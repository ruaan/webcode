<%@ Page Language="VB" AutoEventWireup="false" CodeFile="news_viewsApp.aspx.vb" Inherits="News_news_viewsApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table style="width: 100%;">
                <tr>
                    <td colspan="3">
                        <asp:Label ID="BlogId" runat="server" ForeColor="White"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td colspan="3">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td colspan="3" align="center">
                        <asp:Panel ID="pnlComment" runat="server" Width="80%">

                            <table border="0" cellpadding="3" cellspacing="1" class="style2"
                                style="border: thin solid #333399" width="100%">
                                <tr>
                                    <td colspan="3" width="18%" align="left">
                                        <h3 class="style17">Leave a comment here:</h3>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top">Comment</td>
                                    <td valign="top">:</td>
                                    <td align="left">
                                        <asp:TextBox ID="txtComment" runat="server" Height="75px" TextMode="MultiLine"
                                            Width="479px" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;<asp:Button ID="Button1" runat="server" Text="Save" CssClass="button" />
                                        &nbsp; &nbsp; &nbsp;
                                                        <asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="button" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3" style="color: #336699; font-weight: bold">&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
