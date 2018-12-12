// EverythingPizza - Group Project
// CIS-2284 - November/December 2018
// Group Members: Alix Field, Sharon Goodrich & Jonathan McPeak
// Page: Controllers/ChatController.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

// Sharon Goodrich sgoodrich1@cnm.edu

namespace EverythingPizza.Controllers
{
    public class ChatController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PepperoniLovers()
        {
            return View();
        }

        public IActionResult SauceIsBoss()
        {
            return View();
        }

        public IActionResult PizzaHutHaters()
        {
            return View();
        }

        public IActionResult CheesePlease()
        {
            return View();
        }

        public IActionResult VeggiesOnly()
        {
            return View();
        }
    }
}