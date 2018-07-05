<%@ Page Language="VB" AutoEventWireup="false" CodeFile="EventCapture_App.aspx.vb" Inherits="SetUp_EventCapture_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table width="100%" align="center" celpadding="0" cellspacing="0">
                <tr>
                    <td height="30">&nbsp;</td>
                </tr>
                <tr>
                    <td height="27">&nbsp;<asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <table width="90%" align="center" celpadding="0" cellspacing="0">
                            <tr>
                                <td valign="top" width="50%">
                                    <table width="100%" align="center" celpadding="0" cellspacing="0" style="border-right-style: solid; border-bottom-style: solid; border-width: thin; border-color: #000000">
                                        <tr>
                                            <td colspan="2" align="center" height="35">
                                                <asp:Label ID="lblEventName" Font-Underline="true" Font-Bold="true" Font-Size="Large" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="lblEventId" runat="server" Text="" ForeColor="White"></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td width="50%" align="center">
                                                <asp:Image ID="Image1" runat="server" Width="150px" Height="150px" /></td>
                                            <td width="50%" align="left" valign="top">
                                                <table width="100%" align="left" celpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td height="27">
                                                            <asp:Label ID="lblShortDescription" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="35" align="center">
                                                <asp:Label ID="lblAssName" Font-Size="Large" runat="server" Text=""></asp:Label></td>
                                            <td align="left">
                                                <asp:Label ID="lblEventDate" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25">&nbsp;</td>
                                            <td align="left">
                                                <asp:Label ID="lblVenue" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25">&nbsp;</td>
                                            <td align="left">
                                                <asp:Label ID="lblAddress1" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25">&nbsp;</td>
                                            <td align="left">
                                                <asp:Label ID="lblAddress2" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td height="25">&nbsp;</td>
                                            <td align="left">
                                                <asp:Label ID="lblAddress3" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                    </table>
                                </td>
                                <td valign="top" width="50%">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" align="center" cellpadding="10" cellspacing="0">
                            <tr>
                                <td width="30%" height="27">Attending Member:</td>
                                <td width="70%">
                                    <asp:DropDownList ID="ddlMembers" runat="server" Width="250px" DataTextField="Name" DataValueField="MemberId"></asp:DropDownList>&nbsp;<asp:Button ID="btnGo" runat="server" Text="Add" CssClass="button" /></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="pnlAddMember" runat="server" Visible="false">
                                        <table width="100%" align="center" cellpadding="0" cellspacing="0">
                                            <tr>
                                                <td width="30%" height="27">Member Name:</td>
                                                <td width="70%">
                                                    <asp:TextBox ID="txtName" CssClass="textbox" Width="250px" runat="server"></asp:TextBox>&nbsp;
                                                                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" Width="80px" />
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td height="35" colspan="2" align="right">
                                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>&nbsp;
                                                <asp:Button ID="btnSave1" runat="server" Text="Save Attendees" CssClass="button" Width="300px" />&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" align="center">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No members available to select" Width="90%" Font-Size="Small">
                                        <Columns>
                                            <asp:TemplateField HeaderText="Present">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="CheckBox1" runat="server" Enabled="true" />
                                                </ItemTemplate>
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:TemplateField>
                                            <asp:BoundField DataField="id" HeaderText="Id" />
                                            <asp:BoundField DataField="Name" HeaderText="Member Name" />
                                            <asp:ButtonField ButtonType="Image" CommandName="myDelete" ImageUrl="../Images/Icons/deletes.png" HeaderText="Remove" ItemStyle-HorizontalAlign="Center"></asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td height="35" colspan="2" align="right">
                                    <asp:Label ID="Label2" runat="server" Text=""></asp:Label>&nbsp;
                                                <asp:Button ID="btnSave2" runat="server" Text="Save Attendees" CssClass="button" Width="300px" />&nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
