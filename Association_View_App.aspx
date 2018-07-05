<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Association_View_App.aspx.vb" Inherits="Association_View_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #424531;
            margin: 0;
        }

        .style-profile {
            width: 276px;
            height: 276px;
        }

        .divDetails {
            padding: 4px;
            font-size: medium;
            background-color: #424531;
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

        .Animal_Pic {
            height: 100px;
            width: 100px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div id="divDetails" class="divDetails" style="color: #333333">
                <div>
                    <img alt="" src="Images/Headings/associations.jpg" style="width: 100%" />
                </div>

                <div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>

            </div>
        </div>
    </form>
</body>
</html>
