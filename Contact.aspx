<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Contact.aspx.vb" Inherits="Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .panel-style2 {
            width: 50%;
        }

        .auto-style3 {
            height: 23px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="h1">Contact</div>
    <div>
        <table style="width: 100%;">
            <tr>
                <td>Need some help?
                    <br />
                    Or have some questions?<br />
                    Submit the below form and we will contact you with assitance.</td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Panel ID="pnlForm" runat="server">
                        <table class="panel-style2">
                            <%--<tr>
                            <td>Farm Name<br />
                                <asp:TextBox ID="txtFarmName" runat="server" Width="422px" CssClass="textbox"></asp:TextBox>
                            </td>
                        </tr>--%>
                            <tr>
                                <td>Email<br />
                                    <asp:TextBox ID="txtEmail" runat="server" Width="422px" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Contact Person<br />
                                    <asp:TextBox ID="txtContactPerson" runat="server" Width="422px" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>Phone Number<br />
                                    <asp:TextBox ID="txtPhone" runat="server" Width="422px" CssClass="textbox"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>How should we Contact you<br />
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                        <asp:ListItem>Select</asp:ListItem>
                                        <asp:ListItem>Email</asp:ListItem>
                                        <asp:ListItem>Phone</asp:ListItem>
                                    </asp:DropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td>Message<br />
                                    <asp:TextBox ID="txtMessage" runat="server" Width="418px" CssClass="textbox" Height="84px" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Button ID="Button1" runat="server" CssClass="button" Text="Submit" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                    <asp:Panel ID="pnlSucess" runat="server" Visible="False" Width="637px">
                        <table style="width: 100%;">
                            <tr>
                                <td>Thank you, your question has been submitted.</td>
                            </tr>
                            <tr>
                                <td class="auto-style3"></td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td>&nbsp;</td>
            </tr>
        </table>

    </div>
</asp:Content>

