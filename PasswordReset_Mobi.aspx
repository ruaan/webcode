<%@ Page Language="VB" AutoEventWireup="false" CodeFile="PasswordReset_Mobi.aspx.vb" Inherits="PasswordReset_Mobi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: #333333;
        }

        input[type="text"] {
            background: transparent;
            border: none;
        }

        #wrapper {
            text-align: center;
        }

        #loginContainer {
            display: inline-block;
            width: 40%;
            -moz-box-shadow: 3px 3px 15px 6px #393939;
            -webkit-box-shadow: 3px 3px 15px 6px #393939;
            box-shadow: 3px 3px 15px 6px #393939;
            -moz-box-shadow: -3px 3px 15px 6px #393939;
            -webkit-box-shadow: -3px 3px 15px 6px #393939;
            box-shadow: -3px 3px 15px 6px #393939;
            min-width: 400px;
        }

        #divlogin {
            position: absolute;
            width: 450px;
            height: 655px;
            z-index: 15;
            top: 50%;
            left: 50%;
            margin: -100px 0 0 -150px;
            font-family: Calibri;
            /*background: red;*/
        }

        .pic-style3 {
            width: 400px;
            height: 234px;
        }

        .header {
            font-size: 40px;
            color: white;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="background-position: center center; width: 100%; min-height: 100vh; background-image: url('../Images/Logos/ecolion.jpg'); background-repeat: no-repeat; background-attachment: fixed;">
            <div id="divlogin">
                <div align="center">
                    <img alt="" src="Images/Logos/eco-hunter-log-large.png" class="pic-style3" /></div>
                <div>&nbsp;</div>
                <div>
                    <asp:Panel ID="pnlForgotPassword" runat="server">
                        <div align="center" class="header">New Password : </div>
                        <div align="center">
                            <asp:TextBox ID="txtPassword" placeholder="New Password" runat="server" Font-Size="48px" BorderStyle="None" BackColor="Transparent" ForeColor="White" Width="400px"></asp:TextBox></div>
                        <div>&nbsp;</div>
                        <div>&nbsp;</div>
                        <div align="center" class="header">Confirm Password : </div>
                        <div align="center">
                            <asp:TextBox ID="txtPassword1" placeholder="Confirm Password" runat="server" Font-Size="48px" BorderStyle="None" BackColor="Transparent" ForeColor="White" Width="400px"></asp:TextBox></div>
                        <div>&nbsp;</div>
                        <div>&nbsp;</div>
                        <div align="center">
                            <asp:Button ID="btnSend" runat="server" Text="Save Password" BorderStyle="None" Font-Size="48px" BackColor="#86B24F" ForeColor="White" />
                        </div>
                        <div>&nbsp</div>
                        <div align="center" class="header">
                            <asp:Label ID="lblMsg" runat="server"></asp:Label></div>
                        <div>&nbsp</div>
                    </asp:Panel>
                </div>
                <div>
                    <asp:Panel ID="pnlNotFound" Visible="false" runat="server">
                        <div>&nbsp;</div>
                        <div align="center" class="header">
                            <asp:Label ID="Label1" runat="server"></asp:Label></div>
                        <div>&nbsp;</div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
