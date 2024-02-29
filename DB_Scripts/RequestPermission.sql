ALTER PROCEDURE RequestPermission
	@EmployeeId int,
	@PermissionID int,
	@Name nvarchar(50)
AS
	INSERT INTO Permissions (EmployeeId, PermissionTypeId, Name)
	VALUES
		(@EmployeeId, @PermissionID, @Name)

		if @@ROWCOUNT > 0
		begin
			return 1 --success
		end
		else
		begin
			return 0 --failure
		end