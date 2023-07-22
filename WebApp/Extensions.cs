
using WebApp.Data.Dto;
using WebApp.Models;

namespace WebApp
{
    public static class Extensions
    {
        public static CompanyDto AsDto(this Company company)
            => new CompanyDto(company.Id, company.Name, company.State,company.Phone);
    }
}