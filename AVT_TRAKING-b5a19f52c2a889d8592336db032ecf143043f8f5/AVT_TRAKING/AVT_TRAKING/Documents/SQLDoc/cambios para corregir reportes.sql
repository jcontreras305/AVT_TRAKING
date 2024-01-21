--ALTER proc [dbo].[Client_Billings_Re_Cap_By_Project]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int,
--@job as bigint,
--@all as bit
--as 
--begin

--set @startdate = ISNULL(@startDate,GETDATE())
--set @finaldate = ISNULL(@finaldate,GETDATE())
--set @clientnum = ISNULL(@clientnum,(select top 1 numberClient from clients)) 

--select T2.companyName,T2.[Work Order],T2.jobNo,T2.PO,T2.[Project Desription],
--T2.[Hours Ext],T2.[Total Hours],T2.[Hours ST],T2.[Billings ST],T2.[Hours OT],T2.[Billings OT],
--T2.Complete,T2.[Es-Hrs],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend],T2.Estimate from
--(
--	select cl.companyName,concat(wo.idWO,' ',ts.task) as 'Work Order', jb.jobNo,po.idPO as 'PO',ts.description as 'Project Desription',
    	
--	ISNULL((select T1.EX from  (select sum(hours3) as 'EX' from hoursWorked as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) ,0) as 'Hours Ext',

--	(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)+
--	(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Total Hours',

--	(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours ST',
	
--	(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
--		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount' from 
--			(select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--				where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate
--			)as T1    
--		group by T1.idWorkCode
--		)as T2
--	) as 'Billings ST',

--	(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours OT',
	
--	(select ISNULL( SUM(T2.Amount),0) as 'Billings OT' from 
--		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount' from 
--			(select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--				where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate
--			)as T1    
--		group by T1.idWorkCode
--		)as T2
--	) as 'Billings OT',

--	ts.percentComplete as 'Complete',

--	ts.estimateHours as 'Es-Hrs',

--	ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--	where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0) as 'Total Expenses',
	
--	ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--			where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0) as 'Total Material',
	
--	(
		
--			(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
--			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
--			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--			where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
--			group by T1.idWorkCode) as T2)--Billing ST
--			+
--			(select  ISNULL( SUM(T2.Amount),0) as 'Billing OT' from 
--			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
--			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--			where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
--			group by T1.idWorkCode) as T2) --Billing OT
--			+
--			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--			where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0)--Expenses Used
--			+
--			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--			where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0)-- Material Used
--			)
--		 as 'Total Spend',

--	ts.estTotalBilling as 'Estimate'
--	from task as ts
--	inner join workOrder as wo on wo.idAuxWO=ts.idAuxWO
--	inner join projectOrder as po on po.idPO=wo.idPO and po.jobNo = wo.jobNo
--	inner join job as jb on jb.jobNo=po.jobNo
--	inner join clients cl on cl.idClient=jb.idClient
--	where cl.numberClient=@clientnum and ((select sum(hoursST) from hoursWorked where idAux = ts.idAux)> 0 or (select sum(hoursOT)
--		 from hoursWorked where idAux = ts.idAux)> 0 or (select sum(hours3)
--		 from hoursWorked where idAux = ts.idAux)> 0 or (select sum(amount) 
--		 from expensesUsed where idAux=ts.idAux)> 0 or (select sum(amount)
--		 from materialUsed where idAux=ts.idAux)>0)
--		 and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,''))
--		)as T2
--		where T2.[Billings ST]<>0 OR T2.[Billings OT]<>0 OR T2.[Total Expenses]<>0 OR T2.[Total Material]<>0
--		order by t2.jobNo asc
--end
--go

--ALTER proc [dbo].[select_Time_Sheet_PO]
--	@IntialDate date,
--	@FinalDate date,
--	@clientnum as int,
--	@job as bigint,
--	@all as bit
--as 
--begin
--	set @IntialDate = ISNULL(@IntialDate,GETDATE())
--	set @FinalDate = ISNULL(@FinalDate,GETDATE())
--	select * from (
--	select
--	distinct
--		cl.numberClient,
--		jb.jobNo,
--		po.idPO,
--		(select sum(hw1.hoursST) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and po1.jobNo = wo1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo inner join clients as cl1 on cl1.idClient = jb1.idClient where cl1.idClient = cl.idClient and po1.idPO=po.idPO and jb.jobNo = jb1.jobNo and hw1.idEmployee = em.idEmployee and SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))=SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) and hw1.dateWorked between @IntialDate and @FinalDate) as 'hoursST',
--		(select sum(hw2.hoursOT) from hoursWorked as hw2 inner join workCode as wc2 on wc2.idWorkCode = hw2.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk2 on tk2.idAux = hw2.idAux inner join workOrder as wo2 on wo2.idAuxWO = tk2.idAuxWO inner join projectOrder as po2 on po2.idPO = wo2.idPO and po2.jobNo = wo2.jobNo inner join job as jb2 on jb2.jobNo = po2.jobNo inner join clients as cl2 on cl2.idClient = jb2.idClient where cl2.idClient = cl.idClient and po2.idPO=po.idPO and jb.jobNo = jb2.jobNo and hw2.idEmployee = em.idEmployee and SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))=SUBSTRING( wc2.name,1,iif(CHARINDEX('-',wc2.name)=0, len(wc2.name) ,(CHARINDEX('-',wc2.name)-1))) and hw2.dateWorked between @IntialDate and @FinalDate) as 'hoursOT',
--		SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
--		hw.schedule as 'Shift',
--		CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee',
--		em.numberEmploye as 'Emp: Number',
--		em.typeEmployee as 'class'
--		from hoursWorked as hw 
--					inner join employees as em on hw.idEmployee = em.idEmployee
--					inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--					inner join task as tk on tk.idAux = hw.idAux 
--					inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
--					inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--					inner join job as jb on jb.jobNo = po.jobNo
--					inner join clients  as cl on cl.idClient = jb.idClient
--		where hw.dateWorked between @IntialDate and @FinalDate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,''))
--		) as T1 where T1.hoursST > 0 or  T1.hoursOT>0 order by T1.idPO 
--end
--go

