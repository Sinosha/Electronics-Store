using Electronics_Store.Model;
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
        public AuthorizationForm()
        {
            InitializeComponent();
            _context = new ElectronicsStoreContext();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
