


Imports System.Windows.Markup
Imports Microsoft.Data.SqlClient

Public Class Form1
    Dim dt As New DataTable
    Dim cmmSelect As String = "Select PersID, Nume, JudID, Judet from Persoane Left Join Judete ON Persoane.JudID = Judete.ID"

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim SQLCMM As New SQLCOMMANDS

        SQLCMM.SQLSELECT(dt, cmmSelect)

        dgv.DataSource = dt

        dgv.Columns("JudID").Visible = False
        dgv.Columns("PersID").Visible = False
        dgv.Columns("Judet").ReadOnly = True

    End Sub

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click

        Dim sqlcmm As New SQLCOMMANDS

        sqlcmm.SQLINSERT()
        sqlcmm.SQLSELECT(dt, cmmSelect)

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click

        Dim dr As DataRow
        Dim sqlcmm As New SQLCOMMANDS


        Dim drModif = From drx In dt.Rows
                      Where drx.RowState = DataRowState.Modified


        For Each dr In drModif

            sqlcmm.SQLUPDATE(dr("PersID"), dr("Nume"), dr("JudID"))

        Next

        sqlcmm.SQLSELECT(dt, cmmSelect)

    End Sub

    Dim judID() As ArrayList
    Dim dgvList As DataGridView
    Dim frmList As Form
    Dim dtList As New DataTable

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If dgv.CurrentCell.OwningColumn.HeaderText = "Judet" Then

            Dim sqlcmm As New SQLCOMMANDS
            Dim cmm As String = "Select * from Judete"
            frmList = New Form
            dgvList = New DataGridView

            frmList.Size = New Drawing.Size(500, 500)
            dgvList.Dock = DockStyle.Fill

            sqlcmm.SQLSELECT(dtList, cmm)

            dgvList.DataSource = dtList
            frmList.Controls.Add(dgvList)

            frmList.Show()

            AddHandler dgvList.CellDoubleClick, AddressOf dgvList_CellDoubleClick

        End If
    End Sub

    Private Sub dgvList_CellDoubleClick()

        Dim dr As DataRow
        Dim drlist As DataRow

        drlist = dtList.Rows(dgvList.CurrentCell.RowIndex)
        dr = dt.Rows(dgv.CurrentCell.RowIndex)
        dr("JudID") = drlist("ID")
        dr("Judet") = drlist("Judet")

        frmList.Close()

    End Sub

End Class



Public Class SQLCOMMANDS



    Dim cnn As String = "Data Source=ALEX-PC\SQLEXPRESS01;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
    Dim adapter As SqlDataAdapter

    Public Sub SQLCONN(ByRef conn As SqlConnection)

        conn.ConnectionString = cnn

    End Sub
    Public Sub SQLSELECT(ByRef dt As DataTable, ByVal cmm As String)

        adapter = New SqlDataAdapter
        Dim CONN As New SqlConnection

        dt.Clear()
        SQLCONN(CONN)

        Using CONN
            CONN.Open()
            adapter.SelectCommand = New SqlCommand(cmm, CONN)
            adapter.Fill(dt)

        End Using

    End Sub

    Public Sub SQLINSERT()


        adapter = New SqlDataAdapter
        Dim conn As New SqlConnection

        SQLCONN(conn)

        Using conn
            conn.Open()
            adapter.SelectCommand = New SqlCommand("SELECT MAX(PersID) FROM Persoane", conn)
            Dim id As Integer = adapter.SelectCommand.ExecuteScalar + 1
            Dim cmm As String = "Insert into Persoane (PersID) values (" & id & ")"
            adapter.InsertCommand = New SqlCommand(cmm, conn)
            adapter.InsertCommand.ExecuteNonQuery()
        End Using

    End Sub

    Public Sub SQLUPDATE(ByVal id As Integer, ByVal val1 As String, ByVal val2 As String)

        Dim cmm As String = "Update Persoane Set Nume='" & val1 & "', JudID = " & val2 & " where PersID = " & id
        adapter = New SqlDataAdapter
        Dim conn As New SqlConnection

        SQLCONN(conn)

        Using conn
            conn.Open()
            adapter.UpdateCommand = New SqlCommand(cmm, conn)
            adapter.UpdateCommand.ExecuteNonQuery()
        End Using

    End Sub

End Class