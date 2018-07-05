<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Country_Control.aspx.vb" Inherits="SetUp_Country_Control" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="h1" style="color: #FFFFFF;">Country Controls</div>
    <div style="vertical-align: top;" class="divMainContainerBackgroundColour">
        <div id="CountryList" class="divFormMng" style="width: 30%; vertical-align: top; background-color: #FFFFFF; padding-left: 20px; padding-top: 10px;">
            <div>
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="lineButton" />
            </div>
            <div>&nbsp;</div>
            <div>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox><asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="~/Images/Icons/search.png" />
            </div>
            <div>&nbsp;</div>
            <asp:GridView ID="grdCountries" runat="server" AutoGenerateColumns="False" GridLines="None" EmptyDataText="No Countries" ShowHeader="False">
                <Columns>
                    <asp:BoundField DataField="Country_Id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                        <ItemStyle ForeColor="#494D50" Width="15px" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" SortExpression="Description" />
                    <asp:ButtonField ButtonType="Image" CommandName="View" ImageUrl="~/Images/Icons/edit.png" Text="Edit" />
                    <asp:ButtonField ButtonType="Image" CommandName="remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove" />
                </Columns>
            </asp:GridView>
        </div>
        <div runat="server" visible="false" id="divDetails" class="divFormMng" style="border: thin solid #BBB530; width: 60%; vertical-align: top; padding-left: 10px; background-color: #FFFFFF;">
            <div class="yellowHeader" style="font-size: large; font-weight: bold">Details</div>
            <div>&nbsp;<asp:Label ID="lblCountryId" runat="server"></asp:Label></div>
            <div class="divFormMng" style="width: 100%">
                <div>Name</div>
                <div>
                    <asp:TextBox ID="txtName" runat="server" CssClass="textbox" Width="90%"></asp:TextBox>

                </div>
            </div>

            <div>&nbsp;</div>
            <div style="padding: 10px; display: inline-block">
                <div>
                    Currency Code
                </div>
                <div>
                    <asp:TextBox ID="txtCurrencyCode" runat="server" Width="78px" CssClass="textbox"></asp:TextBox>
                </div>
            </div>
            <div style="padding: 10px; display: inline-block">
                <div>
                    Currency Symbol
                </div>
                <div>
                    <asp:TextBox ID="txtCurencySymbol" runat="server" Width="78px" CssClass="textbox"></asp:TextBox>
                </div>

            </div>
            <div>&nbsp;</div>
            <div>&nbsp;</div>


            <div>&nbsp;</div>
            <div style="text-align: center">
                <asp:Button ID="btnUpdateDescription" runat="server" Text="Update" CssClass="button" /><asp:Label ID="lblUpdateCountry" runat="server"></asp:Label>&nbsp; &nbsp;<asp:Button ID="btnClose" runat="server" Text="Close" CssClass="button" />
            </div>
            <div>&nbsp;</div>
            <div>
                <div style="width: 60%; vertical-align: top; padding-left: 10px; background-color: #FFFFFF; font-weight: bold; font-size: large;">Provinces/ States/ Areas/ Regions</div>
                <div>&nbsp;</div>
                <div>
                    <asp:Button ID="btnAddProvince" runat="server" Text="Add" CssClass="lineButton" />
                </div>

                <div id="addProvince" runat="server" class="panel" style="width: 60%" visible="false">
                    <div>
                        <asp:Label ID="lblProvinceId" runat="server"></asp:Label>
                    </div>
                    <div>
                        Name:
                        <asp:TextBox ID="txtProvinceNameAdd" runat="server" CssClass="textbox" Width="80%"></asp:TextBox>
                    </div>

                    <div>&nbsp;</div>
                    <div>
                        <asp:Button ID="btnSaveProvince" runat="server" Text="Save" CssClass="button" />
                        &nbsp; &nbsp;<asp:Button ID="btnProvinceCancel" runat="server" Text="Cancel" CssClass="button" />
                        <asp:Label ID="lblProvineUpdate" runat="server"></asp:Label>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div>
                    <div id="divprovinceRemoveConfirm" runat="server" visible="false" style="border: thin solid #BBB530; background-color: #FFFFFF;" class="divFormMng">
                        <div id="divareUsureProvince" runat="server" visible="false">
                            Are you sure you want to remove this Province? &nbsp; this action cannot be undone.
                <div style="text-align: center">
                    <asp:Button ID="Button1" runat="server" Text="Yes" CssClass="nextPrevButton" /><asp:Label ID="lblProvinceDelId" runat="server" ForeColor="White"></asp:Label><asp:Button ID="Button2" runat="server" Text="No" CssClass="nextPrevButton" />
                            </div>
                            <div>&nbsp</div>
                        </div>
                        <div id="divDeniedProvince" runat="server">
                            This Province is linked to the following farms and can therefore not be deleted.
                <div>&nbsp</div>
                            <div>

                                <asp:GridView ID="grdProvinceFarms" runat="server" AutoGenerateColumns="False" GridLines="None" EmptyDataText="No Farms" ShowHeader="False">
                                    <Columns>
                                        <asp:BoundField DataField="FarmName"></asp:BoundField>
                                    </Columns>
                                </asp:GridView>

                            </div>
                            <div>&nbsp</div>
                            <div style="text-align: center">
                                <asp:Button ID="Button3" runat="server" Text="OK" CssClass="nextPrevButton" />
                            </div>
                            <div>&nbsp</div>
                        </div>



                    </div>
                </div>
                <div>
                    <asp:GridView ID="grdProvinces" runat="server" AutoGenerateColumns="False" GridLines="None" EmptyDataText="No Provinces" ShowHeader="False">
                        <Columns>
                            <asp:BoundField DataField="ProvinceId" InsertVisible="False" ReadOnly="True" SortExpression="ProvinceId">
                                <ItemStyle ForeColor="White" Width="15px" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Name" SortExpression="Description" />
                            <asp:ButtonField ButtonType="Image" CommandName="View" ImageUrl="~/Images/Icons/edit.png" Text="Edit" />
                            <asp:ButtonField ButtonType="Image" CommandName="remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove" />
                        </Columns>
                    </asp:GridView>
                </div>
                <div>&nbsp;</div>
            </div>
        </div>
        <div id="divConfirmDelete" runat="server" visible="false" style="border: thin solid #BBB530; background-color: #FFFFFF;" class="divFormMng">
            <div id="divareUsure" runat="server" visible="false">
                Are you sure you want to remove this Country? &nbsp; this action cannot be undone.
                <div style="text-align: center">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="nextPrevButton" /><asp:Label ID="lblDelNote" runat="server" ForeColor="White"></asp:Label><asp:Button ID="btnNo" runat="server" Text="No" CssClass="nextPrevButton" />
                </div>
                <div>&nbsp</div>
            </div>
            <div id="divDenied" runat="server">
                This Country is linked to the following farms and can therefore not be deleted.
                <div>&nbsp</div>
                <div>

                    <asp:GridView ID="grdfarms" runat="server" AutoGenerateColumns="False" GridLines="None" EmptyDataText="No Farms" ShowHeader="False">
                        <Columns>
                            <asp:BoundField DataField="FarmName"></asp:BoundField>
                        </Columns>
                    </asp:GridView>

                </div>

                <div>&nbsp</div>
                <div style="text-align: center">
                    <asp:Button ID="btnOk" runat="server" Text="OK" CssClass="nextPrevButton" />
                </div>
                <div>&nbsp</div>
            </div>
            <div id="divProvinceLinkedDenied" runat="server" visible="false">
                The Country has provinces linked to it and can therefore not be deleted. First remove the provinces.
    <div style="text-align: center">
        <asp:Button ID="Button4" runat="server" Text="OK" />
    </div>
            </div>
        </div>

    </div>
    <div>&nbsp</div>
    <div></div>
</asp:Content>

