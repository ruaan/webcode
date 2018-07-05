<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="addEvent.aspx.vb" Inherits="BookingSystem_addEvent" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <table style="width: 100%;">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <div class="h1">Add Booking</div>
            </td>
        </tr>
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
</asp:Content>

