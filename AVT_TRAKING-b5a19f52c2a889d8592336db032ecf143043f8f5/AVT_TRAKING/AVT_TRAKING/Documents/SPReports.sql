--==============================================================================================
--==============================================================================================
--===== LOS PROCEDIMIENTO SI YA ESTA INSERTADOS EN LA BASE DE DATOS SOLO DECOMENTAR ============
--===== EL CREATE QUE ESTA ARRIBA DE CADA PROCEDIMIENTO Y COMENTAR EL ALTER USANDO  ============
--===== (CTRL+K)(CTRL+C) PARA COMENTAR Y (CTRL+K)(CTRL+U)                           ============
--==============================================================================================
--==============================================================================================
--##############################################################################################
--################## SP REPORT Client Billings Re Cap By Project ###############################
--##############################################################################################
--CREATE proc [dbo].[Client_Billings_Re_Cap_By_Project]
ALTER proc [dbo].[Client_Billings_Re_Cap_By_Project]
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
			(select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
				where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate
			)as T1    
		group by T1.idWorkCode
		)as T2
	) as 'Billings ST',

	(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours OT',
	
	(select ISNULL( SUM(T2.Amount),0) as 'Billings OT' from 
		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount' from 
			(select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
				where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate
			)as T1    
		group by T1.idWorkCode
		)as T2
	) as 'Billings OT',

	concat(ts.percentComplete,'%') as 'Complete',

	ts.estimateHours as 'Es-Hrs',

	ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
	where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0) as 'Total Expenses',
	
	ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0) as 'Total Material',
	
	(
		
			(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2)--Billing ST
			+
			(select  ISNULL( SUM(T2.Amount),0) as 'Billing OT' from 
			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
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
--CREATE proc [dbo].[select_Time_Sheet_PO]
ALTER proc [dbo].[select_Time_Sheet_PO]
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
		(select sum(hw1.hoursST) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and po1.jobNo = wo1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo inner join clients as cl1 on cl1.idClient = jb1.idClient where cl1.idClient = cl.idClient and po1.idPO=po.idPO and jb.jobNo = jb1.jobNo and hw1.idEmployee = em.idEmployee and SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))=SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) and hw1.dateWorked between @IntialDate and @FinalDate) as 'hoursST',
		(select sum(hw2.hoursOT) from hoursWorked as hw2 inner join workCode as wc2 on wc2.idWorkCode = hw2.idWorkCode inner join task as tk2 on tk2.idAux = hw2.idAux inner join workOrder as wo2 on wo2.idAuxWO = tk2.idAuxWO inner join projectOrder as po2 on po2.idPO = wo2.idPO and po2.jobNo = wo2.jobNo inner join job as jb2 on jb2.jobNo = po2.jobNo inner join clients as cl2 on cl2.idClient = jb2.idClient where cl2.idClient = cl.idClient and po2.idPO=po.idPO and jb.jobNo = jb2.jobNo and hw2.idEmployee = em.idEmployee and SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))=SUBSTRING( wc2.name,1,iif(CHARINDEX('-',wc2.name)=0, len(wc2.name) ,(CHARINDEX('-',wc2.name)-1))) and hw2.dateWorked between @IntialDate and @FinalDate) as 'hoursOT',
		SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
		hw.schedule as 'Shift',
		CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee',
		em.numberEmploye as 'Emp: Number',
		em.typeEmployee as 'class'
		from hoursWorked as hw 
					inner join employees as em on hw.idEmployee = em.idEmployee
					inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
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
--CREATE proc [dbo].[select_TimeSheet_Report]
ALTER proc [dbo].[select_TimeSheet_Report]
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
			(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hoursST',
			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hoursOT',
			(select iif(SUM(hw1.hours3 )is null,0,SUM(hw1.hours3 )) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hours3',
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
			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
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
--CREATE proc [dbo].[sp_Active_Employee_Average]
ALTER proc [dbo].[sp_Active_Employee_Average]
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
--################## SP REPORT ALL JOBS ########################################################
--##############################################################################################
--CREATE proc [dbo].[Sp_All_Jobs]
ALTER proc [dbo].[Sp_All_Jobs]
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

	case when ((select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked =hw.dateWorked  and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours ST',
	
	ISNULL(wc.billingRate1,0)AS 'billingRate1',

	case when ((select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours OT',

	ISNULL(wc.billingRateOT,0)as 'billingRateOT',
	ISNULL((select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo 
	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Per-Diem') ,0) as 'PerDiem' ,

	ISNULL((select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo 
	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel') ,0) as 'Travel' 
	 
	from employees as em 
		inner join hoursWorked as hw on hw.idEmployee = em.idEmployee
		left join workCode as wc on wc.idWorkCode = hw.idWorkCode
		inner join task as tk on tk.idAux= hw.idAux
		inner join workOrder wo on  wo.idAuxWO=tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = wo.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum
	order by 
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
	hw.dateWorked
end
go

--##############################################################################################
--################## SP REPORT BY JOB NUMBER ###################################################
--##############################################################################################
--CREATE proc [dbo].[Sp_By_JobNumber]
ALTER proc [dbo].[Sp_By_JobNumber]
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
	case when ((select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours ST',
	ISNULL(wc.billingRate1,0)as 'billingRate1',

	case when ((select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours OT',

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
		left join workCode as wc on wc.idWorkCode = hw.idWorkCode
		inner join task as tk on tk.idAux= hw.idAux
		inner join workOrder wo on  wo.idAuxWO=tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = wo.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,''))
	order by 
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
	hw.dateWorked
end
go

--##############################################################################################
--################## SP REPORT CATS EMPLOYEE BY PROJECT ########################################
--##############################################################################################
--CREATE proc [dbo].[sp_Cats_Employee_by_Porject]
ALTER proc [dbo].[sp_Cats_Employee_by_Porject]
@startdate as date,
@finaldate as date,
@employeenumber int,
@all as bit
as
begin
if @all = 0 begin
	select concat(wo.idWO, ' ',ts.task) as 'W/PO Number',
		em.numberEmploye as 'Emp: Number',
		concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
		wc.description,
		sum(hw.hoursST) as 'ST Hours', 
		sum(hw.hoursOT) as 'OT Hours', 
		hw.dateWorked as 'Date Worked'
		from hoursWorked as hw
		inner join employees as em on em.idEmployee= hw.idEmployee
		inner join workCode as wc on wc.idWorkCode= hw.idWorkCode
		inner join task as ts on ts.idAux= hw.idAux
		inner join workOrder wo on wo.idAuxWO=ts.idAuxWO
		where hw.dateWorked between @startdate and @finaldate and em.numberEmploye=@employeenumber
		group by concat(wo.idWO, ' ',ts.task),em.numberEmploye, concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
		 wc.description,hw.dateWorked
end
else
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
		inner join workCode as wc on wc.idWorkCode= hw.idWorkCode
		inner join task as ts on ts.idAux= hw.idAux
		inner join workOrder wo on  wo.idAuxWO=ts.idAuxWO
		where hw.dateWorked between @startdate and @finaldate
		group by concat(wo.idWO, ' ',ts.task),em.numberEmploye, concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
		wc.description,hw.dateWorked
end
end

go

--##############################################################################################
--################## SP REPORT CLIENT BILLINGS PROJECT #########################################
--##############################################################################################
--CREATE proc [dbo].[sp_Client_billings_Project]
ALTER proc [dbo].[sp_Client_billings_Project]
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
			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2) as 'Billings ST',

			(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours OT',
	
		
			(select  ISNULL( SUM(T2.Amount),0) as 'Billings OT' from 
			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2) as 'Billings OT',


			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0) as 'Total Expenses',
			
			
			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0) as 'Total Material',
	
			((select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
			group by T1.idWorkCode) as T2)
			+
			(select  ISNULL( SUM(T2.Amount),0) from 
			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
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
go

--##############################################################################################
--################## SP REPORT COMPLETE BY DATE RANGE ##########################################
--##############################################################################################
--CREATE proc [dbo].[Sp_Complete_By_Date_Range]
ALTER proc [dbo].[Sp_Complete_By_Date_Range]
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
--################## SP REPORT EMPLOYEE PER DIEM ###############################################
--##############################################################################################
--CREATE proc [dbo].[Sp_Employee_Per_Diem_Sheets]
ALTER proc [dbo].[Sp_Employee_Per_Diem_Sheets]
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
--CREATE proc [dbo].[sp_Employee_Time]
ALTER proc [dbo].[sp_Employee_Time]
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
--################## SP HOURS PER WEEK #########################################################
--##############################################################################################
--CREATE proc [dbo].[sp_Hours_Per_Week]
ALTER proc [dbo].[sp_Hours_Per_Week]
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
--################## SP REPORT NOT COMPLETE ####################################################
--##############################################################################################
CREATE proc [dbo].[Sp_Not_Complete]
--ALTER proc [dbo].[Sp_Not_Complete]
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
go

--##############################################################################################
--################## SP REPORT SCAFFOLD ESTIMATE ###################################################
--##############################################################################################
--CREATE proc [dbo].[sp_scfEstimation]
ALTER proc [dbo].[sp_scfEstimation]
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
go

--##############################################################################################
--################## SP YEAR FINAL HOURS #######################################################
--##############################################################################################
--CREATE proc [dbo].[sp_Year_Final_Hours]
ALTER proc [dbo].[sp_Year_Final_Hours]
@year nVarchar(4)
as
begin
    set @year = isnull(@year, DATENAME(YEAR,GETDATE()))
	
	select *, T1.January+T1.February+T1.March+T1.April+T1.May+T1.June+T1.July+T1.August+T1.September+T1.October+T1.Nomvember+T1.Dicember as 'Total' 
	from (
	select 
		wc.name,
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'January') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'January') end as 'January',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'February') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'February') end as 'February',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'March') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'March') end as 'March',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'April') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'April') end as 'April',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'May') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'May') end as 'May',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'June') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'June') end as 'June',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'July') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'July') end as 'July',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'August') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'August') end as 'August',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'September') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'September') end as 'September',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'October') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'October') end as 'October',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'November') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'November') end as 'Nomvember',
		case when (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'Dicember') is null then 0
			 else (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'Dicember') end as 'Dicember'
	from workCode as wc ) as T1
	where (T1.January+T1.February+T1.March+T1.April+T1.May+T1.June+T1.July+T1.August+T1.September+T1.October+T1.Nomvember+T1.Dicember) > 0
