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
    public partial class ManageForm : Form
    {
        public ManageForm(Classes.User user)
        {
            InitializeComponent();
            label2.Text = user.FirstName;
        }
    }
}
