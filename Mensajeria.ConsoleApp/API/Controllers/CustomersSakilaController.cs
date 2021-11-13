using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Topicos.Netcore.NorthWnd.Model.ModelSakila;

namespace Topicos.Netcore.Api.AdventureWorks.Controllers
{
    [Route("api/CustomerSakila")]
    [ApiController]
    public class CustomersSakilaController : ControllerBase
    {
        private readonly sakilaContext _context;

        public CustomersSakilaController(sakilaContext context)
        {
            _context = context;
        }

        // GET: api/CustomersSakila
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            return await _context.Customers.ToListAsync();
        }

        // GET: api/CustomersSakila/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            
            var customer = (await _context.Customers.Include(c => c.Address)
                .ThenInclude(a => a.City)
                .ThenInclude(a => a.Country)
                .Where(c => c.CustomerId == id).ToListAsync()).FirstOrDefault();


            if (customer == null)
            {
                return NotFound();
            }
            var customerResultante = AplanarCustomer(customer);
            return customerResultante;
        }

        private Customer AplanarCustomer(Customer customerBD)
        {
            var elCustomerResultante = new Customer();
            elCustomerResultante.CustomerId = customerBD.CustomerId;
            elCustomerResultante.StoreId = customerBD.StoreId;
            elCustomerResultante.FirstName = customerBD.FirstName;
            elCustomerResultante.LastName = customerBD.LastName;
            elCustomerResultante.Email = customerBD.Email;
            elCustomerResultante.AddressId = customerBD.AddressId;
            elCustomerResultante.Active = customerBD.Active;
            elCustomerResultante.CreateDate = customerBD.CreateDate;
            elCustomerResultante.LastUpdate = customerBD.LastUpdate;
            elCustomerResultante.Address = customerBD.Address;

            //foreach (var item in customerBD.CustomerAddresses)
            //{
            //    var elCustomerAddress = new CustomerAddress();
            //    elCustomerAddress.AddressType = item.AddressType;
            //    elCustomerAddress.Address = new Address();
            //    elCustomerAddress.Address.AddressLine1 = item.Address.AddressLine1;
            //    elCustomerAddress.Address.AddressLine2 = item.Address.AddressLine2;
            //    elCustomerAddress.Address.City = item.Address.City;
            //    elCustomerAddress.Address.StateProvince = item.Address.StateProvince;
            //    elCustomerAddress.Address.CountryRegion = item.Address.CountryRegion;
            //    elCustomerAddress.Address.PostalCode = item.Address.PostalCode;
            //    elCustomerResultante.CustomerAddresses.Add(elCustomerAddress);
            //}
            return elCustomerResultante;
        }

        // PUT: api/CustomersSakila/5
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

        // POST: api/CustomersSakila
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }

        // DELETE: api/CustomersSakila/5
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
