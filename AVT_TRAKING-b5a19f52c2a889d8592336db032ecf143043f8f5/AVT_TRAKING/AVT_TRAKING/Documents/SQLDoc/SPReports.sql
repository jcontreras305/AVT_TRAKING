--==============================================================================================
--==============================================================================================
--===== LOS PROCEDIMIENTO SI YA ESTA INSERTADOS EN LA BASE DE DATOS SOLO DESCOMENTAR ===========
--===== EL ALTER QUE ESTA ARRIBA DE CADA PROCEDIMIENTO Y COMENTAR EL CREATE USANDO   ===========
--===== (CTRL+K)(CTRL+C) PARA COMENTAR Y (CTRL+K)(CTRL+U)                            ===========
--==============================================================================================
--==============================================================================================
--##############################################################################################
--################## SP REPORT Client Billings Re Cap By Project ###############################
--##############################################################################################
--ALTER proc [dbo].[Client_Billings_Re_Cap_By_Project]
CREATE proc [dbo].[Client_Billings_Re_Cap_By_Project]
@startdate as date, 
@finaldate as date,
@clientnum as int,
@job as bigint,
@all as bit
as 
begin

set @startdate = ISNULL(@startDate,GETDATE())
set @finaldate = ISNULL(@finaldate,GETDATE())
set @clientnum = ISNULL(@clientnum,(select top 1 numberClient from clients)) 

select T2.companyName,T2.[Work Order],T2.jobNo,T2.PO,T2.[Project Desription],
T2.[Hours Ext],T2.[Total Hours],T2.[Hours ST],T2.[Billings ST],T2.[Hours OT],T2.[Billings OT],
T2.Complete,T2.[Es-Hrs],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend],T2.Estimate from
(
	select cl.companyName,concat(wo.idWO,' ',ts.task) as 'Work Order', jb.jobNo,po.idPO as 'PO',ts.description as 'Project Desription',
    	
	ISNULL((select T1.EX from  (select sum(hours3) as 'EX' from hoursWorked as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) ,0) as 'Hours Ext',

	(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)+
	(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Total Hours',

	(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours ST',
	
	(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount' from 
			(select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
				where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate
			)as T1    
		group by T1.idWorkCode
		)as T2
	) as 'Billings ST',

	(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours OT',
	
	(select ISNULL( SUM(T2.Amount),0) as 'Billings OT' from 
		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount' from 
			(select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
				where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate
			)as T1    
		group by T1.idWorkCode
		)as T2
	) as 'Billings OT',

	ts.percentComplete as 'Complete',

	ts.estimateHours as 'Es-Hrs',

	ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
	where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0) as 'Total Expenses',
	
	ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0) as 'Total Material',
	
	(
		
			(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2)--Billing ST
			+
			(select  ISNULL( SUM(T2.Amount),0) as 'Billing OT' from 
			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2) --Billing OT
			+
			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0)--Expenses Used
			+
			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0)-- Material Used
			)
		 as 'Total Spend',

	ts.estTotalBilling as 'Estimate'
	from task as ts
	inner join workOrder as wo on wo.idAuxWO=ts.idAuxWO
	inner join projectOrder as po on po.idPO=wo.idPO and po.jobNo = wo.jobNo
	inner join job as jb on jb.jobNo=po.jobNo
	inner join clients cl on cl.idClient=jb.idClient
	where cl.numberClient=@clientnum and ((select sum(hoursST) from hoursWorked where idAux = ts.idAux)> 0 or (select sum(hoursOT)
		 from hoursWorked where idAux = ts.idAux)> 0 or (select sum(hours3)
		 from hoursWorked where idAux = ts.idAux)> 0 or (select sum(amount) 
		 from expensesUsed where idAux=ts.idAux)> 0 or (select sum(amount)
		 from materialUsed where idAux=ts.idAux)>0)
		 and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,''))
		)as T2
		where T2.[Billings ST]<>0 OR T2.[Billings OT]<>0 OR T2.[Total Expenses]<>0 OR T2.[Total Material]<>0
		order by t2.jobNo asc
end
go

--##############################################################################################
--################## SP REPORT TIME SHEETS PO ##################################################
--##############################################################################################
--ALTER proc [dbo].[select_Time_Sheet_PO]
CREATE proc [dbo].[select_Time_Sheet_PO]
	@IntialDate date,
	@FinalDate date,
	@clientnum as int,
	@job as bigint,
	@all as bit
as 
begin
	set @IntialDate = ISNULL(@IntialDate,GETDATE())
	set @FinalDate = ISNULL(@FinalDate,GETDATE())
	select * from (
	select
	distinct
		cl.numberClient,
		jb.jobNo,
		po.idPO,
		(select sum(hw1.hoursST) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and po1.jobNo = wo1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo inner join clients as cl1 on cl1.idClient = jb1.idClient where cl1.idClient = cl.idClient and po1.idPO=po.idPO and jb.jobNo = jb1.jobNo and hw1.idEmployee = em.idEmployee and SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))=SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) and hw1.dateWorked between @IntialDate and @FinalDate) as 'hoursST',
		(select sum(hw2.hoursOT) from hoursWorked as hw2 inner join workCode as wc2 on wc2.idWorkCode = hw2.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk2 on tk2.idAux = hw2.idAux inner join workOrder as wo2 on wo2.idAuxWO = tk2.idAuxWO inner join projectOrder as po2 on po2.idPO = wo2.idPO and po2.jobNo = wo2.jobNo inner join job as jb2 on jb2.jobNo = po2.jobNo inner join clients as cl2 on cl2.idClient = jb2.idClient where cl2.idClient = cl.idClient and po2.idPO=po.idPO and jb.jobNo = jb2.jobNo and hw2.idEmployee = em.idEmployee and SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))=SUBSTRING( wc2.name,1,iif(CHARINDEX('-',wc2.name)=0, len(wc2.name) ,(CHARINDEX('-',wc2.name)-1))) and hw2.dateWorked between @IntialDate and @FinalDate) as 'hoursOT',
		SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
		hw.schedule as 'Shift',
		CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee',
		em.numberEmploye as 'Emp: Number',
		em.typeEmployee as 'class'
		from hoursWorked as hw 
					inner join employees as em on hw.idEmployee = em.idEmployee
					inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
					inner join task as tk on tk.idAux = hw.idAux 
					inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
					inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
					inner join job as jb on jb.jobNo = po.jobNo
					inner join clients  as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @IntialDate and @FinalDate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,''))
		) as T1 where T1.hoursST > 0 or  T1.hoursOT>0 order by T1.idPO 
end
go

--##############################################################################################
--################## SP REPORT REPORTE TIME SHEET ###########################################
--##############################################################################################
--ALTER proc [dbo].[select_TimeSheet_Report]
CREATE proc [dbo].[select_TimeSheet_Report]
	@IntialDate date,
	@FinalDate date,
	@numclient int,
	@job bigint,
	@all bit
as 
begin
	if @IntialDate is not null and @FinalDate is not null
	begin 
			select  
		T1.jobNo,t1.idPO,t1.task,t1.equipament as 'equipment',t1.description, t1.accountNum,
		SUM(t1.hoursST) AS 'hoursST',SUM(t1.hoursOT)AS 'hoursOT',SUM(t1.hours3) AS 'hours3',t1.Code,t1.Shift,t1.expCode,t1.Complete,
		t1.hrEst,t1.Employee,t1.[Emp: Number],t1.class,  clg.companyName
		from (
			select distinct
			jb.jobNo,
			po.idPO,
			CONCAT(wo.idWO,'-',tk.task)AS 'task' ,
			tk.equipament,
			tk.description,
			tk.accountNum,
			(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hoursST',
			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hoursOT',
			(select iif(SUM(hw1.hours3 )is null,0,SUM(hw1.hours3 )) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hours3',
			SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
			hw.schedule as 'Shift', 
			tk.expCode,
			concat(tk.percentComplete,'%')  as 'Complete',
			tk.estimateHours as 'hrEst',
			CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee', 
			em.numberEmploye as 'Emp: Number' ,
			em.typeEmployee as 'class'
			from hoursWorked as hw 
			inner join employees as em on hw.idEmployee = em.idEmployee
			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
			inner join task as tk on tk.idAux = hw.idAux 
			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
			inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
			inner join job as jb on jb.jobNo = po.jobNo
			inner join clients as cl on cl.idClient=jb.idClient
			where hw.dateWorked between @IntialDate and @FinalDate and (hw.hoursST > 0 or hw.hoursOT>0 or hw.hours3>0) and cl.numberClient=@numclient and jb.jobNo like IIF(@all=1,'%%',CONCAT('',@job,''))--and em.numberEmploye = 16874
		) as T1	inner join job as jbg on jbg.jobNo = T1.jobNo inner join clients as clg on clg.idClient = jbg.idClient
		group by T1.jobNo,t1.idPO,t1.Task,t1.equipament,t1.description,t1.hoursST, t1.accountNum,t1.hoursOT,t1.hours3,t1.Code,t1.Shift,t1.expCode,t1.Complete,
		t1.hrEst,t1.Employee,t1.[Emp: Number],t1.class, clg.companyName
		order by t1.Task,t1.[Emp: Number]
end
end
go
--##############################################################################################
--################## SP REPORT ACTIVE EMPLOYEE AVERAGE #########################################
--##############################################################################################
--ALTER proc [dbo].[sp_Active_Employee_Average]
CREATE proc [dbo].[sp_Active_Employee_Average]
as
begin
	select em.lastName as 'Last Name' , CONCAT(em.firstName,' ',substring( em.middleName,1,1)) as 'First Name',CONCAT( '$',pr.payRate1)as 'Pay Rate' , 
		em.socialNumber as 'SS Number',em.numberEmploye as 'Brock Emp.',
		case when em.estatus = 'E' then 'Yes'
		else 'No' end as 'Active',
		em.SAPNumber as 'Citigo Emp.'
		from employees as em left join payRate as pr on pr.idEmployee = em.idEmployee  
		where estatus = 'E'	
end
go
--##############################################################################################
--################## SP ACTUALIZA MATERIAL #####################################################
--##############################################################################################
--ALTER proc [dbo].[sp_actualizaMaterial]
CREATE proc [dbo].[sp_ActualizaMaterial]
@idMaterial varchar(36),
@nombreN varchar(50),
@numeroN int,
@idVendorN varchar(36),
@statusN char(1),
--datos viejos
@idVendorV varchar(36),
@class varchar(20),
@msg varchar(100) out
as 
declare @vendor1 varchar(36)
declare @vendor2 varchar(36)
declare @error int
begin
	begin tran 
		begin try 
			set @error = 0
			if @idVendorN = @idVendorV
			begin --solo cambian los datos de material 
				update material set name = @nombreN , estatus = @statusN,code = iif(@class = '',NUll,@class) where idMaterial = @idMaterial 
				set @msg = 'Successful.'
			end
			else --Cambio de Vendedor
			begin
				set @Vendor2 = (select  top 1 dm.idVendor from material as ma right join detalleMaterial as dm  on ma.idMaterial = dm.idMaterial where ma.name = @nombreN) 
				if @vendor2 = @idVendorN begin
					set @msg = 'Rigth now exists a material whit the same Vendor.'
					set @error = 1
				end
				else begin
				if (select  COUNT(*) from material as ma right join detalleMaterial as dm  on ma.idMaterial = dm.idMaterial where ma.name = @nombreN)=0
				begin 
					insert into detalleMaterial values (NEWID(),'','','',0.0,'',0.0,@idMaterial,@idVendorN,'')
				end
				else
				begin
					update detalleMaterial set idVendor = @idVendorN where idMaterial = @idMaterial and idVendor = @idVendorV
				end
				update material set name = @nombreN , estatus = @statusN,code = iif(@class = '',NUll,@class) where idMaterial = @idMaterial 
				set @msg = 'Successful.'
				end
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
GO
--##############################################################################################
--################## SP REPORT ALL JOBS ########################################################
--##############################################################################################
--ALTER proc [dbo].[Sp_All_Jobs]
CREATE proc [dbo].[Sp_All_Jobs]
@startdate as date, 
@finaldate as date,
@clientnum as int
as
begin
select distinct
	jb.jobNo,
	po.idPO,
	wo.idWO,
	tk.task,
	em.SAPNumber,
	em.numberEmploye, 
	datename(dw,hw.dateWorked) as 'DAY',
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
	hw.dateWorked,
	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',

	ISNULL(((select ISNULL(SUM(hw1.hoursST),0) from hoursWorked as hw1 
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO 
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
	inner join job as jb1 on jb1.jobNo = po1.jobNo  
	where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )),0) as 'Hours ST',
	
	ISNULL(wc.billingRate1,0)AS 'billingRate1',

	ISNULL(((select ISNULL(SUM(hw1.hoursOT),0) from hoursWorked as hw1 
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO 
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
	inner join job as jb1 on jb1.jobNo = po1.jobNo  
	where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )),0) as 'Hours OT',
	
	ISNULL(wc.billingRateOT,0)as 'billingRateOT',


	ISNULL((select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo 
	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Per-Diem') ,0) as 'PerDiem' ,

	ISNULL((select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo 
	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel') ,0) as 'Travel' 
	 
	from employees as em 
		inner join hoursWorked as hw on hw.idEmployee = em.idEmployee
		inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
		inner join task as tk on tk.idAux= hw.idAux
		inner join workOrder wo on  wo.idAuxWO=tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = wo.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and not wc.name like '%6.4%'
	order by 
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
	hw.dateWorked
end
GO

--##############################################################################################
--################## SP REPORT BY JOB NUMBER ###################################################
--##############################################################################################
--ALTER proc [dbo].[Sp_By_JobNumber]
CREATE proc [dbo].[Sp_By_JobNumber]
@startdate as date, 
@finaldate as date,
@clientnum as int,
@job as bigint,
@all as bit
as
begin
select distinct
	jb.jobNo,
	po.idPO,
	wo.idWO,
	tk.task,
	em.SAPNumber,
	em.numberEmploye, 
	datename(dw,hw.dateWorked) as 'DAY',
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
	hw.dateWorked,
	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',
	
	
	ISNULL((select SUM(hw1.hoursST) from 
	hoursWorked as hw1 
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO 
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
	inner join job as jb1 on jb1.jobNo = po1.jobNo  
	where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee 
			and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO 
			and wo.idAuxWO = wo1.idAuxWO 
			and tk1.idAux = tk.idAux 
			and (SUBSTRING(wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) 
			and not wc1.name like '%6.4%'),0) 
	as 'Hours ST',
		
	ISNULL(wc.billingRate1,0)as 'billingRate1',

	ISNULL((select ISNULL(SUM(hw1.hoursOT),0) from 
	hoursWorked as hw1 
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO 
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
	inner join job as jb1 on jb1.jobNo = po1.jobNo  
	where hw1.dateWorked = hw.dateWorked 
			and em.idEmployee = hw1.idEmployee 
			and jb.jobNo = jb1.jobNo 
			and po1.idPO = po.idPO 
			and wo.idAuxWO = wo1.idAuxWO 
			and tk1.idAux = tk.idAux 
			and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) 
			and not wc1.name like '%6.4%') ,0)
	 as 'Hours OT',

	ISNULL(wc.billingRateOT,0) as 'billingRateOT',
	
	ISNULL((select exu.amount from expensesUsed as exu 
	inner join expenses as ex on ex.idExpenses = exu.idExpense 
	inner join task as tk1 on tk1.idAux = exu.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO 
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
	inner join job as jb1 on jb1.jobNo = po1.jobNo 
	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Per-Diem') ,0) as 'PerDiem' ,

	ISNULL((select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo 
	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel') ,0) as 'Travel' 
	from employees as em 
		inner join hoursWorked as hw on hw.idEmployee = em.idEmployee
		left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
		inner join task as tk on tk.idAux= hw.idAux
		inner join workOrder wo on  wo.idAuxWO=tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = wo.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,'')) and not wc.name like '%6.4%' 
	order by 
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
	hw.dateWorked
end
GO

--##############################################################################################
--################## SP REPORT CATS EMPLOYEE BY PROJECT ########################################
--##############################################################################################
--ALTER proc [dbo].[sp_Cats_Employee_by_Porject]
CREATE proc [dbo].[sp_Cats_Employee_by_Porject]
@startdate as date,
@finaldate as date,
@employeenumber int,
@all as bit
as
begin
	select concat(wo.idWO, ' ',ts.task) as 'W/PO Number',
		em.numberEmploye as 'Emp: Number',
		concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
		wc.description,
		sum(hw.hoursST) as 'ST Hours', 
		sum(hw.hoursOT) as 'OT Hours', 
		hw.dateWorked as 'Date Worked'
		from hoursWorked as hw
		inner join employees as em on em.idEmployee= hw.idEmployee
		inner join workCode as wc on wc.idWorkCode= hw.idWorkCode and wc.jobNo = hw.jobNo
		inner join task as ts on ts.idAux= hw.idAux
		inner join workOrder wo on wo.idAuxWO=ts.idAuxWO
		where hw.dateWorked between @startdate and @finaldate and em.numberEmploye like IIF(@all=1,'%',convert(nvarchar, @employeenumber))
		group by concat(wo.idWO, ' ',ts.task),em.numberEmploye, concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
		 wc.description,hw.dateWorked
end
GO

--##############################################################################################
--################## SP REPORT CLIENT BILLINGS PROJECT #########################################
--##############################################################################################
--ALTER proc [dbo].[sp_Client_billings_Project]
CREATE proc [dbo].[sp_Client_billings_Project]
@startdate as date, 
@finaldate as date,
@clientnum as int
as
begin
	set @startdate = ISNULL(@startdate,GETDATE())
	set @finaldate = ISNULL(@FinalDate,GETDATE())
	select T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
			T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
			T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend] from(
		select cl.companyName, jb.jobNo, po.idPO,concat(wo.idWO,' ',ts.task) as 'Work Order',
			ts.description as 'Project Desription',

			(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)+
			(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Total Hours',
		
		
			(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours ST',
		
		
			(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2) as 'Billings ST',

			(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours OT',
	
		
			(select  ISNULL( SUM(T2.Amount),0) as 'Billings OT' from 
			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2) as 'Billings OT',


			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0) as 'Total Expenses',
			
			
			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0) as 'Total Material',
	
			((select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2)
			+
			(select  ISNULL( SUM(T2.Amount),0) from 
			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2)
			+
			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0)
			+
			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0)
			) as 'Total Spend'

			from Clients as cl
			inner join job as jb on jb.idClient= cl.idClient
			inner join projectOrder as po on po.jobNo= jb.jobNo 
			inner join workOrder as wo on wo.idPO=po.idPO and po.jobNo = wo.jobNo
			inner join task as ts on ts.idAuxWO=wo.idAuxWO
	 
			where cl.numberClient=@clientnum 
			)as T2 
			where
			T2.[Billings ST]>0 OR T2.[Billings OT]>0 OR T2.[Total Expenses]>0 OR T2.[Total Material]>0 or T2.[Total Expenses] > 0
			group by T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
			T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
			T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend]
end
GO

--##############################################################################################
--################## SP REPORT COMPLETE BY DATE RANGE ##########################################
--##############################################################################################
--ALTER proc [dbo].[Sp_Complete_By_Date_Range]
CREATE proc [dbo].[Sp_Complete_By_Date_Range]
@clientnum as int,
@jobNum as bigint,
@all as bit
as
begin
if @all=1
begin
	select  cl.companyName, concat(wo.idWO,' ',ts.task) as 'Work Order',ts.description as 'Desription',
		ts.equipament, ts.expCode as 'Expense Code',ts.accountNum as 'Account No', ts.status as 'Complete'
		from task as ts 
		inner join workOrder as wo on wo.idAuxWO = ts.idAuxWO 
		inner join projectOrder as po on po.idPO=wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where ts.status = '1' and cl.numberClient = @clientnum
		end
else 
begin
	select  cl.companyName, concat(wo.idWO,' ',ts.task) as 'Work Order',ts.description as 'Desription',
		ts.equipament, ts.expCode as 'Expense Code',ts.accountNum as 'Account No', ts.status as 'Complete'
		from task as ts 
		inner join workOrder as wo on wo.idAuxWO = ts.idAuxWO 
		inner join projectOrder as po on po.idPO=wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where ts.status = '1' and cl.numberClient = @clientnum and jb.jobNo=@jobNum
		end
end
go

--##############################################################################################
--################## SP DELETE DRAWING #########################################################
--##############################################################################################
--ALTER proc [dbo].[sp_delete_drawing] 
CREATE proc [dbo].[sp_delete_drawing] 
@idDrawingNum varchar(45),
@projectId varchar,
@msg varchar(100) output 
as 
declare @Error as int
begin 
	begin tran 
	begin try 
		set @msg = 'Error while traying to delete Cost Build records'
		select * from EstCostBuild where idDrawingNum = @idDrawingNum
		delete from EstCostBuild where idDrawingNum = @idDrawingNum
		set @msg = 'Error while traying to delete Cost Dimantle records'
		select * from EstCostDism where idDrawingNum = @idDrawingNum
		delete from EstCostDism where idDrawingNum = @idDrawingNum
		set @msg = 'Error while traying to delete Cost Scaffold records'
		select * from EstCostScf where idDrawingNum = @idDrawingNum
		delete from EstCostScf where idDrawingNum = @idDrawingNum
		set @msg = 'Error while traying to delete Cost Equipment records'
		select  *from EstCostEq where idDrawingNum = @idDrawingNum
		delete from EstCostEq where idDrawingNum = @idDrawingNum
		set @msg = 'Error while traying to delete Cost Piping records'
		select * from EstCostPp where idDrawingNum = @idDrawingNum
		delete from EstCostPp where idDrawingNum = @idDrawingNum
		set @msg = 'Error while traying to delete Scaffold Estimation records'
		select * from scaffoldEst where idDrawingNum = @idDrawingNum
		delete from scaffoldEst where idDrawingNum = @idDrawingNum
		set @msg = 'Error while traying to delete Equipment Estimation records'
		select * from equipmentEst where idDrawingNum = @idDrawingNum
		delete from equipmentEst where idDrawingNum = @idDrawingNum
		set @msg = 'Error while traying to delete Piping Estimation records'
		select * from pipingEst where idDrawingNum = @idDrawingNum
		delete from pipingEst where idDrawingNum = @idDrawingNum
		set @msg = 'Error while traying to delete Drawing record'
		select * from drawing where idDrawingNum = @idDrawingNum
		delete from drawing where idDrawingNum = @idDrawingNum 
		set @msg = 'Successfull'
	commit tran 
	end try	
	begin catch
		set @Error = 0
		rollback tran
	end catch
end
GO
--##############################################################################################
--################## SP DELETE SCAFFOLD ########################################################
--##############################################################################################
create proc sp_deleteScaffold
@tag as varchar(20)
as 
declare @countProduct as int = (select COUNT(*) from productTotalScaffold where tag = @tag and status = 't' )	
declare @qty as float = 0.0
declare @idProduct as int
begin
while (@countProduct > 0) 
begin
	select  @qty = quantity ,@idProduct = idProduct from (select top 1  quantity,idProduct from productTotalScaffold where tag = @tag and status = 't') as t1
	select quantity from product where idProduct = @idProduct
	update product set quantity = quantity + @qty where idProduct = @idProduct
	delete from productTotalScaffold where idProduct = @idProduct and tag = @tag
	set @countProduct = (select COUNT(*) from productTotalScaffold where tag = @tag and status = 't')
end
if (select COUNT(*) from productTotalScaffold where tag = @tag and status = 't')=0
begin
	delete from leg where tag	= @tag
	select *from materialHandeling where tag = @tag
	delete from materialHandeling where tag = @tag
	select * from activityHours where tag = @tag
	delete from activityHours where tag = @tag
	select * from scaffoldInformation where tag = @tag
	delete from scaffoldInformation	where tag = @tag
	select * from scfInfo where tag = @tag
	delete from scfInfo where tag = @tag
	select * from productDismantle where tag = @tag
	delete from productDismantle where tag = @tag
	select * from dismantle where tag = @tag
	delete from dismantle where tag = @tag 
	select * from productDismantle where tag = @tag
	delete from productModification where tag = @tag
	select * from modification where tag = @tag
	delete from modification where tag= @tag
	select * from productScaffold where tag = @tag
	delete from productScaffold where tag =@tag
    select * from productTotalScaffold where tag = @tag
	delete from productTotalScaffold where tag = @tag
	select * from scaffoldTraking where tag = @tag
	delete from scaffoldTraking where tag = @tag
end
end
GO
--##############################################################################################
--################## SP DELETE MOD AUX #########################################################
--##############################################################################################
--ALTER proc [dbo].[sp_DeleteModAux]
CREATE proc [dbo].[sp_DeleteModAux]
@tag varchar(20),
@modID varchar(36),
@msg varchar(120) output
as
declare @error as int = 0
declare @flag as int
declare @idProduct as int
declare @qty as float
begin 
	if (select COUNT(*) from modification where idModAux = @modID and tag = @tag) >0 
	begin 
		begin tran	
			begin try
				set	@msg = CONCAT('Error trying to delete Activity Hours from Modification ',@modID)
				delete from activityHours where tag = @tag and idModAux = @modID
				set	@msg = CONCAT('Error trying to delete Material Handeling from Modification ',@modID)
				delete from materialHandeling where tag = @tag and idModAux = @modID
				set	@msg = CONCAT('Error trying to delete Scaffold Information from Modification ',@modID)
				delete from scaffoldInformation where tag = @tag and idModAux=@modID
				set @flag = (select COUNT(*) from productModification where tag = @tag and idModAux = @modID)
				while (@flag > 0)
				begin
					select  @qty = quantity ,@idProduct = idProduct from (select top 1  quantity,idProduct from productModification where tag = @tag and idModAux = @modID) as t1
					set	@msg = CONCAT('Error trying to delete Product Modification Record from Modification: ', @modID,', with the idProduct: ',CONVERT(varchar(12), @idProduct))
					select quantity from product where idProduct = @idProduct
					update product set quantity = quantity + @qty where idProduct = @idProduct
					select quantity from productTotalScaffold where idProduct = @idProduct and tag = @tag
					update productTotalScaffold set quantity = quantity + IIF(@qty>0,@qty*-1,@qty*-1) where idProduct = @idProduct and tag = @tag
					delete from productModification where idProduct = @idProduct and tag = @tag and idModAux = @modID
					delete from productTotalScaffold where quantity = 0 and tag = @tag
					set @flag = ( select COUNT(*) from productModification where tag = @tag and idModAux = @modID)
				end
				delete from modification where idModification = @modID and tag = @tag	
				set @msg = 'Successful'	 
			end try
			begin catch
				set @error = 1
				goto solveProblem
			end catch
		commit tran 
		print @msg	
		solveProblem:
		if @error <> 0
		begin 
			rollback tran 
		end
	end
end
GO
----#########################################################################################################################################################################################
----######## PROCEDIMIENTO PARA ELIMINAR UN RFI EQUIPMENT ###################################################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_deleteRFIEquipment] 
CREATE proc [dbo].[sp_deleteRFIEquipment] 
@idRFIDelete varchar(35),
@idRFINext varchar(35),
@tag int,
@idDrawingNum varchar(45)
as
declare @error as bit

declare @Elevation int
declare @WwPaint varchar(40)
declare @System varchar(10) 
declare @Option varchar(25) 
declare @SqrFtPnt float
declare @WwRemove varchar(40)
declare @Remove bit
declare @SqrFtRmv float
declare @WwInstall varchar(40)
declare @Type varchar(25)
declare @Thick float
declare @Jacket varchar(25)
declare @SqrFtII float
declare @Bevel float
declare @CutOut float

begin
	begin tran
		begin try
			set @error = 0
			if (@idRFINext <> '')--existe un RFI adelante en base a los IDs
			begin
				if (select COUNT(*) from RFIEquipment where idRFIEq = @idRFINext and tag = @tag)=1
				begin 
					--Tomo los valor de LAST del que tengo que eliminar 
					select top 1 @Elevation=oldElevation ,@WwPaint = oldWwPaint,@System=oldSystem,@Option=oldOption,@SqrFtPnt=oldSqrFtPnt,@WwRemove=oldWwRemove,
					@Remove=oldRemove,@SqrFtRmv=oldSqrFtRmv,@WwInstall=oldWwInstall,@Type=oldType,@Thick=oldThick,@Jacket=oldJacket,@SqrFtII=oldSqrFtII,@Bevel=oldBevel,@CutOut=oldCutOut from RFIEquipment where idRFIEq = @idRFIDelete and tag = @tag and idDrawingNum = @idDrawingNum
					--Actualizo los valore del que esta enseguida con los valores que deseo eliminar
					update RFIEquipment set oldElevation=@Elevation,oldWwPaint=@WwPaint,oldSystem=@System,oldOption=@Option,oldSqrFtPnt=@SqrFtPnt,oldWwRemove=@WwRemove,
					oldRemove=@Remove,oldSqrFtRmv=@SqrFtRmv,oldWwInstall=@WwInstall,oldType=@Type,oldThick=@Thick,oldJacket=@Jacket,oldSqrFtII=@SqrFtII,oldBevel=@Bevel,oldCutOut=@CutOut
					where tag = @tag and idDrawingNum = @idDrawingNum and idRFIEq = @idRFINext
					--elimino el RFI
					delete RFIEquipment where tag = @tag and idDrawingNum = @idDrawingNum and idRFIEq = @idRFIDelete
				end
				else
				begin 
					delete RFIEquipment where tag = @tag and idDrawingNum = @idDrawingNum and idRFIEq = @idRFIDelete
				end
			end
			else --No existe un RFI mas o depeues de este, por ende tiene que tomar los valores de su Last ya que es el mismo EQUIPMENT o un anterior a el,
			begin -- y se tiene que actualizar el equipmentEst ya que es el RFI a eliminar es el ultimo cambio que se le hizo
				--Tomo los valor de LAST del que tengo que eliminar 
				select top 1 @Elevation=oldElevation ,@WwPaint = oldWwPaint,@System=oldSystem,@Option=oldOption,@SqrFtPnt=oldSqrFtPnt,@WwRemove=oldWwRemove,
					@Remove=oldRemove,@SqrFtRmv=oldSqrFtRmv,@WwInstall=oldWwInstall,@Type=oldType,@Thick=oldThick,@Jacket=oldJacket,@SqrFtII=oldSqrFtII,@Bevel=oldBevel,@CutOut=oldCutOut from RFIEquipment where idRFIEq = @idRFIDelete and tag = @tag and idDrawingNum = @idDrawingNum
				--Actualizo el equipmentEst con los valores LAST del RFI a eliminar
				update equipmentEst set elevation=@Elevation,idLaborRatePnt=@WwPaint,systemPntEq=@System,pntOption=@Option,sqrFtPnt=@SqrFtPnt,idLaborRateRmv=@WwRemove,
					remIns=@Remove,sqrFtRmv=@SqrFtRmv,idLaborRateII=@WwInstall,[type]=@Type,thick=@Thick,idJacket=@Jacket,sqrFtII=@SqrFtII,bevel=@Bevel,cutout=@CutOut
					where idEquimentEst = @tag and idDrawingNum = @idDrawingNum 
				--Elimino el RFI
				delete RFIEquipment where tag = @tag and idDrawingNum = @idDrawingNum and idRFIEq = @idRFIDelete
			end
		end try
		begin catch
			set @error = 1
			goto solveError
		end catch
	commit tran
	solveError:
	if @error = 1
	begin 
		rollback tran
	end 
end
go
----#########################################################################################################################################################################################
----######## PROCEDIMIENTO PARA ELIMINAR UN RFI PIPING ######################################################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_deleteRFIPiping] 
CREATE proc [dbo].[sp_deleteRFIPiping] 
@idRFIDelete varchar(35),
@idRFINext varchar(35),
@tag int,
@idDrawingNum varchar(45)
as
	declare @error as bit

	declare @Size float 
	declare @Elevation int 
	declare @system varchar(10) 
	declare @option varchar(25) 
	declare @type varchar(25) 
	declare @Thick float 
	declare @IdJacket varchar(25) 
    declare @IdLaborRatePnt varchar(40) 
	declare @LFtPnt float 
	declare @P90Pnt int 
	declare @P45Pnt int 
	declare @PTeePnt int 
	declare @PPairPnt int 
	declare @PVlvPnt int 
	declare @PControlPnt int
	declare @PWeldPnt int
    declare @IdLaborRateRmv varchar(40) 
	declare @LFtRmv float 
    declare @IdLaborRateII varchar(40) 
	declare @LFtII float
	declare @P90II int 
	declare @P45II int 
	declare @PBendII int 
	declare @PTeeII int 
	declare @PReducII int 
	declare @PCapsII int 
	declare @PPairII int 
	declare @PVlvII int 
	declare @PControlII int 
	declare @PWeldII int 
	declare @PCutOutII int 
	declare @PsupportII int 

begin
	begin tran
		begin try
			set @error = 0
			if (@idRFINext <> '')--existe un RFI adelante en base a los IDs
			begin
				if (select COUNT(*) from RFIPiping where idRFIPp = @idRFINext and tag = @tag)=1
				begin 
					--Tomo los valor de LAST del que tengo que eliminar 
					select top 1 @Size = oldSize ,@Elevation = oldElevation ,@system = oldSystem ,@option = oldOption ,@type = oldType ,@Thick = oldThick ,@IdJacket = oldIdJacket ,
						@IdLaborRatePnt = oldIdLaborRatePnt ,@LFtPnt = oldLFtPnt ,@P90Pnt = oldP90Pnt ,@P45Pnt = oldP45Pnt ,@PTeePnt = oldPTeePnt ,@PPairPnt = oldPPairPnt ,@PVlvPnt = oldPVlvPnt ,@PControlPnt = oldPControlPnt ,@PWeldPnt = oldPWeldPnt ,
						@IdLaborRateRmv = oldIdLaborRateRmv ,@LFtRmv = oldLFtRmv ,
						@IdLaborRateII = oldIdLaborRateII ,@LFtII = oldLFtII ,@P90II = oldP90II ,@P45II = oldP45II ,@PTeeII = oldPTeeII ,@PBendII = oldPBendII ,@PReducII = oldPReducII ,@PCapsII = oldPCapsII ,@PPairII = oldPPairPnt ,@PVlvII = oldPVlvII ,@PControlII = oldPControlII ,@PWeldII = oldPWeldII ,@PCutOutII = oldPCutOutII ,@PsupportII = oldPsupportII
						from RFIPiping where idRFIPp = @idRFIDelete and tag = @tag and idDrawingNum = @idDrawingNum
					--Actualizo los valore del que esta enseguida con los valores que deseo eliminar
					update RFIPiping set oldSize = @Size ,oldElevation = @Elevation ,oldSystem = @system ,oldOption= @option ,oldType = @type ,oldThick = @Thick ,
					oldIdLaborRatePnt = @IdLaborRatePnt ,oldLFtPnt = @LFtPnt ,oldP90Pnt = @P90Pnt ,oldP45Pnt = @P45Pnt ,oldPTeePnt = @PTeePnt ,oldPPairPnt = @PPairPnt ,oldPVlvPnt = @PVlvPnt ,oldPControlPnt = @PControlPnt ,oldPWeldPnt = @PWeldPnt ,
					oldIdLaborRateRmv = @IdLaborRateRmv ,oldLFtRmv = @LFtRmv ,
					oldIdLaborRateII = @IdLaborRateII ,oldLFtII = @LFtII ,oldP90II = @P90II ,oldP45II = @P45II ,oldPBendII= @PBendII ,oldPTeeII = @PTeeII ,oldPReducII = @PReducII ,oldPCapsII = @PCapsII ,oldPPairII = @PPairII ,oldPVlvII = @PVlvII ,oldPControlII = @PControlII ,oldPWeldII = @PWeldII ,oldPCutOutII = @PCutOutII ,oldPsupportII = @PsupportII 
					where tag = @tag and idDrawingNum = @idDrawingNum and idRFIPp = @idRFINext
					--elimino el RFI
					delete RFIPiping where tag = @tag and idDrawingNum = @idDrawingNum and idRFIPp = @idRFIDelete
				end
				else
				begin 
					delete RFIPiping where tag = @tag and idDrawingNum = @idDrawingNum and idRFIPp = @idRFIDelete
				end
			end
			else --No existe un RFI mas o depeues de este, por ende tiene que tomar los valores de su Last ya que es el mismo EQUIPMENT o un anterior a el,
			begin -- y se tiene que actualizar el equipmentEst ya que es el RFI a eliminar es el ultimo cambio que se le hizo
				--Tomo los valor de LAST del que tengo que eliminar 
				select top 1 @Size = oldSize ,@Elevation = oldElevation ,@system = oldSystem ,@option = oldOption ,@type = oldType ,@Thick = oldThick ,@IdJacket = oldIdJacket ,
						@IdLaborRatePnt = oldIdLaborRatePnt ,@LFtPnt = oldLFtPnt ,@P90Pnt = oldP90Pnt ,@P45Pnt = oldP45Pnt ,@PTeePnt = oldPTeePnt ,@PPairPnt = oldPPairPnt ,@PVlvPnt = oldPVlvPnt ,@PControlPnt = oldPControlPnt ,@PWeldPnt = oldPWeldPnt ,
						@IdLaborRateRmv = oldIdLaborRateRmv ,@LFtRmv = oldLFtRmv ,
						@IdLaborRateII = oldIdLaborRateII ,@LFtII = oldLFtII ,@P90II = oldP90II ,@P45II = oldP45II ,@PTeeII = oldPTeeII ,@PBendII = oldPBendII ,@PReducII = oldPReducII ,@PCapsII = oldPCapsII ,@PPairII = oldPPairPnt ,@PVlvII = oldPVlvII ,@PControlII = oldPControlII ,@PWeldII = oldPWeldII ,@PCutOutII = oldPCutOutII ,@PsupportII = oldPsupportII
						from RFIPiping where idRFIPp = @idRFIDelete and tag = @tag and idDrawingNum = @idDrawingNum
				--Actualizo el equipmentEst con los valores LAST del RFI a eliminar
				select * from pipingEst
				update pipingEst set size= @Size ,elevation= @Elevation ,[type]= @type ,systemPntPP= @system,pntOption=@option ,idJacket = @IdJacket ,
				idLaborRateRmv = @IdLaborRateRmv ,lFtRmv= @LFtRmv ,
				idLaborRatePnt = @IdLaborRatePnt ,lFtPnt = @LFtPnt ,p90Pnt= @P90Pnt ,p45Pnt = @P45Pnt ,pTeePnt= @PTeePnt ,pPairPnt= @PPairPnt ,pVlvPnt= @PVlvPnt ,pControlPnt= @PControlPnt ,pWeldPnt= @PWeldPnt ,
				idLaborRateII= @IdLaborRateII ,lFtII= @LFtII ,p90II = @P90II ,p45II = @P45II ,pBendII = @PBendII ,pTeeII = @PTeeII ,pReducII = @PReducII ,pCapsII = @PCapsII ,pPairII = @PPairII ,pVlvII = @PVlvII ,pControlII = @PControlII ,pWeldII = @PWeldII ,pCutOutII = @PCutOutII ,psupportII = @PsupportII
				where idPipingEst = @tag and idDrawingNum = @idDrawingNum 
				--Elimino el RFI
				delete RFIPiping where tag = @tag and idDrawingNum = @idDrawingNum and idRFIPp = @idRFIDelete
			end
		end try
		begin catch
			set @error = 1
			goto solveError
		end catch
	commit tran
	solveError:
	if @error = 1
	begin 
		rollback tran
	end 
end
go
----#########################################################################################################################################################################################
----############## PROCEDIMIENTO ELIMINAR RFI SCAFFOLD ######################################################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_deleteRFIScaffold] 
CREATE proc sp_deleteRFIScaffold 
@idRFIDelete varchar(35),
@idRFINext varchar(35),
@tag varchar(20),
@idDrawingNum varchar(45)
as
declare @error as bit
declare @Days as int
declare @With as float
declare @Length as float
declare @Heigth as float
declare @Build as float
declare @IdLabor as varchar(40)
declare @IdSCFUR as varchar(35)
begin
	begin tran
		begin try
			set @error = 0
			if (@idRFINext <> '')--existe un RFI adelante en base a los IDs
			begin
				if (select COUNT(*) from RFIScaffoldEst where idRFI = @idRFINext and tag = @tag)=1
				begin 
					--Tomo los valor de LAST del que tengo que eliminar 
					select top 1 @Days = lastDays,@With = lastWith,@Length = lastLength,@Heigth=lastHeigth,@Build=lastBuild,@IdLabor = lastIdLaborRate,@IdSCFUR = lastIdSCFUR from RFIScaffoldEst where idRFI = @idRFIDelete and tag = @tag	
					--Actualizo los valore del que esta enseguida con los valores que deseo eliminar
					update RFIScaffoldEst set lastDays = @Days ,lastWith = @With,lastLength=@Length,lastHeigth=@Heigth,lastBuild=@Build,lastIdLaborRate=@IdLabor,lastIdSCFUR=@IdSCFUR 
					where tag = @tag and idDrawingNum = @idDrawingNum and idRFI = @idRFINext
					--elimino el RFI
					delete RFIScaffoldEst where tag = @tag and idDrawingNum = @idDrawingNum and idRFI = @idRFIDelete
				end
				else
				begin 
					delete RFIScaffoldEst where tag = @tag and idDrawingNum = @idDrawingNum and idRFI = @idRFIDelete
				end
			end
			else --No existe un RFI mas o depeues de este, por ende tiene que tomar los valores de su Last ya que ES el Scaffold mismo o un anterior a el,
			begin -- y se tiene que actualizar el scaffoldEst ya que es el RFI a eliminar es el ultimo cambio que se le hizo
				--Tomo los valor de LAST del que tengo que eliminar 
				select top 1 @Days = lastDays,@With = lastWith,@Length = lastLength,@Heigth=lastHeigth,@Build=lastBuild,@IdLabor = lastIdLaborRate,@IdSCFUR = lastIdSCFUR from RFIScaffoldEst where idRFI = @idRFIDelete and tag = @tag	
				--Actualizo el ScaffoldEst con los valores LAST del RFI a eliminar
				update scaffoldEst set [days]=@Days,width=@With,[length]=@Length,heigth=@Heigth,build=@Build,idLaborRate= @IdLabor,idSCFUR=@IdSCFUR where tag = @tag and idDrawingNum = @idDrawingNum
				--Elimino el RFI
				delete RFIScaffoldEst where tag = @tag and idDrawingNum = @idDrawingNum and idRFI = @idRFIDelete
			end
		end try
		begin catch
			set @error = 1
			goto solveError
		end catch
	commit tran
	solveError:
	if @error = 1
	begin 
		rollback tran
	end 
end
go
--##############################################################################################
--################## SP REPORT EMPLOYEE PER DIEM ###############################################
--##############################################################################################
--ALTER proc [dbo].[Sp_Employee_Per_Diem_Sheets]
CREATE proc [dbo].[Sp_Employee_Per_Diem_Sheets]
@startdate as date, 
@finaldate as date,
@clientnum as int,
@job as bigInt,
@all as bit
as
begin
	select 
	CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, xp.dateExpense)) ,xp.dateExpense)) as 'Weekending',
			po.jobNo as 'Job Num',
			CONCAT(wo.idWO,' ', tk.task) as 'Project Name',
			ex.expenseCode as 'Project Description' ,
			cl.companyName as 'Company Name',  
			CONCAT(em.lastName,',',em.firstName,' ',em.middleName) as 'Employee Name',
			em.numberEmploye as 'Emp: Number',
			em.typeEmployee as 'Class', 
			sum(xp.amount) as 'Amount' 
			from expensesUsed as xp 
			inner join expenses as ex on xp.idExpense = ex.idExpenses
			inner join employees as em on em.idEmployee = xp.idEmployee 
			inner join task as tk on tk.idAux = xp.idAux
			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
			inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
			inner join job as jb on jb.jobNo = wo.jobNo 
			inner join clients as cl on cl.idClient = jb.idClient
			where xp.dateExpense  between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,''))
			group by CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, xp.dateExpense)) ,xp.dateExpense)),po.jobNo, wo.idWO, tk.task,cl.companyName, ex.expenseCode,
			CONCAT(em.lastName,',',em.firstName,' ',em.middleName),em.numberEmploye,em.typeEmployee
