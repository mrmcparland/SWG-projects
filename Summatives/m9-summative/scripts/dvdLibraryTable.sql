use dvdLibrary
go

if exists(select * from sys.tables where name = 'dvd')
drop table dvd
go

create table dvd(
	dvdId int identity(1,1) not null primary key,
	dvdTitle varchar(50) not null,
	dvdDirector varchar(25) not null,
	dvdRating varchar(5) not null,
	dvdReleaseYear int not null,
	notes varchar (50) null
)