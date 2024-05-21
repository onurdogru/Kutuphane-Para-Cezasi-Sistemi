using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ParaCezaWeb.Models
{
    public class LibraryDBContext : DbContext
    {
        public LibraryDBContext() : base("name=LibraryDBContext")
        {
        }

        public DbSet<WeekendDay> WeekendDays { get; set; }
    }

    public class WeekendDay
    {
        public int Id { get; set; }
        public int DayOfWeek { get; set; }
    }
}