end
go
--##############################################################################################
--################## SP REPORT EMPLOYEE TIME ###################################################
--##############################################################################################
--ALTER proc [dbo].[sp_Employee_Time]
CREATE proc [dbo].[sp_Employee_Time]
@initialDate as date,
@finalDate as date,
@jobNum as bigint,
@numClient as int,
@all as bit
as
begin
if @all = 0 
begin 
	select numberEmploye,em.SAPNumber,concat(em.lastName,',',em.firstName,' ',em.middleName) as 'EmpName',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where jb.jobNo=@jobNum and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayOT',
	 (select pr1.payRate1 from payRate as pr1 where pr1.idEmployee = em.idEmployee and pr1.datePayRate = (select max(pr2.datePayRate) from payRate as pr2 where pr2.idEmployee = em.idEmployee)) as 'RateST',
	 (select pr1.payRate2 from payRate as pr1 where pr1.idEmployee = em.idEmployee and pr1.datePayRate = (select max(pr2.datePayRate) from payRate as pr2 where pr2.idEmployee = em.idEmployee)) as 'RateoT',
	 case when (select sum (amount) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') is NULL then ''  else (select sum (amount) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') end as 'TotalAmount',
	 (select count (*) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') as 'NO.Days'
	from employees as em
	 where em.estatus = 'E'
end 
else if @all = 1
begin 
	select numberEmploye,em.SAPNumber,concat(em.lastName,',',em.firstName,' ',em.middleName) as 'EmpName',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')	is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')	is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where cl.numberClient=@numClient and hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayOT',
	 (select pr1.payRate1 from payRate as pr1 where pr1.idEmployee = em.idEmployee and pr1.datePayRate = (select max(pr2.datePayRate) from payRate as pr2 where pr2.idEmployee = em.idEmployee)) as 'RateST',
	 (select pr1.payRate2 from payRate as pr1 where pr1.idEmployee = em.idEmployee and pr1.datePayRate = (select max(pr2.datePayRate) from payRate as pr2 where pr2.idEmployee = em.idEmployee)) as 'RateoT',
	 case when (select sum (amount) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') is NULL then ''  else (select sum (amount) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') end as 'TotalAmount',
	 (select count (*) from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense where exu.idEmployee = em.idEmployee and exu.dateExpense between @initialDate and @finalDate and ex.expenseCode like '%perdiem%') as 'NO.Days'
	from employees as em
	 where em.estatus = 'E'
end
end
go
--##############################################################################################
--################## SP EQUIPMENT DAILY ########################################################
--##############################################################################################
--ALTER proc [dbo].[sp_Equipament_Daily]
CREATE proc [dbo].[sp_Equipament_Daily]
@startDate date,
@FinalDate date,
@numberClient int
as
begin 
	select cl.companyName 'Comapany Name',CONCAT(cl.firstName,' ',cl.lastName,' ',cl.middleName) as 'Client' ,
	jb.jobNo, po.idPO,CONCAT(wo.idWO,'-',tk.task) as 'WO No',tk.accountNum,tk.expCode as 'CostAllocation', jb.costCode as 'CostCenter',
	ISNULL(CONVERT(varchar,jb.contractNo),'') as 'Contract' ,tk.[description] as'Project Description' 
	,mu.[dateMaterial] as 'Date Worked'
	,mc.code as 'Equip No'
	,mc.[description] as 'Equipment Class'
	,mt.name as 'Equipament Description'
	,mu.hoursST as 'ST Hours'
	,mu.amount as 'Daily Cost'
	from materialUsed as mu 
	inner join material as mt on mt.idMaterial = mu.idMaterial
	inner join materialClass as mc on mc.code = mt.code
	inner join task as tk on tk.idAux = mu.idAux
	inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
	inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
	inner join job as jb on jb.jobNo = po.jobNo
	inner join clients as cl on cl.idClient = jb.idClient
	where SUBSTRING(mc.code,1,2) = '2.' 
	and cl.numberClient = @numberClient
	and (mu.dateMaterial between @startDate and @FinalDate)
end
go
--##############################################################################################
--################## SP HISTORY MATERIAL BY PROJECT ############################################
--##############################################################################################
--ALTER proc [dbo].[sp_historyMaterialByProject]
CREATE proc [dbo].[sp_historyMaterialByProject]
@StartDate as date,
@EndDate as Date,
@numberClient as integer,
@job as bigint,
@all as bit
as begin 
	select cl.numberClient, jb.jobNo , po.idPO , CONCAT(wo.idWO,'-',tk.task) as 'WorkOrder', 
	ma.name , ma.code , mu.quantity,mu.amount , mu.dateMaterial , mu.[description] 
	from materialUsed as mu
	inner join material as ma on ma.idMaterial = mu.idMaterial 
	inner join task as tk on tk.idAux = mu.idAux
	inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
	inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
	inner join job as jb on jb.jobNo = po.jobNo 
	inner join clients as cl on cl.idClient = jb.idClient
	where cl.numberClient = @numberClient and mu.dateMaterial between @StartDate and @EndDate 
			and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,''))
