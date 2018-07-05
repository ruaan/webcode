<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="OutfitterManager.aspx.vb" Inherits="SetUp_OutfitterManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" style="width: 90%;">
        <tr>
            <td height="40" align="left">Outfitter Manager</td>
        </tr>
        <tr>
            <td>
                <asp:Button ID="Button1" runat="server" Text="Add Outfitter" CssClass="button" Width="100px" />
            </td>
        </tr>
        <tr>
            <td>
                <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No outfitters available to select" Font-Names="Verdana" Font-Size="Small" Width="30%">
                    <Columns>
                        <asp:ButtonField ButtonType="Button" Text="View" CommandName="View" ControlStyle-CssClass="button" ControlStyle-Width="50px" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                        <asp:BoundField DataField="id" HeaderText="Id" />
                        <asp:BoundField DataField="FarmName" HeaderText="Farm Name" />
                        <asp:BoundField DataField="Status" HeaderText="Active" />
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
</asp:Content>

