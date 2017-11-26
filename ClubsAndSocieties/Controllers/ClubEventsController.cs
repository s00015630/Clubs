using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ClubsAndSocieties.Data;
using ClubsAndSocieties.Models;

namespace ClubsAndSocieties.Controllers
{
    public class ClubEventsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ClubEventsController(ApplicationDbContext context)
        {

            _context = context;
 
        }

        // GET: ClubEvents
        public async Task<IActionResult> Index()
        {
            //string message = "It didnt get into the foreach loop!!";
            var applicationDbContext = _context.ClubEvents.Include(c => c.ClubsAndSociety).Include(c => c.Event);
            //foreach (var item in applicationDbContext)
            //{
            //    if (item != null && item.Event.PublicClubEvent != true)
            //    {
            //        message = "NO EVENTS FOR APPROVAL";
            //        return View(message);
            //    }
            //    else
            //    {
            //        return View(await applicationDbContext.ToListAsync());
            //    }
            //}
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: ClubEvents/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubEvent = await _context.ClubEvents
                .Include(c => c.ClubsAndSociety)
                .Include(c => c.Event)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (clubEvent == null)
            {
                return NotFound();
            }

            return View(clubEvent);
        }

        // GET: ClubEvents/Create
        public IActionResult Create()
        {
            ViewData["ClubID"] = new SelectList(_context.Clubs, "Id", "Chairperson");
            ViewData["EventID"] = new SelectList(_context.Events, "Id", "Id");
            return View();
        }

        // POST: ClubEvents/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ClubID,EventID")] ClubEvent clubEvent)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clubEvent);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ClubID"] = new SelectList(_context.Clubs, "Id", "Chairperson", clubEvent.ClubID);
            ViewData["EventID"] = new SelectList(_context.Events, "Id", "Id", clubEvent.EventID);
            return View(clubEvent);
        }

        // GET: ClubEvents/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubEvent = await _context.ClubEvents.SingleOrDefaultAsync(m => m.Id == id);
            if (clubEvent == null)
            {
                return NotFound();
            }
            ViewData["ClubID"] = new SelectList(_context.Clubs, "Id", "Chairperson", clubEvent.ClubID);
            ViewData["EventID"] = new SelectList(_context.Events, "Id", "Id", clubEvent.EventID);
            return View(clubEvent);
        }

        // POST: ClubEvents/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ClubID,EventID")] ClubEvent clubEvent)
        {
            if (id != clubEvent.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clubEvent);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClubEventExists(clubEvent.Id))
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
            ViewData["ClubID"] = new SelectList(_context.Clubs, "Id", "Chairperson", clubEvent.ClubID);
            ViewData["EventID"] = new SelectList(_context.Events, "Id", "Id", clubEvent.EventID);
            return View(clubEvent);
        }

        // GET: ClubEvents/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clubEvent = await _context.ClubEvents
                .Include(c => c.ClubsAndSociety)
                .Include(c => c.Event)
                .SingleOrDefaultAsync(m => m.Id == id);
            if (clubEvent == null)
            {
                return NotFound();
            }

            return View(clubEvent);
        }

        // POST: ClubEvents/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var clubEvent = await _context.ClubEvents.SingleOrDefaultAsync(m => m.Id == id);
            _context.ClubEvents.Remove(clubEvent);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClubEventExists(int id)
        {
            return _context.ClubEvents.Any(e => e.Id == id);
        }
    }
}