--ALTER proc [dbo].[select_TimeSheet_Report]
--	@IntialDate date,
--	@FinalDate date,
--	@numclient int,
--	@job bigint,
--	@all bit
--as 
--begin
--	if @IntialDate is not null and @FinalDate is not null
--	begin 
--			select  
--		T1.jobNo,t1.idPO,t1.task,t1.equipament as 'equipment',t1.description, t1.accountNum,
--		SUM(t1.hoursST) AS 'hoursST',SUM(t1.hoursOT)AS 'hoursOT',SUM(t1.hours3) AS 'hours3',t1.Code,t1.Shift,t1.expCode,t1.Complete,
--		t1.hrEst,t1.Employee,t1.[Emp: Number],t1.class,  clg.companyName
--		from (
--			select distinct
--			jb.jobNo,
--			po.idPO,
--			CONCAT(wo.idWO,'-',tk.task)AS 'task' ,
--			tk.equipament,
--			tk.description,
--			tk.accountNum,
--			(select iif(SUM(hw1.hoursST)is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hoursST',
--			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hoursOT',
--			(select iif(SUM(hw1.hours3 )is null,0,SUM(hw1.hours3 )) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and not wc1.name like '%6.4%' ) as 'hours3',
--			SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Code',
--			hw.schedule as 'Shift', 
--			tk.expCode,
--			concat(tk.percentComplete,'%')  as 'Complete',
--			tk.estimateHours as 'hrEst',
--			CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee', 
--			em.numberEmploye as 'Emp: Number' ,
--			em.typeEmployee as 'class'
--			from hoursWorked as hw 
--			inner join employees as em on hw.idEmployee = em.idEmployee
--			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--			inner join task as tk on tk.idAux = hw.idAux 
--			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
--			inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--			inner join job as jb on jb.jobNo = po.jobNo
--			inner join clients as cl on cl.idClient=jb.idClient
--			where hw.dateWorked between @IntialDate and @FinalDate and (hw.hoursST > 0 or hw.hoursOT>0 or hw.hours3>0) and cl.numberClient=@numclient and jb.jobNo like IIF(@all=1,'%%',CONCAT('',@job,''))--and em.numberEmploye = 16874
--		) as T1	inner join job as jbg on jbg.jobNo = T1.jobNo inner join clients as clg on clg.idClient = jbg.idClient
--		group by T1.jobNo,t1.idPO,t1.Task,t1.equipament,t1.description,t1.hoursST, t1.accountNum,t1.hoursOT,t1.hours3,t1.Code,t1.Shift,t1.expCode,t1.Complete,
--		t1.hrEst,t1.Employee,t1.[Emp: Number],t1.class, clg.companyName
--		order by t1.Task,t1.[Emp: Number]
--end
--end
--go

--ALTER proc [dbo].[Sp_All_Jobs]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int
--as
--begin
--select distinct
--	jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',

--	ISNULL(((select ISNULL(SUM(hw1.hoursST),0) from hoursWorked as hw1 
--	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--	inner join task as tk1 on tk1.idAux = hw1.idAux 
--	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO 
--	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--	inner join job as jb1 on jb1.jobNo = po1.jobNo  
--	where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )),0) as 'Hours ST',
	
--	ISNULL(wc.billingRate1,0)AS 'billingRate1',

--	ISNULL(((select ISNULL(SUM(hw1.hoursOT),0) from hoursWorked as hw1 
--	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--	inner join task as tk1 on tk1.idAux = hw1.idAux 
--	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO 
--	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--	inner join job as jb1 on jb1.jobNo = po1.jobNo  
--	where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = tk.idAux and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) and not wc1.name like '%6.4%' )),0) as 'Hours OT',
	
--	ISNULL(wc.billingRateOT,0)as 'billingRateOT',


--	ISNULL((select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo 
--	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Per-Diem') ,0) as 'PerDiem' ,

--	ISNULL((select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo 
--	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel') ,0) as 'Travel' 
	 
--	from employees as em 
--		inner join hoursWorked as hw on hw.idEmployee = em.idEmployee
--		inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--		inner join task as tk on tk.idAux= hw.idAux
--		inner join workOrder wo on  wo.idAuxWO=tk.idAuxWO
--		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
--		inner join job as jb on jb.jobNo = wo.jobNo 
--		inner join clients as cl on cl.idClient = jb.idClient
--		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and not wc.name like '%6.4%'
--	order by 
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
--	hw.dateWorked
--end
--go

--ALTER proc [dbo].[Sp_By_JobNumber]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int,
--@job as bigint,
--@all as bit
--as
--begin
--select distinct
--	jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',
	
	
--	ISNULL((select SUM(hw1.hoursST) from 
--	hoursWorked as hw1 
--	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--	inner join task as tk1 on tk1.idAux = hw1.idAux 
--	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO 
--	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--	inner join job as jb1 on jb1.jobNo = po1.jobNo  
--	where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee 
--			and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO 
--			and wo.idAuxWO = wo1.idAuxWO 
--			and tk1.idAux = tk.idAux 
--			and (SUBSTRING(wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) 
--			and not wc1.name like '%6.4%'),0) 
--	as 'Hours ST',
		
--	ISNULL(wc.billingRate1,0)as 'billingRate1',

--	ISNULL((select ISNULL(SUM(hw1.hoursOT),0) from 
--	hoursWorked as hw1 
--	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--	inner join task as tk1 on tk1.idAux = hw1.idAux 
--	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO 
--	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--	inner join job as jb1 on jb1.jobNo = po1.jobNo  
--	where hw1.dateWorked = hw.dateWorked 
--			and em.idEmployee = hw1.idEmployee 
--			and jb.jobNo = jb1.jobNo 
--			and po1.idPO = po.idPO 
--			and wo.idAuxWO = wo1.idAuxWO 
--			and tk1.idAux = tk.idAux 
--			and (SUBSTRING( wc1.name,1,iif(CHARINDEX('-',wc1.name)=0, len(wc1.name) ,(CHARINDEX('-',wc1.name)-1))) =SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1)))  ) 
--			and not wc1.name like '%6.4%') ,0)
--	 as 'Hours OT',

--	ISNULL(wc.billingRateOT,0) as 'billingRateOT',
	
--	ISNULL((select exu.amount from expensesUsed as exu 
--	inner join expenses as ex on ex.idExpenses = exu.idExpense 
--	inner join task as tk1 on tk1.idAux = exu.idAux 
--	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO 
--	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--	inner join job as jb1 on jb1.jobNo = po1.jobNo 
--	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Per-Diem') ,0) as 'PerDiem' ,

--	ISNULL((select exu.amount from expensesUsed as exu inner join expenses as ex on ex.idExpenses = exu.idExpense inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo 
--	 where tk1.idAux = tk.idAux and wo1.idAuxWO = wo.idAuxWO and po.idPO = po1.idPO and jb.jobNo = jb1.jobNo and exu.dateExpense between @startdate and @finaldate and exu.idEmployee= em.idEmployee and ex.expenseCode like 'Travel') ,0) as 'Travel' 
--	from employees as em 
--		inner join hoursWorked as hw on hw.idEmployee = em.idEmployee
--		left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--		inner join task as tk on tk.idAux= hw.idAux
--		inner join workOrder wo on  wo.idAuxWO=tk.idAuxWO
--		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
--		inner join job as jb on jb.jobNo = wo.jobNo 
--		inner join clients as cl on cl.idClient = jb.idClient
--		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,'')) and not wc.name like '%6.4%' 
--	order by 
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
--	hw.dateWorked
--end
--go

--ALTER proc [dbo].[sp_Cats_Employee_by_Porject]
--@startdate as date,
--@finaldate as date,
--@employeenumber int,
--@all as bit
--as
--begin
--	select concat(wo.idWO, ' ',ts.task) as 'W/PO Number',
--		em.numberEmploye as 'Emp: Number',
--		concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--		wc.description,
--		sum(hw.hoursST) as 'ST Hours', 
--		sum(hw.hoursOT) as 'OT Hours', 
--		hw.dateWorked as 'Date Worked'
--		from hoursWorked as hw
--		inner join employees as em on em.idEmployee= hw.idEmployee
--		inner join workCode as wc on wc.idWorkCode= hw.idWorkCode and wc.jobNo = hw.jobNo
--		inner join task as ts on ts.idAux= hw.idAux
--		inner join workOrder wo on wo.idAuxWO=ts.idAuxWO
--		where hw.dateWorked between @startdate and @finaldate and em.numberEmploye like IIF(@all=1,'%',convert(nvarchar, @employeenumber))
--		group by concat(wo.idWO, ' ',ts.task),em.numberEmploye, concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
--		 wc.description,hw.dateWorked
--end
--GO

--ALTER proc [dbo].[sp_Cats_Employee_by_Porject]
--@startdate as date,
--@finaldate as date,
--@employeenumber int,
--@all as bit
--as
--begin
--	select concat(wo.idWO, ' ',ts.task) as 'W/PO Number',
--		em.numberEmploye as 'Emp: Number',
--		concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--		wc.description,
--		sum(hw.hoursST) as 'ST Hours', 
--		sum(hw.hoursOT) as 'OT Hours', 
--		hw.dateWorked as 'Date Worked'
--		from hoursWorked as hw
--		inner join employees as em on em.idEmployee= hw.idEmployee
--		inner join workCode as wc on wc.idWorkCode= hw.idWorkCode and wc.jobNo = hw.jobNo
--		inner join task as ts on ts.idAux= hw.idAux
--		inner join workOrder wo on wo.idAuxWO=ts.idAuxWO
--		where hw.dateWorked between @startdate and @finaldate and em.numberEmploye like IIF(@all=1,'%',convert(nvarchar, @employeenumber))
--		group by concat(wo.idWO, ' ',ts.task),em.numberEmploye, concat(em.lastName,', ', em.firstName,' ' ,em.middleName),
--		 wc.description,hw.dateWorked
--end
--GO

--ALTER proc [dbo].[sp_Client_billings_Project]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int
--as
--begin
--	set @startdate = ISNULL(@startdate,GETDATE())
--	set @finaldate = ISNULL(@FinalDate,GETDATE())
--	select T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
--			T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
--			T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend] from(
--		select cl.companyName, jb.jobNo, po.idPO,concat(wo.idWO,' ',ts.task) as 'Work Order',
--			ts.description as 'Project Desription',

--			(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)+
--			(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Total Hours',
		
		
--			(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours ST',
		
		
--			(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
--			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
--			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
--			group by T1.idWorkCode) as T2) as 'Billings ST',

--			(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours OT',
	
		
--			(select  ISNULL( SUM(T2.Amount),0) as 'Billings OT' from 
--			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
--			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
--			group by T1.idWorkCode) as T2) as 'Billings OT',


--			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0) as 'Total Expenses',
			
			
--			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0) as 'Total Material',
	
--			((select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
--			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
--			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
--			group by T1.idWorkCode) as T2)
--			+
--			(select  ISNULL( SUM(T2.Amount),0) from 
--			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
--			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
--			group by T1.idWorkCode) as T2)
--			+
--			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0)
--			+
--			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--			where cl.idClient = jb1.idClient and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0)
--			) as 'Total Spend'

--			from Clients as cl
--			inner join job as jb on jb.idClient= cl.idClient
--			inner join projectOrder as po on po.jobNo= jb.jobNo 
--			inner join workOrder as wo on wo.idPO=po.idPO and po.jobNo = wo.jobNo
--			inner join task as ts on ts.idAuxWO=wo.idAuxWO
	 
--			where cl.numberClient=@clientnum 
--			)as T2 
--			where
--			T2.[Billings ST]>0 OR T2.[Billings OT]>0 OR T2.[Total Expenses]>0 OR T2.[Total Material]>0 or T2.[Total Expenses] > 0
--			group by T2.companyName,T2.jobNo,T2.idPO,T2.[Work Order],T2.[Project Desription],
--			T2.[Total Hours],T2.[Hours ST],T2.[Billings ST], T2.[Hours OT],
--			T2.[Billings OT],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend]
--end
--GO

--ALTER proc [dbo].[sp_Invoice_PO_Resume]
--@numberClient  int,
--@startDate date,
--@FinalDate date,
--@idPO bigint,
--@all bit
--as
--begin
--select T1.companyName,T1.payTerms,T1.city,T1.providence,T1.[Address],T1.postalCode,T1.jobNo,T1.custumerNo,T1.contractNo,T1.idPO,
--T1.[Total Hours PO],T1.[Total Hours],T1.[Total Labor],
--T1.[Total Expenses],T1.[Total PerDiem],T1.[3rdParty],T1.[ScRent],T1.[CoEQ],T1.[Material],T1.[Subcontractors],T1.[Other],T1.[ExtraCostMaterial]
--,T1.[Total Material]
--,T1.[Total Cost]
-- from (
--select 
--	cl.companyName,
--	cl.payTerms,
--	ha.city,
--	ha.providence,
--	CONCAT(ha.number,' ',ha.avenue) as 'Address',
--	ha.postalCode,
--	jb.jobNo,
--	jb.custumerNo,
--	isnull(jb.contractNo,'') as 'contractNo',
--	po.idPO,
	
--	ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
--	as 'Total Hours PO',

--	ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
--	as 'Total Hours',

--	ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
--	as 'Total Labor',

--	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
--		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
--		inner join task as tk1 on tk1.idAux = exu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate and ex1.expenseCode like '%travel%'),0)
--	as 'Total Expenses',

--	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
--		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
--		inner join task as tk1 on tk1.idAux = exu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate and ex1.expenseCode like '%per-diem%'),0)
--	as 'Total PerDiem',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.201-D' or mtc1.code = '2.255-D' or mtc1.code = '2.256-D' or mtc1.code = '2.202-D'or mtc1.code = '2.203-D'or mtc1.code = '2.303-F'or mtc1.code = '2.304-F' )),0) 
--	as '3rdParty',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.204-D' or mtc1.code = '2.207-D' or mtc1.code = '2.254-E' or mtc1.code = '2.257-E')),0) 
--	as 'ScRent',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.251-E' or mtc1.code = '2.252-D' or mtc1.code = '2.253-E' or mtc1.code = '2.301-F' or mtc1.code = '2.302-F'or mtc1.code = '2.907-Y')),0) 
--	as 'CoEQ',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.500-M' or mtc1.code = '2.515-M')),0) 
--	as 'Material',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.600-S')),0) 
--	as 'Subcontractors',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.900-Y' or mtc1.code = '2.911-Y')),0) 
--	as 'Other',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and not (
--		   mtc1.code = '2.201-D' or mtc1.code = '2.202-D' or mtc1.code = '2.203-D' or mtc1.code = '2.255-D' or mtc1.code = '2.256-D' or mtc1.code = '2.303-F' or mtc1.code = '2.304-F'
--		or mtc1.code = '2.204-D' or mtc1.code = '2.207-D' or mtc1.code = '2.254-E' or mtc1.code = '2.257-E' 
--		or mtc1.code = '2.252-D' or mtc1.code = '2.253-E' or mtc1.code = '2.301-F' or mtc1.code = '2.302-F' or mtc1.code = '2.251-E' or mtc1.code = '2.907-Y'
--		or mtc1.code = '2.500-M' or mtc1.code = '2.515-M' 
--		or mtc1.code = '2.600-S' 
--		or mtc1.code = '2.900-Y' or mtc1.code = '2.911-Y')),0) 
--	as 'ExtraCostMaterial',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate),0) 
--	as 'Total Material'
	
