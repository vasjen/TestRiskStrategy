using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApp.Data;
using WebApp.Models;

namespace WebApp.Controllers;

public class DataController : Controller
{
    private readonly ILogger<DataController> _logger;
    private readonly ApplicationDbContext _context;

    public DataController(ILogger<DataController> logger, ApplicationDbContext context)
    {
        _logger = logger;
        _context = context;
    }
    [HttpGet]
   public async Task<IActionResult> Histories(int CompanyId)
   {
        var result = await _context.Histories
                           .AsNoTracking()
                           .Where(p => p.CompanyId == CompanyId)
                           .ToListAsync();
        return Ok(result);  
   }
    [HttpGet]
   public async Task<IActionResult> Notes(int CompanyId)
   {
        var result = await _context.Notes
                           .AsNoTracking()
                           .Where(p => p.CompanyId == CompanyId)
                           .Include(p => p.Employee)
                           .ToListAsync();

        var options = new JsonSerializerOptions
        {
            ReferenceHandler = ReferenceHandler.Preserve
        };
                var json = JsonSerializer.Serialize(result, options);
        return Content(json, "application/json"); 
   }
   
   public async Task<IActionResult> Employees(int CompanyId)
   {
        
        var result = await _context.Employees
                           .Where(p => p.CompanyId == CompanyId)
                           .ToListAsync();
        return Ok(result);  
   }
}
