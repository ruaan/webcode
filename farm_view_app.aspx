<%@ Page Language="VB" AutoEventWireup="false" CodeFile="farm_view_app.aspx.vb" Inherits="farm_view_app" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <link href="StyleSheets/lightbox.css" rel="stylesheet" />
    <link rel="stylesheet" href="../StyleSheets/StyleSheetApp.css" type="text/css" />
    <style type="text/css">
        body {
            background-color: #424531;
        }

        .style-profile {
            width: 276px;
            height: 276px;
        }

        .divFilter {
            border: 1px solid #8d9296;
            padding: 4px;
            font-size: medium;
            background-color: #424531;
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            font-family: Calibri;
            color: white;
        }

        .header_icon {
            width: 32px;
            height: 32px;
            vertical-align: middle;
        }

        .auto-style12 {
            height: 75px;
        }

        .Animal_Pic {
            height: 124px;
            width: 124px;
        }

        .headerStyle {
            color: white;
            font-size: 14px;
            font-family: Calibri;
        }

        .filterline {
            padding: 5px;
            border-width: thin;
            border-color: #99b37a;
            border-bottom-style: solid;
            display: inline-block;
            width: 100%;
            cursor: pointer;
            background-color: #5B6849;
            vertical-align: middle;
            font-size: medium;
            padding-top: 10px;
            padding-bottom: 10px;
            padding-left: 5px;
            padding-right: 5px;
            color: white;
            font-size: 14px;
            font-family: Calibri;
        }

        .ratestar {
            width: 24px;
            height: 24px;
        }

        .auto-style13 {
            height: 199px;
        }
    </style>
