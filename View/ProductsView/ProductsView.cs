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

namespace Electronics_Store.View.ProductsView
{
    public partial class ProductsView : Form
    {
        ElectronicsStore _context = new ElectronicsStore();
        public ProductsView()
        {
            InitializeComponent();
            var Products = _context.Models.Include("Manufacturer").Include("Category")
                           .Include("Model_Specification").Include("Model_Specification.Sale_Info").ToList();
            dataGridView1.DataSource = Products;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new AddProductForm().ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            new AddOrderForm().ShowDialog();
        }
    }
}
