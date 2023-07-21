namespace WebApp.Models
{
    public class Note
    {
        public int Id {get;set;}
        public int InvoiceNumber {get;set;}
        public Employee? Employee {get;set;}
        public int CompanyId {get;set;}
        public Company Company {get;set;} = null!;
        
    }

    //public enum Title {Mr, Ms, Mrs, Sir, Madam, Dr, St}
    
}