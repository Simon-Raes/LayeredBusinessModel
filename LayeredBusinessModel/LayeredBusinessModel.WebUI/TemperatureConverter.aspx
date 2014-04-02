<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemperatureConverter.aspx.cs" Inherits="LayeredBusinessModel.WebUI.Temperature" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:TextBox ID="txtCelcius" runat="server"></asp:TextBox>
        <asp:Button ID="btnConvert" runat="server" OnClick="btnConvert_Click" Text="Convert" />
        <asp:Label ID="lblFahrenheit" runat="server"></asp:Label>
    
    </div>
    </form>
</body>
</html>
