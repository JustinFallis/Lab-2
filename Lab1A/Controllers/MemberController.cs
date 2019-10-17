// I, Justin Fallis, 000398973, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Lab1A.Models;

namespace Lab1A.Controllers
{
    public class MemberController : Controller
    {
        private readonly Lab1AContext _context;

        public MemberController(Lab1AContext context)
        {
            _context = context;
        }

        public async Task<string> Seed()
        {
            int numberOfMembers = 0;
            if (_context.Member.Count() == 0)
            {
                Member member1 = new Member { FirstName = "Justin", LastName = "Hill", UserName = "OhGeeItsJustin", Email = "windinthehill1@hotmail.com", Company = "IBM", Position = "Software Tester", BirthDate = DateTimeOffset.Now };
                Member member2 = new Member { FirstName = "Devon", LastName = "Laslo", UserName = "UnSeenGeeko", Email = "DevonL@hotmail.com", Company = "Apple", Position = "JR Software Developer", BirthDate = DateTimeOffset.Now };
                Member member3 = new Member { FirstName = "Max", LastName = "Vokey", UserName = "Maxisice", Email = "Maxxy@hotmail.com", Company = "Google", Position = "Data Analyest", BirthDate = DateTimeOffset.Now };
                Member member4 = new Member { FirstName = "Curtis", LastName = "Atlee", UserName = "OGCurt", Email = "OGCURT@hotmail.com", Company = "Dell", Position = "Graphic Design Artist", BirthDate = DateTimeOffset.Now };

                _context.AddRange(member1, member2, member3, member4);
                await _context.SaveChangesAsync();
                numberOfMembers = 4;
            }

            return $"{numberOfMembers} Members Added";
        }

        // GET: Member
        public async Task<IActionResult> Index()
        {
            return View(await _context.Member.ToListAsync());
        }

        // GET: Member/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Member/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Member/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,FirstName,LastName,UserName,Email,Company,Position,BirthDate")] Member member)
        {
            if (ModelState.IsValid)
            {
                _context.Add(member);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(member);
        }

        // GET: Member/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member.FindAsync(id);
            if (member == null)
            {
                return NotFound();
            }
            return View(member);
        }

        // POST: Member/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,FirstName,LastName,UserName,Email,Company,Position,BirthDate")] Member member)
        {
            if (id != member.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(member);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!MemberExists(member.ID))
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
            return View(member);
        }

        // GET: Member/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var member = await _context.Member
                .FirstOrDefaultAsync(m => m.ID == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var member = await _context.Member.FindAsync(id);
            _context.Member.Remove(member);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return _context.Member.Any(e => e.ID == id);
        }
    }
}
