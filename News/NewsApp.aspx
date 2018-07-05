<%@ Page Language="VB" AutoEventWireup="false" CodeFile="NewsApp.aspx.vb" Inherits="News_NewsApp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #394025;
        }

        .panel-style2 {
            width: 50%;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <img alt="" src="../Images/Headings/news.jpg" style="width: 100%" />
        </div>

        <div style="background-color: #FFFFFF">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

        </div>
    </form>
</body>
</html>
