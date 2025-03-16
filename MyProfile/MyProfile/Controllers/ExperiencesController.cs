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
    public class ExperiencesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public ExperiencesController(ApplicationDbContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }



        // GET: Experiences
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Experiences.Include(e => e.Resume);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Experiences/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experiences
                .Include(e => e.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // GET: Experiences/Create
        public IActionResult Create()
        {
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name");
            return View();
        }

        // POST: Experiences/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CompanyName,Position,Address,CompanyLogoPath,Description,DateFrom,DateTo,LogoFile,ResumeId")] Experience experience)
        {
            if (ModelState.IsValid)
            {

                if (experience.LogoFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + experience.LogoFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/assets/Image/CompanyLogo/", fileName);
                    using (var fileStream1 = new FileStream(path, FileMode.Create))
                    {
                        await experience.LogoFile.CopyToAsync(fileStream1);
                    }
                    experience.CompanyLogoPath = fileName;
                    experience.LogoFile = null;
                }

                _context.Add(experience);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", experience.ResumeId);
            return View(experience);
        }

        // GET: Experiences/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experiences.FindAsync(id);
            if (experience == null)
            {
                return NotFound();
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", experience.ResumeId);
            return View(experience);
        }

        // POST: Experiences/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CompanyName,Position,Address,CompanyLogoPath,Description,DateFrom,DateTo,LogoFile,ResumeId")] Experience experience)
        {
            if (id != experience.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (experience.LogoFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + experience.LogoFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/assets/Image/CompanyLogo/", fileName);
                        using (var fileStream1 = new FileStream(path, FileMode.Create))
                        {
                            await experience.LogoFile.CopyToAsync(fileStream1);
                        }
                        experience.CompanyLogoPath = fileName;
                        experience.LogoFile = null;
                    }

                    _context.Update(experience);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ExperienceExists(experience.Id))
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
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", experience.ResumeId);
            return View(experience);
        }

        // GET: Experiences/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var experience = await _context.Experiences
                .Include(e => e.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (experience == null)
            {
                return NotFound();
            }

            return View(experience);
        }

        // POST: Experiences/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var experience = await _context.Experiences.FindAsync(id);
            _context.Experiences.Remove(experience);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ExperienceExists(int id)
        {
            return _context.Experiences.Any(e => e.Id == id);
        }
    }
}
