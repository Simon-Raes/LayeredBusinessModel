<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Voetballers.aspx.cs" Inherits="LayeredBusinessModel.WebUI.Voetballers" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Landen"></asp:Label>
        <asp:DropDownList ID="ddlCountries" runat="server" AutoPostBack="True" OnSelectedIndexChanged="ddlCountries_SelectedIndexChanged">
        </asp:DropDownList>
    
    </div>
        <asp:Label ID="lblCurrency" runat="server" Text="Currency: "></asp:Label>
        <asp:TextBox ID="txtCurrency" runat="server"></asp:TextBox>
    </form>
</body>
</html>
