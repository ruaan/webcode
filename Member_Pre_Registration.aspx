<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGrnNotLoggedIn.master" AutoEventWireup="false" CodeFile="Member_Pre_Registration.aspx.vb" Inherits="Member_Pre_Registration" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>&nbsp;</div>
    <div id="mainPageWrapper" style="align-content: center;">
        <div class="div_MainBlock">
            <div style="text-align: left; width: 1050px; display: inline-block;">
                <asp:Panel ID="pnlPersonalDetails" runat="server" Width="829px">
                    <table style="width: 800px;">
                        <tr>
                            <td class="auto-style1">&nbsp;</td>
                            <td class="auto-style2">&nbsp;</td>
                            <td class="auto-style8">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Title:</td>
                            <td class="auto-style2">
                                <asp:DropDownList ID="cmbTitle" runat="server" CssClass="textbox">
                                    <asp:ListItem>Mr</asp:ListItem>
                                    <asp:ListItem>Mrs</asp:ListItem>
                                    <asp:ListItem>Dr</asp:ListItem>
                                    <asp:ListItem>Prof</asp:ListItem>
                                    <asp:ListItem>Adv</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style8">Initials:</td>
                            <td>
                                <asp:TextBox ID="txtInitials" runat="server" CssClass="textbox" MaxLength="10" Width="86px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style1">Surname:</td>
                            <td class="auto-style2">
                                <asp:TextBox ID="txtSurname" runat="server" CssClass="textbox" MaxLength="50" Width="301px"></asp:TextBox>
                            </td>
                            <td class="auto-style8">&nbsp;</td>
                            <td>&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Full names:</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtFullName" runat="server" CssClass="textbox" MaxLength="100" Width="301px"></asp:TextBox>
                            </td>
                            <td class="auto-style9">Preferred name:</td>
                            <td class="auto-style7">
                                <asp:TextBox ID="txtPreferredName" runat="server" CssClass="textbox" MaxLength="50" Width="301px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Gender:</td>
                            <td class="auto-style5">
                                <asp:RadioButtonList ID="rdbGender" runat="server">
                                    <asp:ListItem>Male</asp:ListItem>
                                    <asp:ListItem>Female</asp:ListItem>
                                </asp:RadioButtonList>
                            </td>
                            <td class="auto-style9">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Id no:</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtIdNo" runat="server" CssClass="textbox" MaxLength="50" Width="301px"></asp:TextBox>
                            </td>
                            <td class="auto-style9">Passport no:</td>
                            <td class="auto-style7">
                                <asp:TextBox ID="txtPassport" runat="server" CssClass="textbox" MaxLength="50" Width="301px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Country:</td>
                            <td class="auto-style5">
                                <asp:DropDownList ID="cmbCountry" runat="server" CssClass="textbox">
                                    <asp:ListItem>South Africa</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                            <td class="auto-style9">Nationality:</td>
                            <td class="auto-style7">
                                <asp:DropDownList ID="cmbNationality" runat="server" CssClass="textbox">
                                    <asp:ListItem>South African</asp:ListItem>
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style9">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">E-mail:</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" MaxLength="100" Width="301px"></asp:TextBox>
                            </td>
                            <td class="auto-style9">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">Cell:</td>
                            <td class="auto-style5">
                                <asp:TextBox ID="txtCell" runat="server" AutoCompleteType="Cellular" CssClass="textbox" MaxLength="50" Width="301px"></asp:TextBox>
                            </td>
                            <td class="auto-style9">Work Tel:</td>
                            <td class="auto-style7">
                                <asp:TextBox ID="txtWorkTel" runat="server" CssClass="textbox" MaxLength="50" Width="301px"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style9">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style7" colspan="4">If referred by another member enter his Member Id:
                            <asp:TextBox ID="txtReferredBy" runat="server" CssClass="textbox"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style9">&nbsp;</td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style9">
                                <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" />
                            </td>
                            <td class="auto-style7">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style4">&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                            <td class="auto-style7" colspan="2">
                                <asp:Label ID="lblSubmitMsg" runat="server"></asp:Label>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </div>
            <asp:Panel ID="pnlConfirm" runat="server" CssClass="textbox" Visible="False">
                <table style="width: 100%;">
                    <tr>
                        <td>Thank you for applying.</td>
                    </tr>
                    <tr>
                        <td>a Confirmation email will be sent to
                        <asp:Label ID="lblEmailSentTo" runat="server"></asp:Label>
                            &nbsp;(Please allow 24 hrs)</td>
                    </tr>
                    <tr>
                        <td>Follow the instruction on the e-mail to complete your registration.</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblCompleteId" runat="server" ForeColor="#4A4D4F"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" Text="Click here to follow link that will be received by Email (only visible during Dev)" BackColor="#4A4D4F" BorderStyle="None" ForeColor="#FFCC00" /></td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Label ID="lblMsg" runat="server"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btnOk" runat="server" Text="OK" CssClass="button" Width="49px" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </div>
    </div>
</asp:Content>