--	,
--	ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0)
--	+
--	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
--		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
--		inner join task as tk1 on tk1.idAux = exu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate),0)
--	+
--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate),0 )
--	as 'Total Cost'
--from job as jb 
--inner join clients as cl on cl.idClient = jb.idClient 
--left join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAddress
--inner join projectOrder as po on po.jobNo = jb.jobNo
--where cl.idClient = (select idClient from clients where numberClient = @numberClient)  and  po.idPO like iif(@all = 1 ,'%%',convert(nvarchar, @idPO)) 
--) as T1 where T1.[Total Labor]>0 or
--T1.[Total Expenses]>0 or T1.[Total PerDiem]>0 or T1.[3rdParty]>0 or T1.[ScRent]>0 or T1.[CoEQ]>0 or T1.[Material]>0 or T1.[Subcontractors]
-->0 or T1.[Other]>0 or t1.[ExtraCostMaterial]
-->0 or T1.[Total Material] >0
--end
--GO

--ALTER proc [dbo].[sp_selectJobTaxesExcel] 
--@StartDate as date, 
--@EndDate as date 
--as
--begin
--select T1.jobNo ,T1.[ST Hours] ,T1.[OT Hours],T1.[Total Hours] ,T1.[Labor Cost] ,T1.[Scaffold-ADD] ,
--	T1.[3rd Party Cost],T1.[In House Vehicles],T1.[Company Equipment] ,T1.[Material Cost],T1.[Subcontract Cost] ,
--	T1.[Tools] ,T1.[Consumables] ,T1.[Other Cost] , T1.[Other Revanue],
--	ISNULL(txs.FICA,0) as 'FICA',
--	ISNULL(txs.FUI,0) as 'FUI',
--	ISNULL(txs.SUI,0) as 'SUI',
--	ISNULL(txs.WC,0) as 'WC',
--	ISNULL(txs.GenLiab,0) as 'Gen Liab',
--	ISNULL(txs.Umbr,0) as 'Umbr',
--	ISNULL(txs.Pollution,0) as 'Pollution',
--	ISNULL(txs.Healt,0) as 'Healt',
--	ISNULL(txs.Fringe,0) as 'Fringe',
--	ISNULL(txs.Small,0) as 'Small',
--	ISNULL(txs.PPE,0) as 'PPE',
--	ISNULL(txs.Consumable,0) as 'Consumable',
--	ISNULL(txs.Overhead,0) as 'Overhead',
--	ISNULL(txs.Profit,0) as 'Profit',
--	ISNULL(txP.FICA,0) as 'FICA P',
--	ISNULL(txP.FUI,0) as 'FUI P',
--	ISNULL(txP.SUI,0) as 'SUI P',
--	ISNULL(txP.WC,0) as 'WC P',
--	ISNULL(txP.GenLiab,0) as 'Gen Liab P',
--	ISNULL(txP.Umbr,0) as 'Umbr P',
--	ISNULL(txP.Pollution,0) as 'Pollution P',
--	ISNULL(txP.Healt,0) as 'Healt P',
--	ISNULL(txP.Fringe,0) as 'Fringe P',
--	ISNULL(txP.Small,0) as 'Small P',
--	ISNULL(txP.PPE,0) as 'PPE P',
--	ISNULL(txP.Consumable,0) as 'Consumable P',
--	ISNULL(txP.Overhead,0) as 'Overhead P',
--	ISNULL(txP.Profit,0) as 'Profit P'
--from(
--select distinct jb.jobNo,
--	ISNULL((select SUM(hw1.hoursST) from hoursWorked as hw1 
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'ST Hours',
--	ISNULL((select SUM(hw1.hoursOT+hw1.hours3 ) from hoursWorked as hw1 
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'OT Hours',
--	ISNULL((select SUM(hw1.hoursST+hw1.hoursOT+hw1.hours3) from hoursWorked as hw1 
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'Total Hours',
--	ISNULL((select ROUND(SUM((hw1.hoursST*wc1.billingRate1)+(hw1.hoursOT*wc1.billingRateOT)+(hw1.hours3*wc1.billingRate3)),2) from hoursWorked as hw1 
--		left join workCode as wc1 on wc1.idWorkCode= hw1.idWorkCode and wc1.jobNo = hw1.jobNo
--		inner join task as tk1 on tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on wo1.idPO = po1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and hw1.dateWorked between @StartDate and @EndDate),0) as 'Labor Cost',
--	ISNULL((select Scaffold from taxesST where jobNo = jb.jobNo),0) as 'Scaffold-ADD',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='D'),0) AS '3rd Party Cost',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='E'),0) AS 'In House Vehicles',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='F'),0) AS 'Company Equipment',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='M'),0) AS 'Material Cost',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='S'),0) AS 'Subcontract Cost',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='T'),0) AS 'Tools',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='V'),0) AS 'Consumables',
--	ISNULL((select SUM(amount) from materialUsed as mu1
--		inner join material as mt1 on mu1.idMaterial = mt1.idMaterial
--		left join materialClass as mc1 on mt1.code = mc1.code
--		inner join task as tk1 on tk1.idAux = mu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and mu1.dateMaterial between @StartDate and @EndDate and SUBSTRING(mc1.code ,LEN(mc1.code),1)='Y'),0) AS 'Other Cost',
--	(select ROUND(ISNULL(SUM(amount),0),2) 
--		from expensesUsed as exu1 
--		inner join task as tk1 on tk1.idAux = exu1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and po1.jobNo = wo1.jobNo
--		inner join job as jb1 on jb1.jobNo = po1.jobNo
--		where jb1.jobNo = jb.jobNo and exu1.dateExpense between @StartDate and @EndDate ) as 'Other Revanue'
--from job as jb
--left join projectOrder as po on po.jobNo = jb.jobNo
--left join workOrder as wo on wo.idPO = po.idPO and wo.jobNo = po.idPO
--left join task as tk on tk.idAuxWO = wo.idAuxWO 
--left join hoursWorked as hw on hw.idAux = tk.idAux
--) as T1 
--left join taxesST as txs on txs.jobNo = T1.jobNo
--left join taxesPT as txp on txp.jobNo = T1.jobNo
--end
--GO

--ALTER proc [dbo].[Sp_Vacation_Employee]
--@NoEmployee int,
--@year nVarchar(4),
--@all bit
--as
--begin
--    set @year = isnull(@year, DATENAME(YEAR,GETDATE()))
		
--		if @all = 0 begin
--		select t1.[Employee],t1.[Emp: Number],t1.[Day],t1.[Project Name],t1.[Work Description],t1.[Rate ST],
--	    t1.[hoursST],T1.[Rate OT] ,t1.[hoursOT] 
--		from(
--		select distinct
--			CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee', 
--			em.numberEmploye as 'Emp: Number' ,
--			hw.dateWorked as 'Day',
--			concat(wo.idWO,'-',tk.task) as 'Project Name',
--			SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Work Description',
--			wc.billingRate1 as 'Rate ST',
--			(select iif(SUM(hw1.hoursST)  is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursST',
--			wc.billingRateOT as 'Rate OT',
--			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursOT'
--			from hoursWorked as hw 
--			inner join employees as em on hw.idEmployee = em.idEmployee
--			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--			inner join task as tk on tk.idAux = hw.idAux 
--			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
--			inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--			inner join job as jb on jb.jobNo = po.jobNo
--			where   DATEPART(YEAR ,hw.dateWorked) =@year and numberEmploye=@NoEmployee and (hw.hoursST > 0 or hw.hoursOT>0 or hw.hours3>0) and  wc.name like '%6.4%' --and em.numberEmploye = 16874
--		)as t1
--		group by t1.[Employee],t1.[Emp: Number],t1.[Day],t1.[Project Name],t1.[Work Description],t1.[Rate ST],
--	t1.[hoursST],T1.[Rate OT] ,t1.[hoursOT] 

--end
--else
--begin
--select t1.[Employee],t1.[Emp: Number],t1.[Day],t1.[Project Name],t1.[Work Description],t1.[Rate ST],
--	t1.[hoursST],T1.[Rate OT] ,t1.[hoursOT] 
--		from(
--		select distinct
--			CONCAT(em.lastName,' ',em.firstName,' ',em.middleName) as 'Employee', 
--			em.numberEmploye as 'Emp: Number' ,
--			hw.dateWorked as 'Day',
--			concat(wo.idWO,'-',tk.task) as 'Project Name',
--			SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))) as 'Work Description',
--			wc.billingRate1 as 'Rate ST',
--			(select iif(SUM(hw1.hoursST)  is null,0,SUM(hw1.hoursST)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursST',
--			wc.billingRateOT as 'Rate OT',
--			(select iif(SUM(hw1.hoursOT)is null,0,SUM(hw1.hoursOT)) from hoursWorked as hw1 inner join workCode as wc1 on wc1.idWorkCode = hw.idWorkCode and wc1.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where hw1.dateWorked = hw.dateWorked and em.idEmployee = hw1.idEmployee and jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and  wc1.name like '%6.4%') as 'hoursOT'
			

--			from hoursWorked as hw 
--			inner join employees as em on hw.idEmployee = em.idEmployee
--			inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--			inner join task as tk on tk.idAux = hw.idAux 
--			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
--			inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--			inner join job as jb on jb.jobNo = po.jobNo
--			where   DATEPART(YEAR ,hw.dateWorked) =@year  and (hw.hoursST > 0 or hw.hoursOT>0 or hw.hours3>0) and  wc.name like '%6.4%' --and em.numberEmploye = 16874
--		)as t1
--		group by t1.[Employee],t1.[Emp: Number],t1.[Day],t1.[Project Name],t1.[Work Description],t1.[Rate ST],
--	t1.[hoursST],T1.[Rate OT] ,t1.[hoursOT] 
--	end
--end
--GO

--ALTER proc [dbo].[sp_Year_Final_Hours]
--@year nVarchar(4)
--as
--begin
--    set @year = isnull(@year, DATENAME(YEAR,GETDATE()))
	
--	select *, T1.January+T1.February+T1.March+T1.April+T1.May+T1.June+T1.July+T1.August+T1.September+T1.October+T1.Nomvember+T1.Dicember as 'Total' 
--	from (
--	select 
--		wc.name,
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'January'),0) as 'January',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'February'),0) as 'February',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'March'),0) as 'March',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'April') ,0) as 'April',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'May') ,0) as 'May',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'June'),0) as 'June',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'July'),0) as 'July',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'August'),0) as 'August',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'September'),0) as 'September',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'October'),0) as 'October',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'November'),0) as 'Nomvember',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'Dicember'),0) as 'Dicember'
--	from workCode as wc ) as T1
--	where (T1.January+T1.February+T1.March+T1.April+T1.May+T1.June+T1.July+T1.August+T1.September+T1.October+T1.Nomvember+T1.Dicember) > 0
--end
--GO
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V
----###############################################################################################
----########### CAMBIO PARA LOS REPORTES DE TIENEN PERDIEM ########################################
----###############################################################################################
--ALTER proc [dbo].[sp_Invoice_PO_Resume]
--@numberClient  int,
--@startDate date,
--@FinalDate date,
--@idPO bigint,
--@all bit
--as
--begin
--select T1.companyName,T1.payTerms,T1.city,T1.providence,T1.[Address],T1.postalCode,T1.jobNo,T1.custumerNo,T1.contractNo,T1.idPO,
--T1.[Total Hours PO],T1.[Total Hours],T1.[Total Labor],
--T1.[Total Expenses],T1.[Total PerDiem],T1.[3rdParty],T1.[ScRent],T1.[CoEQ],T1.[Material],T1.[Subcontractors],T1.[Other],T1.[ExtraCostMaterial]
--,T1.[Total Material]
--,T1.[Total Cost]
-- from (
--select 
--	cl.companyName,
--	cl.payTerms,
--	ha.city,
--	ha.providence,
--	CONCAT(ha.number,' ',ha.avenue) as 'Address',
--	ha.postalCode,
--	jb.jobNo,
--	jb.custumerNo,
--	isnull(jb.contractNo,'') as 'contractNo',
--	po.idPO,
	
--	ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
--	as 'Total Hours PO',

--	ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
--	as 'Total Hours',

--	ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0) 
--	as 'Total Labor',

