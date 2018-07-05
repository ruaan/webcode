<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Dashboard_App.aspx.vb" Inherits="Members_Dashboard_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../StyleSheets/slideshow.css" type="text/css" />
    <script src="http://ajax.googleapis.com/ajax/libs/jquery/1/jquery.js"></script>
    <script src="../Scripts/jquery.cycle2.min.js"></script>
    <script src="../Scripts/jquery.cycle2.carousel.min.js"></script>
    <%--<script>$.fn.cycle.defaults.autoSelector = '.slideshow';</script>--%>

    <style type="text/css">
        body {
            background-color: #424531;
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

</head>
<body>
    <form id="form1" runat="server">
        <div>



            <div style="align-content: center; width: 100%;">
                <div align="center">
                    <img alt="" src="../Images/Logos/landing2.jpg" class="land-style1" />
                </div>
            </div>

            <div>&nbsp;</div>


            <div>&nbsp;</div>


            <div>
                <asp:PlaceHolder ID="PlaceHolderadd" runat="server"></asp:PlaceHolder>
            </div>
            <div>&nbsp;</div>
            <div>&nbsp;</div>
        </div>
    </form>
</body>
</html>
