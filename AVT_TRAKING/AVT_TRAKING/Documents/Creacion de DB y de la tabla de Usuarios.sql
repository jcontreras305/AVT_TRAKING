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
drop table employees

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
drop table contact

create table HomeAddress (
	idHomeAdress varchar(36) primary key not null,
	avenue varchar(80),
	number int,
	city varchar(20), 
	providence varchar(20),
	postalCode int
)
drop table HomeAddress

create table payRate(
	idPayRate varchar(36) primary key not null ,
	payRate1 float,
	payRate2 float, 
	payRate3 float
)
drop table payRate

--############################################################################
--############# Tables clients ###############################################
--############################################################################
create table clients(
IdClients int not null primary key, 
CompanyName varchar(50), 
Address varchar(30),
City varchar(30),
StateProvince varchar(30), 
PostalCode int,  
ContactFirstName varchar(20), 
ContactLastName varchar(20), 
ContactTitle varchar(20), 
PhoneNumber varchar(15), 
JobNumber int, 
SubJob int, 
CostCode varchar(25), 
WorkLumpsum varchar(10), 

)
insert into clients values(5555,'Cementera','Calle mirador','Jacona','Michoacan',59890,'Andres','Reyes','Supervisor',
							'815-955-9982',8847,200,'240000000000000','T&M'),
							(5556,'Cementera','Calle mirador','Zamora','Michoacan',59890,'Andres','Reyes','Supervisor',
							'815-955-9982',8848,201,'240000000000001','T&M'),
							(5557,'Cementera','Calle mirador','Cotija','Michoacan',59890,'Andres','Reyes','Supervisor',
							'815-955-9982',8848,202,'240000000000002','T&M'),
							(5558,'Cementera','Calle mirador','Los Reyes','Michoacan',59890,'Andres','Reyes','Supervisor',
							'815-955-9982',8850,203,'240000000000003','T&M')

--############################################################################
--############# Tables materials #############################################
--############################################################################

create table materials(
IdMaterials int not null primary key, 
Vendor varchar(25), 
MSize varchar(10), 
MType varchar(10), 
MThickness varchar(10), 
MPrize varchar(15), 
MDesc varchar(20), 
Class varchar(20),
ElbowType varchar(10), 
ElbowThickness int, 
ElbowPrize varchar(15),
ElbowDesc varchar(40),
)

insert into materials values(1,'Homedepo','1.5','CS','1.5','$2.56','Tablas','Roll','CS',3,'$8.76','METAL ALUMINUM ELBOWS'),                           
                            (2,'Homedepo','3.5','CS','2.5','$2.56','Martillos','Roll','CS',3,'$8.76','METAL ALUMINUM ELBOWS'),
							(3,'Homedepo','2.5','CS','3.5','$2.56','Cascos','Roll','CS',3,'$8.76','METAL ALUMINUM ELBOWS'),
							(4,'Homedepo','2.0','CS','3.5','$2.56','Palas','Roll','CS',3,'$8.76','METAL ALUMINUM ELBOWS')

use VRT_

create proc sp_Update_Materials

@IdMaterials int, 
@Vendor varchar(25), 
@MSize varchar(10), 
@MType varchar(10), 
@MThickness varchar(10), 
@MPrize varchar(15), 
@MDesc varchar(20), 
@Class varchar(20),
@ElbowType varchar(10), 
@ElbowThickness int, 
@ElbowPrize varchar(15),
@ElbowDesc  varchar(40)

as

update materials set Vendor=@Vendor, MSize=@MSize, MType=@MType, 
		MThickness=@MThickness, MPrize=@MPrize, MDesc=@MDesc, 
		Class=@Class, ElbowType=@ElbowType, ElbowThickness=@ElbowThickness, 
		ElbowPrize=@ElbowPrize, ElbowDesc=@ElbowDesc where IdMaterials= @IdMaterials

go

drop proc sp_Update_Materials