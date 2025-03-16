using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MyProfile.Models;

namespace MyProfile.Controllers
{
    public class CertificationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public CertificationsController(ApplicationDbContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }


        // GET: Certifications
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Certifications.Include(c => c.Resume);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Certifications/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications
                .Include(c => c.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // GET: Certifications/Create
        public IActionResult Create()
        {
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name");
            return View();
        }

        // POST: Certifications/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CourseName,InstitutionName,InstitutionLogoPath,Link,DateCourse,LogoFile,ResumeId")] Certification certification)
        {
            if (ModelState.IsValid)
            {
                if (certification.LogoFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + certification.LogoFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/assets/Image/certificationPath/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await certification.LogoFile.CopyToAsync(fileStream);
                    }
                    certification.InstitutionLogoPath = fileName;
                    certification.LogoFile = null;
                }

                _context.Add(certification);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", certification.ResumeId);
            return View(certification);
        }

        // GET: Certifications/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications.FindAsync(id);
            if (certification == null)
            {
                return NotFound();
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", certification.ResumeId);
            return View(certification);
        }

        // POST: Certifications/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CourseName,InstitutionName,InstitutionLogoPath,Link,DateCourse,LogoFile,ResumeId")] Certification certification)
        {
            if (id != certification.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (certification.LogoFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + certification.LogoFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/assets/Image/certificationPath/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await certification.LogoFile.CopyToAsync(fileStream);
                        }
                        certification.InstitutionLogoPath = fileName;
                        certification.LogoFile = null;
                    }

                    _context.Update(certification);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CertificationExists(certification.Id))
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
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", certification.ResumeId);
            return View(certification);
        }

        // GET: Certifications/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var certification = await _context.Certifications
                .Include(c => c.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (certification == null)
            {
                return NotFound();
            }

            return View(certification);
        }

        // POST: Certifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var certification = await _context.Certifications.FindAsync(id);
            _context.Certifications.Remove(certification);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CertificationExists(int id)
        {
            return _context.Certifications.Any(e => e.Id == id);
        }
    }
}
