﻿Public Class Estimating
    Dim mtdElevation As New ElevationEstimation
    Dim mtdFactor As New MetodosFactor
    Dim mtdClients As New ClientsEST
    Dim mtdEstimation As New MetodosEstimating
    Dim tblProjects As New Data.DataTable
    Dim tblDrawing As New Data.DataTable
    Dim tblAllSCFTags As New Data.DataTable
    Dim tblScaffoldProjects As New Data.DataTable
    Dim idClient As String
    Dim idDrawing As String = ""
    Dim selectTable As String
    Dim idProject As String = ""
    Dim flagNewDrawing As Boolean = False
    Private Sub Estimating_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        tblProjects = mtdClients.llenarComboClientsEst(cmbProjects)
        tblDrawing = mtdEstimation.selectProjectsDrawing()
        tblAllSCFTags = mtdEstimation.selectSacffoldEst()
        If tblProjects.Rows.Count > 0 Then
            Dim array() As String = cmbProjects.Items(0).ToString().Split(" ")
            idClient = array(0)
            idProject = tblProjects.Rows(0).ItemArray(3).ToString()
            For Each row As Data.DataRow In tblDrawing.Rows
                If idProject = row.ItemArray(2) Then
                    idDrawing = row.ItemArray(0)
                    Exit For
                End If
            Next
            If idDrawing <> "" Then
                cargarDatosDrawing(idClient, idProject, idDrawing)
            End If
            cmbProjects.SelectedIndex = 0
        End If
    End Sub
    Private Sub btnSalir_Click(sender As Object, e As EventArgs) Handles btnSalir.Click
        Me.Close()
    End Sub
    Private Sub btnNextProject_Click(sender As Object, e As EventArgs) Handles btnNextProject.Click
        Try
            If cmbProjects.SelectedItem IsNot Nothing Then
                Dim rowIndex As Integer = cmbProjects.SelectedIndex
                If (tblProjects.Rows.Count - 1) >= (rowIndex + 1) Then
                    rowIndex += 1
                    txtUnit.Text = tblProjects.Rows(rowIndex).ItemArray(4)
                    txtDescription.Text = tblProjects.Rows(rowIndex).ItemArray(5)
                    idClient = tblProjects.Rows(rowIndex).ItemArray(1)
                    cmbProjects.SelectedIndex = cmbProjects.SelectedIndex + 1
                    cmbProjects.Text = tblProjects.Rows(rowIndex).ItemArray(3)
                    idProject = tblProjects.Rows(rowIndex).ItemArray(3)
                Else
                    rowIndex = 0
                    txtUnit.Text = tblProjects.Rows(rowIndex).ItemArray(4)
                    txtDescription.Text = tblProjects.Rows(rowIndex).ItemArray(5)
                    idClient = tblProjects.Rows(rowIndex).ItemArray(1)
                    cmbProjects.SelectedIndex = 0
                    cmbProjects.Text = tblProjects.Rows(rowIndex).ItemArray(3)
                    idProject = tblProjects.Rows(rowIndex).ItemArray(3)
                End If
            ElseIf cmbProjects.Items.Count > 0 Then
                Dim rowIndex As Integer = cmbProjects.SelectedIndex
                If tblProjects.Rows(rowIndex + 1) IsNot Nothing Then
                    rowIndex += 1
                    txtUnit.Text = tblProjects.Rows(rowIndex).ItemArray(4)
                    txtDescription.Text = tblProjects.Rows(rowIndex).ItemArray(5)
                    idClient = tblProjects.Rows(rowIndex).ItemArray(1)
                    cmbProjects.SelectedIndex = cmbProjects.SelectedIndex + 1
                    cmbProjects.Text = tblProjects.Rows(rowIndex).ItemArray(3)
                    idProject = tblProjects.Rows(rowIndex).ItemArray(3)
                End If
            End If
            Dim rowsQuery() As Data.DataRow = tblAllSCFTags.Select("projectId='" + idProject + "' and numberClient=" + idClient + "")
            If rowsQuery.Length > 0 Then
                cargarDatosDrawing(idClient, idProject, rowsQuery(0).ItemArray(1))
            Else
                idDrawing = ""
                tblSCFDrawing.Rows.Clear()
                txtDrawingNum.Text = ""
                txtDescriptionDrawing.Text = ""
            End If

        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnAfterProjects_Click(sender As Object, e As EventArgs) Handles btnAfterProjects.Click
        Try
            If cmbProjects.SelectedItem IsNot Nothing Then
                Dim rowIndex As Integer = cmbProjects.SelectedIndex
                If (rowIndex - 1) > -1 Then
                    rowIndex -= 1
                    txtUnit.Text = tblProjects.Rows(rowIndex).ItemArray(4)
                    txtDescription.Text = tblProjects.Rows(rowIndex).ItemArray(5)
                    idClient = tblProjects.Rows(rowIndex).ItemArray(1)
                    cmbProjects.SelectedIndex = cmbProjects.SelectedIndex - 1
                    cmbProjects.Text = tblProjects.Rows(rowIndex).ItemArray(3)
                    idProject = tblProjects.Rows(rowIndex).ItemArray(3)
                Else
                    rowIndex = (tblProjects.Rows.Count() - 1)
                    txtUnit.Text = tblProjects.Rows(rowIndex).ItemArray(4)
                    txtDescription.Text = tblProjects.Rows(rowIndex).ItemArray(5)
                    idClient = tblProjects.Rows(rowIndex).ItemArray(1)
                    cmbProjects.SelectedIndex = (tblProjects.Rows.Count() - 1)
                    cmbProjects.Text = tblProjects.Rows(rowIndex).ItemArray(3)
                    idProject = tblProjects.Rows(rowIndex).ItemArray(3)
                End If
            ElseIf cmbProjects.Items.Count > 0 Then
                Dim rowIndex As Integer = cmbProjects.SelectedIndex
                If rowIndex = -1 And tblProjects.Rows.Count > 0 Then
                    rowIndex = tblProjects.Rows().Count - 1
                    txtUnit.Text = tblProjects.Rows(rowIndex).ItemArray(4)
                    txtDescription.Text = tblProjects.Rows(rowIndex).ItemArray(5)
                    idClient = tblProjects.Rows(rowIndex).ItemArray(1)
                    cmbProjects.SelectedIndex = tblProjects.Rows.Count - 1
                    cmbProjects.Text = tblProjects.Rows(rowIndex).ItemArray(3)
                    idProject = tblProjects.Rows(rowIndex).ItemArray(3)
                End If
            End If
            Dim rowsQuery() As Data.DataRow = tblAllSCFTags.Select("projectId='" + idProject + "' and numberClient=" + idClient + "")
            If rowsQuery.Length > 0 Then
                cargarDatosDrawing(idClient, idProject, rowsQuery(0).ItemArray(1))
            Else
                idDrawing = ""
                tblSCFDrawing.Rows.Clear()
                txtDrawingNum.Text = ""
                txtDescriptionDrawing.Text = ""
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Select Case selectTable
            Case "SCF"
                If validarRowSCF() And idProject <> "" Then
                    If mtdEstimation.saveUpdateSCFDrawing(tblSCFDrawing, txtDrawingNum.Text, txtDescriptionDrawing.Text, idProject, If(idDrawing = "", "", idDrawing)) Then
                        MsgBox("Successful")
                        Dim array() As String = cmbProjects.Items(0).ToString().Split(" ")
                        mtdEstimation.selectSCFDrawingProject(tblSCFDrawing, array(0), idProject, idDrawing)
                        idDrawing = txtDrawingNum.Text
                        tblProjects = mtdClients.llenarComboClientsEst(cmbProjects)
                        tblAllSCFTags = mtdEstimation.selectSacffoldEst()
                        btnAfterDrawing.Enabled = True
                        btnNextDrawingN.Enabled = True
                        btnFindDrawingN.Enabled = True
                        btnCancel.Enabled = False
                    Else
                        MsgBox("Error, try again or refresh the Window")
                    End If
                Else
                    MessageBox.Show("Please check the information, Is likely that you have not assigned information.", "Impotant", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                End If
            Case ""
            Case ""
        End Select
    End Sub
    Private Function validarRowSCF() As Boolean
        Try
            Dim flagError As Boolean = True
            For Each row As DataGridViewRow In tblSCFDrawing.SelectedRows()
                If row.Cells("Tag").Value <> "" Then
                    For Each cell As DataGridViewCell In row.Cells
                        If cell.ColumnIndex <= 4 And cell.ColumnIndex > 1 Then
                            If cell.Value Is Nothing Or cell.Value = "" Then
                                flagError = False
                                Exit For
                            End If
                        ElseIf cell.ColumnIndex > 4 Then
                            If cell.Value Is Nothing Or cell.Value.ToString() = "" Then
                                cell.Value = "0"
                            End If
                        End If
                    Next
                    If flagError = False Then
                        Exit For
                    End If

                End If
            Next
            Return flagError
        Catch ex As Exception
            MsgBox(ex.Message())
            Return False
        End Try
    End Function
    Private Sub tblSCFDrawing_Enter(sender As Object, e As EventArgs) Handles tblSCFDrawing.Enter
        selectTable = "SCF"
    End Sub
    Private Sub tblSCFDrawing_CellEndEdit(sender As Object, e As DataGridViewCellEventArgs) Handles tblSCFDrawing.CellEndEdit
        Try
            If e.ColumnIndex = 1 And tblSCFDrawing.CurrentRow.Cells("TagId").Value Is Nothing Then
                Dim rowsQuery() As Data.DataRow = tblAllSCFTags.Select("tag='" + tblSCFDrawing.CurrentRow.Cells("Tag").Value + "'")
                If rowsQuery.Length > 0 Then
                    tblSCFDrawing.CurrentRow.Cells("Tag").Value = ""
                    MessageBox.Show("The typed 'Tag' has already been inserted. Please assign a new 'Tag'.", "Important", MessageBoxButtons.OK, MessageBoxIcon.Exclamation)
                End If
            End If
        Catch ex As Exception

        End Try
    End Sub
    Private Sub tblSCFDrawing_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles tblSCFDrawing.CellClick
        Select Case e.ColumnIndex
            Case 2 'Labor Rate 
                Try
                    If tblSCFDrawing.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        Dim cmbLabor As New DataGridViewComboBoxCell
                        With cmbLabor
                            mtdFactor.llenarComboCellLaporRate(cmbLabor)
                        End With
                        tblSCFDrawing.CurrentRow.Cells("LaborRate") = cmbLabor
                        'Else
                        '    tblSCFDrawing.CurrentRow.Cells("LaborRate") = tblSCFDrawing.CurrentCell
                    End If
                Catch ex As Exception

                End Try
            Case 3 'Type Scaffold Nomal or Tower
                Try
                    If tblSCFDrawing.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        Dim cmbType As New DataGridViewComboBoxCell
                        With cmbType
                            mtdFactor.llenarComboCellUnitRate(cmbType)
                        End With
                        tblSCFDrawing.CurrentRow.Cells("TypeSC") = cmbType
                        'Else
                        '    tblSCFDrawing.CurrentRow.Cells("TypeSC") = tblSCFDrawing.CurrentCell
                    End If
                Catch ex As Exception

                End Try
            Case 4
                Try
                    If tblSCFDrawing.CurrentCell.GetType.Name = "DataGridViewTextBoxCell" Then
                        Dim cmbEnviroment As New DataGridViewComboBoxCell
                        With cmbEnviroment
                            mtdFactor.llenarComboCellEnviroment(cmbEnviroment)
                        End With
                        tblSCFDrawing.CurrentRow.Cells("Enviroment") = cmbEnviroment
                        'Else
                        '    tblSCFDrawing.CurrentRow.Cells("Enviroment") = tblSCFDrawing.CurrentCell
                    End If
                Catch ex As Exception

                End Try
        End Select
    End Sub
    Dim clmIndexSCFDrawing
    Public Sub cmb_SelectedIndexChangued(sender As Object, e As EventArgs)
        Dim cmb As ComboBox = CType(sender, ComboBox)
        Select Case tblSCFDrawing.CurrentCell.ColumnIndex
            Case 2
                tblSCFDrawing.CurrentCell.Value = cmb.Text
            Case 3
                tblSCFDrawing.CurrentCell.Value = cmb.Text
            Case 4
                tblSCFDrawing.CurrentCell.Value = cmb.Text
        End Select
    End Sub
    Private Sub tblSCFDrawing_EditingControlShowing(sender As Object, e As DataGridViewEditingControlShowingEventArgs) Handles tblSCFDrawing.EditingControlShowing
        Dim Index = tblSCFDrawing.CurrentCell.ColumnIndex
        If Index = 2 Or Index = 3 Or Index = 4 Then
            Dim typecell = tblSCFDrawing.CurrentCell.GetType.ToString
            If Not typecell = "System.Windows.Forms.DataGridViewTextBoxCell" Then
                Dim cb As ComboBox = CType(e.Control, ComboBox)
                If e.Control IsNot Nothing Then
                    RemoveHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued
                    AddHandler cb.SelectedIndexChanged, AddressOf cmb_SelectedIndexChangued
                End If
            End If
        End If
    End Sub
    Private Sub btnNew_Click(sender As Object, e As EventArgs) Handles btnNew.Click
        Try
            btnCancel.Visible = True
            flagNewDrawing = True
            idDrawing = ""
            tblSCFDrawing.Rows.Clear()
            txtDrawingNum.Text = ""
            txtDescriptionDrawing.Text = ""
            btnAfterDrawing.Enabled = False
            btnNextDrawingN.Enabled = False
            btnFindDrawingN.Enabled = False
        Catch ex As Exception

        End Try
    End Sub

    Private Sub cmbProjects_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbProjects.SelectedIndexChanged
        Dim rowindex = cmbProjects.SelectedIndex
        txtUnit.Text = tblProjects.Rows(rowindex).ItemArray(4)
        txtDescription.Text = tblProjects.Rows(rowindex).ItemArray(5)
        idClient = tblProjects.Rows(rowindex).ItemArray(1)
        cmbProjects.Text = tblProjects.Rows(rowindex).ItemArray(3)
        idProject = tblProjects.Rows(rowIndex).ItemArray(3)
    End Sub

    Private Sub btnAfterDrawing_Click(sender As Object, e As EventArgs) Handles btnAfterDrawing.Click
        Try
            Dim project As String = ""
            Dim drawing As String = ""
            Dim client As String = ""
            Dim rowIndex As Integer = -1
            For Each row As Data.DataRow In tblDrawing.Rows()
                rowIndex += 1
                If row.ItemArray(2) = idProject And row.ItemArray(0) = idDrawing Then
                    Exit For
                End If
            Next
            If rowIndex = 0 Then
                project = tblDrawing.Rows(tblDrawing.Rows.Count - 1).ItemArray(2)
                drawing = tblDrawing.Rows(tblDrawing.Rows.Count - 1).ItemArray(0)
                idDrawing = tblDrawing.Rows(tblDrawing.Rows.Count - 1).ItemArray(0)
                client = tblDrawing.Rows(tblDrawing.Rows.Count - 1).ItemArray(3)
                cargarDatosDrawing(client, project, drawing)
            ElseIf rowIndex <> -1 Then
                project = tblDrawing.Rows(rowIndex - 1).ItemArray(2)
                drawing = tblDrawing.Rows(rowIndex - 1).ItemArray(0)
                idDrawing = tblDrawing.Rows(rowIndex - 1).ItemArray(0)
                client = tblDrawing.Rows(rowIndex - 1).ItemArray(3)
                cargarDatosDrawing(client, project, drawing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnNextDrawingN_Click(sender As Object, e As EventArgs) Handles btnNextDrawingN.Click
        Try
            Dim project As String = ""
            Dim drawing As String = ""
            Dim client As String = ""
            Dim rowIndex As Integer = -1
            For Each row As Data.DataRow In tblDrawing.Rows()
                rowIndex += 1
                If row.ItemArray(2) = idProject And row.ItemArray(0) = idDrawing Then
                    Exit For
                End If
            Next
            If rowIndex = tblDrawing.Rows.Count - 1 Then
                project = tblDrawing.Rows(0).ItemArray(2)
                drawing = tblDrawing.Rows(0).ItemArray(0)
                idDrawing = tblDrawing.Rows(0).ItemArray(0)
                client = tblDrawing.Rows(0).ItemArray(3)
                cargarDatosDrawing(client, project, drawing)
            Else
                project = tblDrawing.Rows(rowIndex + 1).ItemArray(2)
                drawing = tblDrawing.Rows(rowIndex + 1).ItemArray(0)
                idDrawing = tblDrawing.Rows(rowIndex + 1).ItemArray(0)
                client = tblDrawing.Rows(rowIndex + 1).ItemArray(3)
                cargarDatosDrawing(client, project, drawing)
            End If
        Catch ex As Exception
        End Try
    End Sub

    Private Sub btnCancel_Click(sender As Object, e As EventArgs) Handles btnCancel.Click
        Try
            flagNewDrawing = False
            btnCancel.Visible = False
            btnAfterDrawing.Enabled = True
            btnNextDrawingN.Enabled = True
            btnFindDrawingN.Enabled = True
        Catch ex As Exception

        End Try
    End Sub

    Private Function cargarDatosDrawing(ByVal clientNum As String, ByVal Project As String, ByVal Drawing As String) As Boolean
        Try
            Dim itemIndex As Integer = -1
            Dim rowsQuery() As Data.DataRow = tblDrawing.Select("projectId='" + Project + "' and  idDrawingNum = '" + Drawing + "'")
            If rowsQuery.Length > 0 Then
                txtDrawingNum.Text = rowsQuery(0).ItemArray(0)
                idDrawing = rowsQuery(0).ItemArray(0)
                txtDescriptionDrawing.Text = rowsQuery(0).ItemArray(1)
                tblScaffoldProjects = mtdEstimation.selectSCFDrawingProject(tblSCFDrawing, clientNum, Project, Drawing)
            End If
            If idClient <> clientNum Then
                For Each item As Object In cmbProjects.Items
                    itemIndex += 1
                    Dim array() As String = item.ToString.Split(" ")
                    If array(0) = clientNum Then
                        cmbProjects.SelectedIndex = itemIndex
                    End If
                Next
            End If
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

End Class