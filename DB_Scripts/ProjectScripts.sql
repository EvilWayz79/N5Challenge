
--INSERT INTO Employees (Name)
--VALUES
    --('John Smith'),
    --('Jane Doe'),
    --('Michael Johnson'),
    --('Eugenio Derbez'),
    --('Patrick Perez'),
    --('Marlon Bronson'),
    --('Jack Palance'),
    --('Martin Sang'),
    --('Domenica Tabacci'),
    --('Fernando Ramirez')

--INSERT INTO PermissionTypes (Name)
--VALUES
    --('Vacation'),
    --('Sick Leave'),
    --('Work From Home')


--INSERT INTO Permissions (EmployeeId, PermissionTypeId, Name)
--VALUES
    --(1, 1, 'Approved vacation for next week'),
    --(2, 2, 'Sick leave due to flu'),
    --(3, 3, 'Work from home request')

exec GetPermissions 9
exec GetPermissionList
exec GetEmployeeList

exec RequestPermission 10, 1, 'Two weeks vacation' 

exec ModifyPermission 5, "Working from Home" 

select * from Employees
select * from Permissions
select * from PermissionTypes

