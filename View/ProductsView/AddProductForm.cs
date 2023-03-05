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
    public partial class AddProductForm : Form
    {
        ElectronicsStore _context = new ElectronicsStore();
        public AddProductForm()
        {
            InitializeComponent();
            foreach(var items in _context.Categories)
            {
                comboBox1.Items.Add(items);
            }
            foreach(var item in _context.Manufacturers)
            {
                comboBox2.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int CategoryFK = _context.Categories.Where(c => c.Category_name == comboBox1.Text).FirstOrDefault().ID;
            int ManufacturerFK = _context.Manufacturers.Where(c => c.Manufacturer_name == comboBox2.Text).FirstOrDefault().ID;
            Model_Specification spec = new Model_Specification()
            {
                Model_name = ModelNameTextBox.Text,
                Specification = DescriptionTextBox.Text,
                Available_in_stock = (int)AwailableInStockNUD.Value,
                Weight = (double)WeightNUD.Value,
                Price = PriceNUD.Value,
                AmountOfDefective = 0,
                Date_of_manufacture = DateOfManufactureDataPicker.Value,
                Country = CountryTextBox.Text
            };
            Model.Model model = new Model.Model()
            {
                Category_name_FK = CategoryFK,
                Manufacturer_name_FK = ManufacturerFK,
                Model1 = ModelTextBox.Text,
                Model_specification_FK = spec.ID
            };
            _context.Model_Specification.Add(spec);
            _context.Models.Add(model);
            _context.SaveChanges();
        }
    }
}
