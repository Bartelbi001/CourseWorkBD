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
    public class CarBrandsController : Controller
    {
        private readonly TransportCompanyContext _context;

        public CarBrandsController(TransportCompanyContext context)
        {
            _context = context;
        }

        // GET: CarBrands
        public async Task<IActionResult> Index()
        {
            return View(await _context.CarBrands.ToListAsync());
        }
    }
}
