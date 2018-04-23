using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using DevExpress.XtraPivotGrid.Data;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Web.UI.WebControls;
using DevExpress.Web.ASPxPivotGrid;

/// <summary>
/// Summary description for GroupedFilterPopupItem
/// </summary>
public class CustomFilterRanges {
    string[] stringRanges = new string[] { "A-G", "H-P", "Q-Z" };
    string otherGroupName = "Other";
    PivotGridField targetField;
    ASPxPivotGrid pivot;
    public CustomFilterRanges(ASPxPivotGrid pivot, PivotGridField field) {
        this.pivot = pivot;
        targetField = field;
    }
    public void AddEvents() {
        pivot.CustomFilterPopupItems +=new EventHandler<PivotCustomFilterPopupItemsEventArgs>(pivot_CustomFilterPopupItems);
        pivot.FieldFilterChanging +=new PivotFieldFilterChangingEventHandler(pivot_FieldFilterChanging);
    }
    public void Detach() {
        pivot.CustomFilterPopupItems -= pivot_CustomFilterPopupItems;
        pivot.FieldFilterChanging -= pivot_FieldFilterChanging;
    }
    void pivot_FieldFilterChanging(object sender, PivotFieldFilterChangingEventArgs e) {
        if (Equals(e.Field, targetField))
            this.ReplaceRangesByItems(e);
    }
    void pivot_CustomFilterPopupItems(object sender, PivotCustomFilterPopupItemsEventArgs e) {
        if (Equals(e.Field, targetField))
            this.ReplaceItemsByCustomRanges(e.Items);
    }
    void ReplaceItemsByCustomRanges(IList<PivotGridFilterItem> filterItemsCollection) {
        Dictionary<string, List<object>> customGroups = GetCustomRanges(filterItemsCollection);
        PopulateFilterPopupWithCustomRanges(filterItemsCollection, customGroups);
    }
    Dictionary<string, List<object>> GetCustomRanges(IEnumerable<PivotGridFilterItem> filterItemsCollection) {
        Dictionary<string, List<object>> ranges = new Dictionary<string, List<object>>();
        foreach (PivotGridFilterItem item in filterItemsCollection) {
            if (item.IsBlank) continue;
            string groupValue = GetGroupByItem(item);
            if (!ranges.Keys.Contains(groupValue))
                ranges.Add(groupValue, new List<object>());
            ranges[groupValue].Add(item);
        }
        return ranges;
    }
    void PopulateFilterPopupWithCustomRanges(IList<PivotGridFilterItem> filterItemsCollection, Dictionary<string, List<object>> customGroups) {
        RemoveNonBlankFilterItems(filterItemsCollection);
        foreach (string key in customGroups.Keys)
            filterItemsCollection.Add(new PivotGridFilterItem(key, key, IsItemsChecked(customGroups[key]), IsGroupVisible(customGroups[key])));
    }
    void RemoveNonBlankFilterItems(IList<PivotGridFilterItem> filterItemsCollection) {
        for (int i = filterItemsCollection.Count - 1; i >= 0; --i)
            if (!filterItemsCollection[i].IsBlank) filterItemsCollection.RemoveAt(i);
    }
    string GetGroupByDisplayText(string itemText) {
        foreach (string key in stringRanges)
            if (IsValueInStringInterval(key, itemText))
                return key;
        return otherGroupName;
    }
    void ReplaceRangesByItems(PivotFieldFilterChangingEventArgs e) {
        List<object> currentRanges = new List<object>(e.Values);
        e.Values.Clear();
        foreach (object value in e.Field.GetUniqueValues())
            if (currentRanges.Contains(GetGroupByValue(value)))
                e.Values.Add(value);
    }
    string GetGroupByItem(PivotGridFilterItem item) {
        return targetField.ActualDataType == typeof(DateTime) ? GetGroupByDate((DateTime)item.Value) : GetGroupByDisplayText(item.Text);
    }
    string GetGroupByValue(object value) {
        return targetField.ActualDataType == typeof(DateTime) ? GetGroupByDate((DateTime)value) : GetGroupByDisplayText(targetField.GetDisplayText(value));
    }
    bool IsValueInStringInterval(string range, string item) {
        string[] rangeBounds = range.Split('-');
        string itemUpper = item.ToUpper();
        return itemUpper.Substring(0, System.Math.Min(rangeBounds[0].Length, itemUpper.Length)).CompareTo(rangeBounds[0].ToUpper()) >= 0 &&
            itemUpper.Substring(0, System.Math.Min(rangeBounds[1].Length, itemUpper.Length)).CompareTo(rangeBounds[1].ToUpper()) <= 0;
    }
    string GetGroupByDate(DateTime itemDate) {
        DateTime lastWeekFirstDay = DateTime.Now.AddDays(-6 - (int)DateTime.Now.DayOfWeek);
        if (itemDate <= lastWeekFirstDay.AddDays(-1))
            return "Earlier";
        if (itemDate >= lastWeekFirstDay && itemDate <= lastWeekFirstDay.AddDays(6))
            return "Last Week";
        if (itemDate >= DateTime.Now.AddDays(-(int)DateTime.Now.DayOfWeek) && itemDate < DateTime.Today)
            return "This Week";
        if (itemDate == DateTime.Today)
            return "Today";
        if (itemDate > DateTime.Today)
            return "Later";
        return otherGroupName;
    }
    bool IsGroupVisible(List<object> items) {
        foreach (PivotGridFilterItem filterItem in items)
            if (filterItem.IsVisible) return true;
        return false;
    }
    bool IsItemsChecked(List<object> items) {
        foreach (PivotGridFilterItem filterItem in items)
            if (filterItem.IsChecked == false) return false;
        return true;
    }
}