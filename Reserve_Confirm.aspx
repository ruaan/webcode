<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Reserve_Confirm.aspx.vb" Inherits="Reserve_Confirm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>&nbsp;</div>
    <div id="divEmail" style="padding-left: 10px" runat="server">
        <div>Your Booking request has been forwarded to the Game farm to confirm availibility.</div>
        <div>You will receive an E-mail to confirm availibilty and instructions to pay the deposit to secure your booking.</div>
    </div>
    <div id="divDirect" style="padding-left: 10px" runat="server">
        <div>
            <p>
                Thank you for the reservation.
            </p>
            <p>
                A deposit of R
                <asp:Label ID="lblDepositAmount" runat="server" Text="Label"></asp:Label>
                &nbsp; is due before
                <asp:Label ID="lblDepositDue" runat="server" Text="Label"></asp:Label>
                &nbsp; to secure your booking.
            </p>
            <p>
                Navigate to "My Hunts" when you are ready to pay or click on the link below to pay the deposit now.
            </p>
            <p>
                <asp:Button ID="Button1" runat="server" Text="Pay Deposit now" BackColor="White" BorderStyle="None" ForeColor="#86B24F" Style="cursor: pointer" />
            </p>
        </div>
    </div>
    <asp:HiddenField ID="HiddenFieldbookingEmail" runat="server" />
    <asp:HiddenField ID="HiddenFieldFarmEmail" runat="server" />
    <asp:HiddenField ID="HiddenFieldConfirmDates" runat="server" />
</asp:Content>

