using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Electronics_Store.Classes
{
    public abstract class User
    {
        string Name;
        bool IsAdmin;
    }

    public class Client : User
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }
        
        Client (string name)
        {
            Name = name;
            IsAdmin = false;
        }

    }
    public class Manager : User
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        Manager(string name)
        {
            Name = name;
            IsAdmin = false;
        }

    }

    public class Admin : User
    {
        public string Name { get; set; }
        public bool IsAdmin { get; set; }

        Admin(string name)
        {
            Name = name;
            IsAdmin = false;
        }

    }
}
