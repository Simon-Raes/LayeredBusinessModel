<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="DeleteRecord.aspx.cs" Inherits="LayeredBusinessModel.WebUI.DeleteRecord" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvBeer" runat="server" AutoGenerateColumns="False" OnRowDataBound="gvBeer_RowDataBound" OnRowDeleting="gvBeer_RowDeleting">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                        <asp:Button ID="btnDeleter" runat="server" Text="Delete" CommandName="Delete"/>
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="biernr" HeaderText="biernr" />
                <asp:BoundField DataField="naam" HeaderText="naam" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
