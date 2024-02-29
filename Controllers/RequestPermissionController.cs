﻿using Microsoft.AspNetCore.Mvc;
using N5Challenge.Interfaces;
using N5Challenge.Models;
using N5Challenge.Tools;

namespace N5Challenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RequestPermissionController : ControllerBase
    {
        private readonly ILogger<RequestPermissionController> _logger;
        private readonly IPermissionsRepository _permissionRepository;

        public RequestPermissionController(ILogger<RequestPermissionController> logger, IPermissionsRepository permissionsRepository)
        {
            _logger = logger;
            _permissionRepository = permissionsRepository;
        }

        // EmployeeId, PermissionTypeId, Name
        
        [HttpPut("EmployeeId, PermissionTypeId, Name")]
        public IActionResult RequestPermission(int employeeId, int permissionTypeId, string name)
        {
            try
            {
                string newPermission = _permissionRepository.RequestPermission(employeeId, permissionTypeId, name, _logger);
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
