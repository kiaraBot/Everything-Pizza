// EverythingPizza - Group Project
// CIS-2284 - November/December 2018
// Group Members: Alix Field, Sharon Goodrich & Jonathan McPeak
// Page: Controllers/HomeController.cs

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using EverythingPizza.Models;

namespace EverythingPizza.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Who we are, and why we're here";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "We want to here your concerns as well as your awesome ideas!";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        //Paypal Payment Action Method
        public IActionResult PayPalBasicPayment()
        {
            ViewBag.Message = "PayPal Basic Payment Demo.";
            return View();
        }
    }
}
