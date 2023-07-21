namespace WebApp.Models
{
    public class History
    {
        public int Id {get;set;}
        public DateTimeOffset OrderDate {get;set;}
        public string OrderCity {get;set;} = string.Empty;
        public int CompanyId {get;set;}
        public Company Company {get;set;} = null!;
        
    }

    //public enum Title {Mr, Ms, Mrs, Sir, Madam, Dr, St}
    
}