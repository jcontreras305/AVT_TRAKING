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
		Dim arraySheets() As String = {"ALL", "ALL Barriers", "ALLCPH", "ALLHOURS", "CostHPTAS", "CostMth", "Scaffold", "ScaBTools", "ScaDTools", "ScaMTools", "ACM", "ACMLF", "AR Invoices", "Invoices", "Invoices Cost", "Craft"}
		Dim arrayAllBerries() As String = {"ALL Barriers 1", "ALL Barriers 2"}
		Dim arrayALLCPH() As String = {"All CHP 1", "All CHP 2", "All CHP 3"}
		Dim arrayALLHours() As String = {"All Hours 1", "All Hours 2", "Travelers", "Absents", "Count Work Code"}

		For Each item As String In arraySheets
			tvwTablePBI.Nodes.Add(item)
		Next
		For Each item As String In arrayAllBerries
			tvwTablePBI.Nodes(1).Nodes.Add(item)
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
			If mtdPBI.tableRefresh(listRefresh, lblMessage) Then
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
			If Not mtdPBI.selectTable(e.Node.Text, tblInfoPBI, lblMessage) Then
				tblInfoPBI.DataSource = Nothing
			End If
		End If
	End Sub

End Class

Public Class metodosPBI
    Inherits ConnectioDB

	Dim cmdSchemaPBI As String = "IF NOT EXISTS (select * from sys.schemas where name = 'PBI')
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
	Public Function tableRefresh(ByVal tblName As List(Of String), ByVal lbl As Label) As Boolean
		Try
			conectar()
			Dim flag As Boolean = True
			Dim cmd As New SqlCommand(cmdSchemaPBI, conn)
			If cmd.ExecuteNonQuery Then
				Dim tran As SqlTransaction
				tran = conn.BeginTransaction
				For Each name As String In tblName
					Dim cmd1 As New SqlCommand()
					lbl.Text = "Message : Updating info from table " + name
					Select Case name
						Case "ALL"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + All
						Case "ALL Barriers 1"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + ALL_Barries1
						Case "ALL Barriers 2"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + ALL_Barries2
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
						Case "Count Work Code"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + CountWCEmp
						Case "CostHPTAS"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + CostHPTAS
						Case "CostMth"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + CostMth
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
						Case "ACMLF"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + ACMLF
						Case "AR Invoices"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + AR_Inovices
						Case "Invoices"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + Invoices
						Case "Invoices Cost"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + InvoicesCost
						Case "Craft"
							cmd1.CommandText = StartDate + vbCrLf + FinalDate + vbCrLf + Craft
					End Select
					cmd1.Connection = conn
					cmd1.Transaction = tran
					cmd1.CommandTimeout = 200
					If cmd1.ExecuteNonQuery() >= 0 Then
						flag = True
					Else
						flag = False
						Exit For
					End If
				Next
				If flag Then
					tran.Commit()
					lbl.Text = "Message : End."
					Return True
				Else
					tran.Rollback()
					lbl.Text = "Message : Error."
					Return False
				End If
			Else
				Return False
			End If

		Catch ex As Exception
			MsgBox(ex.Message())
			lbl.Text = "Message : Error" + ex.Message
			Return False
		Finally
			desconectar()
		End Try
	End Function
	Public Function selectTable(ByVal tblName As String, ByVal tbl As DataGridView, ByVal lbl As Label) As Boolean
		Try
			conectar()
			Dim cmd As New SqlCommand()
			Select Case tblName
				Case "ALL"
					cmd.CommandText = "select * from PBI.[ALL]"
				Case "ALL Barriers 1"
					cmd.CommandText = "select * from PBI.[ALLBarriers]"
				Case "ALL Barriers 2"
					cmd.CommandText = "select * from PBI.[ALLBarriers2]"
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
				Case "Count Work Code"
					cmd.CommandText = "select * from PBI.[COUNTWCEMP]"
				Case "CostHPTAS"
					cmd.CommandText = "select * from PBI.[CostHPTAS]"
				Case "CostMth"
					cmd.CommandText = "select * from PBI.[CostMth]"
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
				Case "ACMLF"
					cmd.CommandText = "select * from PBI.[ACMLF]"
				Case "AR Invoices"
					cmd.CommandText = "select * from PBI.[ARInvoices]"
				Case "Invoices"
					cmd.CommandText = "select * from PBI.[Invoices]"
				Case "Invoices Cost"
					cmd.CommandText = "select * from PBI.[InvoicesCost]"
				Case "Craft"
					cmd.CommandText = "select * from PBI.[Craft]"
			End Select
			cmd.Connection = conn
			lbl.Text = "Message : Table " + tblName + " info."
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

	Dim _All, _ALL_Barries1, _ALL_Barries2, _CostHPTAS, _CostMth, _Scaffold, _ScaBTools, _ScaDTools, _ScaMTools, _ACM, _ACMLF, _AR_Inovices, _Invoices,
_All_CHP_1, _All_CHP_2, _All_CHP_3,
_All_Hours_1, _All_Hours_2, _Travelers, _Absents, _countWCEMP, _InvoicesCost, _craft As String

	Public Property All As String
		Get
			_All = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALL')
BEGIN 
	drop table PBI.[ALL]
