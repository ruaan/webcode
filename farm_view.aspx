<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="farm_view.aspx.vb" Inherits="farm_view" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="StyleSheets/lightbox.css" rel="stylesheet" />
    <style type="text/css">
        #mainPageWrapper {
            text-align: center;
            font-family: Calibri;
        }

        .div_MainBlock {
            margin: 0 auto;
        }

        .div_details {
            display: inline-block;
            vertical-align: top;
            width: 800px;
            text-align: left;
            padding-left: 5px;
            padding-right: 5px;
        }

        .div_side_block {
            display: inline-block;
            vertical-align: top;
            width: 400px;
            text-align: left;
            padding-left: 5px;
            padding-right: 5px;
        }

        .auto-style3 {
            height: 464px;
        }

        .flight-textbox-style {
            width: 300px;
            height: 30px;
            border-style: none;
            background-color: #5B8EC5;
            color: #FFFFFF;
            font-size: large;
        }

        .auto-style4 {
            width: 83px;
            height: 90px;
        }

        .auto-style5 {
            width: 15px;
        }

        .auto-style6 {
            width: 134px;
            height: 90px;
        }

        .auto-style9 {
            width: 332px;
            height: 53px;
        }

        .tab_Left {
            -moz-border-radius: 10px 0px 0px 0px;
            border-radius: 10px 0px 0px 0px;
            display: inline-block;
            padding-top: 15px;
            background-color: #CCCCCC;
            border: 1px solid #CCCCCC;
            text-align: center;
            height: 29px;
            width: 143px;
        }

            .tab_Left:hover {
                background-color: #86B24F;
            }

        .tab_normal {
            display: inline-block;
            padding-top: 15px;
            background-color: #CCCCCC;
            border: 1px solid #CCCCCC;
            text-align: center;
            height: 29px;
            width: 143px;
        }

        .tab_selected {
            display: inline-block;
            padding-top: 15px;
            border: 1px solid #CCCCCC;
            text-align: center;
            height: 29px;
            width: 143px;
        }

            .tab_selected:focus {
                background-color: red;
            }


            .tab_selected:active {
                background-color: yellow;
            }

        .tab_normal:hover {
            background-color: #86B24F;
        }

        .tab_Right {
            -moz-border-radius: 0px 10px 0px 0px;
            border-radius: 0px 10px 0px 0px;
            border: 1px solid #CCCCCC;
            display: inline-block;
            padding-top: 15px;
            background-color: #CCCCCC;
            text-align: center;
            height: 29px;
            width: 143px;
        }

            .tab_Right:hover {
                background-color: #86B24F;
            }

        .div_infoBlock {
            -moz-border-radius: 0px 10px 0px 0px;
            border-radius: 0px 10px 0px 0px;
            /*height: 1177px;*/
            border-style: solid;
            border-width: 1px;
            border-color: #CCCCCC;
            padding-left: 10px;
        }

        .auto-style12 {
            width: 180px;
            height: 180px;
        }

        .side-Heading {
            width: 157px;
            display: inline-block;
            font-size: large;
            color: #333333;
            padding-right: 20px;
            vertical-align: top;
        }

        .Animal_Pic {
            height: 124px;
            width: 124px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>&nbsp;</div>
    <div id="mainPageWrapper">
        <div id="mainBlock" class="div_MainBlock">
            <div class="div_details">
                <div style="border: 1px solid #333333; padding: 10px 10px 12px 10px; background-color: #E2E2E2; font-size: x-large; display: inline-block; width: 780px">
                    <div style="display: inline-block; width: 540px;">
                        <asp:Label ID="lblHeading" runat="server"></asp:Label>
                    </div>
                    <div style="text-align: right; display: inline-block;">

                        <div style="display: inline-block;">

                            <asp:Image ID="Image5" runat="server" ImageUrl="Images/Icons/favorite-select.png" class="rateStar" Visible="False" />
                            <asp:Image ID="Image6" runat="server" ImageUrl="Images/Icons/favorite-select.png" class="rateStar" Visible="False" />
                            <asp:Image ID="Image7" runat="server" ImageUrl="Images/Icons/favorite-select.png" class="rateStar" Visible="False" />
                            <asp:Image ID="Image8" runat="server" ImageUrl="Images/Icons/favorite-select.png" class="rateStar" Visible="False" />
                            <asp:Image ID="Image9" runat="server" ImageUrl="Images/Icons/favorite-select.png" class="rateStar" Visible="False" />

                        </div>
                        <div style="display: inline-block; color: #CC0000;">
                            <asp:Label ID="lblRating" runat="server" Text="Label"></asp:Label></div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div id="ind_Pic_block" style="border: 1px solid #333333; padding: 5px;">

                    <div style="display: inline-block;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Farms/Images/FarmProfiles/1ProfilePic.jpg" Height="553px" Width="553px" />
                    </div>
                    <div style="display: inline-block;">
                        <div style="padding-right: 0px; padding-bottom: 5px; padding-left: 5px" class="auto-style12">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_22.gif" Height="100%" Width="100%" />
                        </div>
                        <div style="padding-right: 0px; padding-bottom: 5px; padding-left: 5px" class="auto-style12">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_23.gif" Height="100%" Width="100%" />
                        </div>
                        <div style="padding-right: 0px; padding-bottom: 0px; padding-left: 5px" class="auto-style12">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_22.gif" Height="100%" Width="100%" />
                        </div>
                    </div>

                </div>
                <div>&nbsp;</div>
                <div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
                <asp:HiddenField ID="HiddenType" runat="server" />
                <asp:HiddenField ID="HiddenFarmId" runat="server" />
                <div>&nbsp;</div>
                <%-- <div id="divInfo">
                    
                     <div id="divTabs">
                        <div id="divTab_GenInfo" class="tab_Left" onclick="ToggleDetails('GetGeninfo')" style="cursor: pointer" >General Information</div>
                         <div style="display:inline-block;" class="auto-style11">&nbsp;</div>
                        <div id="divTab_Terms" class="tab_selected" onclick="ToggleDetails('Terms')" style="cursor: pointer">Terms</div>
                         <div style="display:inline-block;" class="auto-style11">&nbsp;</div>
                        <div id="divTab_Animals" class="tab_normal" onclick="ToggleDetails('Animals')" style="cursor: pointer" runat="server">Animals</div>
                         <div style="display:inline-block;" class="auto-style11">&nbsp;</div>
                        <div id="divTab_General Amenities" class="tab_normal" onclick="ToggleDetails('Gallery')" style="cursor: pointer">Gallery</div>
                         <div style="display:inline-block;" class="auto-style11">&nbsp;</div>
                        <div id="divTab_Reviews" class="tab_Right" onclick="ToggleDetails('Reviews')" style="cursor: pointer">Reviews</div>
                    </div>
                    <div id="infoBlock"  class="div_infoBlock">
                         <div id="div_info_Terms">
                        <div>&nbsp;</div>
                            
                    </div>
                    </div>
                   
                </div>--%>
            </div>
            <div class="div_side_block">
                <div id="divMap" class="auto-style3" runat="server">
                    <div id="map" class="auto-style3" style="border: 1px solid #333333">
                        MAP
                    </div>
                </div>
                <asp:HiddenField ID="HiddenLatitude" runat="server" Value="" />
                <asp:HiddenField ID="HiddenLongitude" runat="server" Value="" />
                <div>&nbsp;</div>
                <div id="planyourhunt" style="border: 1px solid #333333; padding-right: 5px; padding-left: 5px; padding-bottom: 5px; background-color: #F8F8F8;">
                    <div style="text-align: center; font-size: x-large; padding-top: 15px; padding-bottom: 15px;">
                        Plan Your Hunt
                    </div>
                    <div>&nbsp;</div>
                    <div style="padding: 10px; background-color: #CCCCCC">
                        <div style="display: inline-block;">
                            <div style="padding-bottom: 5px; font-weight: bold;">Arrival</div>
                            <div>
                                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" BehaviorID="txtDateFrom_CalendarExtender" TargetControlID="txtDateFrom" OnClientDateSelectionChanged="countdays" />

                            </div>
                            <div>&nbsp;</div>
                        </div>

                        <div style="display: inline-block;">

                            <div>&nbsp;</div>
                        </div>

                        <div style="display: inline-block;">
                            <div style="padding-bottom: 5px; font-weight: bold;">Departure</div>
                            <div>
                                <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                                <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" BehaviorID="txtDateTo_CalendarExtender" TargetControlID="txtDateTo" OnClientDateSelectionChanged="countdays" />

                            </div>
                            <div>&nbsp;</div>
                        </div>
                    </div>
                    <div style="vertical-align: middle; padding-left: 10px; padding-top: 20px; padding-bottom: 20px">
                        Number of days selected &nbsp;<asp:TextBox ID="txtDaysCount" runat="server" Height="28px" Width="59px"></asp:TextBox>
                    </div>
                    <div style="padding: 10px; background-color: #CCCCCC">
                        <div style="font-weight: bold">Accommodation</div>
                        <div>&nbsp;</div>
                        <div style="display: inline-block;">
                            <div style="padding-bottom: 5px; font-weight: bold;">Hunters</div>
                            <div>
                                <asp:TextBox ID="txtHunterPax" runat="server" Height="28px" onkeyup="javascript:CalcAccom();"></asp:TextBox>
                            </div>
                            <div>Daily Rate
                                <asp:Label ID="lblHunterPrice" runat="server" Font-Bold="True"></asp:Label></div>
                        </div>

                        <div style="display: inline-block;">

                            <div>&nbsp;</div>
                        </div>

                        <div style="display: inline-block;">
                            <div style="padding-bottom: 5px; font-weight: bold;">Guests</div>
                            <div>
                                <asp:TextBox ID="txtGuestPax" runat="server" Height="28px" onkeyup="javascript:CalcAccom();"></asp:TextBox>
                            </div>
                            <div>Daily Rate
                                <asp:Label ID="lblGuestPrice" runat="server" Font-Bold="True"></asp:Label></div>
                        </div>
                        <div>
                            &nbsp;<asp:HiddenField ID="HiddenFieldHunterPrice" runat="server" />
                            <asp:HiddenField ID="HiddenFieldGuestPrice" runat="server" />
                        </div>

                    </div>
                    <%--  <div style="vertical-align:middle; padding-left: 10px; padding-top: 20px; padding-bottom: 20px;">
                        Additional Options
                    </div>
                    <div style="background-color: #CCCCCC; padding-left: 10px; padding-top: 10px">
                        <div>Airport Transfer &nbsp; <asp:CheckBox ID="CheckBox1" runat="server" TextAlign="Left" Text="@ R950.00 (return)" /></div>
                        <div>&nbsp;</div>
                        <div><strong>Trackers</strong> (Trip Duration) &nbsp; <asp:TextBox ID="TextBox6" runat="server" Height="28px" Width="61px"></asp:TextBox></div>
                        <div>&nbsp;</div>
                        <div><strong>Additional Vehicle</strong> &nbsp;<asp:TextBox ID="TextBox7" runat="server" Height="28px" Width="61px"></asp:TextBox></div>
                        <div>&nbsp;</div>
                    </div>--%>
                    <div style="padding: 10px; background-color: #E2E2E2;">
                        <div style="font-weight: bold; text-align: right;">
                            Accommodation Cost:
                            <asp:Label ID="lblAccomTotal" runat="server" Text="0" ForeColor="#CC0000"></asp:Label>
                            <asp:HiddenField ID="HiddenFieldAccomTotal" runat="server" Value="0" />
                        </div>
                        <div>&nbsp;</div>
                        <div style="font-weight: bold; text-align: right;">
                            Additional Cost:
                            <asp:Label ID="lblAdditionalTotal" runat="server" Text="0" ForeColor="#CC0000"></asp:Label>
                            <asp:HiddenField ID="HiddenFieldAdditionalTotal" runat="server" Value="0" />
                        </div>
                        <div>&nbsp;</div>
                        <div style="font-weight: bold; text-align: right;">Total Cost:
                            <asp:Label ID="lblTotal" runat="server" Text="0" ForeColor="#CC0000"></asp:Label></div>
                    </div>
                    <div>&nbsp;</div>
                    <%--   <div style="padding: 10px; background-color: #454346">
                        <div style="text-align:center; font-size:x-large; padding-top: 15px; padding-bottom: 15px; color: #CCCCCC;">Book Your Flights</div>
                        <div>&nbsp</div>
                        <div>
                            <div style="display:inline-block">
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/btnflights.jpg" />

                            </div>
                            <div style="display:inline-block">
                                &nbsp;
                            </div>
                            <div style="display:inline-block">
                                <asp:ImageButton ID="ImageButton3" runat="server" ImageUrl="~/Images/Icons/btnCarhire.jpg" />

                            </div>
                            <div>
                                &nbsp;
                            </div>
                            <div style="padding-bottom: 5px">
                                 <input id="cityFrom" type="text" class="flight-textbox-style" />
                                    <div id="log" class="flight-textbox-style" ></div>
                            </div>
                            <div style="padding-bottom: 5px">
                                  <input id="cityTo" type="text" class="flight-textbox-style" />
                                    <div id="log2" class="flight-textbox-style" ></div>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <div style="display:inline-block; background-color: #EBECEE; text-align:center" class="auto-style4">
                                    <div>Depart</div>
                                    <div>December</div>
                                    <div style="color: #37C4D6; font-weight: bold; font-size: x-large">
                                        <asp:Label ID="Label5" runat="server" Text="15"></asp:Label>
                                                                            </div>
                                     <div style="padding-bottom: 5px">Friday</div>
                                </div>
                                 <div style="display:inline-block" class="auto-style5">
                                     &nbsp;
                                </div>
                                <div style="display:inline-block; background-color: #EBECEE; text-align:center" class="auto-style4">
                                    <div>Return</div>
                                    <div>December</div>
                                    <div style="color: #37C4D6; font-weight: bold; font-size: x-large">
                                        <asp:Label ID="Label6" runat="server" Text="20"></asp:Label>
                                                                            </div>
                                     <div style="padding-bottom: 5px">Monday</div>
                                </div>
                                <div style="display:inline-block" class="auto-style5">
                                     &nbsp;
                                </div>
                                <div style="display:inline-block; background-color: #EBECEE; text-align:center; vertical-align:top;" class="auto-style6">
                                   <div style="display:inline-block;">
                                       <img alt="" src="Images/Icons/flights_11.jpg" /></div>
                                    <div style="display:inline-block;"> <asp:DropDownList ID="DropDownList5" runat="server"  BackColor="White" Font-Size="X-Large">
                                                <asp:ListItem>1</asp:ListItem>
                                                <asp:ListItem>2</asp:ListItem>
                                                <asp:ListItem>3</asp:ListItem>
                                                <asp:ListItem>4</asp:ListItem>
                                                <asp:ListItem>5</asp:ListItem>
                                                <asp:ListItem>6</asp:ListItem>
                                                <asp:ListItem>7</asp:ListItem>
                                                <asp:ListItem>8</asp:ListItem>
                                            </asp:DropDownList></div>
                                    <div style="padding: 12px 0px 10px 0px" >
                                          <asp:DropDownList ID="DropDownList6" runat="server" BackColor="White" Font-Names="Calibri" >
                                                                <asp:ListItem>Economy</asp:ListItem>
                                                                <asp:ListItem>Premium Economy</asp:ListItem>
                                                                <asp:ListItem>Business</asp:ListItem>
                                                                <asp:ListItem>First</asp:ListItem>
                                                            </asp:DropDownList>

                                    </div>
                                </div>

                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <input id="Button12" type="button" value="Search for Available Flights" style="background-color: #454346; color: #CCCCCC; border: 1px solid #CCCCCC; font-size: large;" class="auto-style9" />
                            </div>
                        </div>
                        <div>&nbsp;</div>
                    </div>--%>
                </div>
                <div style="padding: 10px; background-color: #E2E2E2;">
                    <div style="font-weight: bold; text-align: center;">
                        <asp:Button ID="btnReserve" runat="server" Text="Reserve" Style="background-color: #454346; color: #CCCCCC; border: 1px solid #CCCCCC; font-size: large; cursor: pointer;" class="auto-style9" />
                    </div>
                    <div style="font-weight: bold; text-align: center;">
                        <asp:Label ID="lblValidate" runat="server"></asp:Label>
                    </div>
                </div>
            </div>



        </div>
    </div>
    <div>&nbsp;<asp:Button ID="btnTabClick" runat="server" BackColor="White" BorderStyle="None" /></div>
    <script src="Scripts/lightbox-plus-jquery.js"></script>
    <script type="text/javascript">




        function ToggleDetails(Type) {

            var hiddenType = document.getElementById('<%= HiddenType.ClientID %>');
            hiddenType.value = Type;

            var btnType = document.getElementById('<%= btnTabClick.ClientID %>');
            btnType.click();
        }

        function countdays() {
            var dayCounter = document.getElementById('<%= txtDaysCount.ClientID %>');
             var first = parseDate(document.getElementById('<%= txtDateFrom.ClientID %>').value);
             var second = parseDate(document.getElementById('<%= txtDateTo.ClientID %>').value);
             dayCounter.value = Math.round((second - first) / (1000 * 60 * 60 * 24));

             CalcAccom();
        }

        function CalcAccom() {

            var HunterValue, GuestValue, AdditCost;
            var huntersPax = document.getElementById('<%= txtHunterPax.ClientID %>');
             var GuestPax = document.getElementById('<%= txtGuestPax.ClientID %>');
             var AccomTotal = document.getElementById('<%= lblAccomTotal.ClientID %>');
             var dayCounter = document.getElementById('<%= txtDaysCount.ClientID %>');
             var GuestPrice = document.getElementById('<%= HiddenFieldGuestPrice.ClientID %>');
             var HunterPrice = document.getElementById('<%= HiddenFieldHunterPrice.ClientID %>');
             var AdditionalCost = document.getElementById('<%= HiddenFieldAdditionalTotal.ClientID %>');
             var hiddenAccom = document.getElementById('<%= HiddenFieldAccomTotal.ClientID %>');

             var Total = document.getElementById('<%= lblTotal.ClientID %>');

             HunterValue = dayCounter.value * huntersPax.value * HunterPrice.value;
             GuestValue = dayCounter.value * GuestPax.value * GuestPrice.value;


             hiddenAccom.value = HunterValue + GuestValue;
             AccomTotal.innerHTML = (HunterValue + GuestValue).formatMoney(2, '.', ',');

             Total.innerHTML = (1 * hiddenAccom.value) + (1 * AdditionalCost.value);
             Total.innerHTML = ((1 * hiddenAccom.value) + (1 * AdditionalCost.value)).formatMoney(2, '.', ',');

         }


         Number.prototype.formatMoney = function (c, d, t) {
             var n = this,
                 c = isNaN(c = Math.abs(c)) ? 2 : c,
                 d = d == undefined ? "." : d,
                 t = t == undefined ? "," : t,
                 s = n < 0 ? "-" : "",
                 i = String(parseInt(n = Math.abs(Number(n) || 0).toFixed(c))),
                 j = (j = i.length) > 3 ? j % 3 : 0;
             return s + (j ? i.substr(0, j) + t : "") + i.substr(j).replace(/(\d{3})(?=\d)/g, "$1" + t) + (c ? d + Math.abs(n - i).toFixed(c).slice(2) : "");
         };




         function parseDate(str) {
             var mdy = str.split('/');
             return new Date(mdy[2], mdy[0] - 1, mdy[1]);
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
                 zoom: 10,
                 mapTypeId: 'terrain'
             });

             var marker = new google.maps.Marker({
                 position: uluru,
                 map: map,
                 title: "here"
             });

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
                     <script async defer src="https://maps.googleapis.com/maps/api/js?key=AIzaSyAxqfU7c2bizBIU4YMpVEe8qcwd7tRQRHs&callback=initMap">
    </script>
</asp:Content>

