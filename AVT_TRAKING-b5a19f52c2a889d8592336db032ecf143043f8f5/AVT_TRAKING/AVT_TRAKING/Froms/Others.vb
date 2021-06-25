Public Class Others
    Dim mtdOthers As New MetodosOthers

    Dim auxEmploye As String

    Private Sub Others_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        mtdOthers.llenarListTyposEmployees(lstTypeEmployee)
        mtdOthers.llenarListExpCodes(lstExpCode)
        mtdOthers.llenarListWorkTMLump(lstWTMLS)
        mtdOthers.llenarCostDistrinbution(lstCostDistribution)
        mtdOthers.llenarCostCode(lstCostCode)
    End Sub

    Private Sub btnAdd_Click(sender As Object, e As EventArgs) Handles btnAdd.Click
        lstTypeEmployee.Items.Add(txtTypeEmployee.Text)
        mtdOthers.agregarTypeEmployee(txtTypeEmployee.Text)
    End Sub

    Private Sub btnDeleteTypeEmployee_Click(sender As Object, e As EventArgs) Handles btnDeleteTypeEmployee.Click
        Dim item1 As String = lstTypeEmployee.SelectedItem
        lstTypeEmployee.Items.Remove(lstTypeEmployee.SelectedItem)
        mtdOthers.deleteTypeEmployee(item1)
    End Sub

    Private Sub btnUpdateTypeEmploye_Click(sender As Object, e As EventArgs) Handles btnUpdateTypeEmploye.Click
        If btnUpdateTypeEmploye.Text = "Update" Then
            btnUpdateTypeEmploye.Text = "Save"
            txtTypeEmployee.Text = lstTypeEmployee.SelectedItem
            auxEmploye = lstTypeEmployee.SelectedItem
        Else
            If txtTypeEmployee.Text = "" Then
                Dim result As DialogResult = MessageBox.Show("Would you like to cancel?", "Important", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning)
                If result = DialogResult.Cancel Then
                    txtTypeEmployee.Text = ""
                    btnUpdateTypeEmploye.Text = "Update"
                End If
            Else
                btnUpdateTypeEmploye.Text = "Update"
                mtdOthers.updateTypeEmploye(txtTypeEmployee.Text, auxEmploye)
                lstTypeEmployee.Items.RemoveAt(lstTypeEmployee.SelectedIndex)
                lstTypeEmployee.Items.Add(txtTypeEmployee.Text)
                txtTypeEmployee.Text = ""
            End If
        End If
    End Sub

    '==============================================================================================
    '==============================================================================================
    '==============================================================================================

    Dim auxExpCode As New ListViewItem

    Private Sub btnAddExpCode_Click(sender As Object, e As EventArgs) Handles btnAddExpCode.Click
        Dim num As Integer
        Dim name As String
        Dim array() As String
        Dim delimitadores() As String = {" ", ".", ",", "|"}
        array = txtExpCode.Text.Split(delimitadores, StringSplitOptions.None)
        Dim solonumero() As String = array(0).Split()
        Dim flag As Boolean = False
        For Each letra As Char In solonumero
            If Not Char.IsDigit(letra) Then
                flag = True
            End If
        Next

        If flag = True Then
            MsgBox("Check the number it could be have caracters no valid.")
        Else
            num = array(0)
            name = array(1)
            Dim itemNev As ListViewItem = mtdOthers.addExpCode(num, name)
            lstExpCode.Items.Add(itemNev)
        End If
    End Sub

    Private Sub btnUpdateExpCode_Click(sender As Object, e As EventArgs) Handles btnUpdateExpCode.Click
        If btnUpdateExpCode.Text = "Update" Then
            btnUpdateExpCode.Text = "Save"
            txtExpCode.Text = lstExpCode.SelectedItems.Item(0).SubItems(1).Text
            auxExpCode = lstExpCode.SelectedItems.Item(0)
        Else
            If DialogResult.Yes = MessageBox.Show("Would you like to save it? " + vbCrLf + "If you accept it, you will change the records" + vbCrLf + "in your already saved projects.", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                mtdOthers.updateExpCode(txtExpCode.Text, auxExpCode.SubItems(1).Text)
                lstExpCode.SelectedItems(0).SubItems(1).Text = txtExpCode.Text
                txtExpCode.Text = ""
                btnUpdateExpCode.Text = "Update"
            Else
                txtExpCode.Text = ""
                btnUpdateExpCode.Text = "Update"
            End If
        End If
    End Sub

    Private Sub btnDeleteExpCode_Click(sender As Object, e As EventArgs) Handles btnDeleteExpCode.Click
        If lstExpCode.SelectedItems.Count = 1 Then
            If mtdOthers.deleteExpCode(lstExpCode.SelectedItems(0).SubItems(1).Text) Then
                lstExpCode.SelectedItems(0).Remove()
            End If
        End If
    End Sub

    '==============================================================================================
    '==============================================================================================
    '==============================================================================================

    Private Sub btnAddWTMLS_Click(sender As Object, e As EventArgs) Handles btnAddWTMLS.Click
        If txtWTMLS.Text <> "" Then
            mtdOthers.addWTMLS(txtWTMLS.Text)
            lstWTMLS.Items.Add(txtWTMLS.Text)
            txtWTMLS.Text = ""
        End If
    End Sub
    Dim auxWTNLS As ListViewItem
    Private Sub btnUpdateWTMLS_Click(sender As Object, e As EventArgs) Handles btnUpdateWTMLS.Click
        If btnUpdateWTMLS.Text = "Update" Then
            txtWTMLS.Text = lstWTMLS.SelectedItems(0).Text
            btnUpdateWTMLS.Text = "Save"
            auxWTNLS = lstWTMLS.SelectedItems(0)
        Else
            If DialogResult.Yes = MessageBox.Show("Would you like to save it? " + vbCrLf + "If you accept it, you will change the records" + vbCrLf + "in your already saved Jobs.", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                If mtdOthers.updateWTMLS(txtWTMLS.Text, auxWTNLS.Text) Then
                    lstWTMLS.SelectedItems(0).Text = txtWTMLS.Text
                    txtWTMLS.Text = ""
                    btnUpdateExpCode.Text = "Update"
                End If
            Else
                txtWTMLS.Text = ""
                btnUpdateWTMLS.Text = "Update"
            End If
        End If
    End Sub

    Private Sub btnDeleteWTMLS_Click(sender As Object, e As EventArgs) Handles btnDeleteWTMLS.Click
        If lstWTMLS.SelectedItems.Count > 0 Then
            If mtdOthers.deleteWTMLS(lstWTMLS.SelectedItems(0).Text) Then
                lstWTMLS.SelectedItems(0).Remove()
            End If
        End If
    End Sub




    '==============================================================================================
    '==============================================================================================
    '==============================================================================================
    Dim auxCostDistribution As ListViewItem
    Private Sub btnAddCostDristribution_Click(sender As Object, e As EventArgs) Handles btnAddCostDristribution.Click
        If txtCostDistribution.Text <> "" Then
            lstCostDistribution.Items.Add(mtdOthers.addCostDistribution(txtCostDistribution.Text))
            txtCostDistribution.Text = ""
        End If
    End Sub


    Private Sub btnUpdateCostDristribution_Click(sender As Object, e As EventArgs) Handles btnUpdateCostDristribution.Click
        If btnUpdateCostDristribution.Text = "Update" Then
            txtCostDistribution.Text = lstCostDistribution.SelectedItems(0).Text
            btnUpdateCostDristribution.Text = "Save"
            auxCostDistribution = lstCostDistribution.SelectedItems(0)
        Else
            If soloNumero(txtCostDistribution.Text) And txtCostDistribution.Text <> "" Then
                If DialogResult.Yes = MessageBox.Show("Would you like to save it? " + vbCrLf + "If you accept it, you will change the records" + vbCrLf + "in your already saved Jobs.", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    If mtdOthers.updateCostDistribution(txtCostDistribution.Text, auxCostDistribution.Text) Then
                        btnUpdateCostDristribution.Text = "Save"
                        lstCostDistribution.SelectedItems(0).Text = txtCostDistribution.Text
                        txtCostDistribution.Text = ""
                    End If
                Else
                    btnUpdateCostDristribution.Text = "Save"
                    txtCostDistribution.Text = ""

                End If
            End If
        End If
    End Sub

    Private Sub btnDeleteCostDistribution_Click(sender As Object, e As EventArgs) Handles btnDeleteCostDistribution.Click
        If lstCostDistribution.SelectedItems.Count > 0 Then
            If mtdOthers.deleteCostDostribution(lstCostDistribution.SelectedItems(0).Text) Then
                lstCostDistribution.SelectedItems(0).Remove()
            End If
        End If
    End Sub

    '==============================================================================================
    '==============================================================================================
    '==============================================================================================

    Dim auxCostCode As ListViewItem
    Private Sub btnAddCostCode_Click(sender As Object, e As EventArgs) Handles btnAddCostCode.Click
        If txtCostCode.Text <> "" And soloNumero(txtCostCode.Text) Then
            mtdOthers.addCostCode(txtCostCode.Text)
            lstCostCode.Items.Add(txtCostCode.Text)
            txtCostCode.Text = ""
        End If
    End Sub

    Private Sub btnUpdateCostCode_Click(sender As Object, e As EventArgs) Handles btnUpdateCostCode.Click
        If btnUpdateCostCode.Text = "Update" Then
            btnUpdateCostCode.Text = "Save"
            txtCostCode.Text = lstCostCode.SelectedItems(0).Text
            auxCostCode = lstCostCode.SelectedItems(0)
        Else
            If soloNumero(txtCostCode.Text) Then
                If DialogResult.Yes = MessageBox.Show("Would you like to save it? " + vbCrLf + "If you accept it, you will change the records" + vbCrLf + "in your already saved Jobs.", "Important", MessageBoxButtons.YesNo, MessageBoxIcon.Question) Then
                    If mtdOthers.updateCostCode(txtCostCode.Text, auxCostCode.Text) Then
                        lstCostCode.SelectedItems(0).Text = txtCostCode.Text
                        btnUpdateCostCode.Text = "Update"
                        txtCostCode.Text = ""
                    Else
                        btnUpdateCostCode.Text = "Update"
                        txtCostCode.Text = ""
                    End If
                Else
                    btnUpdateCostCode.Text = "Update"
                    txtCostCode.Text = ""
                End If
            End If
        End If
    End Sub

    Private Sub btnDeleteCostCode_Click(sender As Object, e As EventArgs) Handles btnDeleteCostCode.Click
        If lstCostCode.SelectedItems.Count > 0 Then
            If mtdOthers.deleteCostCode(lstCostCode.SelectedItems(0).Text) Then
                lstCostCode.SelectedItems(0).Remove()
            End If
        End If
    End Sub
End Class