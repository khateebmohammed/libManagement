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


-------------------------------------------------------------


-- New Store Procedure Wenseday 27/7/2022---------------------


-------------------------------------------------------------

---------------------------------------------------------------
-- This is to bring the shelfs with its depart
create proc SP_Bring_Shilf
as 
select ROW_NUMBER() over(order by Shelf_ID) as 'التسلسل'
		,s.Shelf_ID,s.Shelf_Code as 'كود الرف',
		d.Dept_Name as 'القسم', s.Shelf_Describtion as 'وصف الرف' 
from Departement as d inner join Shelf as s 
on s.Dept_ID=d.Dept_ID

---------------------------------------------------------------
-- This is to bring the departement that the shelf belong to
create proc SP_Bring_Depts_by_shelf_ID
@ID int
as 
select d.Dept_ID,Dept_Name
from Departement as d inner join Shelf as s
on d.Dept_ID=s.Dept_ID
where s.Shelf_ID=@ID

-------------------------------------------------------------
-- This is for deletet a Shelf
CREATE PROC  DELETE_Shelf
@ID int
as 
Delete from Shelf where Shelf_ID=@ID


------------------------------------------------
-- This is for update Shelf
create proc EDIT_Shelf
@Shelf_ID int,
@Shelf_Code nvarchar(50),
@Shelf_Descrip nvarchar(300),
@Dept_ID int

as
update Shelf
	set Shelf_Code=@Shelf_Code, Shelf_Describtion=@Shelf_Descrip, Dept_ID=@Dept_ID
	Where Shelf_ID=@Shelf_ID

--------------------------------------------------
-- This is for add Shelf
create proc ADD_Shelf
@Shelf_Code nvarchar(50),
@Shelf_Descrip nvarchar(300),
@Dept_ID int
as
Insert into Shelf(Shelf_Code, Shelf_Describtion,Dept_ID)
			values(@Shelf_Code, @Shelf_Descrip,@Dept_ID)


---------------------------------------------------------------
-- This is to bring the departement that the shelf belong to
create proc SP_Bring_Depts_for_shelfs
as 
select Dept_ID,Dept_Name
from Departement