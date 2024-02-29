using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using N5Challenge.Data;
using N5Challenge.Interfaces;
using N5Challenge.Models;
using N5Challenge.Tools;
using N5Challenge.ViewClasses;


// using serilog

namespace N5Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GetPermissionsController : ControllerBase
    {
        private readonly ILogger<GetPermissionsController> _logger;
        private readonly IPermissionsRepository _permissionRepository;

        public GetPermissionsController(ILogger<GetPermissionsController> logger, IPermissionsRepository permissionsRepository)
        {
            _logger = logger;
            _permissionRepository = permissionsRepository;
        }

        [HttpGet(Name = "EmployeeId")]
        public IActionResult GetPermissions(int employeeId)
        {
            try
            {
                var permissions = _permissionRepository.GetPermissions(employeeId, _logger);
                _logger.LogInformation(GlobalData.DISPLAY_PERMISSIONS_BY_USER);

                return Ok(permissions);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, GlobalData.REQUEST_PERMISSION_ERROR);
                return BadRequest(GlobalData.REQUEST_PERMISSION_ERROR);
            }
        }
    }
}
