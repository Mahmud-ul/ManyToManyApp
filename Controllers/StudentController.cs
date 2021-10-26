using ManytoManyApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ManytoManyApp.Controllers
{
    public class StudentController : Controller
    {
        private readonly ConnectionString _mm;
        public StudentController(ConnectionString mm)
        {
            _mm = mm;
        }
        
        [HttpGet]
        public IActionResult Index()
        {
            IEnumerable<Student> students = _mm.Students.Include(s => s.Department).ToList();
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.departments = _mm.Departments.ToList(); ;
            return View();

        }

        [HttpPost]
        public IActionResult Create(Student student)
        {
            if(ModelState.IsValid)
            {
                _mm.Students.Add(student);
                int i = _mm.SaveChanges();

                if(i>0)
                {
                    return RedirectToAction("Index");
                }

                return ViewBag.ErrorMessage("Faild to Save changes");
            }
            return NotFound();
        }

        [HttpGet]
        public IActionResult Delete( int? id)
        {
            if (id == null)
                return NotFound();

            Student std = _mm.Students.Find(id);

            if (std == null)
                return ViewBag.ErrorMessage("Failed to find data");
           
            _mm.Students.Remove(std);
            int n = _mm.SaveChanges();

            if (n > 0)
                return RedirectToAction("Index");

            return NotFound();
        }

        [HttpGet]
        public IActionResult Update(int? id)
        {
            if (id == null)
                return NotFound();
            Student student = _mm.Students.Find(id);

            if (student == null)
                return ViewBag.ErrorMessage("No data found!");

            ViewBag.departments = _mm.Departments.ToList();
            return View(student);
        }

        [HttpPost]
        public IActionResult Update( Student std)
        {
            if(ModelState.IsValid)
            {
                _mm.Entry(std).State = EntityState.Modified;
                
                int n = _mm.SaveChanges();
                if (n > 0)
                    return RedirectToAction("Index");
                return ViewBag.ErrorMessage("Failed to save data");
            }
            return NotFound();
        }
    }
}
