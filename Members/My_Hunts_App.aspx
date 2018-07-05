<%@ Page Language="VB" AutoEventWireup="false" CodeFile="My_Hunts_App.aspx.vb" Inherits="Members_My_Hunts_App" %>

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
            font-size: medium;
            /*background-color: #FFFFFF;*/
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            font-family: Calibri;
            color: #333333;
        }

        .header_icon {
            width: 32px;
            height: 32px;
            vertical-align: middle;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <div>
                <img alt="" src="../Images/Headings/my-hunts.jpg" style="width: 100%" />
            </div>

            <div style="text-align: center" class="divDetails">
                <div class="page_block">
                    <div style="text-align: left; padding-left: 20px; padding-right: 20px; background-color: #5B6849; color: #FFFFFF;">
                        <div>&nbsp;</div>
                        <div>
                            <asp:CheckBox ID="CheckBox2" runat="server" TextAlign="Left" Text="Show history hunts" />
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <asp:Button ID="Button1" runat="server" Text="Refresh" CssClass="button" />
                        </div>
                        <div>&nbsp;</div>
                    </div>
                    <div>&nbsp;</div>
                    <div style="text-align: left">
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
                    <div>
                    </div>
                </div>
            </div>
        </div>


        <div>&nbsp;</div>



    </form>
</body>
</html>
