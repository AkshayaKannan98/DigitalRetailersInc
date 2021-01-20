using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using OnlineShopping.Models;


using Microsoft.EntityFrameworkCore;



namespace OnlineShopping.Controllers
{
    public class DashboardController : Controller
    {
        

        private readonly ECommerceDbContext _context;
        public DashboardController(ECommerceDbContext context)
        {
            _context = context;
        }
        public async Task<ActionResult> Index()
        {
            return View(await _context.Laptops.ToListAsync());
        }

        // GET: DashboardController/Details/5
        public async Task<ActionResult> Details(int? sno)
        {
            if (sno == null)
            {
                return NotFound();
            }
            var laptop = await _context.Laptops.FirstOrDefaultAsync(x => x.Sno == sno);
            if (laptop == null)
            {
                return NotFound();
            }
            return View(laptop);
        }

        
        
        
    }
}
