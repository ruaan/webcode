<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="member_view.aspx.vb" Inherits="member_view" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <link href="StyleSheets/lightbox.css" rel="stylesheet" />
    <style type="text/css">
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
            width: 800px;
            text-align: left;
            padding-left: 5px;
            padding-right: 5px;
        }

        .div_side_block {
            display: inline-block;
            vertical-align: top;
            width: 400px;
            text-align: left;
            padding-left: 5px;
            padding-right: 5px;
        }

        .flight-textbox-style {
            width: 300px;
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
            height: 124px;
            width: 124px;
        }

        .Label_Style {
            border: thin solid #000000;
            border-radius: 5px;
            padding: 3px;
            height: 20px;
        }

        .rateStar {
            width: 28px;
            height: 28px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>&nbsp;</div>
    <div id="mainPageWrapper">
        <div id="mainBlock" class="div_MainBlock">
            <div class="div_details">
                <div style="border: 1px solid #333333; padding: 10px 10px 12px 10px; background-color: #E2E2E2; font-size: x-large; display: inline-block; width: 780px">
                    <div style="display: inline-block; width: 540px;">
                        <asp:Label ID="lblHeading" runat="server"></asp:Label>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div id="ind_Pic_block" style="border: 1px solid #333333; padding: 5px; background-color: #CCCCCC;">
                    <div style="display: inline-block;">
                        <asp:Image ID="Image1" runat="server" Height="200px" Width="200px" />
                    </div>
                    <div style="display: inline-block;">
                        <div style="padding-right: 0px; padding-bottom: 5px; padding-left: 5px;">
                            <div>
                                <asp:Label ID="lblCellNo" runat="server"></asp:Label>
                            </div>
                            <div>
                                <asp:Label ID="lblEmail" runat="server"></asp:Label>
                            </div>
                            <div style="color: #808080; font-size: medium;">&nbsp;</div>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div style="background-color: #CCCCCC">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
                <asp:HiddenField ID="HiddenType" runat="server" />
                <asp:HiddenField ID="HiddenFarmId" runat="server" />
                <div>&nbsp;</div>
            </div>
        </div>
    </div>
    <div>&nbsp;<asp:Button ID="btnTabClick" runat="server" BackColor="White" BorderStyle="None" /></div>
    <script src="Scripts/lightbox-plus-jquery.js"></script>
    <script type="text/javascript">
        function ToggleDetails(Type) {

            var hiddenType = document.getElementById('<%= HiddenType.ClientID %>');
            hiddenType.value = Type;

            var btnType = document.getElementById('<%= btnTabClick.ClientID %>');
            btnType.click();
        }
    </script>
    <script>
        function toggle_visibility(id, counter) {
            for (i = 0; i < counter + 1; i++) {
                try {
                    var e = document.getElementById(id + i);
                    if (e.style.display == 'block')
                        e.style.display = 'none';
                    else
                        e.style.display = 'block';
                } catch (err) {

                }

            }


        }
    </script>
</asp:Content>

