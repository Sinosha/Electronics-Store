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
        Encrypt encrypt = new Encrypt();
        public User GetUser(string login)
        {
           var user = _context.Users.Where(u => u.Login == login).FirstOrDefault();
            return user;
        }

        public bool Login(User user, string password)
        {
            var temp = GetUser(user.Login);
            string tempPassword = encrypt.HashPassword(password, user.Salt);
            if(user.Login == temp.Login && user.Password == tempPassword)
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