END
select 
	T2.[Year],T2.[ClientID],T2.[PO],T2.[MO#],T2.[ProjectDescription],T2.[ST],T2.[OT],
	T2.[Billing ST],
	T2.[Billing OT],
	T2.[Expenses],
	T2.[Total Material],
	CAST(ROUND((T2.[Billing ST]+T2.[Billing OT]+T2.[Expenses]+T2.[Total Material]),2,1) as decimal(20,2)) as 'PO Spent',
	CONCAT(CAST(ROUND((((T2.[Billing ST]+T2.[Billing OT]+T2.[Expenses]+T2.[Total Material])*100)/IIF(T2.[ProjectTotalBillingEstimate]=0,1,T2.[ProjectTotalBillingEstimate])),2,1) as decimal (20,2)),'%')  as 'PO%Spent',
	CAST(ROUND(T2.[ProjectTotalBillingEstimate]-(T2.[Billing ST]+T2.[Billing OT]+T2.[Expenses]+T2.[Total Material]),2,1) as decimal(20,2)) as 'PO Left',
	T2.[Comp],T2.[ProjectTotalBillingEstimate],T2.[PF],T2.[Earned],T2.[Begin Date],T2.[End Date],T2.[Estimate Hours],
	(IIF(T2.[Comp]>0 and t2.[Comp]<100,IIF((T2.[ST] + T2.[OT])>T2.[Estimate Hours],
			((T2.[Estimate Hours]-(T2.[ST] + T2.[OT]))*T2.[PF]) ,-- Caso 1 de ETC
			iif((T2.[ST] + T2.[OT])>0,iif(T2.[Comp]>0,((T2.[ST] + T2.[OT])/(T2.[Comp]*0.01))-(T2.[ST] + T2.[OT]),0), -- Caso 2 de ETC
			0	--Caso 3 de ETC
			)),0) ) as 'ETC',
	T2.[Phase] as 'Phase',
	Round((T2.[Billing ST]+ T2.[Billing OT]+T2.[Expenses]+T2.[Total Material])*(IIF( T2.[Taxes]>0,T2.[Taxes]/100,0)),2) as 'Taxes'
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
	T1.[ProjectTotalBillingEstimate],
	ROUND(IIF((SUM(T1.[ST]) OVER (PARTITION BY T1.[MO#],T1.[PO],T1.[ClientID],T1.[Year],T1.[ProjectDescription]) + SUM(T1.[OT]) OVER (PARTITION BY T1.[MO#],T1.[PO],T1.[ClientID],T1.[Year],T1.[ProjectDescription]))=0,0,T1.earned/(SUM(T1.[ST]) OVER (PARTITION BY T1.[MO#],T1.[PO],T1.[ClientID],T1.[Year],T1.[ProjectDescription]) + SUM(T1.[OT]) OVER (PARTITION BY T1.[MO#],T1.[PO],T1.[ClientID],T1.[Year],T1.[ProjectDescription]))),2) as 'PF',
	ROUND(T1.[earned],2) as 'Earned',
	T1.[Begin Date],
	T1.[End Date],
	T1.[Estimate Hours],
	T1.[Phase],
	T1.[Taxes]
	from(
		select 
		DISTINCT
		YEAR(dateWorked) as 'Year',--MONTH(hw.dateWorked) as 'Month', 
		jb.jobNo as 'ClientID', po.idPO as 'PO', CONCAT(wo.idWO,IIF(tk.task ='' , '','-'),tk.task) as 'MO#',tk.[description] as 'ProjectDescription',
		SUM(hw.hoursST) OVER (PARTITION BY YEAR(dateWorked),jb.jobNo,po.idPO,CONCAT(wo.idWO,IIF(tk.task ='' , '','-'),tk.task),tk.[description]) as 'ST',
		SUM(hw.hoursOT+hw.hours3) OVER (PARTITION BY YEAR(dateWorked),jb.jobNo,po.idPO,CONCAT(wo.idWO,IIF(tk.task='','','-'),tk.task),tk.[description]) as 'OT',
		SUM(hw.hoursST * wc.billingRate1) OVER (PARTITION BY YEAR(dateWorked),jb.jobNo,po.idPO,CONCAT(wo.idWO,IIF(tk.task='','','-'),tk.task),tk.[description]) as 'Billing ST',
		SUM((hw.hoursOT * wc.billingRateOT + hw.hours3 * wc.billingRate3)) OVER (PARTITION BY YEAR(dateWorked),jb.jobNo,po.idPO,CONCAT(wo.idWO,IIF(tk.task='','','-'),tk.task),tk.[description]) as 'Billing OT',
		0 as 'Expenses',
		0 as 'Total Material',
		tk.[percentComplete] as 'Comp',
		tk.estTotalBilling as 'ProjectTotalBillingEstimate',
		(tk.estimateHours*tk.percentComplete)*0.01 as 'earned',
		CONVERT(nvarchar,tk.beginDate,101) as 'Begin Date',
		CONVERT(nvarchar,tk.endDate,101) as 'End Date',
		tk.estimateHours as 'Estimate Hours',
		tk.phase as 'Phase',
		jb.Taxes
		from hoursWorked as hw 
		inner join task as tk on tk.idAux = hw.idAux 
		inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
		inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
		inner join job as jb on jb.jobNo = po.jobNo 
		inner join clients as cl on cl.idClient = jb.idClient
		inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
		where hw.dateWorked between @StartDate and @EndDate
		
		UNION ALL
		
		select
		DISTINCT
		YEAR(exu.dateExpense) as 'Year',jb.jobNo as 'ClientID', po.idPO as 'PO', CONCAT(wo.idWO,IIF(tk.task='','','-'),tk.task)as 'MO#',tk.[description] as 'ProjectDescrioption',
		0 as 'ST',
		0 as 'OT',
		0 as 'Billing ST',
		0 as 'Billing OT',
		SUM(exu.amount) OVER (PARTITION BY YEAR(exu.dateExpense),tk.idAux,wo.idWO,po.idPO,jb.jobNo) as 'Expenses',
		0 as 'Total Material',
		tk.[percentComplete] as 'Complete',
		tk.estTotalBilling as 'ProjectTotalBillingEstimate',
		(tk.estimateHours*tk.percentComplete)*0.01 as 'earned',
		CONVERT(nvarchar,tk.beginDate,101) as 'Begin Date',
		CONVERT(nvarchar,tk.endDate,101) as 'End Date',
		tk.estimateHours as 'Estimate Hours',
		tk.phase as 'Phase',
		jb.Taxes
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
		YEAR(mau.dateMaterial) as 'Year',jb.jobNo as 'ClientID', po.idPO as 'PO', CONCAT(wo.idWO,IIF(tk.task='','','-'),tk.task)as 'MO#',tk.[description] as 'ProjectDescrioption',
		0 as 'ST',
		0 as 'OT',
		0 as 'Billing ST',
		0 as 'Billing OT',
		0 as 'Expenses',
		SUM(mau.amount) OVER (PARTITION BY YEAR(mau.dateMaterial),tk.idAux,wo.idWO,po.idPO,jb.jobNo) as 'Total Material',
		tk.[percentComplete] as 'Complete',
		tk.estTotalBilling as 'ProjectTotalBillingEstimate',
		(tk.estimateHours*tk.percentComplete)*0.01 as 'earned',
		CONVERT(nvarchar,tk.beginDate,101) as 'Begin Date',
		CONVERT(nvarchar,tk.endDate,101) as 'End Date',
		tk.estimateHours as 'Estimate Hours',
		tk.phase as 'Phase',
		jb.Taxes
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

	Public Property ALL_Barries1 As String
		Get
			_ALL_Barries1 = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLBarriers')
BEGIN 
	drop table PBI.[ALLBarriers]
END

select T1.[Year],T1.[ClientID],T1.[Month],T1.[MonthN],T1.[name] AS 'CLASS',T1.[ST Hours],T1.[OT Hours], T1.[ST Hours] + T1.[OT Hours] AS 'TotalHours', T1.[ST Cost],T1.[OT Cost],Round(iif(T1.[Taxes]>0,(T1.[ST Cost]+T1.[OT Cost])*(T1.[Taxes]/100),0),2) AS 'Taxes'
into PBI.ALLBarriers
from (
select 
distinct
YEAR(hw.dateWorked) as 'Year',
jb.jobNo as 'ClientID', MONTH(hw.dateWorked) as 'Month' , DATENAME(MONTH,hw.dateWorked) as 'MonthN',wc.name , 
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'ST Hours',
SUM(hw.hoursOT+ hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'OT Hours',
SUM(hw.hoursST*wc.billingRate1) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'ST Cost',
SUM((hw.hoursOT*wc.billingRateOT) + (hw.hours3*wc.billingRate3)) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'OT Cost',
jb.Taxes
from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
where wc.name like '%-%' and hw.dateWorked between @startDate and @EndDate and wc.name not like '%covid%') 
AS T1 ORDER BY T1.ClientID,T1.[Month]"
			Return _ALL_Barries1
		End Get
		Set(value As String)

		End Set
	End Property
	Public Property ALL_Barries2 As String
		Get
			_ALL_Barries2 = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ALLBarriers2')
BEGIN 
	drop table PBI.[ALLBarriers2]
END

select T1.[Year],T1.[ClientID],T1.[Month],T1.[MonthN],T1.[name] AS 'CLASS',T1.[ST Hours],T1.[OT Hours], T1.[ST Hours] + T1.[OT Hours] AS 'TotalHours', T1.[ST Cost],T1.[OT Cost],Round(iif(T1.[Taxes]>0,(T1.[ST Cost]+T1.[OT Cost])*(T1.[Taxes]/100),0),2) AS 'Taxes'
into PBI.ALLBarriers2
from (
select 
distinct
YEAR(hw.dateWorked) as 'Year',
jb.jobNo as 'ClientID', MONTH(hw.dateWorked) as 'Month' , DATENAME(MONTH,hw.dateWorked) as 'MonthN',wc.name , 
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'ST Hours',
SUM(hw.hoursOT+ hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'OT Hours',
SUM(hw.hoursST*wc.billingRate1) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'ST Cost',
SUM((hw.hoursOT*wc.billingRateOT) + (hw.hours3*wc.billingRate3)) OVER (PARTITION BY YEAR(hw.dateWorked),wc.name,MONTH(hw.dateWorked),jb.jobNo) as 'OT Cost',
jb.Taxes
from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
where hw.dateWorked between @startDate and @EndDate) 
AS T1 ORDER BY T1.ClientID,T1.[Month]"
			Return _ALL_Barries2
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
SELECT distinct T3.[Year],T3.[Month],T3.[MonthN],T3.[ST Hours],T3.[OT Hours],T3.[Total Hours],T3.[Cost],T3.[CostPH],T3.[ClientID],T3.[MaterialCost],ROUND(SUM((T3.[MaterialCost]+T3.[Cost])/IIF(T3.[Total Hours]=0,1,T3.[Total Hours]))OVER (PARTITION BY T3.[Year],T3.[MonthN],T3.[ClientID])
,2,1) as 'CostPHMaterial',Round(iif(T3.[Taxes]>0,(T3.[Cost]+T3.[MaterialCost])*(T3.[Taxes]/100),0),2) AS 'Taxes'
INTO PBI.ALLCPH1 FROM (
select distinct
T2.[Year],
T2.[Month],
T2.[MonthN],
SUM(T2.[ST Hours]) OVER (PARTITION BY T2.[Year],T2.[MonthN],T2.[ClientID]) as 'ST Hours',
SUM(T2.[OT Hours]) OVER (PARTITION BY T2.[Year],T2.[MonthN],T2.[ClientID]) as 'OT Hours',
SUM(T2.[TotalHours]) OVER (PARTITION BY T2.[Year],T2.[MonthN],T2.[ClientID]) as 'Total Hours',
ROUND(SUM(T2.[Cost]) OVER (PARTITION BY T2.[Year],T2.[MonthN],T2.[ClientID]),2,1) as 'Cost' ,
ROUND(SUM(T2.[Cost]/IIF(T2.[TotalHours]=0,1,T2.[TotalHours])) OVER (PARTITION BY T2.[Year],T2.[MonthN],T2.[ClientID]),2,1) as 'CostPH' ,
T2.[ClientID],
ROUND(SUM(T2.[MaterialCost]) OVER (PARTITION BY T2.[Year],T2.[MonthN],T2.[ClientID]),2,1) as 'MaterialCost',
T2.[Taxes]

--INTO PBI.ALLCPH1 
from (
select 
T1.[Year],T1.[Month],T1.[MonthN],T1.[ST Hours],T1.[OT Hours],T1.[TotalHours],T1.[Cost],
--T1.[Cost]/IIF(T1.[TotalHours]=0,1,T1.[TotalHours]) as 'CostPH',
T1.ClientID,
T1.[MaterialCost],--,Round(((T1.[MaterialCost]+T1.[Cost])/(IIF(T1.[TotalHours]=0,1,T1.[TotalHours]))),2,1) as 'CostPHMat'
T1.[Taxes]
--INTO PBI.ALLCPH1
from(
select 
DISTINCT
YEAR(hw.dateWorked) as 'Year',MONTH(hw.dateWorked) as 'Month',DATENAME(MONTH,hw.dateWorked) as 'MonthN',
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'ST Hours',
SUM(hw.hoursOT+hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'OT Hours',
SUM(hw.hoursST + hw.hoursOT + hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'TotalHours',
ROUND(SUM(((hw.hoursST*wc.billingRate1) + (hw.hoursOT*wc.billingRateOT) + (hours3*wc.billingRate3))) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo),2) as 'Cost',
jb.jobNo as 'ClientID',
0 as  'MaterialCost',
jb.Taxes
from hoursWorked as hw 
left join workCode as wc on wc.idWorkCode = hw.idWorkCode and hw.jobNo = wc.jobNo
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
inner join job as jb on jb.jobNo = po.jobNo 
where hw.dateWorked between @StartDate and @EndDate and wc.name not like '%6.4%' and wc.name not like '%covid%'

union all 

select distinct YEAR(mtu.dateMaterial) as 'Year',MONTH(mtu.dateMaterial) as 'Month',DATENAME(MONTH,mtu.dateMaterial) as 'MonthN',
0 as 'ST Hours',
0 as 'OT Hours',
0 as 'TotalHours',
0 as 'Cost',
jb.jobNo as 'ClientID',
sum(mtu.amount) OVER (PARTITION BY YEAR(mtu.dateMaterial),MONTH(mtu.dateMaterial),jb.jobNo) as 'MaterialCost',
jb.Taxes
 from materialUsed as mtu 
inner join material as mt on mt.idMaterial = mtu.idMaterial
inner join task as tk on tk.idAux = mtu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where  mtu.dateMaterial between @StartDate and @EndDate 
) as T1 ) as T2 ) AS T3"
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

select T1.[Year],T1.[Month],T1.[MonthN],T1.[IT],T1.[II SQFT],T1.[Hours],T1.[Total SQF],T1.[ClientID],Round((T1.[Total SQF] / T1.[Hours]),2)  as 'SQFPH'
INTO PBI.ALLCPH2
from (
select 
distinct
YEAR(kpi.dateWorked) as 'Year', MONTH(kpi.dateWorked) as 'Month',DATENAME(MONTH,kpi.dateWorked) as 'MonthN',
kpi.install as 'IT',
SUM(((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF])) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'II SQFT',
SUM((kpi.hoursST + kpi.hoursOT)) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'Hours',--
SUM(((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF]) + kpi.SQF) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.install,jb.jobNo) as 'Total SQF',--
jb.jobNo AS 'ClientID'
from KPI as kpi
inner join task as tk on tk.idAux = kpi.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where kpi.dateWorked between @StartDate and @EndDate and kpi.install not like 'Asbestos'
) as T1
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
T1.[Year],T1.[Month],T1.[MonthN],T1.[ST Hours],T1.[OT Hours],T1.[TotalHours],T1.[Cost],T1.[Cost]/T1.[TotalHours] as 'CostPH',T1.[ClientID],
Round(iif(T1.[Taxes]>0,(T1.[Cost])*(T1.[Taxes]/100),0),2) AS 'Taxes'
INTO PBI.ALLCPH3
from(
select 
DISTINCT
YEAR(hw.dateWorked) as 'Year',MONTH(hw.dateWorked) as 'Month',DATENAME(MONTH,hw.dateWorked) as 'MonthN',
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'ST Hours',
SUM(hw.hoursOT+hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'OT Hours',
SUM(hw.hoursST + hw.hoursOT + hours3) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo) as 'TotalHours',
ROUND(SUM(((hw.hoursST*wc.billingRate1) + (hw.hoursOT*wc.billingRateOT) + (hours3*wc.billingRate3))) OVER (PARTITION BY YEAR(hw.dateWorked),MONTH(hw.dateWorked),jb.jobNo),2) as 'Cost',
jb.jobNo as 'ClientID',
jb.Taxes
from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo 
inner join job as jb on jb.jobNo = po.jobNo
left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
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
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
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
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
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

	Public Property CountWCEmp() As String
		Get
			_countWCEMP = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'COUNTWCEMP')
BEGIN 
	drop table PBI.[COUNTWCEMP]
END

select distinct t1.[Year],t1.[Client],t1.[Month],t1.[MonthN],t1.[Work Code],
count(*) OVER (PARTITION BY t1.[Year],t1.[Client],t1.[Month],t1.[Work Code]) as 'Count Employees'  
into PBI.COUNTWCEMP
from (
select distinct YEAR(hw.dateWorked)as 'Year',jb.jobNo as 'Client',MONTH(hw.dateWorked) as 'Month',DATENAME(MONTH,hw.dateWorked)as 'MonthN'
,case 
	when subString(wc.name,1,2) Like 'CK%' then 'Secretary'
	when subString(wc.name,1,3) Like 'FM%' then 'Foreman'
	when subString(wc.name,1,3) Like 'GF%' then 'General Foreman'
	when wc.name Like 'LMICM' or wc.name Like 'LMSCM' or wc.name Like 'LMPCM'or wc.name Like 'LMACM'or wc.name Like 'LMLCM' THEN 'Construction Manger'
	when wc.name Like 'LMIG' or wc.name Like 'LMSG' or wc.name Like 'LMPG'or wc.name Like 'LMAG'or wc.name Like 'LMLG' then 'General Foreman'
	when wc.name Like 'LMISUP' or wc.name Like 'LMSSUP' or wc.name Like 'LMPSUP'or wc.name Like 'LMASUP'or wc.name Like 'LMLSUP' then 'Supervisor'
	when wc.name Like 'LMIPM' or wc.name Like 'LMSPM' or wc.name Like 'LMPPM'or wc.name Like 'LMAPM'or wc.name Like 'LMLPM' then 'Project Manager'
	when subString(wc.name,1,4) like 'LMA' or subString(wc.name,1,4) like 'LMA-' or SUBSTRING(wc.name ,1,4) = 'LMAB' then 'Asbestos'
	when subString(wc.name,1,4) like 'LMI' or subString(wc.name,1,4) like 'LMI-' or subString(wc.name,1,4) like 'LMB1' or subString(wc.name,1,4) like 'LMB2' or subString(wc.name,1,4) like 'LMB3' or SUBSTRING(wc.name ,1,4) = 'LMIB' or SUBSTRING(wc.name ,1,4) = 'LMI4' or SUBSTRING(wc.name ,1,4) = 'LMII' or SUBSTRING(wc.name ,1,4) = 'CKII' then 'Insulation'
	when subString(wc.name,1,4) like 'LMP' or subString(wc.name,1,4) like 'LMP-' or subString(wc.name,1,4) like 'LMP1' or subString(wc.name,1,4) like 'LMP2' or subString(wc.name,1,4) like 'LMP3' or subString(wc.name,1,4) like 'LMP4' or SUBSTRING(wc.name ,1,4) = 'LMPB' or subString(wc.name,1,4) like 'LMPP' or subString(wc.name,1,4) like 'CKPP' then 'Paint'
	when subString(wc.name,1,4) like 'LMS' or subString(wc.name,1,4) like 'LMS-' or subString(wc.name,1,4) like 'LMS1' or subString(wc.name,1,4) like 'LMS2' or subString(wc.name,1,4) like 'LMS3' or subString(wc.name,1,4) like 'LMS4' or subString(wc.name,1,4) like 'LMSS' or subString(wc.name,1,4) like 'CKSS' or SUBSTRING(wc.name ,1,4) = 'LMSB' then 'Scaffold'
	when subString(wc.name,1,4) like 'LML' or subString(wc.name,1,4) like 'LML-' or subString(wc.name,1,4) like 'LMLB' then 'Lead'
	when subString(wc.name,1,3) like 'PLN%' then 'Planner'
	when subString(wc.name,1,3) like 'QAQ%' then 'Quality Control'
	when subString(wc.name,1,3) like 'SCH%' then 'Scheleder'
	when subString(wc.name,1,3) like 'SM%' then 'Safety-Supervisor'
	when subString(wc.name,1,4) like 'FRKO%' then 'Forklift Operator'
	when subString(wc.name,1,4) like 'SUP%' then 'Supervisor'
	else wc.name 
	end as 'Work Code',
	emp.numberEmploye
from hoursWorked as hw inner join workCode as wc on hw.idWorkCode = wc.idWorkCode and hw.jobNo = wc.jobNo
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO 
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo 
inner join job as jb on jb.jobNo = po.jobNo
left join employees as emp on emp.idEmployee = hw.idEmployee
where hw.dateWorked between @StartDate and @EndDate and not(wc.name like '%Bereavement%' or wc.name like '%Holiday%'or wc.name like '%Safety%'or wc.name like '%Drugtest%'or wc.name like '%Vacation%'or wc.name like '%Travel%'or wc.name like '%Craft%')
) as t1
"
			Return _countWCEMP
		End Get
		Set(ByVal value As String)
			_countWCEMP = value
		End Set
	End Property


	Public Property Absents As String
		Get
			_Absents = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'EmpAbsents')
BEGIN 
	drop table PBI.[EmpAbsents]
END

select distinct YEAR(ab.dateAbsents) as'Year',DATENAME( MONTH,ab.dateAbsents) as 'Month',
SUM(ab.hoursPaid) OVER (PARTITION BY YEAR(ab.dateAbsents),MONTH(ab.dateAbsents),ab.explanation) as 'Hours',
SUM(ab.hoursPaid) OVER (PARTITION BY YEAR(ab.dateAbsents),MONTH(ab.dateAbsents),ab.explanation)/8 as 'Days' ,
MONTH(ab.dateAbsents) as 'MonthN' ,
ab.explanation
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

select T2.[Year],T2.[PO],T2.[Weekly],T2.[ClientID],T2.[ST Hours],T2.[OT Hours],T2.[ST Cost],T2.[OT Cost],T2.[Total Mat],T2.[Total Exp],T2.[Total Rental 3rd party],T2.[Total In House],T2.[Total Company Equipment],T2.[Total Subcontract],T2.[Total Tools],T2.[Total Consumable],T2.[Total Other]
,Round(iif(T2.[Taxes]>0,(T2.[ST Cost]+T2.[OT Cost]+T2.[Total Mat]+T2.[Total Exp]+T2.[Total Rental 3rd party]+T2.[Total In House]+T2.[Total Company Equipment]+T2.[Total Subcontract]+T2.[Total Tools]+T2.[Total Consumable]+T2.[Total Other])*(T2.[Taxes]/100),0),2) AS 'Taxes'
INTO PBI.CostHPTAS from (
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
SUM(T1.[Total Mat]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'Total Mat',
SUM(T1.[Total Rental 3rd Party]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'Total Rental 3rd party',
SUM(T1.[Total In House]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'Total In House',
SUM(T1.[Total Company Equipment]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'Total Company Equipment',
SUM(T1.[Total Subcontract]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'Total Subcontract',
SUM(T1.[Total Tools]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'Total Tools',
SUM(T1.[Total Consumables]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'Total Consumable',
SUM(T1.[Total Other]) OVER (PARTITION BY T1.[Year],T1.[Weekly],T1.[PO],T1.[ClientID]) as 'Total Other',
T1.[Taxes]

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
0 as 'Total Mat',
0 as 'Total Rental 3rd Party',
0 as 'Total In House',
0 as 'Total Company Equipment',
0 as 'Total Subcontract',
0 as 'Total Tools',
0 as 'Total Consumables',
0 as 'Total Other',
jb.Taxes
from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
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
0 as 'Total Mat',
0 as 'Total Rental 3rd Party',
0 as 'Total In House',
0 as 'Total Company Equipment',
0 as 'Total Subcontract',
0 as 'Total Tools',
0 as 'Total Consumables',
0 as 'Total Other',
jb.Taxes
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
IIF(subString(code,LEN(code),1) = 'M' , mau.amount,0) as 'Total Mat',
IIF(subString(code,LEN(code),1) = 'D' , mau.amount,0) as 'Total Rental 3rd Party',
IIF(subString(code,LEN(code),1) = 'E' , mau.amount,0) as 'Total In House',
IIF(subString(code,LEN(code),1) = 'F' , mau.amount,0) as 'Total Company Equipment',
IIF(subString(code,LEN(code),1) = 'S' , mau.amount,0) as 'Total Subcontract',
IIF(subString(code,LEN(code),1) = 'T' , mau.amount,0) as 'Total Tools',
IIF(subString(code,LEN(code),1) = 'V' , mau.amount,0) as 'Total Consumables',
IIF(subString(code,LEN(code),1) = 'Y' , mau.amount,0) as 'Total Other',
jb.Taxes
from materialUsed as mau 
inner join material as ma on ma.idMaterial = mau.idMaterial
left join task as tk on tk.idAux = mau.idAux
left join workOrder as wo on wo.idAuxWO = tk.idAuxWO
left join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
left join job as jb on jb.jobNo = po.jobNo 
where mau.dateMaterial between @StartDate and @EndDate 
) AS T1
) AS T2
 ORDER BY T2.[Weekly],T2.[PO],T2.[ClientID]"
			Return _CostHPTAS
		End Get
		Set(value As String)

		End Set
	End Property

	Public Property CostMth() As String
		Get
			_CostMth = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'CostMth')
BEGIN 
	drop table PBI.[CostMth]
END

select T2.[Year],T2.[PO],T2.[Month],T2.[ClientID],T2.[ST Hours],T2.[OT Hours],T2.[ST Cost],T2.[OT Cost],T2.[Total Exp],T2.[Total Mat],T2.[Total Rental 3rd party],T2.[Total In House],T2.[Total Scaffold],T2.[Total Company Equipment],T2.[Total Subcontract],T2.[Total Tools],T2.[Total Consumable],T2.[Total Other],
	(T2.[OT Cost]+T2.[ST Cost]+T2.[Total Exp]+T2.[Total Mat]+T2.[Total Rental 3rd party]+T2.[Total In House]+T2.[Total Scaffold]+T2.[Total Company Equipment]+T2.[Total Subcontract]+T2.[Total Tools]+T2.[Total Consumable]+T2.[Total Other])as 'T Cost',
	(T2.[ST Hours]+T2.[OT Hours]) as 'T Hrs',
	iif((T2.[ST Hours]+T2.[OT Hours])=0,(T2.[OT Cost]+T2.[ST Cost]+T2.[Total Exp]+T2.[Total Mat]+T2.[Total Rental 3rd party]+T2.[Total In House]+T2.[Total Scaffold]+T2.[Total Company Equipment]+T2.[Total Subcontract]+T2.[Total Tools]+T2.[Total Consumable]+T2.[Total Other])/1,
	(T2.[OT Cost]+T2.[ST Cost]+T2.[Total Exp]+T2.[Total Mat]+T2.[Total Rental 3rd party]+T2.[Total In House]+T2.[Total Scaffold]+T2.[Total Company Equipment]+T2.[Total Subcontract]+T2.[Total Tools]+T2.[Total Consumable]+T2.[Total Other])/(T2.[ST Hours]+T2.[OT Hours])) as 'Cost PH',
	Round(iif(T2.[Taxes]>0,(T2.[OT Cost]+T2.[ST Cost]+T2.[Total Exp]+T2.[Total Mat]+T2.[Total Rental 3rd party]+T2.[Total In House]+T2.[Total Scaffold]+T2.[Total Company Equipment]+T2.[Total Subcontract]+T2.[Total Tools]+T2.[Total Consumable]+T2.[Total Other])*(T2.[Taxes]/100),0),2) AS 'Taxes'
	INTO PBI.CostMth
from (
select DISTINCT
T1.[Year],
T1.[PO],
T1.[Month],
T1.[ClientID],
SUM(T1.[ST Hours]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'ST Hours',
SUM(T1.[OT Hours]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'OT Hours',
SUM(T1.[OT Cost]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'OT Cost',
SUM(T1.[ST Cost]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'ST Cost',
SUM(T1.[Total Exp]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'Total Exp',
SUM(T1.[Total Mat]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'Total Mat',
SUM(T1.[Total Rental 3rd Party]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'Total Rental 3rd party',
SUM(T1.[Total In House]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'Total In House',
SUM(T1.[Total Scaffold]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'Total Scaffold',
SUM(T1.[Total Company Equipment]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'Total Company Equipment',
SUM(T1.[Total Subcontract]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'Total Subcontract',
SUM(T1.[Total Tools]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'Total Tools',
SUM(T1.[Total Consumables]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'Total Consumable',
SUM(T1.[Total Other]) OVER (PARTITION BY T1.[Year],T1.[Month],T1.[PO],T1.[ClientID]) as 'Total Other',
T1.[Taxes]
from(

select 
distinct
YEAR(hw.dateWorked) as 'Year',
po.idPO	as 'PO',
MONTH(hw.dateWorked) as 'Month',
jb.jobNo as 'ClientID',
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),Month(hw.dateWorked),po.idPO,jb.jobNo) as 'ST Hours',
SUM(hw.hoursOT+ hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),Month(hw.dateWorked),po.idPO,jb.jobNo) as 'OT Hours',
ROUND(SUM((hw.hoursOT*wc.billingRateOT) + (hw.hours3*wc.billingRate3)) OVER (PARTITION BY YEAR(hw.dateWorked),Month(hw.dateWorked),po.idPO,jb.jobNo),2) 'OT Cost',
ROUND(SUM(hw.hoursST*wc.billingRate1) OVER (PARTITION BY YEAR(hw.dateWorked),Month(hw.dateWorked),po.idPO,jb.jobNo),2) as 'ST Cost',
0 as 'Total Exp',
0 as 'Total Mat',
0 as 'Total Rental 3rd Party',
0 as 'Total In House',
0 as 'Total Scaffold',
0 as 'Total Company Equipment',
0 as 'Total Subcontract',
0 as 'Total Tools',
0 as 'Total Consumables',
0 as 'Total Other',
jb.Taxes
from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
inner join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
where hw.dateWorked between @StartDate and @EndDate 
UNION ALL

select
YEAR (exu.dateExpense) as 'Year',
po.idPO	as 'PO',
MONTH(exu.dateExpense) as 'Month',
jb.jobNo as 'ClientID',
0 as 'ST Hours',
0 as 'OT Hours',
0 as 'OT Cost',
0 as 'ST Cost',
exu.amount as 'Total Exp',
0 as 'Total Mat',
0 as 'Total Rental 3rd Party',
0 as 'Total In House',
0 as 'Total Scaffold',
0 as 'Total Company Equipment',
0 as 'Total Subcontract',
0 as 'Total Tools',
0 as 'Total Consumables',
0 as 'Total Other',
jb.Taxes
from expensesUsed as exu 
inner join expenses as ex on ex.idExpenses = exu.idExpense
inner join task as tk on tk.idAux = exu.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
where exu.dateExpense between @StartDate and @EndDate 

UNION ALL

select
YEAR (mau.dateMaterial) as 'Year',
po.idPO	as 'PO',
MONTH(mau.dateMaterial) as 'Month',
jb.jobNo as 'ClientID',
0 as 'ST Hours',
0 as 'OT Hours',
0 as 'OT Cost',
0 as 'ST Cost',
0 as 'Total Exu',
IIF(subString(code,LEN(code),1) = 'M' and not (code like ('%scaffold%') or name like '%scaffold%'), mau.amount,0) as 'Total Mat',
IIF(subString(code,LEN(code),1) = 'D' and not (code like ('%scaffold%') or name like '%scaffold%'), mau.amount,0) as 'Total Rental 3rd Party',
IIF(subString(code,LEN(code),1) = 'E' and not (code like ('%scaffold%') or name like '%scaffold%'), mau.amount,0) as 'Total In House',
IIF(code like ('%scaffold%') or name like '%scaffold%', mau.amount,0) as 'Total Scaffold',
IIF(subString(code,LEN(code),1) = 'F' and (not code like ('%scaffold%') or name like '%scaffold%'), mau.amount,0) as 'Total Company Equipment',
IIF(subString(code,LEN(code),1) = 'S' and (not code like ('%scaffold%') or name like '%scaffold%'), mau.amount,0) as 'Total Subcontract',
IIF(subString(code,LEN(code),1) = 'T' and (not code like ('%scaffold%') or name like '%scaffold%'), mau.amount,0) as 'Total Tools',
IIF(subString(code,LEN(code),1) = 'V' and (not code like ('%scaffold%') or name like '%scaffold%'), mau.amount,0) as 'Total Consumables',
IIF(subString(code,LEN(code),1) = 'Y' and (not code like ('%scaffold%') or name like '%scaffold%'), mau.amount,0) as 'Total Other',
jb.Taxes
from materialUsed as mau 
inner join material as ma on ma.idMaterial = mau.idMaterial
inner join task as tk on tk.idAux = mau.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
where mau.dateMaterial between @StartDate and @EndDate 
) AS T1)as T2
 ORDER BY T2.[Month],T2.[PO],T2.[ClientID]"
			Return _CostMth
		End Get
		Set(ByVal value As String)
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
where sc.buildDate between @StartDate and @EndDate and sc.[status]='f' "
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
SUM(ISNULL((select SUM(quantity) from productModification as pd where pd.tag = sc.tag and pd.idModAux = md.idModAux),0)) OVER (PARTITION BY YEAR(md.modificationDate),MONTH(md.modificationDate),jb.jobNo) as 'MTQTY',
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
where kpi.dateWorked between @StartDate and @EndDate and kpi.install like 'ACM' or kpi.install like 'Asbestos'"
			Return _ACM
		End Get
		Set(ByVal value As String)
			_ACM = value
		End Set
	End Property
	Public Property ACMLF() As String
		Get
			_ACMLF = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ACMLF')
BEGIN 
	drop table PBI.[ACMLF]
END
select 
YEAR(kpi.dateWorked) as 'Year', MONTH(kpi.dateWorked) as 'Month',DATENAME(MONTH,kpi.dateWorked) as 'MonthN',
kpi.install as 'IT',
jb.jobNo as 'ClientID',

kpi.dateWorked,
CONCAT(wo.idWO,'-',tk.task) as 'idWO',
po.idPO as 'Project Order',
kpi.size,
kpi.LF,
SUM(kpi.hoursST + kpi.hoursOT) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.dateWorked,kpi.install,jb.jobNo,CONCAT(wo.idWO,'-',tk.task),kpi.size,kpi.LF,kpi.description) as 'Hours',
SUM(((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF])) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.dateWorked,kpi.install,jb.jobNo,CONCAT(wo.idWO,'-',tk.task),kpi.size,kpi.LF,kpi.description) as 'II SQFT',
SUM(((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF]) + kpi.SQF) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.dateWorked,kpi.install,jb.jobNo,CONCAT(wo.idWO,'-',tk.task),kpi.size,kpi.LF,kpi.description) as 'Total SQF',
SUM(ROUND((((((kpi.[size]+2*kpi.[thinck])*PI())/12)*kpi.[LF]) + kpi.SQF) / (kpi.hoursST + kpi.hoursOT),2)) OVER (PARTITION BY YEAR(kpi.dateWorked),MONTH(kpi.dateWorked),kpi.dateWorked,kpi.install,jb.jobNo,CONCAT(wo.idWO,'-',tk.task),kpi.size,kpi.LF,kpi.description) as 'SQF PH',
kpi.[description] as 'Description'
INTO PBI.ACMLF
from KPI as kpi
inner join task as tk on tk.idAux = kpi.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo
where kpi.dateWorked between @StartDate and @EndDate and kpi.install like 'Asbestos' or kpi.install like 'ACM'
"
			Return _ACMLF
		End Get
		Set(ByVal value As String)
			_ACMLF = value
		End Set
	End Property

	Public Property AR_Inovices As String
		Get
			_AR_Inovices = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'ARInvoices')
BEGIN 
	drop table PBI.[ARInvoices]
END
select T1.[ClientID],T1.[PO],T1.[Invoice#],T1.[Amount],T1.[Invoice Date],T1.[Due Date],T1.[Past Due Days], Round(iif(T1.[Taxes]>0,(T1.[Amount])*(T1.[Taxes]/100),0),2) AS 'Taxes' 
INTO PBI.[ARInvoices] from (
select
jb.jobNo as 'ClientID' ,
po.idPO as 'PO',
inv.invoice as 'Invoice#',
ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and jb1.jobNo = wc1.jobNo
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
DATEDIFF(DAY,DATEADD(DAY, IIF(cl.payTerms='',0,CONVERT(INT, cl.payterms)), inv.invoiceDate),GETDATE()) as 'Past Due Days',
jb.Taxes
from invoice as inv
inner join projectOrder as po on po.idPO = inv.idPO
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = inv.idClient and jb.idClient = cl.idClient
where (inv.startDate between @StartDate and @EndDate or inv.FinalDate between @StartDate and @EndDate) and inv.[status] = 0
 ) as T1 where T1.Amount > 0"
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

select T1.[ClientID],T1.[Pay Terms],T1.[PO],T1.[Invoice],T1.[Invoice Date],T1.[Total Hours PO],T1.[Total Labor],T1.[Total Expenses],T1.[Total PerDiem],T1.[3rdParty],T1.[ScRent],T1.[CoEQ],T1.[Material],T1.[Subcontractors],T1.[Other],T1.[ExtraCostMaterial],T1.[Total Material],T1.[Total Cost], Round(iif(T1.[TX]>0,(T1.[Total Cost])*(T1.[TX]/100),0),2) AS 'Taxes' INTO PBI.[Invoices] from (select 
jb.jobNo as 'ClientID',
IIF(cl.payTerms='',0,cl.payTerms) as 'Pay Terms',
po.idPO as 'PO',
inv.invoice as 'Invoice',
CONVERT(nvarchar, inv.invoiceDate,101) as 'Invoice Date',
ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients as cl1 on cl1.idClient = jb1.idClient
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = jb1.jobNo 
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and hw1.dateWorked between inv.startDate and inv.FinalDate),0) 
as 'Total Hours PO',

ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients as cl1 on cl1.idClient = jb1.idClient
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = jb1.jobNo
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
ROUND(
ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
	
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients as cl1 on cl1.idClient = jb1.idClient
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = jb1.jobNo
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
where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate ),0 ),2)
as 'Total Cost',
jb.Taxes as 'TX'
from invoice as inv
inner join projectOrder as po on po.idPO = inv.idPO
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = inv.idClient and jb.idClient = cl.idClient
where inv.invoiceDate between @StartDate and @EndDate and inv.[status] = 0 ) as T1 where T1.[Total Cost] > 0"
			Return _Invoices
		End Get
		Set(value As String)

		End Set
	End Property


	Public Property InvoicesCost() As String
		Get
			_InvoicesCost = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'InvoicesCost')
BEGIN 
	drop table PBI.[InvoicesCost]
END

select T1.[ClientID],T1.[Year],T1.[Month],T1.[Invoice],T1.[Invoice Date],T1.[Total Hours],T1.[Total Labor],T1.[Total Expenses],T1.[Total PerDiem],T1.[3rdParty],T1.[ScRent],T1.[CoEQ],T1.[Material],T1.[Subcontractors],T1.[Other],T1.[ExtraCostMaterial],T1.[Total Material],T1.[Total Cost],Round(iif(T1.[Taxes]>0,(T1.[Total Cost])*(T1.[Taxes]/100),0),2) AS 'Taxes' INTO PBI.[InvoicesCost] 
from 
(select 
jb.jobNo as 'ClientID',
YEAR(inv.invoiceDate)as 'Year',
MONTH(inv.invoiceDate) as 'Month',
inv.invoice as 'Invoice',
CONVERT(nvarchar, inv.invoiceDate,101) as 'Invoice Date',
ISNULL((select sum(hw1.hoursST)+sum(hw1.hoursOT)+sum(hw1.hours3) as 'Total Hours' from hoursWorked as hw1 
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients as cl1 on cl1.idClient = jb1.idClient
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = jb1.jobNo 
	where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and hw1.dateWorked between inv.startDate and inv.FinalDate),0) 
as 'Total Hours',

ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients as cl1 on cl1.idClient = jb1.idClient
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = jb1.jobNo
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
ROUND(
ISNULL((select sum(hw1.hoursST*wc1.billingRate1)+sum(hw1.hoursOT*wc1.billingRateOT)+sum(hw1.hours3*wc1.billingRate3) as 'Labor' from hoursWorked as hw1 
	
	inner join task as tk1 on tk1.idAux = hw1.idAux 
	inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
	inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
	inner join job as jb1 on po1.jobNo = jb1.jobNo
	inner join clients as cl1 on cl1.idClient = jb1.idClient
	inner join workCode as wc1 on wc1.idWorkCode = hw1.idWorkCode and wc1.jobNo = jb1.jobNo
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
where po1.idPO = po.idPO and jb1.jobNo = jb.jobNo and cl1.idClient = inv.idClient and mtu1.dateMaterial between inv.startDate and inv.FinalDate ),0 ),2)
as 'Total Cost',
jb.Taxes
from invoice as inv
inner join projectOrder as po on po.idPO = inv.idPO
inner join job as jb on jb.jobNo = po.jobNo
inner join clients as cl on cl.idClient = inv.idClient and jb.idClient = cl.idClient
where inv.invoiceDate between @StartDate and @EndDate and inv.[status] = 0 ) as T1 where T1.[Total Cost] > 0"
			Return _InvoicesCost
		End Get
		Set(ByVal value As String)
			_InvoicesCost = value
		End Set
	End Property


	Public Property Craft() As String
		Get
			_craft = "IF EXISTS (SELECT * FROM INFORMATION_SCHEMA.TABLES where TABLE_SCHEMA = 'PBI' and TABLE_NAME = 'Craft')
BEGIN 
	drop table PBI.[Craft]
END
select distinct T2.[Year],T2.[ClientID],T2.[PO],T2.[MO#],T2.[Weekending],T2.[ST Hours],T2.[OT Hours],T2.[ST Cost],T2.[OT Cost],T2.[Class]
INTO PBI.Craft from (
select DISTINCT
T1.[Year],
T1.[ClientID],
T1.[PO],
T1.[MO#],
T1.[Weekending],
SUM(T1.[ST Hours]) OVER (PARTITION BY T1.[Year],T1.[PO],T1.[ClientID],T1.[MO#],T1.[Weekending],T1.[Class]) as 'ST Hours',
SUM(T1.[OT Hours]) OVER (PARTITION BY T1.[Year],T1.[PO],T1.[ClientID],T1.[MO#],T1.[Weekending],T1.[Class]) as 'OT Hours',
SUM(T1.[OT Cost]) OVER (PARTITION BY T1.[Year],T1.[PO],T1.[ClientID],T1.[MO#],T1.[Weekending],T1.[Class]) as 'OT Cost',
SUM(T1.[ST Cost]) OVER (PARTITION BY T1.[Year],T1.[PO],T1.[ClientID],T1.[MO#],T1.[Weekending],T1.[Class]) as 'ST Cost',
T1.[Class]
from(
select 
distinct
YEAR(hw.dateWorked) as 'Year',
jb.jobNo as 'ClientID',
po.idPO	as 'PO',
CONCAT(wo.idWO,'-',tk.task) as 'MO#',
DATEADD(DAY,IIF( DATEPART(DW,hw.dateWorked)=1,0, 7-(DATEPART(DW,hw.dateWorked)-1)),hw.dateWorked) as 'Weekending',
wc.name as 'Class',
SUM(hw.hoursST) OVER (PARTITION BY YEAR(hw.dateWorked),DATEADD(DAY,IIF( DATEPART(DW,hw.dateWorked)=1,0, 7-(DATEPART(DW,hw.dateWorked)-1)),hw.dateWorked),CONCAT(wo.idWO,'-',tk.task),po.idPO,jb.jobNo,wc.name) as 'ST Hours',
SUM(hw.hoursOT+ hw.hours3) OVER (PARTITION BY YEAR(hw.dateWorked),DATEADD(DAY,IIF( DATEPART(DW,hw.dateWorked)=1,0, 7-(DATEPART(DW,hw.dateWorked)-1)),hw.dateWorked),CONCAT(wo.idWO,'-',tk.task),po.idPO,jb.jobNo,wc.name) as 'OT Hours',
ROUND(SUM((hw.hoursOT*wc.billingRateOT) + (hw.hours3*wc.billingRate3)) OVER (PARTITION BY YEAR(hw.dateWorked),DATEADD(DAY,IIF( DATEPART(DW,hw.dateWorked)=1,0, 7-(DATEPART(DW,hw.dateWorked)-1)),hw.dateWorked),CONCAT(wo.idWO,'-',tk.task),po.idPO,jb.jobNo,wc.name),2) 'OT Cost',
ROUND(SUM(hw.hoursST*wc.billingRate1)  OVER (PARTITION BY YEAR(hw.dateWorked),DATEADD(DAY,IIF( DATEPART(DW,hw.dateWorked)=1,0, 7-(DATEPART(DW,hw.dateWorked)-1)),hw.dateWorked),CONCAT(wo.idWO,'-',tk.task),po.idPO,jb.jobNo,wc.name),2) as 'ST Cost'
from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and po.jobNo = wo.jobNo
inner join job as jb on jb.jobNo = po.jobNo 
left join workCode as wc on wc.idWorkCode = hw.idWorkCode and wc.jobNo = jb.jobNo
where hw.dateWorked between @StartDate and @EndDate and not wc.name like '%6.4%'
) AS T1
) AS T2
 ORDER BY T2.[Weekending],T2.[PO],T2.[ClientID]"
			Return _craft
		End Get
		Set(ByVal value As String)
			_craft = value
		End Set
	End Property
End Class