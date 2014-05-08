<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eID.aspx.cs" Inherits="LayeredBusinessModel.WebUI.eID" %>

<%@ Register assembly="Arcabase.EID.SDK" namespace="Arcabase.EID.SDK.Web" tagprefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <cc1:EID_Read ID="EID_Read1" runat="server" />
        <asp:Literal ID="ltName" runat="server"></asp:Literal>
        <asp:Button ID="btnReadEid" runat="server" Text="Read card" OnClick="btnReadEid_Click" />
    </div>
    </form>
</body>
</html>
