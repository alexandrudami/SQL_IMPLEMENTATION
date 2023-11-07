


Imports System.CodeDom
Imports System.Drawing.Imaging
Imports System.Security.AccessControl
Imports System.Windows.Markup
Imports Microsoft.Data.SqlClient
Imports SQL_IMPLEMENTATION.My

Public Class Form1
    Dim dt As New DataTable
    Dim cmmSelect As String = "Select PersID, Nume, JudID, Judet from Persoane Left Join Judete ON Persoane.JudID = Judete.ID"
    Dim cnn As String
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        Dim dtr As New DataTree
        If cnn IsNot Nothing Then
            dtr.populateTree(trv)
        End If








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


    Private Sub btnDELETE_Click(sender As Object, e As EventArgs) Handles btnDELETE.Click

        Dim row As DataGridViewRow
        Dim sqlcmm As New SQLCOMMANDS

        For Each row In dgv.SelectedRows

            sqlcmm.SQLDELETE(dgv.Item("PersID", row.Index).Value)

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

    Public Function getConnectionString()
        Return cnn
    End Function

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click

        Dim sqlcmm As New SQLCOMMANDS

        cnn = sqlcmm.SQLCONN()

        Form1_Load(sender, e)
    End Sub


End Class


Public Class FormBuild


    Dim frmInputDatabase As New Form

    Public Sub Input_Database(ByVal array As ArrayList)

        Dim i As Integer = 0

        Dim txtPC As New TextBox
        Dim txtServer As New TextBox
        Dim txtDatabase As New TextBox

        Dim lblPC As New Label
        Dim lblServer As New Label
        Dim lblDatabase As New Label

        Dim btnOK As New Button

        frmInputDatabase.Size = New Size(300, 250)
        frmInputDatabase.FormBorderStyle = FormBorderStyle.FixedDialog
        frmInputDatabase.MaximizeBox = False
        frmInputDatabase.MinimizeBox = False
        frmInputDatabase.Text = "Input Database"
        lblPC.Text = "PC Name:"
        lblServer.Text = "Server Name:"
        lblDatabase.Text = "Database:"
        lblPC.Size = New Size(100, 23)
        lblServer.Size = lblPC.Size
        lblDatabase.Size = lblPC.Size
        lblPC.Location = New Point(20, 45)
        lblServer.Location = New Point(lblPC.Location.X, lblPC.Location.Y + lblPC.Height + 10)
        lblDatabase.Location = New Point(lblServer.Location.X, lblServer.Location.Y + lblServer.Height + 10)
        txtPC.Size = New Size(120, 30)
        txtServer.Size = txtPC.Size
        txtDatabase.Size = txtPC.Size
        txtPC.Location = New Point(lblPC.Location.X + lblPC.Width + 10, lblPC.Location.Y - 5)
        txtServer.Location = New Point(txtPC.Location.X, txtPC.Location.Y + txtPC.Height + 10)
        txtDatabase.Location = New Point(txtServer.Location.X, txtServer.Location.Y + txtServer.Height + 10)
        btnOK.Text = "OK"
        btnOK.Size = New Size(100, 30)
        btnOK.Location = New Point(frmInputDatabase.Width - btnOK.Width - 30, frmInputDatabase.Height - btnOK.Width + 20)

        frmInputDatabase.Controls.Add(lblPC)
        frmInputDatabase.Controls.Add(lblServer)
        frmInputDatabase.Controls.Add(lblDatabase)
        frmInputDatabase.Controls.Add(txtPC)
        frmInputDatabase.Controls.Add(txtServer)
        frmInputDatabase.Controls.Add(txtDatabase)
        frmInputDatabase.Controls.Add(btnOK)

        AddHandler btnOK.Click, AddressOf btnOK_Click

        frmInputDatabase.ShowDialog()

        If frmInputDatabase.DialogResult = DialogResult.OK Then

            For Each ctrl As Control In frmInputDatabase.Controls
                If TypeOf ctrl Is TextBox Then
                    array.Insert(i, ctrl.Text)
                End If

            Next
            frmInputDatabase.Close()
        End If


    End Sub


    Private Sub btnOK_Click()

        frmInputDatabase.DialogResult = DialogResult.OK

    End Sub

End Class


Public Class SQLCOMMANDS




    Dim adapter As SqlDataAdapter
    Dim cnn As String
    Public Function SQLCONN()



        Dim frmInput As New FormBuild
        Dim array As New ArrayList
        frmInput.Input_Database(array)
        cnn = "Data Source=" & array(2) & "\" & array(1) & ";Initial Catalog=" & array(0) _
        & ";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
        Return cnn

    End Function
    Public Sub SQLSELECT(ByRef dt As DataTable, ByVal cmm As String)

        adapter = New SqlDataAdapter
        Dim CONN As New SqlConnection

        dt.Clear()
        CONN.ConnectionString = cnn

        Using CONN
            CONN.Open()
            adapter.SelectCommand = New SqlCommand(cmm, CONN)
            adapter.Fill(dt)

        End Using

    End Sub

    Public Sub SQLINSERT()


        adapter = New SqlDataAdapter
        Dim conn As New SqlConnection

        conn.ConnectionString = cnn

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

        conn.ConnectionString = cnn


        Using conn
            conn.Open()
            adapter.UpdateCommand = New SqlCommand(cmm, conn)
            adapter.UpdateCommand.ExecuteNonQuery()
        End Using

    End Sub

    Public Sub SQLDELETE(ByVal id As String)

        Dim cmm As String = "Delete from Persoane Where PersID=" & id
        adapter = New SqlDataAdapter
        Dim conn As New SqlConnection

        conn.ConnectionString = cnn

        Using conn
            conn.Open()
            adapter.DeleteCommand = New SqlCommand(cmm, conn)
            adapter.DeleteCommand.ExecuteNonQuery()
        End Using

    End Sub




End Class


Public Class DataTree


    Public Sub populateTree(ByRef trv As TreeView)

        Dim sqlcmm As New SQLCOMMANDS
        Dim dtTree As New DataTable
        Dim i As Integer

        sqlcmm.SQLSELECT(dtTree, "Select * from Users")
        Dim LevelMax As Integer = dtTree.Compute("MAX(NodeLevel)", "")


        Dim nodeHome As New TreeNode
        nodeHome.Text = "Home"
        nodeHome.Name = 0
        trv.Nodes.Add(nodeHome)

        For i = 0 To LevelMax


            For Each row As DataRow In dtTree.Select("NodeLevel=" & i, "")

                Dim node As New TreeNode

                node.Text = row("Name")
                node.Name = row("ID")

                trv.Nodes.Find(row("IDParent"), True)(0).Nodes.Add(node)



            Next


        Next



    End Sub

    Private Sub addNode()






    End Sub






End Class