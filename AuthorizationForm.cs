using Electronics_Store.Model;
using Electronics_Store.Services;
using Electronics_Store.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronics_Store
{
    public partial class AuthorizationForm : Form
    {
        ElectronicsStoreContext _context;
        Auth Auth;
        public AuthorizationForm()
        {
            InitializeComponent();
            _context = new ElectronicsStoreContext();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            var u = await Auth.GetUser(LoginTextBox.Text);
            await Auth.Login(LoginTextBox.Text, PasswordTextBox.Text);
            this.Hide();
            //Classes.User user = new Classes.User() { FirstName = u.User_Personal_Data.Select(u => u.FirstName).ToString(), Role = u.User_Personal_Data.Select(u => u.Role).ToString() };
            //ManageForm manageForm = new ManageForm(user);
            //manageForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Classes.User user = new Classes.User() { FirstName = "Гость", Role = "Guest" };
            ManageForm manageForm = new ManageForm(user);
            manageForm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            RegistrationForm registration = new RegistrationForm();
            registration.ShowDialog();
        }
    }
}
