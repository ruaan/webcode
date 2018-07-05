<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FarmsApp.aspx.vb" Inherits="FarmsApp" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="../StyleSheets/token-input.css" type="text/css" />
    <link rel="stylesheet" href="../StyleSheets/StyleSheetApp.css" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.tokeninput.js"></script>
    <style type="text/css">
        body {
            background-color: #394025;
        }

        .style-profile {
            width: 230px;
            height: 230px;
        }

        .divFilter {
            border: 1px solid #8d9296;
            padding: 4px;
            font-size: medium;
            background-color: #5B6849;
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

        .auto-style1 {
            width: 100%;
        }

        .image_Style {
            width: 180px;
            height: 180px;
        }

        .dropDown {
            padding: 20px;
        }

        .selector {
            position: absolute;
            padding: 5px;
            left: 50%;
            background-color: #5B6849;
            border-bottom-left-radius: 10px;
            border-bottom-right-radius: 10px;
            color: white;
            cursor: pointer;
        }
    </style>

    <script type="text/javascript">

        function ShowHideDiv() {
            $(function () {

                $(document).ready(function () {
                    $('.selector').click(function () {
                        $('.dropDown').slideToggle(300);
                    });
                });
            });
        }
</script>


</head>
<body style="margin-left:0; margin-right:0;margin-top:0">
    <form id="form1" runat="server" autocomplete="off" style="margin-right:0;" >
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <img alt="" src="Images/Headings/destinations.jpg" style="width:100%" /></div>
        
        <div id="divSearch" style=" padding: 0px 5px 5px 0px;  width:100%" class = "dropDown" runat="server">
                   <div class="divFilter" id="divFilter">
             <div>&nbsp;</div>       
            <div>Country: <asp:DropDownList ID="cmbCountry" runat="server" CssClass="textbox" AutoPostBack="True" DataSourceID="SqlDataSourceCountries" DataTextField="Name" DataValueField="Country_Id" ></asp:DropDownList>
                 <asp:SqlDataSource ID="SqlDataSourceCountries" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Country_Id], [Name] FROM [tblCountries] WHERE ([Active] = @Active) ORDER BY [Name]">
                   <SelectParameters>
                       <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                   </SelectParameters>
               </asp:SqlDataSource>
            </div>
           <div>&nbsp;</div>
                         <div id="divFarmNameHdr" class="filterline"  onclick="ToggleDetails('divFarmDtl','imgFarmDown','imgFarmUp')" style="border-top-style: solid; border-top-width: thin; border-top-color: #99b37a">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/shot-distance2.png" class="header_icon"  /></div>
                <div style="display: inline-block; font-size: 14px;" >Search by Name</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgFarmUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgFarmDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divFarmDtl" style="display:none; background-color: #D7D7D7; width:95%; color: #424531;">
                  <div style="padding: 10px; background-color: #CCCCCC">
                        <div style="display:inline-block; width:80%">
                        <div style="padding-bottom: 5px; font-size: 14px;">Enter Farm Name or part thereof.</div>
                            <div>
                                <asp:TextBox ID="txtFarmSearch" runat="server" CssClass="textbox" Width="80%"></asp:TextBox>
                        
                            </div>
                            <div>&nbsp;</div>
                            </div>
             
                    </div>

              
            </div>
            <div  id="divLocationHdr" class="filterline"  onclick="ToggleDetails('divLocationDtl','imgLocationDown','imgLocationUp')" >
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/location2.png" class="header_icon" /></div>
                <div style="display: inline-block; font-size: 14px;" class="header_text">Location</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgLocationUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                    <img id="imgLocationDown" alt="" src="Images/Icons/numDown.png"  class="arrow_icon"  />
                </div>
                <div style="display: inline-block;">&nbsp;</div>
            </div>
            <div id="divLocationDtl" style="display:none; width:95%; background-color: #D7D7D7; color: #424531;">
                &nbsp;<asp:CheckBoxList ID="chkLocation" runat="server"  DataTextField="Name" DataValueField="ProvinceId" Width="100%" CssClass="chkBoxList"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceLocation" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Name], [ProvinceId] FROM [tblProvince] ORDER BY [Name]"></asp:SqlDataSource>
             
                </div>
 
        
            <div id="divAmenitiesHdr" class="filterline"  onclick="ToggleDetails('divAmenitiesDtl','imgAmenitiesDown','imgAmenitiesUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/amenities2.png"  class="header_icon" /></div>
                <div style="display: inline-block;  font-size: 14px;"" class="header_text">Facilities</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgAmenitiesUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgAmenitiesDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divAmenitiesDtl" style="display:none; width:95%; background-color: #D7D7D7; color: #424531;">
                <asp:CheckBoxList ID="chkFacilities" runat="server" CssClass="chkBoxList" DataSourceID="SqlDataSourceFacilities" DataTextField="FacilityType" DataValueField="id"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceFacilities" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [id], [FacilityType], [Active] FROM [tbl_Facility_Types] WHERE ([Active] = @Active) ORDER BY [FacilityType]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
            </div>


           <div id="divEcoHdr" class="filterline"  onclick="ToggleDetails('divEcoDtl','imgEcoDown','imgEcoUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/eco-tourism-icon.png"  class="header_icon" /></div>
                <div style="display: inline-block;  font-size: 14px;"" class="header_text">Eco Activities</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgEcoUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgEcoDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divEcoDtl" style="display:none; width:95%; background-color: #D7D7D7; color: #424531;">
                <asp:CheckBoxList ID="chkEco" runat="server" CssClass="chkBoxList" DataSourceID="SqlDataSourceEco" DataTextField="Eco_Tourism" DataValueField="id"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceEco" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT id, Eco_Tourism FROM dbo.tbl_EcoTourism_Types WHERE ([Active] = @Active) ORDER BY [Eco_Tourism]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
            </div>




            <div id="divHuntingTypeHdr" class="filterline"  onclick="ToggleDetails('divHuntingDtl','imgHuntingDown','imgHuntingUpUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/hunt-type2.png"  class="header_icon"  /></div>
                <div style="display: inline-block; font-size: 14px;" class="header_text">Type of Hunting</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgHuntingUpUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgHuntingDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divHuntingDtl" style="display:none; width:95%;  background-color: #D7D7D7; color: #424531;">
                <asp:CheckBoxList ID="chkHuntingType" runat="server" CssClass="chkBoxList" DataSourceID="SqlDataSourceHuntingTypes" DataTextField="HuntingType" DataValueField="id"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceHuntingTypes" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [id], [HuntingType], [Active] FROM [tbl_Hunting_Types] WHERE ([Active] = @Active) ORDER BY [HuntingType]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>

            <div id="divGameTypeHdr" class="filterline"  onclick="ToggleDetails('divGameDtl','imgGameDown','imgGameUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/required-game2.png" class="header_icon"  /></div>
                <div style="display: inline-block; font-size: 14px;" class="header_text">Game Required</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgGameUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgGameDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divGameDtl" style="display: none; background-color: #D7D7D7; color: #424531;">
                <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>

                &nbsp;
            </div>

 



            <div  id="divAvailabilityHdr" class="filterline"  onclick="ToggleDetails('divAvailabilityDtl','imgAvailabilityDown','imgAvailabilityUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/availability2.png"  class="header_icon" /></div>
                <div style="display: inline-block; font-size: 14px;" class="header_text">Availability</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgAvailabilityUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgAvailabilityDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divAvailabilityDtl"  style="display:none; width:95%;  background-color: #D7D7D7; color: #424531;">
                 <div style="padding: 10px; background-color: #CCCCCC">
                        <div style="display:inline-block;">
                        <div style="padding-bottom: 5px; font-weight: bold;">Arrival</div>
                            <div>
                                <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" BehaviorID="txtDateFrom_CalendarExtender" TargetControlID="txtDateFrom"/>

                            </div>
                            <div>&nbsp;</div>
                            </div>

                         <div style="display:inline-block;">
                        
                            <div>&nbsp;</div>
                            </div>

                         <div style="display:inline-block;">
                        <div style="padding-bottom: 5px; font-weight: bold;">Departure</div>
                            <div>
                                 <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox"></asp:TextBox>
                        <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" BehaviorID="txtDateTo_CalendarExtender" TargetControlID="txtDateTo" />

                            </div>
                            <div>&nbsp;</div>
                            </div>
                    </div>
            </div>
             <div id="divPackagesHdr" class="filterline"  onclick="ToggleDetails('divPackagesDtl','imgPackagesDown','imgPackagesUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/hunt-type2.png"  class="header_icon"  /></div>
                <div style="display: inline-block; font-size: 14px;" class="header_text">Packages</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgPackagesUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgPackagesDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divPackagesDtl" style="display:none; width:95%;  background-color: #D7D7D7; color: #424531;">
                <div>&nbsp;</div>
               &nbsp; <asp:CheckBox ID="chkPackages"  CssClass="chkBoxList" runat="server" TextAlign="Left" Text="Only show farms with Packages" />
                <div>&nbsp;</div>
            </div>
            <div align="left" style="width: 96%" id="additional" class="inline_Panel_Header">
                <div style="   color:white;">
                    
                    <div style="padding: 6px 10px 2px 10px;">
                        <div style="padding: 5px 5px 5px 5px; font-size: 14px;">Number of Hunters &nbsp;<asp:TextBox ID="TextBox3" runat="server" Width="50px" CssClass="textbox"></asp:TextBox></div>
                                             
                    </div>
                    
                    <div style="padding: 2px 10px 10px 10px;">
                        <div style="padding: 5px; font-size: 14px;">Number of Guests &nbsp; &nbsp;<asp:TextBox ID="TextBox4" runat="server" Width="50px" CssClass="textbox"></asp:TextBox></div>

                    </div>
                    
                </div>
            </div>
         
            <div style="width: 96%"  id="divBtn" ">
                <div style="display: inline-block; width: 2%">&nbsp;</div>
                    <div align="center" style="display: inline-block; " class="auto-style1">
                         <asp:ImageButton ID="imgBtnFilter" runat="server" ImageUrl="~/Images/Icons/Farm_Search/filtersearchbar.png"  />
                    </div>
                <div>&nbsp;</div>
                 <div style="text-align:right;">
                     <div id="divFavouriteView" runat="server" visible="false" onclick="window.open('View_Favourites_App.aspx', '_self')">
                          View Favourites 
                             <asp:Label ID="lblFavoriteCount" runat="server"></asp:Label>
                             &nbsp; <img alt="" src="Images/Icons/favorite-select.png" class="rateStar" />
                     </div>
                 </div>
                 <div>&nbsp;</div>
            </div>

           
        </div>

        </div>
        <div class="selector" >
    Filter
