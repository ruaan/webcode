<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Members.aspx.vb" Inherits="Members" %>

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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>&nbsp;</div>
     <div id="mainPageWrapper">
            <div id="mainBlock" class="div_MainBlock">
                   <div class="divFilter" id="divFilter">
                    
            <div class="h1" >Search Members</div>
           
            <div style="width: 96%; cursor:pointer;" id="divLocationHdr" class="inline_Panel_Header" onclick="ToggleDetails('divLocationDtl','imgLocationDown','imgLocationUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/location.png" class="header_icon" /></div>
                <div style="display: inline-block;" class="header_text">Farms Visited</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgLocationUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                    <img id="imgLocationDown" alt="" src="Images/Icons/numDown.png"  class="arrow_icon"  />
                </div>
                <div style="display: inline-block;">&nbsp;</div>
            </div>
            <div id="divLocationDtl" style="display:none; width:100%">
                <asp:CheckBoxList ID="chkLocation" runat="server" DataSourceID="SqlDataSourceLocation" DataTextField="FarmName" DataValueField="id" Width="100%" CssClass="chkBoxList"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceLocation" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT DISTINCT id, FarmName FROM tbl_Farm ORDER BY FarmName"></asp:SqlDataSource>
            </div>
 
            

            <div style="width: 96%; cursor:pointer" id="divGameTypeHdr" class="inline_Panel_Header" onclick="ToggleDetails('divGameDtl','imgGameDown','imgGameUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/required-game.png" class="header_icon"  /></div>
                <div style="display: inline-block" class="header_text">Animals Hunted</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgGameUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon"  />
                    <img id="imgGameDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon"  />
                </div>
            </div>
            <div id="divGameDtl" style="display:none; width:100%">
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
                           
                         </div> 
                         <div style="display:inline-block; width:580px; text-align:right;"></div> 
                      </div>
                    <div>&nbsp;</div>
                    <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                    <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
                </div>

            </div>
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



    </script>

</asp:Content>

