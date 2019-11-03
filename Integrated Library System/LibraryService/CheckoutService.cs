using LibraryData;
using LibraryData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryService
{
    public class CheckoutService : ICheckout
    {
        public CheckoutService(LibraryContext context)
        {
            Context = context;
        }

        public LibraryContext Context { get; }

        public void Add(Checkout newCheckout)
        {
            Context.Checkouts.Add(newCheckout);
            Context.SaveChanges();
        }

        public IEnumerable<Checkout> GetAll()
        {
            return Context.Checkouts;
        }

        public Checkout GetById(int checkoutId)
        {
            return GetAll().FirstOrDefault(checkout => checkout.Id == checkoutId);
        }

        public IEnumerable<CheckoutHistory> GetCheckoutHistories(int id)
        {
            var histories = Context.CheckoutHistories
                .Include(ch => ch.LibraryAsset)
                .Include(ch => ch.LibraryCard)
                .Where(ch => ch.LibraryAsset.Id == id);

            return histories;
        }

        public IEnumerable<Hold> GetCurrentHolds(int id)
        {
            return Context.Holds
                .Include(h => h.LibraryAsset)
                .Where(h => h.LibraryAsset.Id == id);
        }

        public Checkout GetLatestCheckout(int assetId)
        {
            return Context.Checkouts
                .Where(c => c.LibraryAsset.Id == assetId)
                .OrderBy(c => c.Since)
                .FirstOrDefault();
        }

        public void MarkFound(int assetId)
        {
            DateTime now = DateTime.Now;

            UpdateAssetStatus(assetId, "Available");
            RemoveExistingCheckout(assetId);
            CloseExistingCheckoutHistory(assetId, now);

            Context.SaveChanges();
        }

        private void UpdateAssetStatus(int assetId, string v)
        {
            LibraryAsset item = Context.LibraryAssets
                .FirstOrDefault(asset => asset.Id == assetId);

            Context.Update(item);

            item.Status = Context.Statuses
                .FirstOrDefault(status => status.Name == v);
        }

        private void CloseExistingCheckoutHistory(int assetId, DateTime now)
        {
            var history = Context.CheckoutHistories
                .FirstOrDefault(h => h.LibraryAsset.Id == assetId && h.CheckedIn == null);

            if (history != null)
            {
                Context.Update(history);
                history.CheckedIn = now;
            }
        }

        private void RemoveExistingCheckout(int assetId)
        {
            var checkout = Context.Checkouts
                .FirstOrDefault(co => co.LibraryAsset.Id == assetId);

            if (checkout != null)
                Context.Remove(checkout);
        }

        public void MarkLost(int assetId)
        {
            UpdateAssetStatus(assetId, "Lost");
            Context.SaveChanges();
        }

        public void CheckOutItem(int assetId, int libraryCardId)
        {
            if (IsCheckedOut(assetId)) return;

            var item = Context.LibraryAssets
                .Include(a => a.Status)
                .FirstOrDefault(a => a.Id == assetId);
            UpdateAssetStatus(assetId, "Checked Out");

            var libraryCard = Context.LibraryCards
                .Include(card => card.Checkouts)
                .FirstOrDefault(card => card.Id == libraryCardId);

            var now = DateTime.Now;
            var checkout = new Checkout
            {
                LibraryAsset = item,
                LibraryCard = libraryCard,
                Since = now,
                Until = GetDefaultCheckoutTime(now)
            };
            Context.Checkouts.Add(checkout);

            var checkoutHistory = new CheckoutHistory
            {
                CheckedOut = now,
                LibraryAsset = item,
                LibraryCard = libraryCard
            };
            Context.CheckoutHistories.Add(checkoutHistory);

            Context.SaveChanges();
        }

        private DateTime GetDefaultCheckoutTime(DateTime now)
        {
            return now.AddDays(30);
        }

        public bool IsCheckedOut(int assetId)
        {
            return Context.Checkouts
                .Where(co => co.LibraryAsset.Id == assetId)
                .Any();
        }

        public void CheckInItem(int assetId)
        {
            var now = DateTime.Now;
            var item = Context.LibraryAssets.FirstOrDefault(a => a.Id == assetId);

            // Remove any existing checkouts on the item
            RemoveExistingCheckout(assetId);

            // close any checkout history
            CloseExistingCheckoutHistory(assetId, now);

            // Look for existing hold on the item
            var currentHolds = Context.Holds
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .Where(h => h.LibraryAsset.Id == assetId);

            //if there are holds, checkout the item to the librarycard with the earliest hold.
            if (currentHolds.Any())
            {
                CheckoutToEarliestHold(assetId, currentHolds);
                return;
            }

            // Otherwise, update the item status to available.
            UpdateAssetStatus(assetId, "Available");

            Context.SaveChanges();
        }

        private void CheckoutToEarliestHold(int assetId, IQueryable<Hold> currentHolds)
        {
            var earliestHold = currentHolds
                .OrderBy(holds => holds.HoldPlaced)
                .FirstOrDefault();

            var card = earliestHold.LibraryCard;

            Context.Remove(earliestHold);
            Context.SaveChanges();

            CheckOutItem(assetId, card.Id);
        }

        public void PlaceHold(int assetId, int libraryCardId)
        {
            var now = DateTime.Now;
            var asset = Context.LibraryAssets
                .Include(a => a.Status)
                .FirstOrDefault(a => a.Id == assetId);

            var card = Context.LibraryCards
                .FirstOrDefault(card => card.Id == libraryCardId);

            if (asset.Status.Name == "Available")
                UpdateAssetStatus(assetId, "On Hold");

            var hold = new Hold
            {
                HoldPlaced = now,
                LibraryAsset = asset,
                LibraryCard = card
            };

            Context.Holds.Add(hold);
            Context.SaveChanges();
        }

        public string GetCurrentHoldPatronName(int holdId)
        {
            var hold = Context.Holds
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .FirstOrDefault(h => h.Id == holdId);

            var cardId = hold?.LibraryCard.Id;

            var patron = Context.Patrons
                .Include(p => p.LibraryCard)
                .FirstOrDefault(p => p.LibraryCard.Id == cardId);

            return patron?.FirstName + " " + patron?.LastName;
        }

        public DateTime GetCurrentHoldPlaced(int holdId)
        {
            return Context.Holds
                .Include(h => h.LibraryAsset)
                .Include(h => h.LibraryCard)
                .FirstOrDefault(h => h.Id == holdId)
                .HoldPlaced;
        }

        public string GetCurrentCheckoutPatron(int assetId)
        {
            var checkout = Context.Checkouts
                .Include(co => co.LibraryCard)
                .Include(co => co.LibraryAsset)
                .FirstOrDefault(co => co.LibraryAsset.Id == assetId);

            if (checkout == null)
            {
                return "";
            }

            var cardId = checkout.LibraryCard.Id; 

            var patron = Context.Patrons
                .Include(p => p.LibraryCard)
                .FirstOrDefault(p => p.LibraryCard.Id == cardId);

            return patron?.FirstName + " " + patron?.LastName;
        }
    }
}
