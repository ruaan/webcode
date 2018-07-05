<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="addNews.aspx.vb" Inherits="SetUp_addNews" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">



    <table align="center" style="width: 90%; font-family: Calibri; color: #1E1E1E; background-color: #FFFFFF;">
        <tr>
            <td>
                <div class="h1">Add News</div>

            </td>
        </tr>

        <tr>
            <td>
                <table align="center" style="width: 90%;">
                    <tr>
                        <td colspan="3">
                            <table style="width: 100%;">
                                <tr>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                                <ContentTemplate>--%>
                                        <table style="width: 100%;">
                                            <tr>
                                                <td class="style1">&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                            <tr>
                                                <td align="left" class="style1" valign="top">
                                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%">
                                                        <Columns>
                                                            <asp:BoundField DataField="Id" />
                                                            <asp:BoundField DataField="datetime" DataFormatString="{0:dd/MM/yyyy}"
                                                                HeaderText="Date" HtmlEncode="False" />
                                                            <asp:BoundField DataField="topic_heading" HeaderText="Topic" />
                                                            <asp:ButtonField ButtonType="Image" CommandName="Change"
                                                                ImageUrl="~/Images/Icons/edit.png" Text="Edit" />
                                                            <asp:ButtonField ButtonType="Image" CommandName="Archive"
                                                                ImageUrl="~/Images/Icons/trash.png" Text="Archive" />
                                                        </Columns>
                                                    </asp:GridView>
                                                </td>
                                                <td colspan="2">
                                                    <asp:Panel ID="pnlDetails" runat="server" BorderColor="#0B384D"
                                                        BorderStyle="Solid" BorderWidth="2px" Height="493px" Width="552px">
                                                        <table style="width: 100%; height: 467px;">
                                                            <tr>
                                                                <td class="style2">ADD TOPIC</td>
                                                                <td>&nbsp;</td>
                                                                <td>
                                                                    <asp:Label ID="lblId" runat="server"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">By (Name):</td>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtName" runat="server" Width="427px" CssClass="textbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">Topic:</td>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtTopic" runat="server" Width="427px" CssClass="textbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">Description: (max 255 char)</td>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtDescription" runat="server" Height="43px" MaxLength="255"
                                                                        TextMode="MultiLine" Width="427px" CssClass="textbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2" valign="top">Content:</td>
                                                                <td colspan="2">
                                                                    <asp:TextBox ID="txtContent" runat="server" Height="239px" TextMode="MultiLine"
                                                                        Width="427px" CssClass="textbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">&nbsp;</td>
                                                                <td>
                                                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="True"
                                                                        Text="Allow Comments" TextAlign="Left" />
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">&nbsp;</td>
                                                                <td colspan="2">Upload Image:
                                                                                <asp:CheckBox ID="CheckBox2" runat="server" Text="Remove Pic"
                                                                                    TextAlign="Left" />
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td class="style2">&nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="Button1" runat="server" Text="Save" />
                                                                    &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                                                                                <asp:Button ID="Button2" runat="server" Text="Clear" />
                                                                </td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td class="style1">&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                                <td>&nbsp;
                                                </td>
                                            </tr>
                                        </table>
                                        <%--</ContentTemplate>
                                            </asp:UpdatePanel>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:FileUpload ID="FileUpload1" runat="server" />
                                    </td>
                                    <td>&nbsp;</td>
                                    <td>&nbsp;</td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
</asp:Content>

