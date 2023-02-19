using Electronics_Store.Model;
using Electronics_Store.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronics_Store.View
{
    public partial class RegistrationForm : Form
    {
        ElectronicsStoreContext _context;
        Auth auth = new Auth();
        public RegistrationForm()
        {
            InitializeComponent();
            _context = new ElectronicsStoreContext();
            label8.Visible = false;
            label9.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (LoginTextBox.Text == "")
            {
                label8.Visible = true;
            }
            else if (PasswordTextBox.Text == "")
            {
                label9.Visible = true;
            }
            else
            {
                User user = new User() { Login = LoginTextBox.Text, Password = PasswordTextBox.Text };
                User_Personal_Data data = new User_Personal_Data()
                { User_FK = user.ID, FirstName = FirstNameTextBox.Text, LastName = LastNameTextBox.Text, PhoneNumber = PhoneTextBox.Text, Current_city = CityTextBox.Text, E_mail = EMailTextBox.Text, Role = "Client" };
                _context.Users.Add(user);
                _context.User_Personal_Data.Add(data);
                _context.SaveChanges();
            }
        }
    }
}
