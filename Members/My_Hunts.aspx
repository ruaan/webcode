<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="My_Hunts.aspx.vb" Inherits="Members_My_Hunts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>&nbsp;</div>
    <div class="h1">My Hunts</div>
    <div>&nbsp;</div>
    <div style="text-align: center">
        <div style="width: 60%; background-color: #CCCCCC;" class="page_block">
            <div style="text-align: left; padding-left: 20px; padding-right: 20px;">
                <div>&nbsp;</div>
                <div>
                    <asp:CheckBox ID="CheckBox2" runat="server" TextAlign="Left" Text="Show history hunts" />
                </div>
                <div>&nbsp;</div>
                <div>
                    <asp:Button ID="Button1" runat="server" Text="Refresh" CssClass="button" />
                </div>
            </div>
            <div>&nbsp;</div>
            <div>
                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" BorderStyle="None" Width="100%">
                    <Columns>
                        <asp:BoundField DataField="HuntId">
                            <ItemStyle ForeColor="White" Height="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="UniqueName" HeaderText="Hunt">
                            <ItemStyle Height="20px" HorizontalAlign="Left" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Date_From" HeaderText="Date From" DataFormatString="{0:dd/MM/yyyy}" HtmlEncode="False">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Height="20px" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Date_To" DataFormatString="{0:dd/MM/yyyy}" HeaderText="Date To" HtmlEncode="False" />
                        <asp:BoundField DataField="Description" HeaderText="Status">
                            <HeaderStyle HorizontalAlign="Right" />
                            <ItemStyle HorizontalAlign="Right" Height="20px" />
                        </asp:BoundField>
                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/editS.png" Text="Edit" CommandName="Select">
                            <ItemStyle Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" />
                        </asp:ButtonField>
                    </Columns>
                    <RowStyle Height="18px" />
                </asp:GridView>
            </div>
        </div>
    </div>

</asp:Content>