</head>
<body style="margin: 0">
    <form id="form1" runat="server" style="margin: 0">
        <div>
            <table style="width: 100%; background-color: #394025;">
                <tr>
                    <td style="background-color: #373E2E">
                        <asp:Label ID="lblHeading" runat="server" Font-Names="Calibri" Font-Size="Large" ForeColor="White" Text="RUST EN VREDE FARM"></asp:Label>
                        <asp:HiddenField ID="HiddenFarmId" runat="server" />
                    </td>
                </tr>
                <tr>
                    <td style="background-color: #D7D7D7">
                        <div id="ind_Pic_block" style="border: 1px solid #333333; padding: 5px; width: 100%;">
                            <div style="display: inline-block; width: 68%;">
                                <asp:Image ID="Image1" runat="server" Height="236px" ImageUrl="~/Farms/Images/FarmProfiles/1Main.jpg" Width="100%" />
                            </div>
                            <div style="display: inline-block; width: 28%;">
                                <div class="auto-style12" style="padding-right: 0px; padding-bottom: 5px; padding-left: 5px">
                                    <asp:Image ID="Image2" runat="server" Height="100%" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_22.gif" Width="100%" />
                                </div>
                                <div class="auto-style12" style="padding-right: 0px; padding-bottom: 5px; padding-left: 5px">
                                    <asp:Image ID="Image3" runat="server" Height="100%" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_23.gif" Width="100%" />
                                </div>
                                <div class="auto-style12" style="padding-right: 0px; padding-bottom: 0px; padding-left: 5px">
                                    <asp:Image ID="Image4" runat="server" Height="100%" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_22.gif" Width="100%" />
                                </div>
                            </div>
                        </div>
                    </td>
                </tr>

                <tr>
                    <td>
                        <table style="width: 100%; background-color: #D7D7D7;">
                            <tr>
                                <td>
                                    <div style="text-align: right; display: inline-block; padding-top: 5px; padding-left: 5px;">

                                        <div style="display: inline-block;">

                                            <asp:Image ID="Image10" runat="server" ImageUrl="Images/Icons/favorites-select-app.png" class="ratestar" Visible="False" />
                                            <asp:Image ID="Image11" runat="server" ImageUrl="Images/Icons/favorites-select-app.png" class="ratestar" Visible="False" />
                                            <asp:Image ID="Image12" runat="server" ImageUrl="Images/Icons/favorites-select-app.png" class="ratestar" Visible="False" />
                                            <asp:Image ID="Image13" runat="server" ImageUrl="Images/Icons/favorites-select-app.png" class="ratestar" Visible="False" />
                                            <asp:Image ID="Image14" runat="server" ImageUrl="Images/Icons/favorites-select-app.png" class="ratestar" Visible="False" />

                                        </div>
                                        <div style="display: inline-block; color: #CC0000;">
                                            <asp:Label ID="lblRating" runat="server" Text="Label"></asp:Label>
                                        </div>
                                    </div>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/Farm_Search/reserve.png" />
                                </td>
                                <td>
                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Icons/Farm_Search/reviews.png" />
                                </td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <div id="divLocationHdr1" class="filterline" onclick="ToggleDetails('divGenDetail','imgLocationDown','imgLocationUp')">
                            <div style="display: inline-block" class="headerStyle">General Information</div>
                            <div style="display: inline-block; float: right;">
                                <img id="imgLocationUp" alt="" src="Images/Icons/numUp.png" class="arrow_icon" />
                                <img id="imgLocationDown" alt="" src="Images/Icons/numDown.png" style="display: none" class="arrow_icon" />
                            </div>

                        </div>
                        <div id="divGenDetail" style="background-color: #D7D7D7; width: 100%;">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </div>




                        <div id="divPricingHdr" class="filterline" onclick="ToggleDetails('divPricingDetail','imgLocationDown2','imgLocationUp2')">
                            <div style="display: inline-block" class="auto-style8">Pricing and Packages</div>
                            <div style="display: inline-block; float: right;">
                                <img id="imgLocationUp2" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                                <img id="imgLocationDown2" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
                            </div>

                        </div>
                        <div id="divPricingDetail" style="display: none; background-color: #D7D7D7; width: 100%; font-family: Calibri;">

                            <div style="padding-left: 10px">
                                <div>

                                    <div style="padding: 6px 10px 2px 10px;">
                                        <div style="padding: 5px 5px 5px 5px; font-size: 14px;">
                                            Hunter Daily Rate: &nbsp;<asp:Label ID="lblHuntRate" runat="server" Text=""></asp:Label>
                                        </div>

                                    </div>

                                    <div style="padding: 2px 10px 10px 10px;">
                                        <div style="padding: 5px; font-size: 14px;">Guests Daily Rate: &nbsp; &nbsp;<asp:Label ID="lblGuestRate" runat="server" Text=""></asp:Label></div>

                                    </div>

                                </div>
                            </div>
                        </div>

                        <div id="divAnimalsHdr" class="filterline" onclick="ToggleDetails('divAnimalsDetail','imgLocationDown3','imgLocationUp3')">
                            <div style="display: inline-block" class="auto-style8">Animals</div>
                            <div style="display: inline-block; float: right;">
                                <img id="imgLocationUp3" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                                <img id="imgLocationDown3" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
                            </div>

                        </div>
                        <div id="divAnimalsDetail" style="display: none; background-color: #D7D7D7; width: 100%;">
                            <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
                        </div>

                        <div id="divGalleryHdr" class="filterline" onclick="ToggleDetails('divGalleryDetail','imgLocationDown4','imgLocationUp4')">
                            <div style="display: inline-block" class="auto-style8">Gallery</div>
                            <div style="display: inline-block; float: right;">
                                <img id="imgLocationUp4" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                                <img id="imgLocationDown4" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
                            </div>

                        </div>
                        <div id="divGalleryDetail" style="display: none; background-color: #D7D7D7; width: 100%;">
                            <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
                        </div>

                        <div id="divReviewsHdr" class="filterline" onclick="ToggleDetails('divReviewsDetail','imgLocationDown5','imgLocationUp5')">
                            <div style="display: inline-block" class="auto-style8">Reviews</div>
                            <div style="display: inline-block; float: right;">
                                <img id="imgLocationUp5" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                                <img id="imgLocationDown5" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
                            </div>

                        </div>
                        <div id="divReviewsDetail" style="display: none; background-color: #D7D7D7; width: 98%;">
                            <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                        </div>

                        <div class="filterline" id="divMapHdr" onclick="ToggleDetails('divMapDetail','imgMapDown','imgMapUp')">
                            <div style="display: inline-block" class="auto-style8">Map</div>
                            <div style="display: inline-block; float: right;">
                                <img id="imgMapUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                                <img id="imgMapDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
                            </div>

                        </div>
                        <div id="divMapDetail" style="display: none; background-color: #D7D7D7; width: 100%;">

                            <div id="divMap" runat="server">
                                <div id="map" style="border: 1px solid #333333" class="auto-style13">
                                    MAP
                                </div>
                            </div>
                            <asp:HiddenField ID="HiddenLatitude" runat="server" Value="" />
                            <asp:HiddenField ID="HiddenLongitude" runat="server" Value="" />
                        </div>
                        <div class="filterline" id="divTermHdr" onclick="ToggleDetails('divTermsDetail','imgLocationDown1','imgLocationUp1')">
                            <div style="display: inline-block" class="auto-style8">Terms</div>
                            <div style="display: inline-block; float: right;">
                                <img id="imgLocationUp1" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                                <img id="imgLocationDown1" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
                            </div>

                        </div>
                        <div id="divTermsDetail" style="display: none; background-color: #D7D7D7; width: 100%;">
                            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:ImageButton ID="btnFarmDescription" runat="server" ImageUrl="~/Images/Icons/backtolist.png" />
                    </td>
                </tr>
            </table>
        </div>
    </form>
    <script src="Scripts/lightbox-plus-jquery.js"></script>
    <script>
        function ToggleDetails(pnlDiv, imgDown, imgUp) {

            var Colordiv = document.getElementById(pnlDiv);
            var CustImgDown = document.getElementById(imgDown);
            var CustImgUp = document.getElementById(imgUp);

            if (Colordiv.style.display == 'none') {
                Colordiv.style.display = 'inline-block';
                CustImgDown.style.display = 'none';
                CustImgUp.style.display = 'inline-block';
                sessionStorage.setItem(pnlDiv, 'inline-block');
            } else {
                Colordiv.style.display = 'none';
                CustImgDown.style.display = 'inline-block';
                CustImgUp.style.display = 'none';
                sessionStorage.setItem(pnlDiv, 'none');
            }

        }
    </script>
    <script>
        function toggle_visibility(id, counter) {
            for (i = 0; i < counter + 1; i++) {
                try {
                    var e = document.getElementById(id + i);
                    if (e.style.display == 'block')
                        e.style.display = 'none';
                    else
                        e.style.display = 'block';
                } catch (err) {

                }

            }


        }

        var marker;
        var messagewindow;

        var map, infoWindow, saveWindow;
        var thisLat, thisLong;
        thisLat = document.getElementById('<%=HiddenLatitude.ClientID %>').value;
        thisLong = document.getElementById('<%=HiddenLongitude.ClientID %>').value;
        thisLat = +thisLat;
        thisLong = +thisLong;
        function initMap() {

            var uluru = { lat: thisLat, lng: thisLong };
            map = new google.maps.Map(document.getElementById('map'), {
                center: uluru,
                zoom: 8,
                mapTypeId: 'terrain'
            });






            var marker = new google.maps.Marker({
                position: uluru,
                map: map,
                title: "here"
            });

        }


    </script>
    <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAxqfU7c2bizBIU4YMpVEe8qcwd7tRQRHs&callback=initMap">
    </script>
</body>
</html>
