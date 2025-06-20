Imports Syncfusion.Windows.Forms.Grid
Imports Syncfusion.Windows.Forms
Imports System
Imports System.Collections
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Linq
Imports System.Text
Imports System.Threading.Tasks
Imports System.Windows.Forms

Namespace GDBGMoveRows
	Partial Public Class Form1
		Inherits Form

		Private gridBoundColumn1 As Syncfusion.Windows.Forms.Grid.GridBoundColumn
		Private gridBoundColumn2 As Syncfusion.Windows.Forms.Grid.GridBoundColumn
		Private gridBoundColumn3 As Syncfusion.Windows.Forms.Grid.GridBoundColumn

		Public Sub New()
			InitializeComponent()

			Me.gridBoundColumn1 = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
			Me.gridBoundColumn1.HeaderText = "Column1"
			Me.gridBoundColumn1.MappingName = "Column1"
			Me.gridBoundColumn2 = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
			Me.gridBoundColumn2.HeaderText = "Column2"
			Me.gridBoundColumn2.MappingName = "Column2"
			Me.gridBoundColumn3 = New Syncfusion.Windows.Forms.Grid.GridBoundColumn()
			Me.gridBoundColumn3.HeaderText = "Column3"
			Me.gridBoundColumn3.MappingName = "Column3"

			Me.gridDataBoundGrid1.GridBoundColumns.AddRange(New Syncfusion.Windows.Forms.Grid.GridBoundColumn() {Me.gridBoundColumn1, Me.gridBoundColumn2, Me.gridBoundColumn3}) ', this.gridBoundColumn3, this.gridBoundColumn4, this.gridBoundColumn5, this.gridBoundColumn6 });
			Me.gridDataBoundGrid1.Model.EnableLegacyStyle = False
			Me.gridDataBoundGrid1.GridVisualStyles = GridVisualStyles.Office2010Black


		End Sub

		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
			Dim dt As New DataTable()
			Dim nCols As Integer = 3
			Dim nRows As Integer = 10

			dt.Columns.Add("sortKey", GetType(Integer)) ' Add sortKey for sorting
			dt.Columns.Add("Column1")
			dt.Columns.Add("Column2")
			dt.Columns.Add("Column3")

			For i As Integer = 0 To nRows - 1
				Dim dr As DataRow = dt.NewRow()
				dr("sortKey") = i ' Set initial sortKey
				dr("Column1") = "Item " & i
				dr("Column2") = "Value A" & i
				dr("Column3") = "Value B" & i
				dt.Rows.Add(dr)
			Next i

			' Sort by sortKey
			dt.DefaultView.Sort = "sortKey ASC"
			Me.gridDataBoundGrid1.DataSource = dt

			' Hide sortKey from UI
			Dim sortCol = New GridBoundColumn()
			sortCol.MappingName = "sortKey"
			sortCol.HeaderText = "sortKey"
			sortCol.StyleInfo.CellType = "Static"


			Me.gridDataBoundGrid1.GridBoundColumns.Clear()
			Me.gridDataBoundGrid1.GridBoundColumns.AddRange(New GridBoundColumn() {Me.gridBoundColumn1, Me.gridBoundColumn2, Me.gridBoundColumn3})

			Me.gridDataBoundGrid1.ThemesEnabled = True
			Me.gridDataBoundGrid1.DefaultColWidth = 135
		End Sub

		Private Sub Swap(ByVal row1 As Integer, ByVal row2 As Integer)


			Dim cm As CurrencyManager = CType(Me.BindingContext(Me.gridDataBoundGrid1.DataSource, Me.gridDataBoundGrid1.DataMember), CurrencyManager)

			If row1 < cm.Count AndAlso row2 < cm.Count AndAlso row1 > -1 AndAlso row2 > -1 Then


				Dim drv1 As DataRowView = DirectCast(cm.List(row1), DataRowView)

				Dim val1 As Integer = DirectCast(drv1.Row("sortKey"), Integer)

				Dim drv2 As DataRowView = DirectCast(cm.List(row2), DataRowView)

				Dim val2 As Integer = DirectCast(drv2.Row("sortKey"), Integer)

				drv1.Row("sortKey") = val2

				drv2.Row("sortKey") = val1

			End If

		End Sub

		Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
			Dim selectedRow As Integer = Me.gridDataBoundGrid1.CurrentCell.RowIndex

			' Ensure the selected row is valid and not the last row
			If selectedRow > 0 AndAlso selectedRow < gridDataBoundGrid1.Model.RowCount - 1 Then
				Swap(selectedRow - 1, selectedRow)
			End If
		End Sub
	End Class
End Namespace
