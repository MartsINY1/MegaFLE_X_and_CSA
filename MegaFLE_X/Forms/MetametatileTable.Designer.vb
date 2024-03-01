<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> Partial Class MetametatileTable
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
	Public WithEvents StrPic As System.Windows.Forms.PictureBox
	'NOTE: The following procedure is required by the Windows Form Designer
	'It can be modified using the Windows Form Designer.
	'Do not modify it using the code editor.
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MetametatileTable))
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.BtnClearUnusedMetametatiles = New System.Windows.Forms.Button()
        Me.BtnClearDuplicated = New System.Windows.Forms.Button()
        Me.BtnOptimiseLowerMetametatilesUsage = New System.Windows.Forms.Button()
        Me.StrPic = New System.Windows.Forms.PictureBox()
        Me.BtnShowSelected = New System.Windows.Forms.Button()
        CType(Me.StrPic, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ToolTip1
        '
        Me.ToolTip1.AutoPopDelay = 15000
        Me.ToolTip1.InitialDelay = 500
        Me.ToolTip1.ReshowDelay = 100
        '
        'BtnClearUnusedMetametatiles
        '
        Me.BtnClearUnusedMetametatiles.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnClearUnusedMetametatiles.Location = New System.Drawing.Point(5, 519)
        Me.BtnClearUnusedMetametatiles.Name = "BtnClearUnusedMetametatiles"
        Me.BtnClearUnusedMetametatiles.Size = New System.Drawing.Size(110, 40)
        Me.BtnClearUnusedMetametatiles.TabIndex = 1
        Me.BtnClearUnusedMetametatiles.Text = "Clear Unused Metametatiles"
        Me.ToolTip1.SetToolTip(Me.BtnClearUnusedMetametatiles, "Clear all unused Metametatiles." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "TIP: Every Screen is checked by current function" &
        "," & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "including the Screen Layouts not assigned to any" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Screen." & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10))
        Me.BtnClearUnusedMetametatiles.UseVisualStyleBackColor = True
        '
        'BtnClearDuplicated
        '
        Me.BtnClearDuplicated.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnClearDuplicated.Location = New System.Drawing.Point(119, 519)
        Me.BtnClearDuplicated.Name = "BtnClearDuplicated"
        Me.BtnClearDuplicated.Size = New System.Drawing.Size(110, 40)
        Me.BtnClearDuplicated.TabIndex = 3
        Me.BtnClearDuplicated.Text = "Clear Duplicated Metametatiles"
        Me.ToolTip1.SetToolTip(Me.BtnClearDuplicated, resources.GetString("BtnClearDuplicated.ToolTip"))
        Me.BtnClearDuplicated.UseVisualStyleBackColor = True
        '
        'BtnOptimiseLowerMetametatilesUsage
        '
        Me.BtnOptimiseLowerMetametatilesUsage.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnOptimiseLowerMetametatilesUsage.Location = New System.Drawing.Point(233, 519)
        Me.BtnOptimiseLowerMetametatilesUsage.Name = "BtnOptimiseLowerMetametatilesUsage"
        Me.BtnOptimiseLowerMetametatilesUsage.Size = New System.Drawing.Size(153, 40)
        Me.BtnOptimiseLowerMetametatilesUsage.TabIndex = 4
        Me.BtnOptimiseLowerMetametatilesUsage.Text = "Optimise Lower Metametatiles Usage"
        Me.ToolTip1.SetToolTip(Me.BtnOptimiseLowerMetametatilesUsage, resources.GetString("BtnOptimiseLowerMetametatilesUsage.ToolTip"))
        Me.BtnOptimiseLowerMetametatilesUsage.UseVisualStyleBackColor = True
        '
        'StrPic
        '
        Me.StrPic.BackColor = System.Drawing.SystemColors.Control
        Me.StrPic.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.StrPic.Cursor = System.Windows.Forms.Cursors.Default
        Me.StrPic.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.StrPic.ForeColor = System.Drawing.SystemColors.ControlText
        Me.StrPic.Location = New System.Drawing.Point(0, 0)
        Me.StrPic.Name = "StrPic"
        Me.StrPic.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.StrPic.Size = New System.Drawing.Size(518, 518)
        Me.StrPic.TabIndex = 0
        Me.StrPic.TabStop = False
        '
        'BtnShowSelected
        '
        Me.BtnShowSelected.Font = New System.Drawing.Font("Arial", 8.25!, System.Drawing.FontStyle.Bold)
        Me.BtnShowSelected.Location = New System.Drawing.Point(403, 519)
        Me.BtnShowSelected.Name = "BtnShowSelected"
        Me.BtnShowSelected.Size = New System.Drawing.Size(110, 40)
        Me.BtnShowSelected.TabIndex = 2
        Me.BtnShowSelected.Text = "Show Selected"
        Me.BtnShowSelected.UseVisualStyleBackColor = True
        '
        'MetametatileTable
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(7.0!, 16.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.Control
        Me.ClientSize = New System.Drawing.Size(517, 563)
        Me.Controls.Add(Me.BtnOptimiseLowerMetametatilesUsage)
        Me.Controls.Add(Me.BtnClearDuplicated)
        Me.Controls.Add(Me.BtnShowSelected)
        Me.Controls.Add(Me.BtnClearUnusedMetametatiles)
        Me.Controls.Add(Me.StrPic)
        Me.Cursor = System.Windows.Forms.Cursors.Default
        Me.Font = New System.Drawing.Font("Arial", 8.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(3, 28)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "MetametatileTable"
        Me.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.Text = "Metametatile Table"
        CType(Me.StrPic, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents BtnClearUnusedMetametatiles As Button
    Friend WithEvents BtnShowSelected As Button
    Friend WithEvents BtnClearDuplicated As Button
    Friend WithEvents BtnOptimiseLowerMetametatilesUsage As Button
#End Region
End Class