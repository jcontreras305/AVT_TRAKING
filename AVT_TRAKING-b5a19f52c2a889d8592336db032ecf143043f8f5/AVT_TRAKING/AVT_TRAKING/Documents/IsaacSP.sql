--##############################################################################################
--################## PROCEDIMINETO ALMACENADO PARA INSERTAR UN EMPLEADO ########################
--##############################################################################################

--^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^
--^^^^^^^^^^^ estructura de un store procedure con transaction ^^^^^^^^^^^^^^^
--^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^^

--create proc sp_[nombreDelSP] --asi se declara un procedimieto se puede modificar con alter proc [nombreDelSP] y todo el codigo nuevo o eliminar con drop proc [nombreDelSP]
--	*(1)
--as 
--  *(2)
--begin 
--  *(3)
--end

----(1) en este apartado se reciven los datos como variables, es algo asi como una funcioncion o metodo en cualquier otro lenguaje.Nota se deben enviar acorde al orden escrito
--@nombre varchar(100), --cuidado con la coma solo se utiliza si hay mas de dos datos a recibir
--@fechar date

----(2) en el siguiente apartado se declaran variables que no se reciben, y se hace con el comando "declare"
--declare @error int  --qui no es enecesario utilizar coma solo utilizar un renglon nuevo

----(3) en el tercer apartado es el cuerpo del SP por ende de estar entre el BEGIN y el END del SP, Aqui pordemos iniciar con la transaccion si asi lo deseamos. NOTA "tran" es el
----el nombre por defecto del transaction puede ser otro. Si en caso de error tenemos que evitar que llegue a la linea de commit con el comando goto y saltando una parate de codigo
----ya que esta confirma que se realicen los cabios
--begin tran 
----	*(5)
--   goto solveproblem
--commit tran
--solveproblem:
--   rollback

----(5) el try es una erramienta que prebiene error o que el programa sea interrumpido por error de logica o error de capa 8 (usuario), en este caso lo usarmos en seguida del tran
----para encontrar errores de ejecucion y que no se detenga nuestro  programa
--begin try 
	
--end try
--begin catch
----    *(6)
--end catch

----(6) aqui podemos utilizar el "goto" para saltar el commit tran 



--create proc sp_insert_Employee
--	--general
--	@numberEmploye int, 
--	@firstName varchar(30),
--	@lastName varchar(25),
--	@middleName varchar(25),
--	@socialNumber varchar(14),
--	@SAPNumber int,
--	@photo image,
--	@estatus char(1),
--	--contact
--	@phoneNumber1 varchar(13),
--	@phoneNumber2 varchar(13),
--	@email varchar(50),
--	--address
--	@avenue varchar(80),
--	@number int,
--	@city varchar(20), 
--	@providence varchar(20),
--	@postalCode int,
--	--pay
--	@payRate1 float,
--	@payRate2 float, 
--	@payRate3 float
--as 
--declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
--declare @idEmployee varchar(36) 
--declare @idContact varchar(36)
--declare @idHomeAdress varchar(36)
--declare @idPayRate varchar(36)
--begin
--	begin tran --inicio tran
--		begin try --inicio try
--			--if @phoneNumber1 <> '' or @email<> '' begin -- si existe un telefono o un correo entra 
--				set @idContact = NEWID() 
--				insert into contact values(@idContact,@phoneNumber1,@phoneNumber2,@email)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end  -- si existe un error en al insertar solo vamos a solveproblem y nos evitamos lo demas
--			--end
--			--if @avenue <> '' begin -- solo se necesita saber si la calle tiene algo 
--				set @idHomeAdress = NEWID()
--				insert into HomeAddress values (@idHomeAdress , @avenue , @number , @city , @providence , @postalCode)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
				
--			--end
--			--if @payRate1 <> '' begin
--				set @idPayRate = NEWID()
--				insert into payRate values (@idPayRate,@payRate1,@payRate2 ,@payRate3)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			--end
--			--if @firstName <> '' or @numberEmploye > 0 begin	
--				set @idEmployee = NEWID()
--				insert into employees values (@idEmployee , @numberEmploye , @firstName , @lastName , @middleName, @socialNumber , @SAPNumber, @photo , @idHomeAdress , @idContact , @idPayRate ,@estatus)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			--end
--		end try	
--		begin catch
--			goto solveproblem -- en caso de error capturado en el catch no vamos a solveproblem y evitamos en commit
--		end catch
--	commit tran 
--	solveproblem:
--	if @error <> 0
--	begin 
--		rollback tran -- el rollback es para deshacer todos lo cambios hechos anteriormente
--	end
--end
--go

select * from employees where  numberEmploye  = 305 and firstName = 'isaac'

--create proc sp_Insert_Cient 
--	@ClientID int,
--	@FirstName varchar (30),
--	@MiddleName varchar (30),
--	@LastName varchar (30),
--	@CompanyName varchar (50),
--	@Status char(1),
--	--Contact
--	@phoneNumer1 varchar(13),
--	@phoneNumer2 varchar(13),
--	@email varchar(50),
--	--Addres
--	@avenue varchar(80),
--	@number int,
--	@city varchar (20),
--	@providence varchar (20),
--	@postalcode int
--as
--declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
--declare @idClient varchar(36) 
--declare @idContact varchar(36)
--declare @idHomeAdress varchar(36)
--begin 
--	begin tran 
--		begin try
--			--se inserta un contacto
			
