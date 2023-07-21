using Bogus;
using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class Seeding
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Companies.Any())
                {
                    return;   
                }
                var comapny = new Company{
                    Id = 1,
                    Name = "Company name",
                    City = "City",
                    Address= "Some address",
                    State = "State",
                    Phone = "phone"
                };
                var note = new Note
                {
                    Id = 1,
                    InvoiceNumber = 31263,
                    CompanyId = 1
                };
                var users = new Faker<Employee>()
                .StrictMode(false)
                .RuleFor(u => u.Id, f => f.IndexVariable)
                .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                .RuleFor(u => u.LastName, f => f.Name.LastName())
                .RuleFor(u => u.Title, f => f.Name.Prefix())
                .RuleFor(u => u.Position, f => f.Name.JobDescriptor())
                .RuleFor(u => u.BirthDate, f => f.Date.Recent(0))
                .RuleFor(u => u.CompanyId, f => f.Random.Int(1,1))
                .RuleFor(u => u.NoteId, f => f.Random.Int(1,1))
                .RuleSet("skip company", f => f.Ignore(x => x.Company))
                .RuleSet("skip note", f => f.Ignore(x => x.Note))
               // .RuleFor(u => u.Title, f => f.Address.State()+ " " + f.Address.City() + " " + f.Address.StreetAddress())
                .Generate(10)
                
                .ToList();
                
               
                context.Add(comapny);
                context.Add(note);
                context.AddRange(users);
                context.SaveChanges();
            }
        }
        }
}   