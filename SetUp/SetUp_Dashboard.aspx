<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="SetUp_Dashboard.aspx.vb" Inherits="SetUp_SetUp_Dashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .thisContainer {
            vertical-align: top;
            height: 100vh;
        }

        .thisBody {
            vertical-align: top;
            display: inline-block;
        }

        .divSideMenu {
            display: inline-block;
            background-color: #000000;
            height: 100vh;
            width: 20%;
        }


        .spaceblock {
            width: 13px;
            display: inline-block;
        }

        .WizBlock {
            width: 125px;
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="thisContainer">


        <div id="divBody" class="thisBody">Dashboard</div>
        <div>&nbsp;</div>
        <div>
            <div class="auto-style3">&nbsp;</div>
            <div class="WizBlock" style="padding: 10px; border: thin solid #BBB530;">
                <div class="yellowHeader">
                    Members
                </div>
                <div>&nbsp;</div>
                <div class="divFormMng" style="text-align: center;">
                    <div>Active </br> Members</div>
                    <div style="text-align: center;">
                        <asp:Label ID="lblActiveMembers" runat="server" Text="10"></asp:Label>
                    </div>
                </div>
                <div class="divFormMng">&nbsp;</div>
                <div class="divFormMng" style="text-align: center;">
                    De-activated </br> Members
                     <div style="text-align: center;">
                         <asp:Label ID="lblinactiveMembers" runat="server" Text="2"></asp:Label>
                    </div>

                </div>
                <div>&nbsp;</div>
                <div style="text-align: center;">
                    <asp:Button ID="Button1" runat="server" Text="View More" CssClass="lineButton" />
                </div>
                <div>&nbsp;</div>
            </div>
            <div class="spaceblock">&nbsp;</div>
            <div class="WizBlock" style="padding: 10px; border: thin solid #BBB530;">
                <div class="yellowHeader">
                    Farms
                </div>
                <div>&nbsp;</div>
                <div class="divFormMng">
                    <div style="text-align: center;">Active </br> Farms</div>
                    <div style="text-align: center;">
                        <asp:Label ID="lblActiveFarms" runat="server" Text="3"></asp:Label>
                    </div>
                </div>
                <div class="divFormMng">&nbsp;</div>
                <div class="divFormMng" style="text-align: center;">
                    De-activated </br> Farms
                     <div style="text-align: center;">
                         <asp:Label ID="Label2" runat="server" Text="0"></asp:Label>
                    </div>

                </div>
                <div>&nbsp;</div>
                <div style="text-align: center;">
                    <asp:Button ID="Button2" runat="server" Text="View More" CssClass="lineButton" />
                </div>
                <div>&nbsp;</div>
            </div>
            <div class="spaceblock">&nbsp;</div>
            <div class="spaceblock">&nbsp;</div>
            <div class="WizBlock" style="padding: 10px; border: thin solid #BBB530;">
                <div class="yellowHeader">
                    Bookings 
                </div>
                <div>&nbsp;</div>
                <div class="divFormMng" style="text-align: center;">
                    <div>Active </br> Booking</div>
                    <div style="text-align: center;">
                        <asp:Label ID="Label6" runat="server" Text="0"></asp:Label>
                    </div>
                </div>
                <div class="divFormMng">&nbsp;</div>
                <div class="divFormMng" style="text-align: center;">
                    Booking </br> Value
                     <div style="text-align: center;">
                         <asp:Label ID="Label7" runat="server" Text="0"></asp:Label>
                    </div>

                </div>
                <div>&nbsp;</div>
                <div style="text-align: center;">
                    <asp:Button ID="Button5" runat="server" Text="View More" CssClass="lineButton" Enabled="False" />
                </div>
                <div>&nbsp;</div>
            </div>
            <div class="spaceblock">&nbsp;</div>
            <div class="WizBlock" style="padding: 10px; border: thin solid #BBB530;">
                <div class="yellowHeader">
                    Suppliers
                </div>
                <div>&nbsp;</div>
                <div class="divFormMng">
                    <div style="text-align: center;">Items </br>in Shop</div>
                    <div style="text-align: center;">
                        <asp:Label ID="Label8" runat="server" Text="0"></asp:Label>
                    </div>
                </div>
                <div class="divFormMng">&nbsp;</div>
                <div class="divFormMng" style="text-align: center;">
                    Items </br>in baskets
                     <div style="text-align: center;">
                         <asp:Label ID="Label9" runat="server" Text="0"></asp:Label>
                    </div>

                </div>
                <div>&nbsp;</div>
                <div style="text-align: center;">
                    <asp:Button ID="Button6" runat="server" Text="View More" CssClass="lineButton" Enabled="False" />
                </div>
                <div>&nbsp;</div>
            </div>
            <div class="divFormMng">&nbsp;</div>
        </div>

        <div>&nbsp;</div>
        <div>&nbsp;</div>

    </div>
</asp:Content>

