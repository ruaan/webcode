<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="CalendarView.aspx.vb" Inherits="BookingSystem_CalendarView" %>

<%@ Register Assembly="DataCalendar" Namespace="DataControls" TagPrefix="cc1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc2" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 390px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <table style="width: 100%;">
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlFarmSelect" runat="server" Visible="True">
                            &nbsp;Farms:
                            <asp:DropDownList ID="cmbFarms" runat="server" AutoPostBack="True" DataTextField="FarmName" DataValueField="id"></asp:DropDownList>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <cc1:DataCalendar ID="cal1" runat="server" Width="80%"
                            DayField="BookingDate"
                            VisibleDate="10/1/2003"
                            OnVisibleMonthChanged="MonthChange" Visible="False">

                            <DayStyle HorizontalAlign="Left" VerticalAlign="Top"
                                Font-Size="8" Font-Name="Arial" BackColor="white" />

                            <OtherMonthDayStyle BackColor="LightGray" ForeColor="DarkGray" />

                            <itemtemplate>
                    <br />                    
                   
                        <a href='javascript:showDetails(<%# Container.DataItem("HuntID") %>)'>   
                        
                        <img src='../Images/Icons/Farm_Search/HuntType/shotgun-hunting.png' height="18" width="18" align="absmiddle" border="0"/>
                     
                          <font>
                            <%# Container.DataItem("HunterName") %>
                        </font>
                    </a>            
                </itemtemplate>

                            <noeventstemplate>
                    <a href='addEvent.aspx'>  <img src='../Images/Icons/editS.png' height="18" width="18" align="absmiddle" border="0"/>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                        </a>   
                </noeventstemplate>

                        </cc1:DataCalendar>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
            <asp:Panel ID="pnlEventDetail" runat="server" BackColor="White" BorderColor="#3E432F" BorderStyle="Solid" BorderWidth="2px">
                <table style="width: 100%;">
                    <tr>
                        <td class="auto-style2">
                            <asp:Panel ID="pnlDrag" runat="server" BackColor="#86B24F">
                                Event Details
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td class="auto-style2">
                            <table>
                                <tr valign="top">
                                    <td><b>Event Title:</b></td>
                                    <td>
                                        <asp:Label ID="txtTitle" runat="server" /></td>
                                </tr>

                                <tr valign="top">
                                    <td><b>Event Description:</b></td>
                                    <td>
                                        <asp:Label ID="txtDescription" runat="server" /></td>
                                </tr>

                                <tr valign="top">
                                    <td><b>Event Selected Date:</b></td>
                                    <td>
                                        <asp:Label ID="txtDate" runat="server" /></td>
                                </tr>

                                <tr valign="top">
                                    <td><b>Event Dates:</b> </td>
                                    <td>
                                        <asp:Label ID="txtEventDate" runat="server"></asp:Label>
                                    </td>
                                </tr>

                                <tr valign="top">
                                    <td><b>Category:</b></td>
                                    <td>
                                        <asp:Image ID="imgCategory" runat="server" ImageAlign="absmiddle" />
                                        <asp:Label ID="txtCategory" runat="server" />
                                    </td>
                                </tr>

                                <tr valign="top">
                                    <td><b>Status:</b></td>
                                    <td>
                                        <asp:Label ID="txtStatus" runat="server"></asp:Label>
                                    </td>
                                </tr>

                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style2">
                            <asp:Panel ID="pnlInfo" runat="server">
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center" class="auto-style2">
                            <asp:Button ID="btnPopupOk" runat="server" Text="OK" />
                        </td>
                    </tr>
                </table>
            </asp:Panel>
            <asp:Button ID="Button1" runat="server" BackColor="White" BorderStyle="None" />
            <cc2:ModalPopupExtender ID="pnlEventDetail_ModalPopupExtender" runat="server" BehaviorID="Button1" CancelControlID="btnPopupOk" TargetControlID="Button1" Drag="True" DropShadow="True" PopupControlID="pnlEventDetail" PopupDragHandleControlID="pnlDrag" >
            </cc2:ModalPopupExtender>
            <asp:Button ID="Button2" runat="server" BackColor="White" BorderStyle="None" />
            <asp:HiddenField ID="HiddenFieldHuntId" runat="server" />

        </ContentTemplate>
    </asp:UpdatePanel>
    <script type="text/javascript">
        function showDetails(huntId) {
            var btnShow = document.getElementById('<%=Button2.ClientID%>');
            var thishuntId = document.getElementById('<%=HiddenFieldHuntId.ClientID%>');
            thishuntId.value = huntId
            btnShow.click();

        }

    </script>
</asp:Content>

