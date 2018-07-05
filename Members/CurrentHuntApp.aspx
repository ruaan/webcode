<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CurrentHuntApp.aspx.vb" Inherits="Members_CurrentHuntApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" type="text/css" href="~/StyleSheets/StyleSheet2.css" />
    <style>
        body {
            background-color: #373e2e;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="h1" style="background-color: #E5E3E5">My Hunt<asp:Label ID="Label1" runat="server" Text="Label" ForeColor="#E5E3E5"></asp:Label></div>
        <div align="center">
            <div>&nbsp;</div>
            <div>

                <asp:HiddenField ID="HiddenFieldFarmId" runat="server" />
                <asp:HiddenField ID="HiddenFieldHuntId" runat="server" />

            </div>
            <div>
                <div style="padding: 5px; display: inline-block">
                    <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Buttons/tracking.jpg" /></div>

                <div style="padding: 5px; display: inline-block">
                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Buttons/pinpoint.jpg" />
                </div>

            </div>
            <div>
                <a href='../../Farms/AddReview.aspx?farmid=&txtFarmId.Value &  '>
                    <div style="padding: 5px; display: inline-block">
                        <img alt="" src="../Images/Buttons/review.jpg" /></div>
                </a>
                <div style="padding: 5px; display: inline-block">
                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/Buttons/photo.jpg" />
                </div>
            </div>
            <div>
                <a href='../../ER24.aspx'>
                    <div style="padding: 5px; display: inline-block">
                        <img alt="" src="../Images/Buttons/emergency.jpg" /></div>
                </a>
                <a href='Hunts_Animals_Shot.aspx'>
                    <div style="padding: 5px; display: inline-block">

                        <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Buttons/animals-hunted.jpg" />
                    </div>
                </a>

            </div>

        </div>
    </form>
    <script>
        function callPinPointActivity() {
            Android.openPinpoint();
        }
        function callTrackingActivity() {
            Android.openTracking();
        }
        function callHuntPhotoActivity() {
            Android.openHuntPhoto();
        }
    </script>
</body>
</html>
