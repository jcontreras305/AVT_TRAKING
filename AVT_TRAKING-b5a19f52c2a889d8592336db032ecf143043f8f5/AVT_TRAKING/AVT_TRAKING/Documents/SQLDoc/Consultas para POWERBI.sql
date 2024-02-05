use vrt_traking
go
IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'PBI')
BEGIN
	PRINT 'THE SCHEMA PBI NOT EXIST.'
	EXEC ('CREATE SCHEMA PBI;');
	PRINT 'THE SCHEMA WAS CREATED.'
END
ELSE
BEGIN 
	PRINT 'THE SCHAME PBI EXIST'
END

declare @StartDate as date = '2022-01-01'
declare @EndDate as date = '2022-12-31'
--==============================================================================================================================================
--====== ALL ===================================================================================================================================
--==============================================================================================================================================


IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALL')
BEGIN 
	drop table PBI.[ALL]
END
select 
	T2.[Year],T2.[ClientID],T2.[PO],T2.[MO#],T2.[ProjectDescription],T2.[ST],T2.[OT],T2.[Billing ST],T2.[Billing OT],T2.[Expenses],T2.[Total Material],
	(T2.[Billing ST]+T2.[Billing OT]+T2.[Expenses]+T2.[Total Material]) as 'PO Spent',
	(((T2.[Billing ST]+T2.[Billing OT]+T2.[Expenses]+T2.[Total Material])*100)/IIF(T2.[ProjectTotalBillingEstimate]=0,1,T2.[ProjectTotalBillingEstimate])) as 'PO%Spent',
	T2.[ProjectTotalBillingEstimate]-(T2.[Billing ST]+T2.[Billing OT]+T2.[Expenses]+T2.[Total Material]) as 'PO Left',
	T2.[Comp],T2.[ProjectTotalBillingEstimate]
	INTO PBI.[ALL]
from(
	select 
	DISTINCT
	T1.[Year],T1.[ClientID],T1.[PO],T1.[MO#],T1.[ProjectDescription],
	SUM(T1.[ST]) OVER (PARTITION BY T1.[MO#],T1.[PO],T1.[ClientID],T1.[Year],T1.[ProjectDescription]) as 'ST',
	SUM(T1.[OT]) OVER (PARTITION BY T1.[MO#],T1.[PO],T1.[ClientID],T1.[Year],T1.[ProjectDescription]) as 'OT',
	SUM(T1.[Billing ST]) OVER (PARTITION BY T1.[MO#],T1.[PO],T1.[ClientID],T1.[Year],T1.[ProjectDescription]) as 'Billing ST',
	SUM(T1.[Billing OT]) OVER (PARTITION BY T1.[MO#],T1.[PO],T1.[ClientID],T1.[Year],T1.[ProjectDescription]) as 'Billing OT',
	SUM(T1.[Expenses]) OVER (PARTITION BY T1.[MO#],T1.[PO],T1.[ClientID],T1.[Year],T1.[ProjectDescription]) as 'Expenses',
	SUM(T1.[Total Material]) OVER (PARTITION BY T1.[MO#],T1.[PO],T1.[ClientID],T1.[Year],T1.[ProjectDescription]) as 'Total Material',
	T1.[Comp],
	T1.[ProjectTotalBillingEstimate]
	from(
		select 
		DISTINCT
		YEAR(dateWorked) as 'Year', jb.jobNo as 'ClientID', po.idPO as 'PO', CONCAT(wo.idWO,IIF(tk.task ='' , '','-'),tk.task) as 'MO#',tk.[description] as 'ProjectDescription',
		SUM(hw.hoursST) OVER (PARTITION BY YEAR(dateWorked),jb.jobNo,po.idPO,CONCAT(wo.idWO,IIF(tk.task ='' , '','-'),tk.task),tk.[description]) as 'ST',
		SUM(hw.hoursOT+hw.hours3) OVER (PARTITION BY YEAR(dateWorked),jb.jobNo,po.idPO,CONCAT(wo.idWO,IIF(tk.task='','','-'),tk.task),tk.[description]) as 'OT',
		SUM(hw.hoursST * wc.billingRate1) OVER (PARTITION BY YEAR(dateWorked),jb.jobNo,po.idPO,CONCAT(wo.idWO,IIF(tk.task='','','-'),tk.task),tk.[description]) as 'Billing ST',
		SUM((hw.hoursOT * wc.billingRateOT + hw.hours3 * wc.billingRate3)) OVER (PARTITION BY YEAR(dateWorked),jb.jobNo,po.idPO,CONCAT(wo.idWO,IIF(tk.task='','','-'),tk.task),tk.[description]) as 'Billing OT',
		0 as 'Expenses',
		0 as 'Total Material',
		tk.[percentComplete] as 'Comp',
		tk.estTotalBilling as 'ProjectTotalBillingEstimate'
		from hoursWorked as hw 
		inner join workCode as wc on wc.idWorkCode = hw.idWorkCode 
		inner join task as tk on tk.idAux = hw.idAux 
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where hw.dateWorked between @StartDate and @EndDate
		UNION ALL
		select
		DISTINCT
		YEAR(exu.dateExpense) as 'Year', jb.jobNo as 'ClientID', po.idPO as 'PO', CONCAT(wo.idWO,IIF(tk.task='','','-'),tk.task)as 'MO#',tk.[description] as 'ProjectDescrioption',
		0 as 'ST',
		0 as 'OT',
		0 as 'Billing ST',
		0 as 'Billing OT',
		SUM(exu.amount) OVER (PARTITION BY tk.idAux,wo.idWO,po.idPO,jb.jobNo) as 'Expenses',
		0 as 'Total Material',
		tk.[percentComplete] as 'Complete',
		tk.estTotalBilling as 'ProjectTotalBillingEstimate'
		from expensesUsed as exu
		inner join expenses as ex on ex.idExpenses = exu.idExpense
		inner join task as tk on tk.idAux = exu.idAux 
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		where exu.dateExpense between @StartDate and @EndDate
		UNION ALL
		select 
		DISTINCT
		YEAR(mau.dateMaterial) as 'Year', jb.jobNo as 'ClientID', po.idPO as 'PO', CONCAT(wo.idWO,IIF(tk.task='','','-'),tk.task)as 'MO#',tk.[description] as 'ProjectDescrioption',
		0 as 'ST',
		0 as 'OT',
		0 as 'Billing ST',
		0 as 'Billing OT',
		0 as 'Expenses',
		SUM(mau.amount) OVER (PARTITION BY tk.idAux,wo.idWO,po.idPO,jb.jobNo) as 'Total Material',
		tk.[percentComplete] as 'Complete',
		tk.estTotalBilling as 'ProjectTotalBillingEstimate'
		from materialUsed as mau
		inner join material as ma on ma.idMaterial = mau.idMaterial 
		inner join task as tk on tk.idAux = mau.idAux 
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as  cl on cl.idClient = jb.idClient
		where mau.dateMaterial between @StartDate and @EndDate
	)as T1 WHERE t1.[Billing ST] > 0 or t1.[Billing OT]>0 or t1.Expenses> 0 or t1.[Total Material]>0
)as T2

--==============================================================================================================================================
--====== ALL BARRIERS ==========================================================================================================================
--==============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLBarriers')
BEGIN 
	drop table PBI.[ALLBarriers]
END

select T1.[Year],T1.[ClientID],T1.[Month],T1.[MonthN],T1.[name] AS 'CLASS',T1.[ST Hours],T1.[OT Hours], T1.[ST Hours] + T1.[OT Hours] AS 'TotalHours', T1.[ST Cost],T1.[OT Cost]
into PBI.ALLBarriers
from (
select 
distinct
YEAR(hw.dateWorked) as 'Year',
jb.jobNo as 'ClientID', MONTH(hw.dateWorked) as 'Month' , DATENAME(MONTH,hw.dateWorked) as 'MonthN',wc.name , 
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'ST Hours',
SUM(hw.hoursOT+ hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'OT Hours',
SUM(hw.hoursST*wc.billingRate1) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'ST Cost',
SUM((hw.hoursOT*wc.billingRateOT) + (hw.hours3*wc.billingRate3)) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'OT Cost'
from hoursWorked as hw 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
where wc.name like '%-%' and hw.dateWorked between @startDate and @EndDate and wc.name not like '%covid%') 
AS T1 ORDER BY T1.ClientID,T1.[Month] 

--==============================================================================================================================================
--====== ALL CPH 1 ==============================================================================================================================
--==============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLCPH1')
BEGIN 
	drop table PBI.[ALLCPH1]
END
----todos las hora de time sheet sin holidays
select 
T1.[Year],T1.[Month],T1.[MonthN],T1.[ST Hours],T1.[OT Hours],T1.[TotalHours],T1.[Cost],T1.[Cost]/IIF(T1.[TotalHours]=0,1,T1.[TotalHours]) as 'CostPH',T1.ClientID
INTO PBI.ALLCPH1
from(
select 
DISTINCT
YEAR(hw.dateWorked) as 'Year',MONTH(hw.dateWorked) as 'Month',DATENAME(MONTH,hw.dateWorked) as 'MonthN',
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'ST Hours',
SUM(hw.hoursOT+hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'OT Hours',
SUM(hw.hoursST + hw.hoursOT + hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'TotalHours',
ROUND(SUM(((hw.hoursST*wc.billingRate1) + (hw.hoursOT*wc.billingRateOT) + (hours3*wc.billingRate3))) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo),2) as 'Cost',
jb.jobNo as 'ClientID'

from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo
left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
where hw.dateWorked between @StartDate and @EndDate and wc.name not like '%6.4%' and wc.name not like '%covid%'
) as T1
--==============================================================================================================================================
--====== ALL CPH 2 =============================================================================================================================
--==============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLCPH2')
BEGIN 
	drop table PBI.[ALLCPH2]
END

select 
distinct
YEAR(kpi.dateWorked) as 'Year', MONTH(kpi.dateWorked) as 'Month',DATENAME(MONTH,kpi.dateWorked) as 'MonthN',
kpi.install as 'IT',
SUM(((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF])) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'II SQFT',
SUM((kpi.hoursST + kpi.hoursOT)) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'Hours',
SUM(((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF]) + kpi.SQF) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'Total SQF',
jb.jobNo AS 'ClientID',
SUM(ROUND((((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF]) + kpi.SQF) / (kpi.hoursST + kpi.hoursOT),2)) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'SQFPH'
INTO PBI.ALLCPH2
from KPI as kpi
inner join task as tk on tk.idAux = kpi.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where kpi.dateWorked between @StartDate and @EndDate and kpi.install not like 'Asbestos'

--==============================================================================================================================================
--====== ALL CPH 3 =============================================================================================================================
--==============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLCPH3')
BEGIN 
	drop table PBI.[ALLCPH3]
END
--todos las horas de time sheet sin supervisor y sin holidays 
select 
T1.[Year],T1.[Month],T1.[MonthN],T1.[ST Hours],T1.[OT Hours],T1.[TotalHours],T1.[Cost],T1.[Cost]/T1.[TotalHours] as 'CostPH',T1.[ClientID]
INTO PBI.ALLCPH3
from(
select 
DISTINCT
YEAR(hw.dateWorked) as 'Year',MONTH(hw.dateWorked) as 'Month',DATENAME(MONTH,hw.dateWorked) as 'MonthN',
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'ST Hours',
SUM(hw.hoursOT+hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'OT Hours',
SUM(hw.hoursST + hw.hoursOT + hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'TotalHours',
ROUND(SUM(((hw.hoursST*wc.billingRate1) + (hw.hoursOT*wc.billingRateOT) + (hours3*wc.billingRate3))) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo),2) as 'Cost',
jb.jobNo as 'ClientID'

from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo
left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
where hw.dateWorked between @StartDate and @EndDate and wc.name not like 'LM%' and wc.name not like '%6.4%' and wc.name not like '%covid%'
) as T1

--==============================================================================================================================================
--====== ALL HOURS1 =============================================================================================================================
--==============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLHours1')
BEGIN 
	drop table PBI.[ALLHours1]
END

select DISTINCT
T1.[Year],
T1.[ClientID],
T1.[Month],T1.[MonthN],
SUM((T1.[ST]+ T1.[OT])) OVER (PARTITION BY T1.[Month],T1.[ClientID]) AS 'TotalHours',
SUM(T1.[ST]) OVER (PARTITION BY T1.[Month],T1.[ClientID]) as 'ST',
SUM(T1.[OT]) OVER (PARTITION BY T1.[Month],T1.[ClientID]) as 'OT' 
into PBI.ALLHours1
from(
select 
distinct
YEAR(hw.dateWorked) as 'Year',jb.jobNo as 'ClientID', MONTH(hw.dateWorked) as 'Month' , DATENAME(MONTH,hw.dateWorked) as 'MonthN', 
SUM(hw.hoursST+hw.hoursOT+ hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'Total Hours',
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'ST',
SUM(hw.hoursOT+ hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'OT'
from hoursWorked as hw 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
where hw.dateWorked between @StartDate and @EndDate and wc.name not like '%6.4%' and wc.name like 'LM%'
) AS T1 

--==============================================================================================================================================
--====== ALL HOURS2 =============================================================================================================================
--==============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLHours2')
BEGIN 
	drop table PBI.[ALLHours2]
END

select DISTINCT
T1.[Year],
T1.[ClientID],
T1.[Month],T1.[MonthN],
SUM((T1.[ST] + T1.[OT])) OVER (PARTITION BY T1.[Month],T1.[ClientID]) AS 'TotalHours',
SUM(T1.[ST]) OVER (PARTITION BY T1.[Month],T1.[ClientID]) as 'ST',
SUM(T1.[OT]) OVER (PARTITION BY T1.[Month],T1.[ClientID]) as 'OT' 
into PBI.ALLHours2
from(
select 
distinct
YEAR(hw.dateWorked) as 'Year',jb.jobNo as 'ClientID', MONTH(hw.dateWorked) as 'Month' , DATENAME(MONTH,hw.dateWorked) as 'MonthN', 
SUM(hw.hoursST+hw.hoursOT+ hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'Total Hours',
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'ST',
SUM(hw.hoursOT+ hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'OT'
from hoursWorked as hw 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
where hw.dateWorked between @StartDate and @EndDate and wc.name not like '%6.4%' and wc.name not like '%covid%'
) AS T1 

--===============================================================================================================================================
--====== EMPLOYEES WITH AND WITHOUT PERDIEM =====================================================================================================
--===============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'EmpTravAndLocals')
BEGIN 
	drop table PBI.[EmpTravAndLocals]
END

select * 
into PBI.EmpTravAndLocals
from (
--travelers
select count(*) as 'Travelers',0 as 'Locals' FROM employees where perdiem = 1
union all
--locals
select 0 as 'Travelers',count(*) as 'Locals' FROM employees where perdiem = 0
) as T1

--===============================================================================================================================================
--====== ABSENTS ================================================================================================================================
--===============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'EmpAbsents')
BEGIN 
	drop table PBI.[EmpAbsents]
END

select YEAR(ab.dateAbsents) as'Year',DATENAME( MONTH,ab.dateAbsents) as 'Month',
SUM(ab.hoursPaid) OVER (PARTITION BY YEAR(ab.dateAbsents),MONTH(ab.dateAbsents)) as 'Hours',
SUM(ab.hoursPaid) OVER (PARTITION BY YEAR(ab.dateAbsents),MONTH(ab.dateAbsents))/8 as 'Days' ,
MONTH(ab.dateAbsents) as 'MonthN' 
into PBI.EmpAbsents
from absents as ab
where ab.dateAbsents between @StartDate and @EndDate
 

--===============================================================================================================================================
--====== COST HPTAS =============================================================================================================================
--===============================================================================================================================================
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'CostHPTAS')
BEGIN 
	drop table PBI.[CostHPTAS]
END

select DISTINCT
T1.[Year],
T1.[PO],
T1.[Weekly],
T1.[ClientID],
SUM(T1.[ST Hours]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'ST Hours',
SUM(T1.[OT Hours]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'OT Hours',
SUM(T1.[OT Cost]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'OT Cost',
SUM(T1.[ST Cost]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'ST Cost',
SUM(T1.[Total Exp]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'Total Exp',
SUM(T1.[Total Mat]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'Total Mat'
INTO PBI.CostHPTAS
from(

select 
distinct
YEAR(hw.dateWorked) as 'Year',
po.idPO	as 'PO',
DATEADD(DAY,IIF( DATEPART(DW,hw.dateWorked)=1,0, 7-(DATEPART(DW,hw.dateWorked)-1)),hw.dateWorked) as 'Weekly',
jb.jobNo as 'ClientID',
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),DATEADD(DAY,IIF( DATEPART(DW,hw.dateWorked)=1,0, 7-(DATEPART(DW,hw.dateWorked)-1)),hw.dateWorked),po.idPO,jb.jobNo) as 'ST Hours',
SUM(hw.hoursOT+ hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),DATEADD(DAY,IIF( DATEPART(DW,hw.dateWorked)=1,0, 7-(DATEPART(DW,hw.dateWorked)-1)),hw.dateWorked),po.idPO,jb.jobNo) as 'OT Hours',
ROUND(SUM((hw.hoursOT*wc.billingRateOT) + (hw.hours3*wc.billingRate3)) OVER (PARTITION BY YEAR(hw.dateWorked),DATEADD(DAY,IIF( DATEPART(DW,hw.dateWorked)=1,0, 7-(DATEPART(DW,hw.dateWorked)-1)),hw.dateWorked),po.idPO,jb.jobNo),2) 'OT Cost',
ROUND(SUM(hw.hoursST*wc.billingRate1) OVER (PARTITION BY YEAR(hw.dateWorked),DATEADD(DAY,IIF( DATEPART(DW,hw.dateWorked)=1,0, 7-(DATEPART(DW,hw.dateWorked)-1)),hw.dateWorked),po.idPO,jb.jobNo),2) as 'ST Cost',
0 as 'Total Exp',
0 as 'Total Mat'
from hoursWorked as hw 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
where hw.dateWorked between @StartDate and @EndDate 
UNION ALL

select
YEAR (exu.dateExpense) as 'Year',
po.idPO	as 'PO',
DATEADD(DAY,IIF( DATEPART(DW,exu.dateExpense)=1,0, 7-(DATEPART(DW,exu.dateExpense)-1)),exu.dateExpense) as 'Weekly',
jb.jobNo as 'ClientID',
0 as 'ST Hours',
0 as 'OT Hours',
0 as 'OT Cost',
0 as 'ST Cost',
exu.amount as 'Total Exp',
0 as 'Total Mat'
from expensesUsed as exu 
inner join expenses as ex on ex.idExpenses = exu.idExpense
left join task as tk on tk.idAux = exu.idAux
left join workOrder as wo on wo.idAuxWO = tk.idAuxWO
left join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
left join job as jb on jb.jobNo = po.jobNo 
where exu.dateExpense between @StartDate and @EndDate 
UNION ALL

select
YEAR (mau.dateMaterial) as 'Year',
po.idPO	as 'PO',
DATEADD(DAY,IIF( DATEPART(DW,mau.dateMaterial)=1,0, 7-(DATEPART(DW,mau.dateMaterial)-1)),mau.dateMaterial) as 'Weekly',
jb.jobNo as 'ClientID',
0 as 'ST Hours',
0 as 'OT Hours',
0 as 'OT Cost',
0 as 'ST Cost',
0 as 'Total Exu',
mau.amount as 'Total Mat'
from materialUsed as mau 
inner join material as ma on ma.idMaterial = mau.idMaterial
left join task as tk on tk.idAux = mau.idAux
left join workOrder as wo on wo.idAuxWO = tk.idAuxWO
left join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
left join job as jb on jb.jobNo = po.jobNo 
where mau.dateMaterial between @StartDate and @EndDate 
) AS T1 
 ORDER BY T1.[Weekly],T1.[PO],T1.[ClientID]

--===============================================================================================================================================
--====== SCAFFOLD ===============================================================================================================================
--===============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'Scaffold')
BEGIN 
	drop table PBI.[Scaffold]
END

select wo.idWO as 'Labor WO / Network #',
case sj.[description] 
	when 'Maintenance' then 'M'
	when 'T/A' then 'T'
	when 'Capital' then 'C'
	when 'Winterization' then 'W'
	when 'All' then 'A'
	when 'Operational' then 'O'
    else 'A'
end as 'TYPE (O,M,T,C)',
sc.tag as 'Tag #',
sc.foreman as 'STFOREMAN',
(select ISNULL(SUM(quantity),0) from productTotalScaffold where tag = sc.tag) as 'Pieces',
ar.name as 'Unit',
sc.location as 'Location',
CONVERT(nvarchar, sc.buildDate,101)  as 'Date UP',
IIF(DATEDIFF(DAY,sc.buildDate,ISNULL((select dismantleDate from dismantle as ds where ds.tag = sc.tag),GETDATE()))=0,1,DATEDIFF(DAY,sc.buildDate,ISNULL( (select  dismantleDate from dismantle as ds where ds.tag = sc.tag), GETDATE()))) as 'ACTIVEDAYS',
ISNULL((select count(*) from productTotalScaffold as pt inner join product as pd on pd.idProduct = pt.idProduct where pt.tag= sc.tag and pd.name = '%YO-YO%'),0) as 'SRL''s', 
ROUND(ISNULL((select SUM(pt.quantity*pd.dailyRentalRate) from productTotalScaffold as pt 
inner join product as pd on pd.idProduct = pt.idProduct
where pt.tag = sc.tag ) ,0),2) as 'M-Rent',
sc.latitude as 'Lat', 
sc.longitude as 'Long',
jb.jobNo as 'ClientID'
INTO PBI.Scaffold
from scaffoldTraking as sc
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join areas as ar on ar.idArea = sc.idArea
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
where sc.buildDate between @StartDate and @EndDate and sc.[status]='f' 


--===============================================================================================================================================
--====== ScaBTools ==============================================================================================================================
--===============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ScaBTools')
BEGIN 
	drop table PBI.[ScaBTools]
END


select T1.[Year],T1.[MONTHB],T1.[STWRKHRS],T1.[STMTRLHRS],T1.[STTRVL],T1.[STWTRHRS],T1.[STALRMHRS],
 T1.[STSFTYHRS],T1.[STSTDBYHRS],T1.[OTHERHRS],T1.[STHRS],T1.[Task],T1.[MTMBQY],T1.[MONTH] ,
 T1.[MTMBQY]/T1.[STWRKHRS] as 'Tools B Pieces',T1.[jobNo] as 'ClientID'
INTO PBI.[ScaBTools]
from (
select  
distinct
YEAR(sc.buildDate) as 'Year',DATENAME(MONTH,sc.buildDate) as 'MONTHB',
SUM(ach.[build]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate),jb.jobNo) as 'STWRKHRS',
SUM(ach.[material]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate),jb.jobNo) as 'STMTRLHRS',
SUM(ach.[travel]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate),jb.jobNo) as 'STTRVL',
SUM(ach.[weather]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate),jb.jobNo) as 'STWTRHRS',
SUM(ach.[alarm]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate),jb.jobNo) as 'STALRMHRS',
SUM(ach.[safety]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate),jb.jobNo) as 'STSFTYHRS',
SUM(ach.[stdBy]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate),jb.jobNo) as 'STSTDBYHRS',
SUM(ach.[other]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate),jb.jobNo) as 'OTHERHRS',
SUM(ach.[build]+ach.[material]+ach.[travel]+ach.[weather]+ach.[alarm]+ach.[safety]+ach.[stdBy]+ach.[other]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate),jb.jobNo) as 'STHRS',
'Build' AS 'Task',
SUM(ISNULL((select SUM(quantity) from productScaffold as ps where ps.tag = sc.tag),0)) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate),jb.jobNo) as 'MTMBQY',
MONTH(sc.buildDate) as 'MONTH'
,jb.jobNo
from activityHours as ach 
left join scaffoldTraking as sc on sc.tag = ach.tag
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where sc.buildDate between @StartDate and @EndDate and ach.idModAux is NULL and idDismantle is NULL
) as T1

--===============================================================================================================================================
--====== ScaDTools ==============================================================================================================================
--===============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ScaDTools')
BEGIN 
	drop table PBI.[ScaDTools]
END

select T1.[Year],T1.[MONTHD],T1.[DHWRKHRS],T1.[DHMTRLHRS],T1.[DHTRVL],T1.[DHWTRHRS],T1.[DHALRMHRS],T1.[DHSFTYHRS],T1.[DHSTDBYHRS],T1.[OTHERHRS],
T1.[DHRS],T1.[Task],T1.[MTMBQY],T1.[MONTH], T1.[MTMBQY]/T1.[DHWRKHRS] as 'Tools D Pieces',T1.[ClientID]
INTO PBI.[ScaDTools]	
from (
select  
DISTINCT
YEAR(ds.dismantleDate) as 'Year',
DATENAME(MONTH,ds.dismantleDate) as 'MONTHD',
SUM(ach.[build]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate),jb.jobNo) as 'DHWRKHRS',
SUM(ach.[material]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate),jb.jobNo) as 'DHMTRLHRS',
SUM(ach.[travel]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate),jb.jobNo) as 'DHTRVL',
SUM(ach.[weather]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate),jb.jobNo) as 'DHWTRHRS',
SUM(ach.[alarm]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate),jb.jobNo) as 'DHALRMHRS',
SUM(ach.[safety]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate),jb.jobNo) as 'DHSFTYHRS',
SUM(ach.[stdBy]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate),jb.jobNo) as 'DHSTDBYHRS',
SUM(ach.[other]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate),jb.jobNo) as 'OTHERHRS',
SUM(ach.[build]+ach.[material]+ach.[travel]+ach.[weather]+ach.[alarm]+ach.[safety]+ach.[stdBy]+ach.[other]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate),jb.jobNo) as 'DHRS',
'Dism' as 'Task',
SUM(ISNULL((select SUM(quantity) from productDismantle as pd where pd.tag = ds.tag and pd.idDismantle = ds.idDismantle),0)) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate),jb.jobNo) as 'MTMBQY',
MONTH(ds.dismantleDate) as 'MONTH'
,jb.jobNo as 'ClientID'
from activityHours as ach 
inner join dismantle as ds on ds.tag = ach.tag and ds.idDismantle = ach.idDismantle
left join scaffoldTraking as sc on sc.tag = ds.tag
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where ds.dismantleDate between @StartDate and @EndDate and ach.idModAux is NULL and ach.idDismantle is not NULL
) as T1

