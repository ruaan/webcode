<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGrnNotLoggedIn.master" AutoEventWireup="false" CodeFile="ForgotPassword.aspx.vb" Inherits="ForgotPassword" %>

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
                <img alt="" src="Images/Icons/login-icon.png" /></div>
            <div style="text-align: center;">
                <div>&nbsp;</div>
                <div>
                    <asp:Panel ID="pnlForgotPassword" runat="server">
                        <div class="yellowHeader">User Name:</div>
                        <div>
                            <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></div>
                        <div>&nbsp;</div>
                        <div class="yellowHeader">Email Address:</div>
                        <div>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></div>
                        <div>&nbsp;</div>
                        <div>
                            <asp:Button ID="btnSend" CssClass="button" runat="server" Text="Send Password" /></div>
                        <div>&nbsp;</div>
                        <div>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label></div>
                        <div>&nbsp;</div>
                    </asp:Panel>
                </div>
                <div>
                    <asp:Panel ID="pnlBack" Visible="false" runat="server">
                        <div>&nbsp;</div>
                        <div>
                            <asp:Label ID="Label1" runat="server"></asp:Label></div>
                        <div>&nbsp;</div>
                        <div>
                            <asp:Button ID="btnBack" CssClass="button" runat="server" Text="Back to Login" /></div>
                        <div>&nbsp;</div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <div style="background-color: #D5EBBD">&nbsp;</div>

</asp:Content>

