namespace WebApp.Models
{
    public class Employee
    {
        public int Id {get;set;}
        public string FirstName {get;set;} = string.Empty;
        public string LastName {get;set;} = string.Empty;
        public string Title {get;set;} = string.Empty;
        public DateTimeOffset BirthDate {get;set;}
        public string Position {get;set;} = string.Empty;
        public int CompanyId {get;set;}
        public Company Company {get;set;} = null!;
        public int NoteId {get;set;}
        public Note Note {get;set;} = null!;
        
    }

    //public enum Title {Mr, Ms, Mrs, Sir, Madam, Dr, St}
    
}