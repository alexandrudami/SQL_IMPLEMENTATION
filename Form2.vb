Imports Microsoft.Data.SqlClient
Imports Microsoft.Identity.Client

Public Class Form2
    Dim list As New TableList
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles MyBase.Load


        List.displayTables(lstTables)



    End Sub
    Dim cnn As String = "Data Source=" & My.Settings.txtPC & "\" & My.Settings.txtSERVER & ";Initial Catalog=" & My.Settings.txtDATABASE _
        & ";Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False"

    Private Sub lstTables_DoubleClick(sender As Object, e As EventArgs) Handles lstTables.DoubleClick

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

        For Each row As DataRow In dtList.Rows

            lst.Items.Add(row("name"))

        Next


    End Sub

    Public Sub displayTableSchema(ByRef dtSchema As DataTable, ByRef cont As Panel)


        Dim panel As New Panel
        Dim chkbox As New CheckedListBox

        For Each row As DataRow In dtSchema.Rows

            chkbox.Items.Add(row("COLUMN_NAME"))

        Next

        panel.Controls.Add(chkbox)
        chkbox.Dock = DockStyle.Fill
        cont.Controls.Add(panel)

    End Sub






End Class




