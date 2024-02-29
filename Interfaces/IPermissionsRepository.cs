using N5Challenge.Controllers;
using N5Challenge.Models;
using N5Challenge.ViewClasses;

namespace N5Challenge.Interfaces
{
    public interface IPermissionsRepository
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        List<EmployeePermissionView> GetPermissions(int employeeId, ILogger<GetPermissionsController> logger);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="permissionTypeId"></param>
        /// <param name="name"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        String RequestPermission(int employeeId, int permissionTypeId, string name, ILogger<RequestPermissionController> logger);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        String ModifyPermission(int permissionId, string name, ILogger<ModifyPermissionController> logger);

    }
}
