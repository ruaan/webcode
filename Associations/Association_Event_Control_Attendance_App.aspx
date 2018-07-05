<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Association_Event_Control_Attendance_App.aspx.vb" Inherits="Associations_Association_Event_Control_Attendance_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../StyleSheets/StyleSheetApp.css" type="text/css" />
    <style>
        .divDetails {
            border: 1px solid #8d9296;
            padding: 4px;
            font-size: medium;
            background-color: #FFFFFF;
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            font-family: Calibri;
            color: #333333;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div id="mainPageWrapper">
            <div class="div_MainBlock" style="text-align: left; align-content: center; font-family: Calibri;">
                <div>&nbsp;</div>
                <div id="divDetails" class="div_Details">
                    <div class="divDetails" style="font-size: x-large;">Attendees For
                        <asp:Label ID="lblEventName" runat="server" Text=""></asp:Label><asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></div>
                    <div>&nbsp;</div>
                    <div style="border: thin solid #333333; padding: 10px; background-color: #FFFFFF;" class="auto-style2">
                        <div>Date:
                            <asp:Label ID="lblDate" runat="server" Text=""></asp:Label></div>
                        <div>Time:
                            <asp:Label ID="lblTime" runat="server" Text=""></asp:Label></div>
                        <div>&nbsp;</div>
                        <div>Venue:
                            <asp:Label ID="lblVenue" runat="server" Text=""></asp:Label></div>
                    </div>
                    <div>&nbsp;</div>
                    <div>&nbsp;</div>
                    <div style="background-color: #FFFFFF">
                        <div class="h1" style="font-size: 20px">Attending</div>
                        <asp:GridView ID="GridView1" runat="server" Font-Size="Large" AutoGenerateColumns="False" Width="770px">
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Title" />
                                <asp:BoundField DataField="Initials" HeaderText="Initials" />
                                <asp:BoundField DataField="PreferredName" HeaderText="Name" />
                                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                                <asp:BoundField DataField="CellNo" HeaderText="Mobile No" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="MemberNo" HeaderText="Member No" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div>&nbsp;</div>
                    <div style="background-color: #FFFFFF">
                        <div class="h1" style="font-size: 20px">Maybe</div>
                        <asp:GridView ID="GridView2" runat="server" Font-Size="Large" AutoGenerateColumns="False" Width="770px">
                            <Columns>
                                <asp:BoundField DataField="Title" HeaderText="Title" />
                                <asp:BoundField DataField="Initials" HeaderText="Initials" />
                                <asp:BoundField DataField="PreferredName" HeaderText="Name" />
                                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                                <asp:BoundField DataField="CellNo" HeaderText="Mobile No" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="MemberNo" HeaderText="Member No" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div>
                        &nbsp;
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
