<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="PackageManager.aspx.vb" Inherits="SetUp_PackageManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../StyleSheets/token-input.css" type="text/css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table align="center" style="width: 100%;">
        <tr>
            <td height="40" align="left">Package Manager</td>
        </tr>
        <tr>
            <td>
                <table align="center" style="width: 90%;">
                    <tr>
                        <td>
                            <div>
                                <asp:Panel ID="pnlFarmSelect" runat="server" Visible="True">
                                    &nbsp;Farms:
                                    <asp:DropDownList ID="cmbFarms" runat="server" AutoPostBack="True" DataTextField="FarmName" DataValueField="id"></asp:DropDownList>
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="btnAdd" runat="server" Text="Add Package" CssClass="button" Width="100px" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No packages available to select" Font-Names="Verdana" Font-Size="Small" Width="50%">
                                <Columns>
                                    <asp:ButtonField ButtonType="Button" Text="Edit" CommandName="View" ControlStyle-CssClass="button" ControlStyle-Width="50px" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                    <asp:BoundField DataField="packageId" HeaderText="Package Id" />
                                    <asp:BoundField DataField="Package" HeaderText="Package" />
                                    <asp:BoundField DataField="farmId" HeaderText="Farm Id" />
                                    <asp:BoundField DataField="FarmName" HeaderText="Farm" />
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
