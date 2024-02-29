CREATE PROCEDURE GetPermissionList
	
AS
	SELECT PermissionTypeId, Name
	FROM PermissionTypes	

RETURN 0
