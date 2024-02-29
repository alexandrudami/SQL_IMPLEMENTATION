Imports System.Runtime.CompilerServices
Imports System.Security.AccessControl

Public Class MyTable

    Friend dictValues As New SortedDictionary(Of Integer, String)


    Friend posX, posY As Integer
    Friend isMoving As Boolean
    Friend newpoint As Point

    Private _TableName As String = ""

    Public Event __CheckChange(sender As Object, e As EventArgs)
    Public Event __MouseDown(sender As Object, e As MouseEventArgs)
    Public Event __DragEnter(sender As Object, e As DragEventArgs)
    Public Event __DragDrop(sender As Object, e As DragEventArgs)
    Public Event _ShadowMouseDown(sender As Object, e As EventArgs)
    Public Event _Load(sender As Object, e As EventArgs)
    Public Property TableName() As String

        Set(ByVal value As String)
            _TableName = value
            lblName.Text = _TableName
            Name = _TableName

        End Set
        Get
            Return _TableName
        End Get
    End Property



    Public Sub addCheckBox(ByRef dtSchema As DataTable)

        For Each row As DataRow In dtSchema.Rows

            Dim chkbox = New myCheckbox
            chkbox.ColumnName = row("COLUMN_NAME")
            chkbox.ColumnIndex = row("ORDINAL_POSITION")
            chkbox.Dock = DockStyle.Top
            chkbox.AllowDrop = True
            If Name = "MyTable" Then
                TableName = row("TABLE_NAME")
            End If
            schemaPanel.Controls.Add(chkbox)
            chkbox.BringToFront()

            AddHandler chkbox._CheckChange, AddressOf chkbox_CheckedChanged
            AddHandler chkbox._MouseDown, AddressOf chkbox_MouseDown
            AddHandler chkbox._DragDrop, AddressOf chkbox_DragDrop
            AddHandler chkbox._DragEnter, AddressOf chkbox_DragEnter
        Next

    End Sub

    Private Sub chkbox_CheckedChanged(sender As Object, e As EventArgs)
        RaiseEvent __CheckChange({Me, sender}, e)
    End Sub

    Public Sub chkbox_MouseDown(sender As Object, e As MouseEventArgs)
        RaiseEvent __MouseDown({Me, sender}, e)
    End Sub

    Private Sub chkbox_DragDrop(sender As Object, e As DragEventArgs)
        RaiseEvent __DragDrop({Me, sender}, e)
    End Sub

    Private Sub chkbox_DragEnter(sender As Object, e As DragEventArgs)
        RaiseEvent __DragEnter(sender, e)
    End Sub


    Public Sub tsp_MouseDown(sender As Object, e As MouseEventArgs) Handles tsp.MouseDown

        BringToFront()
        posX = Panel.MousePosition.X - Location.X
        posY = Panel.MousePosition.Y - Location.Y
        isMoving = True

    End Sub
    Public Sub tsp_MouseMove(sender As Object, e As MouseEventArgs) Handles tsp.MouseMove, MyBase.MouseMove

        _MouseMove()

    End Sub
    Public Sub _MouseMove()
        If isMoving = True Then
            newpoint = MousePosition
            newpoint.X -= posX
            newpoint.Y -= posY
            Location = newpoint
        End If



    End Sub
    Public Sub tsp_MouseUp(sender As Object, e As MouseEventArgs) Handles tsp.MouseUp
        isMoving = False
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs) Handles ToolStripButton1.Click
        Dispose()
    End Sub

    Private Sub MyTable_Load(sender As Object, e As EventArgs) Handles Me.Load
        RaiseEvent _Load(sender, e)
    End Sub
End Class
