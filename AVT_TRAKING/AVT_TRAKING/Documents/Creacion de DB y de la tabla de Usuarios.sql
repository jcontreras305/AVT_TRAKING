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
select*from users
select idUsers from users where nameUser like 'admin'
--##########################################################################
--######################  TABLE EMPLOYEES ##################################
--##########################################################################


create table employees(
IdEmployee int not null primary key, 
jobNumber int, 
SubJob int, 
employeeNumber int, 
Firstname varchar(30), 
lastname varchar(20), 
middleName varchar(20),
title varchar(50), 
NSnumber varchar(20),
Address1 varchar(25),
city varchar(20),
postalCode int, 
HoomePhone varchar(13),
PayRateOT varchar(10), 
PayRate3 varchar(10), 
PayRate varchar(10), 
Activo varchar(10), 
SAPNumber int,
PerDiem varchar(10), 
Craft varchar(10),
Notes varchar(200),
)

--##########################################################################
--######################  TABLE CLIENTS ####################################
--##########################################################################

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

--##########################################################################
--######################  TABLE MATERIALS ##################################
--##########################################################################

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



