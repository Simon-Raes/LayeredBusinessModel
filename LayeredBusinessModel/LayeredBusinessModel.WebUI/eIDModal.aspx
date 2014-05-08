<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="eIDModal.aspx.cs" Inherits="LayeredBusinessModel.WebUI.eIDModal" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>
<%@ Register Assembly="Arcabase.EID.SDK" Namespace="Arcabase.EID.SDK.Web" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .modalBackground {
            background-color: gray;
            z-index: 99;
            position: absolute;
            filter: alpha(opacity=60);
            -moz-opacity: 0.6;
            opacity: 0.6;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server">
            </asp:ScriptManager>
            <cc2:ModalPopupExtender ID="ModalPopupExtender1" runat="server" BackgroundCssClass="modalBackground" TargetControlID="btnDummy" PopupControlID="pnlReader" CancelControlID="btnClose"></cc2:ModalPopupExtender>

            <asp:Panel ID="pnlReader" runat="server" BorderStyle="Solid" BorderWidth="1px">
                <cc1:EID_Read ID="EID_Read1" runat="server" />
                <br />
                <asp:Button ID="btnClose" runat="server" Text="Close" />
            </asp:Panel>


                        <asp:Literal ID="ltName" runat="server"></asp:Literal>
            <asp:Image ID="imgPhoto" runat="server" />
            <asp:Button ID="btnReadEid" runat="server" Text="Read card" OnClick="btnReadEid_Click" />


            <asp:Button ID="btnDummy" Style="display:none;" runat="server" />

        </div>
    </form>
</body>
</html>
