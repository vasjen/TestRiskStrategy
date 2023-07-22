namespace WebApp.Models
{
    public class Employee
    {
        public int Id {get;set;}
        public string FirstName {get;set;} = string.Empty;
        public string LastName {get;set;} = string.Empty;
        public string Title {get;set;} = string.Empty;
        public DateTime BirthDate {get;set;}
        public string Position {get;set;} = string.Empty;
        public int CompanyId {get;set;}
        public Company Company {get;set;} = null!;
        public List<Note> Notes {get;} = new List<Note>();
        
    }

    //public enum Title {Mr, Ms, Mrs, Sir, Madam, Dr, St}
    
}