end 
GO
--##############################################################################################
--################## SP HOURS PER WEEK #########################################################
--##############################################################################################
--ALTER proc [dbo].[sp_Hours_Per_Week]
CREATE proc [dbo].[sp_Hours_Per_Week]
@date as date
as
declare @initialDate as date
declare @finalDate as date
begin 
	set @date = ISNULL(@date, GETDATE())
	set @initialDate = DATEADD (DAY, iif(DATEPART(DW,@date) = 1,-6,iif(DATEPART(DW,@date)=2,0,-(DATEPART(DW,@date)-2)) ),@date)
	set @finalDate = DATEADD(day, 6 , @initialDate)
	select @finalDate as 'Weekending' ,concat(em.lastName,',',em.firstName,' ',em.middleName) as 'EmpName',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Monday')		 end as 'MondayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Tuesday')		 end as 'TuesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	    is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	    is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Wednesday')	 end as 'WednesdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Thursday')	 end as 'ThursdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Friday')		 end as 'FridayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Saturday')	 end as 'SaturdayOT',
	 case when (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursST) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayST',
	 case when (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		is null then 0 else (select sum(hw.hoursOT) from hoursWorked as hw inner join task as tk on tk.idAux = hw.idAux inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo inner join job as jb on jb.jobNo =po.jobNo inner join clients as cl on cl.idClient = jb.idClient where hw.idEmployee= em.idEmployee and (hw.dateWorked between @initialDate and @finalDate) and DATENAME(dw,hw.dateWorked)='Sunday')		 end as 'SundayOT'
	from employees as em
	 where em.estatus = 'E'
end
go
--##############################################################################################
--################## SP INSERT CLIENT ##########################################################
--##############################################################################################
--ALTER proc [dbo].[sp_Insert_Cient] 
CREATE proc [dbo].[sp_Insert_Cient] 
	@ClientID int,
	@FirstName varchar (30),
	@MiddleName varchar (30),
	@LastName varchar (30),
	@CompanyName varchar (50),
	@Status char(1),
	--Contact
	@phoneNumer1 varchar(13),
	@phoneNumer2 varchar(13),
	@email varchar(50),
	--Addres
	@avenue varchar(80),
	@number int,
	@city varchar (20),
	@providence varchar (20),
	@postalcode int,
	--Photo
	@img image,
	@payTerms varchar(30)
as
declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
declare @idClient varchar(36) 
declare @idContact varchar(36)
declare @idHomeAdress varchar(36)
begin 
	begin tran 
		begin try
			--se inserta un contacto
			
				set @idContact = NEWID() 
				insert into contact values(@idContact,@phoneNumer1,@phoneNumer2,@email)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
			
				set @idHomeAdress = NEWID()
				insert into HomeAddress values (@idHomeAdress , @avenue , @number , @city , @providence , @postalCode)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			
				set @idClient = NEWID()
				insert into clients values (@idClient , @ClientID, @FirstName, @MiddleName, @LastName , @CompanyName, @idContact , @idHomeAdress ,@Status,@img,@payTerms)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 

				insert into TrackDefaultElements values(NEWID(),@idClient,'','','','','','','','','','','','','','','','','','','','','','','','','','','','')
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
				
				insert into TrackFormatColums values(NEWID(),@idClient,'Record ID1','Force or Reject1','Source1','Date1','Order Type1','Location ID1','Company Code1','Resource ID1','Resource Name1','Area1','Group Name1','Agreement1','Skill Type1','Shift1','Level 1 ID1','Level 2 ID1','Level 3 ID1','Level 4 ID1','Hours Total1','Hours Total Activity Code1','S/T (Hrs)1','S/T Hrs Activity Code1','O/T (Hrs)1','O/T Hrs Activity Code1','D/T (Hrs)1','D/T Hrs Activity Code1','Extra Charges $1','Extra Charges $ Activity Code1','Extra1','Extra 11','Extra 21','Add Time1','Pay Type1','R4 (Hrs)1','R5 (Hrs)1','R6 (Hrs)1','GL Account1','ST Adders1','OT Adders1','DT Adders1','R4 Adders1','R5 Adders1','R6 Adders1')
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
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
GO
--##############################################################################################
--################## SP INSERT EMPLOYEE ########################################################
--##############################################################################################
--ALTER proc [dbo].[sp_insert_Employee]
CREATE proc [dbo].[sp_insert_Employee]
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
	@payRate3 float,
	--type 
	@type varchar(20),
	--perdiem
	@perdiem bit
as 
declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
declare @idEmployee varchar(36) 
declare @idContact varchar(36)
declare @idHomeAdress varchar(36)
declare @idPayRate varchar(36)
begin
	begin tran --inicio tran
		begin try --inicio try
			--if @phoneNumber1 <> '' or @email<> '' begin -- si existe un telefono o un correo entra 
				set @idContact = NEWID() 
				insert into contact values(@idContact,@phoneNumber1,@phoneNumber2,@email)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end  -- si existe un error en al insertar solo vamos a solveproblem y nos evitamos lo demas
			--end
			--if @avenue <> '' begin -- solo se necesita saber si la calle tiene algo 
				set @idHomeAdress = NEWID()
				insert into HomeAddress values (@idHomeAdress , @avenue , @number , @city , @providence , @postalCode)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
				
			--end
			--if @firstName <> '' or @numberEmploye > 0 begin	
				set @idEmployee = NEWID()
				insert into employees values (@idEmployee , @numberEmploye , @firstName , @lastName , @middleName, @socialNumber , @SAPNumber, @photo , @idHomeAdress , @idContact ,@estatus,@type,@perdiem)
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			--end
			--if @payRate1 <> '' begin
				set @idPayRate = NEWID()
				insert into payRate values (@idPayRate,@payRate1,@payRate2 ,@payRate3,@idEmployee,GETDATE())
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			--end
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
GO
--##############################################################################################
--################## SP INSERT MATERIAL ########################################################
--##############################################################################################
--ALTER proc  [dbo].[sp_insert_Material]
CREATE proc  [dbo].[sp_insert_Material]
@nombre varchar(50),
@numero int,
@idVendor varchar(36),
@status char(1),
@class varchar(20),
@msg varchar(100) out
as
declare @idMaterial varchar(36)
declare @idDM varchar(36)
declare @error int
begin
	begin tran
		begin try	 
			set @idMaterial = NEWID()
			set @idDM = NEWID()
			if not @nombre = '' and not @idVendor = ''
			begin 
				if (select count(*) from material where number = @numero or name = @nombre)=0
				begin
					insert into material values (@idMaterial,@numero,@nombre,@status,iif(@class='',Null,@class))
					insert into detalleMaterial values (@idDM,'','','',0.0,'',0.0,@idMaterial,@idVendor,'')
					insert into existences values (@idDM , 0.0)
					set @msg= 'Successful'
				end
				else
				begin
					set @msg = CONCAT('The Material ',@numero,' was inserted.')
				end
			end
			else 
			begin 
				set @error = 1
				goto solveProblem
			end
		end try
		begin catch
			goto solveProblem
		end catch
	commit tran
	solveProblem:
	if @error <> 0 
	begin 
		rollback tran
		set @msg = concat('Is problably that the Material ',@nombre,' have been inserted, or try to changue the Vendor')
	end  
end
GO
--##############################################################################################
--################## SP INSERT MATERIAL EXCEL ##################################################
--##############################################################################################
--ALTER procedure [dbo].[sp_insert_Material_Excel]
CREATE procedure [dbo].[sp_insert_Material_Excel]
@nombre varchar(50),
@numero int,
@idVendor int,
@status char(1),
@resourceMaterial varchar(50),
@unitMesurement varchar(20),
@type varchar(30),
@price float,
@description varchar(100),
@size float,
@partNum varchar(15)
as
declare @idMaterial varchar(36)
declare @idDM varchar(36)
declare @error int
begin
	begin tran
		begin try	 
			set @idMaterial = NEWID()
			set @idDM = NEWID()
			if not @nombre = '' and not @idVendor = '' and (select count(*) from material where number =@numero) =0
			begin 
				insert into material values (@idMaterial,@numero,@nombre,@status)
				insert into detalleMaterial values (@idDM,@resourceMaterial,@unitMesurement,@type,@price,@description,@size,@idMaterial, (select idVendor from vendor where numberVendor = @idVendor),@partNum)
				insert into existences values (@idDM , 0.0)
			end
			else 
			begin 
				set @error = 1
				goto solveProblem
			end
		end try
		begin catch
			goto solveProblem
		end catch
	commit tran
	solveProblem:
	if @error <> 0 
	begin 
		rollback tran
	end  
end
GO
--##############################################################################################
--################## SP INSERT VENDOR ##########################################################
--##############################################################################################
--ALTER procedure [dbo].[sp_insert_Vendor]
CREATE procedure [dbo].[sp_insert_Vendor]
@nombre varchar(50),
@numero int,
@description varchar(80),
@status char(1),
@msg varchar(100) output
as
declare @idVendor varchar(36)
declare @error int
begin
	begin tran
		begin try	 
			set @idVendor = NEWID()
			if (select COUNT(*) from vendor where exists (select name from vendor where name like @nombre or numberVendor = @numero))=0
			begin
				insert into vendor values (@idVendor,@numero,@nombre,@description,@status)
				set @msg = 'Successful'
			end 
			else 
			begin 
				set @error = 1
				goto solveProblem
			end
		end try
		begin catch
			goto solveProblem
		end catch
	commit tran
	solveProblem:
	if @error <> 0 
	begin 
		rollback tran
		set @msg = CONCAT('Is probably that the Vendor ',@nombre,' have been registrated.')
	end  
end
GO
--##############################################################################################
--################## SP INSERT UPDATE ESTIMARION COST BUILD ####################################
--##############################################################################################
--ALTER proc [dbo].[sp_insertUpdateEstCostBuild]
CREATE proc [dbo].[sp_insertUpdateEstCostBuild]
@tag as varchar(20),
@idDrawingNum as varchar(45),
@width as float,
@length as float,
@decks as int,
@idSUFR as varchar(35),
@idLaborRate as varchar(40)
as 
declare @projectId varchar(30)
declare @M2 float = 0 
declare @SHR float = 0
declare @BUILDPERCENT float = 0
declare @SBHR float = 0
declare @SDHR float = 0
declare @SCOSTL float = 0
declare @SCOSTLB float = 0
declare @SCOSTLD float = 0
declare @SCOSTM float = 0
declare @SCOSTMB float = 0
declare @SCOSTMD float = 0
declare @SCOSTE float = 0
declare @SCOSTEB float = 0
declare @SCOSTED float = 0
declare @STCOST float = 0
declare @STCOSTB float = 0
declare @STCOSTD float = 0
begin
	set @projectId=  (select projectId from drawing where idDrawingNum = @idDrawingNum)
	set @M2 = FORMAT(((ISNULL( @width,0)*ISNULL(@length,0)*ISNULL(@decks,0))/10.76391),'###.00')
	set @SHR = ROUND(@M2/(select laborD from scfUnitsRates where idSCFUR =@idSUFR),1)
	set @BUILDPERCENT = (select dismantlePercent from scfUnitsRates where idSCFUR =@idSUFR)
	set @BUILDPERCENT = @BUILDPERCENT *0.01
	set @SBHR = ROUND(@SHR * @BUILDPERCENT,1)
	set @SDHR = @SHR- @SBHR

	set @SCOSTL = ROUND(@SBHR*(select scafRate from laborRate where idLaborRate = @idLaborRate),2)+ROUND(@SDHR * (select scafRate from laborRate where idLaborRate = @idLaborRate),2)
	set @SCOSTLB = ROUND(@SBHR * (select scafRate from laborRate where idLaborRate = @idLaborRate),2)
	set @SCOSTLD = @SCOSTL - @SCOSTLB

	set @SCOSTM = ROUND(@SHR * (select materialD from scfUnitsRates where idSCFUR = @idSUFR) ,2)
	set @SCOSTMB = ROUND(@SBHR * (select materialD from scfUnitsRates where idSCFUR = @idSUFR) ,2)
	set @SCOSTMD = @SCOSTM - @SCOSTMB

	set @SCOSTE = ROUND(@SHR * (select equipmentD from scfUnitsRates where idSCFUR = @idSUFR) ,2)
	set @SCOSTEB = ROUND(@SBHR * (select equipmentD from scfUnitsRates where idSCFUR = @idSUFR) ,2)
	set @SCOSTED = @SCOSTE - @SCOSTEB

	set @STCOST = ISNULL(@SCOSTL,0)+ISNULL(@SCOSTM,0)+ISNULL(@SCOSTE,0)
	set @STCOSTB = ISNULL(@SCOSTLB,0)+ISNULL(@SCOSTMB,0)+ISNULL(@SCOSTEB,0)
	set @STCOSTD = @STCOST - @STCOSTB

	if (select COUNT(*) from EstCostBuild where tag = @tag and idDrawingNum = @idDrawingNum and projectId = @projectId)=0
	begin 
		insert into EstCostBuild values (@tag,@idDrawingNum,@projectId,@M2,@SHR,@SBHR,@SDHR,@SCOSTL,@SCOSTLB,@SCOSTLD,@SCOSTM,@SCOSTMB,@SCOSTMD,@SCOSTE,@SCOSTEB,@SCOSTED,@STCOST)
	end 
	else if (select COUNT(*) from EstCostBuild where tag = @tag and idDrawingNum = @idDrawingNum and projectId = @projectId)>0
	begin 
		update EstCostBuild set M2= @M2,SHR=@SHR,SBHR=@SBHR,SDHR=@SDHR,SCOSTL=@SCOSTL,SCOSTLB=@SCOSTLB,SCOSTLD=@SCOSTLD,SCOSTM=@SCOSTM,SCOSTMB=@SCOSTMB,SCOSTMD=@SCOSTMD,SCOSTE=@SCOSTE,SCOSTEB=@SCOSTEB,SCOSTED=@SCOSTED,STCOST=@STCOST where tag = @tag and idDrawingNum = @idDrawingNum and projectId = @projectId
	end
end
GO
--##############################################################################################
--################## SP INSERT UPDATE ESTIMARION COST DIMS #####################################
--##############################################################################################
--ALTER proc [dbo].[sp_insertUpdateEstCostDism]
CREATE proc [dbo].[sp_insertUpdateEstCostDism]
@tag as varchar(20),
@idDrawingNum as varchar(45),
@width as float,
@length as float,
@decks as int,
@idSCFUnitRate as varchar (35),
@idLaborRate as varchar (40)
as
declare @projectId varchar(30) = NULL
declare @M2 float = 0
declare @SHRD float = 0
declare @SBHRD float = 0
declare @BUILDPERCENT float = 0
declare @SDHRD float = 0
declare @DSCOSTL float = 0
declare @DSCOSTM float = 0
declare @SCOSTMBD float = 0
declare @DSCOSTMD float = 0
declare @SCOSTEBD float = 0
declare @BSCOSTEB float = 0
declare @SCOSTEDD float = 0
begin
	set @projectId = Convert(varchar, (select projectId from drawing where idDrawingNum = @idDrawingNum))
	set @M2 =  FORMAT(((ISNULL( @width,0)*ISNULL(@length,0)*ISNULL(@decks,0))/10.76391),'###.00')
	set @SHRD = ROUND(@M2 /(select laborB from scfUnitsRates where idSCFUR = @idSCFUnitRate ),1)
	set @BUILDPERCENT = (select dismantlePercent from scfUnitsRates where idSCFUR = @idSCFUnitRate)
	set @SBHRD = ROUND(@SHRD * (@BUILDPERCENT*0.01),1)
	set @SDHRD = ISNULL(@SHRD,0) - ISNULL(@SBHRD,0)

	set @DSCOSTL = ROUND(@SDHRD * (select scafRate from laborRate where idLaborRate = @idLaborRate),2)
	set @DSCOSTM = ROUND(@SHRD * (select materialD from scfUnitsRates where idSCFUR = @idSCFUnitRate),2)
	set @SCOSTMBD = ROUND(@SBHRD *(select materialD from scfUnitsRates where idSCFUR = @idSCFUnitRate),2)
	set @DSCOSTMD = @DSCOSTM - @SCOSTMBD
	set @SCOSTEBD = ROUND(@SHRD * (select equipmentD from scfUnitsRates where idSCFUR = @idSCFUnitRate),2)
	set @BSCOSTEB = ROUND(@SBHRD* (select equipmentD from scfUnitsRates where idSCFUR = @idSCFUnitRate),2)
	set @SCOSTEDD = @SCOSTEBD - @BSCOSTEB

	if (select COUNT(*) FROM EstCostDism where tag = @tag and idDrawingNum = @idDrawingNum and projectId = @projectId) = 0
	begin 
		insert into EstCostDism values (@tag,@idDrawingNum,@projectId,@M2,@SHRD,@SBHRD,@SDHRD,@DSCOSTL,@DSCOSTM,@SCOSTMBD,@DSCOSTMD,@SCOSTEBD,@BSCOSTEB,@SCOSTEDD)
	end
	else if (select COUNT(*) FROM EstCostDism where tag = @tag and idDrawingNum = @idDrawingNum and projectId = @projectId) > 0
	begin 
		update EstCostDism set M2 =@M2,SHRD = @SHRD,SBHRD = @SBHRD,SDHRD = @SDHRD,DSCOSTL = @DSCOSTL,DSCOSTM = @DSCOSTM,SCOSTMBD = @SCOSTMBD,DSCOSTMD = @DSCOSTMD,SCOSTEBD = @SCOSTEBD,BSCOSTEB = @BSCOSTEB,SCOSTEDD = @SCOSTEDD
	end
end
go
--##############################################################################################
--################## SP INSERT UPDATE ESTIMARION COST EQUIPMENT ################################
--##############################################################################################
--ALTER proc [dbo].[sp_insertUpdateEstCostEq] 
CREATE proc [dbo].[sp_insertUpdateEstCostEq] 
@idEquipmentEst as int,
@elevation as int,
@systemPntEq as varchar(10),
@pntOption as varchar(25),
@type as varchar(25),
@thick as float,
@idJacket as varchar(25),
@remIns as bit,
@idLaborRmv as varchar(40),
@sqrFtRmv as float ,
@idLaborPnt as varchar(40),
@sqrFtPnt as float,
@idLaborII as varchar(40),
@sqrFtII as float,
@bevel as float,
@cutout as float,
@acm as bit,
@idDrawingNum as varchar(45)
as
declare @IPEFFACTOR as float = 0
declare @projectId as varchar(30) = NULL
--REMOVAL
declare @IRESQF  as float = 0
declare @ACMH as float = 0
declare @EIRHRS as float = 0
declare @EIRCOSTL  as float = 0
declare @EIRCOSTM as float = 0
declare @EIRCOSTE as float = 0
declare @EIRTCOST as float = 0
--INSTALATION INSULATION
declare @IIESQF as float = 0
declare @EIIHRS as float = 0
declare @EIICOSTL as float = 0
declare @EIICOSTM as float = 0
declare @EIICOSTE as float = 0
declare @EIITCOST as float = 0
--PAINT 
declare @PESQF as float = 0
declare @EPHRS as float = 0
declare @EPCOSTL as float = 0
declare @EPCOSTM as float = 0
declare @EPCOSTE as float = 0
declare @EPTCOST as float = 0
declare @error as int  = 0
begin 
	set @projectId = (select projectId from drawing where idDrawingNum = @idDrawingNum)
	--REMOVAL
	set @IPEFFACTOR = (select top 1 [percent] from factorElevationPaint where elevation = @elevation)*0.01
	set @IRESQF = @sqrFtRmv * iif(@idLaborRmv is not NULL,1,0) 
	set @ACMH = ROUND( iif(@acm = 1 , (@IRESQF * (select top 1 isnull(laborProd,0) from eqInsUnitRate where [type] = @type and thick = @thick )* @IPEFFACTOR * (select top 1 laborProd from eqJktUnitRate where idJacket = @idJacket)),0)*3.5,1)
	set @EIRHRS = ROUND((@IRESQF * (select top 1 isnull(laborProd,0) from EqiRHC where [type] = @type and thickness = @thick) * @IPEFFACTOR * (select top 1 laborProd from eqJktUnitRate where idJacket = @idJacket)),1) + ISNULL(@ACMH,0)
	set @EIRCOSTL = ROUND((@EIRHRS * (select top 1 insRate from laborRate where idLaborRate = @idLaborRmv)) ,2)
	set @EIRCOSTM = ROUND((@IRESQF * (select top 1 isnull(matRate,0) from EqiRHC where [type] = @type and thickness = @thick) * (select top 1 isnull(matFactor,1) from eqJktUnitRate where idJacket = @idJacket)),2)
	set @EIRCOSTE = ROUND((@IRESQF * (select top 1 isnull(eqRate,0) from EqIRHC where [type] = @type and thickness = @thick) * (select top 1 isnull(eqFactor,1) from eqJktUnitRate where idJacket = @idJacket)),2) 
	set @EIRTCOST = ISNULL(@EIRCOSTL,0)+ISNULL(@EIRCOSTM,0)+ISNULL(@EIRCOSTE,0)
	--INTALATION INSULATION
	set @IIESQF = @sqrFtII + (@bevel * (select top 1 bebel from insfitting where [type] = @type)) + (@cutout * (select cutOut from insfitting where [type]=@type)) 
	set @EIIHRS = ROUND((@IIESQF * (select top 1 isnull(laborProd,0) from eqInsUnitRate where [type] = @type and thick = @thick) * @IPEFFACTOR * (select top 1 isnull(laborProd,1) from eqJktUnitRate where idJacket = @idJacket)),1)
	set @EIICOSTL = ROUND((@EIIHRS * (select top 1 insRate from laborRate where idLaborRate = @idLaborII)),2) 
	set @EIICOSTM = ROUND((@IIESQF * (select top 1 isnull(matRate,0) from eqInsUnitRate where [type] = @type and thick = @thick) * (select top 1 isnull(matFactor,1) from eqJktUnitRate where idJacket = @idJacket)),2) 
	set @EIICOSTE = ROUND((@IIESQF * (select top 1 isnull(eqRate,0) from eqInsUnitRate where [type] = @type and thick = @thick) * (select top 1 isnull(eqFactor,1) from eqJktUnitRate where idJacket = @idJacket)),2)
	set @EIITCOST = ISNULL(@EIICOSTL,0)+ISNULL(@EIICOSTM,0)+ISNULL(@EIICOSTE,0)
	--PAINT
	set @PESQF = ISNULL(@sqrFtPnt,0)
	set @EPHRS = ROUND((@PESQF * (select top 1 isnull(laborProd,0) from eqPaintUnitRate where systemPntEq = @systemPntEq and pntOption = @pntOption)  * @IPEFFACTOR),1)
	set @EPCOSTL = ROUND((@EPHRS *(select top 1 paintRate from laborRate where idLaborRate = @idLaborPnt)),2)
	set @EPCOSTM = ROUND((@PESQF * (select top 1 isnull(matRate,0) from eqPaintUnitRate where systemPntEq = @systemPntEq and pntOption = @pntOption)),2) 
	set @EPCOSTE = ROUND((@PESQF * (select top 1 isnull(eqRate,0) from eqPaintUnitRate where systemPntEq = @systemPntEq and pntOption = @pntOption)),2)
	set @EPTCOST = ISNULL(@EPCOSTL,0) + ISNULL(@EPCOSTM,0) + ISNULL(@EPCOSTE,0)
			
	if (select count(*) from EstCostEq where tag=@idEquipmentEst and idDrawingNum=@idDrawingNum and projectId = @projectId)= 0 
	begin  
		insert into EstCostEq values (@idEquipmentEst,@idDrawingNum,@projectId,@IRESQF,@ACMH,@EIRHRS,@EIRCOSTL,@EIRCOSTM,@EIRCOSTE,@EIRTCOST,@IIESQF,@EIIHRS,@EIICOSTL,@EIICOSTM,@EIICOSTE,@EIITCOST,@PESQF,@EPHRS,@EPCOSTL,@EPCOSTM,@EPCOSTE,@EPTCOST)
	end 
	else if(select count(*) from EstCostEq where tag=@idEquipmentest and idDrawingNum=@idDrawingNum and projectId = @projectId)>0 
	begin
		update EstCostEq set @IRESQF = @IRESQF,ACMH=@ACMH,EIRHRS= @EIRHRS,EIRCOSTL=@EIRCOSTL,EIRCOSTM=@EIRCOSTM,EIRCOSTE=@EIRCOSTE,EIRTCOST=@EIRTCOST,IIESQF=@IIESQF,EIIHRS=@EIIHRS,EIICOSTL=@EIICOSTL,EIICOSTM=@EIICOSTM,EIICOSTE=@EIICOSTE,EIITCOST=@EIITCOST,PESQF=@PESQF,EPHRS=@EPHRS,EPCOSTL=@EPCOSTL,EPCOSTM=@EPCOSTM,EPCOSTE=@EPCOSTE,EPTCOST=@EPTCOST where tag = @idEquipmentEst and idDrawingNum = @idDrawingNum and projectId = @projectId
	end
end
go
--##############################################################################################
--################## SP INSERT UPDATE ESTIMATION COST PIPING ###################################
--##############################################################################################
--ALTER proc [dbo].[sp_InsertUpdateEstCostPp]
CREATE proc [dbo].[sp_InsertUpdateEstCostPp]
@idPipingEst as int, 	
@size as float,
@type as varchar(25),
@thick as float,
@systemPntPP as varchar(10), 	
@pntOption as varchar(25), 
@idJacket as varchar(25),
@elevation as int,
@idLaborRateRmv	as varchar(40),
@lFtRmv	as float,
@idLaborRatePnt	as varchar(40),
@lFtPnt	as float,
@p90Pnt	as float,
@p45Pnt	as int,
@pTeePnt as int,	
@pPairPnt as int,
@pVlvPnt as int,
@pControlPnt as int,
@pWeldPnt as int,
@idLaborRateII as varchar(40),
@lFtII as float,
@p90II as int,
@p45II as int,
@pBendII as int,
@pTeeII as int,
@pReducII as int,	
@pCapsII as int,
@pPairII as int,
@pVlvII	as int,
@pControlII	as int,
@pWeldII as int,
@pCutOutII as int,
@psupportII	as int,
@acm as bit,
@idDrawingNum as varchar(45)
as
declare @projectId as varchar(45) = NULL
declare @error as bit = 0
declare @IPPEFFACTOR as float = 0
--REMOVAL
declare @IRELF as float =0
declare @ACMH as float =0
declare @PIRHRS as float =0
declare @PIRCOSTL as float =0
declare @PIRCOSTM as float =0
declare @PIRCOSTE as float =0
declare @PIRTCOST as float =0
--INSTALATION INSULATION
declare @IIELF as float =0
declare @PIIHRS as float =0
declare @PIICOSTL as float =0
declare @PIICOSTM as float =0
declare @PIICOSTE as float =0
declare @PIITCOST as float =0
--PAINT
declare @PESQF as float =0
declare @PPHRS as float =0
declare @PPCOSTL as float =0
declare @PPCOSTM as float =0
declare @PPCOSTE as float =0
declare @PPTCOST as float =0 
begin 
	set @projectId = (select projectId from drawing where idDrawingNum = @idDrawingNum)
	--REMOVAl
	set @IPPEFFACTOR = (select ISNULL([percent],0) from factorElevationPaint where elevation = @elevation)*0.01
	set @IRELF=  @lFtRmv * IIF(@idLaborRateRmv is not NULL,1,0)
	set @ACMH= ROUND(IIF(@ACM = 1, @IRELF * (select laborProd from PpIRHC where size =@size and [type]= @type and thickness = @thick) * @IPPEFFACTOR * (select top 1 laborProd from ppJktUnitRate where idJacket = @idJacket),0)*3,1)
	set @PIRHRS= ROUND((@IRELF * (select top 1 laborProd from PpIRHC where size =@size and [type]= @type and thickness = @thick) * @IPPEFFACTOR * (select top 1 laborProd from ppJktUnitRate where idJacket = @idJacket) + ISNULL(@ACMH,0)),0)
	set @PIRCOSTL= ROUND(@PIRHRS * (select top 1 insRate from laborRate where idLaborRate = @idLaborRateRmv),2) 
	set @PIRCOSTM= ROUND(@IRELF * (select top 1 matRate from PpIRHC where size =@size and [type]= @type and thickness = @thick) * (select top 1 matFactor from ppJktUnitRate where idJacket = @idJacket),2)
	set @PIRCOSTE= ROUND(@IRELF * (select top 1 eqRate from PpIRHC where size =@size and [type]= @type and thickness = @thick) * (select top 1 eqFactor from ppJktUnitRate where idJacket = @idJacket) ,2) 
	set @PIRTCOST= ISNULL(@PIRCOSTL,0)+ISNULL(@PIRCOSTM ,0)+ISNULL(@PIRCOSTE ,0) 
	--INSTALATION INSULATION
	set @IIELF= (@lFtII + (@p90II * (select top 1 p90 from insFitting where [type] = @type)) + (@p45II * (select top 1 p45 from insFitting where [type] = @type) ) + ( @pBendII * (select top 1 bend from insFitting where [type] = @type) ) + ( @pTeeII * (select top 1 tee from insFitting where [type] = @type) ) + ( @pReducII * (select top 1 red from insFitting where [type] = @type) ) + ( @pCapsII * (select top 1 cap from insFitting where [type] = @type) ) + ( @pPairII * (select top 1 flangePair from insFitting where [type] = @type) ) + ( @pVlvII * (select top 1 flangeVlv from insFitting where [type] = @type) ) + ( @pControlII * (select top 1 controlVlv from insFitting where [type] = @type) ) + ( @pWeldII * (select top 1 weldedVlv from insFitting where [type] = @type) ) + ( @pCutOutII * (select top 1 cutOut from insFitting where [type] = @type)) + ( @psupportII * (select top 1 support from insFitting where [type] = @type)))
	set @PIIHRS= ROUND(@IIELF * (select top 1 laborProd from ppInsUnitRate where size = @size and [type] = @type and thick = @thick) * @IPPEFFACTOR * (select top 1 laborProd from ppJktUnitRate where idJacket = @idJacket),1)
	set @PIICOSTL= ROUND(@PIIHRS * (select top 1 insRate from laborRate where idLaborRate = @idLaborRateII),2)
	set @PIICOSTM= ROUND(@IIELF * (select top 1 matRate from ppInsUnitRate where size = @size and thick = @thick and [type] = @type) * (select top 1 matFactor from ppJktUnitRate where idJacket = @idJacket),2)
	set @PIICOSTE= ROUND(@IIELF * (select top 1 eqRate from ppInsUnitRate where size = @size and thick = @thick and [type] = @type) * (select top 1 eqFactor from ppJktUnitRate where idJacket = @idJacket) ,2) 
	set @PIITCOST= ISNULL( @PIICOSTL ,0)+ISNULL( @PIICOSTM ,0)+ISNULL( @PIICOSTE ,0)
	--PAINT
	set @PESQF= IIF(@size<=3, 1, @size / 3.82 )* ( @lFtPnt + (@p90Pnt * (select top 1 p90 from pntFitting where pntOption = @pntOption))+ ( @p45Pnt * (select top 1 p45 from pntFitting where pntOption = @pntOption))+ ( @pTeePnt * (select top 1 tee from pntFitting where pntOption = @pntOption))+ ( @pPairPnt * (select flangePair from pntFitting where pntOption = @pntOption))+ ( @pVlvPnt * (select flangeVlv from pntFitting where pntOption = @pntOption))+ ( @pControlPnt * (select controlVlv from pntFitting where pntOption = @pntOption))+ ( @pWeldPnt * (select weldedVlv from pntFitting where pntOption = @pntOption)))
	set @PPHRS= ROUND(@PESQF * (select top 1 laborProd from ppPaintUnitRate where systemPntPP = @systemPntPP and pntOption = @pntOption and size = @size) * @IPPEFFACTOR ,1)
	set @PPCOSTL= ROUND(@PPHRS * (select top 1 paintRate from laborRate where idLaborRate = @idLaborRatePnt),2)
	set @PPCOSTM= ROUND(@PESQF * (select top 1 matRate from ppPaintUnitRate where size = @size and pntOption = @pntOption and systemPntPP = @systemPntPP),2) 
	set @PPCOSTE= ROUND(@PESQF * (select top 1 eqRate from ppPaintUnitRate where size = @size and pntOption = @pntOption and systemPntPP = @systemPntPP),2) 
	set @PPTCOST= ISNULL(@PPCOSTL ,0)+ISNULL(@PPCOSTM ,0)+ISNULL(@PPCOSTE ,0)
	if(select COUNT(*) from EstCostPp where tag = @idPipingEst and idDrawingNum = @idDrawingNum and projectId = @projectId)=0
	begin
		insert into EstCostPp values(@idPipingEst ,CONVERT(NVARCHAR, @idDrawingNum),@projectId,@IRELF,@ACMH,@PIRHRS,@PIRCOSTL,@PIRCOSTM,@PIRCOSTE,@PIRTCOST,@IIELF,@PIIHRS,@PIICOSTL,@PIICOSTM,@PIICOSTE,@PIITCOST,@PESQF,@PPHRS,@PPCOSTL,@PPCOSTM,@PPCOSTE,@PPTCOST)
	end
	else if(select COUNT(*) from EstCostPp where tag = @idPipingEst and idDrawingNum = @idDrawingNum and projectId = @projectId)>0
	begin
		update EstCostPp set IRELF = @IRELF ,ACMH = @ACMH,PIRHRS = @PIRHRS,PIRCOSTL = @PIRCOSTL,PIRCOSTM = @PIRCOSTM,PIRCOSTE = @PIRCOSTE,PIRTCOST = @PIRTCOST,IIELF = @IIELF,PIIHRS = @PIIHRS,PIICOSTL = @PIICOSTL,PIICOSTM = @PIICOSTM,PIICOSTE = @PIICOSTE,PIITCOST = @PIITCOST,PESQF = @PESQF,PPHRS = @PPHRS,PPCOSTL = @PPCOSTL,PPCOSTM = @PPCOSTM,PPCOSTE = @PPCOSTE,PPTCOST = @PPTCOST where tag = @idPipingEst and idDrawingNum = @idDrawingNum and projectId = @projectId
	end
end
go
--##############################################################################################
--################## SP INSERT UPDATE ESTIMARION COST SCAFFOLD #################################
--##############################################################################################
--ALTER proc [dbo].[sp_insertUpdateEstCostScf]
CREATE proc [dbo].[sp_insertUpdateEstCostScf]
@tagEst as varchar(20),
@days as int,
@width as float,
@length as float,
@heigth as float,
@decks as int,
@build as int,
@idLabor as varchar(40),
@idSCFUR as varchar(35),
@idDrawingNum as varchar(45)
as
declare @idProjectEst as varchar(30) = Null
declare @M2 as float = 0
declare @SHRD as float = 0
declare @SBHRD as float = 0
declare @SDHRD as float = 0
declare @DSCOSTL as float = 0
declare @DSCOSTM as float = 0
declare @SCOSTMBD as float = 0
declare @DSCOSTMD as float = 0
declare @SCOSTEBD as float = 0
declare @BSCOSTEB as float = 0
declare @SCOSTEDD  as float = 0
declare @SCM as float = 0
declare @SHR as float = 0
declare @SBHR as float = 0
declare @SDHR as float = 0
declare @SCOSTL as float = 0
declare @SCOSTLB as float = 0
declare @SCOSTLD as float = 0
declare @SCOSTM as float = 0
declare @SCOSTMB as float = 0
declare @SCOSTMD as float = 0
declare @SCOSTE as float = 0
declare @SCOSTEB as float = 0
declare @SCOSTED as float = 0
declare @STCOST as float = 0
declare @STCOSTB as float = 0
declare @STCOSTD as float = 0
declare @buildPercent as float = 0
declare @dismantlePercent as float = 0
begin
	set @idProjectEst = (select projectId from drawing where idDrawingNum = @idDrawingNum)
	set @M2 = FORMAT(((ISNULL( @width,0)*ISNULL(@length,0)*ISNULL(@decks,0))/10.76391),'###.00')
	set @SHRD = ROUND((@M2/(select laborB from scfUnitsRates where idSCFUR = @idSCFUR)),1)
	set @dismantlePercent = (select dismantlePercent from scfUnitsRates where idSCFUR = @idSCFUR)
	set @SBHRD = ROUND(( @SHRD * (@dismantlePercent*0.01)),1)
	set @SDHRD = @SHRD - @SBHRD

	set @DSCOSTL = ROUND((@SBHRD * (select scafRate from laborRate where idLaborRate = @idLabor)),2) + ROUND((@SDHRD * (select scafRate from laborRate where idLaborRate = @idLabor)),2)
	set @DSCOSTM = ROUND((@SHRD * (select materialD from scfUnitsRates where idSCFUR = @idSCFUR)),2)
	set @SCOSTMBD = ROUND((@SBHRD * (select materialD from scfUnitsRates where idSCFUR = @idSCFUR)),2)
	set @DSCOSTMD = @DSCOSTM - @SCOSTMBD
				
	set @SCOSTEBD = ROUND((@SHRD * (select equipmentD from scfUnitsRates where idSCFUR = @idSCFUR)),2)
	set @BSCOSTEB = ROUND((@SBHRD * (select equipmentD from scfUnitsRates where idSCFUR = @idSCFUR)),2)
	set @SCOSTEDD = (@SCOSTEBD - @BSCOSTEB)

	set @SCM = ROUND(((@width * @heigth * @length)/35.3),2)
	set @SHR = ROUND((@SCM / (select top 1 laborD from scfUnitsRates where idSCFUR = @idSCFUR)),1)
	set @buildPercent = (select top 1 buildPercent from scfUnitsRates where idSCFUR = @idSCFUR)
	set @SBHR = ROUND((@SHR * (@buildPercent*0.01)),1)
	set @SDHR = @SHR - @SBHR

	set @SCOSTL = (ROUND((@SBHR * (select top 1 scafRate from laborRate where idLaborRate = @idLabor)),2) + ROUND((@SDHR * (select top 1 scafRate from laborRate where idLaborRate = @idLabor)),2))
	set @SCOSTLB = ROUND((@SBHR * (select top 1 scafRate from laborRate where idLaborRate = @idLabor)),2)
	set @SCOSTLD = @SCOSTL - @SCOSTLB		
	set @SCOSTM = ROUND((@SHR * (select top 1 materialB from scfUnitsRates where idSCFUR = @idSCFUR)),2)
	set @SCOSTMB = ROUND((@SBHR * (select top 1 materialB from scfUnitsRates where idSCFUR = @idSCFUR)),2)
	set @SCOSTMD = @SCOSTM - @SCOSTMB
				
	set @SCOSTE = ROUND((@SHR * (select top 1 equipmentB from scfUnitsRates where idSCFUR = @idSCFUR)),2) 
	set @SCOSTEB = ROUND((@SBHR * (select top 1 equipmentB from scfUnitsRates where idSCFUR = @idSCFUR)),2)
	set @SCOSTED = @SCOSTE - @SCOSTEB	

	set @STCOST = ISNULL(@SCOSTL,0) + ISNULL(@SCOSTM,0) + ISNULL(@SCOSTE,0)
	set @STCOSTB = ISNULL(@SCOSTLB,0) + ISNULL(@SCOSTMB,0) + ISNULL(@SCOSTEB,0)
	set @STCOSTD = ISNULL(@SCOSTLD,0) + ISNULL(@SCOSTMD,0) + ISNULL(@SCOSTED,0)
				 
	if (select count(*) from EstCostScf where tag=@tagEst and idDrawingNum=@idDrawingNum and projectId = @idProjectEst)= 0 
	begin  
		insert into EstCostScf values (@tagEst,@idDrawingNum,@idProjectEst,@M2, @SHRD ,@SBHRD ,@DSCOSTL ,@DSCOSTM ,@SCOSTMBD ,@DSCOSTMD ,@SCOSTEBD ,@BSCOSTEB ,@SCOSTEDD ,@SCM ,@SHR ,@SBHR ,@SDHR ,@SCOSTL ,@SCOSTLB ,@SCOSTLD ,@SCOSTM ,@SCOSTMB ,@SCOSTMD ,@SCOSTE ,@SCOSTEB ,@SCOSTEBD ,@STCOST ,@STCOSTB ,@STCOSTD)
		exec sp_insertUpdateEstCostBuild @tagEst,@idDrawingNum,@width,@length,@decks,@idSCFUR,@idLabor
		exec sp_insertUpdateEstCostDism @tagEst,@idDrawingNum,@width,@length,@decks,@idSCFUR,@idLabor
	end 
	else if(select count(*) from EstCostScf where tag=@tagEst and idDrawingNum=@idDrawingNum and projectId = @idProjectEst)>0 
	begin
		update EstCostScf set M2 = @M2, SHRD = @SHRD , DSCOSTL = @DSCOSTL, DSCOSTM = @DSCOSTM, SCOSTMBD = @SCOSTMBD,DSCOSTMD = @DSCOSTMD,SCOSTEBD = @SCOSTEBD,BSCOSTEB = @BSCOSTEB, SCOSTEDD = @SCOSTEDD, SCM = @SCM,SHR = @SHR,SBHR = @SBHR,SDHR =@SDHR,SCOSTL = @SCOSTL,SCOSTLB = @SCOSTLB, SCOSTLD = @SCOSTLD,SCOSTM = @SCOSTM,SCOSTMB = @SCOSTMB,SCOSTMD = @SCOSTMD,SCOSTE = @SCOSTE,SCOSTEB = @SCOSTEB,SCOSTED = @SCOSTED,STCOST = @STCOST,STCOSTB = @STCOSTB,STCOSTD = @STCOSTD where tag = @tagEst and idDrawingNum = @idDrawingNum and projectId = @idProjectEst
		exec sp_insertUpdateEstCostBuild @tagEst,@idDrawingNum,@width,@length,@decks,@idSCFUR,@idLabor
		exec sp_insertUpdateEstCostDism @tagEst,@idDrawingNum,@width,@length,@decks,@idSCFUR,@idLabor
	end
end
GO
----#########################################################################################################################################################################################
----######## PROCEDIMIENTO PARA INSERTAR Y ACTUALIZAR RFI EQUIPMENT #########################################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_insertUpdateRFIEquipmentEst]
CREATE proc [dbo].[sp_insertUpdateRFIEquipmentEst]
	@idRFIEq varchar(35),
	@tag int,
	@idDrawingNum varchar(45)
as
	declare @Elevation as int = 1
	declare @WwPaint as varchar(40) = NULL
	declare @System as varchar(10) = NULL 
	declare @Option as varchar(25) = NULL
	declare @SqrFtPnt as float = 0 
	declare @WwRemove as varchar(40) = NULL
	declare @Remove as bit= 0 
	declare @SqrFtRmv as float = 0
	declare @WwInstall as varchar(40) = NULL 
	declare @Type as varchar(25) = NULL
	declare @Thick as float = 0 
	declare @Jacket as varchar(25) = NULL
	declare @SqrFtII as float =0  
	declare @Bevel as float =0 
	declare @CutOut as float = 0
	declare @oIRESQF as float = 0
	declare @oEIRHRS as float = 0
	declare @oEIRCOSTL as float = 0
	declare @oEIRCOSTM as float = 0
	declare @oEIRCOSTE as float = 0
	declare @oEIRTCOST as float = 0
	declare @oIIESQF as float = 0
	declare @oEIIHRS as float = 0
	declare @oEIICOSTL as float = 0
	declare @oEIICOSTM as float = 0
	declare @oEIICOSTE as float = 0
	declare @oEIITCOST as float = 0
	declare @oEPHRS as float = 0
	declare @oEPCOSTL as float = 0
	declare @oEPCOSTM  as float = 0
	declare @oEPCOSTE  as float = 0
	declare @oEPTCOST  as float = 0
	declare @nIRESQF as float = 0
	declare @nEIRHRS as float = 0
	declare @nEIRCOSTL as float = 0
	declare @nEIRCOSTM as float = 0
	declare @nEIRCOSTE as float = 0
	declare @nEIRTCOST as float = 0
	declare @nIIESQF as float = 0
	declare @nEIIHRS as float = 0 
	declare @nEIICOSTL as float = 0
	declare @nEIICOSTM as float = 0
	declare @nEIICOSTE as float = 0
	declare @nEIITCOST as float = 0
	declare @nEPHRS as float = 0
	declare @nEPCOSTL as float = 0
	declare @nEPCOSTM as float = 0
	declare @nEPCOSTE as float = 0
	declare @nEPTCOST as float = 0

	declare @laborPrEqUR as float = 0
	declare @matRateEqUR as float = 0
	declare @eqRateEqUR as float = 0
	declare @percent as float = 0
	declare @laborPrJkt as float = 0 
	declare @matFacJkt as float = 0
	declare @eqFacJkt as float = 0
	declare @insRate as float = 0 
	declare @bevelIf as float = 0
	declare @cutOutIf as float = 0
begin
	--CARGAERMOS LA INFORMACION DEL RFI EQUIPMENT DE LOS DATOS ANTERIORES (old)
	select @Elevation = oldElevation,@WwPaint=oldWwPaint,@System=oldSystem,@Option=oldOption,@SqrFtPnt=oldSqrFtPnt,
	@WwRemove=oldWwRemove,@Remove=oldRemove,@SqrFtRmv=oldSqrFtRmv,
	@WwInstall=oldWwInstall,@Type=oldType,@Thick=oldThick,@Jacket=oldJacket,@SqrFtII=oldSqrFtII,@Bevel=oldBevel,@CutOut=oldCutOut 
	from RFIEquipment where idRFIEq = @idRFIEq and tag = @tag and idDrawingNum=@idDrawingNum
	select @laborPrEqUR = laborProd, @matRateEqUR = matRate,@eqRateEqUR=eqRate from eqInsUnitRate where [type] = @Type and thick=@Thick
	select @percent = [percent] from factorElevationPaint where elevation = @Elevation 
	set @percent = IIF(ISNULL(@percent,1)=1,0,@percent*0.01)
	select @laborPrJkt=laborProd,@matFacJkt = matFactor,@eqFacJkt=eqFactor from eqJktUnitRate where idJacket = @Jacket
	select @bevelIf=bebel,@cutOutIf=cutOut from insFitting where [type]= @Type
	--HACEMOS LAS OPERACIONES PARA LOS VALORES OLD
	set @oIRESQF= @SqrFtRmv * IIF(@Remove=1,1,0)
	set @oEIRHRS= ROUND(@oIRESQF * @laborPrEqUR * @percent * @laborPrJkt,1)
	select @insRate = insRate from laborRate where idLaborRate = @WwRemove --ESTE SE DEBE DE ACTUALIZAR DEBIDO A LA QUE PUEDE CAMBIAR EL VALOR
	set @oEIRCOSTL= ROUND(@oEIRHRS * @insRate,2) 
	set @oEIRCOSTM= ROUND(@SqrFtRmv * @matRateEqUR * @matFacJkt,2)
	set @oEIRCOSTE= ROUND(@SqrFtRmv * @eqRateEqUR * @eqFacJkt,2)
	set @oEIRTCOST= ISNULL(@oEIRCOSTL,0)+ISNULL(@oEIRCOSTM,0)+ISNULL(@oEIRCOSTE,0)

	set @oIIESQF= ROUND(@SqrFtII+(@Bevel*@bevelIf)+(@CutOut*@cutOutIf),2)
	set @oEIIHRS= ROUND(@oIIESQF * @laborPrEqUR * @percent * @laborPrJkt,1)
	select @insRate = insRate from laborRate where idLaborRate = @WwInstall --SE ACTUALIZA CON EL LABOR DE INSTALL
	set @oEIICOSTL= ROUND(@oEIIHRS * @insRate,2)
	set @oEIICOSTM= ROUND(@oIIESQF * @matRateEqUR * @matFacJkt,2)
	set @oEIICOSTE= ROUND(@oIIESQF * @eqRateEqUR * @eqFacJkt,2)
	set @oEIITCOST= ISNULL(@oEIICOSTL,0)+ISNULL(@oEIICOSTM,0)+ISNULL(@oEIICOSTE,0)

	select @laborPrEqUR = laborProd, @matRateEqUR = matRate,@eqRateEqUR=eqRate from eqPaintUnitRate where systemPntEq = @System and pntOption= @Option

	set @oEPHRS= ROUND(@SqrFtPnt * @laborPrEqUR * @percent ,1)
	select @insRate = insRate from laborRate where idLaborRate = @WwPaint
	set @oEPCOSTL= ROUND(@oEPHRS * @insRate ,2)
	set @oEPCOSTM= ROUND(@SqrFtPnt * @matRateEqUR,2)
	set @oEPCOSTE= ROUND(@SqrFtPnt * @eqRateEqUR,2)
	set @oEPTCOST= ISNULL(@oEPCOSTL,0)+ISNULL(@oEPCOSTM,0)+ISNULL(@oEPCOSTE,0)
	
	--CARGAMOS LOS DATOS PARA LAS FORMULAS DE NEW 
	select @Elevation=newElevation,@WwPaint=newWwPaint,@System=newSystem,@Option=newOption,@SqrFtPnt=newSqrFtPnt,
	@WwRemove=newWwRemove,@Remove=newRemove,@SqrFtRmv=newSqrFtRmv,
	@WwInstall=newWwInstall,@Type=newType,@Thick=newThick,@Jacket=newJacket,@SqrFtII=newSqrFtII,@Bevel=newBevel,@CutOut=newCutOut 
	from RFIEquipment where idRFIEq = @idRFIEq and tag = @tag and idDrawingNum=@idDrawingNum
	select @laborPrEqUR = laborProd, @matRateEqUR = matRate,@eqRateEqUR=eqRate from eqInsUnitRate where [type] = @Type and thick=@Thick
	select @laborPrJkt=laborProd,@matFacJkt = matFactor,@eqFacJkt=eqFactor from eqJktUnitRate where idJacket = @Jacket
	select @percent = [percent] from factorElevationPaint where elevation = @Elevation 
	set @percent = IIF(ISNULL(@percent,1)=1,0,@percent*0.01)
	select @bevelIf=bebel,@cutOutIf=cutOut from insFitting where [type]= @Type
	--HACEMOS LAS OPERACIONES DE NEW
	set @nIRESQF= @SqrFtRmv * IIF(@Remove=1,1,0)
	set @nEIRHRS= ROUND(@nIRESQF * @laborPrEqUR * @percent * @laborPrJkt,1)
	select @insRate = insRate from laborRate where idLaborRate = @WwRemove
	set @nEIRCOSTL= ROUND(ROUND(@nIRESQF * @laborPrEqUR * @percent * @laborPrJkt,1) * @insRate,2)
	set @nEIRCOSTM= RoUND(@nIRESQF * @matRateEqUR * @matFacJkt ,2)
	set @nEIRCOSTE= ROUND(@nIRESQF * @eqRateEqUR * @eqFacJkt,2)
	set @nEIRTCOST= ISNULL(@nEIRCOSTL,0)+ISNULL(@nEIRCOSTM,0)+ISNULL(@nEIRCOSTE,0)

	set @nIIESQF= ROUND(@SqrFtII + (@Bevel * @bevelIf) + (@CutOut * @cutOutIf),2)
	set @nEIIHRS= ROUND(@nIIESQF * @laborPrEqUR * @percent * @laborPrJkt ,1)
	select @insRate = insRate from laborRate where idLaborRate = @WwInstall
	set @nEIICOSTL= ROUND(ROUND(@nIIESQF * @laborPrEqUR * @percent * @laborPrJkt,1)* @insRate,2)
	set @nEIICOSTM= ROUND(@nIIESQF * @matRateEqUR * @matFacJkt ,2)
	set @nEIICOSTE= ROUND(@nIIESQF * @eqRateEqUR * @eqFacJkt ,2)
	set @nEIITCOST= ISNULL(@nEIICOSTL,0)+ISNULL(@nEIICOSTM,0)+ISNULL(@nEIICOSTE,0)

	select @laborPrEqUR = laborProd, @matRateEqUR = matRate,@eqRateEqUR=eqRate from eqPaintUnitRate where systemPntEq = @System and pntOption= @Option
	
	set @nEPHRS= ROUND(@SqrFtPnt * @laborPrEqUR * @percent,1)
	select @insRate = insRate from laborRate where idLaborRate = @WwPaint
	set @nEPCOSTL= ROUND(ROUND(@SqrFtPnt * @laborPrEqUR * @percent,1) * @insRate,2)
	set @nEPCOSTM= ROUND(@SqrFtPnt * @matRateEqUR ,2)
	set @nEPCOSTE= ROUND(@SqrFtPnt * @eqRateEqUR ,2)
	set @nEPTCOST= ISNULL(@nEPCOSTL,0)+ISNULL(@nEPCOSTM,0)+ISNULL(@nEPCOSTE,0)

	if (select COUNT(*)from RFIDiffEq where idDrawingNum=@idDrawingNum and tag= @tag and idRFIEq = @idRFIEq )=0
	begin
		insert into RFIDiffEq values (@idRFIEq,@tag,@idDrawingNum,@oIRESQF,@oEIRHRS,@oEIRCOSTL,@oEIRCOSTM,@oEIRCOSTE,@oEIRTCOST,@oIIESQF,@oEIIHRS,@oEIICOSTL,@oEIICOSTM,@oEIICOSTE,@oEIITCOST,@oEPHRS,@oEPCOSTL,@oEPCOSTM,@oEPCOSTE,@oEPTCOST,@nIRESQF,@nEIRHRS,@nEIRCOSTL,@nEIRCOSTM,@nEIRCOSTE,@nEIRTCOST,@nIIESQF,@nEIIHRS,@nEIICOSTL,@nEIICOSTM,@nEIICOSTE,@nEIITCOST,@nEPHRS,@nEPCOSTL,@nEPCOSTM,@nEPCOSTE,@nEPTCOST)	
	end	else if (select COUNT(*)from RFIDiffEq where idDrawingNum=@idDrawingNum and tag= @tag and idRFIEq = @idRFIEq )=1
	begin
		update RFIDiffEq set  
		oIRESQF = @oIRESQF,oEIRHRS = @oEIRHRS,oEIRCOSTL = @oEIRCOSTL,oEIRCOSTM = @oEIRCOSTM,oEIRCOSTE = @oEIRCOSTE,oEIRTCOST = @oEIRTCOST,
		oIIESQF = @oIIESQF,oEIIHRS = @oEIIHRS,oEIICOSTL = @oEIICOSTL,oEIICOSTM = @oEIICOSTM,oEIICOSTE = @oEIICOSTE,oEIITCOST = @oEIITCOST,
		oEPHRS = @oEPHRS,oEPCOSTL = @oEPCOSTL,oEPCOSTM = @oEPCOSTM,oEPCOSTE = @oEPCOSTE,oEPTCOST = @oEPTCOST,
		nIRESQF = @nIRESQF,nEIRHRS = @nEIRHRS,nEIRCOSTL = @nEIRCOSTL,nEIRCOSTM = @nEIRCOSTM,nEIRCOSTE = @nEIRCOSTE,nEIRTCOST = @nEIRTCOST,
		nIIESQF = @nIIESQF,nEIIHRS = @nEIIHRS,nEIICOSTL = @nEIICOSTL,nEIICOSTM = @nEIICOSTM,nEIICOSTE = @nEIICOSTE,nEIITCOST = @nEIITCOST,
		nEPHRS = @nEPHRS,nEPCOSTL = @nEPCOSTL,nEPCOSTM = @nEPCOSTM,nEPCOSTE = @nEPCOSTE,nEPTCOST = @nEPTCOST 
		where idRFIEq = @idRFIEq and tag =  @tag and idDrawingNum = @idDrawingNum
	end
end
GO
----#########################################################################################################################################################################################
----######## PROCEDIMIENTO INSERT Y UPDATE RFI PIPING DIFF ##################################################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_insertUpdateRFIPipingEst]
CREATE proc [dbo].[sp_insertUpdateRFIPipingEst]
	@idRFIPp varchar(35),
	@tag int,
	@idDrawingNum varchar(45)
as
	--INFO PIPING
	declare @Size as float 
	declare @Elevation as int 
	declare @System as varchar(10) 
	declare @Option as varchar(25) 
	declare @Type as varchar(25) 
	declare @Thick as float 
	declare @IdJacket as varchar(25)
    declare @IdLaborRatePnt as varchar(40) 
	declare @LFtPnt as float 
	declare @P90Pnt as int 
	declare @P45Pnt as int 
	declare @PTeePnt as int 
	declare @PPairPnt as int 
	declare @PVlvPnt as int
	declare @PControlPnt as int 
	declare @PWeldPnt as int
	declare @IdLaborRateRmv as varchar(40) 
	declare @LFtRmv as float 
    declare @IdLaborRateII as varchar(40) 
	declare @LFtII as float
	declare @P90II as int 
	declare @P45II as int 
	declare @PBendII as int 
	declare @PTeeII as int 
	declare @PReducII as int 
	declare @PCapsII as int 
	declare @PPairII as int 
	declare @PVlvII as int 
	declare @PControlII as int 
	declare @PWeldII as int 
	declare @PCutOutII as int 
	declare @PsupportII as int
	--EXTRA INFO 
	declare @PIUPL as float = 0
	declare @PJKTL as float = 0
	declare @percent as float = 0
	declare @insRate as float = 0
	declare @PIUPM as float = 0
	declare @PJKTM as float =0
	declare @PIUPE as float = 0
	declare @PJKTE as float =0 

	declare @IFF90 as float =0 
	declare @IFF45 as float =0
	declare @IFFBEND as float = 0
	declare @IFFTEE as float = 0
	declare @IFFREDUC as float = 0
	declare @IFFCAP as float =0
	declare @IFFPAIR as float = 0
	declare @IFFVLV as float = 0
	declare @IFFCONTROL as float = 0
	declare @IFFWELD as float = 0
	declare @IFFCUTOUT as float = 0
	declare @IFFSUP as float = 0

	declare @PFF90 as float = 0
	declare @PFF45 as float = 0
	declare @PFFTEE as float = 0
	declare @PFFPAIR as float = 0
	declare @PFFVLV as float = 0
	declare @PFFCONTROL as float = 0
	declare @PFFWLED as float = 0

	declare @PPUPL as float = 0
	declare @PPUPM as float = 0
	declare @PPUPE as float = 0
	declare @pntRate as float = 0
	--VARIABLES PARA OLD
	--REMOVE OLD
	declare @oPIRHRS as float = 0 
	declare @oPIRCOSTL as float = 0
	declare @oPIRCOSTM as float = 0
	declare @oPIRCOSTE as float = 0
	declare @oPIRTCOST as float = 0 
	--INSULATION OLD
	declare @oIIELF as float =0
	
	declare @oPIIHRS as float = 0
	declare @oPIICOSTL as float = 0
	declare @oPIICOSTM as float = 0
	declare @oPIICOSTE as float = 0
	declare @oPIITCOST as float = 0
	--PAINT OLD
	declare @oPESQF as float = 0
	
	declare @oPPHRS as float = 0 
	
	declare @oPPCOSTL as float = 0
	declare @oPPCOSTM as float = 0
	declare @oPPCOSTE as float = 0
	declare @oPPTCOST as float = 0
	--REMOVE NEW 
	declare @nPIRHRS as float = 0
	declare @nPIRCOSTL as float = 0
	declare @nPIRCOSTM as float = 0
	declare @nPIRCOSTE as float = 0
	declare @nPIRTCOST as float = 0
	--INSTALATION NEW
	declare @nIIELF as float = 0
	declare @nPIIHRS as float = 0
	declare @nPIICOSTL as float = 0
	declare @nPIICOSTM as float = 0
	declare @nPIICOSTE as float = 0
	declare @nPIITCOST as float = 0
	--PAINT NEW 
	declare @nPESQF as float = 0
	declare @nPPHRS as float = 0
	declare @nPPCOSTL as float =0
	declare @nPPCOSTM as float = 0 
	declare @nPPCOSTE as float = 0
	declare @nPPTCOST as float = 0
begin 

	--OLD VALUES
	select  
		@Size = oldSize ,@Elevation   = oldElevation ,@System   = oldSystem ,@Option   = oldOption ,@Type  = oldType ,@Thick   = oldThick ,@IdJacket  = oldIdJacket ,
		@IdLaborRatePnt  = oldIdLaborRatePnt ,@LFtPnt   = oldLFtPnt ,@P90Pnt   = oldP90Pnt ,@P45Pnt   = oldP45Pnt ,@PTeePnt   = oldPTeePnt ,@PPairPnt   = oldPPairPnt ,@PVlvPnt  = oldPVlvPnt ,@PControlPnt   = oldPControlPnt ,@PWeldPnt  = oldPWeldPnt ,
		@IdLaborRateRmv = oldIdLaborRateRmv ,@LFtRmv   = oldLFtRmv ,
		@IdLaborRateII  = oldIdLaborRateII ,@LFtII  = oldLFtII ,@P90II   = oldP90II ,@P45II   = oldP45II ,@PBendII   = oldPBendII ,@PTeeII   = oldPTeePnt ,	@PReducII   = oldPReducII ,@PCapsII   = oldPCapsII ,@PPairII   = oldPPairII ,@PVlvII   = oldPVlvII ,@PControlII   = oldPControlII ,@PWeldII   = oldPWeldII ,@PCutOutII   = oldPCutOutII ,@PsupportII  = oldPsupportII 
	from RFIPiping where idDrawingNum = @idDrawingNum and tag = @tag and idRFIPp = @idRFIPp

	set @percent = (select [percent] from factorElevationPaint where elevation = @Elevation)
	set @percent = IIF(ISNULL(@percent,1)=1,0,@percent*0.01)
	set @insRate =(select insRate from laborRate where idLaborRate = @IdLaborRateRmv)
	
	set @PIUPL = (select top 1 laborProd from ppInsUnitRate where size=@Size and [type]=@Type and [thick]=@Thick)
	set @PIUPM = (select top 1 matRate from ppInsUnitRate where size=@Size and [type]=@Type and [thick]=@Thick)
	set @PIUPE = (select top 1 eqRate from ppInsUnitRate where size=@Size and [type]=@Type and [thick]=@Thick)
	
	set @PJKTL = (select top 1 laborProd from ppJktUnitRate where idJacket = @IdJacket)
	set @PJKTM = (select top 1 matFactor from ppJktUnitRate where IdJacket = @IdJacket)
	set @PJKTE = (select top 1 eqFactor from ppJktUnitRate where idJacket = @IdJacket)
	
	-- INSULATION REMOVE
	
	set @oPIRHRS = ROUND(@LFtRmv*@PIUPL*@percent*@PJKTL,1)
	set @oPIRCOSTL = ROUND(@oPIRHRS*@insRate,2)
	set @oPIRCOSTM = ROUND(@LFtRmv*@PIUPM*@PJKTM,2)
	set @oPIRCOSTE = ROUND(@LFtRmv*@PIUPE*@PJKTE,2)
	set @oPIRTCOST= ROUND(ISNULL(@oPIRCOSTL,0)+ISNULL(@oPIRCOSTM,0)+ISNULL(@oPIRCOSTE,0),2)
	
	--INSULATION RATE (EL INSRATE TIENE QUE CAMBIAR POR EL IDLABOR DEL INSULATION INSTALL)
	set @insRate =(select insRate from laborRate where idLaborRate = @IdLaborRateII)
	select top 1 @IFF90= p90,@IFF45=p45,@IFFBEND=bend,@IFFTEE=tee,@IFFREDUC=red,@IFFCAP=cap,@IFFPAIR=flangePair,@IFFVLV=flangeVlv,@IFFCONTROL=controlVlv,@IFFWELD=weldedVlv,@IFFSUP=support from insFitting where [type] = @Type
	
	set @oIIELF = ROUND(@LFtII+(@P90II*@IFF90)+(@P45II*@IFF45)+ (@PBendII*@IFFBEND)+(@PTeeII*@IFFTEE)+(@PReducII*@IFFREDUC)+(@PCapsII*@IFFCAP)+ (@PPairII*@IFFPAIR)+(@PVlvII*@IFFVLV)+(@PControlII*@IFFCONTROL)+(@PWeldII*@IFFWELD)+(@PCutOutII*@IFFCUTOUT)+(@PsupportII*@IFFSUP),2)
	set @oPIIHRS = ROUND(@oIIELF*@PIUPL*@percent*@PJKTL,1)
	set @oPIICOSTL = ROUND(@oPIIHRS*@insRate,2)
	set @oPIICOSTM = ROUND(@oIIELF*@PIUPM*@PJKTM,2)
	set @oPIICOSTE = ROUND(@oIIELF*@PIUPE*@PJKTE,2)
	set @oPIITCOST = ROUND(ISNULL(@oPIICOSTL,0)+ISNULL(@oPIICOSTM,0)+ISNULL(@oPIICOSTE,0),2)

	--INSULATION PAINT

	set @pntRate = (select top 1 paintRate from laborRate where idLaborRate = @IdLaborRatePnt)
	select @PFF90 = p90 , @PFF45 = p45, @PFFTEE = tee , @PFFPAIR = flangePair , @PFFVLV = flangeVlv , @PFFCONTROL = controlVlv, @PFFWLED = weldedVlv from pntFitting where pntOption = @Option
	select @PPUPL = laborProd, @PPUPM=matRate, @PPUPE=eqRate from ppPaintUnitRate where systemPntPP = @System and pntOption = @Option and size =  @Size

	set @oPESQF = ROUND(IIF(@Size <=3,1,@Size/3.82)*(@LFtPnt+(@P90Pnt*@PFF90)+(@P45Pnt*@PFF45)+(@PTeePnt*@PFFTEE)+(@PPairPnt*@PFFPAIR)+(@PVlvPnt*@PFFVLV)+(@PControlPnt*@PFFCONTROL)+(@PWeldPnt*@PFFWLED)),2)
	set @oPPHRS = ROUND(@oPESQF*@PPUPL*@percent,1)
	set @oPPCOSTL = ROUND(@oPPHRS * @pntRate,2)
	set @oPPCOSTM = ROUND(@oPESQF * @PPUPM,2)
	set @oPPCOSTE = ROUND(@oPESQF * @PPUPE,2)
	set @oPPTCOST = ROUND(ISNULL(@oPPCOSTL,0)+ISNULL(@oPPCOSTM,0)+ISNULL(@oPPCOSTE,0),2)
	--=============================================================================================================================
	--====== NEW VALUES ===========================================================================================================
	--=============================================================================================================================
	select  
		@Size = newSize ,@Elevation   = newElevation ,@System   = newSystem ,@Option   = newOption ,@Type  = newType ,@Thick   = newThick ,@IdJacket  = newIdJacket ,
		@IdLaborRatePnt  = newIdLaborRatePnt ,@LFtPnt   = newLFtPnt ,@P90Pnt   = newP90Pnt ,@P45Pnt   = newP45Pnt ,@PTeePnt   = newPTeePnt ,@PPairPnt   = newPPairPnt ,@PVlvPnt  = newPVlvPnt ,@PControlPnt   = newPControlPnt ,@PWeldPnt  = newPWeldPnt ,
		@IdLaborRateRmv = newIdLaborRateRmv ,@LFtRmv   = newLFtRmv ,
		@IdLaborRateII  = newIdLaborRateII ,@LFtII  = newLFtII ,@P90II   = newP90II ,@P45II   = newP45II ,@PBendII   = newPBendII ,@PTeeII   = newPTeePnt ,	@PReducII   = newPReducII ,@PCapsII   = newPCapsII ,@PPairII   = newPPairII ,@PVlvII   = newPVlvII ,@PControlII   = newPControlII ,@PWeldII   = newPWeldII ,@PCutOutII   = newPCutOutII ,@PsupportII  = newPsupportII 
	from RFIPiping where idDrawingNum = @idDrawingNum and tag = @tag and idRFIPp = @idRFIPp
	
	set @percent = (select [percent] from factorElevationPaint where elevation = @Elevation)
	set @percent = IIF(ISNULL(@percent,1)=1,0,@percent*0.01)
	set @PIUPL = (select top 1 laborProd from ppInsUnitRate where size=@Size and [type]=@Type and [thick]=@Thick)
	set @PIUPM = (select top 1 matRate from ppInsUnitRate where size=@Size and [type]=@Type and [thick]=@Thick)
	set @PIUPE = (select top 1 eqRate from ppInsUnitRate where size=@Size and [type]=@Type and [thick]=@Thick)
	
	set @PJKTL = (select laborProd from ppJktUnitRate where idJacket = @IdJacket)
	set @PJKTM = (select top 1 matFactor from ppJktUnitRate where @IdJacket = @IdJacket)
	set @PJKTE = (select top 1 eqFactor from ppJktUnitRate where idJacket = @IdJacket)

	--INSULATION REMOVE
	set @insRate = (select top 1 insRate from laborRate where idLaborRate = @IdLaborRateRmv)

	set @nPIRHRS = ROUND(@LFtRmv*@PIUPL*@percent *@PJKTL,1)
	set @nPIRCOSTL = ROUND(@nPIRHRS*@insRate,2)
	set @nPIRCOSTM = ROUND(@LFtRmv*@PIUPM*@PJKTM,2)
	set @nPIRCOSTE = ROUND(@LFtRmv*@PIUPE*@PJKTE,2)
	set @nPIRTCOST = ROUND(ISNULL(@nPIRCOSTL,0)+ISNULL(@nPIRCOSTM,0)+ISNULL(@nPIRCOSTE,0),2)

	--INSULATION INSULATION
	set @insRate = (select top 1 insRate from laborRate where idLaborRate = @IdLaborRateII)
	select top 1 @IFF90= p90,@IFF45=p45,@IFFBEND=bend,@IFFTEE=tee,@IFFREDUC=red,@IFFCAP=cap,@IFFPAIR=flangePair,@IFFVLV=flangeVlv,@IFFCONTROL=controlVlv,@IFFWELD=weldedVlv,@IFFSUP=support from insFitting where [type] = @Type
	
	set @nIIELF = ROUND(@LFtII+(@P90II*@IFF90)+(@P45II*@IFF45)+(@PBendII*@IFFBEND)+(@PTeeII*@IFFTEE)+(@PReducII*@IFFREDUC)+(@PCapsII*@IFFCAP)+(@PPairII*@IFFPAIR+(@PVlvII*@IFFVLV)+@PControlII*@IFFCONTROL)+(@PWeldII*@IFFWELD)+(@PCutOutII*@IFFCUTOUT)+(@PsupportII*@IFFSUP),2)
	set @nPIIHRS = ROUND(@nIIELF*@PIUPL*@percent*@PJKTL,1)
	set @nPIICOSTL = ROUND(@nPIRHRS*@insRate,2)
	set @nPIICOSTM = ROUND(@nIIELF*@PIUPM*@PJKTM,2)
	set @nPIICOSTE = ROUND(@nIIELF*@PIUPE*@PJKTE,2)
	set @nPIITCOST = ROUND(ISNULL(@nPIICOSTL,0)+ISNULL(@nPIICOSTM,0)+ISNULL(@nPIICOSTE,0),2)

	--INUSLATION PAINT
	set @pntRate = (select top 1 paintRate from laborRate where idLaborRate = @IdLaborRatePnt)
	select @PPUPL = laborProd,@PPUPM=matRate,@PPUPE=eqRate from ppPaintUnitRate where systemPntPP = @System and pntOption = @Option and size =  @Size
	select @PFF90 = p90 , @PFF45 = p45, @PFFTEE = tee , @PFFPAIR = flangePair , @PFFVLV = flangeVlv , @PFFCONTROL = controlVlv, @PFFWLED = weldedVlv from pntFitting where pntOption = @Option
	
	set @nPESQF = ROUND(IIF(@Size<=3,1,@Size/3.82)*(@LFtPnt+(@P90Pnt*@PFF90)+(@P45Pnt*@PFF45)+(@PTeePnt*@PFFTEE)+(@PPairPnt*@PFFPAIR)+(@PVlvPnt*@PFFVLV)+(@PControlPnt*@PFFCONTROL)+(@PWeldPnt*@PFFWLED)),2)
	set @nPPHRS = ROUND(@nPESQF*@PPUPL*@percent,1)
	set @nPPCOSTL = ROUND(@nPPHRS*@pntRate,2)
	set @nPPCOSTM = ROUND(@nPESQF*@PPUPM,2)
	set @nPPCOSTE = ROUND(@nPESQF*@PPUPE,2)
	set @nPPTCOST = ROUND(ISNULL(@nPPCOSTL,0)+ISNULL(@nPPCOSTM,0)+ISNULL(@nPPCOSTE,0),2)
	
	if (select COUNT(*)from RFIDiffPp where idDrawingNum=@idDrawingNum and tag= @tag and idRFIpP = @idRFIPp )=0
	begin
		insert into RFIDiffPp values (@idRFIPp,@tag,@idDrawingNum,
									@oPIRHRS,@oPIRCOSTL,@oPIRCOSTM,@oPIRCOSTE,@oPIRTCOST,
									@oIIELF,@oPIIHRS,@oPIICOSTL,@oPIICOSTM,@oPIICOSTE,@oPIITCOST,
									@oPESQF,@oPPHRS,@oPPCOSTL,@oPPCOSTM,@oPPCOSTE,@oPPTCOST,
									@nPIRHRS,@nPIRCOSTL,@nPIRCOSTM,@nPIRCOSTE,@nPIRTCOST,
									@nIIELF,@nPIIHRS,@nPIICOSTL,@nPIICOSTM,@nPIICOSTE,@nPIITCOST,
									@nPESQF,@nPPHRS,@nPPCOSTL,@nPPCOSTM,@nPPCOSTE,@nPPTCOST)	
	end	else if (select COUNT(*)from RFIDiffEq where idDrawingNum=@idDrawingNum and tag= @tag and idRFIEq = @idRFIPp )=1
	begin
		update RFIDiffPp set  
			oPIRHRS = @oPIRHRS,oPIRCOSTL = @oPIRCOSTL , oPIRCOSTM = @oPIRCOSTM ,oPIRCOSTE = @oPIRCOSTE , oPIRTCOST = @oPIRTCOST ,  
			oIIELF = @oIIELF ,oPIIHRS = @oPIIHRS , oPIICOSTL = @oPIICOSTL , oPIICOSTM = @oPIICOSTM , oPIICOSTE = @oPIICOSTE , oPIITCOST = @oPIITCOST , 
			oPESQF = @oPESQF , oPPHRS = @oPPHRS ,  oPPCOSTL = @oPPCOSTL , oPPCOSTM = @oPPCOSTM , oPPCOSTE = @oPPCOSTE , oPPTCOST = @oPPTCOST , 
			nPIRHRS = @nPIRHRS , nPIRCOSTL = @nPIRCOSTL , nPIRCOSTM = @nPIRCOSTM , nPIRCOSTE = @nPIRCOSTE , nPIRTCOST = @nPIRTCOST , 
			nIIELF = @nIIELF , nPIIHRS = @nPIIHRS , nPIICOSTL = @nPIICOSTL , nPIICOSTM = @nPIICOSTM , nPIICOSTE = @nPIICOSTE , nPIITCOST = @nPIITCOST , 
			nPESQF = @nPESQF , nPPHRS = @nPPHRS , nPPCOSTL = @nPPCOSTL ,nPPCOSTM = @nPPCOSTM ,  nPPCOSTE = @nPPCOSTE , nPPTCOST = @nPPTCOST 
		where idRFIPp = @idRFIPp and tag = @tag and idDrawingNum = @idDrawingNum
	end
end
GO
----#########################################################################################################################################################################################
----############# PROCDIMIENTO PARA INSERTAR Y ACTUALIZAR RFI DIF DE ESCAFFOLD EST ##########################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_insertUpdateRFIScaffoldEst]
CREATE proc [dbo].[sp_insertUpdateRFIScaffoldEst]
	@idRFI varchar(35),
	@tag varchar(20),
	@idDrawingNum varchar(45)
as
declare @with as float = 0
declare @length as float = 0
declare @heigth as float = 0
declare @buildPercent as float = 0
declare @laborB as float = 0
declare @materialB as float = 0
declare @equipmentB as float = 0
declare @scafRate as float = 0
declare @oSCM as float = 0
declare @oSHR as float = 0
declare @oSBHR as float = 0
declare @oSDHR as float = 0
declare @oSBCOSTL as float = 0
declare @oSDCOSTL as float = 0
declare @oSCOSTL as float = 0
declare @oSBCOSTM as float = 0
declare @oSDCOSTM as float = 0
declare @oSCOSTM as float = 0
declare @oSBCOSTE as float = 0
declare @oSDCOSTE as float = 0
declare @oSCOSTE as float = 0
declare @oSBTCOST as float = 0
declare @oSDTCOST as float = 0
declare @oSTCOST as float = 0
declare @nSCM as float = 0
declare @nSHR as float = 0
declare @nSBHR as float = 0
declare @nSDHR as float = 0
declare @nSBCOSTL as float = 0
declare @nSDCOSTL as float = 0
declare @nSCOSTL as float = 0
declare @nSBCOSTM as float = 0
declare @nSDCOSTM as float = 0
declare @nSCOSTM as float = 0
declare @nSBCOSTE as float = 0
declare @nSDCOSTE as float = 0
declare @nSCOSTE as float = 0
declare @nSBTCOST as float = 0
declare @nSDTCOST as float = 0
declare @nSTCOST as float = 0
begin
	--CARGAMOS LOS DATOS DE LA VARIABLE QUE VAMOS A UTILIZAR
	select @with= lastWith,@length= lastLength ,@heigth = lastHeigth from RFIScaffoldEst where idDrawingNum=@idDrawingNum and tag= @tag and idRFI = @idRFI
	select @laborB = laborB, @materialB = materialB,@equipmentB = equipmentB,@buildPercent = buildPercent from scfUnitsRates where idSCFUR = (select lastIdSCFUR from RFIScaffoldEst where idDrawingNum=@idDrawingNum and tag= @tag and idRFI = @idRFI)
	set @buildPercent = IIF(ISNULL(@buildPercent,1)=1,0,@buildPercent*0.01)  
	select @scafRate = scafRate from laborRate where idLaborRate = (select lastIdLaborRate from RFIScaffoldEst where idDrawingNum=@idDrawingNum and tag= @tag and idRFI = @idRFI)
	--HACEMOS LAS OPERACIONES DEL SCAFFOLD QUE CAMBIO
	SET @oSCM= ROUND(ISNULL(@with,0)*ISNULL(@length,0)*ISNULL(@heigth,0)/35.3,2)
	SET @oSHR= ROUND(@oSCM/@laborB,1)
	SET @oSBHR= ROUND(@oSHR*@buildPercent,1)
	SET @oSDHR= @oSHR-@oSBHR 
	SET @oSBCOSTL= ROUND(@oSBHR*@scafRate,2)
	SET @oSDCOSTL= ROUND(@oSDHR*@scafRate,2)
	SET @oSCOSTL= @oSBCOSTL+@oSDCOSTL 
	SET @oSBCOSTM= ROUND(@oSBHR*@materialB,2)
	SET @oSDCOSTM= ROUND(@oSDHR*@materialB,2)
	SET @oSCOSTM= @oSBCOSTM+@oSDCOSTM
	SET @oSBCOSTE= ROUND(@oSBHR*@equipmentB,2)
	SET @oSDCOSTE= ROUND(@oSDHR*@equipmentB,2)
	SET @oSCOSTE= @oSBCOSTE+@oSDCOSTE
	SET @oSBTCOST= ISNULL(@oSBCOSTL,0)+ISNULL(@oSBCOSTM,0)+ISNULL(@oSBCOSTE,0)
	SET @oSDTCOST= ISNULL(@oSDCOSTL,0)+ISNULL(@oSDCOSTM,0)+ISNULL(@oSDCOSTE,0)
	SET @oSTCOST= ISNULL(@oSCOSTL,0)+ISNULL(@oSCOSTM,0)+ISNULL(@oSCOSTE,0)
	--CARGAMOS AHORA LOS DATOS DE LA ACTUALIZACION DEL RFI
	select @with= ISNULL(newWith,0),@length= ISNULL( newLength,0) ,@heigth = ISNULL(newHeigth,0) from RFIScaffoldEst where idDrawingNum=@idDrawingNum and tag= @tag and idRFI = @idRFI
	select @scafRate = scafRate from laborRate where idLaborRate = (select newIdLaborRate from RFIScaffoldEst where idDrawingNum=@idDrawingNum and tag= @tag and idRFI = @idRFI)
	--HACEMOS LAS OPERACION PARA EL SCAFFOLD CON LA INFORMACION NUEVA
	SET @nSCM= ROUND(ISNULL(@with,0)*ISNULL(@length,0)*ISNULL(@length,0)/35.3,2)
	SET @nSHR= ROUND(@nSCM/@laborB,1)
	SET @nSBHR= ROUND(@nSHR*@buildPercent,1) 
	SET @nSDHR= @nSHR - @nSBHR   
	SET @nSBCOSTL= ROUND(@nSBHR*@scafRate,2)
	SET @nSDCOSTL= ROUND(@nSDHR*@scafRate,2)
	SET @nSCOSTL= @nSBCOSTL+@nSDCOSTL 
	SET @nSBCOSTM= ROUND(@nSBHR*@materialB,2)
	SET @nSDCOSTM= ROUND(@nSDHR*@materialB,2)
	SET @nSCOSTM= @nSBCOSTM+@nSDCOSTM 
	SET @nSBCOSTE= ROUND(@nSBHR*@equipmentB,2) 
	SET @nSDCOSTE= ROUND(@nSDHR*@equipmentB,2) 
	SET @nSCOSTE= @nSBCOSTE+@nSDCOSTE
	SET @nSBTCOST= ISNULL(@nSBCOSTL,0)+ISNULL(@nSBCOSTM,0)+ISNULL(@nSBCOSTE,0)
	SET @nSDTCOST= ISNULL(@nSDCOSTL,0)+ISNULL(@nSDCOSTM,0)+ISNULL(@nSDCOSTE,0)
	SET @nSTCOST= ISNULL(@nSCOSTL,0)+ISNULL(@nSCOSTM,0)+ISNULL(@nSCOSTE,0)

	if (select COUNT(*)from RFIDiffScf where idDrawingNum=@idDrawingNum and tag= @tag and idRFI = @idRFI )=0
	begin
		insert into RFIDiffScf values (@idRFI,@tag,@idDrawingNum,@oSCM,@oSHR,@oSBHR,@oSDHR,@oSBCOSTL,@oSDCOSTL,@oSCOSTL,@oSBCOSTM,@oSDCOSTM,@oSCOSTM,@oSBCOSTE,@oSDCOSTE,@oSCOSTE,@oSBTCOST,@oSDTCOST,@oSTCOST,@nSCM,@nSHR,@nSBHR,@nSDHR,@nSBCOSTL,@nSDCOSTL,@nSCOSTL,@nSBCOSTM,@nSDCOSTM,@nSCOSTM,@nSBCOSTE,@nSDCOSTE,@nSCOSTE,@nSBTCOST,@nSDTCOST,@nSTCOST)
	end
	else if (select COUNT(*)from RFIDiffScf where idDrawingNum=@idDrawingNum and tag= @tag and idRFI = @idRFI )=1
	begin
		update RFIDiffScf set  oSCM = @oSCM,oSHR = @oSHR,oSBHR = @oSBHR,oSDHR = @oSDHR,oSBCOSTL = @oSBCOSTL,oSDCOSTL = @oSDCOSTL,oSCOSTL = @oSCOSTL,oSBCOSTM = @oSBCOSTM,oSDCOSTM = @oSDCOSTM,oSCOSTM = @oSCOSTM,oSBCOSTE = @oSBCOSTE,oSDCOSTE = @oSDCOSTE,oSCOSTE = @oSCOSTE,oSBTCOST = @oSBTCOST,oSDTCOST = @oSDTCOST,oSTCOST = @oSTCOST,nSCM = @nSCM,nSHR = @nSHR,nSBHR = @nSBHR,nSDHR = @nSDHR,nSBCOSTL = @nSBCOSTL,nSDCOSTL = @nSDCOSTL,nSCOSTL = @nSCOSTL,nSBCOSTM = @nSBCOSTM,nSDCOSTM = @nSDCOSTM,nSCOSTM = @nSCOSTM,nSBCOSTE = @nSBCOSTE,nSDCOSTE = @nSDCOSTE,nSCOSTE = @nSCOSTE,nSBTCOST = @nSBTCOST,nSDTCOST = @nSDTCOST,nSTCOST = @nSTCOST where idRFI = @idRFI and tag =  @tag and idDrawingNum = @idDrawingNum
	end	
end
go
--##############################################################################################
--################## SP INVOICE NUMBER #########################################################
--##############################################################################################
--ALTER proc [dbo].[sp_invoice_number]
CREATE proc sp_invoice_number
@numberClient int,
@startDate date,
@FinalDate date
as 
begin 
	select invoice , idPO from tempInvoice
	where startDate = @startDate 
		and FinalDate = @FinalDate 
		and idClient = (select idclient from clients where numberClient = @numberClient)
end
go
--##############################################################################################
--################## SP INVOICE PO #############################################################
--##############################################################################################
--ALTER proc [dbo].[sp_Invoice_PO]
CREATE proc sp_Invoice_PO
@numberClient  int,
@startDate date, 
@FinalDate date, 
@idPO bigint,
@all bit 
as 
begin 
select 
	cl.numberClient,
	cl.companyName,
	jb.jobNo,
	po.idPO, 
	SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) 'Class',
	hw.hoursST,
	(hw.hoursST*wc.billingRate1) as 'CostST',
	hw.hoursOT,
	(hw.hoursOT*wc.billingRateOT) as 'CostOT',
	isnull((select sum(amount) from expensesUsed as exu where exu.idHorsWorked = hw.idHorsWorked and exu.dateExpense between @startDate and @FinalDate),0)as 'Perdiem'
	into #TablaHorasClassPerdiem
	from hoursWorked as hw 
		inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
		inner join task as tk on tk.idAux = hw.idAux 
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on po.jobNo = jb.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where cl.numberClient = @numberClient and hw.dateWorked between @startDate and @FinalDate and po.idPO like iif(@all = 1 ,'%%%',convert(nvarchar, @idPO))

