<%@ Page Language="VB" AutoEventWireup="false" CodeFile="ContactApp.aspx.vb" Inherits="ContactApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheets/StyleSheet2.css" rel="stylesheet" />
    <style type="text/css">
        body {
            background-color: #394025;
        }

        .panel-style2 {
            width: 50%;
        }

        .auto-style3 {
            height: 23px;
        }

        .divFilter {
            border: 1px solid #8d9296;
            padding: 4px;
            font-size: medium;
            background-color: #5B6849;
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            font-family: Calibri;
            color: white;
        }

        .divDetails {
            border: 1px solid #8d9296;
            padding: 4px;
            font-size: medium;
            background-color: #FFFFFF;
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            font-family: Calibri;
            color: #333333;
        }
    </style>
</head>
<body style="margin: 0">
    <form id="form1" runat="server">
        <div>
            <img alt="" src="Images/Headings/contact-us.jpg" style="width: 100%" />
        </div>

        <div style="font-family: Calibri; color: #333333">
            <table style="width: 100%;">
                <tr>
                    <td class="divFilter">Submit the form and we will contact you with assistance.</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlForm" runat="server" CssClass="divFilter">
                            <table style="width: 100%">

                                <tr>
                                    <td>Email<br />
                                        <asp:TextBox ID="txtEmail" runat="server" Width="80%" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Contact Person<br />
                                        <asp:TextBox ID="txtContactPerson" runat="server" Width="80%" CssClass="textbox"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>Phone Number<br />
                                        <asp:TextBox ID="txtPhone" runat="server" Width="80%" CssClass="textbox"></asp:TextBox>
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
                                        <asp:TextBox ID="txtMessage" runat="server" Width="80%" CssClass="textbox" Height="73px" TextMode="MultiLine"></asp:TextBox>
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
                        <asp:Panel ID="pnlSucess" runat="server" Visible="False" CssClass="divFilter">
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
    </form>
</body>
</html>
