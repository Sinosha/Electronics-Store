using Electronics_Store.Model;
using Electronics_Store.View.ProductsView;
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
    public partial class ProfileForm : Form
    {
        ElectronicsStore _cotext = new ElectronicsStore();
        User_Personal_Data data;
        public ProfileForm(User_Personal_Data _data)
        {
            InitializeComponent();
            data = _data;
        }

        private void ProfileForm_Load(object sender, EventArgs e)
        {
            LabelFirstName.Text = data.FirstName;
            LabelSecondName.Text = data.LastName;
            LabelPhone.Text = data.PhoneNumber;
            LabelEMail.Text = data.E_mail;
            LabelCity.Text = data.Current_city;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddProductForm().ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new AddOrderForm().ShowDialog();
        }
    }
}
