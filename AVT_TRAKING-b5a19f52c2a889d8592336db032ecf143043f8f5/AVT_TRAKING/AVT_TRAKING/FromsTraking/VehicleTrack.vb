Imports System.Data.SqlClient

Public Class VehicleTrack

    Private Sub VehicleTrack_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        llenarComboClientsReports(cmbClient)
    End Sub

    Private Sub cmbClient_SelectedIndexChanged(sender As Object, e As EventArgs) Handles cmbClient.SelectedIndexChanged
        If cmbClient.SelectedIndex > -1 Then
            Dim array() As String = cmbClient.SelectedIndex.ToString.Split(" ")
            If array.Length > 0 Then
                llenarComboJobsReports(cmbJobs, array(0))
            End If
        Else
            MsgBox("Please select a client.")
        End If
    End Sub
End Class

Public Class columnsTrackVehicle
    ''Public columns = New String(,) {{"1", "Record ID", "Record ID"}, {"2", "Force or Reject", "Force or Reject"}, {"3", "Date", "Date"}, {"4", "Order Type", "Order Type"}, {"5", "Location ID", "Location ID"}, {"6", "Company Code", "Company Code"}, {"7", "Agreement", "Agreement"}, {"8", "Group", "Group"}, {"9", "Type", "Type"}, {"10", "Equip Unique ID", "Equip Unique ID"}, {"11", "Area", "Area"}, {"12", "Level 1 ID", "Level 1 ID"}, {"13", "Level 2 ID", "Level 2 ID"}, {"14", "Level 3 ID"}, {"15", "Level 4 ID"}, {"16", "Base Hrs", "Base Hrs"}, {"17", "Over Hrs", "Over Hrs"}, {"18", "Idle Hrs", "Idle Hrs"}, {"19", "Other Costs", "Other Costs"}, {"20", "Other Costs Name", "Other Costs Name"}, {"21", "Extra", "Extra"}, {"22", "GL Account", "GL Account"}}

End Class