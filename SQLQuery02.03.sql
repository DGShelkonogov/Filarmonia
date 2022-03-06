go
use [Filarmonia]
go
--//1
create table [Post] (
ID_Post int identity(1,1) not null,
Name_post varchar(50) not null,
constraint [PK_Post] primary key clustered (ID_Post ASC) on [primary]
)
 
--2
create table [Type_of_structure] (
ID_type_of_structure int identity(1,1) not null,
Name_type_of_structure varchar(50) not null,
constraint [PK_type_of_structure] primary key clustered (ID_type_of_structure ASC) on [primary]
)

--3
create table [Awarding] (
ID_award int identity(1,1) not null,
Name_award  varchar(50) not null,
constraint [PK_award ] primary key clustered (ID_award  ASC) on [primary]
)

--4
create table [Genre] (
ID_genre int identity(1,1) not null,
Name_genre varchar(50) not null,
constraint [PK_genre ] primary key clustered (ID_genre  ASC) on [primary]
)

--5
create table [charcteristic_of_the_structure] (
ID_charcteristic_of_the_structure int identity(1,1) not null,
Name_charcteristic_of_the_structure varchar(50) not null,
constraint [PK_charcteristic_of_the_structure] primary key clustered (ID_charcteristic_of_the_structure ASC) on [primary]
)

--6
create table [User] (
ID_User int identity(1,1) not null,
Password_ varchar(30) not null,
Login_ varchar(30) not null,
Middle_name_user varchar (50) null,
Name_user varchar(50) not null,
Surname_user varchar(50)not null,
Post_ID int not null
constraint [PK_User] primary key clustered (ID_User ASC) on [primary],
constraint [FK_Post_User] foreign key (Post_ID) references [Post] (ID_Post)
)
--7
create table [Actor] (
ID_Actor int identity(1,1) not null,
Middle_name_actor varchar(50) null,
Name_actor varchar(50) not null,
Surname_actor varchar(50) not null,
award_ID int not null
constraint [PK_Actor] primary key clustered (ID_Actor ASC) on [primary],
constraint [FK_award_Actor] foreign key (award_ID) references [Awarding] (ID_award)
)

--8
create table [List_of_the_genre] (
ID_list_of_the_genre int identity(1,1) not null,
genre_ID int not null,
Actor_ID int not null
constraint [PK_list_of_the_genre] primary key clustered (ID_list_of_the_genre ASC) on [primary],
constraint [FK_genre_list_of_the_genre] foreign key (genre_ID) references [Genre] (ID_genre),
constraint [FK_Actor_list_of_the_genre] foreign key (Actor_ID) references [Actor] (ID_Actor)
)

--9
create table [List_of_characteristics] (
ID_list_of_characteristics int identity(1,1) not null,
size varchar (10) not null,
charcteristic_of_the_structure_ID int not null,
type_of_structure_ID int not null
constraint [PK_list_of_characteristics] primary key clustered (ID_list_of_characteristics ASC) on [primary],
constraint [FK_charcteristic_of_the_structure_list_of_characteristics] foreign key (charcteristic_of_the_structure_ID) references [charcteristic_of_the_structure] (ID_charcteristic_of_the_structure),
constraint [FK_type_of_structure_list_of_characteristics] foreign key (type_of_structure_ID) references [Type_of_structure] (ID_type_of_structure)
)

--10
create table [List_of_the_actor] (
ID_list_of_the_actor int identity(1,1) not null,
Kolvo_actor varchar (10) not null,
Actor_ID int not null
constraint [PK_list_of_the_actor] primary key clustered (ID_list_of_the_actor ASC) on [primary],
constraint [FK_Actor_list_of_the_actor] foreign key (Actor_ID) references [Actor] (ID_Actor)
)

