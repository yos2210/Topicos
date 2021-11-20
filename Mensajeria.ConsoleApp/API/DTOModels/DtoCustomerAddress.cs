using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mensajeria.ConsoleApp.API.DTOModels
{
    public partial class DtoCustomerAddress
    {
        public string AddressType { get; set; }
        public string AddressAddressLine1 { get; set; }
        public string AddressAddressLine2 { get; set; }
        public string AddressCity { get; set; }
        public string AddressStateProvince { get; set; }
        public string AddressCountryRegion { get; set; }
        public string AddressPostalCode { get; set; }
    }
}
