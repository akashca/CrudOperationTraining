using CrudImplementation.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;

namespace CrudImplementation.Controllers
{
    public class OrganisationController : Controller
    {
        // GET: OrganisationController
        private readonly ApplicationDbContext _db;
        public OrganisationController(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            var displaydata = _db.Organisation.ToList();
            return View(displaydata);
        }
        public IActionResult create()
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> create(Organisation nec)
        {
            if (ModelState.IsValid)
            {
                _db.Add(nec);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nec);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            var organisationdetails = await _db.Organisation.FindAsync(id);
            return View(organisationdetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Organisation nc)
        {
            if (ModelState.IsValid)
            {
                _db.Update(nc);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(nc);
        }
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return RedirectToAction("Index");
            }
            var organisationdetails = await _db.Organisation.FindAsync(id);
            return View(organisationdetails);
        }
        
        public async Task<IActionResult> Delete(int? id)
        {
            //if (id == null)
            //{
            //    return RedirectToAction("Index");
            //}
            var organisationdetails = await _db.Organisation.FindAsync(id);
            return View(organisationdetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Organisation sd)
        {
            var organisationdetails = await _db.Organisation.FindAsync(sd.OrganisationId);
            _db.Organisation.Remove(organisationdetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}
