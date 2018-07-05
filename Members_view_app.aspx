<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Members_view_app.aspx.vb" Inherits="Members_view_app" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheets/lightbox.css" rel="stylesheet" />
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

        .rateStar {
            width: 28px;
            height: 28px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="border: 1px solid #333333; padding: 10px 10px 12px 10px; background-color: #E2E2E2; font-size: x-large; display: inline-block; width: 98%">
                <div style="display: inline-block;">
                    <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
            </div>
            <div>&nbsp;</div>
            <div id="ind_Pic_block" style="border: 1px solid #333333; padding: 5px; background-color: #FFFFFF;">
                <div style="display: inline-block;">
                    <asp:Image ID="Image1" runat="server" Height="176px" Width="176px" />
                </div>
                <div>
                    <div style="padding-right: 0px; padding-bottom: 5px; padding-left: 5px;">
                        <div style="padding: 5px">
                            <asp:Label ID="lblCellNo" runat="server"></asp:Label></div>
                        <div style="padding: 5px"></div>

                        <div>&nbsp;</div>
                    </div>
                </div>
            </div>
        </div>
        <div style="border: 1px solid #8D9296">







            <div id="divPricingDetail" style="display: none; background-color: #FFFFFF;">
            </div>

            <div style="padding: 5px; border-width: thin; border-color: #86B250; background-color: #5B6849; color: #FFFFFF; font-size: large; font-family: Calibri; border-bottom-style: solid;" id="divAnimalsHdr" onclick="ToggleDetails('divAnimalsDetail','imgLocationDown3','imgLocationUp3')">
                <div style="display: inline-block" class="auto-style8">Rating & Reviews</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgLocationUp3" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                    <img id="imgLocationDown3" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
                </div>

            </div>
            <div id="divAnimalsDetail" style="background-color: #FFFFFF; width: 100%">
                <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
            </div>

            <%-- <div style="padding: 5px; border-width: thin; border-color: #86B250; background-color:  #5B6849; color: #FFFFFF; font-size: large; font-family: Calibri; border-bottom-style: solid;" id="divGalleryHdr" class="auto-style2" onclick="ToggleDetails('divGalleryDetail','imgLocationDown4','imgLocationUp4')">
                        <div style="display: inline-block" class="auto-style8">Chats</div>
                        <div style="display: inline-block; float: right;">
                    <img id="imgLocationUp4" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                    <img id="imgLocationDown4" alt="" src="Images/Icons/numDown.png"  class="arrow_icon"  />
                </div>--%>
        </div>
        <div id="divGalleryDetail" style="display: none; background-color: #FFFFFF;">
            <asp:PlaceHolder ID="PlaceHolder5" runat="server"></asp:PlaceHolder>
        </div>

        <div style="padding: 5px; border-width: thin; border-color: #86B250; background-color: #5B6849; color: #FFFFFF; font-size: large; font-family: Calibri; border-bottom-style: solid;" id="divReviewsHdr" class="auto-style2" onclick="ToggleDetails('divReviewsDetail','imgLocationDown5','imgLocationUp5')">
            <div style="display: inline-block" class="auto-style8">Albums</div>
            <div style="display: inline-block; float: right;">
                <img id="imgLocationUp5" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                <img id="imgLocationDown5" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
            </div>

        </div>
        <div id="divReviewsDetail" style="display: none; background-color: #FFFFFF; width: 100%;">
            <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
        </div>
        <div>&nbsp;</div>
        <div>
            <asp:ImageButton ID="imgBtnBack" runat="server" ImageUrl="~/Images/Icons/backtolist.png" />
        </div>

        <%--</div>--%>
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
    </script>
</body>
</html>
