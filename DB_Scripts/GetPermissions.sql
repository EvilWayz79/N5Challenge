ALTER PROCEDURE GetPermissions
	@EmployeeId int
AS
	SELECT e.name, p.name, pt.name
	FROM Employees e	
	INNER JOIN permissions p
	on e.EmployeeId = p.EmployeeId
	inner join permissiontypes pt
	on pt.PermissionTypeId = p.PermissionTypeId
	where e.EmployeeId = @EmployeeId

RETURN 0
