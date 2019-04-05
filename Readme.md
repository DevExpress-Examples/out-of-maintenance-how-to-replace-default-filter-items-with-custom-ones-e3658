<!-- default file list -->
*Files to look at*:

* [GroupedFilterPopupItem.cs](./CS/WebSite/App_Code/GroupedFilterPopupItem.cs) (VB: [GroupedFilterPopupItem.vb](./VB/WebSite/App_Code/GroupedFilterPopupItem.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to replace default filter items with custom ones


<p>In some situation it can be helpful to replace default items with custom ones. E.g. if you have too many items they can be convenient for grouping them based upon certain criteria and displaying group items in a filter popup. It is possible to handle the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_CustomFilterPopupItemstopic">CustomFilterPopupItems </a> event to remove default items and add group items instead. To apply a filter based upon the selected by end-users, handle the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_FieldFilterChangingtopic">FieldFilterChanging</a> event.</p>

<br/>


