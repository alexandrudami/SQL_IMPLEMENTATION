


Imports System.CodeDom
Imports System.Drawing.Imaging
Imports System.Security.AccessControl
Imports System.Windows.Markup
Imports Microsoft.Data.SqlClient
Imports SQL_IMPLEMENTATION.My

Public Class Form1
    Dim dt As New DataTable
    Dim cmmSelect As String = "Select PersID, Nume, JudID, Judet from Persoane Left Join Judete ON Persoane.JudID = Judete.ID"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim frmBuild As New FormBuild
        Dim arr As New ArrayList From {"ID", "Name"}
        frmBuild.SelfBuildForm(arr)

        Dim dtr As New DataTree
        If My.Settings.txtPC = "" Then

        Else
            dtr.populateTree(trv)
        End If

    End Sub

    Private Sub btnADD_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs)


    End Sub


    Private Sub btnDELETE_Click(sender As Object, e As EventArgs)


    End Sub

    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click

        Dim frm As New FormBuild
        frm.Input_Database()
        Form1_Load(sender, e)

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click

        Dim cmm As String
        Dim sqlcmm As New SQLCOMMANDS

        cmm = "Insert into Users(IDParent, NodeLevel, Name) values (" & trv.SelectedNode.Name & ", " & trv.SelectedNode.Level & ", "



    End Sub
End Class


Public Class FormBuild


    Dim frmInputDatabase As New Form
    Dim frmSelfBuild As New Form

    Public Sub SelfBuildForm(ByVal arr As ArrayList, ByVal arrRes As ArrayList)

        Dim btnOK As New Button
        frmSelfBuild.Size = New Size(270, 100)

        Dim oldLoc As Integer = 10
        Dim oldSize As Integer = 0

        For Each obj As String In arr

            Dim lbl As New Label
            Dim txt As New TextBox

            lbl.Text = obj & ":"
            lbl.Name = "lbl" & obj
            txt.Name = "txt" & obj
            lbl.Size = New Size(100, 23)
            txt.Size = New Size(120, 30)
            lbl.Location = New Point(10, oldLoc + oldSize + 10)
            txt.Location = New Point(lbl.Location.X + lbl.Width, lbl.Location.Y - 5)
            frmSelfBuild.Controls.Add(lbl)
            frmSelfBuild.Controls.Add(txt)
            frmSelfBuild.Height = frmSelfBuild.Height + 40
            oldLoc = lbl.Location.Y
            oldSize = lbl.Size.Height
        Next

        btnOK.Size = New Size(100, 30)
        btnOK.Text = "OK"
        btnOK.Location = New Point(frmSelfBuild.Size.Width - btnOK.Size.Width - 40, frmSelfBuild.Size.Height - btnOK.Size.Height - 50)
        frmSelfBuild.Controls.Add(btnOK)

        AddHandler btnOK.Click, AddressOf btnOK_Click

        frmSelfBuild.ShowDialog()

        If frmSelfBuild.DialogResult = DialogResult.OK Then

        End If

    End Sub

    Public Sub Input_Database()

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
        txtPC.Name = "txtPC"
        txtServer.Name = "txtServer"
        txtDatabase.Name = "txtDatabase"
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
                    My.Settings.Item(ctrl.Name) = ctrl.Text
                    My.Settings.Save()
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
    Public Sub SQLCONN(ByRef conn As SqlConnection)

        cnn = "Data Source=" & My.Settings.txtPC & "\" & My.Settings.txtSERVER & ";Initial Catalog=" & My.Settings.txtDATABASE _
        & ";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"
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

    Public Sub SQLINSERT(ByVal cmm As String)

        adapter = New SqlDataAdapter
        Dim conn As New SqlConnection

        SQLCONN(conn)

        Using conn
            conn.Open()
            adapter.InsertCommand = New SqlCommand(cmm, conn)
            adapter.InsertCommand.ExecuteNonQuery()
        End Using

    End Sub

    Public Sub SQLINSERTEMPTY(ByVal tb As String)

        adapter = New SqlDataAdapter
        Dim conn As New SqlConnection

        SQLCONN(conn)

        Using conn
            conn.Open()
            adapter.SelectCommand = New SqlCommand("SELECT MAX(ID) FROM " & tb, conn)
            Dim id As Integer = adapter.SelectCommand.ExecuteScalar + 1
            Dim cmm As String = "Insert into " & tb & "(ID) values (" & id & ")"
            adapter.InsertCommand = New SqlCommand(cmm, conn)
            adapter.InsertCommand.ExecuteNonQuery()
        End Using

    End Sub

    Public Sub SQLUPDATE(ByVal cmm As String)

        adapter = New SqlDataAdapter
        Dim conn As New SqlConnection

        SQLCONN(conn)

        Using conn
            conn.Open()
            adapter.UpdateCommand = New SqlCommand(cmm, conn)
            adapter.UpdateCommand.ExecuteNonQuery()
        End Using

    End Sub

    Public Sub SQLDELETE(ByVal cmm As String)

        adapter = New SqlDataAdapter
        Dim conn As New SqlConnection

        SQLCONN(conn)

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