using LibraryData;
using LibraryData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibraryService
{
    public class LibraryBranchService : ILibraryBranch
    {
        public LibraryBranchService(LibraryContext Context)
        {
            this.Context = Context;
        }

        public LibraryContext Context { get; }

        public void Add(LibraryBranch newBranch)
        {
            Context.LibraryBranches.Add(newBranch);
            Context.SaveChanges();
        }

        public LibraryBranch Get(int branchId)
        {
            return GetAll().FirstOrDefault(b => b.Id == branchId);
        }

        public IEnumerable<LibraryBranch> GetAll()
        {
            return Context.LibraryBranches
                .Include(b => b.Patrons)
                .Include(b => b.LibraryAssets);
        }

        public IEnumerable<LibraryAsset> GetAssets(int branchId)
        {
            return Context.LibraryBranches
                .Include(b => b.LibraryAssets)
                .FirstOrDefault(b => b.Id == branchId)
                .LibraryAssets;
        }

        public IEnumerable<string> GetBranchHours(int branchId)
        {
            var hours = Context.BranchHours.Where(h => h.Branch.Id == branchId);

            return DataHelpers.HumanReadableHours(hours);
        }

        public IEnumerable<Patron> GetPatrons(int branchId)
        {
            return Context.LibraryBranches
                .Include(b => b.Patrons)
                .FirstOrDefault(b => b.Id == branchId)
                .Patrons;
        }

        public bool IsBranchOpen(int branchId)
        {
            var currentTimeHour = DateTime.Now.Hour;
            var currentDayOfWeek = (int)DateTime.Now.DayOfWeek + 1; // As 1-7 is coded.
            var hours = Context.BranchHours.Where(h => h.Branch.Id == branchId);
            var todaysHours = hours.FirstOrDefault(h => h.DayOfWeek == currentDayOfWeek);

            var isOpen = currentTimeHour < todaysHours.CloseTime && currentTimeHour > todaysHours.OpenTime;
            return isOpen;
        }
    }
}
