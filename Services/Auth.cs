using Electronics_Store.Model;
using Electronics_Store.Service;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronics_Store.Services
{
    public class Auth : IAuth
    {
        ElectronicsStoreContext _context = new ElectronicsStoreContext();
        public User GetUser(string login)
        {
           var user = _context.Users.Where(u => u.Login == login).FirstOrDefault();
            return user;
        }

        public bool Login(User user)
        {
            var temp = GetUser(user.Login);
            if(user.Login == temp.Login && user.Password == temp.Password)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
