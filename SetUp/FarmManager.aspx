<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="FarmManager.aspx.vb" Inherits="SetUp_FarmManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            height: 36px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    Farm Manager
    <table align="center" style="width: 90%;">
        <tr>
            <td class="auto-style2">
                <asp:Button ID="Button1" runat="server" Text="Add Farm" CssClass="button" />
            </td>
            <td class="auto-style2"></td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </td>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <div>
                    <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox><asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="~/Images/Icons/search.png" />
                </div>
                <div>&nbsp;</div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No Associations available to select">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" Text="View" ControlStyle-CssClass="button" CommandName="View">
                            <ControlStyle CssClass="button"></ControlStyle>
                        </asp:ButtonField>
                        <asp:BoundField DataField="id" HeaderText="Id" />
                        <asp:BoundField DataField="FarmName" HeaderText="Farm Name" />
                        <asp:BoundField DataField="Status" HeaderText="Active" />
                        <asp:ButtonField ButtonType="Button" CommandName="Animals" Text="Animals" ControlStyle-CssClass="button" />
                        <asp:ButtonField ButtonType="Button" Text="Users" CommandName="Users" ControlStyle-CssClass="button" />
                    </Columns>
                </asp:GridView>
            </td>
            <td valign="top">
                <asp:Panel ID="pnlUsers" runat="server" CssClass="panel" Visible="False">
                    <table style="width: 100%;">
                        <tr>
                            <td>Users Linked to:
                                <asp:Label ID="lblFarmName" runat="server"></asp:Label>
                                <asp:Label ID="lblFarmId" runat="server" ForeColor="White"></asp:Label>
                            </td>
                            <td align="right">
                                <asp:Button ID="Button2" runat="server" CssClass="lineButton" Text="Close" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" EmptyDataText="No Users linked to this Farm">
                                    <Columns>
                                        <asp:BoundField />
                                        <asp:BoundField DataField="id" HeaderText="Link Id" />
                                        <asp:BoundField DataField="NickName" HeaderText="Actual Name" />
                                        <asp:BoundField DataField="UserId" HeaderText="User Id" />
                                        <asp:BoundField DataField="Type" HeaderText="Type" />
                                        <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                        <asp:BoundField DataField="UserActive" HeaderText="User Active" />
                                        <asp:BoundField DataField="LastLoggedIn" HeaderText="Last Logged In" />
                                    </Columns>
                                </asp:GridView>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Button ID="Button3" runat="server" CssClass="button" Text="Create user for this farm" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <asp:Panel ID="pnlCreateUser" runat="server" CssClass="panel" Visible="False">
                                    <table style="width: 100%;">
                                        <tr>
                                            <td>Actual Name</td>
                                            <td>
                                                <asp:TextBox ID="txtActualUser" runat="server" CssClass="textbox" Width="210px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>User Name:</td>
                                            <td>
                                                <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" Width="210px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>Password:</td>
                                            <td>
                                                <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Width="210px"></asp:TextBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>&nbsp;</td>
                                            <td>
                                                <asp:Button ID="Button4" runat="server" Text="Save" CssClass="button" />
                                                &nbsp;
                                                <asp:Button ID="Button5" runat="server" Text="Cancel" CssClass="button" />
                                                <asp:Label ID="lblUserMsg" runat="server"></asp:Label>
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
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>&nbsp;</td>
            <td>&nbsp;</td>
        </tr>
    </table>
</asp:Content>

