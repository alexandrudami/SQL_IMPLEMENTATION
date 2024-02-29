Public Class MyDrawings




    Private _LineStartPoint As Point
    Public Property LineStartPoint() As Point
        Set(ByVal value As Point)
            _LineStartPoint = value
        End Set
        Get
            Return _LineStartPoint
        End Get

    End Property

    Private _LineEndPoint As Point
    Public Property LineEndPoint() As Point
        Set(ByVal value As Point)
            _LineEndPoint = value
        End Set
        Get
            Return _LineEndPoint
        End Get

    End Property




    Public Sub ConnectLine(panel As Panel)


        Dim pen As New Pen(Color.Black, 2)
        panel.CreateGraphics.DrawLine(pen, LineStartPoint, LineEndPoint)

    End Sub



End Class
