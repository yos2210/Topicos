using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Mensajeria.ConsoleApp.API.DTOModels
{
    public partial class DtoCustomer
    {
        public int CustomerId { get; set; }
        public bool NameStyle { get; set; }
        public string FullName { get; set; }
        public string CompanyName { get; set; }
        public string SalesPerson { get; set; }
        public string EmailAddress { get; set; }
        public string Phone { get; set; }
        public IList<DtoCustomerAddress> CustomerAddresses { get; set; }

    }
}
