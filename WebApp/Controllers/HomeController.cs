using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplicationDbContext _context;

    public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }

    
    public IActionResult Index()
    {
        var data = _context.Companies
                    .AsNoTracking()
                    .ToList();
        return View(data);
    }
    public IActionResult Privacy()
    {
        return View(); 
    }
   
    public IActionResult Detail(int id)
    {
        
        var company = _context.Companies
                    .Where(p => p.Id == id)
                    .Include(p => p.Employees)
                    .Include(p => p.Notes)
                    .Include(p => p.Histories)
                    .Single();
        if (company is null)
        {
            return BadRequest();
        }                    
        return View(company);
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
