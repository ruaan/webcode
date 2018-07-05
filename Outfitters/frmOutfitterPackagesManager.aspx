<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="frmOutfitterPackagesManager.aspx.vb" Inherits="Outfitters_frmPackagesManager" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .divsE {
            display: inline-block;
        }

        .divMainContainer {
            display: inline-block;
            width: 70%;
        }

        .divFormMng {
            display: inline-block;
        }

        .auto-style4 {
            font-size: xx-large;
            width: 7px;
        }

        .auto-style5 {
            width: 7px;
        }

        .auto-style7 {
            width: 416px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
        <ContentTemplate>
            <table width="100%" align="center" cellpadding="0" cellspacing"0">
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td height="30">Package&nbsp;&nbsp;&nbsp;<asp:Label ID="lblPackageId" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>&nbsp;<asp:Label ID="lblMsg" ForeColor="Red" runat="server" Text=""></asp:Label></td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" align="center" cellpadding="0" cellspacing"0">
                            <tr>
                                <td height="27" width="10%">Lodge:</td>
                                <td width="90%">
                                    <asp:DropDownList ID="ddlFarms" runat="server" Width="250px" 
                                        DataTextField="FarmName" DataValueField="id">
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">Package Heading:</td>
                                <td><asp:TextBox ID="txtHeading" Width="500px" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="175">Description:</td>
                                <td><asp:TextBox ID="txtDescription" Width="500px" runat="server" TextMode="MultiLine" Rows="10"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Cost:</td>
                                <td><asp:TextBox ID="txtCost" Width="500px" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">From Date:</td>
                                <td><asp:TextBox ID="txtFromDate" Width="250px" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">To Date:</td>
                                <td><asp:TextBox ID="txtToDate" Width="250px" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Included:</td>
                                <td>
                                    <asp:TextBox ID="txtIncluded" Width="500px" runat="server"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="btnAddIncluded" runat="server" Text="Add" CssClass="button" Width="80px" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BorderStyle="solid" Font-Size="x-Small" Width="500px" ShowHeader="False">
                                        <Columns>
                                            <asp:BoundField DataField="includedId">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Description">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:ButtonField ButtonType="Image" CommandName="Remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove"></asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>                            
                            <tr>
                                <td height="27">Excluded:</td>
                                <td>
                                    <asp:TextBox ID="txtExcluded" Width="500px" runat="server"></asp:TextBox>
                                    &nbsp;&nbsp;&nbsp;<asp:Button ID="Button1" runat="server" Text="Add" CssClass="button" Width="80px" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderStyle="solid" Font-Size="x-Small" Width="500px" ShowHeader="False">
                                        <Columns>
                                            <asp:BoundField DataField="excludedId">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Description">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:ButtonField ButtonType="Image" CommandName="Remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove"></asp:ButtonField>
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td height="45">&nbsp;</td>
                                <td align="left"><asp:Button ID="btnSubmit" runat="server" Text="Save Package" CssClass="button" Width="500px" /></td>
                            </tr>
                            <tr>
                                <td height="27">Picture Type:</td>
                                <td>
                                    <asp:DropDownList ID="ddlPicType" runat="server" Width="250px">
                                        <asp:ListItem>-Select-</asp:ListItem>
                                        <asp:ListItem>Large</asp:ListItem>
                                        <asp:ListItem>Below first</asp:ListItem>
                                        <asp:ListItem>Below second</asp:ListItem>
                                        <asp:ListItem>Below third</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">&nbsp;</td>
                                <td>Picture can not exceed 500kb and dimensions 400px x 400px for large image and 200px x 200px for small images</td>
                            </tr>
                            <tr>
                                <td height="27">&nbsp;</td>
                                <td><asp:FileUpload ID="FileUpload1" runat="server" /></td>
                            </tr>
                            <tr>
                                <td height="27">&nbsp;</td>
                                <td><asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="button" Width="80px" />&nbsp;<asp:Label ID="lblUploadMsg" runat="server" Text=""></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <table width="80%" align="left" cellpadding="0" cellpadding="0">
                                        <tr>
                                            <td width="55%" valign="top"><asp:Image ID="Image1" runat="server" BorderColor="#3E432F" BorderStyle="Solid" BorderWidth="2px" Height="400px" Width="400px" /></td>
                                            <td width="15%" valign="top"><asp:Image ID="Image2" runat="server" BorderColor="#3E432F" BorderStyle="Solid" BorderWidth="2px" Height="200px" Width="200px" /></td>
                                            <td width="15%" valign="top"><asp:Image ID="Image3" runat="server" BorderColor="#3E432F" BorderStyle="Solid" BorderWidth="2px" Height="200px" Width="200px" /></td>
                                            <td width="15%" valign="top"><asp:Image ID="Image4" runat="server" BorderColor="#3E432F" BorderStyle="Solid" BorderWidth="2px" Height="200px" Width="200px" /></td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>