--	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
--		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
--		inner join task as tk1 on tk1.idAux = exu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate and ex1.expenseCode like '%travel%'),0)
--	as 'Total Expenses',

--	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
--		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
--		inner join task as tk1 on tk1.idAux = exu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0)
--	as 'Total PerDiem',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.201-D' or mtc1.code = '2.255-D' or mtc1.code = '2.256-D' or mtc1.code = '2.202-D'or mtc1.code = '2.203-D'or mtc1.code = '2.303-F'or mtc1.code = '2.304-F' )),0) 
--	as '3rdParty',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.204-D' or mtc1.code = '2.207-D' or mtc1.code = '2.254-E' or mtc1.code = '2.257-E')),0) 
--	as 'ScRent',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.251-E' or mtc1.code = '2.252-D' or mtc1.code = '2.253-E' or mtc1.code = '2.301-F' or mtc1.code = '2.302-F'or mtc1.code = '2.907-Y')),0) 
--	as 'CoEQ',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.500-M' or mtc1.code = '2.515-M')),0) 
--	as 'Material',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.600-S')),0) 
--	as 'Subcontractors',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and (mtc1.code = '2.900-Y' or mtc1.code = '2.911-Y')),0) 
--	as 'Other',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate 
--		and not (
--		   mtc1.code = '2.201-D' or mtc1.code = '2.202-D' or mtc1.code = '2.203-D' or mtc1.code = '2.255-D' or mtc1.code = '2.256-D' or mtc1.code = '2.303-F' or mtc1.code = '2.304-F'
--		or mtc1.code = '2.204-D' or mtc1.code = '2.207-D' or mtc1.code = '2.254-E' or mtc1.code = '2.257-E' 
--		or mtc1.code = '2.252-D' or mtc1.code = '2.253-E' or mtc1.code = '2.301-F' or mtc1.code = '2.302-F' or mtc1.code = '2.251-E' or mtc1.code = '2.907-Y'
--		or mtc1.code = '2.500-M' or mtc1.code = '2.515-M' 
--		or mtc1.code = '2.600-S' 
--		or mtc1.code = '2.900-Y' or mtc1.code = '2.911-Y')),0) 
--	as 'ExtraCostMaterial',

--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		left join materialClass as mtc1 on mtc1.code = mt1.code
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate),0) 
--	as 'Total Material'
	
--	,
--	ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
--		inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
--		inner join task as tk1 on tk1.idAux = hw1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and hw1.dateWorked between @startDate and @FinalDate),0)
--	+
--	ISNULL((select sum(exu1.amount) from expensesUsed as exu1
--		inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
--		inner join task as tk1 on tk1.idAux = exu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and exu1.dateExpense between @startDate and @FinalDate),0)
--	+
--	ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
--		inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
--		inner join task as tk1 on tk1.idAux = mtu1.idAux 
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
--		inner join job as jb1 on po1.jobNo = jb1.jobNo
--		inner join clients  as cl1 on cl1.idClient = jb1.idClient
--		where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.numberClient = @numberClient and mtu1.dateMaterial between @startDate and @FinalDate),0 )
--	as 'Total Cost'
--from job as jb 
--inner join clients as cl on cl.idClient = jb.idClient 
--left join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAddress
--inner join projectOrder as po on po.jobNo = jb.jobNo
--where cl.idClient = (select idClient from clients where numberClient = @numberClient)  and  po.idPO like iif(@all = 1 ,'%%',convert(nvarchar, @idPO)) 
--) as T1 where T1.[Total Labor]>0 or
--T1.[Total Expenses]>0 or T1.[Total PerDiem]>0 or T1.[3rdParty]>0 or T1.[ScRent]>0 or T1.[CoEQ]>0 or T1.[Material]>0 or T1.[Subcontractors]
-->0 or T1.[Other]>0 or t1.[ExtraCostMaterial]
-->0 or T1.[Total Material] >0
--end
--go
--ALTER proc [dbo].[Sp_All_Jobs]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int
--as
--begin
--select distinct
--T1.[jobNo],
--T1.[idPO],
--T1.[idWO],
--T1.[task],
--T1.[SAPNumber],
--T1.[numberEmploye],
--T1.[DAY],
--T1.[Employee Name],
--T1.[dateWorked],
--T1.[Code],
--SUM(T1.[Hours ST])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Hours ST',
--T1.[billingRate1],
--SUM(T1.[Hours OT])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Hours OT',
--T1.[billingRateOT],
--SUM(T1.[PerDiem])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'PerDiem',
--SUM(T1.[Travel])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Travel'
--from(
--select
--	jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',

--	hw.hoursST as 'Hours ST',
	
--	ISNULL(wc.billingRate1,0)AS 'billingRate1',

--	hw.hoursOT as 'Hours OT',
	
--	ISNULL(wc.billingRateOT,0)as 'billingRateOT',


--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem' ,
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
	
--	from hoursWorked as hw 
--		left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--		inner join employees as em on em.idEmployee = hw.idEmployee
--		inner join task as tk on tk.idAux = hw.idAux 
--		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--		inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--		inner join job as jb on jb.jobNo = po.jobNo 
--		inner join clients as cl on cl.idClient = jb.idClient
--		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and not wc.name like '%6.4%' 
--)as T1
--end
--go
--ALTER proc [dbo].[Sp_By_JobNumber]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int,
--@job as bigint,
--@all as bit
--as
--begin
--select distinct
--T1.[jobNo],
--T1.[idPO],
--T1.[idWO],
--T1.[task],
--T1.[SAPNumber],
--T1.[numberEmploye],
--T1.[DAY],
--T1.[Employee Name],
--T1.[dateWorked],
--T1.[Code],
--SUM(T1.[Hours ST])     OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Hours ST',
--T1.[billingRate1],
--SUM(T1.[Hours OT])     OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Hours OT',
--T1.[billingRateOT],
--SUM(T1.[PerDiem])      OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'PerDiem',
--SUM(T1.[Travel])       OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Travel'
--from(
--select jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',
	
--	hw.hoursST
--	as 'Hours ST',
		
--	ISNULL(wc.billingRate1,0)as 'billingRate1',

--	hw.hoursOT
--	as 'Hours OT',

--	ISNULL(wc.billingRateOT,0) as 'billingRateOT',
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem',
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate 
--			and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux	and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
--from hoursWorked as hw 
--left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--inner join employees as em on em.idEmployee = hw.idEmployee
--inner join task as tk on tk.idAux = hw.idAux 
--inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--inner join job as jb on jb.jobNo = po.jobNo 
--inner join clients as cl on cl.idClient = jb.idClient
--where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,'')) and not wc.name like '%6.4%' 
--)as T1
--end
--go
--ALTER proc [dbo].[Sp_Employee_Per_Diem_Sheets]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int,
--@job as bigInt,
--@all as bit
--as
--begin
--	select 
--	CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, xp.dateExpense)) ,xp.dateExpense)) as 'Weekending',
--			po.jobNo as 'Job Num',
--			po.idPO as 'PO',
--			CONCAT(wo.idWO,' ', tk.task) as 'Project Name',
--			ex.expenseCode as 'Project Description' ,
--			cl.companyName as 'Company Name',  
--			CONCAT(em.lastName,',',em.firstName,' ',em.middleName) as 'Employee Name',
--			em.numberEmploye as 'Emp: Number',
--			em.typeEmployee as 'Class', 
--			sum(xp.amount) as 'Amount'
--			from expensesUsed as xp 
--			inner join expenses as ex on xp.idExpense = ex.idExpenses
--			inner join employees as em on em.idEmployee = xp.idEmployee 
--			inner join task as tk on tk.idAux = xp.idAux
--			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--			inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
--			inner join job as jb on jb.jobNo = wo.jobNo 
--			inner join clients as cl on cl.idClient = jb.idClient
--			where xp.dateExpense  between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,''))
--			group by CONVERT(date, DATEADD(DAY,  8-(DATEPART(dw, xp.dateExpense)) ,xp.dateExpense)),po.jobNo,po.idPO, wo.idWO, tk.task,cl.companyName, ex.expenseCode,
--			CONCAT(em.lastName,',',em.firstName,' ',em.middleName),em.numberEmploye,em.typeEmployee
--end
--go

