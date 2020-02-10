using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.ViewModels.Patron;
using LibraryData;
using LibraryData.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [Authorize]
    public class PatronController : Controller
    {
        public PatronController(IPatron patron)
        {
            _patron = patron;
        }

        public IPatron _patron { get; }

        public IActionResult Index()
        {
            var allPatrons = _patron.GetAll();

            var patronModels = allPatrons.Select(p => new PatronDetaiModel
            {
                Id = p.Id,
                FirstName = p.FirstName,
                LastName = p.LastName,
                LibraryCardId = p.LibraryCard.Id,
                OverdueFees = p.LibraryCard.Fees,
                HomeLibraryBranch = p.HomeLibraryBranch.Name
            }).ToList();

            var model = new PatronIndexModel() { Patrons = patronModels };
            
            return View(model);
        }

        [Authorize(Roles = "Admin")]
        public IActionResult Detail(int patronId)
        {
            var patron = _patron.Get(patronId);

            var model = new PatronDetaiModel
            {
                FirstName = patron.FirstName,
                LastName = patron.LastName,
                Address = patron.Address,
                HomeLibraryBranch = patron.HomeLibraryBranch.Name,
                MemberSince = patron.LibraryCard.Created,
                OverdueFees = patron.LibraryCard.Fees,
                LibraryCardId = patron.LibraryCard.Id,
                Telephone = patron.TelephoneNumber,
                AssetsCheckedout = _patron.GetCheckouts(patronId).ToList() ?? new List<Checkout>(),
                CheckoutHistories = _patron.GetCheckoutHistories(patronId),
                Holds = _patron.GetHolds(patronId)
            };

            return View(model);
        }
    }
}