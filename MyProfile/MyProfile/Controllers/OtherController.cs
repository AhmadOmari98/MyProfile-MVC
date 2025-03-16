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
    public class OtherController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public OtherController(ApplicationDbContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }



        // GET: Other
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Others.Include(o => o.Resume);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Other/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var other = await _context.Others
                .Include(o => o.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (other == null)
            {
                return NotFound();
            }

            return View(other);
        }

        // GET: Other/Create
        public IActionResult Create()
        {
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name");
            return View();
        }

        // POST: Other/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,CvPath,ImageSiteBarPath,ResumeId,CvFile,ImageSiteBarFile")] Other other)
        {
            if (ModelState.IsValid)
            {
                if (other.CvFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + other.CvFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/assets/Image/ImageAndFileOther/", fileName);
                    using (var fileStream1 = new FileStream(path, FileMode.Create))
                    {
                        await other.CvFile.CopyToAsync(fileStream1);
                    }
                    other.CvPath = fileName;
                    other.CvFile = null;
                }
                if (other.ImageSiteBarFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + other.ImageSiteBarFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/assets/Image/ImageAndFileOther/", fileName);
                    using (var fileStream1 = new FileStream(path, FileMode.Create))
                    {
                        await other.ImageSiteBarFile.CopyToAsync(fileStream1);
                    }
                    other.ImageSiteBarPath = fileName;
                    other.ImageSiteBarFile = null;
                }

                _context.Add(other);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", other.ResumeId);
            return View(other);
        }

        // GET: Other/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var other = await _context.Others.FindAsync(id);
            if (other == null)
            {
                return NotFound();
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", other.ResumeId);
            return View(other);
        }

        // POST: Other/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,CvPath,ImageSiteBarPath,ResumeId,CvFile,ImageSiteBarFile")] Other other)
        {
            if (id != other.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (other.CvFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + other.CvFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/assets/Image/ImageAndFileOther/", fileName);
                        using (var fileStream1 = new FileStream(path, FileMode.Create))
                        {
                            await other.CvFile.CopyToAsync(fileStream1);
                        }
                        other.CvPath = fileName;
                        other.CvFile = null;
                    }
                    if (other.ImageSiteBarFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + other.ImageSiteBarFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/assets/Image/ImageAndFileOther/", fileName);
                        using (var fileStream1 = new FileStream(path, FileMode.Create))
                        {
                            await other.ImageSiteBarFile.CopyToAsync(fileStream1);
                        }
                        other.ImageSiteBarPath = fileName;
                        other.ImageSiteBarFile = null;
                    }

                    _context.Update(other);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OtherExists(other.Id))
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
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", other.ResumeId);
            return View(other);
        }

        // GET: Other/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var other = await _context.Others
                .Include(o => o.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (other == null)
            {
                return NotFound();
            }

            return View(other);
        }

        // POST: Other/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var other = await _context.Others.FindAsync(id);
            _context.Others.Remove(other);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool OtherExists(int id)
        {
            return _context.Others.Any(e => e.Id == id);
        }
    }
}
