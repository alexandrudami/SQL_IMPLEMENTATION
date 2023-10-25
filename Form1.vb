


Imports Microsoft.Data.SqlClient

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim cmmSelect As String = "Select PersID, Nume, Judet from Persoane Inner Join Judete ON Persoane.JudID = Judete.JudID"

        Dim dt As New DataTable
        Dim SQLCMM As New SQLCOMMANDS
        SQLCMM.SQLSELECT(dt, cmmSelect)
        dgv.DataSource = dt
        dgv.Columns("PersID").Visible = False

    End Sub

    Private Sub btnADD_Click(sender As Object, e As EventArgs) Handles btnADD.Click
        dgv.AllowUserToAddRows = True

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dim dt As New DataTable

    End Sub

    Private Sub dgv_CellDoubleClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellDoubleClick
        If dgv.CurrentCell.ColumnIndex = 2 Then
            Dim sqlcmm As New SQLCOMMANDS
            Dim cmm As String = "Select * from Judete"
            Dim frmList As New Form
            Dim dgvList As New DataGridView

            Dim dtList As New DataTable



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
        SQLCONN(CONN)

        Using CONN
            CONN.Open()
            adapter.SelectCommand = New SqlCommand(cmm, CONN)
            adapter.Fill(dt)
        End Using

    End Sub

    Public Sub SQLINSERT(ByRef dt As DataTable, ByVal loc As String, ByVal val As String)

        Dim cmm As String = "Insert into " & loc & "values (" & val & ")"

        adapter = New SqlDataAdapter
        Dim conn As New SqlConnection
        SQLCONN(conn)
        Using conn
            conn.Open()
            adapter.InsertCommand = New SqlCommand(cmm, conn)
            adapter.Fill(dt)
        End Using



    End Sub

End Class