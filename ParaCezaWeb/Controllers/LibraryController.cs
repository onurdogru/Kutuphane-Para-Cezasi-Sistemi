using ParaCezaWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ParaCezaWeb.Controllers
{
    public class LibraryController : Controller
    {
        private LibraryDBContext db = new LibraryDBContext();

        [HttpGet]
        public ActionResult CalculateFine()
        {
            //ÜLKE İSİMLERİ İÇİN GET 

            ViewBag.Countries = new SelectList(new List<SelectListItem>
            {
                new SelectListItem { Text = "İspanya", Value = "Spain" },
                 new SelectListItem { Text = "Almanya", Value = "Germany" }
            }, "Value", "Text");




            return View();
        }

        [HttpPost]
        public ActionResult CalculateFine(LibraryFineCalculatorModel model)
        {
            if (ModelState.IsValid)
            {
                // var weekendDays = db.WeekendDays.Select(w => w.DayOfWeek).ToList();
                // model.BusinessDays = CalculateBusinessDays(model.BorrowedDate, model.ReturnedDate, weekendDays);
                model.BusinessDays = CalculateBusinessDays(model.BorrowedDate, model.ReturnedDate);
                model.FineAmount = CalculateFineAmount(model.BusinessDays);

                return View("FineResult", model);


                


            }


            //ÜLKE İSİMLER İÇİN POST
            ViewBag.Countries = new SelectList(new List<SelectListItem>
            {
                     new SelectListItem { Text = "İspanya", Value = "Spain" },
                     new SelectListItem { Text = "Almanya", Value = "Germany" }
            }, "Value", "Text");


            return View(model);




            


        }

        //private int CalculateBusinessDays(DateTime start, DateTime end, List<int> weekendDays)
        private int CalculateBusinessDays(DateTime start, DateTime end)
        {
            int businessDays = 0;
            for (var date = start; date <= end; date = date.AddDays(1))
            {
                //if (!weekendDays.Contains((int)date.DayOfWeek))
                {
                    businessDays++;
                }
            }
            return businessDays;
        }

        private decimal CalculateFineAmount(int businessDays)
        {
            const int allowedDays = 10;
            const decimal finePerDay = 5.0m;

            if (businessDays <= allowedDays)
            {
                return 0;
            }
            return (businessDays - allowedDays) * finePerDay;
        }
    }

}