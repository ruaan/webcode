<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Animals_App.aspx.vb" Inherits="Animals_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link rel="stylesheet" href="../StyleSheets/token-input.css" type="text/css" />
    <script type="text/javascript" src="https://ajax.googleapis.com/ajax/libs/jquery/1.5.1/jquery.min.js"></script>
    <script type="text/javascript" src="../Scripts/jquery.tokeninput.js"></script>
    <style>
        body {
            background-color: #394025;
            margin: 0;
        }

        .divFilter {
            border: 1px solid #8d9296;
            padding: 4px;
            font-size: large;
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
            width: 100px;
            height: 100px;
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
            background-color: #E9F6D8;
            width: 100%;
        }

        .Animal_Pic {
            height: 100px;
            width: 100px;
        }
    </style>
</head>
<body style="margin:0">
    <form id="form1" runat="server">
        <div>
              
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <img alt="" src="Images/Headings/sepcies.jpg"  style="width:100%"  />
         <div class="divFilter" id="divFilter">
                    
            <div class="h1" >Search Species</div>
           
            <div style="width: 96%; cursor:pointer;" id="divLocationHdr" class="inline_Panel_Header" onclick="ToggleDetails('divLocationDtl','imgLocationDown','imgLocationUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/required-game2.png" class="header_icon" /></div>
                <div style="display: inline-block;" class="header_text">By Name</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgLocationUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                    <img id="imgLocationDown" alt="" src="Images/Icons/numDown.png"  class="arrow_icon"  />
                </div>
                <div style="display: inline-block;">&nbsp;</div>
            </div>
            <div id="divLocationDtl" style=" width:100%">
               <asp:PlaceHolder ID="PlaceHolder3" runat="server"></asp:PlaceHolder>
            </div>
 
            

           
            
            
            <div>&nbsp;</div>
           
         
            <div>&nbsp;</div>
            <div style="width: 96%"  id="divBtn" ">
                <div style="display: inline-block; width: 2%">&nbsp;</div>
                    
                    <div align="center" style="">
                          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/Farm_Search/filtersearchbar.png" />
                    </div>

            </div>

            <div>&nbsp;</div>
        </div>
 <div style="font-family: Calibri; color: #424531;">
             <table align="center" style="width: 100%;">
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
</body>
</html>
