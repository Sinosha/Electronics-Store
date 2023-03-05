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

namespace Electronics_Store.View.ProductsView
{
    public partial class AddOrderForm : Form
    {
        ElectronicsStore _context = new ElectronicsStore();
        ModelService modelService = new ModelService();
        public AddOrderForm()
        {
            InitializeComponent();
            foreach (var item in _context.Categories.ToList())
            {
                comboBox1.Items.Add(item);
            }
            foreach (var item in _context.Manufacturers.ToList())
            {
                comboBox2.Items.Add(item);
            }
            comboBox1.SelectedIndex = 1;
            comboBox2.SelectedIndex = 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var tempData = _context.Models.Include("Manufacturer").Include("Category")
                                       .Include("Model_Specification").Include("Model_Specification.Sale_Info").ToList();

            dataGridView1.DataSource = tempData;

                tempData = modelService.SortByCategory(comboBox1.Text, tempData);
                tempData = modelService.SortByManufacturer(comboBox2.Text, tempData);

            if (textBox1.Text != "")
            {
                tempData = modelService.SortByModelName(textBox1.Text, tempData);
            }

            dataGridView1.DataSource = tempData.ToList();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            var selectedModel = dataGridView1.SelectedRows;
            int FK = Convert.ToInt32(dataGridView1[0, dataGridView1.CurrentRow.Index].Value.ToString());
            if (selectedModel == null) return;

            Sale_Info sale = new Sale_Info()
            {
                SaleDate = dateTimePicker1.Value,
                Model_Spec_FK = FK
            };
            _context.Sale_Info.Add(sale);
            _context.SaveChanges();
        }
    }
}
