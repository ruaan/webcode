<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="MemberManager.aspx.vb" Inherits="SetUp_MemberManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../StyleSheets/token-input.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" style="width: 100%;">
        <tr>
            <td height="40" align="left">Member Manager</td>
        </tr>
        <tr>
            <td>
                <table align="center" style="width: 90%;">
                    <tr>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" Text="Add Member" CssClass="button" Width="100px" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox><asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="~/Images/Icons/search.png" />
                            </div>
                            <div>&nbsp;</div>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No members available to select" Font-Names="Verdana" Font-Size="Small" Width="30%">
                                <Columns>
                                    <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="View" ControlStyle-CssClass="button" ControlStyle-Width="50px" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                    <asp:BoundField DataField="MemberId" HeaderText="Member Id" />
                                    <asp:BoundField DataField="MemberName" HeaderText="Member Name" />
                                </Columns>
                            </asp:GridView>
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