--				set @idContact = NEWID() 
--				insert into contact values(@idContact,@phoneNumer1,@phoneNumer2,@email)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			
--				set @idHomeAdress = NEWID()
--				insert into HomeAddress values (@idHomeAdress , @avenue , @number , @city , @providence , @postalCode)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			
--				set @idClient = NEWID()
--				insert into clients values (@idClient , @ClientID, @FirstName, @MiddleName, @LastName , @CompanyName, @idContact , @idHomeAdress ,@Status)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			
--		end try
--		begin catch
--			goto solveproblem
--		end catch
--	commit tran
--	solveproblem:
--	if @error <> 0
--	begin 
--		rollback tran 
--	end
--end
--go

select cl.idClient,cl.numberClient,cl.firstName,cl.middleName,cl.lastName,cl.companyName,cl.estatus,ct.idContact,ct.phoneNumber1, ct.phoneNumber2,ct.email,ha.idHomeAdress, ha.avenue ,ha.number, ha.city ,ha.providence,ha.postalCode from
clients as cl 
left join contact as ct on cl.idContact = ct.idContact
left join HomeAddress as ha on cl.idHomeAddress = ha.idHomeAdress
where cl.numberClient = 1 
or cl.firstName like ''
or cl.lastName like ''
or ct.companyName like ''
or ha.city like ''


--create proc sp_Update_Client
--	@idCL varchar(36),
--	@ClientID int,
--	@FirstName varchar (30),
--	@MiddleName varchar (30),
--	@LastName varchar (30),
--	@CompanyName varchar (50),
--	@Status char(1),
--	--Contact
--	@idContact varchar(36),
--	@phoneNumer1 varchar(13),
--	@phoneNumer2 varchar(13),
--	@email varchar(50),
--	--Addres
--	@idAddres varchar(36),
--	@avenue varchar(80),
--	@number int,
--	@city varchar (20),
--	@providence varchar (20),
--	@postalcode int
--as
--declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
--begin 
--	begin tran 
--		begin try
--			--se inserta un contacto

--				update contact set phoneNumber1= @phoneNumer1 , phoneNumber2=@phoneNumer2 ,email = @email where idContact = @idContact
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
--				update HomeAddress set avenue= @avenue, number = number , city=@city , providence =@providence, postalCode = @postalcode where idHomeAdress = @idAddres
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
--				update  clients set firstName= @FirstName,middleName= @MiddleName,lastName= @LastName ,companyName=@CompanyName,estatus = @Status where idClient = @idCL
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--		end try
--		begin catch
--			goto solveproblem
--		end catch
--	commit tran
--	solveproblem:
--	if @error <> 0
--	begin 
--		rollback tran 
--	end
--end
--go


--#######################################################################################################################
--########### PROCEDURE OF MATERIALS ####################################################################################
--#######################################################################################################################


--create procedure sp_insert_Material
--@nombre varchar(50),
--@numero int,
--@idVendor varchar(36),
--@status char(1),
--@msg varchar(100) out
--as
--declare @idMaterial varchar(36)
--declare @idDM varchar(36)
--declare @error int
--begin
--	begin tran
--		begin try	 
--			set @idMaterial = NEWID()
--			set @idDM = NEWID()
--			if not @nombre = '' and not @idVendor = ''
--			begin 
--				insert into material values (@idMaterial,@numero,@nombre,@status)
--				insert into detalleMaterial values (@idDM,'','','',0.0,'',0.0,@idMaterial,@idVendor)
--				insert into existences values (@idDM , 0.0)
--			end
--			else 
--			begin 
--				set @error = 1
--				goto solveProblem
--			end
--		end try
--		begin catch
--			goto solveProblem
--		end catch
--	commit tran
--	solveProblem:
--	if @error <> 0 
--	begin 
--		rollback tran
--		set @msg = concat('Is problably that the Material ',@nombre,' have been inserted, or try to changue the Vendor')
--	end  
--end
--go




--create proc sp_actualizaMaterial
--@idMaterial varchar(36),
--@nombreN varchar(50),
--@numeroN int,
--@idVendorN varchar(36),
--@statusN char(1),
----datos viejos
--@idVendorV varchar(36),
--@msg varchar(100) out
--as 
--declare @vendor1 varchar(36)
--declare @vendor2 varchar(36)
--declare @error int
--begin
--	begin tran 
--		begin try 
--			set @error = 0
--			if @idVendorN = @idVendorV
--			begin --solo cambian los datos de material 
--				update material set name = @nombreN , estatus = @statusN where idMaterial = @idMaterial 
--				set @msg = 'Successful.'
--			end
--			else --Cambio de Vendedor
--			begin
--				set @Vendor2 = (select  top 1 dm.idVendor from material as ma right join detalleMaterial as dm  on ma.idMaterial = dm.idMaterial where ma.name = @nombreN) 
--				if @vendor2 = @idVendorN begin
--					set @msg = 'Rigth now exists a material whit the same Vendor.'
--					set @error = 1
--				end
--				else begin
--				update detalleMaterial set idVendor = @idVendorN where idMaterial = @idMaterial and idVendor = @idVendorV
--				update material set name = @nombreN , estatus = @statusN where idMaterial = @idMaterial 
--				set @msg = 'Successful.'
--				end
--			end
--		end try
--		begin catch
--			goto solveproblem
--		end catch
--	commit tran 
--	solveproblem:
--	if @error <> 0 
--	begin 
--		rollback tran
--	end 
--end