select
	distinct
	t1.numberClient,
	t1.companyName,
	t1.payTerms,
	t1.jobNo,
	t1.idPO,
	t1.Class,
	(select
	sum(hoursST)
	from #TablaHorasClassPerdiem as t2 
	where t2.numberClient = t2.numberClient and t2.jobNo = t1.jobNo and t2.idPO	= t1.idPO and t2.Class = t1.Class) as 'ST',
	(select
	sum(CostST)
	from #TablaHorasClassPerdiem as t2 
	where t2.numberClient = t2.numberClient and t2.jobNo = t1.jobNo and t2.idPO	= t1.idPO and t2.Class = t1.Class) as 'CostST',
	(select
	sum(hoursOT)
	from #TablaHorasClassPerdiem as t2 
	where t2.numberClient = t2.numberClient and t2.jobNo = t1.jobNo and t2.idPO	= t1.idPO and t2.Class = t1.Class) as 'OT',
	(select
	sum(CostOT)
	from #TablaHorasClassPerdiem as t2 
	where t2.numberClient = t2.numberClient and t2.jobNo = t1.jobNo and t2.idPO	= t1.idPO and t2.Class = t1.Class) as 'CostOT',
	(select
	sum(perdiem)
	from #TablaHorasClassPerdiem as t2 
	where t2.numberClient = t2.numberClient and t2.jobNo = t1.jobNo and t2.idPO	= t1.idPO and t2.Class = t1.Class) as 'Perdiem'
