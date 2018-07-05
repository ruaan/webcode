<%@ Page Language="VB" AutoEventWireup="false" CodeFile="FarmAnimalManagementapp.aspx.vb" Inherits="Farms_FarmAnimalManagementapp" %>

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
                    <div style="font-size: x-large">
                        <asp:Panel ID="pnlFarmSelect" runat="server" Visible="True">
                            &nbsp;Farms:
                            <asp:DropDownList ID="cmbFarms" runat="server" AutoPostBack="True" DataTextField="FarmName" DataValueField="id"></asp:DropDownList>
                        </asp:Panel>
                    </div>
                    <div>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" Width="54px" CssClass="button" />
                    </div>
                    <div>
                        Select the Visitors country: 
                        <asp:DropDownList ID="cmbCountry" runat="server" CssClass="textbox" DataSourceID="SqlCountry" DataTextField="Name" DataValueField="Country_Id" AutoPostBack="True"></asp:DropDownList>
                        <asp:SqlDataSource ID="SqlCountry" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Country_Id], [Name] FROM [tblCountries] WHERE ([Active] = @Active) ORDER BY [Name]">
                            <SelectParameters>
                                <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                            </SelectParameters>
                        </asp:SqlDataSource>
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
                                <asp:CheckBox ID="chkAvailHunt" runat="server" Text="Available to hunt" TextAlign="Left" Checked="True" />
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <div style="display: inline-block; text-align: center;">
                                    <div>Male Price </div>
                                    <div>
                                        <asp:TextBox ID="txtMalePrice" runat="server" Width="90px" CssClass="textbox"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="display: inline-block; text-align: center;">
                                    <div>Female Price </div>
                                    <div>
                                        <asp:TextBox ID="txtFemaleProce" runat="server" Width="90px" CssClass="textbox"></asp:TextBox>
                                    </div>
                                </div>

                                <div style="display: inline-block; text-align: center;">
                                    <div>Trophy Price </div>
                                    <div>
                                        <asp:TextBox ID="txtTrophyPrice" runat="server" Width="90px" CssClass="textbox"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="display: inline-block; text-align: center;">
                                    <div>Inches </div>
                                    <div>
                                        <asp:TextBox ID="txtInches" runat="server" Width="90px" CssClass="textbox"></asp:TextBox>
                                    </div>
                                </div>
                            </div>
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
                                    <ItemStyle ForeColor="White" Height="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Name" HeaderText="Animal">
                                    <ItemStyle Height="20px" HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:CheckBoxField DataField="AvailableToHunt" HeaderText="Available to hunt">
                                    <ItemStyle HorizontalAlign="Center" Height="20px" VerticalAlign="Middle" />
                                </asp:CheckBoxField>
                                <asp:BoundField DataField="Male_Price" HeaderText="Male Price">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Height="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Female_Price" HeaderText="Female Price">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Height="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Trophy_Price" HeaderText="Trophy Price">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Height="20px" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Inches" HeaderText="Inches">
                                    <HeaderStyle HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" Height="20px" />
                                </asp:BoundField>
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
