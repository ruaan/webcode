<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Package_Search.aspx.vb" Inherits="Package_Search" %>

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
            width: 180px;
            height: 180px;
            display: inline-block;
            cursor: pointer;
        }

        .div_Farm_header {
            font-size: large;
            font-weight: bold
        }

        .div_Middle_Block {
            width: 500px;
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
            width: 150px;
            height: 150px;
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
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div>&nbsp;</div>

    <div id="mainPageWrapper">
        <div id="mainBlock" class="div_MainBlock">
            <div class="divFilter" id="divFilter">

                <div class="h1">Search Packages</div>
                <div>&nbsp;</div>
                <div>
                    Country:
                    <asp:DropDownList ID="cmbCountry" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceCountries" DataTextField="Name" DataValueField="Country_Id"></asp:DropDownList>
                    <asp:SqlDataSource ID="SqlDataSourceCountries" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Country_Id], [Name] FROM [tblCountries] WHERE ([Active] = @Active) ORDER BY [Name]">
                        <SelectParameters>
                            <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                        </SelectParameters>
                    </asp:SqlDataSource>
                </div>
                <div>&nbsp;</div>
                <div style="width: 96%; cursor: pointer;" id="divLocationHdr" class="inline_Panel_Header" onclick="ToggleDetails('divLocationDtl','imgLocationDown','imgLocationUp')">
                    <div style="display: inline-block">
                        <img alt="" src="Images/Icons/Farm_Search/Main/location.png" class="header_icon" />
                    </div>
                    <div style="display: inline-block;" class="header_text">Location</div>
                    <div style="display: inline-block; float: right;">
                        <img id="imgLocationUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                        <img id="imgLocationDown" alt="" src="Images/Icons/numDown.png" class="arrow_icon" />
                    </div>
                    <div style="display: inline-block;">&nbsp;</div>
                </div>
                <div id="divLocationDtl" style="display: none; width: 100%">
                    <asp:CheckBoxList ID="chkLocation" runat="server" DataTextField="Name" DataValueField="ProvinceId" Width="100%" CssClass="chkBoxList"></asp:CheckBoxList>
                    <asp:SqlDataSource ID="SqlDataSourceLocation" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Name], [ProvinceId] FROM [tblProvince] ORDER BY [Name]"></asp:SqlDataSource>

                </div>

                <div>&nbsp;</div>
                <div style="width: 96%" id="divBtn">
                    <div style="display: inline-block; width: 2%">&nbsp;</div>
                    <div style="display: inline-block;" class="e-style2">

                        <asp:Button ID="btnClearAll" runat="server" Text="Clear All" CssClass="button" Width="83px" />
                    </div>
                    <div style="display: inline-block; float: right">
                        <asp:Button ID="btnSearch" runat="server" Text="Filter & Search" CssClass="button" />
                    </div>

                </div>

                <div>&nbsp;</div>
            </div>

            <div class="divResult" id="divResult">

                <div>&nbsp;</div>
                <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
            </div>


        </div>
        <asp:Button ID="Button1" runat="server" CssClass="lineButton" />
    </div>
    <asp:HiddenField ID="hiddenfieldFavorite" runat="server" />

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


    </script>


</asp:Content>