--===============================================================================================================================================
--====== ScaMTools ==============================================================================================================================
--===============================================================================================================================================

IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ScaMTools')
BEGIN 
	drop table PBI.[ScaMTools]
END


select T1.[Year],T1.[MONTHM],T1.[MHWRKHRS],T1.[MHMTRLHRS],T1.[MHTRVL],T1.[MHWTRHRS],T1.[MHALRMHRS],
T1.[MHSFTYHRS],T1.[MHSTDBYHRS],T1.[OTHERHRS],T1.[MHRS],T1.[Task],T1.[MTQTY],T1.[MONTH],
T1.[MTQTY]/T1.[MHWRKHRS] as 'Tools M Pieces',T1.[ClientID]
INTO PBI.[ScaMTools]
from (
select  
DISTINCT
YEAR(md.modificationDate) as 'Year',MONTH(md.modificationDate) as 'MONTHM',
SUM(ach.[build]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'MHWRKHRS',
SUM(ach.[material]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'MHMTRLHRS',
SUM(ach.[travel]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'MHTRVL',
SUM(ach.[weather]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'MHWTRHRS',
SUM(ach.[alarm]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'MHALRMHRS',
SUM(ach.[safety]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'MHSFTYHRS',
SUM(ach.[stdBy]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'MHSTDBYHRS',
SUM(ach.[other]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'OTHERHRS',
SUM(ach.[build]+ach.[material]+ach.[travel]+ach.[weather]+ach.[alarm]+ach.[safety]+ach.[stdBy]+ach.[other]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'MHRS',
'Mod' as 'Task',
SUM(ISNULL((select SUM(quantity) from productDismantle as pd where pd.tag = md.tag and pd.idDismantle = md.idModAux),0)) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'MTQTY',
DATENAME(MONTH,md.modificationDate) as 'MONTH',
jb.jobNo as 'ClientID'
from activityHours as ach 
inner join modification as md on md.tag = ach.tag and md.idModAux = ach.idModAux
inner join scaffoldTraking as sc on sc.tag = md.tag 
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where md.modificationDate between @StartDate and @EndDate and ach.idModAux is not NULL 
) as T1

--===============================================================================================================================================
--====== ACM ====================================================================================================================================
--===============================================================================================================================================
IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ACM')
BEGIN 
	drop table PBI.[ACM]
END

select 
distinct
YEAR(kpi.dateWorked) as 'Year', MONTH(kpi.dateWorked) as 'Month',DATENAME(MONTH,kpi.dateWorked) as 'MonthN',
kpi.install as 'IT',
SUM(((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF])) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'II SQFT',
SUM((kpi.hoursST + kpi.hoursOT)) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'Hours',
SUM(((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF]) + kpi.SQF) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'Total SQF',
jb.jobNo AS 'ClientID',
SUM(ROUND((((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF]) + kpi.SQF) / (kpi.hoursST + kpi.hoursOT),2)) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'SQFPH'
INTO PBI.ACM
from KPI as kpi
inner join task as tk on tk.idAux = kpi.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where kpi.dateWorked between @StartDate and @EndDate and kpi.install like 'Asbestos'


insert into trackElemnts values
(1,'Record ID','Record ID',1,1,''),
(2,'Force or Reject','Force or Reject',0,'F',1,''),
(3,'Date','Date',1,'',1,''),
(4,'Order Type','Order Type',0,'POWO',1,''),
(5,'Location ID','Location ID',0,'1',1,''),
(6,'Company Code','Company Code',0,'0',1,''),
(7,'Agreement','Agreement',0,'0',1,''),
(8,'Group','Group',0,'',1,''),
(9,'Type','Type',0,'',1,''),
(10,'Equip Unique ID','Equip Unique ID',1,'',1,''),
(11,'Area','Area',1,'',1,''),
(12,'Level 1 ID','Level 1 ID',1,'',1,''),
(13,'Level 2 ID','Level 2 ID',1,'',1,''),
(14,'Level 3 ID','Level 3 ID',1,'',1,''),
(15,'Level 4 ID','Level 4 ID',0,'',1,''),
(16,'Base Hrs','Base Hrs',0,'1',1,''),
(17,'Over Hrs','Over Hrs',1,'',1,''),
(18,'Idle Hrs','Idle Hrs',0,'0.00',1,''),
(19,'Other Costs','Other Costs',0,'0',1,''),
(20,'Other Costs Name','Other Costs Name',0,'',1,''),
(21,'Extra','Extra',1,'',1,''),
(22,'GL Account','GL Account',0,'',1,'')

