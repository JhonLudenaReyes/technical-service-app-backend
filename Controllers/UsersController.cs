using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Any;
using NuGet.Packaging;
using System.Reflection.Metadata;
using TechnicalService.Context;
using TechnicalService.Models;

namespace TechnicalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext _context;
       

        public UsersController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            return await _context.Users.ToListAsync();
        }

        [HttpGet("/users-person-role")]
        public async Task<ActionResult<IEnumerable<UserPersonRole>>> getUserPersonRole()
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            List<UserPersonRole> usersList = await _context.Database.SqlQuery<UserPersonRole>($"Sp_GetUsersPersonRole").ToListAsync();

            if (usersList == null) {
                return NotFound();
            }

            return Ok(usersList);
        }

        // GET: api/Users/5
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // GET: api/Users/Login/{UserName}/{Password}
        [HttpGet("/Login/{UserName}/{Password}")]
        public async Task<ActionResult<User>> GetUserLogIn(string UserName, string Password)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var userLogin = await _context.Users.Where(u => u.UserName.Equals(UserName) && u.Password.Equals(Password)).FirstOrDefaultAsync();

            if (userLogin == null)
            {
                return NotFound();
            }

            return userLogin;
        }

        // GET: api/Users/Login/{UserName}/{Password}
        [HttpGet("/Login/User/{UserName}/{Password}")]
        public async Task<ActionResult<User>> GetUserLog(string UserName, string Password)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var userLogin = await _context.Users.Include(p => p.FK_Person).Include(r => r.Fk_Role).Where(u => u.UserName.Equals(UserName) && u.Password.Equals(Password)).FirstOrDefaultAsync();

            if (userLogin == null)
            {
                return NotFound();
            }
            Console.Write("Nombre: " + userLogin?.FK_Person?.LastName + " - Rol: " + userLogin?.Fk_Role?.RoleName);

            return userLogin;
        }

        // GET: api/Users/Login/{UserName}/{Password}
        [HttpGet("/Session/Login/User/{UserName}/{Password}")]
        public async Task<ActionResult<UserPersonRole>> GetUserLoginSession(string UserName, string Password)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }

            var userLogin = await _context.Users.Include(p => p.FK_Person).Include(r => r.Fk_Role).Where(u => u.UserName.Equals(UserName) && u.Password.Equals(Password)).Select(x => new UserPersonRole() { UserId = x.UserId, UserName = x.UserName, Password = x.Password, Email = x.Email, RoleId = x.RoleId, PersonId = x.PersonId, Name = x.FK_Person.Name, LastName = x.FK_Person.LastName, IdentificationCard = x.FK_Person.IdentificationCard, CellPhone = x.FK_Person.CellPhone, Address = x.FK_Person.Address, RoleName = x.Fk_Role.RoleName }).FirstOrDefaultAsync();

            if (userLogin == null)
            {
                return NotFound();
            }

            return userLogin;
        }

        // PUT: api/Users/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutUser(int id, User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UserExists(id))
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

        // POST: api/Users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'DataContext.Users'  is null.");
            }
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.UserId }, user);
        }

        // DELETE: api/Users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            if (_context.Users == null)
            {
                return NotFound();
            }
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return (_context.Users?.Any(e => e.UserId == id)).GetValueOrDefault();
        }
    }
}