</div>
        <div style="font-family: Calibri; color: #424531; width:100%">
             <table align="center" style="width: 100%;">
               
                <tr>
                
                <td>
                    <asp:Image ID="imgFarmsResult" runat="server" ImageUrl="~/Images/Logos/farm-search-result.png" Visible="False" /> </td>
                </tr>
               
                <tr>
                    <td>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>
       <script type="text/javascript">

           function ToggleDetails(pnlDiv, imgDown, imgUp) {
               var Colordiv = document.getElementById(pnlDiv);
               var CustImgDown = document.getElementById(imgDown);
               var CustImgUp = document.getElementById(imgUp);

               if (Colordiv.style.display == 'none') {
                   Colordiv.style.display = 'inline-block';
                   CustImgDown.style.display = 'none';
                   CustImgUp.style.display = 'inline-block';
               } else {
                   Colordiv.style.display = 'none';
                   CustImgDown.style.display = 'inline-block';
                   CustImgUp.style.display = 'none';
               }

           }

           function ToggleSearch(pnlDiv, imgDown, imgUp) {
               var Colordiv = document.getElementById(pnlDiv);
               var CustImgDown = document.getElementById(imgDown);
               var CustImgUp = document.getElementById(imgUp);

               if (Colordiv.style.display == 'none') {
                   Colordiv.style.display = 'block';

               } else {
                   Colordiv.style.display = 'none';

               }

           }

           function saveFavorite(farmid) {

               var btnFavorite = document.getElementById('<%=Button1.ClientID%>');
               var farmIdtxt = document.getElementById('<%=hiddenfieldFavorite.ClientID%>');

               farmIdtxt.value = farmid;
               btnFavorite.click();

           }

           function removeFavorite(farmid) {

               var btnFavorite = document.getElementById('<%=Button2.ClientID%>');
               var farmIdtxt = document.getElementById('<%=hiddenfieldFavorite.ClientID%>');

               farmIdtxt.value = farmid;
               btnFavorite.click();

           }

    </script>
        <asp:Button ID="Button2" runat="server" BackColor="#394025" BorderStyle="None" />
         <asp:HiddenField ID="hiddenfieldFavorite" runat="server" />
        <asp:Button ID="Button1" runat="server" BackColor="#394025" BorderStyle="None" />
    </form>
       </body>
</html>