--11
create table [Cultural_building] (
ID_Cultural_building int identity(1,1) not null,
Name_Cultural_building varchar (50) not null,
type_of_structure_ID int not null
constraint [PK_Cultural_building] primary key clustered (ID_Cultural_building ASC) on [primary],
constraint [FK_type_of_structure_Cultural_building] foreign key (type_of_structure_ID) references [Type_of_structure] (ID_type_of_structure)
)

--12
create table [Ever] (
ID_Ever int identity(1,1) not null,
Date_ever date not null,
Venue varchar(50) not null,
Time_ever datetime not null,
Cultural_building_ID int not null,
User_ID int not null,
Actor_ID int not null
constraint [PK_Ever] primary key clustered (ID_Ever ASC) on [primary],
constraint [FK_Cultural_building_Ever] foreign key (Cultural_building_ID) references [Cultural_building] (ID_Cultural_building),
constraint [FK_User_Ever] foreign key (User_ID) references [User] (ID_User),
constraint [FK_Actor_Ever] foreign key (Actor_ID) references [Actor] (ID_Actor)
)
--------------------------------------------------------------------------------------------------------------------------------------------

--go
--CREATE PROC User_Insert
--@Password_ varchar(30), @Login_ varchar(30), @Middle_name_user varchar (50), @Name_user varchar(50), @Surname_user varchar(50), @Post_ID int
--AS
--INSERT INTO [User] (Password_,Login_,Middle_name_user,Name_user,Surname_user,Post_ID)
--VALUES (@Password_,@Login_,@Middle_name_user,@Name_user,@Surname_user,@Post_ID)

--go
--CREATE PROCEDURE User_Update
--@Password_ varchar(30), @Login_ varchar(30), @Middle_name_user varchar (50), @Name_user varchar(50), @Surname_user varchar(50), @Post_ID int, @ID_User int
--AS
--UPDATE [User] set
--Password_=@Password_,
--Login_=@Login_,
--Middle_name_user=@Middle_name_user,
--Name_user=@Name_user,
--Surname_user=@Surname_user,
--Post_ID=@Post_ID
--WHERE
--ID_User=@ID_User

--go
--CREATE PROC User_Delete
--@ID_User int
--AS
--DELETE FROM [User]
--WHERE
--ID_User=@ID_User
-------------------------------------------


--go
--CREATE PROC Actor_Insert
--@Middle_name_actor varchar (50), @Name_actor varchar(50), @Surname_actor varchar(50), @award_ID int
--AS
--INSERT INTO [Actor] (Middle_name_actor,Name_actor,Surname_actor,award_ID)
--VALUES (@Middle_name_actor,@Name_actor,@Surname_actor,@award_ID)

--go
--CREATE PROCEDURE Actor_Update
--@Middle_name_actor varchar (50), @Name_actor varchar(50), @Surname_actor varchar(50), @award_ID int, @ID_Actor int
--AS
--UPDATE Actor set
--Middle_name_actor=@Middle_name_actor,
--Name_actor=@Name_actor,
--Surname_actor=@Surname_actor,
--award_ID=@award_ID
--WHERE
--ID_Actor=@ID_Actor

--go
--CREATE PROC Actor_Delete
--@ID_Actor int
--AS
--DELETE FROM Actor
--WHERE
--ID_Actor=@ID_Actor
----------------------------------------------------------------------------



--go
--CREATE PROC List_of_the_genre_Insert
--@genre_ID int, @Actor_ID int
--AS
--INSERT INTO [List_of_the_genre] (genre_ID,Actor_ID)
--VALUES (@genre_ID,@Actor_ID)

--go
--CREATE PROCEDURE List_of_the_genre_Update
--@genre_ID int, @Actor_ID int, @ID_list_of_the_genre int
--AS
--UPDATE List_of_the_genre set
--genre_ID=@genre_ID,
--Actor_ID=@Actor_ID
--WHERE
--ID_list_of_the_genre=@ID_list_of_the_genre

--go
--CREATE PROC List_of_the_genre_Delete
--@ID_list_of_the_genre int
--AS
--DELETE FROM List_of_the_genre
--WHERE
--ID_list_of_the_genre=@ID_list_of_the_genre
--------------------------------------------------


