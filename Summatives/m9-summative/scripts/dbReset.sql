if exists(select * from INFORMATION_SCHEMA.ROUTINES
	where ROUTINE_NAMe = 'dbReset')
	drop procedure dbReset
go

create procedure dbReset as
begin
	delete from dvd;
	
	dbcc checkident('dvd', RESEED, 1)

	SET IDENTITY_INSERT dvd ON;
	
	insert into dvd(dvdId, dvdTitle, dvdDirector, dvdRating, dvdReleaseYear, notes)
	values (1, 'Bladerunner 2049', 'Denis Villanueve', 'R',2017, 'more human than too human'),
	(2, 'Jurassic Park','Steven Spielberg','R',1995,'life, uh, finds a way'),
	(3, 'Terminator 2', 'James Cameron', 'R', 1992, 'Guess who is back'),
	(4,'The Lion King', 'Guerrillmo del Toro','PG-13', 1996, 'Hakuna Matata'),
	(5, 'The Fellowship of the Ring', 'Peter Jackson', 'PG', 1999,'Fool of a Took!')
	
	SET IDENTITY_INSERT dvd off;
end

exec dbReset
select * from dvd