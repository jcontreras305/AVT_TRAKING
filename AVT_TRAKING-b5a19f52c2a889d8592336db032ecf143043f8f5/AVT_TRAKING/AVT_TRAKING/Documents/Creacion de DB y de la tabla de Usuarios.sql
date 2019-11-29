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
Email varchar(50),
JobNumber int, 
SubJob int, 
CostCode varchar(25), 
WorkLumpsum varchar(10) 
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
idMaterial int primary key not null identity(1,1),
idVendor int, 
idRenta int,
nombre varchar(60)
)

alter table materials  
add constraint fk_idVendor_materials
foreign key (idVendor) references vendor(idVendor)

alter table materials 
add constraint fk_idRenta_materials
foreign key (idRenta) references renta(idRenta)

create table DetallesMaterials(
idDetalleMaterials INT primary key not null identity(1,1), 
idMaterial int, 
idRecursosMaterials int,
idUnidadM int, 
MSize float, 
MType varchar(50), 
MTyckness float,
Mprice float,
Descripcion text,
cantidad float
)

alter table DetallesMaterials
add constraint fk_idMaterial_DetallesMaterials
foreign key (idMaterial) references materials(idMaterial)

alter table DetallesMaterials
add constraint fk_idRecursosMaterials_DetallesMaterials
foreign key (idRecursosMaterials) references RecursosMateriales(idRecursosMaterials)

alter table DetallesMaterials
add constraint fk_idUnidadM_DetallesMaterials
foreign key (idUnidadM) references unidadMedida(idUnidadM) 
								 
create table RecursosMateriales(
idRecursosMaterials INT primary key not null identity(1,1), 
nombre varchar(200), 
descrioción text
)

create table renta(
idRenta INT PRIMARY key not null identity(1,1), 
idPrecio int, 
idHerramienta int,
idMaterial int, 
horas float, 
CantidadRentadaH float, 
CantidadRentadaM float
)

alter table renta 
add constraint fk_idPrecio_renta
foreign key (idPrecio) references precio(idPrecio)

alter table renta 
add constraint fk_idHerramientas_renta
foreign key (idHerramienta) references herramientas(idHerramientas)

alter table renta 
add constraint fk_idMaterial_renta
foreign key (idMaterial) references materials(idMaterial)

create table precio(
idPrecio INT primary key not null identity(1,1), 
PrecioCompra float, 
PrecioRenta float, 
PrecioVenta float
)

create table herramientas(
idHerramientas int primary key not null identity(1,1), 
idVendor int, 
idRenta int, 
nombre varchar(60)
)

alter table herramientas 
add constraint fk_idVendor_herramientas
foreign key (idVendor) references vendor(idVendor)

alter table herramientas 
add constraint fk_idRenta_herramientas
foreign key (idRenta) references renta(idRenta)

create table vendor(
idVendor int primary key not null identity(1,1), 
idTipoVendor int,
nombre varchar(200), 
descripcion text
)

alter table vendor 
add constraint fk_idTipoVendor_vendor
foreign key (idTipoVendor) references tipoVendor(idTipoVendor)

create table tipoVendor(
idTipoVendor int not null primary key identity(1,1), 
tipo varchar(60), 
descripcion text, 
estatus char
)

create table unidadMedida(
idUnidadM int primary key not null identity(1,1), 
nombre varchar(60), 
sigla char(5)
)


--############################################################################
--############# Tables WorkCodes #############################################
--############################################################################

create table WorkCode(
WorkCodeID int not null primary key, 
JobNumber int, 
SubJob int, 
Craft varchar(10),
WorkCode varchar(10),
Classification varchar(10),
BillingRateST varchar(15), 
BillingRateOT varchar(15), 
BillingRate3 varchar(15),
ClassDescription varchar(25)
)

insert into WorkCode values (1, 234, 456,'110sc','110sc','LMS','$30','$47.77','$65.00','Cementera')
