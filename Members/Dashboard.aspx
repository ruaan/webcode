<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Dashboard.aspx.vb" Inherits="Members_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link rel="stylesheet" href="../StyleSheets/slideshow.css" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
    <script src="../Scripts/jquery.cycle2.min.js"></script>
    <script src="../Scripts/jquery.cycle2.carousel.min.js"></script>
    <style type="text/css">
        body {
        }

        .news-style1 {
            width: 100%;
            height: 100%;
        }

        .land-style1 {
            width: 330px;
            height: 200px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>
    <div style="align-content: center; width: 100%;">
        <div align="center">
            <img alt="" src="../Images/Logos/landing2.jpg" class="land-style1" />
        </div>
    </div>
    <div>&nbsp;</div>
    <div>
        <asp:PlaceHolder ID="PlaceHolderadd" runat="server"></asp:PlaceHolder>
    </div>


    &nbsp;

</asp:Content>