--#######################################################################################################################
--########### PROCEDURE OF VENDOR ####################################################################################
--#######################################################################################################################


--create procedure sp_insert_Vendor
--@nombre varchar(50),
--@numero int,
--@description varchar(80),
--@status char(1),
--@msg varchar(100) output
--as
--declare @idVendor varchar(36)
--declare @error int
--begin
--	begin tran
--		begin try	 
--			set @idVendor = NEWID()
--			if (select COUNT(*) from vendor where exists (select name from vendor where name like @nombre or numberVendor = @numero))=0
--			begin
--				insert into vendor values (@idVendor,@numero,@nombre,@description,@status)
--				set @msg = 'Successful'
--			end 
--			else 
--			begin 
--				set @error = 1
--				goto solveProblem
--			end
--		end try
--		begin catch
--			goto solveProblem
--		end catch
--	commit tran
--	solveProblem:
--	if @error <> 0 
--	begin 
--		rollback tran
--		set @msg = CONCAT('Is probably that the Vendor ',@nombre,' have been registrated.')
--	end  
--end
--go



--#############################################################################################################################
--############## POR FAVOR EJECUTA ESTE COMANDO ES PARA RESOLVER UN PROBLEMA CON ESTE PORCEDIMIENTO ###########################
--##### RECUERDA QUE ES ctrl+k,ctrl+U PARA DESCOMENTAR Y ctrl+k,ctrl+c  PATA COMENTAR AL TERMINAR VUELVE A COMNETAR ###########
--#############################################################################################################################
--ALTER procedure [dbo].[sp_insert_Material]
--@nombre varchar(50),
--@numero int,
--@idVendor varchar(36),
--@status char(1),
--@msg varchar(100) out
--as
--declare @idMaterial varchar(36)
--declare @idDM varchar(36)
--declare @error int
--begin
--	begin tran
--		begin try	 
--			set @idMaterial = NEWID()
--			set @idDM = NEWID()
--			if not @nombre = '' and not @idVendor = ''
--			begin 
--				insert into material values (@idMaterial,@numero,@nombre,@status)
--				insert into detalleMaterial values (@idDM,'','','',0.0,'',0.0,@idMaterial,@idVendor)
--				insert into existences values (@idDM , 0.0)
--				set @msg= 'Successful'
--			end
--			else 
--			begin 
--				set @error = 1
--				goto solveProblem
--			end
--		end try
--		begin catch
--			goto solveProblem
--		end catch
--	commit tran
--	solveProblem:
--	if @error <> 0 
--	begin 
--		rollback tran
--		set @msg = concat('Is problably that the Material ',@nombre,' have been inserted, or try to changue the Vendor')
--	end  
--end
--go

--#############################################################################################################################
--############## POR FAVOR EJECUTA ESTE COMANDO ES PARA PODER INSERTAR LOS MATERIALES DE FORMA CONCECUTIVA  CON EL EXCEL ######
--##### RECUERDA QUE ES ctrl+k,ctrl+U PARA DESCOMENTAR Y ctrl+k,ctrl+c  PATA COMENTAR AL TERMINAR VUELVE A COMNETAR ###########
--#############################################################################################################################

--create procedure [dbo].[sp_insert_Material_Excel]
--@nombre varchar(50),
--@numero int,
--@idVendor int,
--@status char(1),
--@resourceMaterial varchar(50),
--@unitMesurement varchar(20),
--@type varchar(30),
--@price float,
--@description varchar(100),
--@size float
--as
--declare @idMaterial varchar(36)
--declare @idDM varchar(36)
--declare @error int
--begin
--	begin tran
--		begin try	 
--			set @idMaterial = NEWID()
--			set @idDM = NEWID()
--			if not @nombre = '' and not @idVendor = '' and (select count(*) from material where number =@numero) =0
--			begin 
--				insert into material values (@idMaterial,@numero,@nombre,@status)
--				insert into detalleMaterial values (@idDM,@resourceMaterial,@unitMesurement,@type,@price,@description,@size,@idMaterial, (select idVendor from vendor where numberVendor = @idVendor))
--				insert into existences values (@idDM , 0.0)
--			end
--			else 
--			begin 
--				set @error = 1
--				goto solveProblem
--			end
--		end try
--		begin catch
--			goto solveProblem
--		end catch
--	commit tran
--	solveProblem:
--	if @error <> 0 
--	begin 
--		rollback tran
--	end  
--end
--go

