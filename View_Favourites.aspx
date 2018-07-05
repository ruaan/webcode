<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="View_Favourites.aspx.vb" Inherits="View_Favourites" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">


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
    <div>&nbsp;</div>
    <div class="h1">My Favourites</div>
    <div>&nbsp;</div>
    <div id="mainPageWrapper">
        <div id="mainBlock" class="div_MainBlock">
            <div class="divResult" id="divResult">

                <div>&nbsp;</div>
                <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
            </div>
        </div>
    </div>
    <asp:Button ID="Button1" runat="server" CssClass="lineButton" /><asp:Button ID="Button2" runat="server" CssClass="lineButton" Style="height: 22px" />
    <asp:HiddenField ID="hiddenfieldFavorite" runat="server" />
    <script type="text/javascript">



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
</asp:Content>

