<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="FarmManageGallery.aspx.vb" Inherits="Farms_FarmManageGallery" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%--<table width="100%" align="center" cellpadding="0" cellspacing="0" style="background-color: #494D50">
        <tr>
            <td>&nbsp;</td>
        </tr>
         <tr>
             <td>--%>
    <table width="90%" align="center" cellpadding="0" cellspacing="0">
        <tr>
            <td class="h1"><span class="HeaderLabel">Manage Gallery : </span></td>
        </tr>
        <tr>
            <td class="h1">
                <div align="left">
                    <asp:Panel ID="pnlFarmSelect" runat="server" Visible="True">
                        &nbsp;Farms:
                        <asp:DropDownList ID="cmbFarms" runat="server" AutoPostBack="True" DataTextField="FarmName" DataValueField="id"></asp:DropDownList>
                    </asp:Panel>
                </div>
            </td>
        </tr>
        <tr>
            <td>Click &quot;Create New Album&quot; to create a new album.<br />
                After Album is created click on the Select Icon&nbsp;
                <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/select.png" />
                to open the Album.</td>
        </tr>
        <tr>
            <td>
                <table width="100%" align="center" cellpadding="0" cellspacing="0">
                    <tr>
                        <td align="left" width="50%">
                            <table width="100%" align="center" cellpadding="0" cellspacing="0">
                                <tr>
                                    <td align="left" height="35">
                                        <asp:Button ID="btnAddMain" runat="server" CssClass="button" Text="Create New Album" /></td>
                                </tr>
                                <tr>
                                    <td>
                                        <table width="100%" align="center">
                                            <tr>
                                                <td valign="top" width="50%">
                                                    <div style="overflow: auto auto; height: 200px;">
                                                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" BorderColor="#666666" BorderStyle="Solid" BorderWidth="2px" Width="350px" ShowHeader="False">
                                                            <Columns>
                                                                <asp:ButtonField ButtonType="Image" CommandName="ViewLine" ImageUrl="~/Images/Icons/select.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:ButtonField>
                                                                <asp:BoundField DataField="id" HeaderText="Id" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemStyle HorizontalAlign="Left" Width="20px"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:BoundField DataField="Name" HeaderText="Main Folder" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Left">
                                                                    <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                                                </asp:BoundField>
                                                                <asp:ButtonField ButtonType="Image" CommandName="EditLine" ImageUrl="~/Images/Icons/edit.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                    <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                </asp:ButtonField>
                                                                <asp:ButtonField ButtonType="Image" CommandName="myDelete" ImageUrl="~/Images/Icons/trash.png" HeaderText="Delete"></asp:ButtonField>
                                                            </Columns>
                                                            <HeaderStyle BackColor="#184D43" ForeColor="White" />
                                                        </asp:GridView>
                                                    </div>
                                                </td>
                                                <td valign="top" width="50%">
                                                    <asp:Panel ID="pnlAddMain" runat="server" Visible="false">
                                                        <table width="100%" align="center">
                                                            <tr>
                                                                <td height="27">#<asp:TextBox ID="txtMainFolderId" runat="server" Width="10px" BorderStyle="None" BackColor="Transparent"></asp:TextBox></td>
                                                                <td>&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td height="27" width="30%">Name : </td>
                                                                <td width="70%">
                                                                    <asp:TextBox ID="txtMainName" runat="server" Width="240px" CssClass="textbox"></asp:TextBox></td>
                                                            </tr>
                                                            <tr>
                                                                <td height="27" width="30%">Description (optional):</td>
                                                                <td width="70%">
                                                                    <asp:TextBox ID="TextBox1" runat="server" Height="40px" TextMode="MultiLine" Width="325px" CssClass="textbox"></asp:TextBox>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td width="30">&nbsp;</td>
                                                                <td>
                                                                    <asp:Button ID="btnSubmitMain" runat="server" CssClass="nextPrevButton" Text="Submit" /></td>
                                                            </tr>
                                                        </table>
                                                    </asp:Panel>
                                                </td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlSub" runat="server" Visible="false">
                                            <table width="100%" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="2" style="border-top-style: solid; border-width: thin; border-color: #184D43">Click on &quot;Create New Sub Album&quot; to create a Sub Album.<br />
                                                        After Sub Album is created click on the Select Icon&nbsp;
                                                        <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icons/select.png" />
                                                        to load images.
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td valign="top" width="50%">
                                                        <table width="100%" align="center" cellpadding="0" cellspacing="0">
                                                            <tr>
                                                                <td height="27" colspan="2">
                                                                    <span class="HeaderLabel">#</span>
                                                                    <asp:Label ID="lblMainId" runat="server" Text="" CssClass="HeaderLabel"></asp:Label>&nbsp;
                                                                                    <asp:Label ID="txtMain" runat="server" Text="" CssClass="HeaderLabel"></asp:Label>
                                                                </td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2" height="35">
                                                                    <asp:Button ID="btnAddSubFolder" runat="server" CssClass="button" Text="Create New Sub Album" /></td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">&nbsp;</td>
                                                            </tr>
                                                            <tr>
                                                                <td colspan="2">
                                                                    <div style="overflow: auto auto; height: 200px;">
                                                                        <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" BorderColor="#666666" BorderStyle="Solid" BorderWidth="2px" Width="350px" ShowHeader="False">
                                                                            <Columns>
                                                                                <asp:ButtonField ButtonType="Image" CommandName="ViewLine" ImageUrl="~/Images/Icons/select.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:ButtonField>
                                                                                <asp:BoundField DataField="subId" HeaderText="Id" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Left">
                                                                                    <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                                                </asp:BoundField>
                                                                                <asp:BoundField DataField="Name" HeaderText="Main Folder" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                                                                                    <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                                                </asp:BoundField>
                                                                                <asp:ButtonField ButtonType="Image" CommandName="EditLine" ImageUrl="~/Images/Icons/edit.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                                    <ItemStyle HorizontalAlign="Center" />
                                                                                </asp:ButtonField>
                                                                                <asp:ButtonField ButtonType="Image" CommandName="myDelete" ImageUrl="~/Images/Icons/trash.png" HeaderText="Delete"></asp:ButtonField>
                                                                            </Columns>
                                                                            <HeaderStyle BackColor="#184D43" ForeColor="White" />
                                                                        </asp:GridView>
                                                                    </div>
                                                                </td>
                                                            </tr>
                                                        </table>
                                                    </td>
                                                    <td valign="top" width="50%">
                                                        <asp:Panel ID="pnlSubFolder" runat="server" Visible="false">
                                                            <table width="100%" align="center" cellpadding="0" cellspacing="0">
                                                                <tr>
                                                                    <td colspan="2" height="60">&nbsp;</td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="27">#<asp:TextBox ID="txtsubId" runat="server" BorderStyle="None" Width="30px" BackColor="Transparent"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="27">Name :</td>
                                                                    <td>
                                                                        <asp:TextBox ID="txtSub" runat="server" Width="240px" CssClass="textbox"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="27" width="30%">Description (optional):</td>
                                                                    <td width="70%">
                                                                        <asp:TextBox ID="TextBox2" runat="server" Height="40px" TextMode="MultiLine" Width="325px" CssClass="textbox"></asp:TextBox>
                                                                    </td>
                                                                </tr>
                                                                <tr>
                                                                    <td width="30%" height="27">&nbsp;</td>
                                                                    <td width="70%">
                                                                        <asp:Button ID="btnAdd" runat="server" CssClass="nextPrevButton" Text="Submit" /></td>
                                                                </tr>
                                                            </table>
                                                        </asp:Panel>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Panel ID="pnlPhotos" runat="server" Visible="false">
                                            <table width="100%" align="center" cellpadding="0" cellspacing="0">
                                                <tr>
                                                    <td colspan="2" style="border-top-style: solid; border-width: thin; border-color: #184D43">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td height="27" colspan="2"><span class="HeaderLabel">#</span><asp:Label ID="lblMain1" runat="server" Text="" CssClass="HeaderLabel"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td height="27" colspan="2"><span class="HeaderLabel">#</span><asp:Label ID="txtSubId1" runat="server" Text="" CssClass="HeaderLabel"></asp:Label>&nbsp;<asp:Label ID="txtSub1" runat="server" Text="" CssClass="HeaderLabel"></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td width="25%" height="27">Photo Name :</td>
                                                    <td width="75%">
                                                        <asp:TextBox ID="txtPhoto" runat="server" Width="300px" CssClass="textbox"></asp:TextBox>&nbsp(20 characters)</td>
                                                </tr>
                                                <tr>
                                                    <td height="27">&nbsp;</td>
                                                    <td>
                                                        <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" />&nbsp;(97 x 102)</td>
                                                </tr>
                                                <tr>
                                                    <td height="27">&nbsp;</td>
                                                    <td>
                                                        <asp:Button ID="btnUpload" runat="server" CssClass="button" Text="Update" /></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">&nbsp;</td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">
                                                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                    </td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2">&nbsp;</td>
                                                </tr>
                                            </table>
                                        </asp:Panel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                </table>
            </td>
        </tr>
        </tr>  
                     <tr>
                         <td>&nbsp;</td>
                     </tr>
        <tr>
            <td>&nbsp;<asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></td>
        </tr>
    </table>
</asp:Content>

