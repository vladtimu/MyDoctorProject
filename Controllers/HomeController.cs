using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using TimuVladProiect.Models;
using TimuVladProiect.Data;
using TimuVladProiect.Models.AppointmentViewModel;


namespace TimuVladProiect.Controllers
{
    public class HomeController : Controller
    {
        private readonly ServiceContext _context;
        public HomeController(ServiceContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Statistics()
        {
            IQueryable<AppointmentGroup> data =
            from order in _context.Appointments
            group order by order.DataProgramare into dateGroup
            select new AppointmentGroup()
            {
                AppointmentDate = dateGroup.Key,
                ReservationsCount = dateGroup.Count()
            };
            return View(await data.AsNoTracking().ToListAsync());
        }

       /* private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }*/

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        public IActionResult Chat()
        {
            return View();
        }
    }
}
