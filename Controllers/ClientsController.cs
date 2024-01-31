using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalService.Context;
using TechnicalService.Models;

namespace TechnicalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientsController : ControllerBase
    {
        private readonly DataContext _context;

        public ClientsController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Clients
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Client>>> GetClients()
        {
            return await _context.Clients.ToListAsync();
        }

        [HttpGet("active-clients")]
        public async Task<ActionResult<IEnumerable<Client>>> GetActiveClients()
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            return await _context.Clients.Where(c => c.State.Equals("A")).ToListAsync();
        }

        [HttpGet("active-clients/data-complete")]
        public async Task<ActionResult<IEnumerable<ClientPerson>>> GetDataClients()
        {
            if (_context.Clients == null)
            {
                return NotFound();
            }
            return await _context.Clients.Include(p => p.FK_Person).Where(c => c.State.Equals("A")).Select(x => new ClientPerson { ClientId = x.ClientId, PersonId = x.PersonId, CityId = x.FK_Person.CityId, GenderId = x.FK_Person.GenderId, Name = x.FK_Person.Name, LastName = x.FK_Person.LastName, IdentificationCard = x.FK_Person.IdentificationCard, RUC = x.RUC, DateOfBirth = x.DateOfBirth, Hobby = x.Hobby, GenderName = x.FK_Person.Fk_Gender.GenderName, CellPhone = x.FK_Person.CellPhone, CityName = x.FK_Person.Fk_City.CityName, Address = x.FK_Person.Address, Email = x.Email, State = x.State }).ToListAsync();
        }

        // GET: api/Clients/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Client>> GetClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);

            if (client == null)
            {
                return NotFound();
            }

            return client;
        }

        // PUT: api/Clients/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutClient(int id, Client client)
        {
            if (id != client.ClientId)
            {
                return BadRequest();
            }

            _context.Entry(client).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClientExists(id))
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

        // POST: api/Clients
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Client>> PostClient(Client client)
        {
            _context.Clients.Add(client);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetClient", new { id = client.ClientId }, client);
        }

        // DELETE: api/Clients/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClient(int id)
        {
            var client = await _context.Clients.FindAsync(id);
            if (client == null)
            {
                return NotFound();
            }

            _context.Clients.Remove(client);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClientExists(int id)
        {
            return _context.Clients.Any(e => e.ClientId == id);
        }
    }
}
