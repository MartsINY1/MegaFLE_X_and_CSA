<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class PalChart
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
	Public WithEvents PalChartPic As System.Windows.Forms.PictureBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.PalChartPic = New System.Windows.Forms.PictureBox()
        CType(Me.PalChartPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'PalChartPic
        '
        Me.PalChartPic.BackColor = System.Drawing.SystemColors.ActiveCaption
        Me.PalChartPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PalChartPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.PalChartPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PalChartPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.PalChartPic.Location = New System.Drawing.Point(0, 0)
        Me.PalChartPic.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.PalChartPic.Name = "PalChartPic"
        Me.PalChartPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.PalChartPic.Size = New System.Drawing.Size(132, 132)
        Me.PalChartPic.TabIndex = 0
        Me.PalChartPic.TabStop = False
        '
        'PalChart
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(131, 131)
        Me.Controls.Add(Me.PalChartPic)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 20)
        Me.Margin = New System.Windows.Forms.Padding(4, 2, 4, 2)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "PalChart"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "NES Pal"
        CType(Me.PalChartPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
#End Region
End Class