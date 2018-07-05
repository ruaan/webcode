<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Member_Report_App.aspx.vb" Inherits="Associations_Member_Report_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .auto-style1 {
            width: 17%;
        }
        .auto-style2 {
            width: 22%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
       <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>--%>
        <ContentTemplate>
            <table width="100%" align="center" celpadding="0" cellspacing="0">
                <tr>
                    <td height="30">&nbsp;</td>
                </tr>
                <tr>
                    <td height="27">&nbsp;<asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" align="center" celpadding="0" cellspacing="0">
                            <tr>
                                <td>
                                    <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-right-style: solid; border-bottom-style: solid; border-width: thin; border-color: #000000">
                                        <tr>
                                            <td align="center" class="auto-style1"><asp:Image ID="Image1" runat="server" Width="150px" Height="150px" /></td>
                                            <td width="50%" align="left" valign="top">
                                                <table width="100%" align="left" celpadding="0" cellspacing="0">
                                                    <tr>
                                                        <td colspan="2" height="60">&nbsp;</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="27" class="auto-style2">Name:</td>
                                                        <td width="65%"><asp:Label ID="lblMemberName" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="27" class="auto-style2">Member No:</td>
                                                        <td><asp:Label ID="lblMemberNo" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="27" class="auto-style2">Dedicated Hunters No:</td>
                                                        <td><asp:Label ID="lblHunterNo" runat="server" Text=""></asp:Label></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td height="45" align="center" colspan="2"><asp:Label ID="lblAssName" Font-Size="X-Large" Font-Bold="true" runat="server" Text=""></asp:Label></td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No data available" Width="95%" Font-Size="Small">
                                                    <Columns>
                                                        <asp:BoundField DataField="Hunts_Id" HeaderText="Hunt Id" />
                                                        <asp:BoundField DataField="Date_From" HeaderText="Date From" DataFormatString="{0:yyyy/MM/dd}" />
                                                        <asp:BoundField DataField="Date_To" HeaderText="Date To" DataFormatString="{0:yyyy/MM/dd}" />
                                                        <asp:BoundField DataField="FarmName" HeaderText="Hunting Farm" />
                                                        <asp:BoundField DataField="Weapon" HeaderText="Weapon Used" />
                                                        <asp:BoundField DataField="Calibre" HeaderText="Calibre" />
                                                        <asp:BoundField DataField="Species" HeaderText="Species" />
                                                        <asp:BoundField DataField="OwnerName" HeaderText="Farm Owner" />
                                                        <asp:BoundField DataField="CellNo" HeaderText="Tel No" />
                                                        <asp:BoundField DataField="MeetingsAttended" HeaderText="Meetings Attended" />
                                                    </Columns>
                                                </asp:GridView>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">&nbsp;</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
