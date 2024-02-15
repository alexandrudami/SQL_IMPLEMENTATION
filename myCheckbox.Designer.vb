<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class myCheckbox
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
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
        box = New CheckBox()
        lbl = New Label()
        SuspendLayout()
        ' 
        ' box
        ' 
        box.AutoSize = True
        box.Location = New Point(3, 3)
        box.Name = "box"
        box.Size = New Size(15, 14)
        box.TabIndex = 0
        box.UseVisualStyleBackColor = True
        ' 
        ' lbl
        ' 
        lbl.AllowDrop = True
        lbl.AutoSize = True
        lbl.Location = New Point(24, 2)
        lbl.Name = "lbl"
        lbl.Size = New Size(35, 15)
        lbl.TabIndex = 1
        lbl.Text = "Label"
        ' 
        ' myCheckbox
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        Controls.Add(lbl)
        Controls.Add(box)
        Name = "myCheckbox"
        Size = New Size(62, 20)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents box As CheckBox
    Friend WithEvents lbl As Label

End Class
