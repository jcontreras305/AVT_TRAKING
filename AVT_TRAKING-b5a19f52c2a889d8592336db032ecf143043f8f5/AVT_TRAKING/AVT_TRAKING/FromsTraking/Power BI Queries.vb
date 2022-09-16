Imports System.Runtime.InteropServices
Imports System.Data.SqlClient
Public Class Power_BI_Queries
	Dim mtdPBI As New metodosPBI
	Dim listRefresh As New List(Of String)
	Dim loadingInfo As Boolean = False
	Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click
		Me.Close()
	End Sub
	Private Sub btnMinimize_Click(sender As Object, e As EventArgs) Handles btnMinimize.Click
		Me.WindowState = FormWindowState.Minimized
	End Sub
	Private Sub btnRestore_Click(sender As Object, e As EventArgs) Handles btnRestore.Click
		WindowState = FormWindowState.Normal
		btnRestore.Visible = False
		btnMaximize.Visible = True
	End Sub
	Private Sub btnMaximize_Click(sender As Object, e As EventArgs) Handles btnMaximize.Click
		MaximizedBounds = Screen.FromHandle(Me.Handle).WorkingArea
		WindowState = FormWindowState.Maximized
		btnMaximize.Visible = False
		btnRestore.Visible = True
	End Sub
	<DllImport("user32.DLL", EntryPoint:="ReleaseCapture")>
	Private Shared Sub ReleaseCapture()
	End Sub
	<DllImport("user32.DLL", EntryPoint:="SendMessage")>
	Private Shared Sub SendMessage(hWnd As IntPtr, wMsg As Integer, wParam As Integer, lParam As Integer)
	End Sub
	Private Sub Panel1_MouseMove(sender As Object, e As MouseEventArgs) Handles Panel1.MouseMove
		ReleaseCapture()
		SendMessage(Me.Handle, &H112&, &HF012&, 0)
	End Sub

	Private Sub Power_BI_Queries_Load(sender As Object, e As EventArgs) Handles Me.Load
		fillListView()
		mtdPBI.StartDate = "declare @StartDate as date ='" + validaFechaParaSQl(dtpStartDate.Value) + "'"
		mtdPBI.FinalDate = "declare @EndDate as date ='" + validaFechaParaSQl(dtpFinalDate.Value) + "'"
	End Sub
	Private Sub fillListView()
		If tvwTablePBI.Nodes IsNot Nothing Then
			tvwTablePBI.Nodes.Clear()
		End If
		Dim arraySheets() As String = {"ALL", "ALL Barriers", "ALLCPH", "ALLHOURS", "CostHPTAS", "Scaffold", "ScaBTools", "ScaDTools", "ScaMTools", "ACM", "AR Invoices", "Invoices"}
		Dim arrayALLCPH() As String = {"All CHP 1", "All CHP 2", "All CHP 3"}
		Dim arrayALLHours() As String = {"All Hours 1", "All Hours 2", "Travelers", "Absents"}


		For Each item As String In arraySheets
			tvwTablePBI.Nodes.Add(item)
		Next
		For Each item As String In arrayALLCPH
			tvwTablePBI.Nodes(2).Nodes.Add(item)
		Next
		For Each item As String In arrayALLHours
			tvwTablePBI.Nodes(3).Nodes.Add(item)
		Next
	End Sub
	Private Sub checkAll(ByVal Pnode As TreeNode)
		Pnode.Checked = True
		For Each node As TreeNode In Pnode.Nodes
			checkAll(node)
		Next
	End Sub
	Private Sub btnRefreshAll_Click(sender As Object, e As EventArgs) Handles btnCheckAll.Click
		loadingInfo = True
		For Each nd As TreeNode In tvwTablePBI.Nodes
			For Each node As TreeNode In tvwTablePBI.Nodes
				checkAll(node)
			Next
		Next
		loadingInfo = False
	End Sub

	Private Sub verifyRefresh(ByVal Pnode As TreeNode)
		For Each nd As TreeNode In Pnode.Nodes
			If nd.Checked Then
				If nd.Nodes.Count > 0 Then
					verifyRefresh(nd)
				Else
					listRefresh.Add(nd.Text)
				End If
			End If
		Next
	End Sub

	Private Sub btnRefresh_Click(sender As Object, e As EventArgs) Handles btnRefresh.Click
		listRefresh.Clear()
		For Each nd As TreeNode In tvwTablePBI.Nodes
			If nd.Checked Then
				If nd.Nodes.Count > 0 Then
					verifyRefresh(nd)
				Else
					listRefresh.Add(nd.Text)
				End If
			End If
		Next
		If listRefresh.Count > 0 Then
			If mtdPBI.tableRefresh(listRefresh) Then
				MsgBox("Successful.")
			End If
		Else
			MessageBox.Show("Please check one element of the list.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information)
		End If
	End Sub
	Private Sub tvwTablePBI_AfterCheck(sender As Object, e As TreeViewEventArgs) Handles tvwTablePBI.AfterCheck
		If Not loadingInfo Then
			If e.Node.Checked = True Then
				If e.Node.Parent IsNot Nothing Then
					e.Node.Parent.Checked = True
				End If
			End If
		End If
	End Sub
	Private Sub dtpStartDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpStartDate.ValueChanged
		mtdPBI.StartDate = "declare @StartDate as date ='" + validaFechaParaSQl(dtpStartDate.Value) + "'"
	End Sub

	Private Sub dtpFinalDate_ValueChanged(sender As Object, e As EventArgs) Handles dtpFinalDate.ValueChanged
		mtdPBI.FinalDate = "declare @EndDate as date ='" + validaFechaParaSQl(dtpFinalDate.Value) + "'"
	End Sub

	Private Sub tvwTablePBI_NodeMouseDoubleClick(sender As Object, e As TreeNodeMouseClickEventArgs) Handles tvwTablePBI.NodeMouseDoubleClick
		If e.Node.Nodes.Count = 0 Then
			If Not mtdPBI.selectTable(e.Node.Text, tblInfoPBI) Then
				tblInfoPBI.DataSource = Nothing
			End If
		End If
	End Sub
End Class

Public Class metodosPBI
    Inherits ConnectioDB

    Dim cmdSchemaPBI As String = "IF NOT EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_SCHEMA = 'PBI')
BEGIN
	PRINT 'THE SCHEMA PBI NOT EXIST.'
	EXEC ('CREATE SCHEMA PBI;');
	PRINT 'THE SCHEMA WAS CREATED.'
END
ELSE
BEGIN 
	PRINT 'THE SCHAME PBI EXIST'
END "
	Private _startDate As String = ""
	Private _finalDate As String = ""

	Public Property StartDate As String
		Get
			If _startDate = "" Then
				_startDate = "declare @StartDate as date = '" + validaFechaParaSQl(Date.Today) + "'"
			End If
			Return _startDate
		End Get
		Set(value As String)
			_startDate = value
		End Set
	End Property

	Public Property FinalDate As String
		Get
			If _finalDate = "" Then
				_finalDate = "declare @EndDate as date = '" + validaFechaParaSQl(Date.Today) + "'"
			End If
			Return _finalDate
		End Get
		Set(value As String)
			_finalDate = value
		End Set
	End Property
	Public Function tableRefresh(ByVal tblName As List(Of String)) As Boolean
		Try
			conectar()
			Dim flag As Boolean = True
			Dim cmd As New SqlCommand(cmdSchemaPBI, conn)
			If cmd.ExecuteNonQuery Then
				Dim tran As SqlTransaction
				tran = conn.BeginTransaction
				For Each name As String In tblName
					Dim cmd1 As New SqlCommand()
					Select Case name
						Case "ALL"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + All
						Case "ALL Barriers"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + ALL_Barries
						Case "All CHP 1"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + All_CHP_1
						Case "All CHP 2"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + All_CHP_2
						Case "All CHP 3"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + All_CHP_3
						Case "All Hours 1"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + All_Hours_1
						Case "All Hours 2"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + All_Hours_2
						Case "Travelers"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + Travelers
						Case "Absents"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + Absents
						Case "CostHPTAS"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + CostHPTAS
						Case "Scaffold"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + Scaffold
						Case "ScaBTools"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + ScaBTools
						Case "ScaDTools"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + ScaDTools
						Case "ScaMTools"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + ScaMTools
						Case "ACM"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + ACM
						Case "AR Invoices"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + AR_Inovices
						Case "Invoices"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + Invoices
					End Select
					cmd1.Connection = conn
					cmd1.Transaction = tran
					If cmd1.ExecuteNonQuery() >= 0 Then
						flag = True
					Else
						flag = False
						Exit For
					End If
				Next
				If flag Then
					tran.Commit()
					Return True
				Else
					tran.Rollback()
					Return False
				End If
			Else
				Return False
			End If

		Catch ex As Exception
			MsgBox(ex.Message())
			Return False
		Finally
			desconectar()
		End Try
	End Function
	Public Function selectTable(ByVal tblName As String, ByVal tbl As DataGridView) As Boolean
		Try
			conectar()
			Dim cmd As New SqlCommand()
			Select Case tblName
				Case "ALL"
					cmd.CommandText = "select * from PBI.[ALL]"
				Case "ALL Barriers"
					cmd.CommandText = "select * from PBI.[ALLBarriers]"
				Case "All CHP 1"
					cmd.CommandText = "select * from PBI.[ALLCPH1]"
				Case "All CHP 2"
					cmd.CommandText = "select * from PBI.[ALLCPH2]"
				Case "All CHP 3"
					cmd.CommandText = "select * from PBI.[ALLCPH3]"
				Case "All Hours 1"
					cmd.CommandText = "select * from PBI.[ALLHours1]"
				Case "All Hours 2"
					cmd.CommandText = "select * from PBI.[ALLHours2]"
				Case "Travelers"
					cmd.CommandText = "select * from PBI.[EmpTravAndLocals]"
				Case "Absents"
					cmd.CommandText = "select * from PBI.[EmpAbsents]"
				Case "CostHPTAS"
					cmd.CommandText = "select * from PBI.[CostHPTAS]"
				Case "Scaffold"
					cmd.CommandText = "select * from PBI.[Scaffold]"
				Case "ScaBTools"
					cmd.CommandText = "select * from PBI.[ScaBTools]"
				Case "ScaDTools"
					cmd.CommandText = "select * from PBI.[ScaDTools]"
				Case "ScaMTools"
					cmd.CommandText = "select * from PBI.[ScaMTools]"
				Case "ACM"
					cmd.CommandText = "select * from PBI.[ACM]"
				Case "AR Invoices"
					cmd.CommandText = "select * from PBI.[ARInvoices]"
				Case "Invoices"
					cmd.CommandText = "select * from PBI.[Invoices]"
			End Select
			cmd.Connection = conn
			If cmd.ExecuteNonQuery Then
				Dim da As New SqlDataAdapter(cmd)
				Dim dt As New DataTable
				da.Fill(dt)
				tbl.DataSource = dt
				Return True
			Else
				Return False
			End If
		Catch ex As Exception
			MsgBox(ex.Message)
			Return False
		Finally
			desconectar()
		End Try
	End Function

	Dim _All, _ALL_Barries, _CostHPTAS, _Scaffold, _ScaBTools, _ScaDTools, _ScaMTools, _ACM, _AR_Inovices, _Invoices,
_All_CHP_1, _All_CHP_2, _All_CHP_3,
_All_Hours_1, _All_Hours_2, _Travelers, _Absents As String

	Public Property All As String
		Get
			_All = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALL')
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
)as T2"
			Return _All
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property ALL_Barries As String
		Get
			_ALL_Barries = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLBarriers')
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
AS T1 ORDER BY T1.ClientID,T1.[Month]"
			Return _ALL_Barries
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property All_CHP_1 As String
		Get
			_All_CHP_1 = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLCPH1')
