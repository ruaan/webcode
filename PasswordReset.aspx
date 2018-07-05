<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGrnNotLoggedIn.master" AutoEventWireup="false" CodeFile="PasswordReset.aspx.vb" Inherits="PasswordReset" %>

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
        <div id="loginContainer">
            <div>&nbsp;</div>
            <div>
                <img alt="" src="Images/Icons/login-icon.png" /></div>
            <div style="text-align: center;">
                <div>&nbsp;</div>
                <div>
                    <asp:Panel ID="pnlForgotPassword" runat="server">
                        <div class="yellowHeader">New Password:</div>
                        <div>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></div>
                        <div>&nbsp;</div>
                        <div class="yellowHeader">Confirm Password:</div>
                        <div>
                            <asp:TextBox ID="txtPassword1" runat="server" CssClass="textbox" Width="300px"></asp:TextBox></div>
                        <div>&nbsp;</div>
                        <div>
                            <asp:Button ID="btnSend" CssClass="button" runat="server" Text="Save Password" /></div>
                        <div>&nbsp;</div>
                        <div>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label></div>
                        <div>&nbsp;</div>
                    </asp:Panel>
                </div>
                <div>
                    <asp:Panel ID="pnlNotFound" Visible="false" runat="server">
                        <div>
                            <asp:Label ID="Label1" runat="server"></asp:Label></div>
                        <div>&nbsp;</div>
                    </asp:Panel>
                </div>
            </div>
        </div>
    </div>
    <div style="background-color: #D5EBBD">&nbsp;</div>

</asp:Content>

