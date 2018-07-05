<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Outfitters_View_App.aspx.vb" Inherits="Outfitters_View_App" %>

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

        .headers {
            font-size: 14px;
        }

        .spacer {
            height: 8px;
        }

        .divMngForm {
            display: inline-block;
        }

        .auto-style2 {
            border-top: 2px solid white;
            border-bottom: 2px solid white;
            padding: 5px;
            display: inline-block;
            width: 100%;
            cursor: pointer;
            background-color: #e2e2e2;
            vertical-align: middle;
            font-size: medium;
            border-left-color: white;
            border-left-width: 2px;
            border-right-color: white;
            border-right-width: 2px;
        }

        .auto-style3 {
            border-top: 2px solid white;
            border-bottom: 2px solid white;
            padding: 5px;
            display: inline-block;
            width: 95%;
            cursor: pointer;
            background-color: #e2e2e2;
            vertical-align: middle;
            font-size: medium;
            border-left-color: white;
            border-left-width: 2px;
            border-right-color: white;
            border-right-width: 2px;
        }


        .auto-style8 {
            width: 90%;
        }

        .auto-style5 {
            width: 90%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
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
                                    <div style="text-align: right; display: inline-block;">

                                        <div style="display: inline-block;">

                                            <asp:Image ID="Image10" runat="server" ImageUrl="Images/Icons/star.png" class="rateStar" Visible="False" />
                                            <asp:Image ID="Image11" runat="server" ImageUrl="Images/Icons/star.png" class="rateStar" Visible="False" />
                                            <asp:Image ID="Image12" runat="server" ImageUrl="Images/Icons/star.png" class="rateStar" Visible="False" />
                                            <asp:Image ID="Image13" runat="server" ImageUrl="Images/Icons/star.png" class="rateStar" Visible="False" />
                                            <asp:Image ID="Image14" runat="server" ImageUrl="Images/Icons/star.png" class="rateStar" Visible="False" />

                                        </div>
                                        <div style="display: inline-block; color: #CC0000;">
                                            <asp:Label ID="lblRating" runat="server"></asp:Label></div>
                                    </div>
                                </td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
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
                        <div style="padding: 5px; border-width: thin; border-color: #86B250; background-color: #5B6849; color: #FFFFFF; font-size: large; font-family: Calibri; border-bottom-style: solid;" id="divLocationHdr1" class="auto-style2" onclick="ToggleDetails('divGenDetail','imgLocationDown','imgLocationUp')">
                            <div style="display: inline-block" class="auto-style8">General Information</div>
                            <div style="display: inline-block; float: right;">
                                <img id="imgLocationUp" alt="" src="Images/Icons/numUp.png" class="arrow_icon" />
                                <img id="imgLocationDown" alt="" src="Images/Icons/numDown.png" style="display: none" class="arrow_icon" />
                            </div>

                        </div>
                        <div id="divGenDetail" style="background-color: #D7D7D7; width: 98%;">
                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                        </div>
                        <div style="padding: 5px; border-width: thin; border-color: #86B250; background-color: #5B6849; color: #FFFFFF; font-size: large; font-family: Calibri; border-bottom-style: solid;" id="divGalleryHdr" class="auto-style2" onclick="ToggleDetails('divGalleryDetail','imgLocationDown4','imgLocationUp4','Terms')">
                            <div style="display: inline-block" class="auto-style8">Lodges</div>
                            <div style="display: inline-block; float: right;">
                                <img id="imgLocationUp4" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                                <img id="imgLocationDown4" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
                            </div>

                        </div>
                        <div id="divGalleryDetail" style="display: none; background-color: #D7D7D7; width: 98%;">
                            <asp:PlaceHolder ID="PlaceHolderLodges" runat="server"></asp:PlaceHolder>
                        </div>

                        <div style="padding: 5px; border-width: thin; border-color: #86B250; background-color: #5B6849; color: #FFFFFF; font-size: large; font-family: Calibri; border-bottom-style: solid;" id="divReviewsHdr" class="auto-style2" onclick="ToggleDetails('divReviewsDetail','imgLocationDown5','imgLocationUp5')">
                            <div style="display: inline-block" class="auto-style8">Reviews</div>
                            <div style="display: inline-block; float: right;">
                                <img id="imgLocationUp5" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                                <img id="imgLocationDown5" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
                            </div>

                        </div>
                        <div id="divReviewsDetail" style="display: none; background-color: #D7D7D7; width: 98%;">
                            <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
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
        <asp:HiddenField ID="HiddenType" runat="server" />
        <asp:HiddenField ID="HiddenType1" runat="server" />
        <asp:HiddenField ID="HiddenType2" runat="server" />
        <asp:HiddenField ID="HiddenType3" runat="server" />
        <asp:HiddenField ID="HiddenField1" runat="server" />
        <asp:HiddenField ID="HiddenLodgeId" runat="server" />
        <asp:Button ID="btnTabClick" runat="server" BackColor="Transparent" BorderStyle="None" Style="height: 22px" />
        <div>&nbsp;<asp:Button ID="btnTabClick1" runat="server" BackColor="Transparent" BorderStyle="None" /></div>
        <div>&nbsp;<asp:Button ID="btnTabClick2" runat="server" BackColor="Transparent" BorderStyle="None" /></div>
    </form>
    <script src="Scripts/lightbox-plus-jquery.js"></script>
    <script>
        function ToggleDetails(pnlDiv, imgDown, imgUp, Type) {
            var hiddenType = document.getElementById('<%= HiddenType.ClientID %>');

            var Colordiv = document.getElementById(pnlDiv);
            var CustImgDown = document.getElementById(imgDown);
            var CustImgUp = document.getElementById(imgUp);

            if (Colordiv.style.display == 'none') {
                Colordiv.style.display = 'inline-block';
                CustImgDown.style.display = 'none';
                CustImgUp.style.display = 'inline-block';
                sessionStorage.setItem(pnlDiv, 'inline-block');
                hiddenType.value = Type;

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
        function ToggleDetails1(Type) {

            var hiddenType1 = document.getElementById('<%= HiddenType1.ClientID %>');
             hiddenType1.value = Type;

             var btnType = document.getElementById('<%= btnTabClick1.ClientID %>');
             btnType.click();
         }
         function ToggleDetails2(LodgeName, Type) {
             var hiddenType2 = document.getElementById('<%= HiddenType2.ClientID %>');
             hiddenType2.value = LodgeName;
             var hiddenType3;
             if (document.getElementById('<%= HiddenType3.ClientID %>').value == '') {
                 hiddenType3 = document.getElementById('<%= HiddenType3.ClientID %>');
                 hiddenType3.value = Type;
             } else {
                 Type = '';
                 hiddenType3 = document.getElementById('<%= HiddenType3.ClientID %>');
                 hiddenType3.value = Type;
             }

             var btnType = document.getElementById('<%= btnTabClick2.ClientID %>');
             btnType.click();
         }
    </script>
</body>
</html>
