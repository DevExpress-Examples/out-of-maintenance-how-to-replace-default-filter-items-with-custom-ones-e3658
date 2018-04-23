<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true"
    CodeFile="Default.aspx.cs" Inherits="_Default" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v11.2, Version=11.2.0.0, Culture=neutral, PublicKeyToken=79868b8147b5eae4" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Demo</title>
</head>
<body>
    <h2>
        Custom filter range sample    </h2>
    <form id="form1" runat="server">
        <div>
            <dx:ASPxPivotGrid ID="ASPxPivotGrid1" runat="server">
            </dx:ASPxPivotGrid>
        </div>
        <input runat="server" type="hidden" name="filterRanges" id="filterRanges" value="" />
    </form>    
</body>

</html>