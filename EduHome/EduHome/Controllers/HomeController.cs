
using EduHome.DAL;
using EduHome.Models;
using EduHome.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Controllers
{
    public class HomeController : Controller
    {

        private readonly AppDbContext _db;
        public HomeController(AppDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
           
            HomeVM homeVM = new HomeVM
            {
                Sliders = _db.Sliders.Where(x => !x.IsDeactive).ToList(),
                About = _db.Abouts.FirstOrDefault(),
                Courses = _db.Courses.OrderByDescending(x => x.Id).Take(3).ToList(),
                Services = _db.Services.Where(x => !x.IsDeactive).ToList(),
                Notices = _db.Notices.ToList(),
                Events = _db.Events.OrderByDescending(x=>x.Id).Take(4).ToList(),
                Testimonial = _db.Testimonials.FirstOrDefault(),
                Blogs = _db.Blogs.OrderByDescending(x => x.Id).Take(3).ToList()


            };
            return View(homeVM);
        }

        public IActionResult Privacy()
        {
            return View();
        }

       
        public IActionResult Error()
        {
            return View();
        }
    }
}
