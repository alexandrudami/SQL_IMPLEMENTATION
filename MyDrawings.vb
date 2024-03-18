Public Class MyDrawings

    Public MyPanel As Panel
    Public MyColor As Color
    Public LastLine As Point()


    Public ReadOnly Property LineStartPoint() As Point

        Get
            Return New Point(startCheckbox.MyTable.Location.X + startCheckbox.MyTable.Width, startCheckbox.MyTable.Location.Y + startCheckbox.Location.Y + startCheckbox.Height / 2)
        End Get

    End Property

    Public ReadOnly Property LineEndPoint() As Point

        Get
            Return New Point(endCheckbox.MyTable.Location.X, endCheckbox.MyTable.Location.Y + endCheckbox.Location.Y + endCheckbox.Height / 2)
        End Get

    End Property

    Private _startCheckbox As myCheckbox
    Public Property startCheckbox() As myCheckbox
        Set(ByVal value As myCheckbox)
            _startCheckbox = value
        End Set
        Get
            Return _startCheckbox
        End Get
    End Property

    Private _endCheckbox As myCheckbox
    Public Property endCheckbox() As myCheckbox
        Set(ByVal value As myCheckbox)
            _endCheckbox = value
        End Set
        Get
            Return _endCheckbox
        End Get

    End Property


    Private _isFirst As Boolean
    Public Property isFirst() As Boolean
        Get
            Return _isFirst
        End Get
        Set(ByVal value As Boolean)
            _isFirst = value
        End Set
    End Property

    Public Sub DeleteLine()


        Dim pen As New Pen(MyPanel.BackColor, 2)
        MyPanel.CreateGraphics.DrawLine(pen, ExStart, ExExnd)


    End Sub

    Dim ExStart As Point
    Dim ExExnd As Point

    Public Sub New(MyPanel As Panel)
        Me.MyPanel = MyPanel
    End Sub

    Public Sub myDrawLine()

        DeleteLine()

        Dim pen As New Pen(Color.Black, 2)
        MyPanel.CreateGraphics.DrawLine(pen, LineStartPoint, LineEndPoint)
        ExStart = LineStartPoint
        ExExnd = LineEndPoint
    End Sub



End Class
