using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceReferenceStudent;
using StudentsWCF.Data;

namespace StudentManagement.Controllers
{
    public class studentsController : Controller
    {
        private readonly StudentClassesDataContext _context;
        private ServiceStudentsClient ss = new ServiceStudentsClient();


        public studentsController(StudentClassesDataContext context)
        {
            _context = context;
        }

        // GET: students
        public async Task<IActionResult> Index()
        {
            return View(ss.GetAllStudents());
        }


        // GET: students/Details/5
        public async Task<IActionResult> Details(int id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var student = await _context.student.FirstOrDefaultAsync(m => m.id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // GET: students/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: students/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("cne,email,firstname,id,lastname,level,phone")] student student)
        {
            if (ModelState.IsValid)
            {
                ss.addStudent(student);
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: students/Edit/5
        public async Task<IActionResult> Edit(int id)
        {
            var student = ss.getStudent(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: students/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]

        public async Task<IActionResult> Edit(string id, [Bind("cne,email,firstname,id,lastname,level,phone")] student student)

        {
            
            if (ModelState.IsValid)
            {
                try
                {
                    ss.UpdateStudent(student);
                }
                catch (DbUpdateConcurrencyException)
                {
                   
                        throw;
                    
                }
                return RedirectToAction(nameof(Index));
            }
            return View(student);
        }

        // GET: students/Delete/5
        public async Task<IActionResult> Delete(student sid)
        {
            if (sid.id == null)
            {
                return NotFound();
            }

            var student = ss.getStudent(sid.id);


            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: students/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var student = await _context.student.FindAsync(id);
            _context.student.Remove(student);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool studentExists(int id)
        {
            return _context.student.Any(e => e.id == id);
        }
    }
}
