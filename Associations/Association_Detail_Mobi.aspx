<%@ Page Title="" Language="VB" AutoEventWireup="false" MasterPageFile="~/MasterPageMobi.master" CodeFile="Association_Detail_Mobi.aspx.vb" Inherits="Associations_Association_Detail_Mobi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        body {
            background-color: #424531;
            font-family: Calibri;
        }

        .style-profile {
            width: 276px;
            height: 276px;
        }

        .divDetails {
            border: 1px solid #8d9296;
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div style="font-size: 48px; width: 100%;">
        <div style="font-size: 48px; width: 100%;">
            <div>&nbsp;</div>
            <div style="border: 1px solid #333333; padding: 10px 10px 12px 10px; background-color: #E2E2E2; display: inline-block; width: 95%">
                <div style="display: inline-block; font-size: 60px;">
                    <asp:Label ID="lblHeading" runat="server"></asp:Label></div>
                <div style="text-align: right; display: inline-block;"></div>
            </div>
            <div>&nbsp</div>
        </div>
        <div style="font-size: 48px; background-color: #ffffff; padding: 10px 10px 10px 10px;">
            <div style="display: inline-block; width: 300px; height: 300px">
                <asp:Image ID="Image1" runat="server" Width="290px" Height="290px" /></div>
            <div style="display: inline-block; vertical-align: top; padding-left: 10px; padding-top: 20px; padding-right: 50px; width: 100%">
                <asp:Label ID="lblShort" runat="server"></asp:Label>
            </div>
            <div>&nbsp</div>
            <div style="display: inline-block; width: 100%; vertical-align: top">
                <asp:Label ID="lblLong" runat="server" Text=""></asp:Label></div>
            <div>&nbsp</div>
            <div style="border-width: thin; border-color: #333333; display: inline-block; width: 100%; padding-left: 20px; vertical-align: top; border-left-style: solid;">
                <div id="divContact" style="padding-bottom: 20px; border-bottom-style: solid; border-width: thin; border-color: #333333">
                    <div style="font-weight: bold">Contact Details</div>
                    <div>&nbsp;</div>
                    <div>Tel:<asp:Label ID="lblTel" runat="server" Text=""></asp:Label></div>
                    <div>Email:<asp:Label ID="lblEmail" runat="server" Text=""></asp:Label></div>
                </div>
                <div id="divEvent" runat="server" style="padding-top: 10px; padding-bottom: 20px">
                    <div style="font-weight: bold">Next Event:</div>
                    <div>
                        <asp:Label ID="lblNextEvent" runat="server" Text="No Current event registered"></asp:Label></div>
                    <div id="divBook" runat="server">
                        <asp:Button ID="btnBook" runat="server" Text="View" BackColor="White" BorderStyle="None" Style="cursor: pointer" Font-Bold="True" Font-Size="48px" /></div>
                    <div>&nbsp;</div>
                    <div>
                        <asp:Button ID="btnCalander" runat="server" Text="Calendar" BackColor="White" BorderStyle="None" Style="cursor: pointer" Font-Bold="True" Visible="False" /></div>
                </div>
                <div style="border-width: thin; border-color: #333333; padding-top: 10px; padding-bottom: 20px; border-top-style: solid;">
                    <div id="divJoin" runat="server" visible="true">
                        <asp:Button ID="btnJoin" runat="server" Text="Join this association" BackColor="White" BorderStyle="None" Style="cursor: pointer" Font-Bold="True" Font-Size="48px" />
                    </div>
                    <div id="divMember" runat="server" visible="false">
                        <div style="padding-bottom: 10px">You are a member of this association</div>

                        <div>
                            Member No:
                            <asp:Label ID="lblMembershipNr" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="padding-top: 10px; padding-bottom: 10px; font-weight: bold;">Your activities with this association:</div>
                        <div>
                            <asp:Button ID="Button1" runat="server" Text="View Activities" BackColor="White" BorderStyle="None" Style="cursor: pointer" Font-Bold="True" Font-Size="48px" /></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
