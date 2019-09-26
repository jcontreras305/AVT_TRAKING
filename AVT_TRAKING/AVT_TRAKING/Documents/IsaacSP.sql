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



create proc sp_insert_Employee
	--general
	@numberEmploye int, 
	@firstName varchar(30),
	@lastName varchar(25),
	@middleName varchar(25),
	@socialNumber varchar(14),
	@SAPNumber int,
	@photo image,
	@estatus char(1),
	--contact
	@phoneNumber1 varchar(13),
	@phoneNumber2 varchar(13),
	@email varchar(50),
	--address
	@avenue varchar(80),
	@number int,
	@city varchar(20), 
	@providence varchar(20),
	@postalCode int,
	--pay
	@payRate1 float,
	@payRate2 float, 
	@payRate3 float
as 
declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
declare @idEmployee varchar(36) 
declare @idContact varchar(36)
declare @idHomeAdress varchar(36)
declare @idPayRate varchar(36)
begin
	begin tran --inicio tran
		begin try --inicio try
			if @phoneNumber1 <> '' or @email<> '' begin -- si existe un telefono o un correo entra 
				set @idContact = NEWID() 
				insert into contact values(@idContact,@phoneNumber1,@phoneNumber2,@email)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end  -- si existe un error en al insertar solo vamos a solveproblem y nos evitamos lo demas
			end
			if @avenue <> '' begin -- solo se necesita saber si la calle tiene algo 
				set @idHomeAdress = NEWID()
				insert into HomeAddress values (@idHomeAdress , @avenue , @number , @city , @providence , @postalCode)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			end
			if @payRate1 <> '' begin
				set @idPayRate = NEWID()
				insert into payRate values (@idPayRate,@payRate1,@payRate2 ,@payRate3)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			end
			if @firstName <> '' or @numberEmploye > 0 begin	
				set @idEmployee = NEWID()
				insert into employees values (@idEmployee , @numberEmploye , @firstName , @lastName , @middleName, @socialNumber , @SAPNumber, @photo , @idHomeAdress , @idContact , @idPayRate ,@estatus)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			end
		end try	
		begin catch
			goto solveproblem -- en caso de error capturado en el catch no vamos a solveproblem y evitamos en commit
		end catch
	commit tran 
	solveproblem:
	if @error <> 0
	begin 
		rollback tran -- el rollback es para deshacer todos lo cambios hechos anteriormente
	end
end
go

select * from employees where  numberEmploye  = 305 and firstName = 'isaac'