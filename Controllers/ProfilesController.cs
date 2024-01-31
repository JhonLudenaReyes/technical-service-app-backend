using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Immutable;
using TechnicalService.Context;
using TechnicalService.Models;

namespace TechnicalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfilesController : ControllerBase
    {
        private readonly DataContext _context;

        public ProfilesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost("/profiles-save")]
        public async Task<string> PostProfile(Profile[] profiles)
        {
            if (_context.Profiles == null)
            {
                return "Entity set 'DataContext.Profiles'  is null.";
            }

            foreach (var profile in profiles)
            {
                _context.Profiles.Add(profile);
            }

            await _context.SaveChangesAsync();

            return "Sus datos se han guardado satisfactoriamente";
        }

        [HttpGet("/profiles/search-by-role/{roleId}")]
        public async Task<ActionResult<IEnumerable<Profile>>> getProfilesByRoleId(int roleId)
        {

            var profiles = await _context.Profiles.Where(r => r.RoleId.Equals(roleId)).Where(r => r.State.Equals("A")).ToListAsync();

            if (profiles == null)
            {
                return NotFound();
            }

            return profiles;
        }

    }
}
