﻿using LibraryData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.ViewModels.Patron
{
    public class PatronDetaiModel
    {
        public int Id { get; set; }
        public int LibraryCardId { get; set; }
        public decimal OverdueFees { get; set; }
        public DateTime MemberSince { get; set; }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        public string Address { get; set; }
        public string Telephone { get; set; }
        public string HomeLibraryBranch { get; set; }
        
        public IEnumerable<Checkout> AssetsCheckedout { get; set; }
        public IEnumerable<CheckoutHistory> CheckoutHistories { get; set; }
        public IEnumerable<Hold> Holds { get; set; }
    }
}
