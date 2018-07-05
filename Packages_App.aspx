<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Packages_App.aspx.vb" Inherits="Packages_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #394025;
            margin: 0;
        }

        .panel-style2 {
            width: 50%;
        }

        .auto-style3 {
            height: 23px;
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
            width: 200px;
            height: 180px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="divDetails" style="font-size: x-large;">Packages</div>
        <div>&nbsp;</div>
        <div>
            <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
            <asp:Label ID="Label1" runat="server" Text=""></asp:Label>
        </div>
    </form>
</body>
</html>
