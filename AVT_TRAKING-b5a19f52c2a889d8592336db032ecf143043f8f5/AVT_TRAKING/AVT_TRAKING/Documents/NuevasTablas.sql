

use VRT_TRAKING

---###############Creación de la tabla Materiales##############---
create table materials(
idMaterial int IDENTITY(1,1) PRIMARY KEY not null,
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


--#############Creación de la tabla Detalles de los materiales ##############--
create table DetallesMaterials(
idDetalleMaterials int IDENTITY(1,1) PRIMARY KEY not null, 
idMaterial int, 
idRecursosMaterials int,
idUnidadM int,
idPrecio int, 
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

alter table DetallesMaterials
add constraint fk_idPrecio_DetallesMaterials
foreign key (idPrecio) references precio(idPrecio)

--######### Creación de tabla de recursos materiales #########--								 
create table RecursosMateriales(
idRecursosMaterials int IDENTITY(1,1) PRIMARY KEY not null, 
nombre varchar(200), 
descrioción text
)
--########### Creación de tabla Renta #################--
create table renta(
idRenta int IDENTITY(1,1) PRIMARY KEY not null, 
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
idPrecio int IDENTITY(1,1) PRIMARY KEY not null, 
PrecioCompra float, 
PrecioRenta float, 
PrecioVenta float
)

--###################Creación de tabla Herramientas################--
create table herramientas(
idHerramientas int IDENTITY(1,1) PRIMARY KEY not null, 
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


--#############Creación de tabla Vendor ############--
create table vendor(
idVendor int IDENTITY(1,1) PRIMARY KEY not null, 
idTipoVendor int,
nombre varchar(200), 
descripcion text
)


alter table vendor 
add constraint fk_idTipoVendor_vendor
foreign key (idTipoVendor) references tipoVendor(idTipoVendor)

--################ Creación de tabla Tipo Vendor ###########--
create table tipoVendor(
idTipoVendor int IDENTITY(1,1) PRIMARY KEY not null, 
tipo varchar(60), 
descripcion text, 
estatus char
)


--########## Creación de tabla unidad de Medida #########--
create table unidadMedida(
idUnidadM int IDENTITY(1,1) PRIMARY KEY not null, 
nombre varchar(60), 
sigla char(5)
)

--######### Creación de tabla detalles de herramientas ##############--
create table DetallesHerramientas(
idDetallesHerramientas int IDENTITY(1,1) PRIMARY KEY not null, 
idHerramientas int, 
idRecursosMaterials int,
idUnidadM int, 
idPrecio int,
MSize float, 
HType varchar(50), 
HTyckness float,
Descripcion text,
cantidad float
)

alter table DetallesHerramientas
add constraint fk_idHerraminetas_DetallesHerraminetas
foreign key (idHerramientas) references herramientas(idHerramientas)

alter table DetallesHerramientas
add constraint fk_idRecursosMaterials_DetallesHerramientas
foreign key (idRecursosMaterials) references RecursosMateriales(idRecursosMaterials) 

alter table DetallesHerramientas
add constraint fk_idUnidadM_DetallesHerramientas
foreign key (idUnidadM) references unidadMedida(idUnidadM)

alter table DetallesHerramientas
add constraint fk_idPrecio_DetallesHerramientas
foreign key (idPrecio) references precio(idPrecio)
