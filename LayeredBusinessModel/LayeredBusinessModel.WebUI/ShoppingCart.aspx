<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ShoppingCart.aspx.cs" Inherits="LayeredBusinessModel.WebUI.ShoppingCart" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <asp:LinkButton ID="btnCart" runat="server" OnClick="btnCart_Click">Cart</asp:LinkButton>
            <asp:GridView ID="gvBeer" runat="server" OnRowCommand="gvBeer_RowCommand" OnSelectedIndexChanging="gvBeer_SelectedIndexChanging">
                <Columns>
                    <asp:CommandField HeaderText="Buy" ShowSelectButton="True" />
                </Columns>
            </asp:GridView>

        </div>
        <cc1:ModalPopupExtender ID="ModalPopupExtender1" runat="server" TargetControlID="btnDummy" PopupControlID="pnlCart" CancelControlID="btnClose"></cc1:ModalPopupExtender>
        <asp:Button ID="btnDummy" runat="server" Text="Dummy" Style="display:none;"/>

        <asp:Panel ID="pnlCart" runat="server">
            <asp:Label ID="lblCart" runat="server" Text="Label"></asp:Label>
            <asp:Button ID="btnClose" runat="server" Text="Close" />
            <asp:GridView ID="gvCart" runat="server" AutoGenerateColumns="False" OnRowDeleting="gvCart_RowDeleting" OnRowEditing="gvCart_RowEditing" OnRowUpdating="gvCart_RowUpdating">
                <Columns>
                    <asp:BoundField DataField="biernr" HeaderText="Nummer" />
                    <asp:BoundField DataField="naam" HeaderText="Product" />
                    <asp:TemplateField HeaderText="Aantal">
                        <ItemTemplate>
                            <%# Eval("Aantal") %>
                        </ItemTemplate>
                        <EditItemTemplate>
                            <asp:DropDownList ID="ddlAmount" runat="server" DataSource='<%# AantalArray %>' SelectedValue='<%# Eval("Aantal") %>'>

                            </asp:DropDownList>
                        </EditItemTemplate>

                    </asp:TemplateField>
                    <asp:CommandField ShowEditButton="True" />
                    <asp:CommandField ShowDeleteButton="True" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnBestellen" runat="server" Text="Button" />
        </asp:Panel>


    </form>
</body>
</html>
