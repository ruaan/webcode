<%@ Page Language="VB" AutoEventWireup="false" CodeFile="farm_reserve1.aspx.vb" Inherits="farm_reserve1" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #424531;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" autocomplete="off">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:HiddenField ID="HiddenFarmId" runat="server" />
        <asp:HiddenField ID="HiddenType" runat="server" />
        <div style="font-family: Calibri; color: #333333">
            <div style="background-color: #E5E3E5">
                <div style="display: inline-block;">
                    <asp:Image ID="Image1" runat="server" ImageUrl="~/Farms/Images/FarmProfiles/1Main.jpg" Height="111px" Width="112px" />
                </div>
                <div style="padding: 5px; display: inline-block; vertical-align: top">
                    <div><strong>Game Farm</strong></div>
                    <div>
                        <asp:Label ID="lblHeading" runat="server" Text="Thuru Lodge"></asp:Label>
                    </div>
                    <div>&nbsp;</div>
                    <div><strong>Daily Rate</strong></div>
                    <div style="display: inline-block">
                        Hunters
                        <div>
                            <asp:Label ID="lblHunterRate" runat="server" Text=""></asp:Label>
                        </div>
                    </div>
                    &nbsp; &nbsp;
                    <div style="display: inline-block">
                        Guests
                        <div>
                            <asp:Label ID="lblGuestRate" runat="server"></asp:Label>
                        </div>
                    </div>

                </div>
            </div>
        </div>
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

                <%--  </div>
                     <div style="vertical-align:middle; padding-left: 10px; padding-top: 20px; padding-bottom: 20px;">
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
                    <asp:Label ID="lblValidate" runat="server"></asp:Label>
                </div>
            </div>
    </form>
    <script type="text/javascript">


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




    </script>
</body>
</html>