BEGIN 
	drop table PBI.[ALLCPH1]
END

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
left join workCode as wc on wc.idWorkCode = hw.idWorkCode
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo
where hw.dateWorked between @StartDate and @EndDate and wc.name not like '%6.4%' and wc.name not like '%covid%'
) as T1"
			Return _All_CHP_1
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property All_CHP_2 As String
		Get
			_All_CHP_2 = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLCPH2')
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
"
			Return _All_CHP_2
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property All_CHP_3 As String
		Get
			_All_CHP_3 = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLCPH3')
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
left join workCode as wc on wc.idWorkCode = hw.idWorkCode
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo
where hw.dateWorked between @StartDate and @EndDate and wc.name not like 'LM%' and wc.name not like '%6.4%' and wc.name not like '%covid%'
) as T1"
			Return _All_CHP_3
		End Get
		Set(value As String)
			_All_CHP_3 = value
		End Set
	End Property

	Public Property All_Hours_1 As String
		Get
			_All_Hours_1 = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLHours1')
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
) AS T1 "
			Return _All_Hours_1
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property All_Hours_2 As String
		Get
			_All_Hours_2 = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLHours2')
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
) AS T1 "
			Return _All_Hours_2
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property Travelers As String
		Get
			_Travelers = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'EmpTravAndLocals')
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
) as T1"
			Return _Travelers
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property Absents As String
		Get
			_Absents = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'EmpAbsents')
