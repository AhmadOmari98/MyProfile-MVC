using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProfile.Models;

namespace MyProfile.Controllers
{
    public class ContactUsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IMailingService _mailingService;

        public ContactUsController(ApplicationDbContext context, IMailingService mailingService)
        {
            _context = context;
            _mailingService = mailingService;
        }


        // GET: ContactUs
        public async Task<IActionResult> Index()
        {

            if (TempData.ContainsKey("showModal"))
            {
                ViewBag.showModal = "Show";
                TempData.Remove("showModal");
            }


            ViewBag.historyContactUs = _context.ContactUss.Include(c => c.Resume).Where(x => x.Respond == "Yes").ToList();
            var applicationDbContext = _context.ContactUss.Include(c => c.Resume);
           return View(await applicationDbContext.Where(x => x.Respond == "No").ToListAsync());
        }

        public IActionResult SelectReplyItId(int? id)
        {
            HttpContext.Session.SetInt32("idReplyIt", (int)id);
            TempData["showModal"] = "Show";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult ReplyAMessage(string replySubject,string replyMessage)
        {

            var contactUsTest = _context.ContactUss.Where(x => x.Id == HttpContext.Session.GetInt32("idReplyIt")).FirstOrDefault();

            string htmlStr = System.IO.File.ReadAllText("wwwroot\\assets\\Files\\TemplateEmail\\ReplyAMessage.html");
            htmlStr = htmlStr.Replace("[sub]", replySubject);
            htmlStr = htmlStr.Replace("[Mass]", replyMessage);
            htmlStr = htmlStr.Replace("[address]", HttpContext.Session.GetString("address"));
            htmlStr = htmlStr.Replace("[email]", HttpContext.Session.GetString("email"));
            htmlStr = htmlStr.Replace("[phone]", HttpContext.Session.GetString("phoneNamber"));
            //###############################################
            MailRequest email1 = new MailRequest();
            email1.ToEmail = contactUsTest.Email;
            email1.Subject = "Reply to your previous message";
            email1.Body = htmlStr;
            email1.Attachments = null;
            _mailingService.SendEmail(email1);


            contactUsTest.Respond = "Yes";
            _context.Update<ContactUs>(contactUsTest);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }


        // GET: ContactUs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUss
                .Include(c => c.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // GET: ContactUs/Create
        public IActionResult Create()
        {
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name");
            return View();
        }

        // POST: ContactUs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Email,Phonenumber,Subject,Message,Respond,ResumeId")] ContactUs contactUs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", contactUs.ResumeId);
            return View(contactUs);
        }

        // GET: ContactUs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUss.FindAsync(id);
            if (contactUs == null)
            {
                return NotFound();
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", contactUs.ResumeId);
            return View(contactUs);
        }

        // POST: ContactUs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Email,Phonenumber,Subject,Message,Respond,ResumeId")] ContactUs contactUs)
        {
            if (id != contactUs.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contactUs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContactUsExists(contactUs.Id))
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
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", contactUs.ResumeId);
            return View(contactUs);
        }

        // GET: ContactUs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contactUs = await _context.ContactUss
                .Include(c => c.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contactUs == null)
            {
                return NotFound();
            }

            return View(contactUs);
        }

        // POST: ContactUs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contactUs = await _context.ContactUss.FindAsync(id);
            _context.ContactUss.Remove(contactUs);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContactUsExists(int id)
        {
            return _context.ContactUss.Any(e => e.Id == id);
        }
    }
}
