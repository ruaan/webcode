<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PaymentSuccessApp.aspx.vb" Inherits="Payment_PaymentSuccessApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: #373e2e;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/interfaces/payment-successful.jpg" />
        </div>

        <input type="hidden" name="m_payment_id" value="10.00">
    </form>
</body>
</html>
