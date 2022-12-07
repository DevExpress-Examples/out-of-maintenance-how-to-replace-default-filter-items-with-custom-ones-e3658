<%@ Page Title="Home Page" Language="vb" AutoEventWireup="true"
	CodeFile="Default.aspx.vb" Inherits="_Default" %>
<%@ Register assembly="DevExpress.Web.ASPxPivotGrid.v15.1, Version=15.1.15.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a" namespace="DevExpress.Web.ASPxPivotGrid" tagprefix="dx" %>

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