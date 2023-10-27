<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As ComponentModel.ComponentResourceManager = New ComponentModel.ComponentResourceManager(GetType(Form1))
        dgv = New DataGridView()
        tsp = New ToolStrip()
        btnADD = New ToolStripButton()
        btnSave = New ToolStripButton()
        CType(dgv, ComponentModel.ISupportInitialize).BeginInit()
        tsp.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgv
        ' 
        dgv.AllowUserToAddRows = False
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv.Dock = DockStyle.Fill
        dgv.Location = New Point(0, 25)
        dgv.Name = "dgv"
        dgv.RowTemplate.Height = 25
        dgv.Size = New Size(800, 425)
        dgv.TabIndex = 0
        ' 
        ' tsp
        ' 
        tsp.Items.AddRange(New ToolStripItem() {btnADD, btnSave})
        tsp.Location = New Point(0, 0)
        tsp.Name = "tsp"
        tsp.Size = New Size(800, 25)
        tsp.TabIndex = 1
        tsp.Text = "ToolStrip1"
        ' 
        ' btnADD
        ' 
        btnADD.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnADD.Image = CType(resources.GetObject("btnADD.Image"), Image)
        btnADD.ImageTransparentColor = Color.Magenta
        btnADD.Name = "btnADD"
        btnADD.Size = New Size(23, 22)
        btnADD.Text = "ADD"
        ' 
        ' btnSave
        ' 
        btnSave.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnSave.Image = CType(resources.GetObject("btnSave.Image"), Image)
        btnSave.ImageTransparentColor = Color.Magenta
        btnSave.Name = "btnSave"
        btnSave.Size = New Size(23, 22)
        btnSave.Text = "ToolStripButton1"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(dgv)
        Controls.Add(tsp)
        Name = "Form1"
        Text = "Form1"
        CType(dgv, ComponentModel.ISupportInitialize).EndInit()
        tsp.ResumeLayout(False)
        tsp.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents tsp As ToolStrip
    Friend WithEvents btnADD As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
End Class
