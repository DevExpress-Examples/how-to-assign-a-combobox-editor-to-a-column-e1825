Imports Microsoft.VisualBasic
Imports System.Collections.Generic
Imports System.Windows.Controls
Imports DevExpress.AgDataGrid
Imports DevExpress.Xpf.Editors.Settings

Namespace AgDataGrid_AssignComboBoxEdit
	Partial Public Class MainPage
		Inherits UserControl
		Public Sub New()
			InitializeComponent()
			grid.DataSource = ProductList.GetData()
			InitComboBoxColumn(grid.Columns("Country"))
		End Sub
		Private Sub InitComboBoxColumn(ByVal column As AgDataGridColumn)
			CType(column.EditSettings, ComboBoxEditSettings).ItemsSource = GetCountries(CType(grid.DataSource, List(Of Product)))
		End Sub
		Private Function GetCountries(ByVal ds As List(Of Product)) As List(Of String)
			Dim list As New List(Of String)()
			For Each p As Product In ds
				If (Not list.Contains(p.Country)) Then
					list.Add(p.Country)
				End If
			Next p
			Return list
		End Function
	End Class
End Namespace
