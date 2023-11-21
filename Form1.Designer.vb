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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        dgv = New DataGridView()
        mst = New MenuStrip()
        btnConnect = New ToolStripMenuItem()
        spc = New SplitContainer()
        trv = New TreeView()
        tspTree = New ToolStrip()
        TreeADD = New ToolStripButton()
        TreeDEL = New ToolStripButton()
        tspGrid = New ToolStrip()
        btnADD = New ToolStripButton()
        btnSave = New ToolStripButton()
        btnDELETE = New ToolStripButton()
        CType(dgv, ComponentModel.ISupportInitialize).BeginInit()
        mst.SuspendLayout()
        CType(spc, ComponentModel.ISupportInitialize).BeginInit()
        spc.Panel1.SuspendLayout()
        spc.Panel2.SuspendLayout()
        spc.SuspendLayout()
        tspTree.SuspendLayout()
        tspGrid.SuspendLayout()
        SuspendLayout()
        ' 
        ' dgv
        ' 
        dgv.AllowUserToAddRows = False
        dgv.AllowUserToDeleteRows = False
        dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize
        dgv.Dock = DockStyle.Fill
        dgv.Location = New Point(0, 25)
        dgv.Name = "dgv"
        dgv.RowTemplate.Height = 25
        dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        dgv.Size = New Size(535, 401)
        dgv.TabIndex = 0
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
        spc.Location = New Point(0, 0)
        spc.Name = "spc"
        ' 
        ' spc.Panel1
        ' 
        spc.Panel1.Controls.Add(trv)
        spc.Panel1.Controls.Add(tspTree)
        ' 
        ' spc.Panel2
        ' 
        spc.Panel2.Controls.Add(dgv)
        spc.Panel2.Controls.Add(tspGrid)
        spc.Size = New Size(800, 426)
        spc.SplitterDistance = 261
        spc.TabIndex = 3
        ' 
        ' trv
        ' 
        trv.Dock = DockStyle.Fill
        trv.Location = New Point(0, 25)
        trv.Name = "trv"
        trv.Size = New Size(261, 401)
        trv.TabIndex = 0
        ' 
        ' tspTree
        ' 
        tspTree.Items.AddRange(New ToolStripItem() {TreeADD, TreeDEL})
        tspTree.Location = New Point(0, 0)
        tspTree.Name = "tspTree"
        tspTree.Size = New Size(261, 25)
        tspTree.TabIndex = 3
        tspTree.Text = "ToolStrip1"
        ' 
        ' TreeADD
        ' 
        TreeADD.DisplayStyle = ToolStripItemDisplayStyle.Image
        TreeADD.Image = CType(resources.GetObject("TreeADD.Image"), Image)
        TreeADD.ImageTransparentColor = Color.Magenta
        TreeADD.Name = "TreeADD"
        TreeADD.Size = New Size(23, 22)
        TreeADD.Text = "ToolStripButton1"
        ' 
        ' TreeDEL
        ' 
        TreeDEL.DisplayStyle = ToolStripItemDisplayStyle.Image
        TreeDEL.Image = CType(resources.GetObject("TreeDEL.Image"), Image)
        TreeDEL.ImageTransparentColor = Color.Magenta
        TreeDEL.Name = "TreeDEL"
        TreeDEL.Size = New Size(23, 22)
        TreeDEL.Text = "ToolStripButton2"
        ' 
        ' tspGrid
        ' 
        tspGrid.Items.AddRange(New ToolStripItem() {btnADD, btnSave, btnDELETE})
        tspGrid.Location = New Point(0, 0)
        tspGrid.Name = "tspGrid"
        tspGrid.Size = New Size(535, 25)
        tspGrid.TabIndex = 2
        tspGrid.Text = "ToolStrip1"
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
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        ClientSize = New Size(800, 450)
        Controls.Add(spc)
        Controls.Add(mst)
        MainMenuStrip = mst
        Name = "Form1"
        Text = "Form1"
        CType(dgv, ComponentModel.ISupportInitialize).EndInit()
        mst.ResumeLayout(False)
        mst.PerformLayout()
        spc.Panel1.ResumeLayout(False)
        spc.Panel1.PerformLayout()
        spc.Panel2.ResumeLayout(False)
        spc.Panel2.PerformLayout()
        CType(spc, ComponentModel.ISupportInitialize).EndInit()
        spc.ResumeLayout(False)
        tspTree.ResumeLayout(False)
        tspTree.PerformLayout()
        tspGrid.ResumeLayout(False)
        tspGrid.PerformLayout()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents dgv As DataGridView
    Friend WithEvents mst As MenuStrip
    Friend WithEvents btnConnect As ToolStripMenuItem
    Friend WithEvents spc As SplitContainer
    Friend WithEvents trv As TreeView
    Friend WithEvents tspTree As ToolStrip
    Friend WithEvents TreeADD As ToolStripButton
    Friend WithEvents tspGrid As ToolStrip
    Friend WithEvents btnADD As ToolStripButton
    Friend WithEvents btnSave As ToolStripButton
    Friend WithEvents btnDELETE As ToolStripButton
    Friend WithEvents TreeDEL As ToolStripButton
End Class
