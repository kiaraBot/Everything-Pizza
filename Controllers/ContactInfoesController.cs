// EverythingPizza - Group Project
// CIS-2284 - November/December 2018
// Group Members: Alix Field, Sharon Goodrich & Jonathan McPeak
// Page: Controllers/ContactInfoesController.cs

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EverythingPizza.Data;
using EverythingPizza.Models;
using System.Net.Mail;
using System.Text;

/* Alix Field
 * 
 */

namespace EverythingPizza.Controllers
{
    public class ContactInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ContactInfoesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ContactInfoes
        public IActionResult Index()
        {
            // Instantiating and Setting the DbViewModel Properties
            DbViewModel dbvm = new DbViewModel();
            dbvm.ContactItems = _context.ContactInfoes.ToList();

            return View(dbvm);
        }

        // GET: ContactInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        // Alix Field
        public IActionResult Success(ContactInfo contactInfo )
        {
            return View(contactInfo);
        }

        // GET: ContactInfoes/Create
        public IActionResult Create()
        {
            return View();
        }


        // POST: ContactInfoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.

        // POST: ContactInfoes/Create
        // ------------------------------------------------------------------------------------
        // Code provided by Robert Garner @ https://robgarnerblog.wordpress.com/2016/07/29/mvc-contact-forms/ 
        // Modified By: Alix Field 11.24.2018
        // ------------------------------------------------------------------------------------
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ContactInfo contactInfo)
        {
            if (ModelState.IsValid)
            {


                // Send email to notify administrator of new contact message 
                // Alix Field_11.24.2018
                try
                {
                    MailMessage msg = new MailMessage();
                    SmtpClient client = new SmtpClient
                    {

                        // Gmail is the smtp client
                        Host = "smtp.gmail.com",
                        Port = 587,
                        EnableSsl = true,
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new System.Net.NetworkCredential("afield08@gmail.com", "T@t0rT0t232") // This probably isn't the best idea, leaving the password here. Alix.
                    };

                    MailAddress from = new MailAddress(contactInfo.Email.ToString());

                    StringBuilder sb = new StringBuilder();
                    sb.Append("First Name: " + contactInfo.FirstName);
                    sb.Append(Environment.NewLine);

                    sb.Append("Last Name: " + contactInfo.LastName);
                    sb.Append(Environment.NewLine);

                    sb.Append("Email: " + contactInfo.Email);
                    sb.Append(Environment.NewLine);

                    sb.Append("Comments: " + contactInfo.Comments);
                    sb.Append(Environment.NewLine);

                    //sb.Append(contactInfo.LastName);
                    //sb.Append(Environment.NewLine);

                    msg.From = from;
                    msg.To.Add("afield08@gmail.com");
                    msg.Subject = "New Customer Contact";
                    msg.IsBodyHtml = false;
                    msg.Body = sb.ToString();

                    // Saving Contact Info to the Database
                    _context.Add(contactInfo);
                    _context.SaveChangesAsync();

                    client.Send(msg);

                    return View("Success");
                }
                catch (Exception)
                {
                    return View("Error");
                }


                //return RedirectToAction(nameof(Index));
            }
            return View(contactInfo);
        }

        // GET: ContactInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfoes.FindAsync(id);
            if (contactInfo == null)
            {
                return NotFound();
            }
            return View(contactInfo);
        }

        // POST: ContactInfoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,LastName,Email,Comments,TypeOfRequest,IsIdea,IsConcern")] ContactInfo contactInfo)
        {
            if (id != contactInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactInfoExists(contactInfo.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contactInfo);
        }

        // GET: ContactInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactInfo = await _context.ContactInfoes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactInfo == null)
            {
                return NotFound();
            }

            return View(contactInfo);
        }

        // POST: ContactInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactInfo = await _context.ContactInfoes.FindAsync(id);
            _context.ContactInfoes.Remove(contactInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactInfoExists(int id)
        {
            return _context.ContactInfoes.Any(e => e.Id == id);
        }
    }
}
