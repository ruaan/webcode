<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PaymentConfirmationApp.aspx.vb" Inherits="Payment_PaymentConfirmationApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: #373e2e;
        }

        .auto-style1 {
            width: 316px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>&nbsp;</div>
        <div class="h1" style="font-family: Calibri; font-size: x-large; color: #FFFFFF">Payment Confirmation</div>
        <div>&nbsp;</div>
        <div>
            <asp:Label ID="lblHuntId" runat="server" ForeColor="#373E2E"></asp:Label>
        </div>

        <div>

            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/depbutton.jpg" />
        </div>
    </form>
</body>
</html>
