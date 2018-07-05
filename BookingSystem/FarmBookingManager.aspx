<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="FarmBookingManager.aspx.vb" Inherits="BookingSystem_FarmBookingManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>&nbsp;</div>
    <div id="mainPageWrapper">
        <div class="div_MainBlock" style="text-align: left; align-content: center">
            <div>&nbsp;</div>
            <div id="divDetails" class="div_Details">
                <div class="h1">Bookings System - Event Manager</div>
                <div>&nbsp;</div>

                <div>
                    <asp:Panel ID="pnlFarmSelect" runat="server" Visible="True">
                        &nbsp;Farms:
                        <asp:DropDownList ID="cmbFarms" runat="server" AutoPostBack="True" DataTextField="FarmName" DataValueField="id"></asp:DropDownList>
                    </asp:Panel>
                </div>
                <div>&nbsp;</div>
                <div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

