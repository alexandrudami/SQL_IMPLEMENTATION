Public Class myCheckbox

    Public Event _CheckChange(sender As Object, e As EventArgs)
    Public Event _MouseDown(sender As Object, e As EventArgs)
    Public Event _DragDrop(sender As Object, e As DragEventArgs)
    Public Event _DragEnter(sender As Object, e As DragEventArgs)
    Private _ColumnName As String
    Private _ColumnIndex As Integer


    Private _boxText As String
    Public Property boxText() As String
        Set(ByVal value As String)
            _boxText = value
        End Set
        Get
            Return _boxText
        End Get
    End Property

    Public Property ColumnName() As String
        Set(ByVal value As String)
            _ColumnName = value
            lbl.Text = _ColumnName

        End Set
        Get
            Return _ColumnName
        End Get

    End Property


    Private _MyParent As MyTable
    Public Property MyTable As MyTable
        Set(value As MyTable)
            _MyParent = value
        End Set
        Get
            Return _MyParent
        End Get

    End Property

    Public Property ColumnIndex() As Integer
        Set(ByVal value As Integer)
            _ColumnIndex = value
            box.Name = _ColumnIndex
        End Set
        Get
            Return _ColumnIndex
        End Get

    End Property



    Private Sub lbl_MouseDown(sender As Object, e As EventArgs) Handles Me.MouseDown, lbl.MouseDown
        RaiseEvent _MouseDown(Me, e)
    End Sub

    Private Sub box_CheckedChanged(sender As Object, e As EventArgs) Handles box.CheckedChanged
        RaiseEvent _CheckChange({lbl, sender}, e)
    End Sub

    Private Sub lbl_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop, lbl.DragDrop
        RaiseEvent _DragDrop(Me, e)
    End Sub

    Private Sub myCheckbox_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter, lbl.DragEnter
        RaiseEvent _DragEnter(Me, e)
    End Sub

    Private Sub myCheckbox_Load(sender As Object, e As EventArgs) Handles Me.Load
        boxText = lbl.Text
    End Sub
End Class
