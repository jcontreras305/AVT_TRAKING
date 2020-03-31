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
