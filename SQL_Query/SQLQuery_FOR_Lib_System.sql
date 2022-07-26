-- To get the data of users when login
alter PROC SP_LOGIN
@ID nvarchar(50),@PWD nvarchar(50)

as 

Select * 
from System_Users 
where User_Name=@ID AND User_Password=@PWD

-------------------------------------------------------------
-- This is for add a new system user 
create proc ADD_System_User
@ID nvarchar(50), @PWD nvarchar(50), @Type nvarchar(50)
as
INSERT INTO System_Users (User_Name,User_Password,User_Type) 
				   values(@ID, @PWD,@Type)


-------------------------------------------------------------


-- New Store Procedure Tuesday 26/7/2022---------------------


-------------------------------------------------------------
-- This is for bring all department in Library
create proc SP_Bring_Lib_Dept
as
select ROW_NUMBER() over(order by Dept_ID) as 'التسلسل'
				,Dept_ID,Dept_Name as 'أسم القسم',Dept_Describtion as 'وصف القسم'
from Departement
-------------------------------------------------------------
-- This is for deletet a Dept
CREATE PROC  DELETE_Dept
@ID int
as 
Delete from Departement where Dept_ID=@ID
------------------------------------------------
-- This is for update dept
create proc EDIT_Dept
@Dept_ID int,
@Dept_Name nvarchar(100),
@Dept_Descrip nvarchar(500)

as
update Departement
	set Dept_name=@Dept_Name, Dept_Describtion=@Dept_Descrip
	Where Dept_ID=@Dept_ID

--------------------------------------------------
-- This is for add Management
create proc ADD_Dept
@Dept_Name nvarchar(100),
@Dept_Descrip nvarchar(500)
as
Insert into Departement(Dept_name, Dept_Describtion)
			values(@Dept_Name, @Dept_Descrip)