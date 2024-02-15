Imports System.DirectoryServices
Imports System.Timers
Imports Microsoft.Data.SqlClient
Imports Microsoft.Identity.Client
Imports System.Windows

Imports Microsoft.VisualBasic.Devices
Imports System.Text.RegularExpressions
Public Class Form2
    Dim list As New TableList
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        list.displayTables(lstTables)


    End Sub
    Dim cnn As String = "Data Source=" & My.Settings.txtPC & "\" & My.Settings.txtSERVER & ";Initial Catalog=" & My.Settings.txtDATABASE _
        & ";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"

#Region "=========Proceduri"

        Dim schema As New DataTable

        Dim conn As New SqlConnection
        Dim adapter As New SqlDataAdapter

        conn.ConnectionString = cnn


        Using conn
            conn.Open()
            adapter.SelectCommand = New SqlCommand("Select * from information_schema.columns where table_name ='" & lstTables.SelectedItem & "'", conn)
            adapter.Fill(schema)
        End Using

        list.displayTableSchema(schema, SplitContainer2.Panel1)

    End Sub
End Class

Public Class TableList
    Dim cnn As String = "Data Source=" & My.Settings.txtPC & "\" & My.Settings.txtSERVER & ";Initial Catalog=" & My.Settings.txtDATABASE _
        & ";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"


    Public Sub displayTables(ByRef lst As ListBox)

        Dim adapter As New SqlDataAdapter
        Dim conn As New SqlConnection
        Dim dtList As New DataTable
        conn.ConnectionString = cnn



        lst.Items.Clear()

        Using conn
            conn.Open()
            adapter.SelectCommand = New SqlCommand("Select * From SysTables order by name ASC", conn)
            adapter.Fill(dtList)

        End Using


            lst.Items.Add(row("name"))

        Next


    End Sub
    Dim panel As Panel
    Dim chkbox As CheckedListBox
    Dim toolstrip As ToolStrip
    Dim container As New Panel
    Public Sub displayTableSchema(ByRef dtSchema As DataTable, ByRef cont As Panel)

        Dim schemaPanel As New Panel
        chkbox = New CheckedListBox
        toolstrip = New ToolStrip
        For Each row As DataRow In dtSchema.Rows

            chkbox.Items.Add(row("COLUMN_NAME"))
            schemaPanel.Name = row("TABLE_NAME")

        Next


        Dim btnClose As New ToolStripButton
        btnClose.Image = Image.FromFile("D:\SQL_IMPLEMENTATION\ico\1766.png")
        btnClose.TextAlign = ContentAlignment.MiddleCenter
        btnClose.Alignment = ToolStripItemAlignment.Right
        toolstrip.Items.Add(btnClose)
        toolstrip.BackColor = Color.SkyBlue
        schemaPanel.Controls.Add(toolstrip)
        schemaPanel.BringToFront()
        schemaPanel.Size = New Drawing.Size(200, 250)
        schemaPanel.Controls.Add(chkbox)
        chkbox.Dock = DockStyle.Fill
        cont.Controls.Add(schemaPanel)
        toolstrip.SendToBack()

        container = cont
        panel = schemaPanel

        AddHandler toolstrip.MouseDown, AddressOf Mouse_Down
        AddHandler container.MouseMove, AddressOf Mouse_Move
        AddHandler toolstrip.MouseMove, AddressOf Mouse_Move
        AddHandler toolstrip.MouseUp, AddressOf Mouse_Up
        AddHandler container.MouseUp, AddressOf Mouse_Up
        AddHandler container.MouseLeave, AddressOf Mouse_Up

    End Sub

    Dim isMoving As Boolean
    Dim posX As New Integer
    Dim posY As New Integer
    Public Sub Mouse_Down(sender As Object, e As EventArgs)

        posX = Panel.MousePosition.X - panel.Location.X - 1
        posY = Panel.MousePosition.Y - panel.Location.Y - 1
        isMoving = True

    End Sub


    Dim newpoint As Point
    Public Sub Mouse_Move(sender As Object, e As EventArgs)

        If isMoving = True Then

            newpoint = Panel.MousePosition
            newpoint.X -= posX
            newpoint.Y -= posY
            panel.Location = newpoint



        End If

    End Sub

    Public Sub Mouse_Up(sender As Object, e As EventArgs)

        isMoving = False

    End Sub


End Class