end
go

--##############################################################################################
--################## SP VACATION EMPLOYEE #######################################################
--##############################################################################################
--CREATE proc [dbo].[Sp_Vacation_Employee]
ALTER proc [dbo].[Sp_Vacation_Employee]
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
			(select iif(SUM(hw1.hoursST)  is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursST',
			wc.billingRateOT as 'Rate OT',
			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursOT'
			from hoursWorked as hw 
			inner join employees as em on hw.idEmployee = em.idEmployee
			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
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
			(select iif(SUM(hw1.hoursST)  is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursST',
			wc.billingRateOT as 'Rate OT',
			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursOT'
			

			from hoursWorked as hw 
			inner join employees as em on hw.idEmployee = em.idEmployee
			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
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
go
--##############################################################################################
--################## SP INVOICE PO #############################################################
--##############################################################################################
--CREATE proc sp_Invoice_PO
ALTER proc [dbo].[sp_Invoice_PO]
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
--create proc sp_Invoice_PO_Resume
ALTER proc [dbo].[sp_Invoice_PO_Resume]
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
		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
		inner join task as tk1 on tk1.idAux = hw1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
	as 'Total Hours PO',

	ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
		inner join task as tk1 on tk1.idAux = hw1.idAux 
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
		inner join job as jb1 on po1.jobNo = jb1.jobNo
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
	as 'Total Hours',

	ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
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
		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
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
go
--##############################################################################################
--################## SP SELECT MY COMPANY INFORMATION ##########################################
--##############################################################################################
--alter proc sp_select_MyComapny_Info
ALTER proc [dbo].[sp_select_MyComapny_Info]
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
where cmp.name = @CompanyName
end
go
--##############################################################################################
--################## SP SELECT MY COMPANY INFORMATION ##########################################
--##############################################################################################
--alter proc sp_invoice_number
alter proc sp_invoice_number
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
--################## SP  SCF HISTORY BY JOB NO  ################################################
--##############################################################################################

alter proc sp_SCF_History_By_JobNo 
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
go

--##############################################################################################
--################## SP  SCF HISTORY BY JOB NO AND WO ##########################################
--##############################################################################################

alter proc sp_SCF_History_By_Job_And_WO
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
go
--##############################################################################################
--################## SP  SCF HISTORY BY JOB NO AND UNIT ########################################
--##############################################################################################
ALTER proc sp_SCF_History_By_JobNo_And_Unit
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
go

--##############################################################################################
--################## SP  SCF HISTORY DISMANTLE #################################################
--##############################################################################################

ALTER proc sp_SCF_History_Dismantle
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
go

--##############################################################################################
--################## SP  SCF HISTORY BY JOB ####################################################
--##############################################################################################

alter proc sp_SCF_History_By_Job
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
go

--##############################################################################################
--################## SP SCF PRODUCT TO SCAFFOLD,MODIFICATION AND DISMANTLE #####################
--##############################################################################################

ALTER proc [dbo].[sp_Scaffold_Product]
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
go

--##############################################################################################
--################## SP SCF RENTAL DETAILS #####################################################
--##############################################################################################

ALTER proc [dbo].[sp_SCF_Rental_Details]
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
IIF( ISNULL(dis.rentStopDate,GETDATE()) >= @startDate ,
	IIF( DATEADD(DAY,isnull(jc.[days],0),sc.buildDate) <= @FinalDate -- EL DIA FINAL DE RENTA GRATIS ES MENOR O IGUAL AL FINALDATE?
	,-- SI ES MENOR O IGUAL POR LO TANTO SI HAY DIAS QUE COBRAR (ESTA DENTRO DEL RANGO)
		IIF(DATEADD(DAY,isnull(jc.[days],0),sc.buildDate) > @startDate -- (PUNTO DE INICIO) EL DIA FINAL DE RENTA GRATIS ES MAYOR AL STARTDATE?
		,--DIAFINAL DE RENTA GRATIS
			IIF(dis.rentStopDate < @FinalDate -- EL DIA FINAL DE RENTA GRATIS ES MENOR QUE EL FINALDATE?
			,DATEDIFF(DAY,DATEADD(DAY,isnull(jc.[days],0),DATEADD(DAY,-1,sc.buildDate)),dis.rentStopDate)
			,DATEDIFF(DAY,DATEADD(DAY,isnull(jc.[days],0),DATEADD(DAY,-1,sc.buildDate)),@FinalDate))
		,--STARTDATE
			IIF(dis.rentStopDate < @FinalDate, 
				DATEDIFF(DAY,DATEADD(DAY,-1 ,@startDate),dis.rentStopDate), 
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
go