--go
--CREATE PROC Genre_Insert
--@Name_genre varchar(50)
--AS
--INSERT INTO [Genre] (Name_genre)
--VALUES (@Name_genre)

--go
--CREATE PROCEDURE Genre_Update
--@Name_genre varchar(50), @ID_genre int
--AS
--UPDATE Genre set
--Name_genre=@Name_genre
--WHERE
--ID_genre=@ID_genre

--go
--CREATE PROC Genre_Delete
--@ID_genre int
--AS
--DELETE FROM Genre
--WHERE
--ID_genre=@ID_genre
------------------------------------------------------

--go
--CREATE PROC Ever_Insert
--@Date_ever date ,@Venue varchar(50) ,@Time_ever datetime,@Cultural_building_ID int,@User_ID int,@Actor_ID int
--AS
--INSERT INTO [Ever] (Date_ever,Venue,Time_ever,Cultural_building_ID,User_ID,Actor_ID)
--VALUES (@Date_ever,@Venue,@Time_ever,@Cultural_building_ID,@User_ID,@Actor_ID)

--go
--CREATE PROCEDURE Ever_Update
--@Date_ever date ,@Venue varchar(50) ,@Time_ever datetime,@Cultural_building_ID int,@User_ID int,@Actor_ID int, @ID_Ever int
--AS
--UPDATE Ever set
--Date_ever=@Date_ever,
--Venue=@Venue,
--Time_ever=@Time_ever,
--Cultural_building_ID=@Cultural_building_ID,
--User_ID=@User_ID,
--Actor_ID=@Actor_ID
--WHERE
--ID_Ever=@ID_Ever

--go
--CREATE PROC Ever_Delete
--@ID_Ever int
--AS
--DELETE FROM Ever
--WHERE
--ID_Ever=@ID_Ever
---------------------------------------------------

--go
--CREATE PROC Awarding_Insert
--@Name_award varchar(50)
--AS
--INSERT INTO [Awarding] (Name_award)
--VALUES (@Name_award)

--go
--CREATE PROCEDURE Awarding_Update
--@Name_award varchar(50), @ID_award int
--AS
--UPDATE Awarding set
--Name_award=@Name_award
--WHERE
--ID_award=@ID_award

--go
--CREATE PROC Awarding_Delete
--@ID_award int
--AS
--DELETE FROM Awarding
--WHERE
--ID_award=@ID_award
------------------------------------------------------------------------



--go
--CREATE PROC List_of_the_actor_Insert
--@Kolvo_actor varchar (10), @Actor_ID int
--AS
--INSERT INTO [List_of_the_actor] (Kolvo_actor,Actor_ID)
--VALUES (@Kolvo_actor,@Actor_ID)

--go
--CREATE PROCEDURE List_of_the_actor_Update
--@Kolvo_actor varchar (10), @Actor_ID int, @ID_list_of_the_actor int
--AS
--UPDATE List_of_the_actor set
--Kolvo_actor=@Kolvo_actor,
--Actor_ID=@Actor_ID
--WHERE
--ID_list_of_the_actor=@ID_list_of_the_actor

--go
--CREATE PROC List_of_the_actor_Delete
--@ID_list_of_the_actor int
--AS
--DELETE FROM List_of_the_actor
--WHERE
--ID_list_of_the_actor=@ID_list_of_the_actor
----------------------------------------------------------

--go
--CREATE PROC List_of_characteristics_Insert
--@size varchar (10),@charcteristic_of_the_structure_ID int, @type_of_structure_ID int
--AS
--INSERT INTO [List_of_characteristics] (size,charcteristic_of_the_structure_ID,type_of_structure_ID)
--VALUES (@size,@charcteristic_of_the_structure_ID,@type_of_structure_ID)

