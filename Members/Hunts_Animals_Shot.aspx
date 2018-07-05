<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Hunts_Animals_Shot.aspx.vb" Inherits="Members_Hunts_Animals_Shot" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        .grid_icon {
            height: 16px;
            width: 16px;
        }

        body {
            background-color: #394025;
            margin: 0;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>&nbsp;</div>
        <div>
            <img alt="" src="../Images/Headings/manage-animals.jpg" />
        </div>
        <div>
            <asp:Label ID="lblFarmId" runat="server" Text="Label"></asp:Label></div>
        <div style="text-align: center; background-color: #FFFFFF;">
            <div style="width: 100%" class="page_block">
                <div>&nbsp;</div>
                <div style="text-align: left; padding-left: 20px; padding-right: 20px;">
                    <div>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="54px" CssClass="button" />
                    </div>
                    <div>&nbsp;</div>

                    <div id="divAdd" runat="server" class="panel" visible="false">
                        <div>Search for animal:
                            <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox" Width="171px"></asp:TextBox><asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/search.png" /></div>
                        <div id="divSearchBlock" runat="server" style="text-align: center">
                            <asp:GridView ID="grdAnimalSearch" runat="server" AutoGenerateColumns="False">
                                <Columns>
                                    <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/select.png" Text="Select" />
                                    <asp:BoundField DataField="id" />
                                    <asp:BoundField DataField="Name" HeaderText="Animal" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div>&nbsp;</div>
                        <div id="divDetail" runat="server" visible="false" style="padding-left: 20px">
                            <div>
                                Add
                                <asp:Label ID="lblAnimalName" runat="server"></asp:Label>
                                <asp:Label ID="lblAnimalId" runat="server" ForeColor="White"></asp:Label>
                            </div>

                            <div>&nbsp;</div>
                            <div>
                                Notes:<br />
                                <asp:TextBox ID="txtNotes" runat="server" TextMode="MultiLine" Width="80%" Height="62px"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>&nbsp;</div>
                            <div style="text-align: center">
                                <asp:Button ID="btnSave" runat="server" Text="Save" CssClass="button" />&nbsp;<asp:Button ID="btnCancel" runat="server" Text="cancel" CssClass="button" />
                            </div>
                        </div>
                    </div>


                </div>
                <div id="divConfirm" runat="server" visible="false" class="panel">
                    <div>Are you sure you want to remove this animal?</div>
                    <div>
                        <asp:Label ID="lblRemoveId" runat="server" ForeColor="White"></asp:Label>
                    </div>
                    <div style="text-align: center">
                        <asp:Button ID="btnRemoveYes" runat="server" Text="Yes" />
                        &nbsp;<asp:Button ID="btnRemoveNo" runat="server" Text="No" />
                    </div>
                </div>
                <div>&nbsp;</div>
                <div>
                    <div style="padding-left: 20px; width: 90%">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="Horizontal" BorderStyle="None" Width="100%">
                            <Columns>
                                <asp:BoundField DataField="id">
                                    <ItemStyle Height="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="Animal">
                                    <ItemStyle Height="20px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Notes" DataField="Notes"></asp:BoundField>
                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/editS.png" Text="Edit" CommandName="Select">
                                    <ItemStyle Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:ButtonField>
                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/deleteS.png" Text="Remove" CommandName="Remove">
                                    <ItemStyle Height="20px" HorizontalAlign="Center" VerticalAlign="Middle" />
                                </asp:ButtonField>
                            </Columns>
                            <RowStyle Height="18px" />
                        </asp:GridView>
                    </div>

                </div>
                <div>&nbsp;</div>
            </div>
        </div>
    </form>
</body>
</html>
