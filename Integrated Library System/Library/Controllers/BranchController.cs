using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.ViewModels.Branch;
using LibraryData;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    public class BranchController : Controller
    {
        public BranchController(ILibraryBranch libbraryBranch)
        {
            _branchService = libbraryBranch;
        }

        public ILibraryBranch _branchService { get; }

        public IActionResult Index()
        {
            var branches = _branchService.GetAll().Select(branch => new BranchDetailModel
            {
                Id = branch.Id,
                Name = branch.Name,
                IsOpen = _branchService.IsBranchOpen(branch.Id),
                NumberOfAssets = _branchService.GetAssets(branch.Id).Count(),
                NumberOfPatrons = _branchService.GetPatrons(branch.Id).Count()
            });

            var model = new BranchIndexModel()
            {
                Branches = branches
            };

            return View(model);
        }

        public IActionResult Detail(int id)
        {
            var branch = _branchService.Get(id);
            var model = new BranchDetailModel
            {
                Name = branch.Name,
                Description = branch.Description,
                Address = branch.Address,
                Telephone = branch.Telephone,
                OpenDate = branch.OpenDate.ToString("yyyy-MM-dd"),
                NumberOfPatrons = _branchService.GetPatrons(id).Count(),
                NumberOfAssets = _branchService.GetAssets(id).Count(),
                TotalAssetValue = _branchService.GetAssets(id).Sum(a => a.Cost),
                ImageUrl = branch.ImageUrl,
                HoursOpen = _branchService.GetBranchHours(id)
            };

            return View(model);
        }

    }
}