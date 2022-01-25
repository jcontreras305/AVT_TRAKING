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
@clientnum as int
as 
begin
if @startDate is not null and @FinalDate is not null and @clientnum is not null
	begin
select T2.companyName,T2.[Work Order],T2.jobNo,T2.PO,T2.[Project Desription],
T2.[Hours Ext],T2.[Total Hours],T2.[Hours ST],T2.[Billings ST],T2.[Hours OT],T2.[Billings OT],
T2.Complete,T2.[Es-Hrs],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend],T2.Estimate from
(
	select cl.companyName,concat(wo.idWO,' ',ts.task) as 'Work Order', jb.jobNo,po.idPO as 'PO',ts.description as 'Project Desription',
    	case when (select T1.EX from  (select sum(hours3) as 'EX' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.EX from  (select sum(hours3) as 'EX' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end as 'Hours Ext',

	(case when (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end +
	case when (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) end) as 'Total Hours',

	case when (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end as 'Hours ST',
	
	(select CONCAT('$' , case when  SUM(T2.Amount) is null then '0'
	else SUM(T2.Amount) end
	) as 'Billings ST' from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) as 'Billings ST',

	case when (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) end as 'Hours OT',
	
	(select CONCAT('$' , case when SUM(T2.Amount) is null then '0'
	else SUM(T2.Amount) end ) as 'Billings OT' from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) as 'Billings OT',

	concat(ts.percentComplete,'%') as 'Complete',

	ts.estimateHours as 'Es-Hrs',

	concat('$', case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end) as 'Total Expenses',
	CONCAT('$', case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) end) as 'Total Material',
	
	concat('$', (case when  (select SUM(T2.Amount)from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) is null then 0 else (select SUM(T2.Amount)from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) end  +

	case when (select SUM(T2.Amount) from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) is null then 0 else (select SUM(T2.Amount) from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) end +

	case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end +
	
	case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) end
	)) as 'Total Spend',

	ts.estTotalBilling as 'Estimate'
	from task as ts
	inner join workOrder as wo on wo.idAuxWO=ts.idAuxWO
	inner join projectOrder as po on po.idPO=wo.idPO
	inner join job as jb on jb.jobNo=po.jobNo
	inner join clients cl on cl.idClient=jb.idClient
	where cl.numberClient=@clientnum and
		((select sum(hoursST)
		 from hoursWorked where idAux = ts.idAux)> 0 or
		 (select sum(hoursOT)
		 from hoursWorked where idAux = ts.idAux)> 0 or
		 (select sum(hours3)
		 from hoursWorked where idAux = ts.idAux)> 0 or
		 (select sum(amount) from expensesUsed where idAux=ts.idAux)> 0 or
		(select sum(amount) from materialUsed where idAux=ts.idAux)>0)
		)as T2
		where T2.[Billings ST]<>'$0' OR T2.[Billings OT]<>'$0' OR T2.[Total Expenses]<>'$0' OR T2.[Total Material]<>'$0'
		order by t2.jobNo asc
end
else
begin 
set @startdate = GETDATE()
set @finaldate = GETDATE()
set @clientnum = (select top 1 numberClient from clients)
select T2.companyName,T2.[Work Order],T2.jobNo,T2.PO,T2.[Project Desription],
T2.[Hours Ext],T2.[Total Hours],T2.[Hours ST],T2.[Billings ST],T2.[Hours OT],T2.[Billings OT],
T2.Complete,T2.[Es-Hrs],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend],T2.Estimate from
(
	select cl.companyName,concat(wo.idWO,' ',ts.task) as 'Work Order', jb.jobNo,po.idPO as 'PO',ts.description as 'Project Desription',
    	case when (select T1.EX from  (select sum(hours3) as 'EX' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.EX from  (select sum(hours3) as 'EX' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end as 'Hours Ext',

	(case when (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end +
	case when (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) end) as 'Total Hours',

	case when (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end as 'Hours ST',
	
	(select CONCAT('$' , case when  SUM(T2.Amount) is null then '0'
	else SUM(T2.Amount) end
	) as 'Billings ST' from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) as 'Billings ST',

	case when (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
	else (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) end as 'Hours OT',
	
	(select CONCAT('$' , case when SUM(T2.Amount) is null then '0'
	else SUM(T2.Amount) end ) as 'Billings OT' from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) as 'Billings OT',

	concat(ts.percentComplete,'%') as 'Complete',

	ts.estimateHours as 'Es-Hrs',

	concat('$', case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end) as 'Total Expenses',
	CONCAT('$', case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) end) as 'Total Material',
	
	concat('$', (case when  (select SUM(T2.Amount)from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) is null then 0 else (select SUM(T2.Amount)from 
	(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
	from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) end  +

	case when (select SUM(T2.Amount) from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) is null then 0 else (select SUM(T2.Amount) from 
	(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
	from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
	where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
	group by T1.idWorkCode) as T2) end +

	case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end +
	
	case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
	else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) end
	)) as 'Total Spend',

	ts.estTotalBilling as 'Estimate'
	from task as ts
	inner join workOrder as wo on wo.idAuxWO=ts.idAuxWO
	inner join projectOrder as po on po.idPO=wo.idPO
	inner join job as jb on jb.jobNo=po.jobNo
	inner join clients cl on cl.idClient=jb.idClient
	where cl.numberClient=@clientnum and
		((select sum(hoursST)
		 from hoursWorked where idAux = ts.idAux)> 0 or
		 (select sum(hoursOT)
		 from hoursWorked where idAux = ts.idAux)> 0 or
		 (select sum(hours3)
		 from hoursWorked where idAux = ts.idAux)> 0 or
		 (select sum(amount) from expensesUsed where idAux=ts.idAux)> 0 or
		(select sum(amount) from materialUsed where idAux=ts.idAux)>0)
		)as T2
		where T2.[Billings ST]<>'$0' OR T2.[Billings OT]<>'$0' OR T2.[Total Expenses]<>'$0' OR T2.[Total Material]<>'$0'
		order by t2.jobNo asc
	end
end
go

--##############################################################################################
--################## SP REPORT REPORTE BY JOB NUMBER ###########################################
--##############################################################################################
--CREATE proc [dbo].[select_TimeSheet_Report]
ALTER proc [dbo].[select_TimeSheet_Report]
	@IntialDate date,
	@FinalDate date
as 
begin
	if @IntialDate is not null and @FinalDate is not null
	begin 
			select  
		T1.jobNo,t1.idPO,t1.task,t1.equipament,t1.description,
		SUM(t1.hoursST) AS 'hoursST',SUM(t1.hoursOT)AS 'hoursOT',SUM(t1.hours3) AS 'hours3',t1.Code,t1.Shift,t1.expCode,t1.Complete,
		t1.hrEst,t1.Employee,t1.[Emp: Number],t1.class
		from (
			select distinct
			jb.jobNo,
			po.idPO,
			CONCAT(wo.idWO,'-',tk.task)AS 'task' ,
			tk.equipament,
			tk.description,
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
			where hw.dateWorked between @IntialDate and @FinalDate and (hw.hoursST > 0 or hw.hoursOT>0 or hw.hours3>0) --and em.numberEmploye = 16874
		) as T1
		group by T1.jobNo,t1.idPO,t1.Task,t1.equipament,t1.description,t1.hoursST,t1.hoursOT,t1.hours3,t1.Code,t1.Shift,t1.expCode,t1.Complete,
		t1.hrEst,t1.Employee,t1.[Emp: Number],t1.class
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
@finaldate as date
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
	SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
	case when ((select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours ST',
	wc.billingRate1,

	case when ((select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours OT',

	wc.billingRateOT,
	case when (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'PerDiem') is NULL then 0
	 else (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'PerDiem') end as 'PerDiem' ,

	case when (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel') is NULL then ''
	 else concat('',(select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel')) end as 'Travel' 
	from employees as em 
		inner join hoursWorked as hw on hw.idEmployee = em.idEmployee
		inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
		inner join task as tk on tk.idAux= hw.idAux
		inner join workOrder wo on  wo.idAuxWO=tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = wo.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @startdate and @finaldate 
	order by 
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
	hw.dateWorked
end
go

--##############################################################################################
--################## SP REPORT ###################################################
--##############################################################################################
--CREATE proc [dbo].[Sp_By_JobNumber]
ALTER proc [dbo].[Sp_By_JobNumber]
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
	SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
	case when ((select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours ST',
	wc.billingRate1,

	case when ((select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )) = 0 then 0 
	else(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%') end as 'Hours OT',

	wc.billingRateOT,
	case when (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'PerDiem') is NULL then 0
	 else (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'PerDiem') end as 'PerDiem' ,

	case when (select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel') is NULL then ''
	 else concat('',(select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense
	 where exu.dateExpense = hw.dateWorked and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel')) end as 'Travel' 
	from employees as em 
		inner join hoursWorked as hw on hw.idEmployee = em.idEmployee
		inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
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
if @startDate is not null and @FinalDate is not null
begin
select T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
		T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
		T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend] from(
	select cl.companyName, jb.jobNo, po.idPO,concat(wo.idWO,' ',ts.task) as 'Work Order',
		ts.description as 'Project Desription',

		(case when (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
		else (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end +
		case when (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
		else (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) end) as 'Total Hours',

		case when (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
		else (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end as 'Hours ST',
	
		(select CONCAT('$' , case when  SUM(T2.Amount) is null then '0'
		else SUM(T2.Amount) end
		) as 'Billings ST' from 
		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
		from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) as 'Billings ST',

		case when (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
		else (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) end as 'Hours OT',
	
		(select CONCAT('$' , case when SUM(T2.Amount) is null then '0'
		else SUM(T2.Amount) end ) as 'Billings OT' from 
		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
		from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) as 'Billings OT',
		concat('$', case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end) as 'Total Expenses',
		CONCAT('$', case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) end) as 'Total Material',
	
		concat('$', (case when  (select SUM(T2.Amount)from 
		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
		from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) is null then 0 else (select SUM(T2.Amount)from 
		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
		from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) end  +

		case when (select SUM(T2.Amount) from 
		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
		from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) is null then 0 else (select SUM(T2.Amount) from 
		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
		from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) end +

		case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end +
	
		case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate ) end
		)) as 'Total Spend'

		from Clients as cl
		inner join job as jb on jb.idClient= cl.idClient
		inner join projectOrder as po on po.jobNo= jb.jobNo
		inner join workOrder as wo on wo.idPO=po.idPO
		inner join task as ts on ts.idAuxWO=wo.idAuxWO
	 
		where cl.numberClient=@clientnum 
		)as T2 
		where T2.[Billings ST]<>'$0' OR T2.[Billings OT]<>'$0' OR T2.[Total Expenses]<>'$0' OR T2.[Total Material]<>'$0'
		group by T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
		T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
		T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend]
end
else
begin 
set @startdate = GETDATE() 
set @finaldate = GETDATE()
select T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
		T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
		T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend] from(
	select cl.companyName, jb.jobNo, po.idPO,concat(wo.idWO,' ',ts.task) as 'Work Order',
		ts.description as 'Project Desription',

		(case when (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
		else (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end +
		case when (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
		else (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) end) as 'Total Hours',

		case when (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
		else (select T1.ST from  (select sum(hoursST) as 'ST' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)end as 'Hours ST',
	
		(select CONCAT('$' , case when  SUM(T2.Amount) is null then '0'
		else SUM(T2.Amount) end
		) as 'Billings ST' from 
		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
		from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) as 'Billings ST',

		case when (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) is null then 0.0
		else (select T1.OT from  (select sum(hoursOT) as 'OT' from hoursWorked where idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) end as 'Hours OT',
	
		(select CONCAT('$' , case when SUM(T2.Amount) is null then '0'
		else SUM(T2.Amount) end ) as 'Billings OT' from 
		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
		from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) as 'Billings OT',
		concat('$', case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end) as 'Total Expenses',
		CONCAT('$', case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) end) as 'Total Material',
	
		concat('$', (case when  (select SUM(T2.Amount)from 
		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
		from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) is null then 0 else (select SUM(T2.Amount)from 
		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
		from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) end  +

		case when (select SUM(T2.Amount) from 
		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
		from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) is null then 0 else (select SUM(T2.Amount) from 
		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
		from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		where idAux=ts.idAux and dateWorked between @startdate and @finaldate)as T1    
		group by T1.idWorkCode) as T2) end +

		case when (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from expensesUsed where idAux=ts.idAux and dateExpense between @startdate and @finaldate) end +
	
		case when (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate) is null then 0.0
		else (select sum(amount) from materialUsed where idAux=ts.idAux and dateMaterial between @startdate and @finaldate ) end
		)) as 'Total Spend'

		from Clients as cl
		inner join job as jb on jb.idClient= cl.idClient
		inner join projectOrder as po on po.jobNo= jb.jobNo
		inner join workOrder as wo on wo.idPO=po.idPO
		inner join task as ts on ts.idAuxWO=wo.idAuxWO
	 
		where cl.numberClient=@clientnum 
		)as T2 
		where T2.[Billings ST]<>'$0' OR T2.[Billings OT]<>'$0' OR T2.[Total Expenses]<>'$0' OR T2.[Total Material]<>'$0'
		group by T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
		T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
		T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend]
end
end
go

--##############################################################################################
--################## SP REPORT COMPLETE BY DATE RANGE ##########################################
--##############################################################################################
--CREATE proc [dbo].[Sp_Complete_By_Date_Range]
ALTER proc [dbo].[Sp_Complete_By_Date_Range]
@startdate as date, 
@finaldate as date,
@clientnum as int
as
begin
	select  cl.companyName, concat(wo.idWO,' ',ts.task) as 'Work Order',ts.description as 'Desription',
		ts.equipament, ts.expCode as 'Expense Code',ts.accountNum as 'Account No', ts.status as 'Complete'
		from task as ts 
		inner join workOrder as wo on wo.idAuxWO = ts.idAuxWO 
		inner join projectOrder as po on po.idPO=wo.idPO and wo.jobNo = po.jobNo
		inner join job as jb on jb.jobNo = po.jobNo
		inner join clients as cl on cl.idClient = jb.idClient
		where ts.status = '1' and (endDate between @startdate and @finaldate) and cl.numberClient = @clientnum
end
go

--##############################################################################################
--################## SP REPORT EMPLOYEE PER DIEM ###############################################
--##############################################################################################
--CREATE proc [dbo].[Sp_Employee_Per_Diem_Sheets]
ALTER proc [dbo].[Sp_Employee_Per_Diem_Sheets]
@startdate as date, 
@finaldate as date,
@clientnum as int
as
begin
if @startDate is not null and @FinalDate is not null
begin
	select CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, GETDATE())) ,GETDATE())) as 'Weekending',
		po.jobNo as 'Job Num',
		CONCAT(wo.idWO,' ', tk.task) as 'Project Name',
		ex.expenseCode as 'Project Description' ,
		CONCAT(cl.lastName,' ',cl.firstName,' ',cl.middleName) as 'Client Name', 
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
		where xp.dateExpense  between @startdate and @finaldate and cl.numberClient = @clientnum 
		group by po.jobNo, wo.idWO, tk.task,CONCAT(cl.lastName,' ',cl.firstName,' ',cl.middleName), ex.expenseCode,
		CONCAT(em.lastName,',',em.firstName,' ',em.middleName),em.numberEmploye,em.typeEmployee
end
else 
begin
	select CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, GETDATE())) ,GETDATE())) as 'Weekending',
		po.jobNo as 'Job Num',
		CONCAT(wo.idWO,' ', tk.task) as 'Project Name',
		ex.expenseCode as 'Project Description' ,
		CONCAT(cl.lastName,' ',cl.firstName,' ',cl.middleName) as 'Client Name', 
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
		where xp.dateExpense  between @startdate and @finaldate and cl.numberClient = @clientnum
		group by po.jobNo, wo.idWO, tk.task,CONCAT(cl.lastName,' ',cl.firstName,' ',cl.middleName), ex.expenseCode,
		CONCAT(em.lastName,',',em.firstName,' ',em.middleName),em.numberEmploye,em.typeEmployee
end 
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
--################## SP REPORT SCAFFOLD ESTIMATE ###################################################
--##############################################################################################
--CREATE proc [dbo].[sp_scfEstimation]
ALTER proc [dbo].[sp_scfEstimation]
@EstNumber as varchar(30)
as 
begin
  if @Estnumber <> '%'
  begin
    select scfe.EstNumber, scfe.unit , scfe.location , scfe.width ,scfe.length ,scfe.heigth,scfe.descks,scfe.daysActive,emt.DA,
		scfe.M3 , scfe.M2, typ.SCTP , (select hFactor from scfFactor where heigth = scfe.heigth+scfe.groundHeigth) as 'Factor' , typ.BDRATE , emt.PMANHRS,
		emt.BPRICE,emt.DECKBP,emt.DPRICE,emt.DECKDP,
		emt.EDM3C,emt.EDM2C,emt.EDM3C,emt.EDM2C,
		emt.M3LBP,emt.M3LDP,emt.M2LBP,emt.M2LDP,
		emt.M3MBP,emt.M3MDP,emt.M2MBP,emt.M2MDP,
		emt.M3EBP,emt.M3EDP,emt.M2EBP,emt.M2EDP
		from scfEstimation as scfe 
		inner join EstMeters as emt on scfe.EstNumber = emt.EstNumber
		inner join scfTypeCost as typ on typ.scfTypeId = scfe.scfTypeId 
		inner join ScafEstCost as cost on cost.idEstCost = scfe.idEstCost
		where scfe.EstNumber like @EstNumber
end
else 
begin
    select scfe.EstNumber, scfe.unit , scfe.location , scfe.width ,scfe.length ,scfe.heigth,scfe.descks,scfe.daysActive,emt.DA,
		scfe.M3 , scfe.M2, typ.SCTP , (select hFactor from scfFactor where heigth = scfe.heigth+scfe.groundHeigth) as 'Factor' , typ.BDRATE , emt.PMANHRS,
		emt.BPRICE,emt.DECKBP,emt.DPRICE,emt.DECKDP,
		emt.EDM3C,emt.EDM2C,emt.EDM3C,emt.EDM2C,
		emt.M3LBP,emt.M3LDP,emt.M2LBP,emt.M2LDP,
		emt.M3MBP,emt.M3MDP,emt.M2MBP,emt.M2MDP,
		emt.M3EBP,emt.M3EDP,emt.M2EBP,emt.M2EDP
		from scfEstimation as scfe 
		inner join EstMeters as emt on scfe.EstNumber = emt.EstNumber
		inner join scfTypeCost as typ on typ.scfTypeId = scfe.scfTypeId 
		inner join ScafEstCost as cost on cost.idEstCost = scfe.idEstCost
		where scfe.EstNumber like '%'
  end
end
go