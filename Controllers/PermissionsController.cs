using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TechnicalService.Context;
using TechnicalService.Models;

namespace TechnicalService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PermissionsController : ControllerBase
    {
        private readonly DataContext _context;

        public PermissionsController(DataContext context)
        {
            _context = context;
        }

        [HttpGet("/api/permissions/get-permissions-active")]
        public async Task<ActionResult<IEnumerable<Permission>>> GetPermissionsActive()
        {
            if(_context.Permissions == null)
            {
                return NotFound();
            }

            var permissions = await _context.Permissions.Where(p=>p.State.Equals("A")).ToListAsync();

            if (permissions == null)
            {
                return NotFound();
            }

            return permissions;
        }

        [HttpGet("/api/permissions/get-permissions-active-check")]
        public async Task<ActionResult<IEnumerable<PermissionValue>>> GetPermissionsActiveCheck()
        {
            if (_context.Permissions == null)
            {
                return NotFound();
            }

            var permissions = await _context.Permissions.Where(p => p.State.Equals("A")).ToListAsync();

            if (permissions == null)
            {
                return NotFound();
            }

            List<PermissionValue> permissionsValuesList = new List<PermissionValue>();

            foreach (var permission in permissions)
            {
                PermissionValue permissionValue = new PermissionValue();
                permissionValue.Name = permission.PermissionName;
                permissionValue.key = permission.PermissionId;

                permissionsValuesList.Add(permissionValue);
            }

            return permissionsValuesList;
        }
    }
}
