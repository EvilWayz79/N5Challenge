ALTER PROCEDURE GetPermissions
	@EmployeeId int
AS
	SELECT e.name as empName, p.name as perName, pt.name as ptName, p.PermissionId, e.EmployeeId, pt.PermissionTypeId
	FROM Employees e	
	INNER JOIN permissions p
	on e.EmployeeId = p.EmployeeId
	inner join permissiontypes pt
	on pt.PermissionTypeId = p.PermissionTypeId
	where e.EmployeeId = @EmployeeId

RETURN 0
