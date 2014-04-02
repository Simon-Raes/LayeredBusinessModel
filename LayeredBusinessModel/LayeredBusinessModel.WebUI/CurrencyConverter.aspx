<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="CurrencyConverter.aspx.cs" Inherits="LayeredBusinessModel.WebUI.CurrencyConverter" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        Euro:&nbsp;&nbsp;
        <asp:TextBox ID="txtEuro" runat="server"></asp:TextBox>
        <br />
        Dollar:
        <asp:TextBox ID="txtDollar" runat="server"></asp:TextBox>
    
    </div>
        <asp:Button ID="btnConvert" runat="server" OnClick="btnConvert_Click" Text="Convert" />
        <asp:Label ID="lblError" runat="server"></asp:Label>
    </form>
</body>
</html>
