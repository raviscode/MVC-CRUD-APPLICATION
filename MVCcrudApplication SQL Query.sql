
CREATE table tbl_Employee(
EmpID int identity(1,1), Name varchar(40), Department varchar(10), Location varchar(20), Salary int
)
INSERT into tbl_Employee values ('Smith', 'IT', 'Mellborn', 200) 

go
CREATE procedure sp_getEmp
as
begin
select * from tbl_Employee
end

go
CREATE procedure sp_getEmpbyID(@EmpID int)
as
begin
select * from tbl_Employee where EmpID = @EmpID
end

go
CREATE procedure sp_deleteEmp(@EmpID int)
as
begin
delete from tbl_Employee where EmpID = @EmpID
end

go
CREATE procedure sp_insertEmp(@Name varchar(40), @Department varchar(20), @Location varchar(20), @Salary money)
as
begin
insert into tbl_Employee values (@Name, @Department, @Location, @Salary)
end

go
CREATE procedure sp_updateEmp(@EmpID int, @Name varchar(40), @Department varchar(20), @Location varchar(20), @Salary money)
as
begin
update tbl_Employee set Name = @Name, Department = @Department, Location = @Location, Salary = @Salary where EmpID = @EmpID
end


--To insert multiple values at one time.
go
alter procedure sp_InsertMultiple ( @Name varchar(40), @Department varchar(20), @Location varchar(20), @Salary money)
as
begin
declare @count int = 0;
while @count < 20
insert into tbl_Employee values (@Name, @Department, @Location, @Salary)
set @count = @count + 1;
end

go
exec sp_InsertMultiple
@Name = 'Maria',
@Department = 'HR',
@Location = 'Mellborn',
@Salary = 2000
