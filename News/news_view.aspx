<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="news_view.aspx.vb" Inherits="News_news_view" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table width="1016px" align="center" cellpadding="0" cellspacing="0" border="0"
        style="background-position: right bottom; background-repeat: no-repeat; background-color: #FFFFFF;">
        <tr>
            <td width="20%" valign="top">
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"
                    EnableModelValidation="True" GridLines="None" ShowHeader="False" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="id">
                            <ItemStyle ForeColor="White" />
                        </asp:BoundField>
                        <asp:ButtonField CommandName="kies" DataTextField="topic_heading"
                            Text="Other Topics">
                            <ItemStyle ForeColor="Silver" />
                        </asp:ButtonField>
                    </Columns>
                </asp:GridView>
            </td>
            <td width="80%">
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
                            <asp:Panel ID="pnlComment" runat="server" Width="592px">

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
            </td>
        </tr>
        <tr>
            <td width="20%"></td>
            <td width="80%">&nbsp;</td>
        </tr>
    </table>
</asp:Content>

