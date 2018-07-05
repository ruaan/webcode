<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="outfitter_view.aspx.vb" Inherits="outfitter_view" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

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

        .auto-style3 {
            height: 464px;
        }

        .flight-textbox-style {
            width: 300px;
            height: 30px;
            border-style: none;
            background-color: #5B8EC5;
            color: #FFFFFF;
            font-size: large;
        }

        .auto-style4 {
            width: 83px;
            height: 90px;
        }

        .auto-style5 {
            width: 15px;
        }

        .auto-style6 {
            width: 134px;
            height: 90px;
        }

        .auto-style7 {
            width: 760px;
        }

        .auto-style9 {
            width: 332px;
            height: 53px;
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
            height: 1177px;
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

        .headers {
            font-weight: bold;
            font-size: large;
            width: 760px;
        }

        .divMngForm {
            display: inline-block;
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
                    <div style="text-align: right; display: inline-block;">

                        <div style="display: inline-block;">

                            <asp:Image ID="Image5" runat="server" ImageUrl="Images/Icons/favorite-select.png" class="rateStar" Visible="False" />
                            <asp:Image ID="Image6" runat="server" ImageUrl="Images/Icons/favorite-select.png" class="rateStar" Visible="False" />
                            <asp:Image ID="Image7" runat="server" ImageUrl="Images/Icons/favorite-select.png" class="rateStar" Visible="False" />
                            <asp:Image ID="Image8" runat="server" ImageUrl="Images/Icons/favorite-select.png" class="rateStar" Visible="False" />
                            <asp:Image ID="Image9" runat="server" ImageUrl="Images/Icons/favorite-select.png" class="rateStar" Visible="False" />

                        </div>
                        <div style="display: inline-block; color: #CC0000;"><%--(<asp:Label ID="lblRating" runat="server" Text=""></asp:Label>)--%></div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div id="ind_Pic_block" style="border: 1px solid #333333; padding: 5px;">

                    <div style="display: inline-block;">
                        <asp:Image ID="Image1" runat="server" ImageUrl="~/Farms/Images/FarmProfiles/1ProfilePic.jpg" Height="371px" Width="553px" />
                    </div>
                    <div style="display: inline-block;">
                        <div style="padding-right: 0px; padding-bottom: 5px; padding-left: 5px" class="auto-style12">
                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_22.gif" Height="100%" Width="100%" />
                        </div>
                        <div style="padding-right: 0px; padding-bottom: 5px; padding-left: 5px" class="auto-style12">
                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_23.gif" Height="100%" Width="100%" />
                        </div>
                        <div style="padding-right: 0px; padding-bottom: 0px; padding-left: 5px" class="auto-style12">
                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_22.gif" Height="100%" Width="100%" />
                        </div>
                    </div>

                </div>
                <div>&nbsp;</div>
                <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                <asp:HiddenField ID="HiddenType" runat="server" />
                <asp:HiddenField ID="HiddenType1" runat="server" />
                <asp:HiddenField ID="HiddenType2" runat="server" />
                <asp:HiddenField ID="HiddenType3" runat="server" />
                <asp:HiddenField ID="HiddenFarmId" runat="server" />
                <asp:HiddenField ID="HiddenLodgeId" runat="server" />
                <div>&nbsp;</div>

            </div>
        </div>
        <div>&nbsp;<asp:Button ID="btnTabClick" runat="server" BackColor="White" BorderStyle="None" /></div>
        <div>&nbsp;<asp:Button ID="btnTabClick1" runat="server" BackColor="White" BorderStyle="None" /></div>
        <div>&nbsp;<asp:Button ID="btnTabClick2" runat="server" BackColor="White" BorderStyle="None" /></div>

        <script type="text/javascript">
            function ToggleDetails(Type) {

                var hiddenType = document.getElementById('<%= HiddenType.ClientID %>');
                hiddenType.value = Type;

                var btnType = document.getElementById('<%= btnTabClick.ClientID %>');
             btnType.click();
            }
            function ToggleDetails1(Type) {

                var hiddenType1 = document.getElementById('<%= HiddenType1.ClientID %>');
                hiddenType1.value = Type;

                var btnType = document.getElementById('<%= btnTabClick1.ClientID %>');
             btnType.click();
            }
            function ToggleDetails2(LodgeName, Type) {
                var hiddenType2 = document.getElementById('<%= HiddenType2.ClientID %>');
                hiddenType2.value = LodgeName;
                var hiddenType3;
                if (document.getElementById('<%= HiddenType3.ClientID %>').value == '') {
                 hiddenType3 = document.getElementById('<%= HiddenType3.ClientID %>');
                 hiddenType3.value = Type;
             } else {
                 Type = '';
                 hiddenType3 = document.getElementById('<%= HiddenType3.ClientID %>');
                 hiddenType3.value = Type;
             }

             var btnType = document.getElementById('<%= btnTabClick2.ClientID %>');
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

