using Electronics_Store.Model;
using Electronics_Store.Services;
using Electronics_Store.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronics_Store
{
    public partial class AuthorizationForm : Form
    {
        ElectronicsStore _context;
        Auth Auth = new Auth();
        User_Personal_Data _data = new User_Personal_Data();
        public AuthorizationForm()
        {
            InitializeComponent();
            _context = new ElectronicsStore();
            
            
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            var user = Auth.GetUser(LoginTextBox.Text);
            if (user == null)
            {
                label9.Visible = true;
            }
            else if (Auth.Login(user,PasswordTextBox.Text))
            {
                int index = user.ID;
                _data.FirstName = _context.User_Personal_Data.FirstOrDefault(i => i.User_FK == index).FirstName.ToString();
                _data.Role = _context.User_Personal_Data.FirstOrDefault(i => i.User_FK == index).Role;
                MainForm manageForm = new MainForm(_data);
                manageForm.ShowDialog();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            _data.FirstName = "Гость";
            _data.Role = "Guest";
            MainForm manageForm = new MainForm(_data);
            manageForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistrationForm registration = new RegistrationForm();
            registration.ShowDialog();
        }
    }
}
