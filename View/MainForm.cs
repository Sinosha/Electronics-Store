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
using Electronics_Store;
using Electronics_Store.Model;
using Electronics_Store.View;

namespace Electronics_Store
{
    public partial class MainForm : Form
    {
        ElectronicsStoreContext _context = new ElectronicsStoreContext();
        User_Personal_Data _data;
        Electronics_storeDataSet _dataSet;
        public MainForm(User_Personal_Data  _data)
        {
            InitializeComponent();
            this._data = _data;
            label2.Text = _data.FirstName;
            dataGridView1.DataSource = _context.Models.Include("Manufacturer").Include("Category").Include("Model_Specification").ToList();
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProfileForm(_data).ShowDialog();
        }
    }
}
