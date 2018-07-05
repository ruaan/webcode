<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CalendarView_App.aspx.vb" Inherits="BookingSystem_CalendarView_App" %>
<%@ Register assembly="DataCalendar" namespace="DataControls" tagprefix="cc1" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color:#424531;
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
            font-family:Calibri;
            color:#333333;
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
                  <img alt="" src="../Images/Headings/view-calendar.jpg" /></div>
   
            <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
    <table style="width:100%;" class="divDetails">
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td><asp:Panel ID="pnlFarmSelect" runat="server" Visible="True">
                    &nbsp;Farms: <asp:DropDownList ID="cmbFarms" runat="server" AutoPostBack="True" DataTextField="FarmName" DataValueField="id"></asp:DropDownList></asp:Panel></td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <cc1:DataCalendar ID="cal1" runat="server" width="80%"
                             DayField="BookingDate"
                             VisibleDate="10/1/2003"
                             OnVisibleMonthChanged="MonthChange" Visible="False">

                <DayStyle HorizontalAlign="Left" VerticalAlign="Top"
                          Font-Size="8" Font-Name="Arial" BackColor="white" />
                          
                <OtherMonthDayStyle BackColor="LightGray" ForeColor="DarkGray"
                           />

                <ItemTemplate>
                    <br />                    
                    <%--<a href='eventDetails.aspx?id=<%# Container.DataItem("HuntID") %>'>     --%>
                        <a href='javascript:showDetails(<%# Container.DataItem("HuntID") %>)'>   
                        
                        <img src='../Images/Icons/Farm_Search/HuntType/shotgun-hunting.png' height="18" width="18" align="absmiddle" border="0"/>
                       <%-- <font color='<%# Container.DataItem("CategoryColor") %>'>
                            <%# Container.DataItem("HunterName") %>
                        </font>--%>
                          <font>
                            <%# Container.DataItem("HunterName") %>
                        </font>
                    </a>            
                </ItemTemplate>
                 
                <NoEventsTemplate>
                    <a href='addEvent_App.aspx'>  <img src='../Images/Icons/editS.png' height="18" width="18" align="absmiddle" border="0"/>
                    <br />
                    <br />
                    <br />
                    <br />
                    <br />
                        </a>   
                </NoEventsTemplate>
                    
                </cc1:DataCalendar>
            </td>
        </tr>
        <tr>
            <td>&nbsp;</td>
        </tr>
    </table>
    <asp:Panel ID="pnlEventDetail" runat="server"  BackColor="White" BorderColor="#3E432F" BorderStyle="Solid" BorderWidth="2px">
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
                    <td><asp:Label id="txtTitle" runat="server" /></td>
                </tr>

                <tr valign="top">
                    <td><b>Event Description:</b></td>
                    <td><asp:Label id="txtDescription" runat="server" /></td>
                </tr>

                <tr valign="top">
                    <td><b>Event Selected Date:</b></td>
                    <td><asp:Label id="txtDate" runat="server" /></td>
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
                        <asp:Image id="imgCategory" runat="server" ImageAlign="absmiddle" />                        
                        <asp:Label id="txtCategory" runat="server" />
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
                    <asp:Button ID="btnPopupOk" runat="server" Text="OK" BackColor="#86B24F" BorderStyle="None" Font-Size="Larger" ForeColor="White" />
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Button ID="Button1" runat="server" BackColor="#424531" BorderStyle="None" />
    <cc2:ModalPopupExtender ID="pnlEventDetail_ModalPopupExtender" runat="server" BehaviorID="Button1" CancelControlID="btnPopupOk"  TargetControlID="Button1" Drag="True" DropShadow="True" PopupControlID="pnlEventDetail" PopupDragHandleControlID="pnlDrag" DynamicServicePath="">
    </cc2:ModalPopupExtender>
    <asp:Button ID="Button2" runat="server" BackColor="#424531" BorderStyle="None" />
        <asp:HiddenField ID="HiddenFieldHuntId" runat="server" />
        
        </ContentTemplate></asp:UpdatePanel>
  
        </div>
    </form>
      <script type="text/javascript">
          function showDetails(huntId) {
              var btnShow = document.getElementById('<%=Button2.ClientID%>');
            var thishuntId = document.getElementById('<%=HiddenFieldHuntId.ClientID%>');
            thishuntId.value = huntId
            btnShow.click();

          }

    </script>
</body>
</html>
