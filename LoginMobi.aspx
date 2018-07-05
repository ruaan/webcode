<%@ Page Language="VB" AutoEventWireup="false" CodeFile="LoginMobi.aspx.vb" Inherits="LoginMobi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
    <style type="text/css">

        html { 
  background: url(../Images/Logos/ecolion.jpg) no-repeat center center fixed; 
  -webkit-background-size: cover;
  -moz-background-size: cover;
  -o-background-size: cover;
  background-size: cover;
}

        .auto-style1 {
            width: 194px;
            height: 72px;
        }
    </style>
    
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id ="divlogin">
                <div align="center"><img alt="" src="Images/Logos/eco-hunter-log-large.png" class="auto-style1" /></div>
                <div>&nbsp;</div>   
                <div align="center"><asp:TextBox ID="txtUserName" placeholder="E-mail address" runat="server"  BorderStyle="None" BackColor="#99B37A" ForeColor="White" Width="250px"  Font-Size="20px"></asp:TextBox></div>
                <div>&nbsp;</div>
                <div>&nbsp;</div>
                <div align="center"><asp:TextBox ID="txtPassword" placeholder="Password" runat="server"  BorderStyle="None" TextMode="Password" BackColor="#99B37A" ForeColor="White" Width="250px" Font-Size="20px"></asp:TextBox></div>
                <div>&nbsp;</div>
                <div>&nbsp;</div>
                <div align="center">
                    <asp:Button ID="Button1" runat="server" Text="SIGN IN" BorderStyle="None"  BackColor="#99B37A" ForeColor="White" Font-Size="20px" />
                </div>
                <div align="center">
                    <asp:Label ID="lblPasswordVal" runat="server"  ForeColor="White" Font-Size="20px"></asp:Label>
                </div>
                <div>&nbsp</div>
                <div align="center">
                    <div style="font-size: 20px"><a class="yellowHeader" href="Member_Registration_Mobi.aspx" style="text-decoration: none; color: white; ">Register</a></div>
                    <div style="font-size: 20px;"><a class="yellowHeader" href="ForgotPassword_Mobi.aspx" style="text-decoration: none; color: white; ">Forgot Password</a></div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
