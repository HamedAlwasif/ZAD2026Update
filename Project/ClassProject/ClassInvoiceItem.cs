using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZAD_Sales.ClassProject
{
   
    public class InvoiceItem
    {

        public string Num { get; set; }

        public string Storage { get; set; }

        public string Category { get; set; }

        public string Quantity { get; set; }

        public string Type { get; set; }

        public decimal Price { get; set; }

        public decimal Discount { get; set; }

        public decimal Total { get; set; }


    }
}
