using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Packaging;
using System.Collections;
using System.Data;
using System.Linq;
using TechnicalService.Context;
using TechnicalService.Models;

namespace TechnicalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly DataContext _context;

        public RolesController(DataContext context)
        {
            _context = context;
        }

        // GET: api/Roles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Role>>> GetRoles()
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            return await _context.Roles.ToListAsync();
        }

        [HttpGet("/api/roles/get-active-roles")]
        public async Task<ActionResult<IEnumerable<Role>?>> GetActiveRoles()
        {
            if(_context.Roles == null)
            {
                return NotFound();
            }

            var roles = await _context.Roles.Where(e => e.State.Equals("A")).ToListAsync();

            if(roles == null)
            {
                return NotFound();
            }

            return roles;
        }

        [HttpGet("/api/roles/get-active-roles-value")]
        public async Task<ActionResult<IEnumerable<RoleValue>>> GetActiveRolesValue()
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }

            var roles = await _context.Roles.Where(e => e.State.Equals("A")).ToListAsync();

            

            if (roles == null)
            {
                return NotFound();
            }

            
            List<RoleValue> roleList = new List<RoleValue>();

            foreach (Role role in roles)
            {
                RoleValue roleValue = new RoleValue();
                roleValue.Name = role.RoleName;
                roleValue.Code = role.RoleId;

                roleList.Add(roleValue);
            }

            return roleList;


        }

        // GET: api/Roles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Role>> GetRole(int id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var role = await _context.Roles.FindAsync(id);

            if (role == null)
            {
                return NotFound();
            }

            return role;
        }

        // PUT: api/Roles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRole(int id, Role role)
        {
            if (id != role.RoleId)
            {
                return BadRequest();
            }

            _context.Entry(role).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoleExists(id))
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

        // POST: api/Roles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Role>> PostRole(Role role)
        {
            if (_context.Roles == null)
            {
                return Problem("Entity set 'DataContext.Roles'  is null.");
            }
            _context.Roles.Add(role);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRole", new { id = role.RoleId }, role);
        }

        [HttpDelete("/api/roles/delete-log-role/{id}")]
        public async Task<IActionResult> DeleteLogRole(int id)
        {
            if(_context.Roles == null)
            {
                return NotFound();
            }

            var role = await _context.Roles.FindAsync(id);

            if(role == null) {
                return NotFound();
            }

            role.State = "I";

            _context.Roles.Update(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE: api/Roles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRole(int id)
        {
            if (_context.Roles == null)
            {
                return NotFound();
            }
            var role = await _context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            _context.Roles.Remove(role);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoleExists(int id)
        {
            return (_context.Roles?.Any(e => e.RoleId == id)).GetValueOrDefault();
        }
    }
}