BEGIN 
	drop table PBI.[EmpAbsents]
END

select YEAR(ab.dateAbsents) as'Year',DATENAME( MONTH,ab.dateAbsents) as 'Month',
SUM(ab.hoursPaid) OVER (PARTITION BY YEAR(ab.dateAbsents),MONTH(ab.dateAbsents)) as 'Hours',
SUM(ab.hoursPaid) OVER (PARTITION BY YEAR(ab.dateAbsents),MONTH(ab.dateAbsents))/8 as 'Days' ,
MONTH(ab.dateAbsents) as 'MonthN' 
into PBI.EmpAbsents
from absents as ab
where ab.dateAbsents between @StartDate and @EndDate"
			Return _Absents
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property CostHPTAS As String
		Get
			_CostHPTAS = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'CostHPTAS')
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
 ORDER BY T1.[Weekly],T1.[PO],T1.[ClientID]"
			Return _CostHPTAS
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property Scaffold As String
		Get
			_Scaffold = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'Scaffold')
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
sc.longitude as 'Long'
INTO PBI.Scaffold
from scaffoldTraking as sc
left join subJobs as sj on sj.idSubJob = sc.idSubJob
left join areas as ar on ar.idArea = sc.idArea
inner join task as tk on tk.idAux = sc.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
where sc.buildDate between @StartDate and @EndDate"
			Return _Scaffold
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property ScaBTools As String
		Get
			_ScaBTools = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ScaBTools')
