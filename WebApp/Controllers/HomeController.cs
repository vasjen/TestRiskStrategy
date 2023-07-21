using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
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
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
    public IActionResult Table()
    {
        var data = _context.Employees.ToList();
        foreach (var item in data)
        {
            System.Console.WriteLine("Hey");
            System.Console.WriteLine(item.Position);
        }
        return View(data);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
