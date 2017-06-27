using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EF_Sample.Models;

namespace EF_Sample.Controllers
{
    public class SampleModelsController : Controller
    {
        private readonly EF_SampleContext _context;

        public SampleModelsController(EF_SampleContext context)
        {
            _context = context;    
        }

        // GET: SampleModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.SampleModel.ToListAsync());
        }

        // GET: SampleModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleModel = await _context.SampleModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sampleModel == null)
            {
                return NotFound();
            }

            return View(sampleModel);
        }

        // GET: SampleModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SampleModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Name,OtherProperty")] SampleModel sampleModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(sampleModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(sampleModel);
        }

        // GET: SampleModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleModel = await _context.SampleModel.SingleOrDefaultAsync(m => m.ID == id);
            if (sampleModel == null)
            {
                return NotFound();
            }
            return View(sampleModel);
        }

        // POST: SampleModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Name,OtherProperty")] SampleModel sampleModel)
        {
            if (id != sampleModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(sampleModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SampleModelExists(sampleModel.ID))
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
            return View(sampleModel);
        }

        // GET: SampleModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var sampleModel = await _context.SampleModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (sampleModel == null)
            {
                return NotFound();
            }

            return View(sampleModel);
        }

        // POST: SampleModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var sampleModel = await _context.SampleModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.SampleModel.Remove(sampleModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool SampleModelExists(int id)
        {
            return _context.SampleModel.Any(e => e.ID == id);
        }
    }
}