from #TablaHorasClassPerdiem as t1 
drop table #TablaHorasClassPerdiem
end
go
--##############################################################################################
--################## SP INVOICE PO RESUME ######################################################
--##############################################################################################
--ALTER proc [dbo].[sp_Invoice_PO_Resume]
CREATE proc [dbo].[sp_Invoice_PO_Resume]
@numberClient  int,
@startDate date,
@FinalDate date,
@idPO bigint,
@all bit
as
begin
select T1.companyName,T1.payTerms,T1.city,T1.providence,T1.[Address],T1.postalCode,T1.jobNo,T1.custumerNo,T1.contractNo,T1.idPO,
T1.[Total Hours PO],T1.[Total Hours],T1.[Total Labor],
T1.[Total Expenses],T1.[Total PerDiem],T1.[3rdParty],T1.[ScRent],T1.[CoEQ],T1.[Material],T1.[Subcontractors],T1.[Other],T1.[ExtraCostMaterial]
,T1.[Total Material]
,T1.[Total Cost]
 from (
select 
	cl.companyName,
	cl.payTerms,
	ha.city,
	ha.providence,
	CONCAT(ha.number,' ',ha.avenue) as 'Address',
	ha.postalCode,
	jb.jobNo,
	jb.custumerNo,
	isnull(jb.contractNo,'') as 'contractNo',
	po.idPO,
	
	ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
		inner join task as tk1 on tk1.idAux = hw1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
	as 'Total Hours PO',

	ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
		inner join task as tk1 on tk1.idAux = hw1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
	as 'Total Hours',

	ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
		inner join task as tk1 on tk1.idAux = hw1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
	as 'Total Labor',

	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
		inner join task as tk1 on tk1.idAux = exu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate and ex1.expenseCode like '%travel%'),0)
	as 'Total Expenses',

	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
		inner join task as tk1 on tk1.idAux = exu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate and ex1.expenseCode like '%per-diem%'),0)
	as 'Total PerDiem',

	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
		left join materialClass as mtc1 on mtc1.code = mt1.code
		inner join task as tk1 on tk1.idAux = mtu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
		and (mtc1.code = '2.201-D' or mtc1.code = '2.255-D' or mtc1.code = '2.256-D' or mtc1.code = '2.202-D'or mtc1.code = '2.203-D'or mtc1.code = '2.303-F'or mtc1.code = '2.304-F' )),0) 
	as '3rdParty',

	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
		left join materialClass as mtc1 on mtc1.code = mt1.code
		inner join task as tk1 on tk1.idAux = mtu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
		and (mtc1.code = '2.204-D' or mtc1.code = '2.207-D' or mtc1.code = '2.254-E' or mtc1.code = '2.257-E')),0) 
	as 'ScRent',

	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
		left join materialClass as mtc1 on mtc1.code = mt1.code
		inner join task as tk1 on tk1.idAux = mtu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
		and (mtc1.code = '2.251-E' or mtc1.code = '2.252-D' or mtc1.code = '2.253-E' or mtc1.code = '2.301-F' or mtc1.code = '2.302-F'or mtc1.code = '2.907-Y')),0) 
	as 'CoEQ',

	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
		left join materialClass as mtc1 on mtc1.code = mt1.code
		inner join task as tk1 on tk1.idAux = mtu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
		and (mtc1.code = '2.500-M' or mtc1.code = '2.515-M')),0) 
	as 'Material',

	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
		left join materialClass as mtc1 on mtc1.code = mt1.code
		inner join task as tk1 on tk1.idAux = mtu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
		and (mtc1.code = '2.600-S')),0) 
	as 'Subcontractors',

	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
		left join materialClass as mtc1 on mtc1.code = mt1.code
		inner join task as tk1 on tk1.idAux = mtu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
		and (mtc1.code = '2.900-Y' or mtc1.code = '2.911-Y')),0) 
	as 'Other',

	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
		left join materialClass as mtc1 on mtc1.code = mt1.code
		inner join task as tk1 on tk1.idAux = mtu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
		and not (
		   mtc1.code = '2.201-D' or mtc1.code = '2.202-D' or mtc1.code = '2.203-D' or mtc1.code = '2.255-D' or mtc1.code = '2.256-D' or mtc1.code = '2.303-F' or mtc1.code = '2.304-F'
		or mtc1.code = '2.204-D' or mtc1.code = '2.207-D' or mtc1.code = '2.254-E' or mtc1.code = '2.257-E' 
		or mtc1.code = '2.252-D' or mtc1.code = '2.253-E' or mtc1.code = '2.301-F' or mtc1.code = '2.302-F' or mtc1.code = '2.251-E' or mtc1.code = '2.907-Y'
		or mtc1.code = '2.500-M' or mtc1.code = '2.515-M' 
		or mtc1.code = '2.600-S' 
		or mtc1.code = '2.900-Y' or mtc1.code = '2.911-Y')),0) 
	as 'ExtraCostMaterial',

	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
		left join materialClass as mtc1 on mtc1.code = mt1.code
		inner join task as tk1 on tk1.idAux = mtu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate),0) 
	as 'Total Material'
	
	,
	ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
		inner join task as tk1 on tk1.idAux = hw1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0)
	+
	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
		inner join task as tk1 on tk1.idAux = exu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate),0)
	+
	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
		inner join task as tk1 on tk1.idAux = mtu1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients  as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate),0 )
	as 'Total Cost'
from job as jb 
inner join clients as cl on cl.idClient = jb.idClient 
left join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAddress
inner join projectOrder as po on po.jobNo = jb.jobNo
where cl.idClient = (select idClient from clients where numberClient = @numberClient)  and  po.idPO like iif(@all = 1 ,'%%',convert(nvarchar, @idPO)) 
) as T1 where T1.[Total Labor]>0 or
T1.[Total Expenses]>0 or T1.[Total PerDiem]>0 or T1.[3rdParty]>0 or T1.[ScRent]>0 or T1.[CoEQ]>0 or T1.[Material]>0 or T1.[Subcontractors]
>0 or T1.[Other]>0 or t1.[ExtraCostMaterial]
>0 or T1.[Total Material] >0
end
GO
----#########################################################################################################################################################################################
----############## PROCEDIMINETO PARA SUBREPORTE DE MATERIALES EN ESTIMACION ################################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_MaterialEstimationProject]
CREATE proc [dbo].[sp_MaterialEstimationProject]
@ProjectId as varchar(30)
as
begin
	select 
	distinct
	TG.size,TG.thick,TG.price,TG.[description],
	SUM(TG.[SQF/LF]) OVER (PARTITION BY description) 'SQF/LF',
	SUM(TG.[PMCost]) OVER (PARTITION BY description) 'PMCost'
from(
	select
	distinct
	--T1.idDrawingNum ,
	(select TOP 1 SUM(T2.[SQF/LF]) from 
					(select TA.[SQF/LF] from
						(select --dr.idDrawingNum, 
							ppE.lFtII  as 'SQF/LF', ppE.size , ppE.thick , ppM.price , ppM.description , (ppE.lFtII * ppM.price) as 'PMCost' from pipingEst as ppE
							inner join pipingMaterial ppM on ppE.size = ppM.size and ppE.thick = ppM.thick and ppe.[type]= ppM.[type]
							inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
							inner join projectClientEst as po on po.projectId  = dr.projectId
							where po.projectId = @ProjectId and (ppE.lFtII > 0 and not ppE.lFtII is null )
							union all
							select --dr.idDrawingNum ,
							eqE.sqrFtII as 'SQF/LF', 0 as 'Size' , eqE.thick , eqM.price , eqM.description , (eqE.sqrFtII * eqM.price) as 'PMCost' from equipmentEst as eqE
							inner join equipmentMaterial as eqM on  eqM.[type] = eqE.[type] and eqM.[thick] = eqE.[thick]
							inner join drawing as dr on dr.idDrawingNum = eqE.idDrawingNum 
							inner join projectClientEst as po on po.projectId  = dr.projectId
							where po.projectId = @ProjectId and (eqE.sqrFtII > 0 and not eqE.sqrFtII is null)) as TA 
						where TA.[description] = T1.[description] and TA.[thick] = T1.[thick] and TA.[price] = T1.[price] --and TA.[idDrawingNum] = T1.[idDrawingNum] 
						) as T2) AS 'SQF/LF',
	T1.size , 
	T1.thick,
	T1.price,
	T1.[description],
	(select TOP 1 SUM(T2.[SQF/LF]) from 
					(select TA.[SQF/LF] from
						(select --dr.idDrawingNum, 
							ppE.lFtII  as 'SQF/LF', ppE.size , ppE.thick , ppM.price , ppM.description , (ppE.lFtII * ppM.price) as 'PMCost' from pipingEst as ppE
							inner join pipingMaterial ppM on ppE.size = ppM.size and ppE.thick = ppM.thick and ppe.[type]= ppM.[type]
							inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
							inner join projectClientEst as po on po.projectId  = dr.projectId
							where po.projectId = @ProjectId and (ppE.lFtII > 0 and not ppE.lFtII is null )
							union all
							select --dr.idDrawingNum ,
							eqE.sqrFtII as 'SQF/LF', 0 as 'Size' , eqE.thick , eqM.price , eqM.description , (eqE.sqrFtII * eqM.price) as 'PMCost' from equipmentEst as eqE
							inner join equipmentMaterial as eqM on  eqM.[type] = eqE.[type] and eqM.[thick] = eqE.[thick]
							inner join drawing as dr on dr.idDrawingNum = eqE.idDrawingNum 
							inner join projectClientEst as po on po.projectId  = dr.projectId
							where po.projectId = @ProjectId and (eqE.sqrFtII > 0 and not eqE.sqrFtII is null)) as TA 
						where TA.[description] = T1.[description] and TA.[thick] = T1.[thick] and TA.[price] = T1.[price]-- and TA.[idDrawingNum] = T1.[idDrawingNum] 
						) as T2) AS 'PMCost'
	from(
	select --dr.idDrawingNum, 
	ppE.lFtII  as 'SQF/LF', ppE.size , ppE.thick , ppM.price , ppM.description , (ppE.lFtII * ppM.price) as 'PMCost' from pipingEst as ppE
	inner join pipingMaterial ppM on ppE.size = ppM.size and ppE.thick = ppM.thick and ppe.[type]= ppM.[type]
	inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
	inner join projectClientEst as po on po.projectId  = dr.projectId
	where po.projectId = @ProjectId and (ppE.lFtII > 0 and not ppE.lFtII is null )
	union all
	select --dr.idDrawingNum ,
	eqE.sqrFtII as 'SQF/LF', 0 as 'Size' , eqE.thick , eqM.price , eqM.description , (eqE.sqrFtII * eqM.price) as 'PMCost' from equipmentEst as eqE
	inner join equipmentMaterial as eqM on  eqM.[type] = eqE.[type] and eqM.[thick] = eqE.[thick]
	inner join drawing as dr on dr.idDrawingNum = eqE.idDrawingNum 
	inner join projectClientEst as po on po.projectId  = dr.projectId
	where po.projectId = @ProjectId and (eqE.sqrFtII > 0 and not eqE.sqrFtII is null)) as T1
	UNION ALL
	select  * , (T2.[SQF/LF]*[Price]) as 'PMCost' from (
select --dr.idDrawingNum,
p90II as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = '90°'),0) as 'Price' , CONCAT('90°',' - ',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = '90°'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.p90II > 0 and not ppE.p90II is null )
union All
select --dr.idDrawingNum,
p45II as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = '45°'),0) as 'Price' , CONCAT('45°',' - ',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = '45°'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.p45II > 0 and not ppE.p45II is null )
union All
select --dr.idDrawingNum,
pBendII as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Bend'),0) as 'Price' , CONCAT('Bend',' - ',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Bend'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.pBendII > 0 and not ppE.pBendII is null )
union All 
select --dr.idDrawingNum,
pTeeII as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'TEE'),0) as 'Price' , CONCAT('TEE',' - ',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'TEE'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.pTeeII > 0 and not ppE.pTeeII is null )
union All 
select --dr.idDrawingNum,
pReducII as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'RED'),0) as 'Price' , CONCAT('Reduction',' - ',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'RED'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.pReducII > 0 and not ppE.pReducII is null )
union All 
select --dr.idDrawingNum,
ppE.pCapsII as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'CAP'),0) as 'Price' , CONCAT('CAP',' - ',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'CAP'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.pCapsII > 0 and not ppE.pCapsII is null )
union All 
select --dr.idDrawingNum,
ppE.pPairII as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Flange Pair'),0) as 'Price' , CONCAT('Flange Pair',' - ',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Flange Pair'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.pPairII > 0 and not ppE.pPairII is null )
union All 
select --dr.idDrawingNum,
ppE.pVlvII as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Flange Valve'),0) as 'Price' , CONCAT('Flange Valve',' - ',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Flange Valve'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.pVlvII > 0 and not ppE.pVlvII is null )
union All 
select --dr.idDrawingNum,
ppE.pControlII as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Control Valve'),0) as 'Price' , CONCAT('Control Valve',' - ',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Control Valve'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.pControlII > 0 and not ppE.pControlII is null )
union All 
select --dr.idDrawingNum,
ppE.pWeldII as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Weld Valve'),0) as 'Price' , CONCAT('Weld Valve',' - ',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Weld Valve'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.pWeldII > 0 and not ppE.pWeldII is null )
union All 
select --dr.idDrawingNum,
ppE.pCutOutII as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Cut-Out'),0) as 'Price' , CONCAT('Cut-Out','-',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Cut-Out'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.pCutOutII > 0 and not ppE.pCutOutII is null )
union All 
select --dr.idDrawingNum,
ppE.psupportII as 'SQF/LF', ppE.size , ppE.thick , ISNULL((select TOP 1 price from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Support'),0) as 'Price' , CONCAT('Support','-',ISNULL((select TOP 1 [description] from ppFittingMaterial as ppFTM where ppFTM.size = ppE.size and ppFTM.[type] = ppE.[type] and ppFTM.[thick] = ppE.[thick] and ppFTM.fitting = 'Support'),'')) as 'Description' from pipingEst as ppE
inner join drawing as dr on dr.idDrawingNum = ppE.idDrawingNum 
inner join projectClientEst as po  on po.projectId =dr.projectId
where po.projectId = @ProjectId and (ppE.psupportII > 0 and not ppE.psupportII is null )
) as T2 
) 
as TG
ORDER BY TG.[description]
end
GO
--##############################################################################################
--################## SP REPORT NOT COMPLETE ####################################################
--##############################################################################################
--ALTER proc [dbo].[Sp_Not_Complete]
CREATE proc [dbo].[Sp_Not_Complete]
@clientnum as int,
@jobNum as bigint,
@all as bit
as
begin
if @all=1
begin
	select  cl.companyName, concat(wo.idWO,' ',ts.task) as 'Work Order',ts.description as 'Desription',
		ts.equipament,ts.estimateHours as 'Est:', ts.expCode as 'Expense Code',ts.accountNum as 'Account No', ts.status as 'Not Complete'
		from task as ts 
		inner join workOrder as wo on wo.idAuxWO = ts.idAuxWO 
		inner join projectOrder as po on po.idPO=wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where ts.status = '0' and cl.numberClient = @clientnum
end
else
	select  cl.companyName, concat(wo.idWO,' ',ts.task) as 'Work Order',ts.description as 'Desription',
		ts.equipament,ts.estimateHours as 'Est:', ts.expCode as 'Expense Code',ts.accountNum as 'Account No', ts.status as 'Not Complete'
		from task as ts 
		inner join workOrder as wo on wo.idAuxWO = ts.idAuxWO 
		inner join projectOrder as po on po.idPO=wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where ts.status = '0' and cl.numberClient = @clientnum and jb.jobNo=@jobNum
end
GO
--##############################################################################################
--################## SP PRODUCT INCOMING #######################################################
--##############################################################################################
create proc sp_ProductIncoming
@jobNo bigint,
@ticket varchar(15),
@all bit
as
begin 
	select inc.jobNo as 'JobNo',inc.ticketNum,CONVERT(nvarchar, inc.dateRecived,101)as 'Date',inc.comment as 'Comment',
	--product
	pd.um as 'UNIT MSR',pic.quantity as 'QTY',pic.idProduct as 'PRODUCT ID',pd.QID as 'QUANTITY ID',pd.name as 'PRODUCT NAME',pd.class as 'CLASS',pd.[weight]*pic.quantity as 'WEIGTH',
	--cliente
	cl.companyName as 'Client',ha.number,ha.avenue,ha.providence,CONCAT(ha.city,', ',ha.providence,' ',ha.postalCode) as 'Address',CONCAT(cl.firstName,' ',cl.lastName) as 'Contact',ISNULL(ctc.phoneNumber1,'') as 'Phone',
	--recived by
	inc.recivedBy as 'RecivedBy',
	ISNULL((select TOP 1 ctc1.phoneNumber1 from employees as emp 
	inner join contact as ctc1 on ctc1.idContact= emp.idContact
	where CONCAT(firstName,' ',middleName,' ',lastName) like inc.recivedBy),'') as 'EmployePhone'
	from productComing as pic 
	inner join product as pd on pd.idProduct = pic.idProduct
	inner join incoming as inc on inc.ticketNum = pic.ticketNum
	inner join job as jb on jb.jobNo = inc.jobNo
	inner join clients as cl on cl.idClient = jb.idClient
	left join contact as ctc on ctc.idContact = cl.idContact 
	left join HomeAddress as ha on ha .idHomeAdress = cl.idHomeAddress
	where inc.jobNo = @jobNo and inc.ticketNum like IIF(@all=1,'%%',@ticket)
end
go
--##############################################################################################
--################## SP PRODUCT OUTGOING #######################################################
--##############################################################################################
create proc sp_ProductOutgoing
@jobNo bigint,
@ticket varchar(15),
@all bit
as
begin 
	select otg.jobNo as 'JobNo',otg.ticketNum,CONVERT(nvarchar, otg.dateShipped,101)as 'Date',otg.comment as 'Comment',
	--product
	pd.um as 'UNIT MSR',pog.quantity as 'QTY',pog.idProduct as 'PRODUCT ID',pd.QID as 'QUANTITY ID',pd.name as 'PRODUCT NAME',pd.class as 'CLASS',pd.[weight]*pog.quantity as 'WEIGTH',
	--cliente
	cl.companyName as 'Client',ha.number,ha.avenue,ha.providence,CONCAT(ha.city,', ',ha.providence,' ',ha.postalCode) as 'Address',CONCAT(cl.firstName,' ',cl.lastName) as 'Contact',ISNULL(ctc.phoneNumber1,'') as 'Phone',
	--recived by
	otg.shippedby as 'ShippedBy', otg.superintendent as 'Intendent',
	ISNULL((select TOP 1 ctc1.phoneNumber1 from employees as emp 
	inner join contact as ctc1 on ctc1.idContact= emp.idContact
	where CONCAT(firstName,' ',middleName,' ',lastName) like otg.shippedby),'') as 'EmployePhone'
	from productOutGoing as pog 
	inner join product as pd on pd.idProduct = pog.idProduct
	inner join outgoing as otg on otg.ticketNum = pog.ticketNum
	inner join job as jb on jb.jobNo = otg.jobNo
	inner join clients as cl on cl.idClient = jb.idClient
	left join contact as ctc on ctc.idContact = cl.idContact 
	left join HomeAddress as ha on ha .idHomeAdress = cl.idHomeAddress
	where otg.jobNo = @jobNo and otg.ticketNum like IIF(@all=1,'%%',@ticket)
end
GO
----#########################################################################################################################################################################################
----######## PROCEDIMIENTO PARA REPORTE DE RFI DIFF EQUIPMENT ###############################################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_RFIDiffEq]
CREATE proc [dbo].[sp_RFIDiffEq]
	@idRFIEq varchar(35),
	@tag int,
	@idDrawingNum varchar(45)
as 
begin
	exec sp_insertUpdateRFIEquipmentEst @idRFIEq ,@tag, @idDrawingNum
	select rfiD.idRFIEq,rfiD.tag,rfiD.idDrawingNum, po.projectId,po.[description],rfi.basicFCR,
	rfiD.oIRESQF, rfiD.oEIRHRS, rfiD.oEIRCOSTL, rfiD.oEIRCOSTM, rfiD.oEIRCOSTE, rfiD.oEIRTCOST, rfiD.nIRESQF, rfiD.nEIRHRS, rfiD.nEIRCOSTL, rfiD.nEIRCOSTM, rfiD.nEIRCOSTE, rfiD.nEIRTCOST,
	rfiD.oIIESQF, rfiD.oEIIHRS, rfiD.oEIICOSTL, rfiD.oEIICOSTM, rfiD.oEIICOSTE, rfiD.oEIITCOST, rfiD.nIIESQF, rfiD.nEIIHRS, rfiD.nEIICOSTL, rfiD.nEIICOSTM, rfiD.nEIICOSTE, rfiD.nEIITCOST,
				  rfiD.oEPHRS , rfiD.oEPCOSTL , rfiD.oEPCOSTM , rfiD.oEPCOSTE , rfiD.oEPTCOST , rfiD.nEPHRS , rfiD.nEPHRS , rfiD.nEPCOSTL , rfiD.nEPCOSTM , rfiD.nEPCOSTE , rfiD.nEPTCOST
	from RFIDiffEq as rfiD
	inner join equipmentEst as eq on eq.idEquimentEst = rfiD.tag and rfiD.idDrawingNum = eq.idDrawingNum
	inner join RFIEquipment as rfi on rfi.tag = rfiD.tag and rfi.idDrawingNum = eq.idDrawingNum and rfi.idRFIEq = rfiD.idRFIEq
	inner join drawing as dr on dr.idDrawingNum = rfiD.idDrawingNum
	inner join projectClientEst as po on po.projectId = dr.projectId
	where rfiD.idDrawingNum = @idDrawingNum and rfiD.tag = @tag and rfiD.idRFIEq = @idRFIEq
end
GO
----#########################################################################################################################################################################################
----######## PROCEDIMIENTO PARA REPORTE RFI DIFF PIPING #####################################################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_RFIDiffPp]
CREATE proc [dbo].[sp_RFIDiffPp]
	@idRFIPp varchar(35),
	@tag int,
	@idDrawingNum varchar(45)
as 
begin
	exec sp_insertUpdateRFIPipingEst @idRFIPp ,@tag, @idDrawingNum
	select rfiD.idRFIPp,rfiD.tag,rfiD.idDrawingNum, po.projectId,po.[description],rfi.basicFCR,pp.line	,
		oPIRHRS  , oPIRCOSTL  , oPIRCOSTM  , oPIRCOSTE  , oPIRTCOST  ,  
		oPIIHRS  , oPIICOSTL  , oPIICOSTM  , oPIICOSTE  , oPIITCOST  , 
		oPPHRS  ,  oPPCOSTL  , oPPCOSTM  , oPPCOSTE  , oPPTCOST  , 
		nPIRHRS  , nPIRCOSTL  , nPIRCOSTM  , nPIRCOSTE  , nPIRTCOST  , 
		nPIIHRS  , nPIICOSTL  , nPIICOSTM  , nPIICOSTE  , nPIITCOST  , 
		nPPHRS  , nPPCOSTL  , nPPCOSTM  ,  nPPCOSTE  , nPPTCOST  
	from RFIDiffPp as rfiD
	inner join pipingEst as pp on pp.idPipingEst = rfiD.tag and rfiD.idDrawingNum = pp.idDrawingNum
	inner join RFIEquipment as rfi on rfi.tag = rfiD.tag and rfi.idDrawingNum = pp.idDrawingNum and rfi.idRFIEq = rfiD.idRFIPp
	inner join drawing as dr on dr.idDrawingNum = rfiD.idDrawingNum
	inner join projectClientEst as po on po.projectId = dr.projectId
	where rfiD.idDrawingNum = @idDrawingNum and rfiD.tag = @tag and rfiD.idRFIPp = @idRFIPp
