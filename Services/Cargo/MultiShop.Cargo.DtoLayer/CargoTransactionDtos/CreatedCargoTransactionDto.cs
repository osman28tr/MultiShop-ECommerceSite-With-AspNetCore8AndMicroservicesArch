using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.CargoTransactionDtos
{
    public class CreatedCargoTransactionDto
    {
        public byte Barcode { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
    }
}
