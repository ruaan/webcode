<%@ Page Language="VB" AutoEventWireup="false" CodeFile="package_view_App.aspx.vb" Inherits="package_view_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            margin: 0;
        }

        #mainPageWrapper {
            text-align: center;
            font-family: Calibri;
        }

        .div_MainBlock {
            margin: 0 auto;
        }

        .div_details {
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            padding-left: 5px;
            padding-right: 5px;
        }

        .div_side_block {
            display: inline-block;
            vertical-align: top;
            text-align: left;
            padding-left: 5px;
            padding-right: 5px;
        }

        .flight-textbox-style {
            height: 30px;
            border-style: none;
            background-color: #5B8EC5;
            color: #FFFFFF;
            font-size: large;
        }

        .tab_Left {
            -moz-border-radius: 10px 0px 0px 0px;
            border-radius: 10px 0px 0px 0px;
            display: inline-block;
            padding-top: 15px;
            background-color: #CCCCCC;
            border: 1px solid #CCCCCC;
            text-align: center;
            height: 29px;
            width: 143px;
        }

            .tab_Left:hover {
                background-color: #86B24F;
            }

        .tab_normal {
            display: inline-block;
            padding-top: 15px;
            background-color: #CCCCCC;
            border: 1px solid #CCCCCC;
            text-align: center;
            height: 29px;
            width: 143px;
        }

        .tab_selected {
            display: inline-block;
            padding-top: 15px;
            border: 1px solid #CCCCCC;
            text-align: center;
            height: 29px;
            width: 143px;
        }

            .tab_selected:focus {
                background-color: red;
            }


            .tab_selected:active {
                background-color: yellow;
            }

        .tab_normal:hover {
            background-color: #86B24F;
        }

        .tab_Right {
            -moz-border-radius: 0px 10px 0px 0px;
            border-radius: 0px 10px 0px 0px;
            border: 1px solid #CCCCCC;
            display: inline-block;
            padding-top: 15px;
            background-color: #CCCCCC;
            text-align: center;
            height: 29px;
            width: 143px;
        }

            .tab_Right:hover {
                background-color: #86B24F;
            }

        .div_infoBlock {
            -moz-border-radius: 0px 10px 0px 0px;
            border-radius: 0px 10px 0px 0px;
            border-style: solid;
            border-width: 1px;
            border-color: #CCCCCC;
            padding-left: 10px;
        }

        .auto-style12 {
            width: 221px;
            height: 120px;
        }

        .side-Heading {
            width: 157px;
            display: inline-block;
            font-size: large;
            color: #333333;
            padding-right: 20px;
            vertical-align: top;
        }

        .Animal_Pic {
            height: 80px;
            width: 130px;
        }

        .Label_Style {
            border: thin solid #000000;
            border-radius: 5px;
            padding: 3px;
            height: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>&nbsp;</div>
        <div id="mainPageWrapper">
            <div id="mainBlock" class="div_MainBlock">
                <div class="div_details">
                    <div style="border: 1px solid #333333; padding: 10px 10px 12px 10px; background-color: #E2E2E2; font-size: x-large; display: inline-block; width: 95%">
                        <div style="display: inline-block; width: 98%;">
                            <asp:Label ID="lblHeading" runat="server"></asp:Label>
                        </div>
                    </div>
                    <div>&nbsp;</div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    <asp:HiddenField ID="HiddenType" runat="server" />
                    <asp:HiddenField ID="HiddenFarmId" runat="server" />
                    <div>&nbsp;</div>
                </div>
            </div>
        </div>
        <div>&nbsp;<asp:Button ID="btnTabClick" runat="server" BackColor="White" BorderStyle="None" /></div>

        <script type="text/javascript">
            function ToggleDetails(Type) {

                var hiddenType = document.getElementById('<%= HiddenType.ClientID %>');
                hiddenType.value = Type;

                var btnType = document.getElementById('<%= btnTabClick.ClientID %>');
            btnType.click();
            }
        </script>
    </form>
</body>
</html>
