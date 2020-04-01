

create table materials(
idMaterial varchar(36) primary key not null,
idVendor varchar(36), 
idRenta varchar(36),
nombre varchar(60)
)

alter table materials  
add constraint fk_idVendor_materials
foreign key (idVendor) references vendor(idVendor)

alter table materials 
add constraint fk_idRenta_materials
foreign key (idRenta) references renta(idRenta)

create table DetallesMaterials(
idDetalleMaterials varchar(36) primary key not null, 
idMaterial varchar(36), 
idRecursosMaterials varchar(36),
idUnidadM varchar(36),
idPrecio varchar(36), 
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
								 
create table RecursosMateriales(
idRecursosMaterials varchar(36) primary key not null, 
nombre varchar(200), 
descrioción text
)

create table renta(
idRenta varchar(36) primary key not null, 
idPrecio varchar(36), 
idHerramienta varchar(36),
idMaterial varchar(36), 
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
idPrecio varchar(36) primary key not null, 
PrecioCompra float, 
PrecioRenta float, 
PrecioVenta float
)

create table herramientas(
idHerramientas varchar(36) primary key not null, 
idVendor varchar(36), 
idRenta varchar(36), 
nombre varchar(60)
)

alter table herramientas 
add constraint fk_idVendor_herramientas
foreign key (idVendor) references vendor(idVendor)

alter table herramientas 
add constraint fk_idRenta_herramientas
foreign key (idRenta) references renta(idRenta)

create table vendor(
idVendor varchar(36) primary key not null, 
idTipoVendor varchar(36),
nombre varchar(200), 
descripcion text
)

alter table vendor 
add constraint fk_idTipoVendor_vendor
foreign key (idTipoVendor) references tipoVendor(idTipoVendor)

create table tipoVendor(
idTipoVendor varchar(36) primary key not null, 
tipo varchar(60), 
descripcion text, 
estatus char
)

create table unidadMedida(
idUnidadM varchar(36) primary key not null, 
nombre varchar(60), 
sigla char(5)
)

create table DetallesHerramientas(
idDetallesHerramientas varchar(36) primary key not null, 
idHerramientas varchar(36), 
idRecursosMaterials varchar(36),
idUnidadM varchar(36), 
idPrecio varchar(36),
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
