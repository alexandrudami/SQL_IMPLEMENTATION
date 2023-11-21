


Imports System.CodeDom
Imports System.ComponentModel
Imports System.Drawing.Imaging
Imports System.Security.AccessControl
Imports System.Windows.Markup
Imports Microsoft.Data.SqlClient
Imports SQL_IMPLEMENTATION.My

Public Class Form1
    Dim dt As New DataTable
    Dim dtr As New DataTree
    Dim cmmSelect As String = "Select PersID, Nume, JudID, Judet from Persoane Left Join Judete ON Persoane.JudID = Judete.ID"
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim frmBuild As New FormBuild

        If Settings.txtPC = "" Then

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
        Dim arrInput As New ArrayList From {"PC", "Server", "Database"}
        frm.SelfBuildForm(arrInput)

        For Each ctrl As Control In frm.frmSelfBuild.Controls.OfType(Of TextBox)

            Settings.Item(ctrl.Name) = ctrl.Text
            My.Settings.Save()

        Next

        Form1_Load(sender, e)

    End Sub

    Private Sub dgv_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles dgv.CellContentClick

    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles TreeADD.Click
        Dim frm As New FormBuild
        Dim cmm As String
        Dim sqlcmm As New SQLCOMMANDS
        Dim aux As String = ""

        Dim arr As New ArrayList From {"Name"}
        frm.SelfBuildForm(arr)

        For Each ctrl As Control In frm.frmSelfBuild.Controls.OfType(Of TextBox)

            aux = ctrl.Text

        Next

        sqlcmm.SQLSELECT(dt, "Select * from Users")
        Dim maxID As Integer = dt.Compute("MAX(ID)", "") + 1
        cmm = "Insert into Users(ID, IDParent, NodeLevel, Name) values (" & maxID & ", " & trv.SelectedNode.Name & ", " & trv.SelectedNode.Level & ", '" & aux & "')"
        sqlcmm.SQLINSERT(cmm)
        dtr.populateTree(trv)

    End Sub

    Private Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles MyBase.Closing
        Settings.Save()
    End Sub

    Private Sub TreeDEL_Click(sender As Object, e As EventArgs) Handles TreeDEL.Click


        Dim sqlcmm As New SQLCOMMANDS
        'Dim cmm As String
        'If trv.SelectedNode.Nodes.Count > 0 Then
        '    MsgBox("The item cannot be deleted. Please make sure it does not have any other items tied to it.")
        'Else
        '    cmm = "Delete From Users where ID= " & trv.SelectedNode.Name
        '    sqlcmm.SQLDELETE(cmm)
        '    dtr.populateTree(trv)
        'End If


        Dim nodes As New List(Of TreeNode)
        getAllChildren(trv.SelectedNode, nodes)

        For Each node As TreeNode In nodes
            sqlcmm.SQLDELETE("Delete From Users where ID= " & node.Name)
        Next
        sqlcmm.SQLDELETE("Delete From Users where ID = " & trv.SelectedNode.Name)
        dtr.populateTree(trv)

    End Sub



    Public Sub getAllChildren(ByRef parentNode As TreeNode, nodes As List(Of TreeNode))

        For Each childNode As TreeNode In parentNode.Nodes
            nodes.Add(childNode)
            getAllChildren(childNode, nodes)
        Next

    End Sub


End Class


Public Class FormBuild


    Dim frmInputDatabase As New Form
    Public frmSelfBuild As New Form

    Public Sub SelfBuildForm(ByVal arr As ArrayList)

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

            frmSelfBuild.Close()

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

        trv.Nodes.Clear()
        Dim nodeHome As New TreeNode
        nodeHome.Text = "Home"
        nodeHome.Name = 0
        trv.Nodes.Add(nodeHome)

        For i = 0 To LevelMax
            For Each row As DataRow In dtTree.Select("NodeLevel=" & i, "")

                Dim node As New TreeNode With {
                    .Text = row("Name"),
                    .Name = row("ID")
                }

                trv.Nodes.Find(row("IDParent"), True)(0).Nodes.Add(node)

            Next
        Next

    End Sub

    Private Sub addNode()

    End Sub

End Class