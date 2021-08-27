<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128577737/11.2.5%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E3658)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [GroupedFilterPopupItem.cs](./CS/WebSite/App_Code/GroupedFilterPopupItem.cs) (VB: [GroupedFilterPopupItem.vb](./VB/WebSite/App_Code/GroupedFilterPopupItem.vb))
* [Default.aspx](./CS/WebSite/Default.aspx) (VB: [Default.aspx](./VB/WebSite/Default.aspx))
* [Default.aspx.cs](./CS/WebSite/Default.aspx.cs) (VB: [Default.aspx.vb](./VB/WebSite/Default.aspx.vb))
<!-- default file list end -->
# How to replace default filter items with custom ones
<!-- run online -->
**[[Run Online]](https://codecentral.devexpress.com/e3658/)**
<!-- run online end -->


<p>In some situation it can be helpful to replace default items with custom ones. E.g. if you have too many items they can be convenient for grouping them based upon certain criteria and displaying group items in a filter popup. It is possible to handle the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_CustomFilterPopupItemstopic">CustomFilterPopupItems </a> event to remove default items and add group items instead. To apply a filter based upon the selected by end-users, handle the <a href="http://documentation.devexpress.com/#AspNet/DevExpressWebASPxPivotGridASPxPivotGrid_FieldFilterChangingtopic">FieldFilterChanging</a> event.</p>

<br/>


