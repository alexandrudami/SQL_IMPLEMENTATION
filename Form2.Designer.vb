<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form2
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        SplitContainer1 = New SplitContainer()
        lstTables = New ListBox()
        displayCont = New SplitContainer()
        RichTextBox1 = New RichTextBox()
        CType(SplitContainer1, ComponentModel.ISupportInitialize).BeginInit()
        SplitContainer1.Panel1.SuspendLayout()
        SplitContainer1.Panel2.SuspendLayout()
        SplitContainer1.SuspendLayout()
        CType(displayCont, ComponentModel.ISupportInitialize).BeginInit()
        displayCont.Panel2.SuspendLayout()
        displayCont.SuspendLayout()
        SuspendLayout()
        ' 
        ' SplitContainer1
        ' 
        SplitContainer1.Dock = DockStyle.Fill
        SplitContainer1.Location = New Point(0, 0)
        SplitContainer1.Name = "SplitContainer1"
        ' 
        ' SplitContainer1.Panel1
        ' 
        SplitContainer1.Panel1.Controls.Add(lstTables)
        ' 
        ' SplitContainer1.Panel2
        ' 
        SplitContainer1.Panel2.Controls.Add(displayCont)
        SplitContainer1.Size = New Size(1038, 584)
        SplitContainer1.SplitterDistance = 346
        SplitContainer1.TabIndex = 0
        ' 
        ' lstTables
        ' 
        lstTables.Dock = DockStyle.Fill
        lstTables.FormattingEnabled = True
        lstTables.ItemHeight = 15
        lstTables.Location = New Point(0, 0)
        lstTables.Name = "lstTables"
        lstTables.Size = New Size(346, 584)
        lstTables.TabIndex = 0
        ' 
        ' displayCont
        ' 
        displayCont.Dock = DockStyle.Fill
        displayCont.Location = New Point(0, 0)
        displayCont.Name = "displayCont"
        displayCont.Orientation = Orientation.Horizontal
        ' 
        ' displayCont.Panel1
        ' 
        displayCont.Panel1.AllowDrop = True
        displayCont.Panel1.BackColor = SystemColors.ButtonFace
        ' 
        ' displayCont.Panel2
        ' 
        displayCont.Panel2.BackColor = SystemColors.ButtonHighlight
        displayCont.Panel2.Controls.Add(RichTextBox1)
        displayCont.Size = New Size(688, 584)
        displayCont.SplitterDistance = 416
        displayCont.TabIndex = 0
        ' 
        ' RichTextBox1
        ' 
        RichTextBox1.Dock = DockStyle.Fill
        RichTextBox1.Location = New Point(0, 0)
        RichTextBox1.Name = "RichTextBox1"
        RichTextBox1.ReadOnly = True
        RichTextBox1.Size = New Size(688, 164)
        RichTextBox1.TabIndex = 0
        RichTextBox1.Text = ""
        ' 
        ' Form2
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(1038, 584)
        Controls.Add(SplitContainer1)
        Name = "Form2"
        Text = "Form2"
        WindowState = FormWindowState.Maximized
        SplitContainer1.Panel1.ResumeLayout(False)
        SplitContainer1.Panel2.ResumeLayout(False)
        CType(SplitContainer1, ComponentModel.ISupportInitialize).EndInit()
        SplitContainer1.ResumeLayout(False)
        displayCont.Panel2.ResumeLayout(False)
        CType(displayCont, ComponentModel.ISupportInitialize).EndInit()
        displayCont.ResumeLayout(False)
        ResumeLayout(False)
    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents lstTables As ListBox
    Friend WithEvents displayCont As SplitContainer
    Friend WithEvents RichTextBox1 As RichTextBox
End Class
