using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Core_MVC.Models;
using Core_MVC.Models.SampleViewModels;

namespace Core_MVC.Controllers
{
    public class SampleController : Controller
    {
        private readonly SampleDbContext _context;

        public SampleController(SampleDbContext context)
        {
            _context = context;    
        }

        // GET: SampleViewModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SampleViewModel.ToListAsync());
        }

        // GET: SampleViewModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleViewModel = await _context.SampleViewModel
                .SingleOrDefaultAsync(m => m.SampleID == id);
            if (sampleViewModel == null)
            {
                return NotFound();
            }

            return View(sampleViewModel);
        }

        // GET: SampleViewModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SampleViewModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SampleID,Text")] SampleViewModel sampleViewModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sampleViewModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sampleViewModel);
        }

        // GET: SampleViewModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleViewModel = await _context.SampleViewModel.SingleOrDefaultAsync(m => m.SampleID == id);
            if (sampleViewModel == null)
            {
                return NotFound();
            }
            return View(sampleViewModel);
        }

        // POST: SampleViewModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SampleID,Text")] SampleViewModel sampleViewModel)
        {
            if (id != sampleViewModel.SampleID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sampleViewModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleViewModelExists(sampleViewModel.SampleID))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction("Index");
            }
            return View(sampleViewModel);
        }

        // GET: SampleViewModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleViewModel = await _context.SampleViewModel
                .SingleOrDefaultAsync(m => m.SampleID == id);
            if (sampleViewModel == null)
            {
                return NotFound();
            }

            return View(sampleViewModel);
        }

        // POST: SampleViewModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sampleViewModel = await _context.SampleViewModel.SingleOrDefaultAsync(m => m.SampleID == id);
            _context.SampleViewModel.Remove(sampleViewModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SampleViewModelExists(int id)
        {
            return _context.SampleViewModel.Any(e => e.SampleID == id);
        }
    }
}
