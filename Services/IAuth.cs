using Electronics_Store.Model;
using Electronics_Store.Services;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronics_Store.Service
{
    
    public interface IAuth
    {
        Task<User> GetUser(string login);
        Task<User> AddUser(User user);
        Task<User> Login(string login, string password);
    }

    
}
