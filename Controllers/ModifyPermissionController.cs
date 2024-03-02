using Microsoft.AspNetCore.Mvc;
using N5Challenge.Interfaces;
using N5Challenge.Tools;
using Nest;

namespace N5Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ModifyPermissionController : ControllerBase
    {
        private readonly ILogger<ModifyPermissionController> _logger;
        private readonly IPermissionsRepository _permissionRepository;
        private readonly IElasticClient _elasticClient;

        public ModifyPermissionController(ILogger<ModifyPermissionController> logger, IPermissionsRepository permissionsRepository, IElasticClient elasticClient)
        {
            _logger = logger;
            _permissionRepository = permissionsRepository;
            _elasticClient = elasticClient;

        }

        // EmployeeId, PermissionTypeId, Name

        [HttpPut("PermissionId, Name")]
        public IActionResult ModifyPermission(int permissionId, string name)
        {
            try
            {
                string newPermission = _permissionRepository.ModifyPermission(permissionId, name, _logger, _elasticClient);
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
