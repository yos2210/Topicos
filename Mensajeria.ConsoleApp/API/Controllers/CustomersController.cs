using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NorthWnd.Model.MyModels;

namespace Mensajeria.ConsoleApp.API.Controllers
{
    [Route("api/Customer")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly AdventureWorksLT2019Context _context;
        private readonly IMapper _mapper;

        public CustomersController()
        {
            _context = new AdventureWorksLT2019Context();
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<DTOModels.DtoCustomer>>> GetCustomers(int pageSize = 5, int pageNumber = 5)
        {
            var customer = await _context.Customers.OrderBy(c => c.LastName).
                Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync();

            if (customer == null)
            {
                return NotFound();
            }

            var customermapeado = _mapper.Map<List<DTOModels.DtoCustomer>>(customer);

            return customermapeado;
        }

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<DTOModels.DtoCustomer>> GetCustomer(int id)
        {
            var customer = (await _context.Customers.Include(c => c.CustomerAddresses)
                            .ThenInclude(a => a.Address).Where(c => c.CustomerId == id)
                            .ToListAsync()).FirstOrDefault();

            if (customer == null)
            {
                return NotFound();
            }
            var customermapeado = _mapper.Map<DTOModels.DtoCustomer>(customer);

            return customermapeado;
        }

        // GET: api/Customers/PagedQuery/?pageNumber=3?pageSize=5
        [HttpGet("PagedQuery/")]
        public async Task<ActionResult<IEnumerable<DTOModels.DtoCustomer>>> GetCustomerPaged(int pageNumber, int pageSize)
        {

            var customer = await _context.Customers.OrderBy(c => c.LastName).
                Skip(pageSize * (pageNumber - 1)).Take(pageSize).ToListAsync(); 

            if (customer == null)
            {
                return NotFound();
            }

            var customermapeado = _mapper.Map< List<DTOModels.DtoCustomer>>(customer);

            return customermapeado;
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
