using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace EduHome.Controllers
{
    public class CoursesController : Controller

    {
        private readonly AppDbContext _db;

        public CoursesController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            ViewBag.CoursesCount = _db.Courses.Count();
            List<Course> courses = _db.Courses.OrderByDescending(x => x.Id).Take(6).ToList();
            return View(courses);
        }

        public IActionResult LoadMoreCourses(int skip)
        {
            if(_db.Courses.Count()<= skip)
            {
                return Content("Go to Hell");
            }
            List<Course> courses = _db.Courses.OrderByDescending(x => x.Id).Skip(skip).Take(6).ToList();
            return PartialView("_LoadCoursesPartial",courses);
        }
    }
}
