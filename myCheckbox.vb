Public Class myCheckbox

    Public Event _CheckChange(sender As Object, e As EventArgs)
    Public Event _MouseDown(sender As Object, e As EventArgs)
    Public Event _DragDrop(sender As Object, e As DragEventArgs)
    Public Event _DragEnter(sender As Object, e As DragEventArgs)
    Private _ColumnName As String

    Public Property ColumnName() As String
        Set(ByVal value As String)
            _ColumnName = value
            lbl.Text = _ColumnName

        End Set
        Get
            Return _ColumnName
        End Get

    End Property

    Private _ColumnIndex As Integer
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
        RaiseEvent _MouseDown({lbl, sender}, e)
    End Sub

    Private Sub box_CheckedChanged(sender As Object, e As EventArgs) Handles box.CheckedChanged
        RaiseEvent _CheckChange({lbl, sender}, e)
    End Sub

    Private Sub lbl_DragDrop(sender As Object, e As DragEventArgs) Handles Me.DragDrop, lbl.DragDrop
        RaiseEvent _DragDrop(sender, e)
    End Sub

    Private Sub myCheckbox_DragEnter(sender As Object, e As DragEventArgs) Handles Me.DragEnter, lbl.DragEnter
        RaiseEvent _DragEnter(sender, e)
    End Sub
End Class
