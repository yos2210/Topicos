using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWnd.Model.MyModels;

namespace API.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AdventureWorksLT2019Context _context;

        public CustomersController()
        {
            _context = new AdventureWorksLT2019Context();
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = (await _context.Customers.Include(c => c.CustomerAddresses).ThenInclude(a => a.Address).Where(c => c.CustomerId == id).ToListAsync()).FirstOrDefault();
            //var customer = await _context.Customers.FindAsync(id);
           
            if (customer == null)
            {
                return NotFound();
            }
            var customerResultante = ExtraerCustomer(customer);

            return customer;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomerWithParameter(int id)
        {
           var customer = (await _context.Customers.Include(c => c.CustomerAddresses).ThenInclude(a => a.Address).Where(c => c.CustomerId == id).ToListAsync()).FirstOrDefault();
            //var customer = await _context.Customers.FindAsync(id);
            //IEnumerable<Employee> result = Employees.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }

        private Customer ExtraerCustomer(Customer customerBD)
        {
            var customerExtraido = new Customer();
            customerExtraido.CustomerId = customerBD.CustomerId;
            customerExtraido.NameStyle = customerBD.NameStyle;
            customerExtraido.Title = customerBD.Title;
            customerExtraido.FirstName = customerBD.FirstName;
            customerExtraido.MiddleName = customerBD.MiddleName;
            customerExtraido.Suffix = customerBD.Suffix;
            customerExtraido.CompanyName = customerBD.CompanyName;
            customerExtraido.SalesPerson = customerBD.SalesPerson;
            customerExtraido.EmailAddress = customerBD.EmailAddress;
            customerExtraido.Phone = customerBD.Phone;
            customerExtraido.LastName = customerBD.LastName;
            customerExtraido.CustomerAddresses = new List<CustomerAddress>();
            foreach (var item in customerBD.CustomerAddresses)
            {
                var customerAddress = new CustomerAddress();
                customerAddress.AddressType = item.AddressType;
                customerAddress.Address = new Address();
                customerAddress.Address.AddressLine1 = item.Address.AddressLine1;
                customerAddress.Address.AddressLine2 = item.Address.AddressLine2;
                customerAddress.Address.City = item.Address.City;
                customerAddress.Address.StateProvince = item.Address.StateProvince;
                customerAddress.Address.CountryRegion = item.Address.CountryRegion;
                customerAddress.Address.PostalCode = item.Address.PostalCode;
                customerExtraido.CustomerAddresses.Add(customerAddress);
            }
            return customerExtraido;
        }

        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            if (id != customer.CustomerId)
            {
                return BadRequest();
            }

            _context.Entry(customer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomerExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _context.Customers.FindAsync(id);
            if (customer == null)
            {
                return NotFound();
            }

            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CustomerExists(int id)
        {
            return _context.Customers.Any(e => e.CustomerId == id);
        }
    }
}
