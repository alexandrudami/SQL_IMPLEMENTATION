<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MyTable
    Inherits System.Windows.Forms.UserControl

    'UserControl overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MyTable))
        schemaPanel = New Panel()
        tsp = New ToolStrip()
        lblName = New ToolStripLabel()
        ToolStripButton1 = New ToolStripButton()
        schemaPanel.SuspendLayout()
        tsp.SuspendLayout()
        SuspendLayout()
        ' 
        ' schemaPanel
        ' 
        schemaPanel.AllowDrop = True
        schemaPanel.AutoScroll = True
        schemaPanel.BackColor = SystemColors.ControlLightLight
        schemaPanel.Controls.Add(tsp)
        schemaPanel.Dock = DockStyle.Fill
        schemaPanel.Location = New Point(0, 0)
        schemaPanel.Name = "schemaPanel"
        schemaPanel.Size = New Size(208, 262)
        schemaPanel.TabIndex = 0
        ' 
        ' tsp
        ' 
        tsp.BackColor = Color.LightSteelBlue
        tsp.Items.AddRange(New ToolStripItem() {lblName, ToolStripButton1})
        tsp.Location = New Point(0, 0)
        tsp.Name = "tsp"
        tsp.Size = New Size(208, 25)
        tsp.TabIndex = 0
        tsp.Text = "ToolStrip1"
        ' 
        ' lblName
        ' 
        lblName.Name = "lblName"
        lblName.Size = New Size(39, 22)
        lblName.Text = "Name"
        ' 
        ' ToolStripButton1
        ' 
        ToolStripButton1.Alignment = ToolStripItemAlignment.Right
        ToolStripButton1.DisplayStyle = ToolStripItemDisplayStyle.Image
        ToolStripButton1.Image = CType(resources.GetObject("ToolStripButton1.Image"), Image)
        ToolStripButton1.ImageTransparentColor = Color.Magenta
        ToolStripButton1.Name = "ToolStripButton1"
        ToolStripButton1.Size = New Size(23, 22)
        ToolStripButton1.Text = "ToolStripButton1"
        ' 
        ' MyTable
        ' 
        AllowDrop = True
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BorderStyle = BorderStyle.FixedSingle
        Controls.Add(schemaPanel)
        Name = "MyTable"
        Size = New Size(208, 262)
        schemaPanel.ResumeLayout(False)
        schemaPanel.PerformLayout()
        tsp.ResumeLayout(False)
        tsp.PerformLayout()
        ResumeLayout(False)
    End Sub

    Friend WithEvents schemaPanel As Panel
    Friend WithEvents tsp As ToolStrip
    Friend WithEvents lblName As ToolStripLabel
    Friend WithEvents ToolStripButton1 As ToolStripButton

End Class
