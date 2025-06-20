Namespace GDBGMoveRows
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
			End If
			MyBase.Dispose(disposing)
		End Sub

		#Region "Windows Form Designer generated code"

		''' <summary>
		''' Required method for Designer support - do not modify
		''' the contents of this method with the code editor.
		''' </summary>
		Private Sub InitializeComponent()
			Me.gridDataBoundGrid1 = New Syncfusion.Windows.Forms.Grid.GridDataBoundGrid()
			Me.button1 = New System.Windows.Forms.Button()
			CType(Me.gridDataBoundGrid1, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.SuspendLayout()
			' 
			' gridDataBoundGrid1
			' 
			Me.gridDataBoundGrid1.AllowDragSelectedCols = True
			Me.gridDataBoundGrid1.Location = New System.Drawing.Point(17, 29)
			Me.gridDataBoundGrid1.Name = "gridDataBoundGrid1"
			Me.gridDataBoundGrid1.OptimizeInsertRemoveCells = True
			Me.gridDataBoundGrid1.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus
			Me.gridDataBoundGrid1.Size = New System.Drawing.Size(448, 432)
			Me.gridDataBoundGrid1.SmartSizeBox = False
			Me.gridDataBoundGrid1.SortBehavior = Syncfusion.Windows.Forms.Grid.GridSortBehavior.DoubleClick
			Me.gridDataBoundGrid1.TabIndex = 0
			Me.gridDataBoundGrid1.Text = "gridDataBoundGrid1"
			Me.gridDataBoundGrid1.UseListChangedEvent = True
			Me.gridDataBoundGrid1.UseRightToLeftCompatibleTextBox = True
			' 
			' button1
			' 
			Me.button1.Location = New System.Drawing.Point(471, 132)
			Me.button1.Name = "button1"
			Me.button1.Size = New System.Drawing.Size(75, 23)
			Me.button1.TabIndex = 1
			Me.button1.Text = "Swap rows"
			Me.button1.UseVisualStyleBackColor = True
			' 
			' Form1
			' 
			Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
			Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
			Me.ClientSize = New System.Drawing.Size(629, 510)
			Me.Controls.Add(Me.button1)
			Me.Controls.Add(Me.gridDataBoundGrid1)
			Me.Name = "Form1"
			Me.Text = "EnhancedVisualStyleInGDBG_Demo"
			CType(Me.gridDataBoundGrid1, System.ComponentModel.ISupportInitialize).EndInit()
			Me.ResumeLayout(False)

		End Sub

		#End Region
		Private gridDataBoundGrid1 As Syncfusion.Windows.Forms.Grid.GridDataBoundGrid
		Private WithEvents button1 As System.Windows.Forms.Button
	End Class

End Namespace