----###############################################################################################
----########### CAMBIO PARA LOS REPORTES DE ESTIMACION ############################################
----###############################################################################################

--ALTER proc [dbo].[sp_SelectScaffoldBudgetEstimate]
--	@projectId as varchar(30)
--as
--begin
--select 
--cl.numberClient, cl.contactName, cl.companyName, cl.plant, ha.avenue, ha.city, ha.providence,
--po.projectId as 'Project' ,po.[description] as 'Description',estCScf.tag , dr.idDrawingNum , scf.location as 'Location', CONCAT(scf.width,'x',scf.[length],'x',scf.heigth) as 'Dimention',scf.build as 'Elevation',
--scf.[days] as 'Days Active',scf.idSCFUR as 'Scaf.Type', FORMAT ((((scf.width)*(scf.[length])*(scf.heigth))/35.31),'###.00') as 'M3',estCScf.M2 as 'M2', scf.idLaborRate as 'Work Week' ,
----MAN HRS SCF
----estCScf.SBHR as 'Man Hrs B' ,estCScf.SHRD as 'Man Hrs D',
--estCScf.SHR as 'Man Hrs B' ,estCScf.SDHR as 'Man Hrs D',
----MAN HRS DECKS
--ISNULL(ROUND((select top 1 estB.SBHR from EstCostBuild as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0),0) as 'Man Hrs Deck B',
--ISNULL(ROUND((select top 1 estD.SHRD from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0),0) as 'Man Hrs Deck D',
--scf.decks as 'Decks',
----DESCKS LABOR
--ISNULL((select estB.SCOSTLB from EstCostBuild as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'Decks Labor B',
--ISNULL((select estD.DSCOSTL from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'Decks Labor D',
----SCAF LABOR 
--ISNULL((select estB.SCOSTL from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Labor B',
--ISNULL((select estB.SCOSTLD from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Labor D',
----MATERIAL
--ISNULL((select estB.SCOSTM from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Material B',
--ISNULL((select estD.SCOSTMD from EstCostScf as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'SCF Material D',
--ISNULL((select estB.SCOSTMB from EstCostBuild as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'DECK Material B',
--ISNULL((select estD.DSCOSTM from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'DECK Material D',
----EQUIPMENT
--ISNULL((select estB.SCOSTE from EstCostScf as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'SCF Equipment B',
--ISNULL((select estD.SCOSTED from EstCostScf as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'SCF Equipment D',
--ISNULL((select estB.SCOSTEB from EstCostBuild as estB where estB.idDrawingNum = estCScf.idDrawingNum and estB.projectId = estCScf.projectId and estB.tag = estCScf.tag),0) as 'DECK Equipment B',
--ISNULL((select estD.SCOSTEDD from EstCostDism as estD where estD.idDrawingNum = estCScf.idDrawingNum and estD.projectId = estCScf.projectId and estD.tag = estCScf.tag),0) as 'DECK Equipment D'

--from EstCostScf as estCScf
--inner join scaffoldEst as scf on scf.idDrawingNum = estCScf.idDrawingNum and scf.tag = estCScf.tag
--inner join drawing as dr on dr.idDrawingNum = estCScf.idDrawingNum
--inner join projectClientEst as po on po.projectId = estCScf.projectId
--inner join clientsEst as cl on cl.idClientEst = po.idClientEst
--inner join HomeAddress as ha on ha.idHomeAdress = cl.idHomeAdress
--where estCScf.projectId  = @projectId
--end

----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V
----###############################################################################################
----########### CAMBIO PARA EL REPORTE DE YEAR FINAL HOURS ########################################
----###############################################################################################

--ALTER proc [dbo].[sp_Year_Final_Hours]
--@year nVarchar(4),
--@numberClient int,
--@jobNo bigint
--as
--begin
--    set @year = isnull(@year, DATENAME(YEAR,GETDATE()))
	
--	select *, T1.January+T1.February+T1.March+T1.April+T1.May+T1.June+T1.July+T1.August+T1.September+T1.October+T1.Nomvember+T1.Dicember as 'Total' 
--	from (
--	select 
--		cl.companyName,
--		jb.jobNo,
--		wc.name,
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'January'),0) as 'January',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'February'),0) as 'February',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'March'),0) as 'March',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'April') ,0) as 'April',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'May') ,0) as 'May',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'June'),0) as 'June',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'July'),0) as 'July',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'August'),0) as 'August',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'September'),0) as 'September',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'October'),0) as 'October',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'November'),0) as 'Nomvember',
--		ISNULL( (select SUM(hw.hoursST)+SUM(hw.hoursOT)+SUM(hw.hours3) from hoursWorked as hw where hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo and DATEPART(YEAR ,hw.dateWorked) = @year and DATENAME(MONTH, hw.dateWorked) = 'Dicember'),0) as 'Dicember'
--	from workCode as wc 
--	inner join job as jb on jb.jobNo = wc.jobNo 
--	inner join clients as cl on cl.idClient = jb.idClient
--	where CONVERT(nvarchar, cl.numberClient) like iif(@numberClient = 0 ,'%%',convert( nvarchar,@numberClient)) and convert(nvarchar,jb.jobNo) like IIF( @jobNo = 0,'%%',convert(nvarchar,@jobNo))    
--	) as T1
--	where (T1.January+T1.February+T1.March+T1.April+T1.May+T1.June+T1.July+T1.August+T1.September+T1.October+T1.Nomvember+T1.Dicember) > 0
--end
--go

----###############################################################################################
----########### CAMBIO PARA EL REPORTE DE EMPLOYEE PER DIEM SHEET #################################
----###############################################################################################
--alter proc [dbo].[Sp_Employee_Per_Diem_Sheets]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int,
--@job as bigInt,
--@all as bit
--as
--begin
--	SELECT 
--	DISTINCT
--	T1.[Weekending],T1.[Job Num],T1.[PO],T1.[Project Name],T1.[Project Description],T1.[Company Name],T1.[Employee Name],
--	T1.[Emp: Number],T1.[Class],
--	SUM	(T1.[Amount]) OVER (PARTITION BY T1.[Weekending],T1.[Job Num],T1.[PO],T1.[Emp: Number],T1.[Project Description],T1.[Company Name]) as 'Amount'
--FROM 
--(select CONVERT(date, DATEADD(DAY, IIF(DATEPART(dw, xp.dateExpense) = 1,0,  8-(DATEPART(dw, xp.dateExpense))) ,xp.dateExpense)) as 'Weekending',
--	jb.jobNo 'Job Num', po.idPO as 'PO', concat(wo.idWO,' ',tk.task) as 'Project Name',
--	ex.expenseCode as 'Project Description', cl.companyName as 'Company Name',
--	CONCAT(em.lastName,',',em.firstName,' ',em.middleName) as 'Employee Name',
--	em.numberEmploye as 'Emp: Number',
--	em.typeEmployee as 'Class', 
--	xp.amount as 'Amount'
--from expensesUsed as xp 
--			inner join expenses as ex on xp.idExpense = ex.idExpenses
--			inner join employees as em on em.idEmployee = xp.idEmployee 
--			inner join task as tk on tk.idAux = xp.idAux
--			inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--			inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
--			inner join job as jb on jb.jobNo = wo.jobNo 
--			inner join clients as cl on cl.idClient = jb.idClient
--			where xp.dateExpense between @startdate and @finaldate
--				and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,''))
--) AS T1
--end
--go

----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V
----###############################################################################################
----########### CAMBIOS PARA EL REPORTE DE FIEL FORSE TS ##########################################
----###############################################################################################

----===============================================================================================
----=========== SE AGREGO EL CAMPO DE POSTING PROJECT EN CLIENTS ==================================
----===============================================================================================
--alter table clients 
--add postingProject varchar (12)
--update clients set postingProject = '0'
--go

--ALTER proc [dbo].[sp_Update_Client]
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
--	@postalcode int,
--	@img image,
--	@payTerms varchar(30),
--	@PostingProject varchar(12)
--as
--declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
--begin 
--	begin tran 
--		begin try
--			--se inserta un contacto

--				update contact set phoneNumber1= @phoneNumer1 , phoneNumber2=@phoneNumer2 ,email = @email where idContact = @idContact
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
--				update HomeAddress set avenue= @avenue, number = @number , city=@city , providence =@providence, postalCode = @postalcode where idHomeAdress = @idAddres
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
--				update  clients set firstName= @FirstName,middleName= @MiddleName,lastName= @LastName ,companyName=@CompanyName,estatus = @Status, photo = @img ,payTerms = @payTerms, postingProject = @PostingProject where idClient = @idCL
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
--ALTER proc [dbo].[sp_Insert_Cient] 
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
--	@postalcode int,
--	--Photo
--	@img image,
--	@payTerms varchar(30),
--	@PostingProject varchar(12)
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
--				insert into clients values (@idClient , @ClientID, @FirstName, @MiddleName, @LastName , @CompanyName, @idContact , @idHomeAdress ,@Status,@img,@payTerms,@PostingProject)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 

--				insert into TrackDefaultElements values(NEWID(),@idClient,'','','','','','','','','','','','','','','','','','','','','','','','','','','','')
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
				
--				insert into TrackFormatColums values(NEWID(),@idClient,'Record ID1','Force or Reject1','Source1','Date1','Order Type1','Location ID1','Company Code1','Resource ID1','Resource Name1','Area1','Group Name1','Agreement1','Skill Type1','Shift1','Level 1 ID1','Level 2 ID1','Level 3 ID1','Level 4 ID1','Hours Total1','Hours Total Activity Code1','S/T (Hrs)1','S/T Hrs Activity Code1','O/T (Hrs)1','O/T Hrs Activity Code1','D/T (Hrs)1','D/T Hrs Activity Code1','Extra Charges $1','Extra Charges $ Activity Code1','Extra1','Extra 11','Extra 21','Add Time1','Pay Type1','R4 (Hrs)1','R5 (Hrs)1','R6 (Hrs)1','GL Account1','ST Adders1','OT Adders1','DT Adders1','R4 Adders1','R5 Adders1','R6 Adders1')
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

----===============================================================================================
----=========== SE AGREGO EL CAMPO DE LINE Y WBS EN PROJECT ORDER =================================
----===============================================================================================
--alter table ProjectOrder
--add Line varchar(10),WBS varchar(10)
--go

