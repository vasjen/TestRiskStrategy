namespace WebApp.Models
{
    public class Company
    {
        public int Id {get;set;}
        public string name {get;set;} = string.Empty;

        public List<Employee> Employees {get;} = new List<Employee>();
    }
}