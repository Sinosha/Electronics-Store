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
        public static Auth Instance { get => AuthCreate.Instance; }
        private readonly IEncrypt _encrypt = new Encrypt();
        ElectronicsStoreContext _context = new ElectronicsStoreContext();

        public async Task<User> GetUser(string login)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Login == login) ?? new User();
        }
        public async Task<User> AddUser(User user)
        {
            user.Salt = Guid.NewGuid().ToString();
            user.Password = _encrypt.HashPassword(user.Password, user.Salt);

            _context.Users.Add(user);     //Добавить в DbContext public DbSet<User> Users {get;set;}
            await _context.SaveChangesAsync();
            return _context.Users.Last();
        }

        public async Task<User> Login(string login, string password)
        {
            var user = await GetUser(login);
            if (user.Password == _encrypt.HashPassword(password, user.Salt))
            {
                MessageBox.Show("Succ");
            }
            else
            {
                MessageBox.Show("Unsucc");
            }
            return user;
        }

        private Auth()
        {
            _context = new ElectronicsStoreContext();
        }

        private class AuthCreate
        {
            static AuthCreate() { }
            internal static readonly Auth Instance = new Auth();
        }
    }
}