--update projectOrder set Line = '' , WBS= ''
--go

----===============================================================================================
----=========== SE CAMBIARON LOS VALORES DE DAYS Y NIGTH POR DAY Y NIGTH ==========================
----===============================================================================================

--update hoursWorked set schedule='Day' where schedule = 'DAYS'
--update hoursWorked set schedule='Night' where schedule = 'DAYS'
--GO

----===============================================================================================
----=========== SE AGREGARON LOS VALLORES DE CATEGORY, PAYITEMTYPE, WORKTYPE, =====================
----=========== COSTCODE, CUSTOMEPOSITIONID, CUSTOMERJOBPOSITIONDESCRIOPTION, =====================
----=========== Y CBSFULLNUMBER EN LA TABLA DE WORKORDER ==========================================
----===============================================================================================

--alter table workCode 
--add Category varchar(12),PayItemType varchar(20), WorkType varchar(20),
--	CostCode varchar(20),CustomerPositionID varchar(5), CustomerJobPositionDescription varchar(15),
--	CBSFullNumber varchar(11)
--go

--update workCode set Category = '',PayItemType = '', WorkType = '',
--CostCode = '',CustomerPositionID = '',CustomerJobPositionDescription='',
--CBSFullNumber = ''
--GO

--alter table clients 
--drop column postingProject
--go

--alter table job
--add postingProject bigint
--go

--update job set postingProject = 0 
--go

--ALTER proc [dbo].[sp_Update_Client]
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
--	@postalcode int,
--	@img image,
--	@payTerms varchar(30)
--as
--declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
--begin 
--	begin tran 
--		begin try
--			--se inserta un contacto

--				update contact set phoneNumber1= @phoneNumer1 , phoneNumber2=@phoneNumer2 ,email = @email where idContact = @idContact
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
--				update HomeAddress set avenue= @avenue, number = @number , city=@city , providence =@providence, postalCode = @postalcode where idHomeAdress = @idAddres
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
--				update  clients set firstName= @FirstName,middleName= @MiddleName,lastName= @LastName ,companyName=@CompanyName,estatus = @Status, photo = @img ,payTerms = @payTerms where idClient = @idCL
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

--ALTER proc [dbo].[sp_Insert_Cient] 
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
--	@postalcode int,
--	--Photo
--	@img image,
--	@payTerms varchar(30)
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
--				insert into clients values (@idClient , @ClientID, @FirstName, @MiddleName, @LastName , @CompanyName, @idContact , @idHomeAdress ,@Status,@img,@payTerms)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 

--				insert into TrackDefaultElements values(NEWID(),@idClient,'','','','','','','','','','','','','','','','','','','','','','','','','','','','')
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end
				
--				insert into TrackFormatColums values(NEWID(),@idClient,'Record ID1','Force or Reject1','Source1','Date1','Order Type1','Location ID1','Company Code1','Resource ID1','Resource Name1','Area1','Group Name1','Agreement1','Skill Type1','Shift1','Level 1 ID1','Level 2 ID1','Level 3 ID1','Level 4 ID1','Hours Total1','Hours Total Activity Code1','S/T (Hrs)1','S/T Hrs Activity Code1','O/T (Hrs)1','O/T Hrs Activity Code1','D/T (Hrs)1','D/T Hrs Activity Code1','Extra Charges $1','Extra Charges $ Activity Code1','Extra1','Extra 11','Extra 21','Add Time1','Pay Type1','R4 (Hrs)1','R5 (Hrs)1','R6 (Hrs)1','GL Account1','ST Adders1','OT Adders1','DT Adders1','R4 Adders1','R5 Adders1','R6 Adders1')
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
--GO

----###############################################################################################
----########### CAMBIO PARA CORREGIR EL PEDIEM EN LOS REPORTES ####################################
----###############################################################################################

--ALTER proc [dbo].[Sp_By_JobNumber]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int,
--@job as bigint,
--@all as bit
--as
--begin
--select distinct
--T1.[jobNo],
--T1.[idPO],
--T1.[idWO],
--T1.[task],
--T1.[SAPNumber],
--T1.[numberEmploye],
--T1.[DAY],
--T1.[Employee Name],
--T1.[dateWorked],
--T1.[Code],
--SUM(T1.[Hours ST])     OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Hours ST',
--T1.[billingRate1],
--SUM(T1.[Hours OT])     OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Hours OT',
--T1.[billingRateOT],
--SUM(T1.[PerDiem])      OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'PerDiem',
--SUM(T1.[Travel])       OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Travel'
--from(
--select jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',
	
--	hw.hoursST
--	as 'Hours ST',
		
--	ISNULL(wc.billingRate1,0)as 'billingRate1',

--	hw.hoursOT
--	as 'Hours OT',

--	ISNULL(wc.billingRateOT,0) as 'billingRateOT',
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem',
	
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate 
--			and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux	and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
--from hoursWorked as hw 
--inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--inner join employees as em on em.idEmployee = hw.idEmployee
--inner join task as tk on tk.idAux = hw.idAux 
--inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--inner join job as jb on jb.jobNo = po.jobNo 
--inner join clients as cl on cl.idClient = jb.idClient
--where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,'')) and not wc.name like '%6.4%' 
--)as T1 order by T1.dateWorked asc
--end
--go 

----###############################################################################################
----########### CAMBIOS PARA CORREGIR TRACK Y WORKCODES CON SKILLTYPE #############################
----###############################################################################################

--alter table workCode 
--add skillType varchar(100)
--go
--Update workCode set [skillType] = '' 
--go


--alter table TrackDefaultElements
--add [Level 2 ID] varchar(15)
--go
--update TrackDefaultElements set [Level 2 ID] = '' 
--go

----###############################################################################################
----########### CAMBIOS PARA CORREGIR LOS REPORTES DE ALL JOBS Y BY JOB NUM #######################
----###############################################################################################

--ALTER proc [dbo].[Sp_All_Jobs]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int
--as
--begin
--select distinct
--T1.[jobNo],
--T1.[idPO],
--T1.[idWO],
--T1.[task],
--T1.[SAPNumber],
--T1.[numberEmploye],
--T1.[DAY],
--T1.[Employee Name],
--T1.[dateWorked],
--T1.[Code],
--SUM(T1.[Hours ST])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Hours ST',
--T1.[billingRate1],
--SUM(T1.[Hours OT])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Hours OT',
--T1.[billingRateOT],
--SUM(T1.[PerDiem])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'PerDiem',
--SUM(T1.[Travel])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Travel'
--from(
--select
--	jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',

--	hw.hoursST as 'Hours ST',
	
--	ISNULL(wc.billingRate1,0)AS 'billingRate1',

--	hw.hoursOT as 'Hours OT',
	
--	ISNULL(wc.billingRateOT,0)as 'billingRateOT',


--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked and hw1.idAux = exu1.idAux
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem' ,
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked and hw1.idAux = exu1.idAux
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
	
--	from hoursWorked as hw 
--		left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--		inner join employees as em on em.idEmployee = hw.idEmployee
--		inner join task as tk on tk.idAux = hw.idAux 
--		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--		inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--		inner join job as jb on jb.jobNo = po.jobNo 
--		inner join clients as cl on cl.idClient = jb.idClient
--		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and not wc.name like '%6.4%' and hw.idWorkCode = NULL

--		UNION 

--	select
--	jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	'' as 'Code',
--	hw.hoursST as 'Hours ST',
	
--	ISNULL(wc.billingRate1,0)AS 'billingRate1',

--	hw.hoursOT as 'Hours OT',
	
--	ISNULL(wc.billingRateOT,0)as 'billingRateOT',


--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked and hw1.idAux = exu1.idAux
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem' ,
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked and hw1.idAux = exu1.idAux
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
--	from hoursWorked as hw 
--	left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--	inner join employees as em on em.idEmployee = hw.idEmployee
--	inner join task as tk on tk.idAux = hw.idAux 
--	inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--	inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
--	inner join job as jb on jb.jobNo = po.jobNo 
--	inner join clients as cl on cl.idClient = jb.idClient
--	where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and (hw.hoursST + hw.hoursOT + hw.hours3) = 0 

--)as T1
--end
--GO

--ALTER proc [dbo].[Sp_By_JobNumber]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int,
--@job as bigint,
--@all as bit
--as
--begin
--select distinct
--T1.[jobNo],
--T1.[idPO],
--T1.[idWO],
--T1.[task],
--T1.[SAPNumber],
--T1.[numberEmploye],
--T1.[DAY],
--T1.[Employee Name],
--T1.[dateWorked],
--T1.[Code],
--SUM(T1.[Hours ST])     OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Hours ST',
--T1.[billingRate1],
--SUM(T1.[Hours OT])     OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Hours OT',
--T1.[billingRateOT],
--SUM(T1.[PerDiem])      OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'PerDiem',
--SUM(T1.[Travel])       OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Travel'
--from(
--select jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',
	
--	hw.hoursST
--	as 'Hours ST',
		
--	ISNULL(wc.billingRate1,0)as 'billingRate1',

--	hw.hoursOT
--	as 'Hours OT',

--	ISNULL(wc.billingRateOT,0) as 'billingRateOT',
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo and hw1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem',
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate 
--			and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux	and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
--from hoursWorked as hw 
--left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--inner join employees as em on em.idEmployee = hw.idEmployee
--inner join task as tk on tk.idAux = hw.idAux 
--inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo and hw.jobNo = po.jobNo
--inner join job as jb on jb.jobNo = po.jobNo 
--inner join clients as cl on cl.idClient = jb.idClient
--where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,'')) and not wc.name like '%6.4%' 

--UNION 

--select jb.jobNo,
--	po.idPO,
--	wo.idWO,
--	tk.task,
--	em.SAPNumber,
--	em.numberEmploye, 
--	datename(dw,hw.dateWorked) as 'DAY',
--	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
--	hw.dateWorked,
--	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',
	
--	hw.hoursST
--	as 'Hours ST',
		
--	ISNULL(wc.billingRate1,0)as 'billingRate1',

--	hw.hoursOT
--	as 'Hours OT',

