using System.Collections.Generic;
using System.Linq;
using FinanceApp.Models;

namespace FinanceApp.Services
{
    public class UserService
    {
        private List<User> users = new List<User>();

        public bool Register(string username, string password)
        {
            if (users.Any(u => u.Username == username))
                return false;
            
            users.Add(new User { Username = username, Password = password });
            return true;
        }

        public User Login(string username, string password)
        {
            return users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}