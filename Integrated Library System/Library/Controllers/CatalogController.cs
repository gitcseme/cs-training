using System;
using System.Collections.Generic;
using System.Linq;
using Library.ViewModels.Catalog;
using Library.ViewModels.CheckoutModels;
using LibraryData;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Library.Controllers
{
    public class CatalogController : Controller
    {
        public CatalogController(ILibraryAsset asset, ICheckout checkout)
        {
            _Assets = asset;
            _Checkouts = checkout;
        }

        public ILibraryAsset _Assets { get; }
        public ICheckout _Checkouts { get; }

        public IActionResult Index(string searchText)
        {
            var assetModel = _Assets.GetAll();
            var listingResult = assetModel
                .Select(result => new AssetIndexListingModel
                {
                    Id = result.Id,
                    ImageUrl = result.ImageUrl,
                    AuthorOrDiretor = _Assets.GetAuthorOrDirector(result.Id),
                    DeweyCallNumber = _Assets.GetDeweyIndex(result.Id),
                    Title = result.Title,
                    Type = _Assets.GetType(result.Id)
                });
            
            if (searchText != null)
            {
                listingResult = listingResult.Where(data => data.Title.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                data.AuthorOrDiretor.Contains(searchText, StringComparison.OrdinalIgnoreCase) ||
                                data.DeweyCallNumber.Contains(searchText, StringComparison.OrdinalIgnoreCase));
            }

            var model = new AssetIndexModel()
            {
                Assets = listingResult
            };

            return View(model);
        }

        public IActionResult Details(int id)
        {
            var asset = _Assets.GetById(id);
            var currentHolds = _Checkouts.GetCurrentHolds(id)
                .Select(a => new AssetHoldModel
                {
                    HoldPlaced = _Checkouts.GetCurrentHoldPlaced(a.Id).ToString("d"),
                    PatronName = _Checkouts.GetCurrentHoldPatronName(a.Id)
                });

            var model = new AssetDetailModel
            {
                AssetId = asset.Id,
                Title = asset.Title,
                Year = asset.Year,
                Cost = asset.Cost,
                Status = asset.Status.Name,
                ImageUrl = asset.ImageUrl,
                AuthorOrDirector = _Assets.GetAuthorOrDirector(id),
                CurrentLocation = _Assets.GetCurrentLocation(id).Name,
                DeweyCallNumber = _Assets.GetDeweyIndex(id),
                CheckoutHistories = _Checkouts.GetCheckoutHistories(id),
                ISBN = _Assets.GetIsbn(id),
                LatestCheckout = _Checkouts.GetLatestCheckout(id),
                PatronName = _Checkouts.GetCurrentCheckoutPatron(id),
                CurrentHolds = currentHolds
            };

            return View(model);
        }

        public IActionResult Checkout(int id)
        {
            var asset = _Assets.GetById(id);

            var model = new CheckoutModel
            {
                AssetId = id,
                ImageUrl = asset.ImageUrl,
                Title = asset.Title,
                LibraryCardId = "",
                IsCheckedOut = _Checkouts.IsCheckedOut(id)
            };

            return View(model);
        }

        public IActionResult CheckIn(int id)
        {
            _Checkouts.CheckInItem(id);
            return RedirectToAction("Details", new { id = id });
        }

        public IActionResult Hold(int id)
        {
            var asset = _Assets.GetById(id);

            var model = new CheckoutModel
            {
                AssetId = id,
                ImageUrl = asset.ImageUrl,
                Title = asset.Title,
                LibraryCardId = "",
                IsCheckedOut = _Checkouts.IsCheckedOut(id),
                HoldCount = _Checkouts.GetCurrentHolds(id).Count()
            };

            return View(model);
        }

        public IActionResult MarkLost(int assetId)
        {
            _Checkouts.MarkLost(assetId);
            return RedirectToAction("Details", new { id = assetId });
        }

        public IActionResult MarkFound(int assetId)
        {
            _Checkouts.MarkFound(assetId);
            return RedirectToAction("Details", new { id = assetId });
        }

        [HttpPost]
        public IActionResult PlaceCheckout(int assetId, int libraryCardId)
        {
            _Checkouts.CheckOutItem(assetId, libraryCardId);
            return RedirectToAction("Details", new { id = assetId });
        }

        [HttpPost]
        public IActionResult PlaceHold(int assetId, int libraryCardId)
        {
            _Checkouts.PlaceHold(assetId, libraryCardId);
            return RedirectToAction("Details", new { id = assetId });
        }
    }
}
