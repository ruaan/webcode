<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="UserManager.aspx.vb" Inherits="SetUp_UserManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../StyleSheets/token-input.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" style="width: 100%;">
        <tr>
            <td height="40" align="left">User Management</td>
        </tr>
        <tr>
            <td>
                <table align="center" style="width: 90%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" Text="Add User" CssClass="button" Width="100px" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td width="30%" valign="top">
                            <table width="100%" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td>
                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No members available to select" Font-Names="Verdana" Font-Size="x-small" Width="100%">
                                            <Columns>
                                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/edit.png" Text="Edit or View" CommandName="View" ItemStyle-HorizontalAlign="Center" />
                                                <asp:BoundField DataField="id" HeaderText="User Id" />
                                                <asp:BoundField DataField="UserName" HeaderText="UserName" />
                                                <asp:BoundField DataField="MemberId" HeaderText="Member Id" />
                                            </Columns>
                                            <HeaderStyle BackColor="#3e432f" ForeColor="White" />
                                        </asp:GridView>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td width="70%" valign="top">
                            <asp:Panel ID="pnlDetail" runat="server" Visible="false">
                                <table width="95%" align="center" cellpadding="0" cellspacing="0">
                                    <tr>
                                        <td width="50%" valign="top">
                                            <table width="100%" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td>
                                                        <table width="98%" align="center" cellpadding="0" cellspacing="0" style="border-style: none solid none none; border-width: thin; border-color: #000000">
                                                            <tr>
                                                                <td height="27" width="25%">
                                                                    <asp:Label ID="lblId" runat="server" Text=""></asp:Label></td>
                                                                <td width="75%">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td height="27">UserName:</td>
                                                                <td>
                                                                    <asp:TextBox ID="txtUserName" CssClass="textbox" Width="250px" runat="server"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="27">UserType:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlUserType" CssClass="textbox" runat="server" Width="250px" DataTextField="Type_Name" DataValueField="UserType_Id"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="27">Member:</td>
                                                                <td>
                                                                    <asp:DropDownList ID="ddlMember" CssClass="textbox" runat="server" Width="250px" DataTextField="Name" DataValueField="MemberId"></asp:DropDownList></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="27">Active:</td>
                                                                <td>
                                                                    <asp:CheckBox ID="chkActive" runat="server" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="27">&nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Width="100px" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="27">&nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label></td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                </tr>
                                            </table>
                                        </td>
                                        <td width="50%" valign="top">
                                            <asp:Panel ID="pnlPassword" Visible="false" runat="server">
                                                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td>
                                                            <table width="98%" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td colspan="2">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" width="25%">Password:</td>
                                                                    <td width="75%">
                                                                        <asp:TextBox ID="txtPassword" CssClass="textbox" Width="250px" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="27">&nbsp;</td>
                                                                    <td>
                                                                        <asp:Button ID="btnReset" runat="server" Text="Reset" CssClass="button" Width="100px" /></td>
                                                                </tr>
                                                                <tr>
                                                                    <td colspan="2">&nbsp;</td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>
