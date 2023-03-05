using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Electronics_Store;
using Electronics_Store.Model;
using Electronics_Store.Services;
using Electronics_Store.View;

namespace Electronics_Store
{
    public partial class MainForm : Form
    {
        ElectronicsStore _context = new ElectronicsStore();
        User_Personal_Data _data;
        ModelService modelService = new ModelService();
        public MainForm(User_Personal_Data  _data)
        {
            InitializeComponent();
            this._data = _data;
            label2.Text = _data.FirstName;
            dataGridView1.DataSource = _context.Models.Include("Manufacturer").Include("Category")
                                       .Include("Model_Specification").Include("Model_Specification.Sale_Info").ToList();
            comboBox1.Items.Add("Все");
            comboBox2.Items.Add("Все");
            comboBox1.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            foreach(var item in _context.Categories.ToList())
            {
                comboBox1.Items.Add(item);
            }
            foreach(var item in _context.Manufacturers.ToList())
            {
                comboBox2.Items.Add(item);
            }
            listBox1.SelectedIndexChanged += ListBox1_SelectedIndexChanged;
            

        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            new ProfileForm(_data).ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var tempData = _context.Models.Include("Manufacturer").Include("Category")
                                       .Include("Model_Specification").Include("Model_Specification.Sale_Info").ToList();

            dataGridView1.DataSource = tempData;

            if (comboBox1.SelectedIndex != 0)
            {
                tempData = modelService.SortByCategory(comboBox1.Text, tempData);
            }
            if (comboBox2.SelectedIndex != 0)
            {
                tempData = modelService.SortByManufacturer(comboBox2.Text,tempData);
            }
            if (textBox1.Text != "")
            {
                tempData = modelService.SortByModelName(textBox1.Text, tempData);
            }
            if (numericUpDown1.Value != 0 || numericUpDown2.Value != 0)
            {
                tempData = modelService.SortByPrice(tempData,numericUpDown1.Value,numericUpDown2.Value);
            }
            if(checkBox1.Checked)
            {
                tempData = modelService.SortByDateOfManufacturing(tempData, dateTimePicker1.Value, dateTimePicker2.Value);
            }
            if(checkBox2.Checked)
            {
                MessageBox.Show($"За выбранный промежуток времени было продано: {modelService.SortByDateOfSale(tempData, dateTimePicker1.Value, dateTimePicker2.Value)}");
            }
            dataGridView1.DataSource = tempData.ToList();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                checkBox1.Checked = false;
                
            }
            
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if(checkBox2.Checked)
            {
                checkBox2.Checked = false;
                
            }
        }

