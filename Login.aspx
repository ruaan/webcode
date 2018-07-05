<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGrnNotLoggedIn.master" AutoEventWireup="false" CodeFile="Login.aspx.vb" Inherits="Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="wrapper">
        <div>&nbsp;</div>
        <div>&nbsp;</div>
        <div id="loginContainer" style="background-color: #F0F0F0">
            <div>&nbsp;</div>
            <div>
                <img alt="" src="Images/Icons/login-icon.png" />
            </div>
            <div style="text-align: center;">
                <div>&nbsp;</div>
                <div class="yellowHeader">User Email</div>
                <div>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox"></asp:TextBox><asp:Label ID="lblUserVal" runat="server"></asp:Label>
                </div>
                <div>&nbsp;</div>
                <div class="yellowHeader">Password</div>
                <div>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" TextMode="Password"></asp:TextBox>
                    <asp:Label ID="lblPasswordVal" runat="server"></asp:Label>
                </div>
                <div>&nbsp;</div>
                <div>
                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/login-button.png" />
                </div>
                <div>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
                <div>&nbsp;</div>
                <div class="yellowHeader"><a class="yellowHeader" href="Member_Registration.aspx">Register</a></div>
                <div class="yellowHeader"><a class="yellowHeader" href="ForgotPassword.aspx">Forgot Password</a></div>
                <%-- <div>&nbsp;</div>
            <div class="yellowHeader">
                <a class="yellowHeader" href="#Forgot Password">Forgot your password?</a></div>--%>

                <div>&nbsp;</div>
            </div>

        </div>

    </div>
    <div style="background-color: #D5EBBD">&nbsp;</div>

</asp:Content>

