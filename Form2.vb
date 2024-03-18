Imports System.DirectoryServices
Imports System.Timers
Imports Microsoft.Data.SqlClient
Imports Microsoft.Identity.Client
Imports System.Windows
Imports Microsoft.VisualBasic.Devices
Imports System.Text.RegularExpressions
Imports System.CodeDom
Imports System.Diagnostics.SymbolStore
Imports System.Runtime.CompilerServices
Public Class Form2

#Region "=========Declarations"

    Dim myDT_Active As MyTable
    Dim StrDict As New Dictionary(Of String, myString)

#End Region

#Region "=========Load"
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        displayTables(lstTables)

    End Sub
#End Region

#Region "=========Proceduri"

    Private Function isOccupied(mytb As MyTable, x As Integer, y As Integer) As Boolean
        If mytb.Bounds.Contains(x, y) Then
            Return True
        End If
        Return False
    End Function

    Public Sub displayTables(ByRef lst As ListBox)

        Dim comm As New SQLCNN
        Dim dtList As New DataTable

        comm.SQLSELECT("Select * From SysTables order by name ASC", dtList)

        For Each row As DataRow In dtList.Rows
            lst.Items.Add(row("name"))
        Next

    End Sub

    Public Function SelectString()

        Dim txtSelect As String

        Dim strList As New List(Of String)

        For Each table As MyTable In displayCont.Panel1.Controls.OfType(Of MyTable)

            For Each item As String In table.dictValues.Values

                strList.Add(table.TableName & "." & item)

            Next

        Next

        txtSelect = "SELECT "

        For Each item As String In strList

            If item = strList.Last Then
                txtSelect = txtSelect & item
            Else
                txtSelect = txtSelect & item & ", "
            End If

        Next
        Return txtSelect & vbCrLf
    End Function

    Public Sub displayString()

        Dim selectstr As String = SelectString()

        Dim joinstr As String = ""

        For Each item As myString In StrDict.Values


            If item.StringFrom IsNot Nothing Then
                joinstr = joinstr & item.StringFrom & vbCrLf
            ElseIf item.StringJoin.StartsWith("CROSS") Then
                joinstr = joinstr & item.StringJoin & vbCrLf
            ElseIf item.StringJoin.StartsWith("INNER") Then
                joinstr = joinstr & item.StringJoin & item.StringLink & vbCrLf
            End If



        Next


        RichTextBox1.Text = selectstr & joinstr

    End Sub




#End Region

#Region "=========Events"

#Region "DragAndDrop_Operation"

    Dim lineInProgress As MyDrawings = Nothing
    Private Sub lbl_MouseDown(sender As Object, e As MouseEventArgs)
        Dim line As New MyDrawings(displayCont.Panel1)
        lineInProgress = line
        Dim tb As MyTable = sender(0)

        Dim box As myCheckbox = sender(1)

        tb.myLine = line

        tb.myLine.startCheckbox = box



        box.DoDragDrop(tb.TableName & "." & box.boxText, DragDropEffects.Link)

    End Sub
    Private Sub lbl_DragEnter(sender As Object, e As DragEventArgs)
        e.Effect = DragDropEffects.Link
    End Sub
    Private Sub lbl_DragDrop(sender As Object, e As DragEventArgs)

        Dim tb As MyTable = sender(0)

        Dim box As myCheckbox = sender(1)
        tb.myLine = lineInProgress

        tb.myLine.endCheckbox = box


        Dim mystr As myString = StrDict(tb.TableName)
        mystr.JoinString(2, tb.TableName)
        mystr.JoinLinkString(e.Data.GetData(DataFormats.Text), tb.TableName & "." & box.boxText)


        tb.myLine.myDrawLine()

        displayString()

    End Sub


    Private Sub panel_Paint(sender As Object, e As PaintEventArgs) Handles displayCont.Panel1.Paint

        'If myDT_Active IsNot Nothing AndAlso myDT_Active.myLine IsNot Nothing Then
        '    myDT_Active.myLine.myDrawLine()
        'End If


    End Sub


#End Region

