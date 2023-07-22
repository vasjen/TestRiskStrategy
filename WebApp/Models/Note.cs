namespace WebApp.Models
{
    public class Note
    {
        public int Id {get;set;}
        public int InvoiceNumber {get;set;}
        public int CompanyId {get;set;}
         public int EmployeeId {get;set;}
        public Employee Employee {get;set;} = null!;
        
    }

    //public enum Title {Mr, Ms, Mrs, Sir, Madam, Dr, St}
    
}