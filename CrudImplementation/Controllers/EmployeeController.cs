using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using CrudImplementation;
using CrudImplementation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Protocols;

namespace CrudImplementation.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _db;
        public IEnumerable<Organisation> organisationList { get; set; }

        public EmployeeController(ApplicationDbContext db)
        {
            _db = db;
            organisationList = _db.Organisation.ToList();

        }

        public IActionResult Index()
        {
            var displaydata = _db.Employees.ToList();
            return View(displaydata);
         }

        public IActionResult create()
        {
            ViewBag.Organisation = new SelectList(organisationList, "OrganisationId", "OrganisationName");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> create(Employee ep)
        {
            if (ModelState.IsValid)
            {
                _db.Add(ep);
                await _db.SaveChangesAsync();
                return RedirectToAction("Index");
            }
            return View(ep);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Organisation = new SelectList(organisationList, "OrganisationId", "OrganisationName");
            var employeedetails = await _db.Employees.FindAsync(id);
            return View(employeedetails);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(Employee nc)
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
            var employeedetails = await _db.Employees.FindAsync(id);
            return View(employeedetails);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            var employeedetails = await _db.Employees.FindAsync(id);
            return View(employeedetails);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Employee sd)
        {
            var employeedetails = await _db.Employees.FindAsync(sd.EmpId);
            _db.Employees.Remove(employeedetails);
            await _db.SaveChangesAsync();
            return RedirectToAction("Index");
        }

    }
}



