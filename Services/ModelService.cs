using Electronics_Store.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Electronics_Store.Services
{
    public class ModelService
    {
        ElectronicsStore _context = new ElectronicsStore();
        List<Model.Model> sortedData = new List<Model.Model>();
        
        public List<Model.Model> SortByCategory(string name,List<Model.Model> data)
        {
            sortedData = data.Where(c => c.Category.Category_name == name).ToList();
            return sortedData;
        }

        public List<Model.Model> SortByManufacturer(string name, List<Model.Model> data)
        {
            sortedData = data.Where(m => m.Manufacturer.Manufacturer_name == name).ToList();
            return sortedData;
        }

        public List<Model.Model> SortByModelName(string name, List<Model.Model> data)
        {
            sortedData = data.Where(n => n.Model1 == name).ToList();
            return sortedData;
        }

        public List<Model.Model> SortByPrice(List<Model.Model> data,decimal minPrice,decimal maxPrice)
        {
            if(minPrice == 0)
            {
                sortedData = data.Where(p => p.Model_Specification.Price < maxPrice).ToList();
            }
            else if(maxPrice == 0)
            {
                sortedData = data.Where(p => p.Model_Specification.Price > minPrice).ToList();
            }
            else
            {
                sortedData = data.Where(p => p.Model_Specification.Price > minPrice && p.Model_Specification.Price < maxPrice).ToList();
            }
            
            return sortedData;
        }

        public List<Model.Model> SortByDateOfManufacturing(List<Model.Model> data, DateTime start,DateTime end)
        {
            sortedData = data.Where(d => d.Model_Specification.Date_of_manufacture > start && d.Model_Specification.Date_of_manufacture < end).ToList();
            return sortedData;
        }

        public int SortByDateOfSale(List<Model.Model> data, DateTime start, DateTime end)
        {
            int amountofSales = data.Where(d => d.Model_Specification.Sale_Info.Max(m => m.SaleDate).Value > start && d.Model_Specification.Sale_Info.Min(m => m.SaleDate).Value < end).Count();
            return amountofSales;
        }

    }
}
