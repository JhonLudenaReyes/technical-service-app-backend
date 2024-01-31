using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using TechnicalService.Context;
using TechnicalService.Models;

namespace TechnicalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PeopleController : ControllerBase
    {
        private readonly DataContext _context;

        public PeopleController(DataContext context)
        {
            _context = context;
        }

        // GET: api/People
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Person>>> GetPersons()
        {
            if (_context.Persons == null)
            {
                return NotFound();
            }
            return await _context.Persons.ToListAsync();
        }

        // GET: api/People
        [HttpGet("/api/People/PeopleActive")]
        public async Task<ActionResult<IEnumerable<Person>?>> GetPeople()
        {
            if (_context.Persons == null)
            {
                return NotFound();
            }

            var peopleList = await _context.Persons.Where(p => p.State.Equals("A")).ToListAsync();

            if (peopleList == null)
            {
                return NotFound();
            }

            return peopleList;

        }


        [HttpGet("search-people-active")]
        public async Task<ActionResult<IEnumerable<Person>>> getSearchPeopleActive(string Search)
        {

            var searchPeople = await _context.Persons.FromSqlRaw($"EXEC Sp_SearchPerson {Search}").ToArrayAsync();

            if (searchPeople == null)
            {
                return NotFound();
            }


            return searchPeople;



        }

        // GET: api/People/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Person>> GetPerson(int id)
        {
            if (_context.Persons == null)
            {
                return NotFound();
            }
            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            return person;
        }

        // PUT: api/People/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPerson(int id, Person person)
        {
            if (id != person.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(person).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonExists(id))
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

        // PUT: /delete-person/5
        [HttpDelete("/delete-person/{id}")]
        public async Task<IActionResult> DeletePersonLog(int id)
        {
            if (_context.Persons == null)
            {
                return NotFound();
            }

            var person = await _context.Persons.FindAsync(id);

            if (person == null)
            {
                return NotFound();
            }

            person.State = "I";

            _context.Persons.Update(person);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        // POST: api/People
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Person>> PostPerson(Person person)
        {
            if (_context.Persons == null)
            {
                return Problem("Entity set 'DataContext.Persons'  is null.");
            }
            _context.Persons.Add(person);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPerson", new { id = person.PersonId }, person);
        }

        // DELETE: api/People/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePerson(int id)
        {
            if (_context.Persons == null)
            {
                return NotFound();
            }
            var person = await _context.Persons.FindAsync(id);
            if (person == null)
            {
                return NotFound();
            }

            _context.Persons.Remove(person);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonExists(int id)
        {
            return (_context.Persons?.Any(e => e.PersonId == id)).GetValueOrDefault();
        }
    }
}
