using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebApplication10.Models;

namespace WebApplication10.Controllers
{
    public class ArgusModelsController : Controller
    {
        private readonly ArgusContext _context;

        public ArgusModelsController(ArgusContext context)
        {
            _context = context;    
        }

        // GET: ArgusModels
        public async Task<IActionResult> Index()
        {
            return View(await _context.ArgusModel.ToListAsync());
        }

        // GET: ArgusModels/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var argusModel = await _context.ArgusModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (argusModel == null)
            {
                return NotFound();
            }

            return View(argusModel);
        }

        // GET: ArgusModels/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ArgusModels/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,Title")] ArgusModel argusModel)
        {
            if (ModelState.IsValid)
            {
                _context.Add(argusModel);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(argusModel);
        }

        // GET: ArgusModels/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var argusModel = await _context.ArgusModel.SingleOrDefaultAsync(m => m.ID == id);
            if (argusModel == null)
            {
                return NotFound();
            }
            return View(argusModel);
        }

        // POST: ArgusModels/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,Title")] ArgusModel argusModel)
        {
            if (id != argusModel.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(argusModel);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ArgusModelExists(argusModel.ID))
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
            return View(argusModel);
        }

        // GET: ArgusModels/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var argusModel = await _context.ArgusModel
                .SingleOrDefaultAsync(m => m.ID == id);
            if (argusModel == null)
            {
                return NotFound();
            }

            return View(argusModel);
        }

        // POST: ArgusModels/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var argusModel = await _context.ArgusModel.SingleOrDefaultAsync(m => m.ID == id);
            _context.ArgusModel.Remove(argusModel);
            await _context.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        private bool ArgusModelExists(int id)
        {
            return _context.ArgusModel.Any(e => e.ID == id);
        }
    }
}
