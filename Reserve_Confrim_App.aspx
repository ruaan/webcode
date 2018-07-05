<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Reserve_Confrim_App.aspx.vb" Inherits="Reserve_Confrim_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: #373e2e;
        }

        .auto-style1 {
            width: 316px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div>&nbsp;</div>
            <div id="divEmail" style="padding-left: 10px; color: #FFFFFF;" runat="server">
                <div>Your Booking request has been forwarded to the Game farm to confirm availibility.</div>
                <div>You will receive an E-mail to confirm availibilty and instructions to pay the deposit to secure your booking.</div>
            </div>
            <div id="divDirect" style="padding-left: 10px" runat="server" class="auto-style1">
                <div>
                    &nbsp;
                </div>
                <div style="background-color: #D5EBBD; color: #333333; font-family: Calibri;">
                    <div>
                        <img alt="" src="Images/Icons/reservation-header.jpg" />
                    </div>
                    <p>
                        <strong>Thank you</strong> for the reservation.
                    </p>
                    <p>
                        A deposit of R
                        <asp:Label ID="lblDepositAmount" runat="server" Text="Label"></asp:Label>
                        &nbsp; is due before
                        <asp:Label ID="lblDepositDue" runat="server" Text="Label"></asp:Label>
                        &nbsp; to secure your booking.
                    </p>
                    <p>
                        You can pay the deposit now, or pay later and complete your booking through <strong>My Hunts.</strong>
                    </p>
                    <p>
                        <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Icons/depbutton.jpg" Width="314px" />
                    </p>
                </div>
            </div>
            <asp:HiddenField ID="HiddenFieldbookingEmail" runat="server" />
            <asp:HiddenField ID="HiddenFieldFarmEmail" runat="server" />
            <asp:HiddenField ID="HiddenFieldConfirmDates" runat="server" />
        </div>
    </form>
</body>
</html>
