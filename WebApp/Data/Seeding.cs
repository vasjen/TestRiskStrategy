using Bogus;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class Seeding
    {
        public static async Task InitializeAsync(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Companies.Any())
                {
                    return;   
                }
                var companies = CreateCompanies(10);
                await context.AddRangeAsync(companies);
                var rnd = new Random();
                foreach (var item in companies)
                {
                    var companId = item.Id;
                    var histories = CreateHistory(rnd.Next(2,10),companId);
                    var employees = CreateEmployees(rnd.Next(4,10),companId);
                    await context.AddRangeAsync(histories);
                    await context.AddRangeAsync(employees);
                    foreach (var employee in employees)
                    {
                        var notes = CreateNotes(rnd.Next(0,3),companId,employee.Id);
                        await context.AddRangeAsync(notes);
                    }
                   
                }
               
                await context.SaveChangesAsync();
            }
        }

        private static List<Employee> CreateEmployees (int count, int CompanyId)
        {
            return 
                new Faker<Employee>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => f.IndexVariable)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Title, f => f.Name.Prefix())
                .RuleFor(u => u.Position, f => f.Name.JobDescriptor())
                .RuleFor(u => u.BirthDate, f => f.Date.Recent(0))
                .RuleFor(u => u.CompanyId, f => f.Random.Int(CompanyId,CompanyId))
                .RuleSet("skip company", f => f.Ignore(x => x.Company))
                .Generate(count)
                .ToList();
        }
        private static List<Company> CreateCompanies (int count)
        {
            return 
                new Faker<Company>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => f.IndexVariable)
                .RuleFor(u => u.Name, f => f.Company.CompanyName())
                .RuleFor(u => u.City, f => f.Address.City())
                .RuleFor(u => u.State, f => f.Address.State())
                .RuleFor(u => u.Address, f => f.Address.StreetAddress())
                .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
                .Generate(count)
                .ToList();
        }

        private static List<History> CreateHistory (int count, int CompanyId)
        {
            return 
                new Faker<History>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => f.IndexVariable)
                .RuleFor(u => u.OrderDate, f => f.Date.Past(65))
                .RuleFor(u => u.OrderCity, f => f.Address.City())
                .RuleFor(u => u.CompanyId, f => f.Random.Int(CompanyId,CompanyId))
                .Generate(count)
                .ToList();
        }
        private static List<Note> CreateNotes (int count, int CompanyId, int EmployeeId)
        {
            return 
                new Faker<Note>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => f.IndexVariable)
                .RuleFor(u => u.InvoiceNumber, f => f.IndexFaker)
                .RuleFor(u => u.CompanyId, f => f.Random.Int(CompanyId,CompanyId))
                .RuleFor(u => u.EmployeeId, f => f.Random.Int(EmployeeId,EmployeeId))
                .RuleSet("skip Employee", f => f.Ignore(x => x.Employee))
                .Generate(count)
                .ToList();
        }
        }
}   