Imports System.Data.SqlClient
Imports System.Runtime.InteropServices
Imports Microsoft.Office.Core
Imports Microsoft.Office.Interop.Excel
Public Class ReportsExcel
    Inherits ConnectioDB
    Public Function createExcelUnderFourty(ByVal dateQuery As String) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("declare @GETDATE as date = '" + dateQuery + "'

select * from(select CONCAT(em.lastName, ' ', em.middleName, ' ',em.firstName) as 'Employee ID' ,
em.numberEmploye as 'Employee Number',
ISNULL((select sum(hw.hoursST)+sum(hw.hoursOT)+sum(hw.hours3) from hoursWorked as hw 
where idEmployee = em.idEmployee and hw.dateWorked = IIF(DATEPART(dw,@GETDATE)=1,
															DATEADD(dd, -6 , @GETDATE),
															DATEADD(dd,-(DATEPART(dw,@GETDATE)-1)+1,@GETDATE))
),0)as 'Monday',
ISNULL((select sum(hw.hoursST)+sum(hw.hoursOT)+sum(hw.hours3) from hoursWorked as hw 
where idEmployee = em.idEmployee and hw.dateWorked = IIF(DATEPART(dw,@GETDATE)=1,
															DATEADD(dd, -5 , @GETDATE),
															DATEADD(dd,-(DATEPART(dw,@GETDATE)-1)+2,@GETDATE))
),0)as 'Tuesday',
ISNULL((select sum(hw.hoursST)+sum(hw.hoursOT)+sum(hw.hours3) from hoursWorked as hw 
where idEmployee = em.idEmployee and hw.dateWorked = IIF(DATEPART(dw,@GETDATE)=1,
															DATEADD(dd, -4 , @GETDATE),
															DATEADD(dd,-(DATEPART(dw,@GETDATE)-1)+3,@GETDATE))
),0)as 'Wednesday',
ISNULL((select sum(hw.hoursST)+sum(hw.hoursOT)+sum(hw.hours3) from hoursWorked as hw 
where idEmployee = em.idEmployee and hw.dateWorked = IIF(DATEPART(dw,@GETDATE)=1,
															DATEADD(dd, -3 , @GETDATE),
															DATEADD(dd,-(DATEPART(dw,@GETDATE)-1)+4,@GETDATE))
),0)as 'Thursday',
ISNULL((select sum(hw.hoursST)+sum(hw.hoursOT)+sum(hw.hours3) from hoursWorked as hw 
where idEmployee = em.idEmployee and hw.dateWorked = IIF(DATEPART(dw,@GETDATE)=1,
															DATEADD(dd, -2 , @GETDATE),
															DATEADD(dd,-(DATEPART(dw,@GETDATE)-1)+5,@GETDATE)) 
),0)as 'Friday',
ISNULL((select sum(hw.hoursST)+sum(hw.hoursOT)+sum(hw.hours3) from hoursWorked as hw 
where idEmployee = em.idEmployee and hw.dateWorked = IIF(DATEPART(dw,@GETDATE)=1,
															DATEADD(dd, -1 , @GETDATE),
															DATEADD(dd,-(DATEPART(dw,@GETDATE)-1)+6,@GETDATE)) 
),0)as 'Saturday',
ISNULL((select sum(hw.hoursST)+sum(hw.hoursOT)+sum(hw.hours3) from hoursWorked as hw 
where idEmployee = em.idEmployee and hw.dateWorked = IIF(DATEPART(dw,@GETDATE)=1,
															@GETDATE,
															DATEADD(dd,-(DATEPART(dw,@GETDATE)-1)+7,@GETDATE)) 
),0)as 'Sunday',
(select sum(hw.hoursST)+sum(hw.hoursOT)+sum(hw.hours3) from hoursWorked as hw 
where idEmployee = em.idEmployee and hw.dateWorked between IIF(DATEPART(dw,@GETDATE)=1,
															DATEADD(dd, -6 , @GETDATE),
															DATEADD(dd,-(DATEPART(dw,@GETDATE)-1)+1,@GETDATE))
														AND
														   IIF(DATEPART(dw,@GETDATE)=1,
															@GETDATE,
															DATEADD(dd,-(DATEPART(dw,@GETDATE)-1)+7,@GETDATE))	 
)as 'Total',
convert(varchar, (select IIF(DATEPART(dw,@GETDATE)=1,@GETDATE,DATEADD(dd,-(DATEPART(dw,@GETDATE)-1)+7,@GETDATE))),101) as 'WeekEnding'
from employees as em) as T1 where T1.Total is not Null and T1.Total < 40", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New Data.DataTable
                da.Fill(dt)
                If dt.Rows.Count() > 0 Then
                    Dim flagOpen As Boolean = False
                    Dim ruta As String = ""
                    Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
                    Dim libro = ApExcel.Workbooks.Add()
                    Try
                        Dim Hoja1 = libro.Worksheets(1)
                        Dim count As Integer = 1
                        With Hoja1.Range("A1:L1")
                            .Font.Bold = True
                            .Font.ColorIndex = 1
                            With .Interior
                                .ColorIndex = 15
                            End With
                            .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black)
                        End With
                        Dim countColum As Integer = 1
                        For Each colm As Data.DataColumn In dt.Columns
                            Hoja1.Cells(count, countColum) = colm.ColumnName.ToString()
                            countColum += 1
                        Next
                        Hoja1.Cells(count, countColum) = "Notes"
                        count += 1
                        For Each row As Data.DataRow In dt.Rows
                            Hoja1.Cells(count, 1) = row.ItemArray(0).ToString()
                            Hoja1.Cells(count, 2) = row.ItemArray(1).ToString()
                            Hoja1.Cells(count, 3) = row.ItemArray(2).ToString()
                            Hoja1.Cells(count, 4) = row.ItemArray(3).ToString()
                            Hoja1.Cells(count, 5) = row.ItemArray(4).ToString()
                            Hoja1.Cells(count, 6) = row.ItemArray(5).ToString()
                            Hoja1.Cells(count, 7) = row.ItemArray(6).ToString()
                            Hoja1.Cells(count, 8) = row.ItemArray(7).ToString()
                            Hoja1.Cells(count, 9) = row.ItemArray(8).ToString()
                            Hoja1.Cells(count, 10) = row.ItemArray(9).ToString()
                            Hoja1.Cells(count, 11) = row.ItemArray(10).ToString()
                            count += 1
                        Next
                        Hoja1.Name = "Week EE Under Forty Final"
                        Dim opFile As New SaveFileDialog
                        opFile.DefaultExt = "xlsx"
                        opFile.FileName = "Week EE Under Forty Final"
                        If DialogResult.OK = opFile.ShowDialog() Then
                            ruta = opFile.FileName
                            libro.SaveAs(opFile.FileName)
                            MsgBox("Successful")
                            NAR(Hoja1)
                            If DialogResult.Yes = MessageBox.Show("Successful" + vbCrLf + "Would you like to open the excel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                flagOpen = True
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message())
                    Finally
                        libro.Close()
                        NAR(libro)
                        ApExcel.Quit()
                        NAR(ApExcel)
                        If flagOpen Then
                            System.Diagnostics.Process.Start(ruta)
                        End If
                    End Try
                Else
                    MessageBox.Show("We can not found Any Record?")
                End If
            End If
            Return True
        Catch ex As Exception
            Return False
        Finally
            desconectar()
        End Try
    End Function

    Public Function createExcelMoutlyHours(ByVal clNumber As String, ByVal StartDate As String, Optional finalDate As String = Nothing, Optional JobNo As String = Nothing) As Boolean
        Try
            conectar()
            Dim cmd As New SqlCommand("
declare @GetDate as Date = '" + StartDate + "'
declare @StarDate as date = " + If(finalDate IsNot Nothing, "'" + StartDate + "'", "(select DATEADD(dd,-(DATEPART(dd,@GetDate)-1),@GetDate))") + "
declare @FinalDate as date = " + If(finalDate IsNot Nothing, "'" + finalDate + "'", "(select DATEADD(dd, -(DATEPART(dd,@GetDate)),DATEADD(mm,1,@GetDate)))") + "
declare @numClient as int = " + clNumber + "
select T1.[Mounth],T1.[WO ST],T1.[WO OT],T1.[WO XT], (T1.[WO ST]+T1.[WO OT]+T1.[WO XT]) as 'Total',T1.Mo,T1.idPO
from (select distinct
(select DATENAME(mm,hw.dateWorked))as 'Mounth',
(select sum(hw1.hoursST) from hoursWorked as hw1 
inner join task as tk1 on tk1.idAux = hw1.idAux 
inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
inner join job as jb1 on jb1.jobNo = jb1.jobNo 
inner join clients as cl1 on cl1.idClient = jb1.idClient
where
		DATENAME(mm,hw.dateWorked) = DATENAME(mm,hw1.dateWorked)
		and (po1.idPO = po.idPO) and cl1.numberClient = @numClient) as 'WO ST',
(select sum(hw1.hoursOT) from hoursWorked as hw1 
inner join task as tk1 on tk1.idAux = hw1.idAux 
inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
inner join job as jb1 on jb1.jobNo = jb1.jobNo
inner join clients as cl1 on cl1.idClient = jb1.idClient
where
		DATENAME(mm,hw.dateWorked) = DATENAME(mm,hw1.dateWorked)
		and (po1.idPO = po.idPO)and cl1.numberClient = @numClient ) as 'WO OT',
(select sum(hw1.hours3) from hoursWorked as hw1 
inner join task as tk1 on tk1.idAux = hw1.idAux 
inner join workOrder as wo1 on wo1.idAuxWO = tk1.idAuxWO
inner join projectOrder as po1 on po1.idPO = wo1.idPO and wo1.jobNo = po1.jobNo
inner join job as jb1 on jb1.jobNo = jb1.jobNo
inner join clients as cl1 on cl1.idClient = jb1.idClient
where
		DATENAME(mm,hw.dateWorked) = DATENAME(mm,hw1.dateWorked)
		and (po1.idPO = po.idPO) and cl1.numberClient = @numClient ) as 'WO XT',
(select DATEPART(mm,hw.dateWorked)) as 'Mo',
po.idPO
from hoursWorked as hw 
inner join task as tk on tk.idAux = hw.idAux 
inner join workOrder as wo on wo.idAuxWO = tk.idAuxWO
inner join projectOrder as po on po.idPO = wo.idPO and wo.jobNo = po.jobNo
inner join job as jb on jb.jobNo = jb.jobNo
inner join clients as cl on cl.idClient = jb.idClient
where hw.dateWorked between @StarDate and @FinalDate and cl.numberClient = @numClient " + If(JobNo IsNot Nothing, "and  jb.jobNo = " + JobNo + "", "") + " 
) as T1 where (T1.[WO ST] + T1.[WO OT] + T1.[WO XT] )>0", conn)
            If cmd.ExecuteNonQuery Then
                Dim da As New SqlDataAdapter(cmd)
                Dim dt As New Data.DataTable
                da.Fill(dt)
                If dt.Rows.Count() > 0 Then
                    Dim flagOpen As Boolean = False
                    Dim ruta As String = ""
                    Dim ApExcel = New Microsoft.Office.Interop.Excel.Application
                    Dim libro = ApExcel.Workbooks.Add()
                    Try
                        Dim Hoja1 = libro.Worksheets(1)
                        Dim count As Integer = 1
                        With Hoja1.Range("A1:H1")
                            .Font.Bold = True
                            .Font.ColorIndex = 1
                            With .Interior
                                .ColorIndex = 15
                            End With
                            .BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, Color.Black)
                        End With
                        Dim countColum As Integer = 1
                        For Each colm As Data.DataColumn In dt.Columns
                            If countColum = 5 Then
                                Hoja1.Cells(count, countColum) = colm.ColumnName.ToString()
                                countColum += 1
                                Hoja1.Cells(count, countColum) = "Employees"
                            Else
                                Hoja1.Cells(count, countColum) = colm.ColumnName.ToString()
                            End If
                            countColum += 1
                        Next
                        count += 1
                        For Each row As Data.DataRow In dt.Rows
                            Hoja1.Cells(count, 1) = row.ItemArray(0).ToString()
                            Hoja1.Cells(count, 2) = row.ItemArray(1).ToString()
                            Hoja1.Cells(count, 3) = row.ItemArray(2).ToString()
                            Hoja1.Cells(count, 4) = row.ItemArray(3).ToString()
                            Hoja1.Cells(count, 5) = row.ItemArray(4).ToString()
                            Hoja1.Cells(count, 6) = ""
                            Hoja1.Cells(count, 7) = row.ItemArray(5).ToString()
                            Hoja1.Cells(count, 8) = row.ItemArray(6).ToString()
                            count += 1
                        Next
                        Hoja1.Name = "WO MhrS By Date Range"
                        Dim opFile As New SaveFileDialog
                        opFile.DefaultExt = "xlsx"
                        opFile.FileName = "WO MhrS By Date Range"
                        If DialogResult.OK = opFile.ShowDialog() Then
                            ruta = opFile.FileName
                            libro.SaveAs(opFile.FileName)
                            MsgBox("Successful")
                            NAR(Hoja1)
                            If DialogResult.Yes = MessageBox.Show("Successful" + vbCrLf + "Would you like to open the excel?", "Message", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                                flagOpen = True
                            End If
                        End If
                    Catch ex As Exception
                        MsgBox(ex.Message())
                    Finally
                        libro.Close()
                        NAR(libro)
                        ApExcel.Quit()
                        NAR(ApExcel)
                        If flagOpen Then
                            System.Diagnostics.Process.Start(ruta)
                        End If
                    End Try
                Else
                    MessageBox.Show("We can not found Any Record?")
                End If
            End If
            Return True
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        Finally
            desconectar()
        End Try
    End Function
End Class
