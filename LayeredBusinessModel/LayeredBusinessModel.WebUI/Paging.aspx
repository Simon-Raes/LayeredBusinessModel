<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Paging.aspx.cs" Inherits="LayeredBusinessModel.WebUI.Paging" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvBrewers" runat="server" AllowPaging="True" AllowSorting="True" OnPageIndexChanging="GridView1_PageIndexChanging" OnSorting="gvBrewers_Sorting">
        </asp:GridView>
        Search:
        <asp:TextBox ID="txtSearch" runat="server"></asp:TextBox>
        <asp:Button ID="btnSearch" runat="server" OnClick="btnSearch_Click" Text="Search" />
    
    </div>
    </form>
</body>
</html>
