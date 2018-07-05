<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="CaptureEvent.aspx.vb" Inherits="Associations_CaptureEvent" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .divFormMng {
            display: inline-block;
            vertical-align: top;
        }
        .divMainContainer {
            display: inline-block;
            /*width: 30%;*/
            vertical-align: top;
        }
        .divPagewide {
            vertical-align: top;
        }
        .Column1{
            width: 200px;
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>
        <ContentTemplate>
            <table width="100%" align="center" celpadding="0" cellspacing="0">
                <tr>
                    <td height="35">Capture Event:</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" align="center" celpadding="0" cellspacing="0">
                            <tr>
                                <td height="27" width="15%">Association:</td>
                                <td width="85%"><asp:DropDownList ID="ddlAssociations" runat="server" Width="250px" DataTextField="Name" DataValueField="Association_Id" AutoPostBack="true"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="pnlEvents" Visible="false" runat="server">
                                        <table width="100%" align="center" celpadding="0" cellspacing="0">
                                            <tr>
                                                <td height="27" width="15%">Event Type:</td>
                                                <td width="85%"><asp:DropDownList ID="ddlEvents" runat="server" Width="250px" DataTextField="Event_Name" DataValueField="event_id" AutoPostBack="true"></asp:DropDownList></td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2" height="27">&nbsp;<asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="pnlMember" Visible="false" runat="server">
                                        <table width="60%" align="left" cellpadding="5" cellspacing="0" style="border-left-style: solid; border-bottom-style: solid; border-width: thin; border-color: #000000">
                                            <tr>
                                                <td height="27" width="25%">Member Name:</td>
                                                <td width="25%"><asp:Label ID="lblName" runat="server" Text=""></asp:Label></td>
                                                <td width="25%">Date:</td>
                                                <td width="25%">
                                                    <asp:TextBox ID="txtDate" CssClass="textbox" Width="200px" runat="server"></asp:TextBox>
                                                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" TodaysDateFormat="yyyy/MM/dd" PopupPosition="BottomRight" />
                                                </td>
                                            </tr>
                                            <tr>
                                                <td height="27">Member No:</td>
                                                <td><asp:Label ID="lblMemberNo" runat="server" Text=""></asp:Label></td>
                                                <td>ID No:</td>
                                                <td><asp:Label ID="lblIdNo" runat="server" Text=""></asp:Label></td>
                                            </tr>
                                            <tr>
                                                <td colspan="4">&nbsp;</td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" align="center" celpadding="0" cellspacing="0">
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="pnlScoreSheet" Visible="false" runat="server">
                                    <table width="100%" align="left" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td colspan="4">
                                                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="1">
                                                    <tr>
                                                        <td height="25" colspan="13" align="center"><b>Animal Targets</b></td>
                                                        <td rowspan="3" align="center" width="5%">Total</td>
                                                        <td rowspan="3" align="center" width="5%">Shots <br />Fired<br /> <span style="font-size: xx-small;">(SF)</span></td>
                                                        <td rowspan="3" align="center" width="5%">Max Scoring<br /> <span style="font-size: xx-small;">(SF)x30</span></td>
                                                        <td rowspan="3" align="center" width="5%">% <br />Success<br /><span style="font-size: xx-small;">Total/Max Scoring</span></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" rowspan="2" align="center" width="20%">Target Type</td>
                                                        <td rowspan="2" align="center" width="5%">Distance Meters</td>
                                                        <td colspan="5" align="center">Positive Scoring</td>
                                                        <td align="center">V-Bulls</td>
                                                        <td colspan="5" align="center">Negative Scoring</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" align="center" width="5%">x30</td>
                                                        <td align="center" width="5%">x20</td>
                                                        <td align="center" width="5%">x15</td>
                                                        <td align="center" width="5%">x10</td>
                                                        <td align="center" width="5%">x5</td>
                                                        <td align="center" width="5%">x0.1</td>
                                                        <td align="center" width="5%">x-30</td>
                                                        <td align="center" width="5%">x-20</td>
                                                        <td align="center" width="5%">x-15</td>
                                                        <td align="center" width="5%">x-10</td>
                                                        <td align="center" width="5%">x-5</td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" align="left"><b>&nbsp;Blesbok</b></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokMeters" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokx30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokx20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokx15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokx10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokx5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokx01" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbok30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbok20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbok15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbok10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbok5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlesbokSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" align="left"><b>&nbsp;Blouwillebees</b></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesMeters" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesx30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesx20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesx15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesx10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesx5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesx01" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebees30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebees20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebees15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebees10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebees5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtBlouwillebeesSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" align="left"><b>&nbsp;Jakkels</b></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsMeters" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsx30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsx20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsx15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsx10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsx5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsx01" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkels30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkels20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkels15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkels10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkels5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtJkkelsSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" align="left"><b>&nbsp;Rooibok</b></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokMeters" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokx30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokx20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokx15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokx10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokx5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokx01" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibok30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibok20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibok15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibok10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibok5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooibokSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" align="left"><b>&nbsp;Rooihartbees</b></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesMeters" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesx30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesx20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesx15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesx10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesx5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesx01" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbees30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbees20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbees15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbees10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbees5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtRooihartbeesSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" align="left"><b>&nbsp;Springbok</b></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokMeters" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokx30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokx20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokx15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokx10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokx5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokx01" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbok30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbok20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbok15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbok10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbok5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtSpringbokSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" align="left"><b>&nbsp;Vlakvark</b></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkMeters" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkx30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkx20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkx15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkx10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkx5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkx01" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvark30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvark20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvark15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvark10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvark5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtVlakvarkSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                    <tr>
                                                        <td height="25" align="left"><b>&nbsp;Other</b></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherMeters" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherx30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherx20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherx15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherx10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherx5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherx01" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOther30" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOther20" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOther15" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOther10" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOther5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                        <td align="center"><asp:TextBox ID="txtOtherSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">
                                                <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                                                    <tr>
                                                        <td width="47.4%" valign="top">
                                                            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="1">
                                                                <tr>
                                                                    <td height="25" align="center" colspan="2"><b>Range Name:</b></td>
                                                                    <td colspan="7"><asp:TextBox ID="txtRangeName" Width="500px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" width="11.1%" align="center"><span style="font-size: small;">Temperature</span></td>
                                                                    <td width="11.1%" align="center"><span style="font-size: small;">Wnid Speed</span></td>
                                                                    <td width="11.1%" align="center"><span style="font-size: small;">Wind Direction</span></td>
                                                                    <td width="11.1%" align="center"><span style="font-size: small;">Pressure</span></td>
                                                                    <td width="11.1%" align="center"><span style="font-size: small;">Humidity</span></td>
                                                                    <td width="11.1%" align="center"><span style="font-size: small;">Altitude</span></td>
                                                                    <td width="11.1%" align="center"><span style="font-size: small;">Target Direction</span></td>
                                                                    <td width="11.1%" align="center"><span style="font-size: small;">Calibre Gun</span></td>
                                                                    <td width="11.1%" align="center"><span style="font-size: small;">Bullet Grain</span></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" align="center"><asp:TextBox ID="txtTemperature" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtWindSpeed" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtWindDirection" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtPressure" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtHumidity" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtAltitude" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtTargetDirection" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtCalibreGun" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtBulletGrain" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" align="center" colspan="2">Notes:</td>
                                                                    <td colspan="7"><asp:TextBox ID="txtNotes" Width="500px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td width="5.2%">&nbsp;</td>
                                                        <td width="47.4%" valign="top">
                                                            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="1">
                                                                <tr>
                                                                    <td height="25" align="center" colspan="5"><b>Gong</b></td>
                                                                    <td align="center" rowspan="3">Total</td>
                                                                    <td align="center" rowspan="3">Shots<br />Fired<br /><span style="font-size: xx-small;">(SF)</span></td>
                                                                    <td align="center" rowspan="3">Max<br />Scoring<br /><span style="font-size: xx-small;">(SF)x30</span></td>
                                                                    <td align="center" rowspan="3">%<br />Success<br /><span style="font-size: xx-small;">Total/Max Scoring</span></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" align="center">Gong 1</td>
                                                                    <td align="center">Gong 2</td>
                                                                    <td align="center">Gong 3</td>
                                                                    <td align="center">Gong 4</td>
                                                                    <td align="center">Gong 5</td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" align="center">x30</td>
                                                                    <td align="center">x30</td>
                                                                    <td align="center">x30</td>
                                                                    <td align="center">x30</td>
                                                                    <td align="center">x30</td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" width="11.1%" align="center"><asp:TextBox ID="txtGong1" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td width="11.1%" align="center"><asp:TextBox ID="txtGong2" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td width="11.1%" align="center"><asp:TextBox ID="txtGong3" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td width="11.1%" align="center"><asp:TextBox ID="txtGong4" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td width="11.1%" align="center"><asp:TextBox ID="txtGong5" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td width="11.1%" align="center"><asp:TextBox ID="txtGongTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td width="11.1%" align="center"><asp:TextBox ID="txtGongSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td width="11.1%" align="center"><asp:TextBox ID="txtGongMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td width="11.1%" align="center"><asp:TextBox ID="txtGongSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
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
                                                        <td valign="top">
                                                            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="0">
                                                                <tr>
                                                                    <td height="27">
                                                                        Upload Scoresheet:&nbsp;
                                                                        <asp:FileUpload ID="FileUpload1" Width="300px" runat="server" />
                                                                    </td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                        <td>&nbsp;</td>
                                                        <td>
                                                            <table width="100%" align="center" cellpadding="0" cellspacing="0" border="1">
                                                                <tr>
                                                                    <td height="25" align="center" width="55.5%"><b>Total</b></td>
                                                                    <td align="center" width="11.1%">Total</td>
                                                                    <td align="center" width="11.1%">Shots<br />Fired</td>
                                                                    <td align="center" width="11.1%">Max<br />Scoring</td>
                                                                    <td align="center" width="11.1%">%<br />Success</td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" align="center">Animal Targets</td>
                                                                    <td align="center"><asp:TextBox ID="txtAnimalTargetTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtAnimalTargetSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtAnimalTargetMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtAnimalTargetSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" align="center">Gong Scoring</td>
                                                                    <td align="center"><asp:TextBox ID="txtGongScoringTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtGongScoringSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtGongScoringMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtGongScoringSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                                <tr>
                                                                    <td height="25" align="center">Event Total</td>
                                                                    <td align="center"><asp:TextBox ID="txtEventTotalTotal" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtEventTotalSF" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtEventTotalMS" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                    <td align="center"><asp:TextBox ID="txtEventTotalSuccess" Width="50px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                                                </tr>
                                                            </table>
                                                        </td>
                                                    </tr>
                                                </table>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="4">&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" height="35"><asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" Width="250px" /></td>
                                        </tr>
                                        <tr>
                                            <td colspan="4" align="center" height="27"><asp:Label ID="lblError" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                                        </tr>
                                    </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

