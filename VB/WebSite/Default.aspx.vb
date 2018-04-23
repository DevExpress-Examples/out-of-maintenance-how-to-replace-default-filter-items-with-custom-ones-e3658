Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Web.UI
Imports System.Web.UI.WebControls
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports System.Data
Imports DevExpress.Web.ASPxPivotGrid
Imports DevExpress.XtraPivotGrid

Partial Public Class _Default
	Inherits System.Web.UI.Page
	Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs)
		ASPxPivotGrid1.DataSource = CreateCustomDataTable()
		If (Not IsPostBack) AndAlso (Not IsCallback) Then
			Dim fieldQuantity As New PivotGridField("Quantity", PivotArea.DataArea)
			Dim fieldProductName As New PivotGridField("ProductName", PivotArea.RowArea)
			Dim fieldDate As New PivotGridField("Date", PivotArea.ColumnArea)
			fieldDate.GroupInterval = PivotGroupInterval.Date
			ASPxPivotGrid1.Fields.AddField(fieldProductName)
			ASPxPivotGrid1.Fields.AddField(fieldDate)
			ASPxPivotGrid1.Fields.AddField(fieldQuantity)
		End If
		CType(New CustomFilterRanges(ASPxPivotGrid1, ASPxPivotGrid1.Fields("ProductName")), CustomFilterRanges).AddEvents()
		CType(New CustomFilterRanges(ASPxPivotGrid1, ASPxPivotGrid1.Fields("Date")), CustomFilterRanges).AddEvents()
	End Sub
	Private Function CreateCustomDataTable() As DataTable
		Dim customDataTable As New DataTable("Shopping")
		customDataTable.Columns.Add("Quantity", GetType(Single))
		customDataTable.Columns.Add("Price", GetType(Single))
		customDataTable.Columns.Add("ProductName", GetType(String))
		customDataTable.Columns.Add("Date", GetType(DateTime))
		customDataTable.Rows.Add(5.0, 50.0, Nothing, DateTime.Today.AddYears(-1).AddMonths(-1))
		customDataTable.Rows.Add(10.0, 31.0, Nothing, DateTime.Today.AddYears(-1).AddMonths(-1))
		customDataTable.Rows.Add(3.0, 30.0, Nothing, DateTime.Today.AddYears(-1).AddMonths(-1))
		customDataTable.Rows.Add(3.5, 230.0, "Bananas", DateTime.Today.AddYears(-1).AddMonths(-1))
		customDataTable.Rows.Add(5.0, 50.0, "Apples", DateTime.Today.AddDays(-8))
		customDataTable.Rows.Add(10.0, 31.0, "Peaches", DateTime.Today.AddDays(-8))
		customDataTable.Rows.Add(3.0, 30.0, "Lemons", DateTime.Today.AddDays(-8))
		customDataTable.Rows.Add(3.5, 230.0, "Bananas", DateTime.Today.AddDays(-8))
		customDataTable.Rows.Add(5.0, 52.0, "Apples", DateTime.Today.AddDays(-7))
		customDataTable.Rows.Add(1.0, 33.0, "Peaches", DateTime.Today.AddDays(-7))
		customDataTable.Rows.Add(2.0, 32.0, "Lemons", DateTime.Today.AddDays(-7))
		customDataTable.Rows.Add(2.3, 250.20, "Bananas", DateTime.Today.AddDays(-7))
		customDataTable.Rows.Add(5.0, 50.0, "Apples", DateTime.Today.AddDays(-6))
		customDataTable.Rows.Add(10.0, 31.0, "Peaches", DateTime.Today.AddDays(-6))
		customDataTable.Rows.Add(3.0, 30.0, "Lemons", DateTime.Today.AddDays(-6))
		customDataTable.Rows.Add(3.5, 230.0, "Bananas", DateTime.Today.AddDays(-6))
		customDataTable.Rows.Add(5.0, 52.0, "Apples", DateTime.Today.AddDays(-2))
		customDataTable.Rows.Add(1.0, 33.0, "Peaches", DateTime.Today.AddDays(-2))
		customDataTable.Rows.Add(2.0, 32.0, "Lemons", DateTime.Today.AddDays(-2))
		customDataTable.Rows.Add(2.3, 250.20, "Bananas", DateTime.Today.AddDays(-2))
		customDataTable.Rows.Add(1.0, 55.0, "Apples", DateTime.Today.AddDays(-1))
		customDataTable.Rows.Add(2.0, 38.0, "Peaches", DateTime.Today.AddDays(-1))
		customDataTable.Rows.Add(1.0, 36.0, "Lemons", DateTime.Today.AddDays(-1))
		customDataTable.Rows.Add(2.0, 55.0, "Apples", DateTime.Today)
		customDataTable.Rows.Add(2.0, 39.0, "Peaches", DateTime.Today)
		customDataTable.Rows.Add(1.0, 37.0, "Lemons", DateTime.Today)
		customDataTable.Rows.Add(3.5, 270.30, "Bananas", DateTime.Today)
		customDataTable.Rows.Add(2.0, 55.0, "Apples", DateTime.Today.AddDays(1))
		customDataTable.Rows.Add(3.0, 40.5, "Peaches", DateTime.Today.AddDays(1))
		customDataTable.Rows.Add(4.2, 290.8, "Bananas", DateTime.Today.AddDays(1))
		customDataTable.Rows.Add(10.0, 56.0, "Apples", DateTime.Today.AddMonths(1))
		customDataTable.Rows.Add(1.0, 41.0, "Peaches", DateTime.Today.AddMonths(1))
		customDataTable.Rows.Add(2.0, 39.0, "Lemons", DateTime.Today.AddMonths(1))
		customDataTable.Rows.Add(1.5, 290.30, "Bananas", DateTime.Today.AddMonths(1))
		customDataTable.Rows.Add(10.0, 56.0, "Apples", DateTime.Today.AddMonths(1).AddDays(1))
		customDataTable.Rows.Add(1.0, 41.0, "Peaches", DateTime.Today.AddMonths(1).AddDays(1))
		customDataTable.Rows.Add(2.0, 39.0, "Lemons", DateTime.Today.AddMonths(1).AddDays(1))
		customDataTable.Rows.Add(1.5, 290.30, "Bananas", DateTime.Today.AddMonths(1).AddDays(1))
		customDataTable.Rows.Add(5.0, 57.2, "Apples", DateTime.Today.AddYears(1))
		customDataTable.Rows.Add(3.0, 42.0, "Peaches", DateTime.Today.AddYears(1))
		customDataTable.Rows.Add(1.0, 43.0, "Lemons", DateTime.Today.AddYears(1))
		customDataTable.Rows.Add(1.2, 295.30, "Bananas", DateTime.Today.AddYears(1))
		Return customDataTable
	End Function
End Class
