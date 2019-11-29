use VRT_TRAKING

create proc InsertaMaterial
	--materials
	@nombreM varchar(60), 
	--DetalleMaterials
	@MSize float,
	@MType varchar(50),
	@MTyckness float,
	@Mprice float,
	@Descripcion text,
	@cantidad float, 
	--recursos materiales
	@nombreRM varchar(200),
	@descripcionRM text,
	--UidadDeMedida
	@nombreUM varchar(60), 
	@sigla char(5),
	--Renta
	@horas float, 
	@CantidadRentadaH float, 
	@CantidadRentadaM float,
	--Vendor
	@nombreV varchar(200), 
	@descripcionV text,
	--TipoVendor
	@tipo varchar(60), 
	@descripcionTV text, 
	@estatus char,
	--Precio
	@PrecioCompra float, 
	@PrecioRenta float, 
	@PrecioVenta float,
	--herramientas
	@nombreH varchar(60)

as
declare @error int
declare @idMaterial int
declare @idDetalleMaterials int
declare @idRecursosMaterials int
declare @idUnidadM int
declare @idVendor int
declare @idRenta int
declare @idTipoVendor int
declare @idPrecio int
declare @idHerramientas int

begin
	begin tran
		begin try
			if @MSize <> '' begin
				set @idRecursosMaterials = @@IDENTITY
				insert into RecursosMateriales values (@nombreRM, @descripcionRM)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			end

			if	@nombreUM <> '' begin
				set @idUnidadM = @@IDENTITY
				insert into unidadMedida values(@nombreUM, @sigla)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			end
			--Tabla precio
			if @PrecioCompra <>'' begin
				set @idPrecio = @@IDENTITY
				insert into precio values (@PrecioCompra,@PrecioRenta,@PrecioVenta)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			end
			--Tabla Tipo Vendor
			if @tipo <>'' begin
				set @idTipoVendor = @@IDENTITY
				insert into tipoVendor values(@tipo,@descripcionTV,@estatus)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			end
			--Tabla Vendor
			if @nombreV <>'' begin
				set @idVendor= @@IDENTITY
				insert into vendor values(@idTipoVendor,@nombreV,@descripcionV)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			end
			--Tabla Renta
			if @horas <> '' begin
				set @idRenta = @@IDENTITY
				insert into renta values(@idPrecio,@idHerramientas,@idMaterial,@horas,@CantidadRentadaH,@CantidadRentadaM)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			end
			--Tabla Herramientas
			if @nombreH <>'' begin
				set @idHerramientas =@@IDENTITY
				insert into herramientas values(@idVendor,@idRenta,@nombreH)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			end
			--Tabla Materiales
			if @nombreM <> '' begin
				set @idMaterial = @@IDENTITY
				insert into materials values(@idVendor,@idRenta,@nombreM)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			end
			--Tabla Detalles Materiales
			if @MSize <> '' begin	
				set @idDetalleMaterials = @@IDENTITY
				insert into DetallesMaterials values(@idMaterial,@idRecursosMaterials,@idUnidadM,@MSize,@MType,@MTyckness,@Mprice,@Descripcion,@cantidad)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			end
		end try
		begin catch
			goto solveproblem
		end catch
	commit tran
	solveproblem:
	if @error <> 0

	begin 
		rollback tran
	end
end
go
