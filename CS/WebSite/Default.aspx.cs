using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using System.Data;
using DevExpress.Web.ASPxPivotGrid;
using DevExpress.XtraPivotGrid;

public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        ASPxPivotGrid1.DataSource = CreateCustomDataTable();
        if (!IsPostBack && !IsCallback) {
            PivotGridField fieldQuantity = new PivotGridField("Quantity", PivotArea.DataArea);
            PivotGridField fieldProductName = new PivotGridField("ProductName", PivotArea.RowArea);
            PivotGridField fieldDate = new PivotGridField("Date", PivotArea.ColumnArea);
            fieldDate.GroupInterval = PivotGroupInterval.Date;
            ASPxPivotGrid1.Fields.AddField(fieldProductName);
            ASPxPivotGrid1.Fields.AddField(fieldDate);
            ASPxPivotGrid1.Fields.AddField(fieldQuantity);
        }
        new CustomFilterRanges(ASPxPivotGrid1, ASPxPivotGrid1.Fields["ProductName"]).AddEvents();
        new CustomFilterRanges(ASPxPivotGrid1, ASPxPivotGrid1.Fields["Date"]).AddEvents();
    }
    DataTable CreateCustomDataTable() {
        DataTable customDataTable = new DataTable("Shopping");
        customDataTable.Columns.Add("Quantity", typeof(float));
        customDataTable.Columns.Add("Price", typeof(float));
        customDataTable.Columns.Add("ProductName", typeof(string));
        customDataTable.Columns.Add("Date", typeof(DateTime));
        customDataTable.Rows.Add(5.0, 50.0, null, DateTime.Today.AddYears(-1).AddMonths(-1));
        customDataTable.Rows.Add(10.0, 31.0, null, DateTime.Today.AddYears(-1).AddMonths(-1));
        customDataTable.Rows.Add(3.0, 30.0, null, DateTime.Today.AddYears(-1).AddMonths(-1));
        customDataTable.Rows.Add(3.5, 230.0, "Bananas", DateTime.Today.AddYears(-1).AddMonths(-1));
        customDataTable.Rows.Add(5.0, 50.0, "Apples", DateTime.Today.AddDays(-8));
        customDataTable.Rows.Add(10.0, 31.0, "Peaches", DateTime.Today.AddDays(-8));
        customDataTable.Rows.Add(3.0, 30.0, "Lemons", DateTime.Today.AddDays(-8));
        customDataTable.Rows.Add(3.5, 230.0, "Bananas", DateTime.Today.AddDays(-8));
        customDataTable.Rows.Add(5.0, 52.0, "Apples", DateTime.Today.AddDays(-7));
        customDataTable.Rows.Add(1.0, 33.0, "Peaches", DateTime.Today.AddDays(-7));
        customDataTable.Rows.Add(2.0, 32.0, "Lemons", DateTime.Today.AddDays(-7));
        customDataTable.Rows.Add(2.3, 250.20, "Bananas", DateTime.Today.AddDays(-7));
        customDataTable.Rows.Add(5.0, 50.0, "Apples", DateTime.Today.AddDays(-6));
        customDataTable.Rows.Add(10.0, 31.0, "Peaches", DateTime.Today.AddDays(-6));
        customDataTable.Rows.Add(3.0, 30.0, "Lemons", DateTime.Today.AddDays(-6));
        customDataTable.Rows.Add(3.5, 230.0, "Bananas", DateTime.Today.AddDays(-6));
        customDataTable.Rows.Add(5.0, 52.0, "Apples", DateTime.Today.AddDays(-2));
        customDataTable.Rows.Add(1.0, 33.0, "Peaches", DateTime.Today.AddDays(-2));
        customDataTable.Rows.Add(2.0, 32.0, "Lemons", DateTime.Today.AddDays(-2));
        customDataTable.Rows.Add(2.3, 250.20, "Bananas", DateTime.Today.AddDays(-2));
        customDataTable.Rows.Add(1.0, 55.0, "Apples", DateTime.Today.AddDays(-1));
        customDataTable.Rows.Add(2.0, 38.0, "Peaches", DateTime.Today.AddDays(-1));
        customDataTable.Rows.Add(1.0, 36.0, "Lemons", DateTime.Today.AddDays(-1));
        customDataTable.Rows.Add(2.0, 55.0, "Apples", DateTime.Today);
        customDataTable.Rows.Add(2.0, 39.0, "Peaches", DateTime.Today);
        customDataTable.Rows.Add(1.0, 37.0, "Lemons", DateTime.Today);
        customDataTable.Rows.Add(3.5, 270.30, "Bananas", DateTime.Today);
        customDataTable.Rows.Add(2.0, 55.0, "Apples", DateTime.Today.AddDays(1));
        customDataTable.Rows.Add(3.0, 40.5, "Peaches", DateTime.Today.AddDays(1));
        customDataTable.Rows.Add(4.2, 290.8, "Bananas", DateTime.Today.AddDays(1));
        customDataTable.Rows.Add(10.0, 56.0, "Apples", DateTime.Today.AddMonths(1));
        customDataTable.Rows.Add(1.0, 41.0, "Peaches", DateTime.Today.AddMonths(1));
        customDataTable.Rows.Add(2.0, 39.0, "Lemons", DateTime.Today.AddMonths(1));
        customDataTable.Rows.Add(1.5, 290.30, "Bananas", DateTime.Today.AddMonths(1));
        customDataTable.Rows.Add(10.0, 56.0, "Apples", DateTime.Today.AddMonths(1).AddDays(1));
        customDataTable.Rows.Add(1.0, 41.0, "Peaches", DateTime.Today.AddMonths(1).AddDays(1));
        customDataTable.Rows.Add(2.0, 39.0, "Lemons", DateTime.Today.AddMonths(1).AddDays(1));
        customDataTable.Rows.Add(1.5, 290.30, "Bananas", DateTime.Today.AddMonths(1).AddDays(1));
        customDataTable.Rows.Add(5.0, 57.2, "Apples", DateTime.Today.AddYears(1));
        customDataTable.Rows.Add(3.0, 42.0, "Peaches", DateTime.Today.AddYears(1));
        customDataTable.Rows.Add(1.0, 43.0, "Lemons", DateTime.Today.AddYears(1));
        customDataTable.Rows.Add(1.2, 295.30, "Bananas", DateTime.Today.AddYears(1));
        return customDataTable;
    }
}