end
GO
----#########################################################################################################################################################################################
----############# PROCDIMIENTO PARA LA CONSULTA DEL REPORTE DE RFI DE SCAFFOLD #############################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_RFIDiffScf]
CREATE proc [dbo].[sp_RFIDiffScf]
	@idRFI varchar(35),
	@tag varchar(20),
	@idDrawingNum varchar(45)
as 
begin
	exec sp_insertUpdateRFIScaffoldEst @idRFI,@tag,@idDrawingNum
	select rfiD.idRFI,rfiD.tag,rfiD.idDrawingNum,scf.location, po.projectId,po.[description],rfi.basicFCR,
	rfiD.oSHR ,rfiD.oSBHR,rfiD.oSDHR,rfiD.nSHR,rfiD.nSBHR,rfiD.nSDHR,
	rfiD.oSBCOSTL,rfiD.oSDCOSTL,rfiD.oSCOSTL,rfiD.nSBCOSTL,rfiD.nSDCOSTL,rfiD.nSCOSTL,
	rfiD.oSCOSTM,rfiD.nSCOSTM,
	rfiD.oSCOSTE,rfiD.nSCOSTE
	from RFIDiffScf as rfiD
	inner join scaffoldEst as scf on scf.tag = rfiD.tag and rfiD.idDrawingNum = scf.idDrawingNum
	inner join RFIScaffoldEst as rfi on rfi.tag = rfiD.tag and rfi.idDrawingNum = scf.idDrawingNum and rfi.idRFI= rfiD.idRFI
	inner join drawing as dr on dr.idDrawingNum = rfiD.idDrawingNum
	inner join projectClientEst as po on po.projectId = dr.projectId
	where rfiD.idDrawingNum = @idDrawingNum and rfiD.tag = @tag and rfiD.idRFI = @idRFI
end
GO
--##############################################################################################
--################## SP SCF PRODUCT TO SCAFFOLD,MODIFICATION AND DISMANTLE #####################
--##############################################################################################
--ALTER proc [dbo].[sp_Scaffold_Product]
CREATE proc [dbo].[sp_Scaffold_Product]
@tagID as varchar(20) ,
@modID as varchar(20) ,
@scf as bit,
@mod as bit,
@dis as bit
as
begin
	if @scf = 1 
	begin 
	select 
		sc.tag , 
		cl.photo as 'imgClient' ,
		ha.city as 'City',
		ha.providence as 'Providence',
		ha.postalCode as 'CP',
		jb.jobNo ,
		CONCAT(wo.idWO, '-' ,tk.task) as 'WO',
		jc.cat as 'Area',
		CONCAT(ar.idArea,'-',ar.name) as 'Unit',
		sj.[description] as 'Sub Job',
		sc.location as 'Location',
		sc.purpose as 'Purpose',
		sc.buildDate as 'BuildDate',
		ds.dismantleDate as 'DemoDate',
		sc.foreman as 'Foreman',
		si.width as 'Width',
		si.[length] as 'Length',
		si.heigth as 'Heigth',
		ISNULL((si.descks + si.extraDeck),0) as 'Decks',
		ISNULL((select (ah.build + ah.material + ah.travel + ah.weather+ ah.alarm+ ah.[safety]+ ah.stdBy+ ah.other) from activityHours as ah where ah.tag = sc.tag and ah.idModAux IS NUll and ah.idDismantle IS NUll),0) as 'Erection Hours',
		pd.QID as 'QuanID',
		pd.idProduct as 'ProductId',
		pd.name as 'Product Name',
		ps.quantity as 'QTY',
		pd.[weight] as 'Weight',
		pd.dailyRentalRate as 'DailyRent'
		from scaffoldTraking as sc
		left join scaffoldInformation as si on si.tag = sc.tag
		left join dismantle as ds on ds.tag = sc.tag
		left join areas as ar on ar.idArea = sc.idArea 
		left join subJobs as sj on sj.idSubJob = sc.idSubJob
		left join jobCat as jc on jc.idJobCat = sc.idJobCat
		left join task as tk on tk.idAux = sc.idAux
		left join productScaffold as ps on ps.tag = sc.tag
		inner join product as pd on pd.idProduct = ps.idProduct
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		left join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAddress
		where sc.tag = @tagID
	end
	else if @mod = 1 
	begin 
	select 
		sc.tag , 
		cl.photo as 'imgClient' ,
		ha.city as 'City',
		ha.providence as 'Providence',
		ha.postalCode as 'CP',
		jb.jobNo ,
		CONCAT(wo.idWO, '-' ,tk.task) as 'WO',
		jc.cat as 'Area',
		CONCAT(ar.idArea,'-',ar.name) as 'Unit',
		sj.[description] as 'Sub Job',
		sc.location as 'Location',
		sc.purpose as 'Purpose',
		sc.buildDate as 'BuildDate',
		ds.dismantleDate as 'DemoDate',
		sc.foreman as 'Foreman',
		si.width as 'Width',
		si.[length] as 'Length',
		si.heigth as 'Heigth',
		ISNULL((si.descks + si.extraDeck),0) as 'Decks',
		ISNULL((select (ah.build + ah.material + ah.travel + ah.weather+ ah.alarm+ ah.[safety]+ ah.stdBy+ ah.other) from activityHours as ah where ah.tag = sc.tag and ah.idModAux IS NUll and ah.idDismantle IS NUll),0) as 'Erection Hours',
		pd.QID as 'QuanID',
		pd.idProduct as 'ProductId',
		pd.name as 'Product Name',
		ps.quantity as 'QTY',
		pd.[weight] as 'Weight',
		pd.dailyRentalRate as 'DailyRent'
		from scaffoldTraking as sc
		left join scaffoldInformation as si on si.tag = sc.tag
		left join dismantle as ds on ds.tag = sc.tag
		left join areas as ar on ar.idArea = sc.idArea 
		left join subJobs as sj on sj.idSubJob = sc.idSubJob
		left join jobCat as jc on jc.idJobCat = sc.idJobCat
		left join task as tk on tk.idAux = sc.idAux
		left join productScaffold as ps on ps.tag = sc.tag
		inner join product as pd on pd.idProduct = ps.idProduct
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		left join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAddress
		where sc.tag = @tagID 
		union all 
		select 
		sc.tag , 
		cl.photo as 'imgClient' ,
		ha.city as 'City',
		ha.providence as 'Providence',
		ha.postalCode as 'CP',
		jb.jobNo ,
		CONCAT(wo.idWO, '-' ,tk.task) as 'WO',
		jc.cat as 'Area',
		CONCAT(ar.idArea,'-',ar.name) as 'Unit',
		sj.[description] as 'Sub Job',
		sc.location as 'Location',
		sc.purpose as 'Purpose',
		sc.buildDate as 'BuildDate',
		ds.dismantleDate as 'DemoDate',
		sc.foreman as 'Foreman',
		si.width as 'Width',
		si.[length] as 'Length',
		si.heigth as 'Heigth',
		ISNULL((si.descks + si.extraDeck),0) as 'Decks',
		ISNULL((select(sum(ah.build)+sum(ah.material)+sum(ah.travel)+sum(ah.weather)+sum(ah.alarm)+sum(ah.[safety])+sum(ah.stdBy)+sum(ah.other)) from activityHours as ah where ah.tag = sc.tag and ah.idModAux = md.idModAux and ah.idDismantle IS NUll),0) as 'Erection Hours',
		pd.QID as 'QuanID',
		pd.idProduct as 'ProductId',
		pd.name as 'Product Name',
		pm.quantity as 'QTY',
		pd.[weight] as 'Weight',
		pd.dailyRentalRate as 'DailyRent'
		from scaffoldTraking as sc
		left join modification as md on md.tag = sc.tag
		left join scaffoldInformation as si on si.tag = sc.tag 
		left join dismantle as ds on ds.tag = sc.tag
		left join areas as ar on ar.idArea = sc.idArea 
		left join subJobs as sj on sj.idSubJob = sc.idSubJob
		left join jobCat as jc on jc.idJobCat = sc.idJobCat
		left join task as tk on tk.idAux = sc.idAux
		left join productModification as pm on pm.tag = sc.tag and pm.idModAux = md.idModAux
		inner join product as pd on pd.idProduct = pm.idProduct
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		left join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAddress
		where sc.tag = @tagID and md.idModification = @modID
	end
	else if @dis = 1
	begin
	select 
		sc.tag , 
		cl.photo as 'imgClient' ,
		ha.city as 'City',
		ha.providence as 'Providence',
		ha.postalCode as 'CP',
		jb.jobNo ,
		CONCAT(wo.idWO, '-' ,tk.task) as 'WO',
		jc.cat as 'Area',
		CONCAT(ar.idArea,'-',ar.name) as 'Unit',
		sj.[description] as 'Sub Job',
		sc.location as 'Location',
		sc.purpose as 'Purpose',
		sc.buildDate as 'BuildDate',
		ds.dismantleDate as 'DemoDate',
		sc.foreman as 'Foreman',
		si.width as 'Width',
		si.[length] as 'Length',
		si.heigth as 'Heigth',
		ISNULL((si.descks + si.extraDeck),0) as 'Decks',
		ISNULL((select (ah.build + ah.material + ah.travel + ah.weather+ ah.alarm+ ah.[safety]+ ah.stdBy+ ah.other) from activityHours as ah where ah.tag = sc.tag and ah.idModAux IS NUll and ah.idDismantle IS NUll),0) as 'Erection Hours',
		pd.QID as 'QuanID',
		pd.idProduct as 'ProductId',
		pd.name as 'Product Name',
		ps.quantity as 'QTY',
		pd.[weight] as 'Weight',
		pd.dailyRentalRate as 'DailyRent'
		from scaffoldTraking as sc
		left join scaffoldInformation as si on si.tag = sc.tag
		left join dismantle as ds on ds.tag = sc.tag
		left join areas as ar on ar.idArea = sc.idArea 
		left join subJobs as sj on sj.idSubJob = sc.idSubJob
		left join jobCat as jc on jc.idJobCat = sc.idJobCat
		left join task as tk on tk.idAux = sc.idAux
		left join productTotalScaffold as ps on ps.tag = sc.tag
		inner join product as pd on pd.idProduct = ps.idProduct
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		left join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAddress
		where sc.tag = @tagID and ds.tag = @tagID
	end
end
GO
--##############################################################################################
--################## SP SCAFFOLD ACTIVE ########################################################
--##############################################################################################
--ALTER proc [dbo].[sp_SCF_Active]
CREATE proc [dbo].[sp_SCF_Active]
@numberClient as int
as 
begin
select CONCAT(wo.idWO,' ',tk.task) as 'WO#', sc.tag as 'Tag' ,sc.location as 'Location','Build' as 'Task',
sc.buildDate as 'Build', IIF(ds.dismantleDate is null , DATEDIFF(DAY,sc.buildDate ,GETDATE()),DATEDIFF(DAY,sc.buildDate ,ds.dismantleDate)) as 'D.Ac.',
ds.dismantleDate as 'R. Stop', 
CONCAT(si.[length],' x ',si.width,' x ',si.heigth,' - ',(si.descks+si.extraDeck),' Deck (s)') as 'Scaffold Description',
sc.foreman as 'Foreman',
CONCAT(CONVERT(VARCHAR, sc.reqComp,101),' - ',sc.erector) as 'Comp - Req',
ISNULL((select SUM(IIF(pd.PLF <> 0,pd.PLF*psc.quantity,pd.PSQF*psc.quantity)) from productScaffold as psc 
	inner join product as pd on pd.idProduct = psc.idProduct 
	where psc.tag = sc.tag),0)as 'Leg',
ISNULL((select SUM(psc.quantity) from productScaffold as psc where psc.tag = sc.tag),0) as 'QTY'
from scaffoldTraking as sc
left join scaffoldInformation as si on si.tag = sc.tag
left join dismantle as ds on ds.tag = sc.tag
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO= tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where ds.idDismantle is null and cl.numberClient = @numberClient
end
GO
--##############################################################################################
--################## SP  SCF HISTORY BY JOB ####################################################
--##############################################################################################
--ALTER proc [dbo].[sp_SCF_History_By_Job]
CREATE proc sp_SCF_History_By_Job
@numberClient as int,
@all as bit
as
begin
select 
sc.tag as 'Tag',
sj.[description] as 'SubJob',
sc.location as 'Location',
CONCAT(sci.[type],'- ',sci.[length],' x',sci.width,' x',sci.heigth,'- ',(sci.descks+sci.extraDeck),' Decks') as 'Scaff Original Size',
'Build' as 'Task',
sc.buildDate as 'Start',
ds.dismantleDate as 'Demo',
IIF(DATEDIFF(DAY,sc.buildDate,ISNULL(ds.dismantleDate,GETDATE()))=0,1,DATEDIFF(DAY,sc.buildDate,ISNULL(ds.dismantleDate,GETDATE()))) as 'Days'
,ISNULL((select SUM(ptsc.quantity * pd.PLF) from productScaffold as ptsc 
	inner join product as pd on pd.idProduct = ptsc.idProduct where ptsc.tag = sc.tag),0) as 'PSQF'
,ISNULL((select SUM(ptsc.quantity * pd.PSQF) from productScaffold as ptsc 
	inner join product as pd on pd.idProduct = ptsc.idProduct where ptsc.tag = sc.tag),0) as 'PSQF'
,ISNULL((select sum(ptsc.quantity) from productScaffold as ptsc
	inner join product as pd on pd.idProduct = ptsc.idProduct where ptsc.tag = sc.tag),0) as 'QTY'
from scaffoldTraking as sc 
left join areas as ar on ar.idArea = sc.tag 
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join scaffoldInformation as sci on sci.tag = sc.tag
left join dismantle as ds on ds.tag = sc.tag 
inner join task as tk on tk.idAux = sc.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient like IIF(@all=1,'%%' , CONVERT(NVARCHAR, @numberClient))
union all
select 
md.tag as 'Tag',
sj.[description] as 'SubJob',
sc.location as 'Location',
CONCAT(sci.[type],'- ',sci.[length],' x',sci.width,' x',sci.heigth,'- ',(sci.descks+sci.extraDeck),' Decks') as 'Scaff Original Size',
'Mod' as 'Task',
md.modificationDate as 'Start',
ds.dismantleDate as 'Demo',
IIF(DATEDIFF(DAY,sc.buildDate,ISNULL(ds.dismantleDate,GETDATE()))=0,1,DATEDIFF(DAY,sc.buildDate,ISNULL(ds.dismantleDate,GETDATE()))) as 'Days'
,ISNULL((select SUM(ptmd.quantity * pd.PLF) from productModification as ptmd 
	inner join product as pd on pd.idProduct = ptmd.idProduct where ptmd.tag = sc.tag),0) as 'PSQF'
,ISNULL((select SUM(ptmd.quantity * pd.PSQF) from productModification as ptmd
	inner join product as pd on pd.idProduct = ptmd.idProduct where ptmd.tag = sc.tag),0) as 'PSQF'
,ISNULL((select sum(ptmd.quantity) from productModification as ptmd
	inner join product as pd on pd.idProduct = ptmd.idProduct where ptmd.tag = sc.tag),0) as 'QTY'
from modification md
left join scaffoldTraking as sc on sc.tag = md.tag
left join areas as ar on ar.idArea = sc.tag 
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join scaffoldInformation as sci on sci.tag = sc.tag
left join dismantle as ds on ds.tag = sc.tag 
inner join task as tk on tk.idAux = sc.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient like IIF(@all=1,'%%' , CONVERT(NVARCHAR, @numberClient))
order by [Tag],[Task]
end
GO
--##############################################################################################
--################## SP  SCF HISTORY BY JOB NO AND WO ##########################################
--##############################################################################################
--ALTER proc [dbo].[sp_SCF_History_By_Job_And_WO]
CREATE proc [dbo].[sp_SCF_History_By_Job_And_WO]
@startDate as date,
@FinalDate as date,
@numberClient as int
as
begin
select * , DATEDIFF(DAY,T1.buildDate,iif(T1.dismantleDate is null,getdate(),T1.dismantleDate)) as 'Days' from(
select md.tag as 'Tag No',sc.location as 'Location',sj.[description]as 'description',
CONCAT(scis.[type],'- ',scis.[length],' x',scis.width,' x',scis.heigth,'- ',(scis.descks+scis.extraDeck),' Decks')  as 'ScaffoldDescription',
iif(md.idModification is null,'Build','Mod') as 'Task',
sc.reqComp as 'dateRequest',md.requestBy as 'requestBy', isnull(md.modificationDate,'') as 'buildDate', dis.dismantleDate as 'dismantleDate'
,ISNULL( (select SUM(pdmd.quantity * pd.PLF) from productModification as pdmd 
	inner join product as pd on pd.idProduct = pdmd.idProduct where pdmd.idModAux = md.idModAux),0) as 'PLF'
,ISNULL( (select SUM(pdmd.quantity * pd.PSQF) from productModification as pdmd 
	inner join product as pd on pd.idProduct = pdmd.idProduct where pdmd.idModAux = md.idModAux),0) as 'PSQF'
,ISNULL( (select sum(pdmd.quantity) from productModification as pdmd 
	inner join product as pd on pd.idProduct = pdmd.idProduct where pdmd.idModAux = md.idModAux),0) as 'QTY'
,concat(wo.idWO,' ',tk.task)as 'workOrder'
,ISNULL(sj.[description],'') as 'SubJob'
from 
modification as md 
left join scaffoldTraking as sc on sc.tag = md.tag
left join areas as ar on ar.idArea = sc.idArea
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join scaffoldInformation as scis on scis.tag = sc.tag
left join dismantle as dis on dis.tag = sc.tag
left join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where sc.buildDate between @startDate and @FinalDate and cl.numberClient = @numberClient
union all
select sc.tag as 'Tag No',sc.location as 'Location',sj.[description]as 'description',
CONCAT(scis.[type],'- ',scis.[length],' x',scis.width,' x',scis.heigth,'- ',(scis.descks+scis.extraDeck),' Decks')  as 'ScaffoldDescription',
iif(sc.tag is not null,'Build','Mod') as 'Task',
sc.reqComp as 'dateRequest',sc.contact as 'requestBy', isnull(sc.buildDate,'') as 'buildDate', dis.dismantleDate as 'dismantleDate'
,ISNULL( (select SUM(pdsc.quantity * pd.PLF) from productScaffold as pdsc 
	inner join product as pd on pd.idProduct = pdsc.idProduct where pdsc.tag = sc.tag),0) as 'PLF'
,ISNULL( (select SUM(pdsc.quantity * pd.PSQF) from productScaffold as pdsc 
	inner join product as pd on pd.idProduct = pdsc.idProduct where pdsc.tag = sc.tag),0) as 'PSQF'
,ISNULL( (select SUM(pdsc.quantity) from productScaffold as pdsc 
	inner join product as pd on pd.idProduct = pdsc.idProduct where pdsc.tag = sc.tag),0) as 'PLF'
,concat(wo.idWO,' ',tk.task)as 'workOrder'
,ISNULL(sj.[description],'') as 'SubJob'
from 
scaffoldTraking as sc 
left join areas as ar on ar.idArea = sc.idArea
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join scaffoldInformation as scis on scis.tag = sc.tag
left join dismantle as dis on dis.tag = sc.tag
left join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where sc.buildDate between @startDate and @FinalDate and cl.numberClient = @numberClient
) T1
order by T1.[Tag No] , t1.Task
end
GO
--##############################################################################################
--################## SP REPORT SCAFFOLD HISTORY BY JOB NO ######################################
--##############################################################################################
--ALTER proc [dbo].[sp_SCF_History_By_JobNo] 
CREATE proc [dbo].[sp_SCF_History_By_JobNo] 
@startDate as date,
@FinalDate as date,
@numberClient as int
as
begin
select sc.tag, sc.location as 'Location',sj.[description] , CONCAT(sci.[type],'- ',sci.[length],' x',sci.width,' x',sci.heigth,'- ',(sci.descks+sci.extraDeck),' Decks') as 'ScaffoldDescription',
sc.reqComp as 'dateRequest',sc.contact as 'requestBy', isnull(sc.buildDate,'') as 'buildDate', dis.dismantleDate as 'dismantleDate',
IIF(DATEDIFF(DAY,sc.buildDate,isnull(dis.dismantleDate,GETDATE()))= 0,1,DATEDIFF(DAY,sc.buildDate,isnull(dis.dismantleDate,GETDATE()))) as 'Days'
,iif(sc.tag is not null,'Build','Mod') as 'Task'
,ISNULL( (select SUM(ptsc.quantity * pd.PLF) from productTotalScaffold as ptsc 
	inner join product as pd on pd.idProduct = ptsc.idProduct where ptsc.tag = sc.tag),0) as 'PLF'
,ISNULL((select SUM(ptsc.quantity * pd.PSQF) from productTotalScaffold as ptsc 
	inner join product as pd on pd.idProduct = ptsc.idProduct where ptsc.tag = sc.tag),0) as 'PSQF'
,ISNULL((select sum(ptsc.quantity) from productTotalScaffold as ptsc
	inner join product as pd on pd.idProduct = ptsc.idProduct where ptsc.tag = sc.tag),0) as 'QTY'
,ISNULL(sj.[description],'') as 'SubJob'
from scaffoldTraking as sc
left join areas as ar on ar.idArea = sc.idArea
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join scaffoldInformation as sci on sci.tag = sc.tag
left join dismantle as dis on dis.tag = sc.tag
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where sc.buildDate between @startDate and @FinalDate and cl.numberClient = @numberClient
end
GO
--##############################################################################################
--################## SP  SCF HISTORY BY JOB NO AND UNIT ########################################
--##############################################################################################
--ALTER proc [dbo].[sp_SCF_History_By_JobNo_And_Unit]
CREATE proc [dbo].[sp_SCF_History_By_JobNo_And_Unit]
@startDate as date,
@FinalDate as date,
@numberClient as int
as 
begin
select sc.tag, sc.location as 'Location',sj.[description] , CONCAT(sci.[type],'- ',sci.[length],' x',sci.width,' x',sci.heigth,'- ',(sci.descks+sci.extraDeck),' Decks') as 'ScaffoldDescription',
sc.reqComp as 'dateRequest',sc.contact as 'requestBy', isnull(sc.buildDate,'') as 'buildDate', dis.dismantleDate as 'dismantleDate',
IIF(sc.tag is not null,'Build','Mod') as 'Task',
IIF(DATEDIFF(DAY,sc.buildDate,isnull(dis.dismantleDate,GETDATE()))= 0,1,DATEDIFF(DAY,sc.buildDate,isnull(dis.dismantleDate,GETDATE()))) as 'Days'
,ISNULL( (select SUM(ptsc.quantity * pd.PLF) from productTotalScaffold as ptsc 
	inner join product as pd on pd.idProduct = ptsc.idProduct where ptsc.tag = sc.tag),0) as 'PLF'
,ISNULL((select SUM(ptsc.quantity * pd.PSQF) from productTotalScaffold as ptsc 
	inner join product as pd on pd.idProduct = ptsc.idProduct where ptsc.tag = sc.tag),0) as 'PSQF'
,ISNULL((select sum(ptsc.quantity) from productTotalScaffold as ptsc
	inner join product as pd on pd.idProduct = ptsc.idProduct where ptsc.tag = sc.tag),0) as 'QTY'
,CONCAT(ar.idArea,' ',ar.name) as 'Unit'
,ISNULL(sj.[description],'') as 'SubJob'
from scaffoldTraking as sc
left join areas as ar on ar.idArea = sc.idArea
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join scaffoldInformation as sci on sci.tag = sc.tag
left join dismantle as dis on dis.tag = sc.tag
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where sc.buildDate between @startDate and @FinalDate and cl.numberClient = @numberClient
end
GO
--##############################################################################################
--################## SP  SCF HISTORY DISMANTLE #################################################
--##############################################################################################
--ALTER proc [dbo].[sp_SCF_History_Dismantle]
CREATE proc [dbo].[sp_SCF_History_Dismantle]
@numberClient as int,
@all as bit
as 
begin
select 
sj.[description] as 'Log#',
sc.tag as 'Tag',
sc.buildDate as 'Date Ord.',
sc.reqComp as 'Date Request',
CONCAT(wo.idWO,' ',tk.task) as 'W.O.N',
cl.companyName  as 'Copany',
sc.contact as 'Requestee',
CONCAT(ar.idArea,' ',ar.Name) as 'Area',
CONCAT(sci.[type],'- ',sci.[length],' x',sci.width,' x',sci.heigth,'- ',(sci.descks+sci.extraDeck),' Decks') as 'Scaff Original Size',
sc.location as 'Location'
from scaffoldTraking as sc 
left join areas as ar on ar.idArea = sc.idArea
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join scaffoldInformation as sci on sci.tag = sc.tag
inner join task as tk on tk.idAux = sc.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient like IIF(@all=1,'%%' , CONVERT(NVARCHAR, @numberClient))
end
GO
--##############################################################################################
--################## SP SCF MATERIAL INVETORY ##################################################
--##############################################################################################
--ALTER proc [dbo].[sp_SCF_Material_Inventory]
CREATE proc [dbo].[sp_SCF_Material_Inventory]
@numberClient as int,
@all as bit
as
begin
select 
jb.jobNo,
pd.QID,
pd.idProduct ,
pd.name ,
ISNULL((select sum(pinc.quantity) from productComing as pinc 
inner join incoming as inc on inc.ticketNum = pinc.ticketNum
where inc.jobNo = jb.jobNo and pinc.idProduct = pj.idProduct),0) as 'Incoming', 
ISNULL((select sum(pout.quantity) from productOutGoing as pout 
inner join outgoing as outg on outg.ticketNum = outg.ticketNum
where outg.jobNo = jb.jobNo and pout.idProduct = pj.idProduct),0) as 'Outgoing',
ISNULL(pj.qty,0) as 'Inventory',
ISNULL((select sum(pts.quantity) from productTotalScaffold as pts
inner join scaffoldTraking as sc on sc.tag = pts.tag
inner join task as tk on tk.idAux = sc.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb1 on jb1.jobNo = po.jobNo
where jb1.jobNo = jb.jobNo and pts.idProduct = pj.idProduct),0) as 'OnRent',
ISNULL(pd.quantity,0) as 'InYard',
pd.[weight] as 'Weight'
from  productJob as pj  
inner join product as pd on pd.idProduct = pj.idProduct 
left join job as jb on jb.jobNo = pj.jobNo
inner join clients as cl on cl.idClient = jb.idClient 
where cl.numberClient like iif(@all = 1, '%%', concat('%',@numberClient,'%'))
ORDER BY pd.idProduct
end
GO
--##############################################################################################
--################## SP SCF RENTAL DETAILS #####################################################
--##############################################################################################
--ALTER proc [dbo].[sp_SCF_Rental_Details]
CREATE proc [dbo].[sp_SCF_Rental_Details]
@startDate date,
@FinalDate  date,
@numberClient int
as
begin 
	select * 
from(
select 
sc.tag,
cl.companyName,
sc.location as 'Location',
sj.[description] , 
CONCAT(wo.idWO,'-',tk.task) as 'PO/WONo',
CONCAT(sci.[type],'- ',sci.[length],' x',sci.width,' x',sci.heigth,'- ',(sci.descks+sci.extraDeck),' Decks') as 'ScaffoldDescription',
sc.reqComp as 'dateRequest',
sc.contact as 'requestBy', 
sc.buildDate as 'buildDate', 
--DATEADD(DAY,isnull(jc.[days],0),sc.buildDate) as 'ContractEndDate',
dis.dismantleDate as 'dismantleDate',
dis.rentStopDate as 'rentStopDate',
--isnull(jc.[days],0) as 'Contract days',
DATEDIFF(DAY,sc.buildDate,ISNULL(dis.rentStopDate,GETDATE())) as 'ActivityDays',
IIF(sc.tag is not null,'Build','Mod') as 'Task',
IIF( ISNULL(dis.rentStopDate,GETDATE()) >= @startDate --and sc.buildDate <= @startDate 
,
	IIF( DATEADD(DAY,isnull(jc.[days],0),sc.buildDate) <= @FinalDate -- EL DIA FINAL DE RENTA GRATIS ES MENOR O IGUAL AL FINALDATE?
	,-- SI ES MENOR O IGUAL POR LO TANTO SI HAY DIAS QUE COBRAR (ESTA DENTRO DEL RANGO)
		IIF(DATEADD(DAY,isnull(jc.[days],0),sc.buildDate) > @startDate -- (PUNTO DE INICIO) EL DIA FINAL DE RENTA GRATIS ES MAYOR AL STARTDATE?
		,--DIAFINAL DE RENTA GRATIS
			IIF(ISNULL(dis.rentStopDate,GETDATE()) < @FinalDate -- EL DIA FINAL DE RENTA GRATIS ES MENOR QUE EL FINALDATE?
			,DATEDIFF(DAY,DATEADD(DAY,isnull(jc.[days],0),DATEADD(DAY,-1,sc.buildDate)),ISNULL(dis.rentStopDate,GETDATE()))
			,DATEDIFF(DAY,DATEADD(DAY,isnull(jc.[days],0),DATEADD(DAY,-1,sc.buildDate)),@FinalDate))
		,--STARTDATE
			IIF(ISNULL(dis.rentStopDate,GETDATE()) < @FinalDate, 
				DATEDIFF(DAY,DATEADD(DAY,-1 ,@startDate),ISNULL(dis.rentStopDate,GETDATE())), 
				DATEDIFF(DAY,DATEADD(DAY,-1 ,@startDate),@finalDate))
		)	,-- NO ES MENOR O IGUAL POR ENDE NO HAY DIAS QUE COBAR (NO ESTA DENTRO DEL RANGO)
	0),0) AS 'DaysRent',
--IIF(DATEADD(DAY,isnull(jc.[days],0),sc.buildDate)<@FinalDate,1,0) as 'ExedContractDate',
(select COUNT(*) from productTotalScaffold where tag = sc.tag) AS 'QTY'
,pts.idProduct as 'idPrduct',
pts.quantity as 'qtyPoduct',
pd.name as 'productName',
ISNULL(pd.dailyRentalRate,0) as 'dailyRent',
(pts.quantity * ISNULL(pd.dailyRentalRate,0)) as 'Total'
from scaffoldTraking as sc 
left join areas as ar on ar.idArea = sc.idArea
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join jobCat as jc on jc.idJobCat = sc.idJobCat
left join scaffoldInformation as sci on sci.tag = sc.tag
left join dismantle as dis on dis.tag = sc.tag
left join productTotalScaffold as pts on pts.tag = sc.tag
inner join product as pd on pd.idProduct= pts.idProduct
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where cl.numberClient = @numberClient
) as T1 where T1.DaysRent > 0 
end
GO
--##############################################################################################
--################## SP REPORT SCAFFOLD ESTIMATE ###############################################
--##############################################################################################
--ALTER proc [dbo].[sp_scfEstimation]
CREATE proc [dbo].[sp_scfEstimation]
@ccnum as varchar(30),
@EstNumber as varchar(36),
@IdClient as varchar(36),
@all as bit
as 
begin 
	if @all = 1
	begin
		select 
				scfE.EstNumber,ISNULL(scfp.unit,'')as 'unit',ISNULL(scfP.ccnum,'') as 'ccnum',scfE.location,scfE.width,scfE.length,scfE.heigth,scfE.descks,scfE.daysActive,estM.DA,
				scfE.M3,scfE.M2,scfT.SCTP, ISNULL((select hFactor from scfFactor where heigth = scfe.heigth+scfe.groundHeigth),(select hFactor from scfFactor where heigth = (select MAX(heigth)from scfFactor) )) as 'Factor', scfT.BDRATE, estm.PMANHRS,
				estM.BPRICE,estM.DECKBP,estM.DPRICE,estM.DECKDP,
				estM.EDM3C,estM.EDM2C,estM.EDM3,estM.EDM2,
				estM.M3LBP,estM.M3LDP,estM.M2LBP,estM.M2LDP,
				estM.M3MBP,estM.M3MDP,estM.M2MBP,estM.M2MDP,
				estM.M3EBP,estM.M3EDP,estM.M2EBP,estM.M2EDP
			from scfEstimation as scfE
				inner join EstMeters as estM on estM.EstNumber = scfE.EstNumber
				inner join ScafEstCost as scfC on scfC.idEstCost = scfE.idEstCost
				inner join scfTypeCost as scfT on scfT.scfTypeId = scfE.scfTypeId 
				left join  scfEstProyect as scfP on scfP.ccnum = scfE.ccnum
			where idClient= @IdClient 
			order by scfP.ccnum
	end
	else if @ccnum<> '' and @all = 0
	begin
		select 
				scfE.EstNumber,ISNULL(scfp.unit,'')as 'unit',ISNULL(scfP.ccnum,'') as 'ccnum',scfE.location,scfE.width,scfE.length,scfE.heigth,scfE.descks,scfE.daysActive,estM.DA,
				scfE.M3,scfE.M2,scfT.SCTP, ISNULL((select hFactor from scfFactor where heigth = scfe.heigth+scfe.groundHeigth),(select hFactor from scfFactor where heigth = (select MAX(heigth)from scfFactor) )) as 'Factor', scfT.BDRATE, estm.PMANHRS,
				estM.BPRICE,estM.DECKBP,estM.DPRICE,estM.DECKDP,
				estM.EDM3C,estM.EDM2C,estM.EDM3,estM.EDM2,
				estM.M3LBP,estM.M3LDP,estM.M2LBP,estM.M2LDP,
				estM.M3MBP,estM.M3MDP,estM.M2MBP,estM.M2MDP,
				estM.M3EBP,estM.M3EDP,estM.M2EBP,estM.M2EDP
			from scfEstimation as scfE
				inner join EstMeters as estM on estM.EstNumber = scfE.EstNumber
				inner join ScafEstCost as scfC on scfC.idEstCost = scfE.idEstCost
				inner join scfTypeCost as scfT on scfT.scfTypeId = scfE.scfTypeId 
				left join  scfEstProyect as scfP on scfP.ccnum = scfE.ccnum
				where scfP.ccnum = @ccnum and scfE.idClient = @IdClient
			order by scfP.ccnum
	end
	else if @ccnum ='' and @all = 0
	begin
		select 
				scfE.EstNumber,ISNULL(scfp.unit,'')as 'unit',ISNULL(scfP.ccnum,'') as 'ccnum',scfE.location,scfE.width,scfE.length,scfE.heigth,scfE.descks,scfE.daysActive,estM.DA,
				scfE.M3,scfE.M2,scfT.SCTP, ISNULL((select hFactor from scfFactor where heigth = scfe.heigth+scfe.groundHeigth),(select hFactor from scfFactor where heigth = (select MAX(heigth)from scfFactor) )) as 'Factor', scfT.BDRATE, estm.PMANHRS,
				estM.BPRICE,estM.DECKBP,estM.DPRICE,estM.DECKDP,
				estM.EDM3C,estM.EDM2C,estM.EDM3,estM.EDM2,
				estM.M3LBP,estM.M3LDP,estM.M2LBP,estM.M2LDP,
				estM.M3MBP,estM.M3MDP,estM.M2MBP,estM.M2MDP,
				estM.M3EBP,estM.M3EDP,estM.M2EBP,estM.M2EDP
			from scfEstimation as scfE
				inner join EstMeters as estM on estM.EstNumber = scfE.EstNumber
				inner join ScafEstCost as scfC on scfC.idEstCost = scfE.idEstCost
				inner join scfTypeCost as scfT on scfT.scfTypeId = scfE.scfTypeId 
				left join  scfEstProyect as scfP on scfP.ccnum = scfE.ccnum
			where scfE.EstNumber =@EstNumber and idClient= @IdClient 
	end
