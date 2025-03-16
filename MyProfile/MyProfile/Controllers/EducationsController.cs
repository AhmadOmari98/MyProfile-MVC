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
    public class EducationsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public EducationsController(ApplicationDbContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }


        // GET: Educations
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Educations.Include(e => e.Resume);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Educations/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // GET: Educations/Create
        public IActionResult Create()
        {
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name");
            return View();
        }

        // POST: Educations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,DegreeName,SectionName,Grade,Institution,InstitutionLogoPath,DateFrom,DateTo,LogoFile,ResumeId")] Education education)
        {
            if (ModelState.IsValid)
            {
                if (education.LogoFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + education.LogoFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/assets/Image/InstitutionLogo/", fileName);
                    using (var fileStream = new FileStream(path, FileMode.Create))
                    {
                        await education.LogoFile.CopyToAsync(fileStream);
                    }
                    education.InstitutionLogoPath = fileName;
                    education.LogoFile = null;
                }

                _context.Add(education);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", education.ResumeId);
            return View(education);
        }

        // GET: Educations/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations.FindAsync(id);
            if (education == null)
            {
                return NotFound();
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", education.ResumeId);
            return View(education);
        }

        // POST: Educations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DegreeName,SectionName,Grade,Institution,InstitutionLogoPath,DateFrom,DateTo,LogoFile,ResumeId")] Education education)
        {
            if (id != education.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {

                    if (education.LogoFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + education.LogoFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/assets/Image/InstitutionLogo/", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await education.LogoFile.CopyToAsync(fileStream);
                        }
                        education.InstitutionLogoPath = fileName;
                        education.LogoFile = null;
                    }

                    _context.Update(education);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EducationExists(education.Id))
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
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", education.ResumeId);
            return View(education);
        }

        // GET: Educations/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var education = await _context.Educations
                .Include(e => e.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (education == null)
            {
                return NotFound();
            }

            return View(education);
        }

        // POST: Educations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var education = await _context.Educations.FindAsync(id);
            _context.Educations.Remove(education);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EducationExists(int id)
        {
            return _context.Educations.Any(e => e.Id == id);
        }
    }
}
