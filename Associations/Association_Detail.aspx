<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Association_Detail.aspx.vb" Inherits="Associations_Association_Detail" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">

    <div id="mainPageWrapper">
        <div style="width: 800px; margin: 0 auto; text-align: left">
            <div>&nbsp;</div>
            <div style="border: 1px solid #333333; padding: 10px 10px 12px 10px; background-color: #E2E2E2; font-size: x-large; display: inline-block; width: 780px">
                <div style="display: inline-block; width: 540px;">
                    <asp:Label ID="lblHeading" runat="server"></asp:Label>
                </div>
                <div style="text-align: right; display: inline-block;">
                </div>
            </div>
            <div>&nbsp</div>
            <div style="display: inline-block; width: 300px; height: 300px">
                <asp:Image ID="Image1" runat="server" Height="100%" Width="100%" />
            </div>
            <div style="display: inline-block; vertical-align: top; padding-left: 10px; padding-top: 20px; width: 480px">
                <asp:Label ID="lblShort" runat="server" Font-Bold="True"></asp:Label>
            </div>
            <div style="display: inline-block; width: 490px; vertical-align: top">
                <asp:Label ID="lblLong" runat="server" Text=""></asp:Label>
            </div>
            <div style="border-width: thin; border-color: #333333; display: inline-block; width: 280px; padding-left: 20px; vertical-align: top; border-left-style: solid;">
                <div id="divContact" style="padding-bottom: 20px; border-bottom-style: solid; border-width: thin; border-color: #333333">
                    <div style="font-size: large; font-weight: bold">Contact Details</div>
                    <div>&nbsp;</div>
                    <div>
                        Tel:
                        <asp:Label ID="lblTel" runat="server" Text=""></asp:Label>
                    </div>
                    <div>
                        Email:
                        <asp:Label ID="lblEmail" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div id="divEvent" runat="server" style="padding-top: 10px; padding-bottom: 20px">
                    <div style="font-weight: bold">Next Event:</div>
                    <div>
                        <asp:Label ID="lblNextEvent" runat="server" Text="No Current event registered"></asp:Label>
                    </div>
                    <div id="divBook" runat="server">
                        <asp:Button ID="btnBook" runat="server" Text="View" BackColor="White" BorderStyle="None" Style="cursor: pointer" Font-Bold="True" />
                    </div>
                    <div>&nbsp;</div>
                    <div>
                        <asp:Button ID="btnCalander" runat="server" Text="Calendar" BackColor="White" BorderStyle="None" Style="cursor: pointer" Font-Bold="True" Visible="False" />
                    </div>

                </div>
                <div style="border-width: thin; border-color: #333333; padding-top: 10px; padding-bottom: 20px; border-top-style: solid;">
                    <div id="divJoin" runat="server" visible="true">
                        <asp:Button ID="btnJoin" runat="server" Text="Join this association" BackColor="White" BorderStyle="None" Style="cursor: pointer" Font-Bold="True" />
                    </div>
                    <div id="divMember" runat="server" visible="false">
                        <div style="padding-bottom: 10px">You are a member of this association</div>

                        <div>
                            Member No:
                            <asp:Label ID="lblMembershipNr" runat="server" Text=""></asp:Label>
                        </div>
                        <div style="padding-top: 10px; padding-bottom: 10px; font-weight: bold;">Your activities with this association:</div>
                        <div>
                            <asp:Button ID="Button1" runat="server" Text="View Activities" BackColor="White" BorderStyle="None" Style="cursor: pointer" Font-Bold="True" /></div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

