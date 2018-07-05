<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AssociationEvent_App.aspx.vb" Inherits="SetUp_AssociationEvent_App" %>

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
        <div>
            <table width="100%" align="center" celpadding="0" cellspacing="0">
                <tr>
                    <td height="35">
                        <div class="divDetails" style="font-size: x-large;">Association Events:</div>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" align="center" celpadding="0" cellspacing="0">
                            <tr style="background-color: #FFFFFF">
                                <td height="27" width="15%">Association:</td>
                                <td width="85%">
                                    <asp:DropDownList ID="ddlAssociations" runat="server" Width="250px" DataTextField="Name" DataValueField="Association_Id" AutoPostBack="true"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No events available to select" Width="100%" BackColor="White">
                                        <Columns>
                                            <asp:ButtonField ButtonType="Button" Text="Select" ControlStyle-CssClass="button" CommandName="View"></asp:ButtonField>
                                            <asp:BoundField DataField="event_id" HeaderText="Id" />
                                            <asp:BoundField DataField="Event_Name" HeaderText="Event Name" />
                                            <asp:BoundField DataField="EventType" HeaderText="EventType" />
                                            <asp:BoundField DataField="EventDate" HeaderText="EventDate" DataFormatString="{0:yyyy/MM/dd}" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>