end
GO
--##############################################################################################
--################## SP SELECT IMG CLIENT ######################################################
--##############################################################################################
--ALTER proc [dbo].[sp_select_Img_Client]
CREATE proc [dbo].[sp_select_Img_Client]
@numberClient  Int
as
begin
	set @numberClient=ISNULL(@numberClient,(select top 1 numberClient from clients))
	select photo from clients where numberClient = @numberClient
end
GO
--##############################################################################################
--################## SP SELECT MY COMPANY INFORMATION ##########################################
--##############################################################################################
--ALTER proc [dbo].[sp_select_MyComapny_Info]
CREATE proc sp_select_MyComapny_Info
@CompanyName varchar(30)
as
begin
select cmp.name,
	ha.city,
	ha.providence,
	CONCAT(ha.avenue , ' ',ha.number) as 'Address',
	ha.postalCode,
	cmp.idContact,
	cmp.invoiceDescr,
	ct.email,
	ct.phoneNumber1 as 'PhoneNumber1',
	ct.phoneNumber2 as 'PhoneNumber2',
	cmp.img
from company as cmp 
left join HomeAddress as ha on ha.idHomeAdress	= cmp.idHomeAddress
left join contact as ct on ct.idContact = cmp.idContact
end
GO
--##########################################################################################################################################################################################################################
--########## PROCEDIMENTO PARA REPORTE DE EQUIPMENT BUDGET ESTIMATION ######################################################################################################################################################
--##########################################################################################################################################################################################################################
--ALTER proc [dbo].[sp_SelectEquipmentBudgetEstimate]
CREATE proc [dbo].[sp_SelectEquipmentBudgetEstimate]
	@projectId as varchar(30)
as
begin 
	select 
	cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
	estCEq.tag as 'ID',
	estCEq.idDrawingNum as 'Drawing',
	po.projectId as 'Project',
	po.[description] as 'Description',
	eq.[description] as 'Equipment', 
	eq.elevation as 'Height',
	eq.systemPntEq as 'System',
	eq.pntOption as 'Paint Option',
	eq.[type] as 'Ins Type',
	eq.thick as 'Ins Thick',
	eq.idJacket as 'JKT',
	'Insul Removal' as 'TaskRmv',
	eq.sqrFtRmv as 'SqrFtRmv',
	'Insul Install' as 'TaskII',
	eq.sqrFtII as 'SqrFtII',
	eq.bevel as 'Bevel',
	eq.cutout as 'Cut Out',
	'Paint' as 'TaskPnt',
	eq.sqrFtPnt as 'SqrFtPnt',
	eq.acm as 'ACM',	
	--remove
	ISNULL(eq.idLaborRateRmv,'') as 'WW Rmv',
	estCEq.EIRHRS as 'Horas Rmv',
	ISNULL(estCEq.EIRCOSTL,0) as 'Labor Rmv',
	estCEq.EIRCOSTM as 'Materal Rmv',
	estCeq.EIRCOSTE as 'Equipment Rmv',
	--instalation
	ISNULL(eq.idLaborRateII,'') as 'WW II',
	estceq.EIIHRS as 'Horas II', 
	ISNULL(estCEq.EIICOSTL,0) as 'Labor II' ,
	estCEq.EIICOSTM as 'Material II',
	estCEq.EIICOSTE as 'Equipment II',
	--paint
	ISNULL(eq.idLaborRatePnt,'') as 'WW Pnt',
	estCEq.EPHRS as 'Horas Pnt',
	ISNULL(estCEq.EPCOSTL,0) as 'Labor Pnt',
	estCEq.EPCOSTM as 'Material Pnt',
	estCEq.EPCOSTE as 'Equipment Pnt'
	from EstCostEq as estCEq
	inner join equipmentEst as eq on eq.idEquimentEst = estCEq.tag and eq.idDrawingNum = estCEq.idDrawingNum 
	inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum and dr.idDrawingNum = estCEq.idDrawingNum  
	inner join projectClientEst as po on po.projectId = dr.projectId and estCEq.projectId = po.projectId
	inner join clientsEst as cl on cl.idClientEst =po.idClientEst
	inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress
	where po.projectId =@projectId
end
GO
--##############################################################################################
--################## SP SELECT ESTIMATION COST BY PROJECT ######################################
--##############################################################################################

--ALTER proc [dbo].[sp_SelectEstCostByProject]
CREATE proc [dbo].[sp_SelectEstCostByProject]
@projectId as varchar(40)
as 
begin
-- scaffold
--decks dismantle scf
select po.ProjectId, po.[description],po.unit,
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
dr.idDrawingNum,dr.[description],
CONVERT(NVARCHAR, scfD.tag)as 'Tag' ,'SCF Deck DISM' as 'TASK',scfD.SHRD as 'HRS',scfD.DSCOSTL as 'COSTL',scfD.DSCOSTM as 'COSTM',scfD.SCOSTEDD as 'COSTE',scfD.DSCOSTL + scfD.DSCOSTMD + scfD.SCOSTEDD  as 'TCOST' 
from EstCostDism as scfD
inner join drawing as dr on dr.idDrawingNum = scfD.idDrawingNum
inner join projectClientEst as po on po.projectId = scfD.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
where po.ProjectId = @projectId
--decks build scf
UNION ALL
select po.ProjectId, po.[description],po.unit,
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
dr.idDrawingNum,dr.[description],
CONVERT(NVARCHAR, scfB.tag)as 'Tag' ,'SCF Deck Build' as 'TASK',scfB.SBHR as 'HRS',scfB.SCOSTLB as 'COSTL',scfB.SCOSTMB as 'COSTM',scfB.SCOSTEB as 'COSTE', scfB.STCOST as 'TCOST' 
from EstCostBuild as scfB
inner join drawing as dr on dr.idDrawingNum = scfB.idDrawingNum
inner join projectClientEst as po on po.projectId = scfB.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
where po.ProjectId = @projectId
--Build Scaffold
UNION ALL
select po.ProjectId, po.[description],po.unit,
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
dr.idDrawingNum,dr.[description],
CONVERT(NVARCHAR, scf.tag)as 'Tag' , 'Scf Build' as 'TASK', scf.SHR as 'HRS',scf.SCOSTL as 'COSTL',scf.SCOSTM as 'COSTM',scf.SCOSTE as 'COSTE',scf.STCOST as 'TCOST' 
from EstCostScf as scf
inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
inner join projectClientEst as po on po.projectId = scf.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
where po.ProjectId = @projectId
--Dimantle Scaffold
UNION ALL
select po.ProjectId, po.[description],po.unit,
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
dr.idDrawingNum,dr.[description],
CONVERT(NVARCHAR, scf.tag)as 'Tag' , 'SCF Demo' as 'TASK', scf.SDHR as 'HRS',scf.SCOSTLD as 'COSTL',scf.SCOSTMD as 'COSTM',scf.SCOSTED as 'COSTE',scf.STCOSTD as 'TCOST' 
from EstCostScf as scf
inner join drawing as dr on dr.idDrawingNum = scf.idDrawingNum
inner join projectClientEst as po on po.projectId = scf.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
where po.ProjectId = @projectId
-- EQUIPMENT 
--REMOVE
UNION ALL
select po.ProjectId, po.[description],po.unit,
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
dr.idDrawingNum,dr.[description],
CONVERT(NVARCHAR, eq.tag) as 'Tag', 'Remove' as 'TASK',eq.EIRHRS as 'HRS',eq.EIRCOSTL as 'COSTL',eq.EIRCOSTM as 'COSTM',eq.EIRCOSTE as 'COSTE', eq.EIRTCOST as 'TCOST'   from EstCostEq as eq
inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum
inner join projectClientEst as po on po.projectId = eq.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
where po.ProjectId = @projectId
--INSTALATION
UNION ALL 
select po.ProjectId, po.[description],po.unit,
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
dr.idDrawingNum,dr.[description],
CONVERT(NVARCHAR, eq.tag) as 'Tag', 'Install' as 'TASK', eq.EIIHRS as 'HRS',eq.EIICOSTL as 'COSTL',eq.EIICOSTM as 'COSTM',eq.EIICOSTE as 'COSTE', eq.EIITCOST as 'TCOST'   from EstCostEq as eq
inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum
inner join projectClientEst as po on po.projectId = eq.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
where po.ProjectId = @projectId
--PAINT
UNION ALL
select po.ProjectId, po.[description],po.unit,
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
dr.idDrawingNum,dr.[description],
CONVERT(NVARCHAR, eq.tag) as 'Tag','Paint' as 'TASK',eq.EPHRS as 'HRS',eq.EPCOSTL as 'COSTL',eq.EPCOSTM as 'COSTM',eq.EPCOSTE as 'COSTE', eq.EPTCOST as 'TCOST'   from EstCostEq as eq
inner join drawing as dr on dr.idDrawingNum = eq.idDrawingNum
inner join projectClientEst as po on po.projectId = eq.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
where po.ProjectId = @projectId
--PIPING
--REMOVE
UNION ALL
select po.ProjectId, po.[description],po.unit,
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
dr.idDrawingNum,dr.[description],
CONVERT(NVARCHAR , pp.tag) as 'TAG',  'Remove'as 'TASK', pp.PIRHRS as 'HRS', pp.PIRCOSTL as 'COSTL',pp.PIRCOSTM as 'COSTM',pp.PIRCOSTE as 'COSTE', pp.PIRTCOST as 'TCOST'  from EstCostPp as pp
inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
inner join projectClientEst as po on po.projectId = pp.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
where po.ProjectId = @projectId
--INSTALATION
UNION ALL
select po.ProjectId, po.[description],po.unit,
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
dr.idDrawingNum,dr.[description],
CONVERT(NVARCHAR , pp.tag) as 'TAG', 'Install' as 'TASK', pp.PIIHRS as 'HRS', pp.PIICOSTL as 'COSTL',pp.PIICOSTM as 'COSTM',pp.PIICOSTE as 'COSTE', pp.PIITCOST as 'TCOST'  from EstCostPp as pp
inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
inner join projectClientEst as po on po.projectId = pp.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
where po.ProjectId = @projectId
--PAINT
UNION ALL
select po.ProjectId, po.[description],po.unit,
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
dr.idDrawingNum,dr.[description],
CONVERT(NVARCHAR , pp.tag) as 'TAG','Paint' as 'TASK' , pp.PPHRS as 'HRS', pp.PPCOSTL as 'COSTL',pp.PPCOSTM as 'COSTM',pp.PPCOSTE as 'COSTE', pp.PPTCOST as 'TCOST'  from EstCostPp as pp
inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum
inner join projectClientEst as po on po.projectId = pp.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress 
where po.ProjectId = @projectId
end
GO
----#########################################################################################################################################################################################
----############## PROCEDIMINETO PARA CONSULTA DE MATERIALES EN EXCEL WORKING ###############################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_selectJobMaterialCost]
CREATE proc [dbo].[sp_selectJobMaterialCost]
@StartDate as date,
@EndDate as date
as
begin
	select jb1.jobNo,mc1.code as 'Code' ,mt1.name as 'Material Name',mu1.[description] as 'Description',amount as 'Cost',CONVERT(NVARCHAR,dateMaterial,101) as 'Date',
	CASE 
		WHEN SUBSTRING(mc1.code ,LEN(mc1.code),1) = 'D' THEN '3rd Party Cost'
		WHEN SUBSTRING(mc1.code ,LEN(mc1.code),1) = 'E' THEN 'In House Vehicles'
		WHEN SUBSTRING(mc1.code ,LEN(mc1.code),1) = 'F' THEN 'Company Equipment'
		WHEN SUBSTRING(mc1.code ,LEN(mc1.code),1) = 'M' THEN 'Material Cost'
		WHEN SUBSTRING(mc1.code ,LEN(mc1.code),1) = 'S' THEN 'Subcontract Cost'
		WHEN SUBSTRING(mc1.code ,LEN(mc1.code),1) = 'T' THEN 'Tools'
		WHEN SUBSTRING(mc1.code ,LEN(mc1.code),1) = 'V' THEN 'Consumables'
		WHEN SUBSTRING(mc1.code ,LEN(mc1.code),1) = 'Y' THEN 'Other Cost'
		END  as 'Type Material' 
	from materialUsed as mu1
		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
		left join materialClass as mc1 on mt1.code = mc1.code
		inner join task as tk1 on tk1.idAux = mu1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where  mu1.dateMaterial between @StartDate and @EndDate 
		order by mu1.dateMaterial,mc1.code asc
end
GO
----#########################################################################################################################################################################################
----######## PROCEDIMIENTO PARA EXCEL DE WORKING ############################################################################################################################################
----#########################################################################################################################################################################################
--ALTER proc [dbo].[sp_selectJobTaxesExcel] 
CREATE proc [dbo].[sp_selectJobTaxesExcel] 
@StartDate as date, 
@EndDate as date 
as
begin
select T1.jobNo ,T1.[ST Hours] ,T1.[OT Hours],T1.[Total Hours] ,T1.[Labor Cost] ,T1.[Scaffold-ADD] ,
	T1.[3rd Party Cost],T1.[In House Vehicles],T1.[Company Equipment] ,T1.[Material Cost],T1.[Subcontract Cost] ,
	T1.[Tools] ,T1.[Consumables] ,T1.[Other Cost] , T1.[Other Revanue],
	ISNULL(txs.FICA,0) as 'FICA',
	ISNULL(txs.FUI,0) as 'FUI',
	ISNULL(txs.SUI,0) as 'SUI',
	ISNULL(txs.WC,0) as 'WC',
	ISNULL(txs.GenLiab,0) as 'Gen Liab',
	ISNULL(txs.Umbr,0) as 'Umbr',
	ISNULL(txs.Pollution,0) as 'Pollution',
	ISNULL(txs.Healt,0) as 'Healt',
	ISNULL(txs.Fringe,0) as 'Fringe',
	ISNULL(txs.Small,0) as 'Small',
	ISNULL(txs.PPE,0) as 'PPE',
	ISNULL(txs.Consumable,0) as 'Consumable',
	ISNULL(txs.Overhead,0) as 'Overhead',
	ISNULL(txs.Profit,0) as 'Profit',
	ISNULL(txP.FICA,0) as 'FICA P',
	ISNULL(txP.FUI,0) as 'FUI P',
	ISNULL(txP.SUI,0) as 'SUI P',
	ISNULL(txP.WC,0) as 'WC P',
	ISNULL(txP.GenLiab,0) as 'Gen Liab P',
	ISNULL(txP.Umbr,0) as 'Umbr P',
	ISNULL(txP.Pollution,0) as 'Pollution P',
	ISNULL(txP.Healt,0) as 'Healt P',
	ISNULL(txP.Fringe,0) as 'Fringe P',
	ISNULL(txP.Small,0) as 'Small P',
	ISNULL(txP.PPE,0) as 'PPE P',
	ISNULL(txP.Consumable,0) as 'Consumable P',
	ISNULL(txP.Overhead,0) as 'Overhead P',
	ISNULL(txP.Profit,0) as 'Profit P'
