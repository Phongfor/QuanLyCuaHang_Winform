using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyCuaHang
{
    internal class MenuItem
    {
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string ImagePath { get; set; }

        public MenuItem(string name, decimal price, string imagePath)
        {
            Name = name;
            Price = price;
            ImagePath = imagePath;
        }
    }
}
