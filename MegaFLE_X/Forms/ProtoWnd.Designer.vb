<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class ProtoWnd
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
		Form_Initialize()
	End Sub
	'Form overrides dispose to clean up the component list.
	<System.Diagnostics.DebuggerNonUserCode()> Protected Overloads Overrides Sub Dispose(ByVal Disposing As Boolean)
		If Disposing Then
			If Not components Is Nothing Then
				components.Dispose()
			End If
		End If
		MyBase.Dispose(Disposing)
	End Sub
	'Required by the Windows Form Designer
	Private components As System.ComponentModel.IContainer
	Public ToolTip1 As System.Windows.Forms.ToolTip
    Public WithEvents _ArrFileListView_0 As System.Windows.Forms.ListView
    Public WithEvents _ArrList_0 As System.Windows.Forms.ListBox
    Public WithEvents _ArrBtn_0 As System.Windows.Forms.Button
    Public WithEvents _ArrTB_0 As System.Windows.Forms.TextBox
    Public WithEvents _ArrCombo_0 As System.Windows.Forms.ComboBox
    Public WithEvents _ArrLab_0 As System.Windows.Forms.Label
    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(ProtoWnd))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me._ArrFileListView_0 = New System.Windows.Forms.ListView()
        Me._ArrList_0 = New System.Windows.Forms.ListBox()
        Me._ArrBtn_0 = New System.Windows.Forms.Button()
        Me._ArrTB_0 = New System.Windows.Forms.TextBox()
        Me._ArrCombo_0 = New System.Windows.Forms.ComboBox()
        Me._ArrLab_0 = New System.Windows.Forms.Label()
        Me.ColumnHeader1 = CType(New System.Windows.Forms.ColumnHeader(), System.Windows.Forms.ColumnHeader)
        Me.SuspendLayout()
        '
        '_ArrFileListView_0
        '
        Me._ArrFileListView_0.BackColor = System.Drawing.SystemColors.Window
        Me._ArrFileListView_0.Columns.AddRange(New System.Windows.Forms.ColumnHeader() {Me.ColumnHeader1})
        Me._ArrFileListView_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ArrFileListView_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ArrFileListView_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ArrFileListView_0.HideSelection = False
        Me._ArrFileListView_0.Location = New System.Drawing.Point(8, 160)
        Me._ArrFileListView_0.Name = "_ArrFileListView_0"
        Me._ArrFileListView_0.Size = New System.Drawing.Size(273, 20)
        Me._ArrFileListView_0.TabIndex = 5
        Me._ArrFileListView_0.UseCompatibleStateImageBehavior = False
        Me._ArrFileListView_0.Visible = False
        '
        '_ArrList_0
        '
        Me._ArrList_0.BackColor = System.Drawing.SystemColors.Window
        Me._ArrList_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ArrList_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ArrList_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ArrList_0.ItemHeight = 16
        Me._ArrList_0.Location = New System.Drawing.Point(8, 136)
        Me._ArrList_0.Name = "_ArrList_0"
        Me._ArrList_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ArrList_0.Size = New System.Drawing.Size(273, 20)
        Me._ArrList_0.TabIndex = 4
        Me._ArrList_0.Visible = False
        '
        '_ArrBtn_0
        '
        Me._ArrBtn_0.BackColor = System.Drawing.SystemColors.Control
        Me._ArrBtn_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ArrBtn_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ArrBtn_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ArrBtn_0.Location = New System.Drawing.Point(8, 72)
        Me._ArrBtn_0.Name = "_ArrBtn_0"
        Me._ArrBtn_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ArrBtn_0.Size = New System.Drawing.Size(89, 25)
        Me._ArrBtn_0.TabIndex = 2
        Me._ArrBtn_0.Text = "Command"
        Me._ArrBtn_0.UseVisualStyleBackColor = False
        Me._ArrBtn_0.Visible = False
        '
        '_ArrTB_0
        '
        Me._ArrTB_0.AcceptsReturn = True
        Me._ArrTB_0.BackColor = System.Drawing.SystemColors.Window
        Me._ArrTB_0.Cursor = System.Windows.Forms.Cursors.IBeam
        Me._ArrTB_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ArrTB_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ArrTB_0.Location = New System.Drawing.Point(8, 40)
        Me._ArrTB_0.MaxLength = 0
        Me._ArrTB_0.Multiline = True
        Me._ArrTB_0.Name = "_ArrTB_0"
        Me._ArrTB_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ArrTB_0.Size = New System.Drawing.Size(273, 25)
        Me._ArrTB_0.TabIndex = 1
        Me._ArrTB_0.Visible = False
        '
        '_ArrCombo_0
        '
        Me._ArrCombo_0.BackColor = System.Drawing.SystemColors.Window
        Me._ArrCombo_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ArrCombo_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ArrCombo_0.ForeColor = System.Drawing.SystemColors.WindowText
        Me._ArrCombo_0.Location = New System.Drawing.Point(8, 8)
        Me._ArrCombo_0.Name = "_ArrCombo_0"
        Me._ArrCombo_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ArrCombo_0.Size = New System.Drawing.Size(273, 24)
        Me._ArrCombo_0.TabIndex = 0
        Me._ArrCombo_0.Visible = False
        '
        '_ArrLab_0
        '
        Me._ArrLab_0.BackColor = System.Drawing.SystemColors.Control
        Me._ArrLab_0.Cursor = System.Windows.Forms.Cursors.Default
        Me._ArrLab_0.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me._ArrLab_0.ForeColor = System.Drawing.SystemColors.ControlText
        Me._ArrLab_0.Location = New System.Drawing.Point(16, 104)
        Me._ArrLab_0.Name = "_ArrLab_0"
        Me._ArrLab_0.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me._ArrLab_0.Size = New System.Drawing.Size(185, 17)
        Me._ArrLab_0.TabIndex = 3
        Me._ArrLab_0.Text = "Label"
        Me._ArrLab_0.Visible = False
        '
        'ProtoWnd
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(461, 308)
        Me.Controls.Add(Me._ArrFileListView_0)
        Me.Controls.Add(Me._ArrList_0)
        Me.Controls.Add(Me._ArrBtn_0)
        Me.Controls.Add(Me._ArrTB_0)
        Me.Controls.Add(Me._ArrCombo_0)
        Me.Controls.Add(Me._ArrLab_0)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "ProtoWnd"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Proto"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents ColumnHeader1 As ColumnHeader
#End Region
End Class