from(
select distinct jb.jobNo,
	ISNULL((select SUM(hw1.hoursST) from hoursWorked as hw1 
		inner join task as tk1 on tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'ST Hours',
	ISNULL((select SUM(hw1.hoursOT+hw1.hours3 ) from hoursWorked as hw1 
		inner join task as tk1 on tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'OT Hours',
	ISNULL((select SUM(hw1.hoursST+hw1.hoursOT+hw1.hours3) from hoursWorked as hw1 
		inner join task as tk1 on tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'Total Hours',
	ISNULL((select ROUND(SUM((hw1.hoursST*wc1.billingRate1)+(hw1.hoursOT*wc1.billingRateOT)+(hw1.hours3*wc1.billingRate3)),2) from hoursWorked as hw1 
		left join workCode as wc1 on wc1.idWorkCode= hw1.idWorkCode and wc1.jobNo = hw1.jobNo
		inner join task as tk1 on tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'Labor Cost',
	ISNULL((select Scaffold from taxesST where jobNo = jb.jobNo),0) as 'Scaffold-ADD',
	ISNULL((select SUM(amount) from materialUsed as mu1
		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
		left join materialClass as mc1 on mt1.code = mc1.code
		inner join task as tk1 on tk1.idAux = mu1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='D'),0) AS '3rd Party Cost',
	ISNULL((select SUM(amount) from materialUsed as mu1
		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
		left join materialClass as mc1 on mt1.code = mc1.code
		inner join task as tk1 on tk1.idAux = mu1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='E'),0) AS 'In House Vehicles',
	ISNULL((select SUM(amount) from materialUsed as mu1
		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
		left join materialClass as mc1 on mt1.code = mc1.code
		inner join task as tk1 on tk1.idAux = mu1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='F'),0) AS 'Company Equipment',
	ISNULL((select SUM(amount) from materialUsed as mu1
		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
		left join materialClass as mc1 on mt1.code = mc1.code
		inner join task as tk1 on tk1.idAux = mu1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='M'),0) AS 'Material Cost',
	ISNULL((select SUM(amount) from materialUsed as mu1
		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
		left join materialClass as mc1 on mt1.code = mc1.code
		inner join task as tk1 on tk1.idAux = mu1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='S'),0) AS 'Subcontract Cost',
	ISNULL((select SUM(amount) from materialUsed as mu1
		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
		left join materialClass as mc1 on mt1.code = mc1.code
		inner join task as tk1 on tk1.idAux = mu1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='T'),0) AS 'Tools',
	ISNULL((select SUM(amount) from materialUsed as mu1
		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
		left join materialClass as mc1 on mt1.code = mc1.code
		inner join task as tk1 on tk1.idAux = mu1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='V'),0) AS 'Consumables',
	ISNULL((select SUM(amount) from materialUsed as mu1
		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
		left join materialClass as mc1 on mt1.code = mc1.code
		inner join task as tk1 on tk1.idAux = mu1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='Y'),0) AS 'Other Cost',
	(select ROUND(ISNULL(SUM(amount),0),2) 
		from expensesUsed as exu1 
		inner join task as tk1 on tk1.idAux = exu1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and po1.jobNo = wo1.jobNo
		inner join job as jb1 on jb1.jobNo = po1.jobNo
		where jb1.jobNo = jb.jobNo and exu1.dateExpense between @StartDate and @EndDate ) as 'Other Revanue'
from job as jb
left join projectOrder as po on po.jobNo = jb.jobNo
left join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = po.idPO
left join task as tk on tk.idAuxWO = wo.idAuxWO 
left join hoursWorked as hw on hw.idAux = tk.idAux
) as T1 
left join taxesST as txs on txs.jobNo = T1.jobNo
left join taxesPT as txp on txp.jobNo = T1.jobNo
end
GO
--##########################################################################################################################################################################################################################
--########## PROCEDIMENTO PARA REPORTE DE PIPING BUDGET ESTIMATION #########################################################################################################################################################
--##########################################################################################################################################################################################################################
--ALTER proc [dbo].[sp_SelectPipingBudgetEstimate]
CREATE proc [dbo].[sp_SelectPipingBudgetEstimate]
	@projectId as varchar(30)
as
begin
	select 
	cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
	estCPp.tag as 'ID',
	pp.acm as 'ACM',
	pp.st as 'ST',
	estCPp.idDrawingNum as 'Drawing',
	po.projectId as 'Project',
	po.[description] as 'Description',
	pp.line as 'PipingDescription',
	pp.size as 'PZ',
	pp.elevation as 'Elevation',
	pp.systemPntPP as 'System',
	pp.pntOption as 'Paint Option',
	pp.[type] as 'InsType',
	pp.thick as 'InsThick',
	pp.idJacket as 'JKT',
	pp.lFtRmv as 'LnFtRmv',
	ISNULL(pp.idLaborRateRmv,'') as 'LaborRateRmv',
	ISNULL(pp.lFtII,0) as 'LnFtII',
	ISNULL(pp.p90II,0) as '90II',
	ISNULL(pp.p45II,0) as '45II',
	ISNULL(pp.pBendII,0) as 'BendII',
	ISNULL(pp.pTeeII,0) as 'TEEII',
	ISNULL(pp.pReducII,0) as 'REDII',
	ISNULL(pp.pCapsII,0) as 'CapII',
	ISNULL(pp.pPairII,0) as 'PairII',
	ISNULL(pp.pVlvII,0) as 'VlvII',
	ISNULL(pp.pControlII,0) as 'CtrlII',
	ISNULL(pp.pWeldII,0) as 'WldII',
	ISNULL(pp.pCutOutII,0) as 'CutOut',
	ISNULL(pp.psupportII,0) as 'SpptII',
	ISNULL(pp.idLaborRateII,'') as 'LaborRateII',
	ISNULL(pp.lFtPnt,0) as 'LnFtPnt',
	ISNULL(pp.p90Pnt,0) as '90Pnt',
	ISNULL(pp.p45Pnt,0) as '45Pnt',
	ISNULL(pp.pTeePnt,0) as 'TEEPnt',
	ISNULL(pp.pPairPnt,0) as 'PairPnt',
	ISNULL(pp.pVlvPnt,0) as 'VlvPnt',
	ISNULL(pp.pControlPnt,0) as 'CtrlPnt',
	ISNULL(pp.pWeldPnt,0) as 'WldPnt',
	ISNULL(pp.idLaborRatePnt,'') as 'LaborRatePnt',
	ISNULL(estCPp.PIRHRS,0) as 'ManHrsRmv',
	ISNULL(estCPp.PIIHRS,0) as 'ManHrsII',
	ISNULL(estCPp.PPHRS,0) as 'ManHrsPnt',
	ISNULL(estCPp.PIRCOSTL,0) as 'LaborRmv',
	ISNULL(estCPp.PIICOSTL,0) as 'LaborII',
	ISNULL(estCPp.PPCOSTL,0) as 'LaborPnt',
	ISNULL(estCPp.PIRCOSTM,0) as 'MaterialRmv',
	ISNULL(estCPp.PIICOSTM,0) as 'MaterialII',
	ISNULL(estCPp.PPCOSTM,0)  as 'MaterialPnt',
	ISNULL(estCPp.PIRCOSTE,0) as 'EquipmentRmv',
	ISNULL(estCPp.PIICOSTE,0) as 'EquipmentII',
	ISNULL(estCPp.PPCOSTE,0)  as 'EquipmentPnt' 
from EstCostPp as estCPp 
inner join pipingEst as pp on pp.idPipingEst = estCPp.tag and pp.idDrawingNum = estCPp.idDrawingNum
inner join drawing as dr on dr.idDrawingNum = pp.idDrawingNum and dr.idDrawingNum = estCPp.idDrawingNum
inner join projectClientEst as po on po.projectId = dr.projectId and po.projectId = estCPp.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress
where po.projectId = @projectId
end
GO
--##########################################################################################################################################################################################################################
--########## PROCEDIMENTO PARA REPORTE DE SCAFFOLD BUDGET ESTIMATION #######################################################################################################################################################
--##########################################################################################################################################################################################################################
--ALTER proc [dbo].[sp_SelectScaffoldBudgetEstimate]
CREATE proc [dbo].[sp_SelectScaffoldBudgetEstimate]
	@projectId as varchar(30)
as
begin
select 
cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
po.projectId as 'Project' ,po.[description] as 'Description',estCScf.tag , dr.idDrawingNum , scf.location as 'Location', CONCAT(scf.width,'x',scf.[length],'x',scf.heigth) as 'Dimention',scf.build as 'Elevation',
scf.[days] as 'Days Active',scf.idSCFUR as 'Scaf.Type', FORMAT ((((scf.width)*(scf.[length])*(scf.heigth))/35.31),'###.00') as 'M3',estCScf.M2 as 'M2', scf.idLaborRate as 'Work Week' ,
--MAN HRS 
estCScf.SBHR as 'Man Hrs B' ,estCScf.SDHR as 'Man Hrs D',
--MAN HRS DECKS
ISNULL(ROUND((select top 1 estB.SBHRD from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0),0) as 'Man Hrs Deck B',
ISNULL(ROUND((select top 1 estD.SDHRD from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0),0) as 'Man Hrs Deck D',
scf.decks as 'Decks',
--DESCKS LABOR
ISNULL((select estB.SCOSTLB from EstCostBuild as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'Decks Labor B',
ISNULL((select estD.DSCOSTL from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'Decks Labor D',
--SCAF LABOR 
ISNULL((select estB.SCOSTLB from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Labor B',
ISNULL((select estB.SCOSTLD from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Labor D',
--MATERIAL
ISNULL((select estB.SCOSTMB from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Material B',
ISNULL((select estD.SCOSTMD from EstCostScf as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'SCF Material D',
ISNULL((select estB.SCOSTMB from EstCostBuild as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'DECK Material B',
ISNULL((select estD.DSCOSTMD from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'DECK Material D',
--EQUIPMENT
ISNULL((select estB.SCOSTEB from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Equipment B',
ISNULL((select estD.SCOSTED from EstCostScf as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'SCF Equipment D',
ISNULL((select estB.SCOSTEB from EstCostBuild as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'DECK Equipment B',
ISNULL((select estD.SCOSTEDD from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'DECK Equipment D'

from EstCostScf as estCScf
inner join scaffoldEst as scf on scf.idDrawingNum = estCScf.idDrawingNum and scf.tag = estCScf.tag
inner join drawing as dr on dr.idDrawingNum = estCScf.idDrawingNum
inner join projectClientEst as po on po.projectId = estCScf.projectId
inner join clientsEst as cl on cl.idClientEst = po.idClientEst
inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress
where estCScf.projectId = @projectId
end
GO
--##############################################################################################
--################## SP UPDATE CLIENT ##########################################################
--##############################################################################################
--ALTER proc [dbo].[sp_Update_Client]
CREATE proc [dbo].[sp_Update_Client]
	@idCL varchar(36),
	@ClientID int,
	@FirstName varchar (30),
	@MiddleName varchar (30),
	@LastName varchar (30),
	@CompanyName varchar (50),
	@Status char(1),
	--Contact
	@idContact varchar(36),
	@phoneNumer1 varchar(13),
	@phoneNumer2 varchar(13),
	@email varchar(50),
	--Addres
	@idAddres varchar(36),
	@avenue varchar(80),
	@number int,
	@city varchar (20),
	@providence varchar (20),
	@postalcode int,
	@img image,
	@payTerms varchar(30)
as
declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
begin 
	begin tran 
		begin try
			--se inserta un contacto

				update contact set phoneNumber1= @phoneNumer1 , phoneNumber2=@phoneNumer2 ,email = @email where idContact = @idContact
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
				update HomeAddress set avenue= @avenue, number = @number , city=@city , providence =@providence, postalCode = @postalcode where idHomeAdress = @idAddres
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
				update  clients set firstName= @FirstName,middleName= @MiddleName,lastName= @LastName ,companyName=@CompanyName,estatus = @Status, photo = @img ,payTerms = @payTerms where idClient = @idCL
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
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
GO
--##############################################################################################
--################## SP UPDATE EMPLOYEE ########################################################
--##############################################################################################
CREATE proc [dbo].[sp_update_Employee]
	@idEmployee varchar(36),
	@idAddress varchar(36),
	@idContact varchar(36),
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
	----pay
	--@payRate1 float,
	--@payRate2 float, 
	--@payRate3 float,
	--type 
	@type varchar(20),
	@perdiem bit,
	@msg varchar(50) output
as 
declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
begin
	begin tran --inicio tran
		begin try --inicio try
			--if @avenue <> '' begin -- solo se necesita saber si la calle tiene algo 
				set @msg = 'Error at moment to save Address data'
				update HomeAddress set avenue = @avenue ,number =@number ,city =@city ,providence =@providence ,postalcode = @postalCode where idHomeAdress = @idAddress
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
				
				set @msg = 'Error at moment to save Contact data'
				update contact set phoneNumber1 =@phoneNumber1 , phoneNumber2 =@phoneNumber2 , email = @email where idContact = @idContact
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			--end
			----if @payRate1 <> '' begin
			--	set @msg = 'Error at moment to save Pay Rate data'
			--	update payRate set payRate1 = @payRate1,payRate2= @payRate2 , payRate3 = @payRate3 where idPayRate = @idPay and idEmployee = @idEmployee
			--	if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			----end
			--if @firstName <> '' or @numberEmploye > 0 begin
				set @msg = 'Error at moment to save Employee data'	
				update employees set  numberEmploye = @numberEmploye ,firstName = @firstName , lastName = @lastName ,middleName = @middleName,socialNumber = @socialNumber ,SAPNumber = @SAPNumber,photo = @photo , estatus = @estatus,typeEmployee = @type, perdiem = @perdiem where idEmployee = @idEmployee
				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
			--end
			set @msg = 'Succesfull'
		end try	
		begin catch
			goto solveproblem -- en caso de error capturado en el catch no vamos a solveproblem y evitamos en commit
		end catch
	commit tran 
	solveproblem:
	if @error <> 0
	begin 
		rollback tran -- el rollback es para deshacer todos lo cambios hechos anteriormente
		return @msg
	end
end
GO
--##############################################################################################
--################## SP UPDATE TOTAL SPEND #####################################################
--##############################################################################################
--ALTER proc [dbo].[sp_UpdateTotalSpendTask]
CREATE proc [dbo].[sp_UpdateTotalSpendTask]
 @idAux varchar(36)
as
declare @total as float
declare @horasST as float
declare @horasOT as float
declare @horasO3 as float
declare @expenses as float
declare @material as float
begin

	--Total de gastos de horas St
	set @horasST = 		
		(select top 1 
		(select SUM(T2.Amount) as 'Total Amount ST' from 
		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
		from (select idHorsWorked,hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=tk.idAux)as T1    
		group by T1.idWorkCode) as T2
		) as 'ST'
	from 
	task as tk 
	where tk.idAux = @idAux
	)
	--Total de gastos de horas OT
	set @horasOT =		
		(select top 1 
		(select SUM(T2.Amount) as 'Total Amount OT' from 
		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
		from (select idHorsWorked,hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=tk.idAux)as T1    
		group by T1.idWorkCode) as T2
		) as 'OT'
	from
	task as tk
	where tk.idAux = @idAux
	)
	--Total gastos horas 3
	set @horasO3 =
		(select top 1 
		(select SUM(T2.Amount) as 'Total Amount OT' from 
		(select SUM(T1.hours3*T1.billingRate3) AS 'Amount'
		from (select idHorsWorked,hours3, hw.idWorkCode , billingRate3  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=tk.idAux)as T1    
		group by T1.idWorkCode) as T2
		) as 'OT3'
	from 
	task AS tk 
	where tk.idAux = @idAux
	)

	--'Total Expenses Spend'
	set @expenses = (select top 1 (select SUM( amount) from expensesUsed where idAux = @idAux))

	--Total Material Spend
	set @material = (select top 1 (select sum (amount) from materialUsed where idAux = @idAux))
	
	if (@horasST IS Null) 
	begin 
		set @horasST =0.0
	end
	if (@horasOT IS NUll)
	begin 
		set @horasOT =0.0
	end
	if (@horasO3  IS NULL)
	begin 
		set @horasO3 =0.0
	end
	if (@expenses IS NULL)
	begin 
		set	@expenses=0.0 
	end
	if (@material IS NULL)
	begin 
		set	@material =0.0
	end

	set @total = @horasST + @horasOT + @horasO3 + @expenses + @material

	update task set totalSpend = @total where idAux = @idAux
end
GO
--##############################################################################################
--################## SP VACATION EMPLOYEE ######################################################
--##############################################################################################
--ALTER proc [dbo].[Sp_Vacation_Employee]
CREATE proc [dbo].[Sp_Vacation_Employee]
@NoEmployee int,
@year nVarchar(4),
@all bit
as
begin
    set @year = isnull(@year, DATENAME(YEAR,GETDATE()))
		
		if @all = 0 begin
		select t1.[Employee],t1.[Emp: Number],t1.[Day],t1.[Project Name],t1.[Work Description],t1.[Rate ST],
	    t1.[hoursST],T1.[Rate OT] ,t1.[hoursOT] 
		from(
		select distinct
			CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee', 
			em.numberEmploye as 'Emp: Number' ,
			hw.dateWorked as 'Day',
			concat(wo.idWO,'-',tk.task) as 'Project Name',
			SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Work Description',
			wc.billingRate1 as 'Rate ST',
			(select iif(SUM(hw1.hoursST)  is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursST',
			wc.billingRateOT as 'Rate OT',
			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursOT'
			from hoursWorked as hw 
			inner join employees as em on hw.idEmployee = em.idEmployee
			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
			inner join task as tk on tk.idAux = hw.idAux 
			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
			inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
			inner join job as jb on jb.jobNo = po.jobNo
			where   DATEPART(YEAR ,hw.dateWorked) =@year and numberEmploye=@NoEmployee and (hw.hoursST > 0 or hw.hoursOT>0 or hw.hours3>0) and  wc.name like '%6.4%' --and em.numberEmploye = 16874
		)as t1
		group by t1.[Employee],t1.[Emp: Number],t1.[Day],t1.[Project Name],t1.[Work Description],t1.[Rate ST],
	t1.[hoursST],T1.[Rate OT] ,t1.[hoursOT] 

end
else
begin
select t1.[Employee],t1.[Emp: Number],t1.[Day],t1.[Project Name],t1.[Work Description],t1.[Rate ST],
	t1.[hoursST],T1.[Rate OT] ,t1.[hoursOT] 
		from(
		select distinct
			CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee', 
			em.numberEmploye as 'Emp: Number' ,
			hw.dateWorked as 'Day',
			concat(wo.idWO,'-',tk.task) as 'Project Name',
			SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Work Description',
			wc.billingRate1 as 'Rate ST',
			(select iif(SUM(hw1.hoursST)  is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursST',
			wc.billingRateOT as 'Rate OT',
			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursOT'
			

			from hoursWorked as hw 
			inner join employees as em on hw.idEmployee = em.idEmployee
			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
			inner join task as tk on tk.idAux = hw.idAux 
			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
			inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
			inner join job as jb on jb.jobNo = po.jobNo
			where   DATEPART(YEAR ,hw.dateWorked) =@year  and (hw.hoursST > 0 or hw.hoursOT>0 or hw.hours3>0) and  wc.name like '%6.4%' --and em.numberEmploye = 16874
		)as t1
		group by t1.[Employee],t1.[Emp: Number],t1.[Day],t1.[Project Name],t1.[Work Description],t1.[Rate ST],
	t1.[hoursST],T1.[Rate OT] ,t1.[hoursOT] 
	end
end
GO
--##############################################################################################
--################## SP YEAR FINAL HOURS #######################################################
--##############################################################################################
--ALTER proc [dbo].[sp_Year_Final_Hours]
CREATE proc [dbo].[sp_Year_Final_Hours]
@year nVarchar(4)
as
begin
    set @year = isnull(@year, DATENAME(YEAR,GETDATE()))
	
	select *, T1.January+T1.February+T1.March+T1.April+T1.May+T1.June+T1.July+T1.August+T1.September+T1.October+T1.Nomvember+T1.Dicember as 'Total' 
	from (
	select 
		wc.name,
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'January'),0) as 'January',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'February'),0) as 'February',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'March'),0) as 'March',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'April') ,0) as 'April',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'May') ,0) as 'May',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'June'),0) as 'June',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'July'),0) as 'July',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'August'),0) as 'August',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'September'),0) as 'September',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'October'),0) as 'October',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'November'),0) as 'Nomvember',
		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'Dicember'),0) as 'Dicember'
	from workCode as wc ) as T1
	where (T1.January+T1.February+T1.March+T1.April+T1.May+T1.June+T1.July+T1.August+T1.September+T1.October+T1.Nomvember+T1.Dicember) > 0
end
GO
--##############################################################################################
--################## TRIGER DE ESTCOSTSCF ######################################################
--##############################################################################################

--ALTER trigger [dbo].[addCostScfEsDr]
create trigger [dbo].[addCostScfEsDr]
on [dbo].[scaffoldEst] 
after insert , Update
as
begin
	declare @idProjectEst as varchar(30) = Null
	declare @M2 as float = 0
	declare @SHRD as float = 0
	declare @SBHRD as float = 0
	declare @SDHRD as float = 0
	declare @DSCOSTL as float = 0
	declare @DSCOSTM as float = 0
	declare @SCOSTMBD as float = 0
	declare @DSCOSTMD as float = 0
	declare @SCOSTEBD as float = 0
	declare @BSCOSTEB as float = 0
	declare @SCOSTEDD  as float = 0
	declare @SCM as float = 0
	declare @SHR as float = 0
	declare @SBHR as float = 0
	declare @SDHR as float = 0
	declare @SCOSTL as float = 0
	declare @SCOSTLB as float = 0
	declare @SCOSTLD as float = 0
	declare @SCOSTM as float = 0
	declare @SCOSTMB as float = 0
	declare @SCOSTMD as float = 0
	declare @SCOSTE as float = 0
	declare @SCOSTEB as float = 0
	declare @SCOSTED as float = 0
	declare @STCOST as float = 0
	declare @STCOSTB as float = 0
	declare @STCOSTD as float = 0
	declare @buildPercent as float = 0
	declare @dismantlePercent as float = 0
	set @idProjectEst = (select projectId from drawing where idDrawingNum = (select idDrawingNum from inserted))
	set @M2 = FORMAT((ISNULL((select width from inserted),0)*ISNULL((select length from inserted),0)*ISNULL((select decks from inserted),0))/10.76391,'###.00')
	set @SHRD = ROUND((@M2/(select laborB from scfUnitsRates where idSCFUR =(select idSCFUR from inserted))),1)
	set @buildPercent = (select buildPercent from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))
	set @SBHRD = ROUND(( @SHRD * (@buildPercent*0.01)),1)
	set @SDHRD = @SHRD - @SBHRD 

	set @DSCOSTL = ROUND((@SBHRD * (select scafRate from laborRate where idLaborRate = (select idLaborRate from inserted))) + (@SDHRD * (select scafRate from laborRate where idLaborRate = (select idLaborRate from inserted))),2)
	set @DSCOSTM = ROUND((@SHRD * (select materialD from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
	set @SCOSTMBD = ROUND((@SBHRD * (select materialD from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
	set @DSCOSTMD = @DSCOSTM - @SCOSTMBD

	set @SCOSTEBD = ROUND((@SHRD * (select equipmentD from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
	set @BSCOSTEB = ROUND((@SBHRD * (select equipmentD from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
	set @SCOSTEDD = (@SCOSTEBD - @BSCOSTEB)

	set @SCM = ROUND((((select width from inserted) * (select [length] from inserted) * (select heigth from inserted))/35.3),2)
	set @SHR = ROUND((@SCM / (select laborD from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),1)
	set @dismantlePercent = (select dismantlePercent from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))
	set @SBHR = ROUND((@SHR * (@dismantlePercent*0.01)),1)
	set @SDHR = @SHR - @SBHR

	set @SCOSTL = (ROUND((@SBHR * (select scafRate from laborRate where idLaborRate = (select idLaborRate from inserted))),2) + ROUND((@SDHR * (select scafRate from laborRate where idLaborRate = (select idLaborRate from inserted))),2))
	set @SCOSTLB = ROUND((@SBHR * (select scafRate from laborRate where idLaborRate = (select idLaborRate from inserted))),2)
	set @SCOSTLD = @SCOSTL - @SCOSTLB 
				
	set @SCOSTM = ROUND((@SHR * (select materialB from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
	set @SCOSTMB = ROUND((@SBHR * (select materialB from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
	set @SCOSTMD = @SCOSTM - @SCOSTMB
				
	set @SCOSTE = ROUND((@SHR * (select equipmentB from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2) 
	set @SCOSTEB = ROUND((@SBHR * (select equipmentB from scfUnitsRates where idSCFUR = (select idSCFUR from inserted))),2)
	set @SCOSTED = @SCOSTE - @SCOSTEB

	set @STCOST = ISNULL(@SCOSTL,0) + ISNULL(@SCOSTM,0) + ISNULL(@SCOSTE,0)
	set @STCOSTB = ISNULL(@SCOSTLB,0) + ISNULL(@SCOSTMB,0) + ISNULL(@SCOSTEB,0)
	set @STCOSTD = ISNULL(@SCOSTLD,0) + ISNULL(@SCOSTMD,0) + ISNULL(@SCOSTED,0)
				 
	if (select count(*) from EstCostScf where tag=(select tag from inserted) and idDrawingNum=(select idDrawingNum from inserted) and projectId = @idProjectEst)= 0 
	begin  
		insert into EstCostScf values ((select tag from inserted),(select idDrawingNum from inserted),@idProjectEst,@M2, @SHRD ,@SBHRD ,@DSCOSTL ,@DSCOSTM ,@SCOSTMBD ,@DSCOSTMD ,@SCOSTEBD ,@BSCOSTEB ,@SCOSTEDD ,@SCM ,@SHR ,@SBHR ,@SDHR ,@SCOSTL ,@SCOSTLB ,@SCOSTLD ,@SCOSTM ,@SCOSTMB ,@SCOSTMD ,@SCOSTE ,@SCOSTEB ,@SCOSTEBD ,@STCOST ,@STCOSTB ,@STCOSTD)
	end 
	else if(select count(*) from EstCostScf where tag=(select tag from inserted) and idDrawingNum=(select idDrawingNum from inserted) and projectId = @idProjectEst)>0 
	begin
		update EstCostScf set M2 = @M2, SHRD = @SHRD ,SBHRD = @SBHRD , DSCOSTL = @DSCOSTL, DSCOSTM = @DSCOSTM, SCOSTMBD = @SCOSTMBD,DSCOSTMD = @DSCOSTMD,SCOSTEBD = @SCOSTEBD,BSCOSTEB = @BSCOSTEB, SCOSTEDD = @SCOSTEDD, SCM = @SCM,SHR = @SHR,SBHR = @SBHR,SDHR =@SDHR,SCOSTL = @SCOSTL,SCOSTLB = @SCOSTLB, SCOSTLD = @SCOSTLD,SCOSTM = @SCOSTM,SCOSTMB = @SCOSTMB,SCOSTMD = @SCOSTMD,SCOSTE = @SCOSTE,SCOSTEB = @SCOSTEB,SCOSTED = @SCOSTED,STCOST = @STCOST,STCOSTB = @STCOSTB,STCOSTD = @STCOSTD where tag = (select tag from inserted) and idDrawingNum = (select idDrawingNum from inserted) and projectId = @idProjectEst
	end
end
go

--##############################################################################################
--################## TRIGER DE ESTCOSTEQ #######################################################
--##############################################################################################
create trigger [dbo].[addCostEqEsDr]
on [dbo].[equipmentEst] 
after insert , Update
as
begin
	declare @IPEFFACTOR as float = 0
	declare @projectId as varchar(30) = NULL
	--REMOVAL
	declare @IRESQF  as float = 0
	declare @ACMH as float = 0
	declare @EIRHRS as float = 0
	declare @EIRCOSTL  as float = 0
	declare @EIRCOSTM as float = 0
	declare @EIRCOSTE as float = 0
	declare @EIRTCOST as float = 0
	--INSTALATION INSULATION
	declare @IIESQF as float = 0
	declare @EIIHRS as float = 0
	declare @EIICOSTL as float = 0
	declare @EIICOSTM as float = 0
	declare @EIICOSTE as float = 0
	declare @EIITCOST as float = 0
	--PAINT 
	declare @PESQF as float = 0
	declare @EPHRS as float = 0
	declare @EPCOSTL as float = 0
	declare @EPCOSTM as float = 0
	declare @EPCOSTE as float = 0
	declare @EPTCOST as float = 0
	
	set @projectId = (select projectId from drawing where idDrawingNum = (select idDrawingNum from inserted))
	--REMOVAL
	set @IPEFFACTOR = (select top 1 [percent] from factorElevationPaint where elevation = (select elevation from inserted))*0.01
	set @IRESQF = (select sqrFtRmv from inserted)* iif((select idLaborRateRmv from inserted) is not NULL,1,0) 
	set @ACMH =  ROUND( iif((select acm from inserted) = 1 , (@IRESQF * (select isnull(laborProd,0) from EqIRHC where [type] = (select [type] from inserted) and thickness = (select thick from inserted))* @IPEFFACTOR * (select laborProd from eqJktUnitRate where idJacket = (select idJacket from inserted))),0)*3.5,1)
	set @EIRHRS = ROUND((@IRESQF * (select isnull(laborProd,0) from EqIRHC where [type] = (select [type] from inserted) and thickness = (select thick from inserted)) * @IPEFFACTOR * (select laborProd from eqJktUnitRate where idJacket = (select idJacket from inserted))),1) + ISNULL(@ACMH,0)
	set @EIRCOSTL = ROUND((@EIRHRS * (select insRate from laborRate where idLaborRate = (select idLaborRateRmv from inserted))) ,2)
	set @EIRCOSTM = ROUND((@IRESQF * (select isnull(matRate,0) from EqIRHC where [type] = (select [type] from inserted) and thickness = (select thick from inserted)) * (select isnull(matFactor,1) from eqJktUnitRate where idJacket = (select idJacket from inserted))),2)
	set @EIRCOSTE = ROUND((@IRESQF * (select isnull(eqRate,0) from EqIRHC where [type] = (select [type] from inserted) and thickness = (select thick from inserted)) * (select isnull(eqFactor,1) from eqJktUnitRate where idJacket = (select idJacket from inserted))),2) 
	set @EIRTCOST = ISNULL(@EIRCOSTL,0)+ISNULL(@EIRCOSTM,0)+ISNULL(@EIRCOSTE,0)
	--INTALATION INSULATION
	set @IIESQF = (select sqrFtII from inserted) + ((select bevel from inserted) * (select bebel from insfitting where [type] = (select [type] from inserted))) + ((select cutOut from inserted) * (select cutOut from insfitting where [type]=(select [type] from inserted))) 
	set @EIIHRS = ROUND((@IIESQF * (select isnull(laborProd,0) from eqInsUnitRate where [type]= (select [type] from inserted) and thick = (select thick from inserted)) * @IPEFFACTOR * (select isnull(laborProd,1) from eqJktUnitRate where idJacket = (select idJacket from inserted))),1)
	set @EIICOSTL = ROUND((@EIIHRS * (select insRate from laborRate where idLaborRate = (select idLaborRateII from inserted))),2) 
	set @EIICOSTM = ROUND((@IIESQF * (select isnull(matRate,0) from eqInsUnitRate where [type] = (select [type] from inserted) and thick = (select thick from inserted)) * (select isnull(matFactor,1) from eqJktUnitRate where idJacket = (select idJacket from inserted))),2) 
	set @EIICOSTE = ROUND((@IIESQF * (select isnull(eqRate,0) from eqInsUnitRate where [type] = (select [type] from inserted) and thick = (select thick from inserted)) * (select isnull(eqFactor,1) from eqJktUnitRate where idJacket = (select idJacket from inserted))),2)
	set @EIITCOST = ISNULL(@EIICOSTL,0)+ISNULL(@EIICOSTM,0)+ISNULL(@EIICOSTE,0)
	--PAINT
	set @PESQF = ISNULL((select sqrFtPnt from inserted),0)
	set @EPHRS = ROUND((@PESQF * (select isnull(laborProd,0) from eqPaintUnitRate where systemPntEq = (select systemPntEq from inserted) and pntOption = (select pntOption from inserted))  * @IPEFFACTOR),1)
	set @EPCOSTL = ROUND((@EPHRS *(select paintRate from laborRate where idLaborRate = (select idLaborRatePnt from inserted))),2)
	set @EPCOSTM = ROUND((@PESQF * (select isnull(matRate,0) from eqPaintUnitRate where systemPntEq = (select systemPntEq from inserted) and pntOption = (select pntOption from inserted))),2)
	set @EPCOSTE = ROUND((@PESQF * (select isnull(eqRate,0) from eqPaintUnitRate where systemPntEq = (select systemPntEq from inserted) and pntOption = (select pntOption from inserted))),2) 
	set @EPTCOST = ISNULL(@EPCOSTL,0) + ISNULL(@EPCOSTM,0) + ISNULL(@EPCOSTE,0)
			
	if (select count(*) from EstCostEq where tag= (select idEquimentEst from inserted) and idDrawingNum=(select idDrawingNum from inserted) and projectId = @projectId)= 0 
	begin  
		insert into EstCostEq values ((select idEquimentEst from inserted),(select idDrawingNum from inserted),@projectId,@IRESQF,@ACMH,@EIRHRS,@EIRCOSTL,@EIRCOSTM,@EIRCOSTE,@EIRTCOST,@IIESQF,@EIIHRS,@EIICOSTL,@EIICOSTM,@EIICOSTE,@EIITCOST,@PESQF,@EPHRS,@EPCOSTL,@EPCOSTM,@EPCOSTE,@EPTCOST)
	end 
	else if(select count(*) from EstCostEq where tag=(select idEquimentEst from inserted) and idDrawingNum=(select idDrawingNum from inserted) and projectId = @projectId)>0 
	begin
		update EstCostEq set @IRESQF = @IRESQF,ACMH=@ACMH,EIRHRS= @EIRHRS,EIRCOSTL=@EIRCOSTL,EIRCOSTM=@EIRCOSTM,EIRCOSTE=@EIRCOSTE,EIRTCOST=@EIRTCOST,IIESQF=@IIESQF,EIIHRS=@EIIHRS,EIICOSTL=@EIICOSTL,EIICOSTM=@EIICOSTM,EIICOSTE=@EIICOSTE,EIITCOST=@EIITCOST,PESQF=@PESQF,EPHRS=@EPHRS,EPCOSTL=@EPCOSTL,EPCOSTM=@EPCOSTM,EPCOSTE=@EPCOSTE,EPTCOST=@EPTCOST where tag = (select idEquimentEst from inserted) and idDrawingNum = (select idDrawingNum from inserted) and projectId = @projectId
	end
end
go
--##############################################################################################
--################## TRIGER DE ESTCOSTPP #######################################################
--##############################################################################################

CREATE TRIGGER [dbo].[addCostPpEst]
ON [dbo].[pipingEst]
after insert, update
as 
begin
	declare @projectId as varchar(45) = NULL
	declare @IPPEFFACTOR as float = 0
	--REMOVAL
	declare @IRELF as float =0
	declare @ACMH as float =0
	declare @PIRHRS as float =0
	declare @PIRCOSTL as float =0
	declare @PIRCOSTM as float =0
	declare @PIRCOSTE as float =0
	declare @PIRTCOST as float =0
	--INSTALATION INSULATION
	declare @IIELF as float =0
	declare @PIIHRS as float =0
	declare @PIICOSTL as float =0
	declare @PIICOSTM as float =0
	declare @PIICOSTE as float =0
	declare @PIITCOST as float =0
	--PAINT
	declare @PESQF as float =0
	declare @PPHRS as float =0
	declare @PPCOSTL as float =0
	declare @PPCOSTM as float =0
	declare @PPCOSTE as float =0
	declare @PPTCOST as float =0 
	declare @type as varchar(25) = NULL
	set @projectId = (select projectId from drawing where idDrawingNum = (select idDrawingNum from inserted))
	set @type = (select [type] from inserted)
	--REMOVAl
	set @IPPEFFACTOR = (select ISNULL([percent],0) from factorElevationPaint where elevation = (select elevation from inserted))*0.01
	set @IRELF=  (select lFtRmv from inserted) * IIF((select idLaborRateRmv from inserted) is not NULL,1,0)
	set @ACMH= ROUND(IIF((select acm from inserted) = 1, @IRELF * (select laborProd from PpIRHC where size =(select size from inserted) and [type]= (select [type] from inserted) and thickness = (select thick from inserted)) * @IPPEFFACTOR * (select laborProd from ppJktUnitRate where idJacket = (select idJacket from inserted)),0)*3,1)
	set @PIRHRS= ROUND((@IRELF * (select laborProd from PpIRHC where size =(select size from inserted) and [type]= (select [type] from inserted) and thickness = (select thick from inserted)) * @IPPEFFACTOR * (select laborProd from ppJktUnitRate where idJacket = (select idJacket from inserted)) + ISNULL(@ACMH,0)),0)
	set @PIRCOSTL= ROUND(@PIRHRS * (select top 1 insRate from laborRate where idLaborRate = (select idLaborRateRmv from inserted)),2) 
	set @PIRCOSTM= ROUND(@IRELF * (select top 1 matRate from PpIRHC where size =(select size from inserted) and [type]= (select [type] from inserted) and thickness = (select thick from inserted)) * (select matFactor from ppJktUnitRate where idJacket = (select idJacket from inserted)),2)
	set @PIRCOSTE= ROUND(@IRELF * (select top 1 eqRate from PpIRHC where size =(select size from inserted) and [type]= (select [type] from inserted) and thickness = (select thick from inserted)) * (select eqFactor from ppJktUnitRate where idJacket = (select idJacket from inserted)) ,2) 
	set @PIRTCOST= ISNULL(@PIRCOSTL,0)+ISNULL(@PIRCOSTM ,0)+ISNULL(@PIRCOSTE ,0) 
	--INSTALATION INSULATION
	set @IIELF= ((select lFtII from inserted)+ ((select p90II from inserted) * (select p90 from insFitting where [type] = @type)) + ((select p45II from inserted) * (select p45 from insFitting where [type] = @type) ) + ( (select pBendII from inserted) * (select bend from insFitting where [type] = @type) ) + ( (select pTeeII from inserted) * (select tee from insFitting where [type] = @type) ) + ((select pReducII from inserted) * (select red from insFitting where [type] = @type) ) + ( (select pCapsII from inserted) * (select cap from insFitting where [type] = @type) ) + ( (select pPairII from inserted) * (select flangePair from insFitting where [type] = @type) ) + ( (select pVlvII from inserted) * (select flangeVlv from insFitting where [type] = @type) ) + ((select pControlII from inserted) * (select controlVlv from insFitting where [type] = @type) ) + ((select pWeldII from inserted) * (select weldedVlv from insFitting where [type] = @type) ) + ((select pCutOutII from inserted) * (select cutOut from insFitting where [type] = @type)) + ((select psupportII from inserted) * (select support from insFitting where [type] = @type)))
	set @PIIHRS= ROUND(@IIELF * (select laborProd from ppInsUnitRate where size = (select size from inserted) and [type] = (select [type] from inserted) and thick = (select thick from inserted)) * @IPPEFFACTOR * (select laborProd from ppJktUnitRate where idJacket = (select idJacket from inserted)),1)
	set @PIICOSTL= ROUND(@PIIHRS * (select top 1 insRate from laborRate where idLaborRate = (select idLaborRateII from inserted)),2)
	set @PIICOSTM= ROUND(@IIELF * (select top 1 matRate from ppInsUnitRate where size = (select size from inserted) and [type] = (select [type] from inserted) and thick = (select thick from inserted)) * (select matFactor from ppJktUnitRate where idJacket = (select idJacket from inserted)),2)
	set @PIICOSTE= ROUND(@IIELF * (select top 1 eqRate from ppInsUnitRate where size = (select size from inserted) and [type] = (select [type] from inserted) and thick = (select thick from inserted)) * (select eqFactor from ppJktUnitRate where idJacket = (select idJacket from inserted)) ,2) 
	set @PIITCOST= ISNULL( @PIICOSTL ,0)+ISNULL( @PIICOSTM ,0)+ISNULL( @PIICOSTE ,0)
	--PAINT
	set @PESQF= IIF((select size from inserted)<=3, 1, (select size from inserted) / 3.82 )*((select lFtPnt from inserted) + ((select p90Pnt from inserted) * (select p90 from pntFitting where pntOption = (select pntOption from inserted))) + ((select p45Pnt from inserted) * (select p45 from pntFitting where pntOption = (select pntOption from inserted)) ) + ( (select pTeePnt from inserted) * (select tee from pntFitting where pntOption = (select pntOption from inserted))) + ((select pPairPnt from inserted) * (select flangePair from pntFitting where pntOption = (select pntOption from inserted)) ) + ((select pVlvPnt from inserted) * (select flangeVlv from pntFitting where pntOption = (select pntOption from inserted))) + ((select pControlPnt from inserted) * (select controlVlv from pntFitting where pntOption = (select pntOption from inserted))) + ((select pWeldPnt from inserted) * (select weldedVlv from pntFitting where pntOption = (select pntOption from inserted)))) 
	set @PPHRS= ROUND(@PESQF * (select laborProd from ppPaintUnitRate where systemPntPP = (select systemPntPP from inserted) and pntOption = (select pntOption from inserted) and size = (select size from inserted)) * @IPPEFFACTOR ,1)
	set @PPCOSTL= ROUND(@PPHRS * (select top 1 paintRate from laborRate where idLaborRate = (select idLaborRatePnt from inserted)),2)
	set @PPCOSTM= ROUND(@PESQF * (select top 1 matRate from ppPaintUnitRate where size = (select size from inserted) and pntOption = (select pntOption from inserted) and systemPntPP = (select systemPntPP from inserted)),2) 
	set @PPCOSTE= ROUND(@PESQF * (select top 1 eqRate from ppPaintUnitRate where size = (select size from inserted) and pntOption = (select pntOption from inserted) and systemPntPP = (select systemPntPP from inserted)),2)
	set @PPTCOST= ISNULL(@PPCOSTL ,0)+ISNULL(@PPCOSTM ,0)+ISNULL(@PPCOSTE ,0)
	if(select COUNT(*) from EstCostPp where tag = CONVERT(NVARCHAR, (select idPipingEst from inserted)) and idDrawingNum = (select idDrawingNum from inserted) and projectId = @projectId)=0
	begin
		insert into EstCostPp values(CONVERT(NVARCHAR,(select idPipingEst from inserted)) , (select idDrawingNum from inserted),@projectId,@IRELF,@ACMH,@PIRHRS,@PIRCOSTL,@PIRCOSTM,@PIRCOSTE,@PIRTCOST,@IIELF,@PIIHRS,@PIICOSTL,@PIICOSTM,@PIICOSTE,@PIITCOST,@PESQF,@PPHRS,@PPCOSTL,@PPCOSTM,@PPCOSTE,@PPTCOST)
	end
	else if(select COUNT(*) from EstCostPp where tag = CONVERT(NVARCHAR,(select idPipingEst from inserted)) and idDrawingNum = (select idDrawingNum from inserted) and projectId = @projectId)>0
	begin
		update EstCostPp set IRELF = @IRELF ,ACMH = @ACMH,PIRHRS = @PIRHRS,PIRCOSTL = @PIRCOSTL,PIRCOSTM = @PIRCOSTM,PIRCOSTE = @PIRCOSTE,PIRTCOST = @PIRTCOST,IIELF = @IIELF,PIIHRS = @PIIHRS,PIICOSTL = @PIICOSTL,PIICOSTM = @PIICOSTM,PIICOSTE = @PIICOSTE,PIITCOST = @PIITCOST,PESQF = @PESQF,PPHRS = @PPHRS,PPCOSTL = @PPCOSTL,PPCOSTM = @PPCOSTM,PPCOSTE = @PPCOSTE,PPTCOST = @PPTCOST where tag = CONVERT(NVARCHAR, (select idPipingEst from inserted)) and idDrawingNum = (select idDrawingNum from inserted) and projectId = @projectId
	end
end
go

--##############################################################################################
--################## SP DELETE PROJECT #########################################################
--##############################################################################################
create proc sp_delete_project
@idAux varchar(36),
@idAuxWO varchar(36)
as
declare @error as bit = 0
declare @taskAux as varchar(20)
declare @countScaff as int
begin 
	begin tran
		begin try	
		if @idAux <> '' 
		begin 
			if (select COUNT(*) from expensesUsed where idAux = @idAux)>0
			begin 
				delete from expensesUsed where idAux = @idAux 
			end
			if (select COUNT(*) from materialUsed where idAux = @idAux)>0
			begin
				delete from materialUsed where idAux = @idAux
			end
			if (select COUNT(*) from hoursWorked where idAux = @idAux)>0
			begin
				delete from hoursWorked where idAux = @idAux
			end
			if (select COUNT(*) from scaffoldTraking where idAux = @idAux)>0
			begin
				set @countScaff =( select COUNT(*) from scaffoldTraking where idAux = @idAux)
				while (@countScaff>0)
				begin
					set @taskAux = (select top 1 tag from scaffoldTraking where idAux = @idAux)
					exec sp_deleteScaffold @taskAux
					set @countScaff =( select COUNT(*) from scaffoldTraking where idAux = @idAux)
				end
			end
			if (select COUNT(*) from scfEstimation where idAux = @idAux)>0
			begin
				delete EstMeters from EstMeters as estM inner join scfEstimation as scfest on estM.EstNumber = scfest.EstNumber 
				 where scfest.idAux = @idAux
				delete from scfEstimation where idAux = @idAux
			end
			delete from task where idAux = @idAux
		end
		else if @idAuxWO <> '' 
		begin 
			delete from workOrder where idAuxWO = @idAuxWO
		end
	end try
		begin catch
			set @error = 1
			goto solveProblem
		end catch
	commit tran
	solveProblem:
	if @error <> 0 
	begin 
		rollback tran
	end  
end
go
