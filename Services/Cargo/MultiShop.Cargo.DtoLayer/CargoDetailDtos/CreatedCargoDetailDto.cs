using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DtoLayer.CargoDetailDtos
{
    public class CreatedCargoDetailDto
    {
        public string SenderCustomerId { get; set; }
        public string ReceiverCustomerId { get; set; }
        public byte Barcode { get; set; }
        public int CargoCompanyId { get; set; }
    }
}