BEGIN 
	drop table PBI.[ScaBTools]
END

select * , T1.[MTMBQY]/T1.[STWRKHRS] as 'Tools B Pieces'
INTO PBI.[ScaBTools]
from (
select  
DISTINCT
YEAR(sc.buildDate) as 'Year',DATENAME(MONTH,sc.buildDate) as 'MONTHB',
SUM(ach.[build]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate)) as 'STWRKHRS',
SUM(ach.[material]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate)) as 'STMTRLHRS',
SUM(ach.[travel]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate)) as 'STTRVL',
SUM(ach.[weather]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate)) as 'STWTRHRS',
SUM(ach.[alarm]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate)) as 'STALRMHRS',
SUM(ach.[safety]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate)) as 'STSFTYHRS',
SUM(ach.[stdBy]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate)) as 'STSTDBYHRS',
SUM(ach.[other]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate)) as 'OTHERHRS',
SUM(ach.[build]+ach.[material]+ach.[travel]+ach.[weather]+ach.[alarm]+ach.[safety]+ach.[stdBy]+ach.[other]) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate)) as 'STHRS',
'Build' AS 'Task',
SUM(ISNULL((select SUM(quantity) from productScaffold as ps where ps.tag = sc.tag),0)) OVER (PARTITION BY YEAR(sc.buildDate),MONTH(sc.buildDate)) as 'MTMBQY',
MONTH(sc.buildDate) as 'MONTH'
from activityHours as ach 
inner join scaffoldTraking as sc on sc.tag = ach.tag
where sc.buildDate between @StartDate and @EndDate and ach.idModAux is NULL and idDismantle is NULL
) as T1"
			Return _ScaBTools
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property ScaDTools As String
		Get
			_ScaDTools = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ScaDTools')
BEGIN 
	drop table PBI.[ScaDTools]
END

