using System;
using System.Collections.Generic;
using System.Text;

namespace projectsoftserve
{
    public class JewelryShop
    {
        public string Address { get; set; }
        public int ItemsCount { get; set; }
        public List<JewelryItem> Items { get; set; } = new List<JewelryItem>();
    }
}
