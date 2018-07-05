<%@ Page Language="VB" AutoEventWireup="false" CodeFile="View_Favourites_App.aspx.vb" Inherits="View_Favourites_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../StyleSheets/StyleSheetApp.css" type="text/css" />

    <style type="text/css">
        body {
            background-color: #394025;
            margin-left: 0;
            margin-right: 0;
            margin-top: 0
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

        .divDetails {
            border: 1px solid #8d9296;
            padding: 4px;
            font-size: medium;
            background-color: #FFFFFF;
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            font-family: Calibri;
            color: #333333;
        }

        .image_Style {
            width: 180px;
            height: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>&nbsp;</div>
        <div class="divDetails" style="font-size: x-large;">My Favourites</div>
        <div>&nbsp;</div>
        <div style="font-family: Calibri; color: #424531; width: 100%">
            <table align="center" style="width: 100%;">



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
