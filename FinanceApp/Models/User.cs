namespace FinanceApp.Models
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; } // Note: In a real application, never store passwords as plain text.
    }
}