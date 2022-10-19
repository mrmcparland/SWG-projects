use master
go

if exists(select * from sys.databases where name = 'dvdLibrary')
drop database dvdLibrary
go

create database dvdLibrary
go

