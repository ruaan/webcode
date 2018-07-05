<%@ Page Language="VB" AutoEventWireup="false" CodeFile="dynamicAttend.aspx.vb" Inherits="Associations_dynamicAttend" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="font-size: x-large; font-family: Calibri">
            <div>Attendance</div>
            <div>
                <asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></div>
            <asp:Panel ID="pnlMeeting" runat="server" Visible="False">
                <div>&nbsp;</div>
                <div>Welcome <asp:Label ID="lblName" runat="server" Text="Label"></asp:Label></div>
                <div>Your attendance has been recorded.</div>
                <div>&nbsp;</div>
                <div>
                    <asp:Label ID="lblEvent" runat="server" Text="Label"></asp:Label></div>
                 <div>&nbsp;</div>
            </asp:Panel>
            <asp:Panel ID="pnlShoot" runat="server" Visible="False">
                 <div>&nbsp;</div>
                <div>Welcome <asp:Label ID="lblName1" runat="server" Text="Label"></asp:Label></div>
                <div>Your attendance has been recorded.</div>
                <div>&nbsp;</div>
                <div>
                    <asp:Label ID="lblEvent1" runat="server" Text="Label"></asp:Label></div>
                 <div>&nbsp;</div>
                <div>Scorecard:</div>
            </asp:Panel>
        </div>
    </form>
</body>
</html>
