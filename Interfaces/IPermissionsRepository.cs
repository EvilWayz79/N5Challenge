using N5Challenge.Controllers;
using N5Challenge.Models;
using N5Challenge.ViewClasses;
using Nest;

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
        List<EmployeePermissionView> GetPermissions(int employeeId, ILogger<GetPermissionsController> logger, IElasticClient elasticClient);
        /// <summary>
        /// 
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="permissionId"></param>
        /// <param name="name"></param>
        /// <param name="logger"></param>
        /// <returns></returns>
        String RequestPermission(int employeeId, int permissionId, string name, ILogger<RequestPermissionController> logger, IElasticClient elasticClient);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="permissionId"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        String ModifyPermission(int permissionId, string name, ILogger<ModifyPermissionController> logger, IElasticClient elasticClient);

    }
}
