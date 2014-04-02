<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Brewers_Image_Link.aspx.cs" Inherits="LayeredBusinessModel.WebUI.Brewers_Image_Link" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvBrewers" runat="server">
            <Columns>
                <asp:TemplateField HeaderText="ImageLink"></asp:TemplateField>
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
