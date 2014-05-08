<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Update.aspx.cs" Inherits="LayeredBusinessModel.WebUI.Update" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:GridView ID="gvUpdate" runat="server" AutoGenerateColumns="False" OnRowCancelingEdit="gvUpdate_RowCancelingEdit" OnRowEditing="gvUpdate_RowEditing" OnRowUpdating="gvUpdate_RowUpdating">
            <Columns>
                <asp:CommandField ButtonType="Image" CancelImageUrl="~/images/cancel.jpg" EditImageUrl="~/images/edit.png" ShowEditButton="True" UpdateImageUrl="~/images/save.png" />
                <asp:BoundField DataField="biernr" HeaderText="biernr" ReadOnly="True" />
                <asp:BoundField DataField="naam" HeaderText="naam" />
                <asp:BoundField DataField="brouwernr" HeaderText="brouwernr" ReadOnly="True" />
                <asp:BoundField DataField="soortnr" HeaderText="soortnr" ReadOnly="True" />
                <asp:BoundField DataField="alcohol" HeaderText="alcohol" ReadOnly="True" />
            </Columns>
        </asp:GridView>
    
    </div>
    </form>
</body>
</html>
