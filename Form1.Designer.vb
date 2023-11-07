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
        btnDELETE = New ToolStripButton()
        mst = New MenuStrip()
        btnConnect = New ToolStripMenuItem()
        spc = New SplitContainer()
        trv = New TreeView()
        CType(dgv, ComponentModel.ISupportInitialize).BeginInit()
        tsp.SuspendLayout()
        mst.SuspendLayout()
        CType(spc, ComponentModel.ISupportInitialize).BeginInit()
        spc.Panel1.SuspendLayout()
        spc.Panel2.SuspendLayout()
        spc.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgv
        ' 
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv.Dock = DockStyle.Fill
        dgv.Location = New Point(0, 0)
        dgv.Name = "dgv"
        dgv.RowTemplate.Height = 25
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.Size = New Size(533, 401)
        dgv.TabIndex = 0
        ' 
        ' tsp
        ' 
        tsp.Items.AddRange(New ToolStripItem() {btnADD, btnSave, btnDELETE})
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
        ' btnDELETE
        ' 
        btnDELETE.DisplayStyle = ToolStripItemDisplayStyle.Image
        btnDELETE.Image = CType(resources.GetObject("btnDELETE.Image"), Image)
        btnDELETE.ImageTransparentColor = Color.Magenta
        btnDELETE.Name = "btnDELETE"
        btnDELETE.Size = New Size(23, 22)
        btnDELETE.Text = "ToolStripButton1"
        ' 
        ' mst
        ' 
        mst.Dock = DockStyle.Bottom
        mst.Items.AddRange(New ToolStripItem() {btnConnect})
        mst.Location = New Point(0, 426)
        mst.Name = "mst"
        mst.Size = New Size(800, 24)
        mst.TabIndex = 2
        mst.Text = "MenuStrip1"
        ' 
        ' btnConnect
        ' 
        btnConnect.Name = "btnConnect"
        btnConnect.Size = New Size(105, 20)
        btnConnect.Text = "SQL Connection"
        ' 
        ' spc
        ' 
        spc.Dock = DockStyle.Fill
        spc.Location = New Point(0, 25)
        spc.Name = "spc"
        ' 
        ' spc.Panel1
        ' 
        spc.Panel1.Controls.Add(trv)
        ' 
        ' spc.Panel2
        ' 
        spc.Panel2.Controls.Add(dgv)
        spc.Size = New Size(800, 401)
        spc.SplitterDistance = 263
        spc.TabIndex = 3
        ' 
        ' trv
        ' 
        trv.Dock = DockStyle.Fill
        trv.Location = New Point(0, 0)
        trv.Name = "trv"
        trv.Size = New Size(263, 401)
        trv.TabIndex = 0
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(spc)
        Controls.Add(tsp)
        Controls.Add(mst)
        MainMenuStrip = mst
        Name = "Form1"
        Text = "Form1"
        CType(dgv, ComponentModel.ISupportInitialize).EndInit()
        tsp.ResumeLayout(False)
        tsp.PerformLayout()
        mst.ResumeLayout(False)
        mst.PerformLayout()
        spc.Panel1.ResumeLayout(False)
        spc.Panel2.ResumeLayout(False)
        CType(spc, ComponentModel.ISupportInitialize).EndInit()
        spc.ResumeLayout(False)
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents tsp As ToolStrip
    Friend WithEvents btnADD As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnDELETE As ToolStripButton
    Friend WithEvents mst As MenuStrip
    Friend WithEvents btnConnect As ToolStripMenuItem
    Friend WithEvents spc As SplitContainer
    Friend WithEvents trv As TreeView
End Class
