<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Reserve_DateConfirm.aspx.vb" Inherits="Reserve_DateConfirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="lblHuntId" runat="server" Text=""></asp:Label>
    <asp:Panel ID="pnlAccept" runat="server" Width="479px" Visible="False">
        <div>&nbsp;</div>
        <div>Thank you!</div>
        <div>The dates has been confirmed and the hunters has been notified.</div>
    </asp:Panel>

    <asp:Panel ID="pnlDecline" runat="server" Width="479px" Visible="False">
        <div>&nbsp;</div>
        <div>Thank you.</div>
        <div>The hunters will be informed that the dates are not available.</div>
        <div>&nbsp;</div>
        <div>Would you like to add a message? (optional)</div>
        <div>
            <asp:TextBox ID="txtMessage" runat="server" Height="52px" TextMode="MultiLine" Width="382px"></asp:TextBox>
        </div>
        <div>&nbsp;</div>
        <div style="text-align: center">
            <asp:Button ID="btnDeclineSubmit" runat="server" Text="Submit" CssClass="button" />
        </div>
    </asp:Panel>
    <asp:Panel ID="pnlAlreadyCompleted" runat="server" Width="479px" Visible="False">
        <div>&nbsp;</div>
        <div>This request has already been
            <asp:Label ID="lblResult" runat="server" Text=""></asp:Label></div>
        <div>&nbsp;</div>
    </asp:Panel>
    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
</asp:Content>