--	ISNULL(wc.billingRateOT,0) as 'billingRateOT',
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo and hw1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem',
--	isnull((select sum(amount) from expensesUsed as exu1 
--		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
--		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
--		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
--		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
--		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
--		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
--		inner join job as jb1 on jb1.jobNo = po1.jobNo 
--		inner join clients as cl1 on cl1.idClient = jb1.idClient
--		where hw1.dateWorked between @startdate and @finaldate 
--			and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux	and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
--from hoursWorked as hw 
--left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
--inner join employees as em on em.idEmployee = hw.idEmployee
--inner join task as tk on tk.idAux = hw.idAux 
--inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo and hw.jobNo = po.jobNo
--inner join job as jb on jb.jobNo = po.jobNo 
--inner join clients as cl on cl.idClient = jb.idClient
--where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,'')) and (hw.hoursST + hw.hoursOT + hw.hours3 )= 0 

--)as T1 order by T1.dateWorked asc
--end
--GO

----###############################################################################################
----########### CAMBIOS PARA CORREGIR LOS REPORTES DE CLIENT BILLING RE CAP BY PROJECT ############
----########### Y PUEDA BUSCAR USANDO EL PROJECT ORDER ############################################
----###############################################################################################

--ALTER proc [dbo].[Client_Billings_Re_Cap_By_Project]
--@startdate as date, 
--@finaldate as date,
--@clientnum as int,
--@job as bigint,
--@idPO as bigint,
--@allJob as bit,
--@allPO as bit
--as 
--begin

--set @startdate = ISNULL(@startDate,GETDATE())
--set @finaldate = ISNULL(@finaldate,GETDATE())
--set @clientnum = ISNULL(@clientnum,(select top 1 numberClient from clients)) 

