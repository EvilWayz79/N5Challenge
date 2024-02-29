ALTER PROCEDURE ModifyPermission
	@PermissionId int,
	@Name nvarchar(50)
AS
	UPDATE Permissions
	SET Name = @Name
	WHERE PermissionId = @PermissionId

	if @@ROWCOUNT > 0
	begin
		RETURN 1
	end
	else
	begin
		RETURN 0
	end