#Region "myTable_Movement"
    Private Sub displayCont_MouseMove(sender As Object, e As MouseEventArgs) Handles displayCont.Panel1.MouseMove
        If myDT_Active IsNot Nothing Then
            myDT_Active._MouseMove()


        End If



    End Sub
    Private Sub myDT_MouseDown(sender As Object, e As MouseEventArgs)
        myDT_Active = sender



    End Sub
    Private Sub myDT_MouseUp(sender As Object, e As MouseEventArgs)
        myDT_Active = Nothing
    End Sub
#End Region

    Private Sub My_CheckChange(sender As Object, e As EventArgs)

        Dim lbl As Label = sender(1)(0)
        Dim box As CheckBox = sender(1)(1)
        Dim tb As MyTable = sender(0)
        If box.Checked Then
            tb.dictValues.Add(box.Name, lbl.Text)
        Else
            tb.dictValues.Remove(box.Name, lbl.Text)
        End If

        displayString()

    End Sub
    Private Sub lstTables_DoubleClick(sender As Object, e As EventArgs) Handles lstTables.DoubleClick

        Dim myDT As MyTable = New MyTable
        Dim myStr As myString = New myString
        AddHandler myDT.__DragEnter, AddressOf lbl_DragEnter
        AddHandler myDT.__MouseDown, AddressOf lbl_MouseDown
        AddHandler myDT.__DragDrop, AddressOf lbl_DragDrop
        AddHandler myDT.__CheckChange, AddressOf My_CheckChange
        AddHandler myDT._tbMouseDown, AddressOf myDT_MouseDown
        AddHandler myDT.MouseUp, AddressOf myDT_MouseUp
        AddHandler myDT._Load, AddressOf MyDT_Load

        Dim schema As New DataTable
        Dim comm As New SQLCNN
        comm.SQLSELECT("Select * from information_schema.columns where table_name ='" & lstTables.SelectedItem & "'", schema)

        myDT.addCheckBox(schema)

        displayCont.Panel1.Controls.Add(myDT)
        myDT.BringToFront()

        If displayCont.Panel1.Controls.OfType(Of MyTable).Count = 1 Then

            myStr.Name = myDT.TableName
            myStr.isPrimary = True
            myStr.FromString(myDT.TableName)

            StrDict.Add(myStr.Name, myStr)

        Else

            myStr.Name = myDT.TableName
            myStr.JoinString(1, myDT.TableName)

            StrDict.Add(myStr.Name, myStr)

        End If

        displayString()

    End Sub
    Private Sub MyDT_Load(sender As Object, e As EventArgs)
        Dim tb As MyTable = sender
        Dim maxX, maxY As Int16

        For Each ctrl As Control In displayCont.Panel1.Controls.OfType(Of MyTable)

            If ctrl IsNot sender Then
                If maxX < ctrl.Left + ctrl.Width Then
                    maxX = ctrl.Left + ctrl.Width
                End If
                If maxY < ctrl.Top + ctrl.Height Then
                    maxY = ctrl.Top + ctrl.Height
                End If


                Do While isOccupied(ctrl, tb.Location.X, tb.Location.Y) = True
                        tb.Location = New Point(ctrl.Location.X + ctrl.Width, ctrl.Location.Y)
                    Loop
                End If
        Next

        tb.Location = New Point(maxX, 0)

    End Sub

    Private Sub Form2_Move(sender As Object, e As EventArgs) Handles Me.Move

    End Sub

#End Region

End Class

Public Class SQLCNN
    Dim cnn As String = "Data Source=" & My.Settings.txtPC & My.Settings.txtSERVER & ";Initial Catalog=" & My.Settings.txtDATABASE _
        & ";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"

    Dim conn As New SqlConnection
    Dim adapter As New SqlDataAdapter

    Public Sub SQLSELECT(ByVal cmm As String, ByRef dt As DataTable)
        conn.ConnectionString = cnn

        Using conn
            conn.Open()
            adapter.SelectCommand = New SqlCommand(cmm, conn)
            adapter.Fill(dt)
        End Using
    End Sub

End Class