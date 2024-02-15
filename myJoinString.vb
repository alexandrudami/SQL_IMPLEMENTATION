Public Class myString

    Private _Name As String = ""
    Private _isPrimary As Boolean = False

    Public Property Name() As String
        Set(ByVal value As String)
            _Name = value
        End Set
        Get
            Return _Name
        End Get
    End Property


    Public Property isPrimary() As Boolean
        Set(ByVal value As Boolean)
            _isPrimary = value
        End Set
        Get
            Return _isPrimary
        End Get
    End Property

    Private _StringFrom As String
    Public Property StringFrom() As String
        Set(ByVal value As String)
            _StringFrom = value
        End Set
        Get
            Return _StringFrom
        End Get
    End Property

    Private _StringJoin As String
    Public Property StringJoin() As String
        Set(ByVal value As String)
            _StringJoin = value
        End Set
        Get
            Return _StringJoin
        End Get
    End Property

    Private _StringLink As String
    Public Property StringLink() As String
        Set(ByVal value As String)
            _StringLink = value
        End Set
        Get
            Return _StringLink
        End Get
    End Property

    Public Sub FromString(tbname As String)

        StringFrom = "FROM " & tbname

    End Sub

    Public Sub JoinString(JoinType As Integer, tbname As String)

        Select Case JoinType
            Case 1
                StringJoin = "CROSS JOIN " & tbname
            Case 2
                StringJoin = "INNER JOIN " & tbname & " ON "
        End Select

    End Sub

    Public Sub JoinLinkString(Drag As String, Drop As String)

        StringLink = Drag & " = " & Drop

    End Sub



End Class