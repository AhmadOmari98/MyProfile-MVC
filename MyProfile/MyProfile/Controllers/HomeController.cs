using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Logging;
using MyProfile.Models;

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace MyProfile.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;
        private readonly IMailingService _mailingService;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context, IMailingService mailingService)
        {
            _logger = logger;
            _context = context;
            _mailingService = mailingService;
        }

        public IActionResult Index()
        {
            var basicInfo = _context.BasicInfos.Where(x => x.Id == 1).FirstOrDefault();
            HttpContext.Session.SetString("linkLinkedin", basicInfo.LinkLinkedin);
            HttpContext.Session.SetString("linkGitHub", basicInfo.LinkGitHub);
            HttpContext.Session.SetString("email", basicInfo.Email);
            HttpContext.Session.SetString("fName", basicInfo.FirstName);
            HttpContext.Session.SetString("mName", basicInfo.MiddleName);
            HttpContext.Session.SetString("lName", basicInfo.LastName);
            HttpContext.Session.SetString("position", basicInfo.Position);
            HttpContext.Session.SetString("phoneNamber", basicInfo.Phone);
            HttpContext.Session.SetString("address", basicInfo.Address);
            ViewBag.myBasicInfo = basicInfo;

            //-------------------------------------------------------------------
            ViewBag.educations = _context.Educations.OrderByDescending(x => x.DateTo).ToList();
            ViewBag.experiences = _context.Experiences.OrderByDescending(x => x.DateTo).ToList();
            //-------------------------------------------------------------------
            ViewBag.skillsProgrammingLanguages = _context.Skills.Where(x => x.CategoryName == "Programming Languages").ToList();
            ViewBag.skillsDatabase = _context.Skills.Where(x => x.CategoryName == "Database").ToList();
            ViewBag.skillsOther = _context.Skills.Where(x => x.CategoryName == "Other").ToList();
            ViewBag.skillsBackend = _context.Skills.Where(x => x.CategoryName == "Backend").ToList();
            ViewBag.skillsFrontend = _context.Skills.Where(x => x.CategoryName == "Frontend").ToList();
            //-------------------------------------------------------------------
            ViewBag.projects = _context.Projects.OrderByDescending(x => x.DateTo).ToList();
            //-------------------------------------------------------------------
            ViewBag.certifications = _context.Certifications.OrderByDescending(x => x.DateCourse).ToList();
            //-------------------------------------------------------------------
            ViewBag.languages = _context.Languages.ToList();
            //-------------------------------------------------------------------
            var other = _context.Others.Where(x => x.Id == 1).FirstOrDefault();
            HttpContext.Session.SetString("cvPath", other.CvPath);
            HttpContext.Session.SetString("imageSiteBarPath", other.ImageSiteBarPath);


            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateNewContactUs([Bind("Id,Name,Email,Phonenumber,Subject,Message,Respond,ResumeId")] ContactUs contactUs, string copyMessage)
        {
            if (ModelState.IsValid)
            {
                contactUs.ResumeId = 1;
                contactUs.Respond = "No";
                _context.Add(contactUs);
                await _context.SaveChangesAsync();
                //###############################################
                if (copyMessage != null)
                {

                    string htmlStr = System.IO.File.ReadAllText("wwwroot\\assets\\Files\\TemplateEmail\\index.html");
                    htmlStr = htmlStr.Replace("[sub]", contactUs.Subject);
                    htmlStr = htmlStr.Replace("[Mass]", contactUs.Message);
                    htmlStr = htmlStr.Replace("[address]", HttpContext.Session.GetString("address"));
                    htmlStr = htmlStr.Replace("[email]", HttpContext.Session.GetString("email"));
                    htmlStr = htmlStr.Replace("[phone]", HttpContext.Session.GetString("phoneNamber"));
                    //###############################################
                    MailRequest email1 = new MailRequest();
                    email1.ToEmail = contactUs.Email;
                    email1.Subject = contactUs.Subject;
                    email1.Body = htmlStr;
                    email1.Attachments = null;
                    _mailingService.SendEmail(email1);

                }
                //###############################################
                //Send to Me
                string htmlStrMe = System.IO.File.ReadAllText("wwwroot\\assets\\Files\\TemplateEmail\\indexSenderInfo.html");
                htmlStrMe = htmlStrMe.Replace("[Sender-Name]", contactUs.Name);
                htmlStrMe = htmlStrMe.Replace("[Sender-Email]", contactUs.Email);
                htmlStrMe = htmlStrMe.Replace("[Sender-Phone]", contactUs.Phonenumber);
                if (copyMessage != null)
                {
                    htmlStrMe = htmlStrMe.Replace("[Take a copy of the e-mail]", "True");
                }
                else
                {
                    htmlStrMe = htmlStrMe.Replace("[Take a copy of the e-mail]", "False");
                }
                htmlStrMe = htmlStrMe.Replace("[sub]", contactUs.Subject);
                htmlStrMe = htmlStrMe.Replace("[Mass]", contactUs.Message);
                htmlStrMe = htmlStrMe.Replace("[address]", HttpContext.Session.GetString("address"));
                htmlStrMe = htmlStrMe.Replace("[email]", HttpContext.Session.GetString("email"));
                htmlStrMe = htmlStrMe.Replace("[phone]", HttpContext.Session.GetString("phoneNamber"));
                //###############################################
                MailRequest email2 = new MailRequest();
                email2.ToEmail = HttpContext.Session.GetString("email");
                email2.Subject = "Copies of someone's message to you through your MyProfile";
                email2.Body = htmlStrMe;
                email2.Attachments = null;
                _mailingService.SendEmail(email2);
                //###############################################



                return RedirectToAction(nameof(Index));

                
            }
            return RedirectToAction(nameof(Index));
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
    }
}
