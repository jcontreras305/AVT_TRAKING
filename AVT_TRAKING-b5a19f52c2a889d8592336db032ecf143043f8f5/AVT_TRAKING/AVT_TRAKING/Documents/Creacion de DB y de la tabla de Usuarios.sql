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

--create table employees(
--	idEmployee varchar(36) primary key not null,
--	numberEmploye int not null,
--	firstName varchar(30),
--	lastName varchar(25),
--	middleName varchar(25),
--	socialNumber varchar(14),
--	SAPNumber int,
--	photo image,
--	idHomeAdress varchar(36),
--	idContact varchar(36),
--	idPayRate varchar(36),
--	estatus char(1)
--)
--go

--alter table employees 
--add constraint fk_idContact_EM foreign key (idContact)
--references contact (idContact)

--alter table contact 
--go
--ejecutar si ya se tiene la tabla fuerror de escribir email
--EXECUTE sp_rename 'conact', 'emial', 'email';


--create table contact(
--	idContact varchar(36) primary key not null,
--	phoneNumber1 varchar(13),
--	phoneNumber2 varchar(13),
--	email varchar(50)
--)

--create table HomeAddress (
--	idHomeAdress varchar(36) primary key not null,
--	avenue varchar(80),
--	number int,
--	city varchar(20), 
--	providence varchar(20),
--	postalCode int
--)

--create table payRate(
--	idPayRate varchar(36) primary key not null ,
--	payRate1 float,
--	payRate2 float, 
--	payRate3 float
--)

--alter table employees 
--add constraint fk_idPayRate_employees
--foreign key (idPayRate) references payRate(idPayRate)

--alter table employees 
--add constraint fk_idContact_employees
--foreign key (idContact) references contact(idContact)

----alter table employees drop constraint fk_idContact_employees

--alter table employees 
--add constraint fk_idHomeAdress_employees
--foreign key (idHomeAdress) references HomeAddress(idHomeAdress)




--############################################################################
--############# Tables clients ###############################################
--############################################################################
--select * from contact
--select * from HomeAddress

--SELECT * from clients
--drop table clients

--create table clients(
--idClient varchar (36) not null primary key,
--numberClient int not null,
--firstName varchar(30), 
--middleName Varchar(30),
--lastName varchar(30),  
--companyName varchar (50),
--idContact varchar(36),
--idHomeAddress varchar(36),
--estatus char(1)
--)

--alter table clients
--add constraint fk_idContact_CL foreign key (idContact)
--references contact(idContact)
--go

--alter table clients
--add constraint fk_idHomeAddres_CL foreign key (idHomeAddress)
--references HomeAddress(idHomeAdress)
--go


--insert into clients values (NEWID(), 1, 'Jorge','Isaac','Contreras Zamora',null,null)
--select * from clients
--Avenue varchar(30),
--City varchar(30),

--StateProvince varchar(30), 
--PostalCode int, 
--ContactTitle varchar(20), 
--PhoneNumber varchar(15),
--Email varchar(50),
--JobNumber int, 
--SubJob int, 
--CostCode varchar(25),
--insert into clients values(newid(),5555,'Cementera','Calle mirador','Jacona','Michoacan',59890,'Andres','Reyes','Supervisor',
	--						'815-955-9982',8847,200,'240000000000000','T&M'),
	--						(5556,'Cementera','Calle mirador','Zamora','Michoacan',59890,'Andres','Reyes','Supervisor',
	--						'815-955-9982',8848,201,'240000000000001','T&M'),
	--						(5557,'Cementera','Calle mirador','Cotija','Michoacan',59890,'Andres','Reyes','Supervisor',
	--						'815-955-9982',8848,202,'240000000000002','T&M'),
	--						(5558,'Cementera','Calle mirador','Los Reyes','Michoacan',59890,'Andres','Reyes','Supervisor',
	--						'815-955-9982',8850,203,'240000000000003','T&M')






--############################################################################
--############# Tables vendor ################################################
--############################################################################

--create table vendor (
--idVendor varchar (36) primary key not null,
--numberVendor int not null,
--name varchar (50),
--descriptions varchar(80),
--estatus char(1)
--)
--go
----############################################################################
----############# Table materials ##############################################
----############################################################################

--create table material(
--	idMaterial varchar(36) primary key not null,
--	number int not null,
--	name varchar(50), 
--	estatus char (1) 
--)
--go



----####################################################################################################################################################################################################################################
----############# Table detalleMaterial ##################################################################### CAMBIOS EN LAS TABLAS REALCIONADAS CON MATERIALES ########################################################################
----####################################################################################################################################################################################################################################

--create table detalleMaterial(
--	idDM varchar (36) primary key not null,
--	resourceMaterial varchar(50),
--	unitMeasurement varchar(20),
--	type varchar(30),
--	price float,
--	description varchar(100),
--	size float,
--	idMaterial varchar(36),
--	idVendor varchar(36), 
--  partNum  varchar(15)
--)
--go

--alter table detalleMaterial 
--add constraint fk_idMaterial_DM foreign key (idMaterial)
--references material (idMaterial)
--go
--alter table detalleMaterial
--add constraint fk_idVendor_Dm foreign key (idVendor)
--references vendor (idVendor)
--go
----############################################################################
----############# Table existencias ############################################
----############################################################################

