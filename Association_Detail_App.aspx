<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Association_Detail_App.aspx.vb" Inherits="Association_Detail_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #424531;
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
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div>
            <div style="margin: 0 auto; text-align: left; background-color: #FFFFFF; font-family: Calibri; color: #333333;">
                <div>&nbsp;</div>
                <div style="border: 1px solid #333333; padding: 10px 10px 12px 10px; background-color: #E2E2E2; font-size: x-large; display: inline-block; width: 95%">
                    <div style="display: inline-block;">
                        <asp:Label ID="lblHeading" runat="server"></asp:Label>
                    </div>
                    <div style="text-align: right; display: inline-block;">
                    </div>
                </div>
                <div>&nbsp</div>
                <div style="display: inline-block; width: 200px; height: 200px">
                    <asp:Image ID="Image1" runat="server" Height="100%" Width="100%" />
                </div>
                <div style="vertical-align: top; padding-left: 10px; padding-top: 20px; padding-bottom: 10px;">
                    <asp:Label ID="lblShort" runat="server" Font-Bold="True"></asp:Label>
                </div>
                <div style="vertical-align: top">
                    <asp:Label ID="lblLong" runat="server" Text=""></asp:Label>
                </div>
                <div>&nbsp</div>
                <div style="border-width: thin; border-color: #333333; padding-left: 20px; vertical-align: top; border-left-style: solid;">
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
            <div>&nbsp;</div>
            <div>
                <asp:ImageButton ID="btnFarmDescription" runat="server" ImageUrl="~/Images/Icons/backtolist.png" />
            </div>
        </div>
    </form>
</body>
</html>
