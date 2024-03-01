<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class Support
#Region "Windows Form Designer generated code "
	<System.Diagnostics.DebuggerNonUserCode()> Public Sub New()
		MyBase.New()
		'This call is required by the Windows Form Designer.
		InitializeComponent()
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
	Public WithEvents SupFLB As ListBox
	Public WithEvents ExitBtn As System.Windows.Forms.Button
	Public WithEvents GoBtn As System.Windows.Forms.Button
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Support))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.SupFLB = New System.Windows.Forms.ListBox()
        Me.ExitBtn = New System.Windows.Forms.Button()
        Me.GoBtn = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'SupFLB
        '
        Me.SupFLB.BackColor = System.Drawing.SystemColors.Window
        Me.SupFLB.Cursor = System.Windows.Forms.Cursors.Default
        Me.SupFLB.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SupFLB.ForeColor = System.Drawing.SystemColors.WindowText
        Me.SupFLB.ItemHeight = 16
        Me.SupFLB.Location = New System.Drawing.Point(0, 0)
        Me.SupFLB.Name = "SupFLB"
        Me.SupFLB.Size = New System.Drawing.Size(193, 148)
        Me.SupFLB.TabIndex = 2
        '
        'ExitBtn
        '
        Me.ExitBtn.BackColor = System.Drawing.SystemColors.Control
        Me.ExitBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.ExitBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ExitBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.ExitBtn.Location = New System.Drawing.Point(96, 160)
        Me.ExitBtn.Name = "ExitBtn"
        Me.ExitBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ExitBtn.Size = New System.Drawing.Size(97, 25)
        Me.ExitBtn.TabIndex = 1
        Me.ExitBtn.Text = "Exit"
        Me.ExitBtn.UseVisualStyleBackColor = False
        '
        'GoBtn
        '
        Me.GoBtn.BackColor = System.Drawing.SystemColors.Control
        Me.GoBtn.Cursor = System.Windows.Forms.Cursors.Default
        Me.GoBtn.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.GoBtn.ForeColor = System.Drawing.SystemColors.ControlText
        Me.GoBtn.Location = New System.Drawing.Point(0, 160)
        Me.GoBtn.Name = "GoBtn"
        Me.GoBtn.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.GoBtn.Size = New System.Drawing.Size(89, 25)
        Me.GoBtn.TabIndex = 0
        Me.GoBtn.Text = "Go"
        Me.GoBtn.UseVisualStyleBackColor = False
        '
        'Support
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(195, 189)
        Me.Controls.Add(Me.SupFLB)
        Me.Controls.Add(Me.ExitBtn)
        Me.Controls.Add(Me.GoBtn)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 22)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Support"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Choose support file"
        Me.TopMost = True
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class