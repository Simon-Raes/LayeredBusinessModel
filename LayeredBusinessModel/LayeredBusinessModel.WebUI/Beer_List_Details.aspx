<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Beer_List_Details.aspx.cs" Inherits="LayeredBusinessModel.WebUI.Beer_List_Details" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <table>
            
            <tr>
                <td>
                    <asp:GridView ID="gvBeer" runat="server" AutoGenerateColumns="False" OnRowCommand="gvBeer_RowCommand" BackColor="#FFFF66" AllowPaging="True" PageSize="15">
                        <AlternatingRowStyle BackColor="#FFFF99" />
                        <Columns>
                            <asp:BoundField DataField="biernr" HeaderText="Biernummer" />
                            <asp:BoundField DataField="naam" HeaderText="Naam" />
                            <asp:BoundField DataField="alcohol" HeaderText="Alcohol" />
                            <asp:CommandField ShowSelectButton="True" />
                        </Columns>
                        <HeaderStyle BackColor="#99FF33" />
                    </asp:GridView>
                </td>
                <td>
                    <asp:Label ID="lblName" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblAlcohol" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblBrewer" runat="server"></asp:Label>
                    <br />
                    <asp:Label ID="lblSoort" runat="server"></asp:Label>
                </td>
            </tr>
        </table>
        <div>
        </div>
    </form>
</body>
</html>
