<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Association_Event_Control_Attendance.aspx.vb" Inherits="Associations_Association_Event_Control_Attendance" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 298px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="mainPageWrapper">
        <div class="div_MainBlock" style="text-align: left; align-content: center">
            <div>&nbsp;</div>
            <div id="divDetails" class="div_Details">
                <div class="h1">Attendees For
                    <asp:Label ID="lblEventName" runat="server" Text=""></asp:Label><asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></div>
                <div>&nbsp;</div>
                <div style="border: thin solid #333333; padding: 10px;" class="auto-style2">
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
                <div>
                    <div class="h1">Attending</div>
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
                <div>
                    <div class="h1">Maybe</div>
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
</asp:Content>

