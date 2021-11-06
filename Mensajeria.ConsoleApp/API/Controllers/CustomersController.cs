using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWnd.Model.MyModels;

namespace Topicos.Netcore.Api.AdventureWorks.Controllers
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
            var customerBD = (await _context.Customers.Include(c => c.CustomerAddresses).ThenInclude(a => a.Address).Where(c => c.CustomerId == id).ToListAsync()).FirstOrDefault();
            //var customer = await _context.Customers.FindAsync (id);

            if (customerBD == null)
            {
                return NotFound();
            }
            var customerResultante = AplanarCustomer(customerBD);

            return customerResultante;
        }

        // GET: api/Customers/PagedQuery/?pageNumber=3?pageSize=15
        [HttpGet("PagedQuery/")]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomerPaged(int pageNumber, int pageSize)
        {

            var customer = await _context.Customers.OrderBy(c => c.LastName).
                Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync(); 

            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }


        private Customer AplanarCustomer(Customer customerBD)
        {
            var elCustomerResultante = new Customer();
            elCustomerResultante.CustomerId = customerBD.CustomerId;
            elCustomerResultante.NameStyle = customerBD.NameStyle;
            elCustomerResultante.Title = customerBD.Title;
            elCustomerResultante.FirstName = customerBD.FirstName;
            elCustomerResultante.MiddleName = customerBD.MiddleName;
            elCustomerResultante.Suffix = customerBD.Suffix;
            elCustomerResultante.CompanyName = customerBD.CompanyName;
            elCustomerResultante.SalesPerson = customerBD.SalesPerson;
            elCustomerResultante.EmailAddress = customerBD.EmailAddress;
            elCustomerResultante.Phone = customerBD.Phone;
            elCustomerResultante.LastName = customerBD.LastName;
            elCustomerResultante.CustomerAddresses = new List<CustomerAddress>();
            foreach (var item in customerBD.CustomerAddresses)
            {
                var elCustomerAddress = new CustomerAddress();
                elCustomerAddress.AddressType = item.AddressType;
                elCustomerAddress.Address = new Address();
                elCustomerAddress.Address.AddressLine1 = item.Address.AddressLine1;
                elCustomerAddress.Address.AddressLine2 = item.Address.AddressLine2;
                elCustomerAddress.Address.City = item.Address.City;
                elCustomerAddress.Address.StateProvince = item.Address.StateProvince;
                elCustomerAddress.Address.CountryRegion = item.Address.CountryRegion;
                elCustomerAddress.Address.PostalCode = item.Address.PostalCode;
                elCustomerResultante.CustomerAddresses.Add(elCustomerAddress);
            }
            return elCustomerResultante;
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