--select T2.companyName,T2.[Work Order],T2.jobNo,T2.PO,T2.[Project Desription],
--T2.[Hours Ext],T2.[Total Hours],T2.[Hours ST],T2.[Billings ST],T2.[Hours OT],T2.[Billings OT],
--T2.Complete,T2.[Es-Hrs],T2.[Total Expenses],T2.[Total Material],T2.[Total Spend],T2.Estimate from
--(
--	select cl.companyName,concat(wo.idWO,' ',ts.task) as 'Work Order', jb.jobNo,po.idPO as 'PO',ts.description as 'Project Desription',
    	
--	ISNULL((select T1.EX from  (select sum(hours3) as 'EX' from hoursWorked as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) ,0) as 'Hours Ext',

--	(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1)+
--	(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Total Hours',

--	(select isnull(T1.ST,0.0) from  (select sum(hoursST) as 'ST' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours ST',
	
--	(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
--		(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount' from 
--			(select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--				where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate
--			)as T1    
--		group by T1.idWorkCode
--		)as T2
--	) as 'Billings ST',

--	(select isnull(T1.OT,0.0) from  (select sum(hoursOT) as 'OT' from hoursWorked  as hw1 inner join task as tk1 on tk1.idAux = hw1.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and tk1.idAux = ts.idAux and dateWorked between @startdate and @finaldate) as T1) as 'Hours OT',
	
--	(select ISNULL( SUM(T2.Amount),0) as 'Billings OT' from 
--		(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount' from 
--			(select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--				where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate
--			)as T1    
--		group by T1.idWorkCode
--		)as T2
--	) as 'Billings OT',

--	ts.percentComplete as 'Complete',

--	ts.estimateHours as 'Es-Hrs',

--	ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--	where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0) as 'Total Expenses',
	
--	ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--			where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0) as 'Total Material',
	
--	(
		
--			(select ISNULL(SUM(T2.Amount),0) as 'Billings ST' from 
--			(select SUM(T1.hoursST*T1.billingRate1) AS 'Amount'
--			from (select hoursST, hw.idWorkCode , billingRate1  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--			where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
--			group by T1.idWorkCode) as T2)--Billing ST
--			+
--			(select  ISNULL( SUM(T2.Amount),0) as 'Billing OT' from 
--			(select SUM(T1.hoursOT*T1.billingRateOT) AS 'Amount'
--			from (select hoursOT, hw.idWorkCode , billingRateOT  from hoursWorked as hw inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo inner join task as tk1 on tk1.idAux = hw.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo  
--			where jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and hw.idAux=ts.idAux  and dateWorked between @startdate and @finaldate)as T1    
--			group by T1.idWorkCode) as T2) --Billing OT
--			+
--			ISNULL((select sum(amount) from expensesUsed as exu inner join task as tk1 on tk1.idAux = exu.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--			where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and exu.idAux=ts.idAux and exu.dateExpense between @startdate and @finaldate),  0)--Expenses Used
--			+
--			ISNULL((select sum(amount) from materialUsed as mau inner join task as tk1 on tk1.idAux = mau.idAux inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo inner join job as jb1 on jb1.jobNo = po1.jobNo
--			where  jb.jobNo = jb1.jobNo and po1.idPO = po.idPO and wo.idAuxWO = wo1.idAuxWO and mau.idAux=ts.idAux and mau.dateMaterial between @startdate and @finaldate), 0)-- Material Used
--			)
--		 as 'Total Spend',

--	ts.estTotalBilling as 'Estimate'
--	from task as ts
--	inner join workOrder as wo on wo.idAuxWO=ts.idAuxWO
--	inner join projectOrder as po on po.idPO=wo.idPO and po.jobNo = wo.jobNo
--	inner join job as jb on jb.jobNo=po.jobNo
--	inner join clients cl on cl.idClient=jb.idClient
--	where cl.numberClient=@clientnum and ((select sum(hoursST) from hoursWorked where idAux = ts.idAux)> 0 or (select sum(hoursOT)
--		 from hoursWorked where idAux = ts.idAux)> 0 or (select sum(hours3)
--		 from hoursWorked where idAux = ts.idAux)> 0 or (select sum(amount) 
--		 from expensesUsed where idAux=ts.idAux)> 0 or (select sum(amount)
--		 from materialUsed where idAux=ts.idAux)>0)
--		 and jb.jobNo like iif(@allJob=1,'%%',CONCAT('',@job,''))
--		 and po.jobNo like iif(@allPO = 1 ,'%%',CONCAT('',@idPO,''))
--		)as T2
--		where T2.[Billings ST]<>0 OR T2.[Billings OT]<>0 OR T2.[Total Expenses]<>0 OR T2.[Total Material]<>0
--		order by t2.jobNo asc
--end
--GO
------###############################################################################################
------########### CAMBIOS PARA CORREGIR EL REPORTE DE PRODUCTOS EN EL REPORTE DE MATERIAL ###########
------########### INVENTORY Y SFFOLD TRAKING (TAB:PRODUCTS) #########################################
------###############################################################################################

--ALTER proc [dbo].[sp_SCF_Material_Inventory]
--@numberClient as int,
--@all as bit
--as
--begin
--select 
--jb.jobNo,
--pd.QID,
--pd.idProduct ,
--pd.name ,
--ISNULL((select sum(pinc.quantity) from productComing as pinc 
--inner join incoming as inc on inc.ticketNum = pinc.ticketNum
--where inc.jobNo = jb.jobNo and pinc.idProduct = pj.idProduct),0) as 'Incoming', 

--ISNULL((select sum(pout.quantity) from productOutGoing as pout 
--inner join outgoing as outg on outg.ticketNum = outg.ticketNum
--where outg.jobNo = jb.jobNo and pout.idProduct = pj.idProduct),0) as 'Outgoing',

--ISNULL((select sum(pinc.quantity) from productComing as pinc 
--inner join incoming as inc on inc.ticketNum = pinc.ticketNum
--where inc.jobNo = jb.jobNo and pinc.idProduct = pj.idProduct),0)
---
--ISNULL((select sum(pout.quantity) from productOutGoing as pout 
--inner join outgoing as outg on outg.ticketNum = outg.ticketNum
--where outg.jobNo = jb.jobNo and pout.idProduct = pj.idProduct),0)as 'Inventory',
----ISNULL(pj.qty,0) as 'Inventory',
--ISNULL((select sum(pts.quantity) from productTotalScaffold as pts
--inner join scaffoldTraking as sc on sc.tag = pts.tag
--inner join task as tk on tk.idAux = sc.idAux 
--inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
--inner join job as jb1 on jb1.jobNo = po.jobNo
--where jb1.jobNo = jb.jobNo and pts.idProduct = pj.idProduct),0) as 'OnRent',

--(ISNULL((select sum(pinc.quantity) from productComing as pinc 
--inner join incoming as inc on inc.ticketNum = pinc.ticketNum
--where inc.jobNo = jb.jobNo and pinc.idProduct = pj.idProduct),0)
---
--ISNULL((select sum(pout.quantity) from productOutGoing as pout 
--inner join outgoing as outg on outg.ticketNum = outg.ticketNum
--where outg.jobNo = jb.jobNo and pout.idProduct = pj.idProduct),0))
---
--ISNULL((select sum(pts.quantity) from productTotalScaffold as pts
--inner join scaffoldTraking as sc on sc.tag = pts.tag
--inner join task as tk on tk.idAux = sc.idAux 
--inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
--inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
--inner join job as jb1 on jb1.jobNo = po.jobNo
--where jb1.jobNo = jb.jobNo and pts.idProduct = pj.idProduct),0) as 'InYard',
----ISNULL(pd.quantity,0) as 'InYard'
--pd.[weight] as 'Weight'

--from  productJob as pj  
--inner join product as pd on pd.idProduct = pj.idProduct 
--left join job as jb on jb.jobNo = pj.jobNo
--inner join clients as cl on cl.idClient = jb.idClient 
--where cl.numberClient like iif(@all = 1, '%%', concat('%',@numberClient,'%'))
--ORDER BY pd.idProduct
--end
--go

----###############################################################################################
----########### CAMBIOS PARA CORREGIR EL SAP NUMBER DE LOS EMPLEADOS ##############################
----###############################################################################################

--alter table employees alter column SAPNumber varchar(13)
--go

--ALTER proc [dbo].[sp_insert_Employee]
--	--general
--	@numberEmploye int, 
--	@firstName varchar(30),
--	@lastName varchar(25),
--	@middleName varchar(25),
--	@socialNumber varchar(14),
--	@SAPNumber varchar(13),
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
--	@payRate3 float,
--	--type 
--	@type varchar(20),
--	--perdiem
--	@perdiem bit
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
--			--if @firstName <> '' or @numberEmploye > 0 begin	
--				set @idEmployee = NEWID()
--				insert into employees values (@idEmployee , @numberEmploye , @firstName , @lastName , @middleName, @socialNumber , @SAPNumber, @photo , @idHomeAdress , @idContact ,@estatus,@type,@perdiem)
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			--end
--			--if @payRate1 <> '' begin
--				set @idPayRate = NEWID()
--				insert into payRate values (@idPayRate,@payRate1,@payRate2 ,@payRate3,@idEmployee,GETDATE())
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


--ALTER proc [dbo].[sp_update_Employee]
--	@idEmployee varchar(36),
--	@idAddress varchar(36),
--	@idContact varchar(36),
--	--general
--	@numberEmploye int, 
--	@firstName varchar(30),
--	@lastName varchar(25),
--	@middleName varchar(25),
--	@socialNumber varchar(14),
--	@SAPNumber varchar(13),
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
--	----pay
--	--@payRate1 float,
--	--@payRate2 float, 
--	--@payRate3 float,
--	--type 
--	@type varchar(20),
--	@perdiem bit,
--	@msg varchar(50) output
--as 
--declare @error int  -- declaro variables para los ID que son nuevos y una variable de error
--begin
--	begin tran --inicio tran
--		begin try --inicio try
--			--if @avenue <> '' begin -- solo se necesita saber si la calle tiene algo 
--				set @msg = 'Error at moment to save Address data'
--				update HomeAddress set avenue = @avenue ,number =@number ,city =@city ,providence =@providence ,postalcode = @postalCode where idHomeAdress = @idAddress
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
				
--				set @msg = 'Error at moment to save Contact data'
--				update contact set phoneNumber1 =@phoneNumber1 , phoneNumber2 =@phoneNumber2 , email = @email where idContact = @idContact
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			--end
--			----if @payRate1 <> '' begin
--			--	set @msg = 'Error at moment to save Pay Rate data'
--			--	update payRate set payRate1 = @payRate1,payRate2= @payRate2 , payRate3 = @payRate3 where idPayRate = @idPay and idEmployee = @idEmployee
--			--	if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			----end
--			--if @firstName <> '' or @numberEmploye > 0 begin
--				set @msg = 'Error at moment to save Employee data'	
--				update employees set  numberEmploye = @numberEmploye ,firstName = @firstName , lastName = @lastName ,middleName = @middleName,socialNumber = @socialNumber ,SAPNumber = @SAPNumber,photo = @photo , estatus = @estatus,typeEmployee = @type, perdiem = @perdiem where idEmployee = @idEmployee
--				if @@ERROR <> 0 begin set @error = @@ERROR goto solveproblem end 
--			--end
--			set @msg = 'Succesfull'
--		end try	
--		begin catch
--			goto solveproblem -- en caso de error capturado en el catch no vamos a solveproblem y evitamos en commit
--		end catch
--	commit tran 
--	solveproblem:
--	if @error <> 0
--	begin 
--		rollback tran -- el rollback es para deshacer todos lo cambios hechos anteriormente
--		return @msg
--	end
--end
--go
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----| | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | | |
----V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V V
----###############################################################################################
----########### CAMBIOS PARA REPORTES CON REOCRODS EN CEROS #######################################
----###############################################################################################

ALTER proc [dbo].[Sp_All_Jobs]
@startdate as date, 
@finaldate as date,
@clientnum as int
as
begin
select distinct
T1.[jobNo],
T1.[idPO],
T1.[idWO],
T1.[task],
T1.[SAPNumber],
T1.[numberEmploye],
T1.[DAY],
T1.[Employee Name],
T1.[dateWorked],
T1.[Code],
SUM(T1.[Hours ST])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Hours ST',
T1.[billingRate1],
SUM(T1.[Hours OT])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Hours OT',
T1.[billingRateOT],
SUM(T1.[PerDiem])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'PerDiem',
SUM(T1.[Travel])OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[numberEmploye],T1.[DAY],T1.[Code],T1.[dateWorked]) as 'Travel'
from(
select
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

	hw.hoursST as 'Hours ST',
	
	ISNULL(wc.billingRate1,0)AS 'billingRate1',

	hw.hoursOT as 'Hours OT',
	
	ISNULL(wc.billingRateOT,0)as 'billingRateOT',


	isnull((select sum(amount) from expensesUsed as exu1 
		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked and hw1.idAux = exu1.idAux
		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
		inner join job as jb1 on jb1.jobNo = po1.jobNo 
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem' ,
	isnull((select sum(amount) from expensesUsed as exu1 
		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked and hw1.idAux = exu1.idAux
		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
		inner join job as jb1 on jb1.jobNo = po1.jobNo 
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
	
	from hoursWorked as hw 
		left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
		inner join employees as em on em.idEmployee = hw.idEmployee
		inner join task as tk on tk.idAux = hw.idAux 
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and not wc.name like '%6.4%' 

		UNION ALL

	select
	jb.jobNo,
	po.idPO,
	wo.idWO,
	tk.task,
	em.SAPNumber,
	em.numberEmploye, 
	datename(dw,hw.dateWorked) as 'DAY',
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
	hw.dateWorked,
	'' as 'Code',
	hw.hoursST as 'Hours ST',
	
	ISNULL(wc.billingRate1,0)AS 'billingRate1',

	hw.hoursOT as 'Hours OT',
	
	ISNULL(wc.billingRateOT,0)as 'billingRateOT',


	isnull((select sum(amount) from expensesUsed as exu1 
		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked and hw1.idAux = exu1.idAux
		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
		inner join job as jb1 on jb1.jobNo = po1.jobNo 
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem' ,
	isnull((select sum(amount) from expensesUsed as exu1 
		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked and hw1.idAux = exu1.idAux
		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
		inner join job as jb1 on jb1.jobNo = po1.jobNo 
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
	from hoursWorked as hw 
	left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
	inner join employees as em on em.idEmployee = hw.idEmployee
	inner join task as tk on tk.idAux = hw.idAux 
	inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
	inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
	inner join job as jb on jb.jobNo = po.jobNo 
	inner join clients as cl on cl.idClient = jb.idClient
	where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and (hw.hoursST + hw.hoursOT + hw.hours3) = 0 

)as T1 where (T1.billingRate1 + T1.billingRateOT + T1.PerDiem + T1.Travel) > 0 
end
GO

ALTER proc [dbo].[Sp_By_JobNumber]
@startdate as date, 
@finaldate as date,
@clientnum as int,
@job as bigint,
@all as bit
as
begin
select distinct
T1.[jobNo],
T1.[idPO],
T1.[idWO],
T1.[task],
T1.[SAPNumber],
T1.[numberEmploye],
T1.[DAY],
T1.[Employee Name],
T1.[dateWorked],
T1.[Code],
SUM(T1.[Hours ST])     OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Hours ST',
T1.[billingRate1],
SUM(T1.[Hours OT])     OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Hours OT',
T1.[billingRateOT],
SUM(T1.[PerDiem])      OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'PerDiem',
SUM(T1.[Travel])       OVER (PARTITION BY T1.[jobNo],T1.[idPO],T1.[idWO],T1.[task],T1.[dateWorked],T1.[numberEmploye],T1.[DAY],T1.[Code]) AS 'Travel'
from(
select jb.jobNo,
	po.idPO,
	wo.idWO,
	tk.task,
	em.SAPNumber,
	em.numberEmploye, 
	datename(dw,hw.dateWorked) as 'DAY',
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
	hw.dateWorked,
	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',
	
	hw.hoursST
	as 'Hours ST',
		
	ISNULL(wc.billingRate1,0)as 'billingRate1',

	hw.hoursOT
	as 'Hours OT',

	ISNULL(wc.billingRateOT,0) as 'billingRateOT',
	isnull((select sum(amount) from expensesUsed as exu1 
		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo and hw1.jobNo = po1.jobNo 
		inner join job as jb1 on jb1.jobNo = po1.jobNo 
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem',
	isnull((select sum(amount) from expensesUsed as exu1 
		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
		inner join job as jb1 on jb1.jobNo = po1.jobNo 
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where hw1.dateWorked between @startdate and @finaldate 
			and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux	and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
from hoursWorked as hw 
left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
inner join employees as em on em.idEmployee = hw.idEmployee
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo and hw.jobNo = po.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,'')) and not wc.name like '%6.4%' 

UNION ALL

select jb.jobNo,
	po.idPO,
	wo.idWO,
	tk.task,
	em.SAPNumber,
	em.numberEmploye, 
	datename(dw,hw.dateWorked) as 'DAY',
	concat(em.lastName,', ', em.firstName,' ' ,em.middleName) as 'Employee Name',
	hw.dateWorked,
	ISNULL(SUBSTRING( wc.name,1,iif(CHARINDEX('-',wc.name)=0, len(wc.name) ,(CHARINDEX('-',wc.name)-1))),'') as 'Code',
	
	hw.hoursST
	as 'Hours ST',
		
	ISNULL(wc.billingRate1,0)as 'billingRate1',

	hw.hoursOT
	as 'Hours OT',

	ISNULL(wc.billingRateOT,0) as 'billingRateOT',
	isnull((select sum(amount) from expensesUsed as exu1 
		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo and hw1.jobNo = po1.jobNo 
		inner join job as jb1 on jb1.jobNo = po1.jobNo 
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where hw1.dateWorked between @startdate and @finaldate and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%per-diem%' or ex1.expenseCode like '%per diem%')),0) as 'PerDiem',
	isnull((select sum(amount) from expensesUsed as exu1 
		inner join employees as em1 on em1.idEmployee = exu1.idEmployee
		inner join expenses as ex1 on ex1.idExpenses= exu1.idExpense 
		inner join hoursWorked as hw1 on hw1.idHorsWorked  = exu1.idHorsWorked 
		inner join task as tk1 on tk1.idAux = exu1.idAux and tk1.idAux = hw1.idAux
		inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
		inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo 
		inner join job as jb1 on jb1.jobNo = po1.jobNo 
		inner join clients as cl1 on cl1.idClient = jb1.idClient
		where hw1.dateWorked between @startdate and @finaldate 
			and hw1.idHorsWorked = hw.idHorsWorked and tk1.idAux = tk.idAux	and wo.idAuxWO = wo.idAuxWO and po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and (ex1.expenseCode like '%Travel%')),0) as 'Travel'
from hoursWorked as hw 
left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = hw.jobNo
inner join employees as em on em.idEmployee = hw.idEmployee
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo and hw.jobNo = po.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join clients as cl on cl.idClient = jb.idClient
where hw.dateWorked between @startdate and @finaldate and cl.numberClient = @clientnum and jb.jobNo like iif(@all=1,'%%',CONCAT('',@job,'')) and (hw.hoursST + hw.hoursOT + hw.hours3)= 0 

)as T1 where (T1.[Hours OT] + T1.[billingRate1] + T1.[PerDiem] + T1.[Travel]) >0 
 order by T1.dateWorked asc
end
GO