--create table existences(
--	idDM varchar(36) primary key not null,
--	quantity float not null 
--)
--go

----aqui se realiza un relacion entre el producto y las exitencias sabiendo que solo ese producto sera el mismo 
----debido a que la clave primaria del producto es la clave princiapal de existencias ya que solo se podra alterar
----con con inserciones o bajas es por eso que se realiza una tabla diferente.

--alter table existences 
--add constraint fk_idDM_existenece foreign key (idDM)
--references DetalleMaterial (idDM)
--go

----############################################################################
----############# Table Material Orders ########################################
----############################################################################



--create table materialOrder (
--	idOrder varchar (36) primary key not null,
--	quantity float,
--	price float,
--	fecha date,
--	idMaterial varchar(36)
--)

--alter table MaterialOrder 
--add constraint fk_idMaterial_MaterialOrder foreign key (idMaterial)
--references material (idMaterial)
--go







----###########################################################################################################################
----######## TABLES FOR WORK CODES, JOBS AND EXPENCES CREATIO DATE 1/11/2020 ##################################################
----######## REMEMBER TO SELECT EVERYTHING AND DISCOMMENT, USE (Ctrl+k,Ctrl+U) AND COMMNET AGAIN, USE (Ctrl+k,Ctrl+C) #########
----###########################################################################################################################

--create table workCode (
--	idWorkCode int primary key  not null,
--	name varchar(50),
--	billingRate1 float,
--	billingRateOT float,
--	billingRate3 float,
--	EQExq1 varchar(50),
--	EQExq2 varchar(50),	 
--)
--go

--create table hoursWorked (
--	idHorsWorked varchar(36) primary key not null,
--	hours1 float,
--	hoursOT float,
--	dateWorked date,
--	idEmployee varchar(36),
--	idWorkCode int
--)
--go

--alter table hoursWorked
--add constraint fk_idWorkCode_hoursWorked
--foreign key (idWorkCode) references workCode(idWorkCode)
--go

--create table workOrder (
--	idWorkOrder varchar(36) primary key not null,
--	task char(6),
--	contactNumer char(13),
--	contactTitle varchar(40),
--	contactNum bigint,
--	idHomeAddress varchar(36),
--	idClient varchar(36)
--)
--go
----select * from HomeAddress
--alter table workOrder
--add constraint fk_idHomeAddress_WO
--foreign key (idHomeAddress) references HomeAddress(idHomeAdress)
--go
----select * from clients
--alter table workOrder
--add constraint fk_idClient_WO
--foreign key (idClient) references clients(idClient) 
--go

--create table job (
--	idJob int primary key not null,
--	idEquipament varchar(30),
--	proyectManager varchar(50),
--	description varchar(100),
--	beginDate date,
--	endDate date,
--	totalBilling float,
--	complete char(1),
--	status float(1),
--	idWorkOrder varchar(36)
--)
--go

--alter table job 
--add constraint fk_WorkOrder_Job
--foreign key (idWorkOrder) references workOrder(idWorkOrder)
--go

--create table expenses (
--	idExpences varchar(36) primary key not null,
--	expenseCode varchar(20) not null,
--	description varchar(100)
--)

--create table expensesPeerJob (
--	idEJ varchar(36) primary key not null,
--	dateExpense date,
--	amount float,
--	idJob int,
--	idExpense varchar(36)
--)

--alter table expensesPeerJob
--add constraint fk_idJob_EJ
--foreign key (idJob) references job(idJob)
--go

--alter table expensesPeerJob
--add constraint fk_idExpense_EJ
--foreign key (idExpense) references expenses(idExpences)
--go


----#####################################################################################################################################
----####################este codigo es para eliminar la tabla de typeWorKCode  ####################################################################
----#####################################################################################################################################


----ESTE ES EL CODIGO PARA ELIMINAR LA CLASIFICACION DE LOS WORKCODES 
--alter table workCode 
--drop constraint fk_idTWorkCode_workCode

--alter table workCode
--drop column idTWorkCode

--drop table typeWorkCode

----YA NO SIRVE LA TABLA DE TYPEWORK CODE CON ESTE CODIGO SE ELEMINA 
--alter table workCode 
--drop constraint fk_idTWorkCode_workCode

--alter table workCode
--drop column idTWorkCode

--drop table typeWorkCode
----SE TIENEN QUE AGREGAR EL DATO DE HORAS 3
--alter table hoursWorked 
--drop constraint fk_idEmployee_hoursWorked , fk_idWorkCode_hoursWorked
--go

--drop table hoursWorked
--GO

--create table hoursWorked (
--	idHorsWorked varchar(36) primary key not null,
--	hoursST float,
--	hoursOT float,
--	hours3 float,
--	dateWorked date,
--	idEmployee varchar(36),
--	idWorkCode int
--)
--go

--alter table hoursWorked 
--add constraint fk_idEmployee_hoursWorked
--foreign key (idEmployee) references  employees(idEmployee)
--go

--alter table hoursWorked
--add constraint fk_idWorkCode_hoursWorked
--foreign key (idWorkCode) references workCode(idWorkCode) 
--go