select * , T1.[MTMBQY]/T1.[DHWRKHRS] as 'Tools D Pieces'
INTO PBI.[ScaDTools]
from (
select  
DISTINCT
YEAR(ds.dismantleDate) as 'Year',
DATENAME(MONTH,ds.dismantleDate) as 'MONTHD',
SUM(ach.[build]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate)) as 'DHWRKHRS',
SUM(ach.[material]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate)) as 'DHMTRLHRS',
SUM(ach.[travel]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate)) as 'DHTRVL',
SUM(ach.[weather]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate)) as 'DHWTRHRS',
SUM(ach.[alarm]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate)) as 'DHALRMHRS',
SUM(ach.[safety]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate)) as 'DHSFTYHRS',
SUM(ach.[stdBy]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate)) as 'DHSTDBYHRS',
SUM(ach.[other]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate)) as 'OTHERHRS',
SUM(ach.[build]+ach.[material]+ach.[travel]+ach.[weather]+ach.[alarm]+ach.[safety]+ach.[stdBy]+ach.[other]) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate)) as 'DHRS',
'Dism' as 'Task',
SUM(ISNULL((select SUM(quantity) from productDismantle as pd where pd.tag = ds.tag and pd.idDismantle = ds.idDismantle),0)) OVER (PARTITION BY YEAR(ds.dismantleDate),MONTH(ds.dismantleDate)) as 'MTMBQY',
MONTH(ds.dismantleDate) as 'MONTH'
from activityHours as ach 
inner join dismantle as ds on ds.tag = ach.tag and ds.idDismantle = ach.idDismantle
where ds.dismantleDate between @StartDate and @EndDate and ach.idModAux is NULL and ach.idDismantle is not NULL
) as T1"
			Return _ScaDTools
		End Get
		Set(value As String)
			_ScaDTools = value
		End Set
	End Property

	Public Property ScaMTools As String
		Get
			_ScaMTools = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ScaMTools')
BEGIN 
	drop table PBI.[ScaMTools]
END

select * , T1.[MTQTY]/T1.[MHWRKHRS] as 'Tools M Pieces'
INTO PBI.[ScaMTools]
from (
select  
DISTINCT
YEAR(md.modificationDate) as 'Year',MONTH(md.modificationDate) as 'MONTHM',
SUM(ach.[build]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate)) as 'MHWRKHRS',
SUM(ach.[material]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate)) as 'MHMTRLHRS',
SUM(ach.[travel]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate)) as 'MHTRVL',
SUM(ach.[weather]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate)) as 'MHWTRHRS',
SUM(ach.[alarm]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate)) as 'MHALRMHRS',
SUM(ach.[safety]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate)) as 'MHSFTYHRS',
SUM(ach.[stdBy]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate)) as 'MHSTDBYHRS',
SUM(ach.[other]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate)) as 'OTHERHRS',
SUM(ach.[build]+ach.[material]+ach.[travel]+ach.[weather]+ach.[alarm]+ach.[safety]+ach.[stdBy]+ach.[other]) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate)) as 'MHRS',
'Mod' as 'Task',
SUM(ISNULL((select SUM(quantity) from productDismantle as pd where pd.tag = md.tag and pd.idDismantle = md.idModAux),0)) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate)) as 'MTQTY',
DATENAME(MONTH,md.modificationDate) as 'MONTH'
from activityHours as ach 
inner join modification as md on md.tag = ach.tag and md.idModAux = ach.idModAux
where md.modificationDate between @StartDate and @EndDate and ach.idModAux is not NULL 
) as T1"
			Return _ScaMTools
		End Get
		Set(value As String)
			_ScaMTools = value
		End Set
	End Property

	Public Property ACM As String
		Get
			_ACM = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ACM')
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
where kpi.dateWorked between @StartDate and @EndDate and kpi.install like 'Asbestos'"
			Return _ACM
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property AR_Inovices As String
		Get
			_AR_Inovices = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ARInvoices')
BEGIN 
	drop table PBI.[ARInvoices]
END

select
jb.jobNo as 'ClientID' ,
po.idPO as 'PO',
inv.invoice as 'Invoice#',
ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients as cl1 on cl1.idClient = jb1.idClient
where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and hw1.dateWorked between inv.startDate and inv.FinalDate ),0)
+
ISNULL((select sum(exu1.amount) from expensesUsed as exu1
	inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
	inner join task as tk1 on tk1.idAux = exu1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients  as cl1 on cl1.idClient = jb1.idClient
where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and exu1.dateExpense between inv.startDate and inv.FinalDate ),0)
+
ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
	inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
	inner join task as tk1 on tk1.idAux = mtu1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients  as cl1 on cl1.idClient = jb1.idClient