        private void button4_Click(object sender, EventArgs e) // производитель
        {
            var tempData = _context.Models.Include("Manufacturer").Include("Category")
                                       .Include("Model_Specification").Include("Model_Specification.Sale_Info").ToList();
            
            if(button4.Text == "По производителю ↓")
            {
                tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).OrderBy(m => m.Manufacturer.Manufacturer_name).ToList();
                dataGridView1.DataSource = tempData;
                button4.Text = "По производителю ↑";
            }
            else
            {
                tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).OrderByDescending(m => m.Manufacturer.Manufacturer_name).ToList();
                dataGridView1.DataSource = tempData;
                button4.Text = "По производителю ↓";
            }

        }

        private void button5_Click(object sender, EventArgs e) // вес
        {
            var tempData = _context.Models.Include("Manufacturer").Include("Category")
                                       .Include("Model_Specification").Include("Model_Specification.Sale_Info").ToList();

            if (button5.Text == "По весу ↓")
            {
                tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).OrderBy(m => m.Model_Specification.Weight).ToList();
                dataGridView1.DataSource = tempData;
                button5.Text = "По весу ↑";
            }
            else
            {
                tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).OrderByDescending(m => m.Model_Specification.Weight).ToList();
                dataGridView1.DataSource = tempData;
                button5.Text = "По весу ↓";
            }
        }

        private void button6_Click(object sender, EventArgs e) // стоимость
        {
            var tempData = _context.Models.Include("Manufacturer").Include("Category")
                                       .Include("Model_Specification").Include("Model_Specification.Sale_Info").ToList();

            if (button6.Text == "По стоимости ↓")
            {
                tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).OrderBy(m => m.Model_Specification.Price).ToList();
                dataGridView1.DataSource = tempData;
                button6.Text = "По стоимости ↑";
            }
            else
            {
                tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).OrderByDescending(m => m.Model_Specification.Price).ToList();
                dataGridView1.DataSource = tempData;
                button6.Text = "По стоимости ↓";
            }
        }

        private void button7_Click(object sender, EventArgs e) // дата продажи
        {
            var tempData = _context.Models.Include("Manufacturer").Include("Category")
                                       .Include("Model_Specification").Include("Model_Specification.Sale_Info").ToList();

            if (button7.Text == "По дате продажи ↓")
            {
                if (comboBox1.SelectedIndex != 0)
                {
                    tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).OrderBy(s => s.Model_Specification.Sale_Info.First().SaleDate).ToList();
                }
                else
                {
                    tempData = tempData.OrderBy(s => s.Model_Specification.Sale_Info.First().SaleDate).ToList();
                }
                dataGridView1.DataSource = tempData;
                button7.Text = "По дате продажи ↑";
            }
            else
            {
                if(comboBox1.SelectedIndex != 0)
                {
                    tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).OrderByDescending(s => s.Model_Specification.Sale_Info.First().SaleDate).ToList();
                }
                else
                {
                    tempData = tempData.OrderByDescending(s => s.Model_Specification.Sale_Info.First().SaleDate).ToList();
                }
                dataGridView1.DataSource = tempData;
                button7.Text = "По дате продажи ↓";
            }
        }

        private void button8_Click(object sender, EventArgs e) // дата выпуска
        {
            var tempData = _context.Models.Include("Manufacturer").Include("Category")
                                       .Include("Model_Specification").Include("Model_Specification.Sale_Info").ToList();

            if (button8.Text == "По дате выпуска ↓")
            {
                tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).OrderBy(m => m.Model_Specification.Date_of_manufacture).ToList();
                dataGridView1.DataSource = tempData;
                button8.Text = "По дате выпуска ↑";
            }
            else
            {
                tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).OrderByDescending(m => m.Model_Specification.Date_of_manufacture).ToList();
                dataGridView1.DataSource = tempData;
                button8.Text = "По дате выпуска ↓";
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tempData = _context.Models.Include("Manufacturer").Include("Category")
                                       .Include("Model_Specification").Include("Model_Specification.Sale_Info").ToList();
            if (listBox1.SelectedIndex == 0)
            {
                decimal maxPrice = 0;
                string maxCategory = "";
                decimal minPrice = (decimal)tempData.Max(p => p.Model_Specification.Price);
                string minCategory = "";
                decimal avgPrice = Math.Round((decimal)tempData.Average(p => p.Model_Specification.Price), 2);

                foreach (var item in _context.Categories)
                {
                    var result = item.Models.Sum(p => p.Model_Specification.Price);
                    if (result > maxPrice)
                    {
                        maxPrice = (decimal)result;
                        maxCategory = item.Category_name;
                    }
                    if (result < minPrice)
                    {
                        minPrice = (decimal)result;
                        minCategory = item.Category_name;
                    }
                }

                if (comboBox1.SelectedIndex != 0)
                {
                    tempData = tempData.Where(c => c.Category.Category_name == comboBox1.Text).ToList();
                    avgPrice = (decimal)tempData.Average(c => c.Model_Specification.Price);
                    MessageBox.Show($"Самый дорогой вид электроприборов: {maxCategory} - {maxPrice} \nСамый дешевый вид электроприборов: {minCategory} - {minPrice}\nСредняя цена в категории {comboBox1.Text} - {avgPrice}");
                }
                else
                {
                    MessageBox.Show($"Самый дорогой вид электроприборов: {maxCategory} - {maxPrice} \nСамый дешевый вид электроприборов: {minCategory} - {minPrice}\nСредняя цена по всем категориям: {Math.Round(avgPrice, 2)}");
                }
            }
            else if (listBox1.SelectedIndex == 1)
            {
                int amountOfSales = 0;
                string popularCategory = "";
                foreach (var item in tempData.ToList())
                {
                    foreach (var count in tempData.SelectMany(c => c.Model_Specification.Sale_Info))
                    {
                        if (amountOfSales < item.Model_Specification.Sale_Info.Count())
                        {
                            amountOfSales = item.Model_Specification.Sale_Info.Count();
                            popularCategory = item.Category.Category_name;
                        }

                    }
                }
                MessageBox.Show($"Самый популярный вид товара: {popularCategory}, кол-во продаж: {amountOfSales}");
            }
            else if (listBox1.SelectedIndex == 2)
            {
                
                foreach (var item in _context.Model_Specification)
                {
                    if (item.Country != null)
                    {
                        comboBox3.Items.Add(item.Country);
                    }
                }
                if (comboBox1.SelectedIndex == 0)
                {
                    tempData = tempData.Where(m => m.Model_Specification.Country == comboBox3.Text).ToList();
                }
                if(comboBox1.SelectedIndex != 0)
                {
                    tempData = tempData.Where(c=> c.Category.Category_name == comboBox1.Text).Where(m => m.Model_Specification.Country == comboBox3.Text).ToList();
                }
                if(comboBox2.SelectedIndex != 0)
                {
                    tempData.Where(m => m.Manufacturer.Manufacturer_name == comboBox2.Text).ToList();
                }
                int Defective = tempData.Count();
                MessageBox.Show($"Из {comboBox3.Text} было выявлено: {Defective} бракованных товаров");
            }
            else if(listBox1.SelectedIndex == 3)
            {
                DateTime start = dateTimePicker1.Value;
                DateTime end = dateTimePicker2.Value;
                tempData = tempData.Where(s => s.Model_Specification.Sale_Info.First().SaleDate > start && s.Model_Specification.Sale_Info.First().SaleDate < end).ToList();
                decimal avgPrice = (decimal)tempData.Average(p => p.Model_Specification.Price);
                MessageBox.Show($"Средняя стоимость электроприборов за выбранный промежуток: {avgPrice}");
            }
            else if(listBox1.SelectedIndex == 4)
            {
                if (comboBox2.SelectedIndex != 0)
                {
                    decimal avgPrice = (decimal)tempData.Where(m => m.Manufacturer.Manufacturer_name == comboBox2.Text).Average(p => p.Model_Specification.Price);
                    tempData = tempData.Where(p => p.Model_Specification.Price > avgPrice).ToList();
                    MessageBox.Show($"Средняя цена товаров у производителя: {comboBox2.Text} составляет: {avgPrice}");
                    dataGridView1.DataSource = tempData;
                }
                else
                {
                    return;
                }

            }
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        
    }
}
