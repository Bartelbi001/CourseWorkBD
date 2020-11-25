using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TransportCompanyMVCApp;
using TransportCompanyMVCApp.Models;

namespace TransportCompanyMVCApp.Controllers
{
    public class CarsController : Controller
    {
        private readonly TransportCompanyContext _context;

        public CarsController(TransportCompanyContext context)
        {
            _context = context;
        }

        // GET: Cars
        public async Task<IActionResult> Index()
        {
            var transportCompanyContext = _context.Cars.Include(c => c.CarBrand).Include(c => c.CarType);
            return View(await transportCompanyContext.ToListAsync());
        }
    }
}
