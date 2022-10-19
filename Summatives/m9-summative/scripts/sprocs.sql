if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAMe = 'dvdSelectAll')
	drop procedure dvdSelectAll
go

create procedure dvdSelectAll as
begin
	select * from dvd
end

go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAMe = 'dvdInsert')
	drop procedure dvdInsert
go

create procedure dvdInsert (
	@dvdId int output,
	@dvdTitle varchar(50),
	@dvdDirector varchar(25),
	@dvdRating varchar(5),
	@dvdReleaseYear int,
	@notes varchar (50)

) as
begin
	insert into dvd (dvdTitle, dvdDirector,dvdRating,dvdReleaseYear,notes)
	values(@dvdTitle,@dvdDirector,@dvdRating,@dvdReleaseYear,@notes)

	set @dvdId = SCOPE_IDENTITY();
end

go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAMe = 'dvdUpdate')
	drop procedure dvdUpdate
go

create procedure dvdUpdate (
	@dvdId int,
	@dvdTitle varchar(50),
	@dvdDirector varchar(25),
	@dvdRating varchar(5),
	@dvdReleaseYear int,
	@notes varchar (50)

) as
begin
	update dvd set
		--dvdId = @dvdId,
		dvdTitle=@dvdTitle,
		dvdDirector=@dvdDirector,
		dvdRating=@dvdRating,
		dvdReleaseYear=@dvdReleaseYear,
		notes=@notes
		
		where dvdid=@dvdId

	
end

go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAMe = 'dvdDelete')
	drop procedure dvdDelete
go

create procedure dvdDelete (
	@dvdId int
	)
	as
begin
	delete from dvd where dvdId = @dvdId
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAMe = 'dvdSelect')
	drop procedure dvdSelect
go

create procedure dvdSelect (
	@dvdId int
	)
	as
begin
	select * from dvd
	where dvdid=@dvdId
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAMe = 'dvdSelectTitle')
	drop procedure dvdSelectTitle
go

create procedure dvdSelectTitle (
	@dvdTitle nvarchar(25)
	)
	as
begin
	select * from dvd
	where dvdTitle like @dvdTitle
end
go

if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAMe = 'dvdSelectRating')
	drop procedure dvdSelectRating
go

create procedure dvdSelectRating (
	@dvdTitle nvarchar(25)
	)
	as
begin
	select * from dvd
	where dvdRating like @dvdRating
end
go