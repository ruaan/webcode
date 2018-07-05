<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="AssociationEvent.aspx.vb" Inherits="SetUp_AssociationEvent" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .divFormMng {
            display: inline-block;
            vertical-align: top;
        }

        .divMainContainer {
            display: inline-block;
            vertical-align: top;
        }

        .divPagewide {
            vertical-align: top;
        }

        .Column1 {
            width: 200px;
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">

        <ContentTemplate>
            <table width="100%" align="center" celpadding="0" cellspacing="0">
                <tr>
                    <td height="35">Association Events:</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="100%" align="center" celpadding="0" cellspacing="0">
                            <tr>
                                <td height="27" width="15%">Association:</td>
                                <td width="85%">
                                    <asp:DropDownList ID="ddlAssociations" runat="server" Width="250px" DataTextField="Name" DataValueField="Association_Id" AutoPostBack="true"></asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td>&nbsp;</td>
                                <td align="left">
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No events available to select" Width="50%">
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
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

