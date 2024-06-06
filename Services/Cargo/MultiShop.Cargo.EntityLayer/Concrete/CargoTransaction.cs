using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.EntityLayer.Concrete
{
    public class CargoTransaction
    {
        public int Id { get; set; }
        public byte Barcode { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