where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate ),0 )
as 'Amount',
CONVERT(nvarchar, inv.invoiceDate, 101) as 'Invoice Date',
CONVERT(nvarchar, DATEADD(DAY, IIF(cl.payTerms='',0,CONVERT(INT, cl.payterms)), inv.invoiceDate),101)  as 'Due Date',
DATEDIFF(DAY,DATEADD(DAY, IIF(cl.payTerms='',0,CONVERT(INT, cl.payterms)), inv.invoiceDate),GETDATE()) as 'Past Due Days'
INTO PBI.[ARInvoices]
from invoice as inv
inner join projectOrder as po on po.idPO = inv.idPO
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = inv.idClient and jb.idClient = cl.idClient
where inv.invoiceDate between @StartDate and @EndDate and inv.[status] = 0 "
			Return _AR_Inovices
		End Get
		Set(value As String)
			_AR_Inovices = value
		End Set
	End Property

	Public Property Invoices As String
		Get
			_Invoices = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'Invoices')
BEGIN 
	drop table PBI.[Invoices]
END

select 
jb.jobNo as 'ClientID',
IIF(cl.payTerms='',0,cl.payTerms) as 'Pay Terms',
po.idPO as 'PO',
inv.invoice as 'Invoice',
CONVERT(nvarchar, inv.invoiceDate,101) as 'Invoice Date',
ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients as cl1 on cl1.idClient = jb1.idClient
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and hw1.dateWorked between inv.startDate and inv.FinalDate),0) 
as 'Total Hours PO',

ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients as cl1 on cl1.idClient = jb1.idClient
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and hw1.dateWorked between inv.startDate and inv.FinalDate),0) 
as 'Total Labor',

ISNULL((select sum(exu1.amount) from expensesUsed as exu1
	inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
	inner join task as tk1 on tk1.idAux = exu1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients  as cl1 on cl1.idClient = jb1.idClient
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and exu1.dateExpense between inv.startDate and inv.FinalDate and ex1.expenseCode like '%travel%'),0)
as 'Total Expenses',

ISNULL((select sum(exu1.amount) from expensesUsed as exu1
	inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
	inner join task as tk1 on tk1.idAux = exu1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients  as cl1 on cl1.idClient = jb1.idClient
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and exu1.dateExpense between inv.startDate and inv.FinalDate and ex1.expenseCode like '%per-diem%'),0)
as 'Total PerDiem',

ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
	inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
	left join materialClass as mtc1 on mtc1.code = mt1.code
	inner join task as tk1 on tk1.idAux = mtu1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients  as cl1 on cl1.idClient = jb1.idClient
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate 
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
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate 
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
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate 
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
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate  
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
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate  
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
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient =inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate  
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
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate 
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
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate ),0) 
as 'Total Material'
,
ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients as cl1 on cl1.idClient = jb1.idClient
where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and hw1.dateWorked between inv.startDate and inv.FinalDate ),0)
+
ISNULL((select sum(exu1.amount) from expensesUsed as exu1
	inner join expenses as ex1 on exu1.idExpense = ex1.idExpenses
	inner join task as tk1 on tk1.idAux = exu1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients  as cl1 on cl1.idClient = jb1.idClient
where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and exu1.dateExpense between inv.startDate and inv.FinalDate ),0)
+
ISNULL((select sum(mtu1.amount) from materialUsed as mtu1
	inner join material as mt1 on mtu1.idMaterial = mt1.idMaterial
	inner join task as tk1 on tk1.idAux = mtu1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients  as cl1 on cl1.idClient = jb1.idClient
where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate ),0 )
as 'Total Cost'
INTO PBI.[Invoices]
from invoice as inv
inner join projectOrder as po on po.idPO = inv.idPO
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = inv.idClient and jb.idClient = cl.idClient
where inv.invoiceDate between @StartDate and @EndDate and inv.[status] = 0 "
			Return _Invoices
		End Get
		Set(value As String)

		End Set
	End Property


End Class