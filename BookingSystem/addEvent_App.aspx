<%@ Page Language="VB" AutoEventWireup="false" CodeFile="addEvent_App.aspx.vb" Inherits="BookingSystem_addEvent_App" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #424531;
        }

        .style-profile {
            width: 276px;
            height: 276px;
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

        .header_icon {
            width: 32px;
            height: 32px;
            vertical-align: middle;
        }

        .auto-style2 {
            width: 390px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div>
                <img alt="" src="../Images/Headings/add-booking.jpg" />
            </div>
        </div>

        <div>
            <table style="width: 100%;" class="divDetails">

                <tr>
                    <td>&nbsp;<asp:Panel ID="pnlFarmSelect" runat="server" Visible="True">
                        &nbsp;Select Farm:
                        <asp:DropDownList ID="cmbFarms" runat="server" AutoPostBack="True" DataTextField="FarmName" DataValueField="id"></asp:DropDownList>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>Date from:
                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" BehaviorID="txtDateFrom_CalendarExtender" TargetControlID="txtDateFrom"></cc1:CalendarExtender>
                        &nbsp;to
                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" BehaviorID="txtDateTo_CalendarExtender" TargetControlID="txtDateTo" />
                    </td>
                </tr>
                <tr>
                    <td>Event Description:
                <asp:TextBox ID="txtDescription" runat="server" Width="229px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>No Hunters:
                <asp:TextBox ID="txthuntersQty" runat="server" Width="77px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>No Guests:
                <asp:TextBox ID="txtGuestQty" runat="server" Width="85px" CssClass="textbox"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" />
                        &nbsp; &nbsp;
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" />
                        <asp:Label ID="lblMsg" runat="server"></asp:Label>
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
