using System;
using System.Collections.Generic;

#nullable disable

namespace Sakila.Model.ModelSakila
{
    public partial class Store
    {
        public Store()
        {
            Customers = new HashSet<Customer>();
        }

        public int StoreId { get; set; }
        public byte ManagerStaffId { get; set; }
        public int AddressId { get; set; }
        public DateTime LastUpdate { get; set; }

        public virtual Address Address { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }
    }
}
