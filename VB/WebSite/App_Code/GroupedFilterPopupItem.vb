Imports Microsoft.VisualBasic
Imports System
Imports System.Collections.Generic
Imports System.Linq
Imports System.Web
Imports System.Collections
Imports DevExpress.XtraPivotGrid.Data
Imports System.Runtime.Serialization
Imports System.Runtime.Serialization.Formatters.Binary
Imports System.IO
Imports System.Web.UI.WebControls
Imports DevExpress.Web.ASPxPivotGrid

''' <summary>
''' Summary description for GroupedFilterPopupItem
''' </summary>
Public Class CustomFilterRanges
	Private stringRanges() As String = { "A-G", "H-P", "Q-Z" }
	Private otherGroupName As String = "Other"
	Private targetField As PivotGridField
	Private pivot As ASPxPivotGrid
	Public Sub New(ByVal pivot As ASPxPivotGrid, ByVal field As PivotGridField)
		Me.pivot = pivot
		targetField = field
	End Sub
	Public Sub AddEvents()
		AddHandler pivot.CustomFilterPopupItems, AddressOf pivot_CustomFilterPopupItems
		AddHandler pivot.FieldFilterChanging, AddressOf pivot_FieldFilterChanging
	End Sub
	Public Sub Detach()
		RemoveHandler pivot.CustomFilterPopupItems, AddressOf pivot_CustomFilterPopupItems
		RemoveHandler pivot.FieldFilterChanging, AddressOf pivot_FieldFilterChanging
	End Sub
	Private Sub pivot_FieldFilterChanging(ByVal sender As Object, ByVal e As PivotFieldFilterChangingEventArgs)
		If Equals(e.Field, targetField) Then
			Me.ReplaceRangesByItems(e)
		End If
	End Sub
	Private Sub pivot_CustomFilterPopupItems(ByVal sender As Object, ByVal e As PivotCustomFilterPopupItemsEventArgs)
		If Equals(e.Field, targetField) Then
			Me.ReplaceItemsByCustomRanges(e.Items)
		End If
	End Sub
	Private Sub ReplaceItemsByCustomRanges(ByVal filterItemsCollection As IList(Of PivotGridFilterItem))
		Dim customGroups As Dictionary(Of String, List(Of Object)) = GetCustomRanges(filterItemsCollection)
		PopulateFilterPopupWithCustomRanges(filterItemsCollection, customGroups)
	End Sub
	Private Function GetCustomRanges(ByVal filterItemsCollection As IEnumerable(Of PivotGridFilterItem)) As Dictionary(Of String, List(Of Object))
		Dim ranges As New Dictionary(Of String, List(Of Object))()
		For Each item As PivotGridFilterItem In filterItemsCollection
			If item.IsBlank Then
				Continue For
			End If
			Dim groupValue As String = GetGroupByItem(item)
			If (Not ranges.Keys.Contains(groupValue)) Then
				ranges.Add(groupValue, New List(Of Object)())
			End If
			ranges(groupValue).Add(item)
		Next item
		Return ranges
	End Function
	Private Sub PopulateFilterPopupWithCustomRanges(ByVal filterItemsCollection As IList(Of PivotGridFilterItem), ByVal customGroups As Dictionary(Of String, List(Of Object)))
		RemoveNonBlankFilterItems(filterItemsCollection)
		For Each key As String In customGroups.Keys
			filterItemsCollection.Add(New PivotGridFilterItem(key, key, IsItemsChecked(customGroups(key)), IsGroupVisible(customGroups(key))))
		Next key
	End Sub
	Private Sub RemoveNonBlankFilterItems(ByVal filterItemsCollection As IList(Of PivotGridFilterItem))
		For i As Integer = filterItemsCollection.Count - 1 To 0 Step -1
			If (Not filterItemsCollection(i).IsBlank) Then
				filterItemsCollection.RemoveAt(i)
			End If
		Next i
	End Sub
	Private Function GetGroupByDisplayText(ByVal itemText As String) As String
		For Each key As String In stringRanges
			If IsValueInStringInterval(key, itemText) Then
				Return key
			End If
		Next key
		Return otherGroupName
	End Function
	Private Sub ReplaceRangesByItems(ByVal e As PivotFieldFilterChangingEventArgs)
		Dim currentRanges As New List(Of Object)(e.Values)
		e.Values.Clear()
		For Each value As Object In e.Field.GetUniqueValues()
			If currentRanges.Contains(GetGroupByValue(value)) Then
				e.Values.Add(value)
			End If
		Next value
	End Sub
	Private Function GetGroupByItem(ByVal item As PivotGridFilterItem) As String
		If targetField.ActualDataType Is GetType(DateTime) Then
			Return GetGroupByDate(CDate(item.Value))
		Else
			Return GetGroupByDisplayText(item.Text)
		End If
	End Function
	Private Function GetGroupByValue(ByVal value As Object) As String
		If targetField.ActualDataType Is GetType(DateTime) Then
			Return GetGroupByDate(CDate(value))
		Else
			Return GetGroupByDisplayText(targetField.GetDisplayText(value))
		End If
	End Function
	Private Function IsValueInStringInterval(ByVal range As String, ByVal item As String) As Boolean
		Dim rangeBounds() As String = range.Split("-"c)
		Dim itemUpper As String = item.ToUpper()
		Return itemUpper.Substring(0, System.Math.Min(rangeBounds(0).Length, itemUpper.Length)).CompareTo(rangeBounds(0).ToUpper()) >= 0 AndAlso itemUpper.Substring(0, System.Math.Min(rangeBounds(1).Length, itemUpper.Length)).CompareTo(rangeBounds(1).ToUpper()) <= 0
	End Function
	Private Function GetGroupByDate(ByVal itemDate As DateTime) As String
		Dim lastWeekFirstDay As DateTime = DateTime.Now.AddDays(-6 - CInt(Fix(DateTime.Now.DayOfWeek)))
		If itemDate <= lastWeekFirstDay.AddDays(-1) Then
			Return "Earlier"
		End If
		If itemDate >= lastWeekFirstDay AndAlso itemDate <= lastWeekFirstDay.AddDays(6) Then
			Return "Last Week"
		End If
		If itemDate >= DateTime.Now.AddDays(-CInt(Fix(DateTime.Now.DayOfWeek))) AndAlso itemDate < DateTime.Today Then
			Return "This Week"
		End If
		If itemDate = DateTime.Today Then
			Return "Today"
		End If
		If itemDate > DateTime.Today Then
			Return "Later"
		End If
		Return otherGroupName
	End Function
	Private Function IsGroupVisible(ByVal items As List(Of Object)) As Boolean
		For Each filterItem As PivotGridFilterItem In items
			If filterItem.IsVisible Then
				Return True
			End If
		Next filterItem
		Return False
	End Function
	Private Function IsItemsChecked(ByVal items As List(Of Object)) As Boolean
		For Each filterItem As PivotGridFilterItem In items
			If filterItem.IsChecked = False Then
				Return False
			End If
		Next filterItem
		Return True
	End Function
End Class