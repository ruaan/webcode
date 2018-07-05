<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Farm_Booking_Manager_App.aspx.vb" Inherits="BookingSystem_Farm_Booking_Manager_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #424531;
            margin: 0;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div>
                <img alt="" src="../Images/Headings/manage-booking.jpg" />
            </div>

            <div id="divDetails" class="divDetails">

                <div>&nbsp;<asp:Label ID="Label1" runat="server" Text="Label"></asp:Label></div>

                <div style="font-size: x-large">
                    <asp:Panel ID="pnlFarmSelect" runat="server" Visible="True">
                        &nbsp;Farms:
                        <asp:DropDownList ID="cmbFarms" runat="server" AutoPostBack="True" DataTextField="FarmName" DataValueField="id"></asp:DropDownList>
                    </asp:Panel>
                </div>
                <div>&nbsp;</div>
                <div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
