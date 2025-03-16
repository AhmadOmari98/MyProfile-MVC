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
    public class BasicInfoesController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _webHostEnviroment;

        public BasicInfoesController(ApplicationDbContext context, IWebHostEnvironment webHostEnviroment)
        {
            _context = context;
            _webHostEnviroment = webHostEnviroment;
        }


        // GET: BasicInfoes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.BasicInfos.Include(b => b.Resume);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: BasicInfoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicInfo = await _context.BasicInfos
                .Include(b => b.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basicInfo == null)
            {
                return NotFound();
            }

            return View(basicInfo);
        }

        // GET: BasicInfoes/Create
        public IActionResult Create()
        {
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name");
            return View();
        }

        // POST: BasicInfoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FirstName,MiddleName,LastName,Position,LinkLinkedin,LinkGitHub,Email,Phone,Address,AboutMe,Birthday,ImagePath,ResumeId,ImageFile")] BasicInfo basicInfo)
        {
            if (ModelState.IsValid)
            {
                
                if (basicInfo.ImageFile != null)
                {
                    string wwwRootPath = _webHostEnviroment.WebRootPath;
                    string fileName = Guid.NewGuid().ToString() + "_" + basicInfo.ImageFile.FileName;
                    string path = Path.Combine(wwwRootPath + "/assets/Image/ImageUser/", fileName);
                    using (var fileStream1 = new FileStream(path, FileMode.Create))
                    {
                        await basicInfo.ImageFile.CopyToAsync(fileStream1);
                    }
                    basicInfo.ImagePath = fileName;
                    basicInfo.ImageFile = null;
                }
                
                _context.Add(basicInfo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", basicInfo.ResumeId);
            return View(basicInfo);
        }

        // GET: BasicInfoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicInfo = await _context.BasicInfos.FindAsync(id);
            if (basicInfo == null)
            {
                return NotFound();
            }
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", basicInfo.ResumeId);
            return View(basicInfo);
        }

        // POST: BasicInfoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FirstName,MiddleName,LastName,Position,LinkLinkedin,LinkGitHub,Email,Phone,Address,AboutMe,Birthday,ImagePath,ImageFile,ResumeId")] BasicInfo basicInfo)
        {
            if (id != basicInfo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    if (basicInfo.ImageFile != null)
                    {
                        string wwwRootPath = _webHostEnviroment.WebRootPath;
                        string fileName = Guid.NewGuid().ToString() + "_" + basicInfo.ImageFile.FileName;
                        string path = Path.Combine(wwwRootPath + "/assets/Image/ImageUser/", fileName);
                        using (var fileStream1 = new FileStream(path, FileMode.Create))
                        {
                            await basicInfo.ImageFile.CopyToAsync(fileStream1);
                        }
                        basicInfo.ImagePath = fileName;
                        basicInfo.ImageFile = null;
                    }

                    _context.Update(basicInfo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BasicInfoExists(basicInfo.Id))
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
            ViewData["ResumeId"] = new SelectList(_context.resumes, "Id", "Name", basicInfo.ResumeId);
            return View(basicInfo);
        }

        // GET: BasicInfoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var basicInfo = await _context.BasicInfos
                .Include(b => b.Resume)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (basicInfo == null)
            {
                return NotFound();
            }

            return View(basicInfo);
        }

        // POST: BasicInfoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var basicInfo = await _context.BasicInfos.FindAsync(id);
            _context.BasicInfos.Remove(basicInfo);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BasicInfoExists(int id)
        {
            return _context.BasicInfos.Any(e => e.Id == id);
        }
    }
}