--go
--CREATE PROCEDURE List_of_characteristics_Update
--@size varchar (10),@charcteristic_of_the_structure_ID int, @type_of_structure_ID int, @ID_list_of_characteristics int
--AS
--UPDATE List_of_characteristics set
--size=@size,
--charcteristic_of_the_structure_ID=@charcteristic_of_the_structure_ID,
--type_of_structure_ID=@type_of_structure_ID
--WHERE
--ID_list_of_characteristics=@ID_list_of_characteristics

--go
--CREATE PROC List_of_characteristics_Delete
--@ID_list_of_characteristics int
--AS
--DELETE FROM List_of_characteristics
--WHERE
--ID_list_of_characteristics=@ID_list_of_characteristics
-------------------------------------------------------------

--go
--CREATE PROC charcteristic_of_the_structure_Insert
--@Name_charcteristic_of_the_structure varchar(50)
--AS
--INSERT INTO [charcteristic_of_the_structure] (Name_charcteristic_of_the_structure)
--VALUES (@Name_charcteristic_of_the_structure)

--go
--CREATE PROCEDURE charcteristic_of_the_structure_Update
--@Name_charcteristic_of_the_structure varchar(50), @ID_charcteristic_of_the_structure int
--AS
--UPDATE charcteristic_of_the_structure set
--Name_charcteristic_of_the_structure=@Name_charcteristic_of_the_structure
--WHERE
--ID_charcteristic_of_the_structure=@ID_charcteristic_of_the_structure

--go
--CREATE PROC charcteristic_of_the_structure_Delete
--@ID_charcteristic_of_the_structure int
--AS
--DELETE FROM charcteristic_of_the_structure
--WHERE
--ID_charcteristic_of_the_structure=@ID_charcteristic_of_the_structure
----------------------------------------------------------------------------------------------

--go
--CREATE PROC Post_Insert
--@Name_post varchar(50)
--AS
--INSERT INTO [Post] (Name_post)
--VALUES (@Name_post)

--go
--CREATE PROCEDURE Post_Update
--@Name_post varchar(50), @ID_Post int
--AS
--UPDATE Post set
--Name_post=@Name_post
--WHERE
--ID_Post=@ID_Post

--go
--CREATE PROC Post_Delete
--@ID_Post int
--AS
--DELETE FROM Post
--WHERE
--ID_Post=@ID_Post
--------------------------------------------------------------------------------------------------

--go
--CREATE PROC Type_of_structure_Insert
--@Name_type_of_structure varchar(50)
--AS
--INSERT INTO [Type_of_structure] (Name_type_of_structure)
--VALUES (@Name_type_of_structure)

--go
--CREATE PROCEDURE Type_of_structure_Update
--@Name_type_of_structure varchar(50), @ID_type_of_structure int
--AS
--UPDATE Type_of_structure set
--Name_type_of_structure=@Name_type_of_structure
--WHERE
--ID_type_of_structure=@ID_type_of_structure

--go
--CREATE PROC Type_of_structure_Delete
--@ID_type_of_structure int
--AS
--DELETE FROM Type_of_structure
--WHERE
--ID_type_of_structure=@ID_type_of_structure
 -------------------------------------------------------------------------------------

--go
--CREATE PROC Cultural_building_Insert
--@Name_Cultural_building varchar(50),@type_of_structure_ID int
--AS
--INSERT INTO [Cultural_building] (Name_Cultural_building,type_of_structure_ID)
--VALUES (@Name_Cultural_building,@type_of_structure_ID)

--go
--CREATE PROCEDURE 
--@Name_Cultural_building varchar(50),@type_of_structure_ID int, @ID_Cultural_building int
--AS
--UPDATE Cultural_building set
--Name_Cultural_building=@Name_Cultural_building,
--type_of_structure_ID=@type_of_structure_ID
--WHERE
--ID_Cultural_building=@ID_Cultural_building

--go
--CREATE PROC Cultural_building_Delete
--@ID_Cultural_building int
--AS
--DELETE FROM Cultural_building
--WHERE
--ID_Cultural_building=@ID_Cultural_building
---------------------------------------------------
