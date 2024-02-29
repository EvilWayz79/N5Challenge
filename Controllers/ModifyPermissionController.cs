using Microsoft.AspNetCore.Mvc;
using N5Challenge.Interfaces;
using N5Challenge.Tools;

namespace N5Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModifyPermissionController : ControllerBase
    {
        private readonly ILogger<ModifyPermissionController> _logger;
        private readonly IPermissionsRepository _permissionRepository;

        public ModifyPermissionController(ILogger<ModifyPermissionController> logger, IPermissionsRepository permissionsRepository)
        {
            _logger = logger;
            _permissionRepository = permissionsRepository;
        }

        // EmployeeId, PermissionTypeId, Name

        [HttpPut("PermissionTypeId, Name")]
        public IActionResult ModifyPermission(int permissionTypeId, string name)
        {
            try
            {
                string newPermission = _permissionRepository.ModifyPermission(permissionTypeId, name, _logger);
                _logger.LogInformation(GlobalData.REGISTER_NEW_PERMISSION);

                return Ok(newPermission);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, GlobalData.REQUEST_PERMISSION_ERROR);
                return BadRequest(GlobalData.REQUEST_PERMISSION_ERROR);
            }
        }
    }
}
