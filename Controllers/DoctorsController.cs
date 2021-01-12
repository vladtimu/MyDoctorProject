﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TimuVladProiect.Data;
using TimuVladProiect.Models;
using TimuVladProiect.Models.AppointmentViewModel;

namespace TimuVladProiect.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly ServiceContext _context;

        public DoctorsController(ServiceContext context)
        {
            _context = context;
        }

        // GET: Doctors
        public async Task<IActionResult> Index( int? id, int? serviceID)
        {
            var viewModel = new DoctorIndexData();
            viewModel.Doctors = await _context.Doctors
            .Include(i => i.DoctorServices)
            .ThenInclude(i => i.Service)
            .ThenInclude(i => i.Appointments)
            .ThenInclude(i => i.User)
            .AsNoTracking()
            .OrderBy(i => i.DoctorName)
            .ToListAsync();
            if (id != null)
            {
                ViewData["DoctorID"] = id.Value;
                Doctor doctor = viewModel.Doctors.Where(
                i => i.ID == id.Value).Single();
                viewModel.Services = doctor.DoctorServices.Select(s => s.Service);
            }
            if (serviceID != null)
            {
                ViewData["serviceID"] = serviceID.Value;
                viewModel.Appointments = viewModel.Services.Where(
                x => x.ID == serviceID).Single().Appointments;
            }
            return View(viewModel);
        
    }

        // GET: Doctors/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // GET: Doctors/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Doctors/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID,DoctorName")] Doctor doctor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(doctor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(doctor);
        }

        // GET: Doctors/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors.Include(i => i.DoctorServices).ThenInclude(i => i.Service).AsNoTracking().FirstOrDefaultAsync(m => m.ID == id);
            if (doctor == null)
            {
                return NotFound();
            }
            PopulateAvailableAppointmnetData(doctor);
            return View(doctor);
        }
        private void PopulateAvailableAppointmnetData(Doctor doctor)
        {
            var allServices = _context.Services;
            var doctorServices = new HashSet<int>(doctor.DoctorServices.Select(c => c.ServiceID));
            var viewModel = new List<AvailableAppointmentData>();
            foreach (var service in allServices)
            {
                viewModel.Add(new AvailableAppointmentData
                {
                    ServiceID = service.ID,
                    Name = service.Name,
                    IsAvailable = doctorServices.Contains(service.ID)
                });
            }
            ViewData["Services"] = viewModel;
        }

        // POST: Doctors/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID,DoctorName")] Doctor doctor)
        {
            if (id != doctor.ID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(doctor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DoctorExists(doctor.ID))
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
            return View(doctor);
        }

        // GET: Doctors/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var doctor = await _context.Doctors
                .FirstOrDefaultAsync(m => m.ID == id);
            if (doctor == null)
            {
                return NotFound();
            }

            return View(doctor);
        }

        // POST: Doctors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var doctor = await _context.Doctors.FindAsync(id);
            _context.Doctors.Remove(doctor);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DoctorExists(int id)
        {
            return _context.Doctors.Any(e => e.ID == id);
        }
    }
}
