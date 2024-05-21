using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ParaCezaWeb.Models
{
    public class LibraryFineCalculatorModel
    {
        public DateTime BorrowedDate { get; set; }
        public DateTime ReturnedDate { get; set; }
        public string Country { get; set; }
        public int BusinessDays { get; set; }
        public decimal FineAmount { get; set; }
    }
}