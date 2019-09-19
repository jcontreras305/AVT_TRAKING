create database VRT_TRAKING 
GO

use VRT_TRAKING 
GO

create table users(
	idUsers varchar(36) primary key not null,
	nameUser varchar(20) not null,
	passwordUser varchar(25) not null
)

insert into users values (NEWID(), 'admin' , 'admin')

--############################################################################
--############# Tables Employees , Contact , HomeAdress , PayRate ############
--############################################################################
use VRT_TRAKING

create table employees(
	idEmployee varchar(36) primary key not null,
	numberEmploye int not null,
	firstName varchar(30),
	lastName varchar(25),
	middleName varchar(25),
	socialNumber varchar(14),
	SAPNumber int,
	photo image,
	idHomeAdress varchar(36),
	idContact varchar(36),
	idPayRate varchar(36),
	estatus char(1)
)

alter table employees 
add constraint fk_idPayRate_employees
foreign key (idPayRate) references payRate(idPayRate)

alter table employees 
add constraint fk_idContact_employees
foreign key (idContact) references contact(idContact)

alter table employees 
add constraint fk_idHomeAdress_employees
foreign key (idHomeAdress) references HomeAddress(idHomeAdress)


create table contact(
	idContact varchar(36) primary key not null,
	phoneNumber1 varchar(13),
	phoneNumber2 varchar(13),
	emial varchar(50)
)

create table HomeAddress (
	idHomeAdress varchar(36) primary key not null,
	avenue varchar(80),
	number int,
	city varchar(20), 
	providence varchar(20),
	postalCode int
)

create table payRate(
	idPayRate varchar(36) primary key not null ,
	payRate1 float,
	payRate2 float, 
	payRate3 float
)

