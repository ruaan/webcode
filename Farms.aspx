<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Farms.aspx.vb" Inherits="Farms" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../StyleSheets/token-input.css" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.tokeninput.js"></script>
     
    <style type="text/css">
        .divFilter {
            border: 1px solid #8d9296;
            padding: 4px;
            font-size: medium;
            background-color: #f8f8f8;
            display: inline-block;
            vertical-align: top;
            width: 300px;
            text-align: left;
        }

        .divResult {
            display: inline-block;
            vertical-align: top;
            text-align: left;
            padding-left: 10px;
        }



        .div_Farm_Block {
            border: 1px solid #333333;
            background-color: #F8F8F8;
            padding: 15px;
            font-family: Calibri;
            color: #333333;
        }

        .div_Picture_Style {
            width: 282px;
            height: 282px;
            display: inline-block;
            cursor: pointer;
        }

        .div_Farm_header {
            font-size: large;
            font-weight: bold
        }

        .div_Middle_Block {
            width: 300px;
            vertical-align: top;
            padding: 0px 10px 10px 10px;
            display: inline-block;
            cursor: pointer;
        }

        .div_right_block {
            width: 200px;
            vertical-align: top;
            padding-top: 0px;
            padding-left: 20px;
            display: inline-block;
            border-left-style: solid;
            border-width: thin;
            border-color: #FFFFFF;
        }

        .image_Style {
            width: 100%;
            height: 100%;
        }

        .div_text_block {
            height: 190px;
        }

        .icon_style {
            padding: 5px;
            display: inline-block;
        }

        .rateStar {
            width: 28px;
            height: 28px;
        }

        .div_facility_block {
            min-height: 150px;
        }

        .facilities {
            padding-bottom: 5px;
        }

        .drop_icon {
            width: 16px;
            height: 16px;
        }

        .header_icon {
            width: 21px;
            height: 21px;
            vertical-align: middle;
        }

        .arrow_icon {
            vertical-align: middle;
        }

        .header_text {
            padding-left: 5px;
        }

        .e-style2 {
            width: 92px;
        }

        .chkBoxList {
            margin-right: 10px;
            padding-right: 10px;
            padding-left: 10px;
            padding-bottom: 5px;
            background-color: #E9F6D8;
            width: 100%;
        }

        .auto-style2 {
            width: 580px;
        }

        .LoadingClass {
            position: absolute;
            background-color: #FAFAFA;
            z-index: 2147483647;
            opacity: 0.8;
            overflow: hidden;
            text-align: center;
            top: 0;
            left: 0;
            height: 39000%;
            width: 100%;
            padding-top: 20%;
            display: none;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <%-- </ContentTemplate></asp:UpdatePanel>--%>
    
    <div>&nbsp;</div>
   <%-- <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate> --%>
     <div id="mainPageWrapper">
            <div id="mainBlock" class="div_MainBlock">
                   <div class="divFilter" id="divFilter">
                    
            <div class="h1" >Search Filter</div>
           <div>Country:  <asp:DropDownList ID="cmbCountrySelect" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceCountries" DataTextField="Name" DataValueField="Country_Id">
               </asp:DropDownList>
               <asp:SqlDataSource ID="SqlDataSourceCountries" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Country_Id], [Name] FROM [tblCountries] WHERE ([Active] = @Active) ORDER BY [Name]">
                   <SelectParameters>
                       <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                   </SelectParameters>
               </asp:SqlDataSource>
                      
                       </div>
   <div style="width: 96%; cursor:pointer" id="divFarmNameHdr" class="inline_Panel_Header" onclick="ToggleDetails('divFarmDtl','imgFarmDown','imgFarmUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/shot-distance.png"  class="header_icon" /></div>
                <div style="display: inline-block" class="header_text">Search by Name</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgFarmUp" alt="" src="Images/Icons/numUp.png" style="display: none"  class="arrow_icon"  />
                    <img id="imgFarmDown" alt="" src="Images/Icons/numDown.png"  class="arrow_icon" />
                </div>
            </div>
            <div id="divFarmDtl" style="display:none; width:100%">
                <div style="width: 100%">
                   
                        <div style=" background-color: #E9F6D8;  width:100%">
                        <div style="display:inline-block; width:100%">
                        <div style="padding-bottom: 5px; font-size: 14px;">Enter Farm Name or part thereof.</div>
                            <div>
                                <asp:TextBox ID="txtFarmSearch" runat="server" CssClass="textbox" Width="80%"></asp:TextBox>
                        
                            </div>
                            <div>&nbsp;</div>
                            </div>
             
                  

                    </div>
                   
                </div>
            </div>
            <div style="width: 96%; cursor:pointer;" id="divLocationHdr" class="inline_Panel_Header" onclick="ToggleDetails('divLocationDtl','imgLocationDown','imgLocationUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/location.png" class="header_icon" /></div>
                <div style="display: inline-block;" class="header_text">Location</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgLocationUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                    <img id="imgLocationDown" alt="" src="Images/Icons/numDown.png"  class="arrow_icon"  />
                </div>
                <div style="display: inline-block;">&nbsp;</div>
            </div>
            <div id="divLocationDtl" style="display:none;  width:100%">
                <asp:CheckBoxList ID="chkLocation" runat="server" DataTextField="Name" DataValueField="ProvinceId" Width="100%" CssClass="chkBoxList"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceLocation" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Name], [ProvinceId] FROM [tblProvince] ORDER BY [Name]"></asp:SqlDataSource>
             
                </div>
 
                     <div style="width: 96%; cursor:pointer" id="divAmenitiesHdr" class="inline_Panel_Header" onclick="ToggleDetails('divAmenitiesDtl','imgAmenitiesDown','imgAmenitiesUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/amenities.png"  class="header_icon" /></div>
                <div style="display: inline-block" class="header_text">Facilities</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgAmenitiesUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgAmenitiesDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divAmenitiesDtl" style="display:none; width:100%">
                <asp:CheckBoxList ID="chkFacilities" runat="server" CssClass="chkBoxList" DataSourceID="SqlDataSourceFacilities" DataTextField="FacilityType" DataValueField="id"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceFacilities" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [id], [FacilityType], [Active] FROM [tbl_Facility_Types] WHERE ([Active] = @Active) ORDER BY [FacilityType]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
            </div>

                          <div style="width: 96%; cursor:pointer" id="divEcoHdr" class="inline_Panel_Header" onclick="ToggleDetails('divEcoDtl','imgEcoDown','imgEcoUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/eco-tourism-icon.png"  class="header_icon" /></div>
                <div style="display: inline-block" class="header_text">Eco Activities</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgEcoUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgEcoDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divEcoDtl" style="display:none; width:100%">
                <asp:CheckBoxList ID="chkEco" runat="server" CssClass="chkBoxList" DataSourceID="SqlDataSourceEco" DataTextField="Eco_Tourism" DataValueField="id"></asp:CheckBoxList>
                 <asp:SqlDataSource ID="SqlDataSourceEco" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT id, Eco_Tourism FROM dbo.tbl_EcoTourism_Types WHERE ([Active] = @Active) ORDER BY [Eco_Tourism]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
                
            </div>


            <div style="width: 96%; cursor:pointer" id="divHuntingTypeHdr" class="inline_Panel_Header" onclick="ToggleDetails('divHuntingDtl','imgHuntingDown','imgHuntingUpUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/hunt-type.png"  class="header_icon"  /></div>
                <div style="display: inline-block" class="header_text">Type of Hunting</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgHuntingUpUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgHuntingDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divHuntingDtl" style="display:none; width:100%">
                <asp:CheckBoxList ID="chkHuntingType" runat="server" CssClass="chkBoxList" DataSourceID="SqlDataSourceHuntingTypes" DataTextField="HuntingType" DataValueField="id"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceHuntingTypes" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [id], [HuntingType], [Active] FROM [tbl_Hunting_Types] WHERE ([Active] = @Active) ORDER BY [HuntingType]">
                    <SelectParameters>
                        <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                    </SelectParameters>
                </asp:SqlDataSource>
            </div>

            <div style="width: 96%; cursor:pointer" id="divGameTypeHdr" class="inline_Panel_Header" onclick="ToggleDetails('divGameDtl','imgGameDown','imgGameUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/required-game.png" class="header_icon"  /></div>
                <div style="display: inline-block" class="header_text">Game Required</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgGameUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgGameDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divGameDtl" style="display: none; background-color: #E9F6D8;">
                <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>

                &nbsp;
            </div>

            <div style="width: 96%; cursor:pointer" id="divAvailabilityHdr" class="inline_Panel_Header" onclick="ToggleDetails('divAvailabilityDtl','imgAvailabilityDown','imgAvailabilityUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/availability.png"  class="header_icon" /></div>
                <div style="display: inline-block" class="header_text">Availability</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgAvailabilityUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgAvailabilityDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divAvailabilityDtl"  style="display:none; background-color: #E9F6D8; width:100%">
                <div>&nbsp;</div>
                <div style="width: 100%">
                    <div style="display: inline-block; padding-left: 20px;">
                        <div>Date From:</div>
                        <div>
                            <asp:TextBox ID="txtDateFrom" runat="server" CssClass="textbox" Width="94px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" BehaviorID="txtDateFrom_CalendarExtender" TargetControlID="txtDateFrom" />
                        </div>
                    </div>
                    <div style="display: inline-block; padding-left: 20px;">
                        <div> Date To:</div>
                        <div>
                            <asp:TextBox ID="txtDateTo" runat="server" CssClass="textbox" Width="94px"></asp:TextBox>
                            <cc1:CalendarExtender ID="txtDateTo_CalendarExtender" runat="server" BehaviorID="txtDateTo_CalendarExtender" TargetControlID="txtDateTo" />
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
            </div>



            <div style="width: 96%; cursor:pointer;" id="divPackagesHdr" class="inline_Panel_Header" onclick="ToggleDetails('divPackagesDtl','imgPackagesDown','imgPackagesUp')">
                <div style="display: inline-block"><img alt="" src="Images/Icons/Farm_Search/Main/hunt-type.png" class="header_icon" /></div>
                <div style="display: inline-block;" class="header_text">Packages</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgPackagesUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                    <img id="imgPackagesDown" alt="" src="Images/Icons/numDown.png"  class="arrow_icon"  />
                </div>
                <div style="display: inline-block;">&nbsp;</div>
            </div>
            <div id="divPackagesDtl" style="display:none; width:100%;  background-color: #E9F6D8;">
                
                <asp:CheckBox ID="chkPackages"  CssClass="chkBoxList" runat="server" TextAlign="Left" Text="Only show farms with Packages" />
            </div>





            <div>&nbsp;</div>
            <div style="width: 96%" id="additional" class="inline_Panel_Header">
                <div style="width: 90%">
                  <div style="padding: 6px 10px 2px 10px;">
                        <div style="padding: 5px 5px 5px 5px; font-size: 14px;">Number of Hunters &nbsp;<asp:TextBox ID="txtHunterPax" runat="server" Width="50px" CssClass="textbox"></asp:TextBox></div>
                                             
                    </div>
                    
                    <div style="padding: 2px 10px 10px 10px;">
                        <div style="padding: 5px; font-size: 14px;">Number of Guests &nbsp; &nbsp;<asp:TextBox ID="txtGuestPax" runat="server" Width="50px" CssClass="textbox"></asp:TextBox></div>

                    </div>
                </div>
            </div>
         
            <div>&nbsp;</div>
            <div style="width: 96%"  id="divBtn" ">
                <div style="display: inline-block; width: 2%">&nbsp;</div>
                    <div style="display: inline-block; " class="e-style2">
                       
                        <asp:Button ID="btnClearAll" runat="server" Text="Clear All" CssClass="button" Width="83px" />
                    </div>
                    <div style="display: inline-block; float:right">
                         <asp:Button ID="btnSearch" runat="server" Text="Filter & Search" CssClass="button" />
                    </div>

            </div>

            <div>&nbsp;</div>
        </div>





               
                <div class="divResult" id="divResult">
                     <div>
                         <div style="display:inline-block; color: #FFFFFF;">
                             <%--<div style="display:inline-block; color: #FFFFFF;">Sort by</div> 
                             | popular | price | closest to me &nbsp;--%>
                         </div> 
                          <%-- <div style="display:inline-block;"">
                             <div style="display:inline-block; color: #CC0000;">Sort by</div> 
                             | popular | price | closest to me &nbsp;
                         </div> --%> 
                         <div style="display:inline-block; text-align:right; cursor: pointer; color: #333333; width:100%"   onclick="window.open('View_Favourites.aspx', '_self')">
                             View Favourites 
                             <asp:Label ID="lblFavoriteCount" runat="server"></asp:Label>
                             &nbsp; <img alt="" src="Images/Icons/star.png" class="rateStar" />
                         </div> 
                      </div>
                    <div>&nbsp;</div>
                    <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                </div>

            </div>
         <asp:Button ID="Button1" runat="server" CssClass="lineButton" /><asp:Button ID="Button2" runat="server" CssClass="lineButton" />
        </div>
         <asp:HiddenField ID="hiddenfieldFavorite" runat="server" />
  <%-- </ContentTemplate></asp:UpdatePanel>--%>
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

    </script >
    
   

</asp:Content>

