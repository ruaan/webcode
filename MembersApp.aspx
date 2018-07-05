<%@ Page Language="VB" AutoEventWireup="false" CodeFile="MembersApp.aspx.vb" Inherits="MembersApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #394025;
            margin: 0;
        }

        .auto-style1 {
            width: 100%;
        }

        .divFilter {
            border: 1px solid #8d9296;
            font-size: medium;
            background-color: #5B6849;
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            font-family: Calibri;
            color: white;
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
            cursor: pointer;
        }

        .div_Picture_Style {
            width: 80px;
            height: 80px;
            display: inline-block;
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

        .chkBoxList {
            margin-right: 10px;
            padding-right: 10px;
            padding-left: 10px;
            padding-bottom: 5px;
            width: 100%;
        }
    </style>

</head>
<body>
    <form id="form1" runat="server"  autocomplete="off">
        <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div>
                <img alt="" src="Images/Headings/hunters.jpg" style =" width:100%"/></div>
        <div id="divSearch" style="  font-size: large">
               <div class="divFilter" id="divFilter">
                    
           
           
            <div style="padding: 5px; border-style: none none solid none; border-width: thin; border-color: #86B24F; width: 96%; cursor:pointer; font-size: larger;" id="divLocationHdr" class="inline_Panel_Header" onclick="ToggleDetails('divLocationDtl','imgLocationDown','imgLocationUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/farmvisit.png" class="header_icon" /></div>
                <div style="display: inline-block;" class="header_text">Farms Visited</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgLocationUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                    <img id="imgLocationDown" alt="" src="Images/Icons/numDown.png"  class="arrow_icon"  />
                </div>
                <div style="display: inline-block;">&nbsp;</div>
            </div>
            <div id="divLocationDtl" style="display:none; width:90%;  background-color: #D7D7D7; color: #424531;">
                <asp:CheckBoxList ID="chkLocation" runat="server" DataSourceID="SqlDataSourceLocation" DataTextField="FarmName" DataValueField="id" Width="100%" CssClass="chkBoxList"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceLocation" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT DISTINCT id, FarmName FROM tbl_Farm ORDER BY FarmName"></asp:SqlDataSource>
            </div>
 
            

            <div style="padding: 5px; border-style: none none solid none; border-width: thin; border-color: #86B24F; width: 96%; cursor:pointer; font-size: large;" id="divGameTypeHdr" class="inline_Panel_Header" onclick="ToggleDetails('divGameDtl','imgGameDown','imgGameUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/animalshunted.png" class="header_icon"  /></div>
                <div style="display: inline-block" class="header_text">Animals Hunted</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgGameUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgGameDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divGameDtl" style="display:none; width:100%;  background-color: #D7D7D7; color: #424531;">
                <asp:CheckBoxList ID="chkAnimalsHunted" runat="server" DataSourceID="SqlDataSourceAnimalsHunted" DataTextField="Name" DataValueField="id" Width="100%" CssClass="chkBoxList"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceAnimalsHunted" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT DISTINCT id, Name FROM tbl_Animals ORDER BY Name"></asp:SqlDataSource>
            </div>
            
            <div>&nbsp;</div>
            <div style="width: 96%" id="additional" class="inline_Panel_Header">
                <div style="width: 90%">
                    <div style="display: inline-block; width: 2%">&nbsp;</div>
                    <div style="display: inline-block; width: 45%">
                        <div>Member Name</div>
                        <div style="vertical-align:middle;">
                            <asp:TextBox ID="txtMemName" runat="server" Width="250px" CssClass="textbox"></asp:TextBox>&nbsp;</div>

                    </div>
                </div>
            </div>
         
            <div>&nbsp;</div>
            <div style="width: 96%"  id="divBtn" ">
                <div style="display: inline-block; width: 2%">&nbsp;</div>
                    <div style="display: inline-block; " class="auto-style2">
                       
                    </div>
                    <div align="center" style="display: inline-block; " class="auto-style1">
                         <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/Farm_Search/filtersearchbar.png" />
                    </div>
                <div>
                    <asp:Button ID="btnClearAll" runat="server" Text="Clear All" BorderStyle="None" Font-Size="Larger" Visible="False" /></div>

            </div>

            <div>&nbsp;</div>
        </div>

        </div>
 <div style="font-family: Calibri; color: #424531;">
             <table align="center" style="width: 90%;">
                <tr>
                    <td style="color: #FFFFFF; font-size: medium;">
                       <div id="divSearchClick" onclick="ToggleSearch('divSearch','imgAvailabilityDown','imgAvailabilityUp')" style="font-size: larger; display:none;" > <img alt="" src="Images/Icons/Farm_Search/filter.png" />VIEW FILTERS</div></td>
                </tr>
                <tr>
                    <td style="color: #FFFFFF; font-size: large;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder> <asp:Label ID="Label1" runat="server" ForeColor="White"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>




        </div>
    </form>
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

    </script>
</body>
</html>
