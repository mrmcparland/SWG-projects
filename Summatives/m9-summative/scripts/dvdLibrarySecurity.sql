USE master
GO

create login DvdLibraryApp with password = 'testing123'
go

use dvdLibrary
go

create user dvdFan for login DvdLibraryApp
go

grant execute on dbReset to dvdFan
grant execute on dvdSelectAll to dvdFan

GRANT SELECT ON dvd TO dvdFan
GRANT INSERT ON dvd TO dvdFan
GRANT UPDATE ON dvd TO dvdFan
GRANT DELETE ON dvd TO dvdFan

go

