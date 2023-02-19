using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Electronics_Store;
using Electronics_Store.Model;

namespace Electronics_Store
{
    public partial class ManageForm : Form
    {
        ElectronicsStoreContext _context = new ElectronicsStoreContext();
        public ManageForm(User_Personal_Data  _data)
        {
            InitializeComponent();
            label2.Text = _data.FirstName;
        }
    }
}
