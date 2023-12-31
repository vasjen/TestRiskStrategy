namespace WebApp.Models
{
    public class Company
    {
        public int Id {get;set;}
        public string Name {get;set;} = string.Empty;
        public string City {get;set;} = string.Empty;
        public string Address {get;set;} = string.Empty;
        public string State {get;set;} = string.Empty;
        public string Phone {get;set;} = string.Empty;

        public List<Employee> Employees {get;} = new List<Employee>();
        public List<History> Histories {get;} = new List<History>();
        public List<Note> Notes {get;} = new List<Note>();
    }
}