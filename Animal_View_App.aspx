<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Animal_View_App.aspx.vb" Inherits="Animal_View_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: #424531;
        }

        #mainPageWrapper1 {
            text-align: center;
            font-family: Calibri;
        }

        .MainImage-style {
            width: 171px;
            height: 180px;
        }

        .Geninfo-style {
            width: 1056px;
            align-content: center;
        }

        .img-style2 {
            width: 150px;
            height: 150px;
        }

        .div_details1 {
            display: inline-block;
            vertical-align: top;
            width: 800px;
            text-align: left;
            padding-left: 5px;
            padding-right: 5px;
            border: thin solid #333333
        }

        .name-style3 {
            width: 75%;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div style="border: 1px solid #333333; padding: 10px 10px 12px 10px; background-color: #E2E2E2; font-size: large; display: inline-block; width: 98%">
            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
        </div>
    </form>
</body>
</html>
