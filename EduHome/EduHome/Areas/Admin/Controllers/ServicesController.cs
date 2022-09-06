using EduHome.DAL;
using EduHome.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduHome.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ServicesController : Controller
    {
        private readonly AppDbContext _db;
        public ServicesController(AppDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
           List<Service> services = _db.Services.ToList();
            return View(services);
        }
        public IActionResult Create()
        {
            
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Service service)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            bool isExist = await _db.Services.AnyAsync(x => x.Title == service.Title);
            if (isExist)
            {
                ModelState.AddModelError("Title", "This service already is exist");
                return View();
            }
            await _db.Services.AddAsync(service);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service service = await _db.Services.FirstOrDefaultAsync(x=>x.Id==id);
            if(service == null)
            {
                return BadRequest();
            }
            return View(service);
        }
        public async Task<IActionResult> Update(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service dbService = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (dbService == null)
            {
                return BadRequest();
            }
            return View(dbService);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(int? id, Service service)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service dbService = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (dbService == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(dbService);
            }
            bool isExist = await _db.Services.AnyAsync(x => x.Title == service.Title&&x.Id!=id);
            if (isExist)
            {
                ModelState.AddModelError("Title", "This service already is exist");
                return View();
            }
            dbService.Title= service.Title;
            dbService.SubTitle= service.SubTitle;
            await _db.SaveChangesAsync();

            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service service = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
            {
                return BadRequest();
            }
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        [ActionName("Delete")]
        public async Task<IActionResult> DeletePost(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service service = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
            {
                return BadRequest();
            }
            service.IsDeactive = true;
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Activity(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Service service = await _db.Services.FirstOrDefaultAsync(x => x.Id == id);
            if (service == null)
            {
                return BadRequest();
            }
            if (service.IsDeactive)
            {
                service.IsDeactive = false;
            }
            else
            {
                service.IsDeactive=true;
            }
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
