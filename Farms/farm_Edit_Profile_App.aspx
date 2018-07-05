<%@ Page Language="VB" AutoEventWireup="false" CodeFile="farm_Edit_Profile_App.aspx.vb" Inherits="Farms_farm_Edit_Profile_App" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>

    <style>
        .buttonHidden {
            border: none;
            background-color: white;
        }

        .buttonUpdate {
            background-color: #3E432F;
            border: none;
            color: white;
            width: 72px;
            cursor: pointer;
        }

        .lineButton {
            background-color: white;
            border-style: none;
            color: #7DB15C;
            cursor: pointer;
        }

        .selectbar {
            border-top: 2px solid white;
            border-bottom: 2px solid white;
            padding: 5px;
            display: inline-block;
            width: 100%;
            cursor: pointer;
            background-color: #e2e2e2;
            vertical-align: middle;
            border-left-color: white;
            border-left-width: 2px;
            border-right-color: white;
            border-right-width: 2px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div style="font-size: 14px; font-family: Calibri; color: #333333">
            <div class="h1" style="font-size: 18px">Manage Farm Profile</div>
            <div>
                <asp:Panel ID="pnlFarmSelect" runat="server" Visible="True">
                    &nbsp;Farms:
                    <asp:DropDownList ID="cmbFarms" runat="server" AutoPostBack="True" DataTextField="FarmName" DataValueField="id"></asp:DropDownList>
                </asp:Panel>
            </div>
            <div>
                &nbsp;
                <asp:Label ID="lblFarmId" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblFarmName" runat="server"></asp:Label>
            </div>
            <div id="divAllBlock" runat="server" style="">
                <div id="divDetails" runat="server" style="border-width: thin; border-color: #838383; vertical-align: top; padding-right: 20px; border-right-style: solid; width: 100%">

                    <div style="background-color: #86B250; color: #FFFFFF; font-size: large; font-family: Calibri;" id="divLocationHdr1" class="selectbar" onclick="showPanel('<%=btnFarmDescription.ClientID %>')">
                        <div class="auto-style8" style="display: inline-block">Farm Description</div>
                        <div style="display: inline-block">
                            <asp:Image ID="imgFarmDesc" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />
                        </div>
                    </div>
                    <asp:Panel ID="pnlFarmDesc" runat="server" Visible="False">
                        <div id="divDescriptHdr">
                            <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" id="divLocationHdr" class="auto-style3" onclick="showPanel('<%=btnfarmDescDetail.ClientID %>')">
                                <div style="display: inline-block" class="auto-style5">
                                    <img alt="" src="../Images/Icons/numDown1.png" />&nbsp; General Farm Description
                                </div>
                                <div style="display: inline-block">
                                    <asp:Image ID="imgfarmDescDetail" runat="server" ImageUrl="~/Images/Icons/numDown.png" />
                                </div>
                            </div>
                            <div id="divfarmDescDetail" class="auto-style9" runat="server" visible="false">
                                <div>&nbsp;</div>
                                <div>
                                    <div>Short Farm Description</div>
                                    <div>This is the Text that will appear on the thumbnail when hunters searches for farms. (Max 200 Characters)</div>
                                    <div>
                                        <asp:TextBox ID="txtShortDescription" runat="server" MaxLength="200" TextMode="MultiLine" Height="64px" Width="90%" CssClass="textbox"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div>
                                    <div>Farm Description</div>
                                    <div>This is the Text that will appear on the full page when hunters selects your farms.</div>
                                    <div>
                                        <asp:TextBox ID="txtLongDescription" runat="server" TextMode="MultiLine" Height="218px" Width="90%" CssClass="textbox"></asp:TextBox>
                                    </div>
                                </div>
                                <div>&nbsp;</div>
                                <div style="text-align: right">
                                    <asp:Label ID="lblDescriptionSubmitMesg" runat="server"></asp:Label>
                                    <asp:Button ID="btnUpdateDescription" runat="server" Text="Update" BackColor="#3E432F" BorderStyle="None" ForeColor="White" Width="72px" />
                                    <asp:Image ID="imgUpdateDescription" runat="server" ImageUrl="~/Images/Icons/correct.png" Visible="False" />
                                </div>
                                <div>&nbsp;</div>
                            </div>
                            <div class="auto-style10">&nbsp;</div>
                            <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" id="divLocationHdr3" class="auto-style3" onclick="showPanel('<%=btnFeatures.ClientID %>')">
                                <div style="display: inline-block" class="auto-style6">
                                    <img alt="" src="../Images/Icons/numDown1.png" />&nbsp; Natural Features & Terrain
                                </div>
                                <div style="display: inline-block" class="auto-style7">
                                    <asp:Image ID="imgTerrain" runat="server" ImageUrl="~/Images/Icons/numDown.png" />
                                </div>
                            </div>
                            <asp:Panel ID="pnlTerrain" runat="server" Visible="False" Width="648px">
                                <div>&nbsp;</div>
                                <div style="text-align: left">
                                    <div>
                                        Hectares within game fencing:  
                                    <asp:TextBox ID="txtHectare" runat="server" CssClass="textbox" Width="62px"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="text-align: left" class="divFormMng">
                                    <div>
                                        % Savannah:  
                                    <asp:TextBox ID="txtSavannah" runat="server" CssClass="textbox" Width="62px"></asp:TextBox>
                                        <img id="numUp" alt="" src="../Images/Icons/numUp.png" /><img id="numDown" alt="" src="../Images/Icons/numDown.png" />
                                        <cc1:NumericUpDownExtender ID="txtSavannah_NumericUpDownExtender" runat="server" Maximum="100" Minimum="0" RefValues="" Tag="0" TargetControlID="txtSavannah" Width="30" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID="numDown" TargetButtonUpID="numUp" BehaviorID="_content_txtSavannah_NumericUpDownExtender" ServiceDownPath=""></cc1:NumericUpDownExtender>
                                    </div>
                                </div>
                                <div class="divFormMng" style="width: 5px">&nbsp;</div>
                                <div style="text-align: center" class="divFormMng">
                                    <div>
                                        % Mountain & Hills:  
                                    <asp:TextBox ID="txtMountains" runat="server" CssClass="textbox" Width="62px"></asp:TextBox>

                                        <img id="numUp1" alt="" src="../Images/Icons/numUp.png" /><img id="numDown1" alt="" src="../Images/Icons/numDown.png" />

                                        <cc1:NumericUpDownExtender ID="txtMountains_NumericUpDownExtender1" runat="server" Maximum="100" Minimum="0" RefValues="" Tag="0" TargetControlID="txtMountains" Width="30" ServiceDownMethod="" ServiceUpMethod="" TargetButtonDownID="numDown1" TargetButtonUpID="numUp1" BehaviorID="_content_txtMountains_NumericUpDownExtender1" ServiceDownPath=""></cc1:NumericUpDownExtender>

                                    </div>
                                </div>
                                <div class="divFormMng" style="width: 10%">&nbsp;</div>
                                <div>&nbsp;</div>
                                <div style="text-align: center" class="divFormMng">
                                    <div>
                                        <asp:CheckBox ID="chkRivers" runat="server" Text="Rivers?" TextAlign="Left" />
                                    </div>
                                </div>
                                <div class="divFormMng" style="width: 10px">&nbsp;</div>

                                <div style="text-align: center" class="divFormMng">
                                    <div>
                                        <asp:CheckBox ID="chkLakes" runat="server" Text="Natural Lakes?" TextAlign="Left" />
                                    </div>
                                </div>
                                <div class="divFormMng" style="width: 10px">&nbsp;</div>
                                <div style="text-align: center" class="divFormMng">
                                    <asp:CheckBox ID="chkDam" runat="server" Text="Dam?" TextAlign="Left" />
                                </div>
                                <div class="divFormMng" style="width: 10px">&nbsp;</div>
                                <div>&nbsp;</div>
                                <div style="text-align: right">
                                    <asp:Label ID="lblUpdateTerrainMsg" runat="server"></asp:Label>
                                    <asp:Button ID="btnUpdateTerrain" runat="server" Text="Update" CssClass="buttonUpdate" />
                                    <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icons/correct.png" Visible="False" />
                                </div>
                                <div>&nbsp;</div>
                            </asp:Panel>
                            <div class="auto-style10">&nbsp;</div>
                        </div>
                    </asp:Panel>
                     <div style="background-color: #86B250; color: #FFFFFF; font-size: large; font-family: Calibri;"" id="divFacilitiesbtn1"  class="selectbar" onclick="showPanel('<%=btnFacilities.ClientID %>')">
                        <div style="display: inline-block" class="auto-style8">Facilities & Amenities</div>
                        <div style="display: inline-block">
                             <asp:Image ID="imgFacilities" runat="server" ImageUrl="~/Images/Icons/numDown1.png" /> 
                        </div>
                    </div>
                    <div id="divFacilitiesHdr" runat="server" visible="false">
                        <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" id="divLocationHdr4" class="auto-style3" onclick="showPanel('<%=btnfacilitiesDetail.ClientID %>')">
                            <div style="display: inline-block" class="auto-style6">
                                <img alt="" src="../Images/Icons/numDown1.png" />&nbsp; Facilities
                            </div>
                            <div style="display: inline-block" class="auto-style7">
                                <asp:Image ID="imgFacilitiesDet" runat="server" ImageUrl="~/Images/Icons/numDown.png" />
                            </div>
                        </div>
                        <asp:Panel ID="pnlFacilitiesDetail" runat="server" Visible="False" Width="650px">
                            <div>&nbsp;</div>
                            <div>Please indicate what facilities your farm has available.</div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:GridView ID="grdFacilities" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="sqlFacilities" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                            <ItemStyle ForeColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="FacilityType" HeaderText="Description" SortExpression="Description" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkFacility" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="sqlFacilities" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT id, FacilityType FROM [tbl_Facility_Types] WHERE Active = 'True'"></asp:SqlDataSource>
                            </div>
                            <div>&nbsp;</div>
                            <div style="text-align: right">
                                <asp:Label ID="lblFacilitySubmitMsg" runat="server"></asp:Label><asp:Button ID="btnUpdateFacilities" runat="server" Text="Update" CssClass="buttonUpdate" /><asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icons/correct.png" Visible="False" />
                            </div>
                            <div class="auto-style10">&nbsp;</div>
                        </asp:Panel>
                        <div class="auto-style10">&nbsp;</div>
                        <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" id="divLocationHdr5" class="auto-style3" onclick="showPanel('<%=btnSpecificFeature.ClientID %>')">
                            <div style="display: inline-block" class="auto-style6">
                                <img alt="" src="../Images/Icons/numDown1.png" />&nbsp; Specific Features & Services
                            </div>
                            <div style="display: inline-block" class="auto-style7">
                                <asp:Image ID="imgSpecific" runat="server" ImageUrl="~/Images/Icons/numDown.png" />
                            </div>
                        </div>
                        <asp:Panel ID="pnlSpecificFeatures" runat="server" Width="650px" Visible="False">
                            <div>&nbsp;</div>
                            <div>Do you offer any additional services not mentioned in other sections?</div>
                            <div>&nbsp;</div>
                            <div id="divAddBtn" runat="server">

                                <asp:Button ID="btnAddAdditional" runat="server" Text="Add" CssClass="buttonUpdate" />
                            </div>
                            <div>&nbsp;</div>
                            <div id="divAddService" runat="server" visible="false" class="textbox">
                                <div>Description:&nbsp;<asp:TextBox ID="txtAdditServiceDesc" runat="server" CssClass="textbox" Width="390px" MaxLength="50"></asp:TextBox>
                                    max 50 characters</div>
                                <div>
                                    <asp:CheckBox ID="chkAddCharge" runat="server" TextAlign="Left" Text="Additional charge?" AutoPostBack="True" />
                                </div>
                                <div id="divAdditionalCharge" runat="server" visible="False">
                                    <div>Price:&nbsp;<asp:TextBox ID="txtAdditPrice" runat="server" CssClass="textbox" Width="90px"></asp:TextBox></div>
                                    <div>Unit:&nbsp;<asp:TextBox ID="txtAdditUnit" runat="server" CssClass="textbox" Width="51px"></asp:TextBox>
                                    </div>
                                </div>
                                <div style="text-align: center">
                                    <asp:Button ID="btnUpdateAddService" runat="server" Text="Update" CssClass="buttonUpdate" />
                                    &nbsp;<asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="buttonUpdate" /><asp:Label ID="lblUpdateAddServiceMsg" runat="server"></asp:Label>
                                </div>
                                <div>&nbsp;</div>
                            </div>
                            <div>&nbsp;</div>
                            <div id="AddGrid">
                                <asp:GridView ID="grdAddiotnalService" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlAdditionalService" GridLines="None" EmptyDataText="No additional sevices">
                                    <Columns>
                                        <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                            <ItemStyle ForeColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="ExtraServiceDescription" SortExpression="Description" HeaderText="Description" />
                                        <asp:CheckBoxField DataField="Chargeable" HeaderText="Chargable" />
                                        <asp:BoundField DataField="Unit" HeaderText="Unit" />
                                        <asp:BoundField DataField="Price" HeaderText="Price" />
                                        <asp:ButtonField ButtonType="Image" CommandName="Update" ImageUrl="~/Images/Icons/edit.png" Text="Edit" />
                                        <asp:ButtonField ButtonType="Image" CommandName="remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove" />
                                    </Columns>
                                </asp:GridView>
                            </div>
                            <asp:SqlDataSource ID="SqlAdditionalService" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [id], [ExtraServiceDescription], [Chargeable], [Price], [Unit] FROM [tbl_Farm_ExtraService] WHERE ([FarmId] = @FarmId) ORDER BY [ExtraServiceDescription]">
                                <SelectParameters>
                                    <asp:ControlParameter ControlID="lblFarmId" Name="FarmId" PropertyName="Text" Type="Int32" />
                                </SelectParameters>
                            </asp:SqlDataSource>
                            <div class="auto-style10">&nbsp;</div>
                        </asp:Panel>
                        <div class="auto-style10">&nbsp;</div>
                    </div>
                    <div style="background-color: #86B250; color: #FFFFFF; font-size: large; font-family: Calibri;" id="divGallerybtn" class="selectbar" onclick="showPanel('<%=btnGallery.ClientID %>')">
                        <div style="display: inline-block" class="auto-style8">Farm Pictures & Galleries</div>
                        <div style="display: inline-block">
                            <asp:Image ID="imgGallery" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />
                        </div>
                    </div>
                    <asp:Panel ID="pnlGallery" runat="server" Visible="False">
                        <div>&nbsp;</div>
                        <div>Picture that will display on farm search</div>
                        <div>Please use the Gallery option on the top menu bar under Profiles to upload Gallery picture.</div>
                        <div>&nbsp;</div>
                        <div id="ind_Pic_block" style="border: 1px solid #333333; padding: 5px;">
                            <div style="display: inline-block;">
                                <asp:Image ID="imgMain" runat="server" ImageUrl="~/Farms/Images/FarmProfiles/1ProfilePic.jpg" Height="388px" Width="553px" CssClass="auto-style11" />
                            </div>
                            <div style="display: inline-block;">
                                <div style="padding-right: 0px; padding-bottom: 5px; padding-left: 5px" class="auto-style12">
                                    <asp:Image ID="imgSideTop" runat="server" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_22.gif" Height="127px" Width="127px" />
                                </div>
                                <div style="padding-right: 0px; padding-bottom: 5px; padding-left: 5px" class="auto-style12">
                                    <asp:Image ID="imgSidemiddel" runat="server" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_23.gif" Height="127px" Width="127px" />
                                </div>
                                <div style="padding-right: 0px; padding-bottom: 0px; padding-left: 5px" class="auto-style12">
                                    <asp:Image ID="imgSideBottom" runat="server" ImageUrl="~/Farms/Albums/test/lk;k/farms-lodges_22.gif" Height="127px" Width="127px" />
                                </div>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            What Picture are you uploading: &nbsp;
                            <asp:DropDownList ID="cmbPicType" runat="server" CssClass="textbox">
                                <asp:ListItem>SELECT</asp:ListItem>
                                <asp:ListItem>Main</asp:ListItem>
                                <asp:ListItem>SideTop</asp:ListItem>
                                <asp:ListItem>SideMiddel</asp:ListItem>
                                <asp:ListItem>SideBottom</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div>&nbsp;</div>
                        <asp:FileUpload ID="FileUpload1" runat="server" /><div>
                            <asp:Button ID="btnUploadProfilePic" runat="server" Text="Upload" CssClass="nextPrevButton" /><asp:Label ID="lblUploadMsg" runat="server"></asp:Label>
                        </div>
                        <%--<div>Picture can not exceed xxxkb and dimensions xxx heigt and xxx width.</div>--%>
                        <div>&nbsp;</div>
                        <div>
                        </div>
                        <div class="auto-style10">&nbsp;</div>
                    </asp:Panel>
                    <div style="background-color: #86B250; color: #FFFFFF; font-size: large; font-family: Calibri;" id="divHuntingSeasonbtn" class="selectbar" onclick="showPanel('<%=btnHuntingSeason.ClientID %>')">
                        <div style="display: inline-block" class="auto-style8">Hunting Season</div>
                        <div style="display: inline-block">
                            <asp:Image ID="imgHuntingSeason" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />
                        </div>
                    </div>
                    <asp:Panel ID="pnlHuntingSeason" runat="server" Visible="False" Width="650px">

                        <div>&nbsp;</div>
                        <div style="text-align: center" class="divFormMng">
                            <div>
                                Minimum qty of hunters per booking: 
                                    <asp:DropDownList ID="cmbQtyHunters" runat="server">
                                        <asp:ListItem>0</asp:ListItem>
                                        <asp:ListItem>1</asp:ListItem>
                                        <asp:ListItem>2</asp:ListItem>
                                        <asp:ListItem>5</asp:ListItem>
                                        <asp:ListItem>10</asp:ListItem>
                                        <asp:ListItem>20</asp:ListItem>
                                    </asp:DropDownList>

                            </div>
                        </div>
                        <div class="divFormMng" style="width: 10px">&nbsp;</div>
                        <div class="divFormMng">
                            <div>
                                <asp:CheckBox ID="chkChildren" runat="server" TextAlign="Left" Text="Cater for children?" />
                            </div>
                        </div>
                        <div class="divFormMng" style="width: 10px">&nbsp;</div>
                        <div class="divFormMng">
                            <div>
                                <asp:CheckBox ID="chkOwnVehicle" runat="server" TextAlign="Left" Text="Own vehicle allowed?" />
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div class="divFormMng">
                            <div>
                                Hunting Months
                            </div>
                            <div>
                                <asp:CheckBoxList ID="chckHuntingMonths" runat="server">
                                    <asp:ListItem Value="1">January</asp:ListItem>
                                    <asp:ListItem Value="2">February</asp:ListItem>
                                    <asp:ListItem Value="3">March</asp:ListItem>
                                    <asp:ListItem Value="4">April</asp:ListItem>
                                    <asp:ListItem Value="5">May</asp:ListItem>
                                    <asp:ListItem Value="6">June</asp:ListItem>
                                    <asp:ListItem Value="7">July</asp:ListItem>
                                    <asp:ListItem Value="8">August</asp:ListItem>
                                    <asp:ListItem Value="9">September</asp:ListItem>
                                    <asp:ListItem Value="10">October</asp:ListItem>
                                    <asp:ListItem Value="11">November</asp:ListItem>
                                    <asp:ListItem Value="12">December</asp:ListItem>
                                </asp:CheckBoxList>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div style="text-align: right">
                            <asp:Label ID="lblUpdateAmenitiesMsg" runat="server"></asp:Label>
                            <asp:Button ID="btnUpdateAmenities" runat="server" Text="Update" CssClass="buttonUpdate" /><asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Icons/correct.png" Visible="False" />
                        </div>

                        <div class="auto-style10">&nbsp;</div>
                    </asp:Panel>
                    <div style="background-color: #86B250; color: #FFFFFF; font-size: large; font-family: Calibri;" id="divHuntingTypebtn" class="selectbar" onclick="showPanel('<%=btnhuntingTypes.ClientID %>')">
                        <div style="display: inline-block" class="auto-style8">Hunting Types</div>
                        <div style="display: inline-block">
                            <asp:Image ID="imgHuntingTypes" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />

                        </div>

                    </div>
                    <asp:Panel ID="pnlHuntingTypes" runat="server" Visible="False" Width="650px">

                        <div>&nbsp;</div>
                        <div>Please indicate what hunting types are allowed on your farm.</div>
                        <div>&nbsp;</div>
                        <div>
                            <asp:GridView ID="grdHunting" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlHuntingTypes" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                        <ItemStyle ForeColor="White" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="HuntingType" SortExpression="Description" />
                                    <asp:TemplateField>
                                        <ItemTemplate>
                                            <asp:CheckBox ID="ChkHuntingType" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="SqlHuntingTypes" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT id, HuntingType FROM [tbl_Hunting_Types] WHERE Active = 'True'"></asp:SqlDataSource>
                        </div>
                        <div>&nbsp;</div>
                        <div style="text-align: right">
                            <asp:Label ID="lblHuntingTypeSubmitMsg" runat="server"></asp:Label>
                            <asp:Button ID="btnUpdateHunting" runat="server" Text="Update" CssClass="buttonUpdate" /><asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Icons/correct.png" Visible="False" />
                        </div>

                        <div class="auto-style10">&nbsp;</div>
                    </asp:Panel>
                    <div style="background-color: #86B250; color: #FFFFFF; font-size: large; font-family: Calibri;" id="divecoTourismbtn" class="selectbar" onclick="showPanel('<%=btnExoTourism.ClientID %>')">
                        <div style="display: inline-block" class="auto-style8">Eco Tourism</div>
                        <div style="display: inline-block">
                            <asp:Image ID="imgecoTourism" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />
                        </div>

                    </div>
                    <div id="divecoTourism">
                        <asp:Panel ID="Panel1" runat="server" Visible="False" Width="650px">

                            <div>&nbsp;</div>
                            <div>Please indicate what Eco Tourism Services you offer.</div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:GridView ID="grdEcoTourism" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlEcoTourism" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                            <ItemStyle ForeColor="#494D50" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Eco_Tourism" SortExpression="Description" />
                                        <asp:TemplateField>
                                            <ItemTemplate>
                                                <asp:CheckBox ID="ChkEcoTourismType" runat="server" />
                                            </ItemTemplate>
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlEcoTourism" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT id, Eco_Tourism FROM [tbl_EcoTourism_Types] WHERE Active = 'True' ORDER BY Eco_Tourism"></asp:SqlDataSource>
                            </div>
                            <div>&nbsp;</div>
                            <div style="text-align: right">
                                <asp:Label ID="lblEcoTourismSubmitMsg" runat="server"></asp:Label>
                                <asp:Button ID="btnUpdateEcoTourism" runat="server" Text="Update" CssClass="buttonUpdate" /><asp:Image ID="Image6" runat="server" ImageUrl="~/Images/Icons/correct.png" Visible="False" />
                            </div>

                            <div class="auto-style10">&nbsp;</div>
                        </asp:Panel>
                        <div style="background-color: #86B250; color: #FFFFFF; font-size: large; font-family: Calibri;" id="divtermsbtn" class="selectbar" onclick="showPanel('<%=btnTerms.ClientID %>')">
                            <div style="display: inline-block" class="auto-style8">Terms &amp; Pricing</div>
                            <div style="display: inline-block">
                                <asp:Image ID="imgTerms" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />
                            </div>

                        </div>
                        <asp:Panel ID="pnlTerms" runat="server" Visible="False">
                            <div>&nbsp;</div>
                            <div>
                                <div>Hunter Daily Rate:
                                    <asp:TextBox ID="txtHunterRate" runat="server"></asp:TextBox></div>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <div>Guest Daily Rate:
                                    <asp:TextBox ID="txtGuestRate" runat="server"></asp:TextBox></div>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <div>Deposit % (only on daily rates):
                                    <asp:TextBox ID="txtDepositPerc" runat="server"></asp:TextBox>%</div>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <div>Deposit waiting period:
                                    <asp:TextBox ID="txtDepositPeriod" runat="server"></asp:TextBox>
                                    Days.</div>
                            </div>
                            <div>&nbsp;</div>

                            <div>
                                Booking System:
                                <asp:CheckBox ID="CheckBox1" runat="server" Text="Allow booking without date confirmation email:" TextAlign="Left" />
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:Button ID="btnRateUpdate" runat="server" Text="Update" CssClass="button" />
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:Label ID="lblTermsMsg" runat="server"></asp:Label>
                            </div>
                            <div>&nbsp;</div>
                            <div class="h1">
                                Price Includes:
                            </div>
                            <div>
                                <asp:TextBox ID="txtPriceIncludes" runat="server" CssClass="textbox" Width="423px"></asp:TextBox>&nbsp;
                                <asp:Button ID="Button3" runat="server" Text="Add" CssClass="lineButton" />
                            </div>
                            <div>
                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="sqlPriceIncludes" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                            <ItemStyle ForeColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Item" ValidateRequestMode="Disabled" />
                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/trash.png" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="sqlPriceIncludes" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Item], [id], [Line] FROM [tbl_Farm_Terms] WHERE (([FarmId] = @FarmId) AND ([TermsItem] = @TermsItem)) ORDER BY [Line]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblFarmId" Name="FarmId" PropertyName="Text" Type="Int32" />
                                        <asp:Parameter DefaultValue="Price Includes" Name="TermsItem" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div>&nbsp;</div>
                            <div class="h1">
                                Price Does Not Includes:
                            </div>
                            <div>
                                <asp:TextBox ID="txtPriceDoesnot" runat="server" CssClass="textbox" Width="423px"></asp:TextBox>&nbsp;
                                <asp:Button ID="Button4" runat="server" Text="Add" CssClass="lineButton" />
                            </div>
                            <div>
                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource1" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                            <ItemStyle ForeColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Item" ValidateRequestMode="Disabled" />
                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/trash.png" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Item], [id], [Line] FROM [tbl_Farm_Terms] WHERE (([FarmId] = @FarmId) AND ([TermsItem] = @TermsItem)) ORDER BY [Line]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblFarmId" Name="FarmId" PropertyName="Text" Type="Int32" />
                                        <asp:Parameter DefaultValue="Price DOES NOT include" Name="TermsItem" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div>&nbsp;</div>
                            <div class="h1">
                                Terms of Payment:
                            </div>
                            <div>
                                <div>
                                    <asp:TextBox ID="txtTermsPayment" runat="server" CssClass="textbox" Width="423px"></asp:TextBox>&nbsp;
                                    <asp:Button ID="Button5" runat="server" Text="Add" CssClass="lineButton" />
                                </div>
                                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource2" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                            <ItemStyle ForeColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Item" ValidateRequestMode="Disabled" />
                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/trash.png" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Item], [id], [Line] FROM [tbl_Farm_Terms] WHERE (([FarmId] = @FarmId) AND ([TermsItem] = @TermsItem)) ORDER BY [Line]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblFarmId" Name="FarmId" PropertyName="Text" Type="Int32" />
                                        <asp:Parameter DefaultValue="Terms of Payment" Name="TermsItem" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div>&nbsp;</div>
                            <div class="h1">
                                Cancellation:
                            </div>
                            <div>
                                <asp:TextBox ID="txtCanselation" runat="server" CssClass="textbox" Width="423px"></asp:TextBox>&nbsp;
                                <asp:Button ID="Button6" runat="server" Text="Add" CssClass="lineButton" />
                            </div>
                            <div>
                                <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource3" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                            <ItemStyle ForeColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Item" ValidateRequestMode="Disabled" />
                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/trash.png" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource3" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Item], [id], [Line] FROM [tbl_Farm_Terms] WHERE (([FarmId] = @FarmId) AND ([TermsItem] = @TermsItem)) ORDER BY [Line]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblFarmId" Name="FarmId" PropertyName="Text" Type="Int32" />
                                        <asp:Parameter DefaultValue="Cancellation" Name="TermsItem" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                            <div>&nbsp;</div>
                            <div class="h1">
                                Wounding:
                            </div>
                            <div>
                                <asp:TextBox ID="txtWounding" runat="server" CssClass="textbox" Width="423px"></asp:TextBox>&nbsp;
                                <asp:Button ID="Button7" runat="server" Text="Add" CssClass="lineButton" />
                            </div>
                            <div>
                                <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="SqlDataSource4" GridLines="None">
                                    <Columns>
                                        <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                                            <ItemStyle ForeColor="White" />
                                        </asp:BoundField>
                                        <asp:BoundField DataField="Item" ValidateRequestMode="Disabled" />
                                        <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/trash.png" />
                                    </Columns>
                                </asp:GridView>
                                <asp:SqlDataSource ID="SqlDataSource4" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Item], [id], [Line] FROM [tbl_Farm_Terms] WHERE (([FarmId] = @FarmId) AND ([TermsItem] = @TermsItem)) ORDER BY [Line]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="lblFarmId" Name="FarmId" PropertyName="Text" Type="Int32" />
                                        <asp:Parameter DefaultValue="Wounding" Name="TermsItem" Type="String" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </asp:Panel>
                    </div>


                </div>
            </div>
        </div>
        <div>
            <img alt="" src="javascript:javascript:thisonload()" />
            <asp:Button ID="btnExoTourism" runat="server" Text="" CssClass="buttonHidden" />
            <asp:Button ID="btnFarmDescription" runat="server" Text="" CssClass="buttonHidden" />
            <asp:Button ID="btnFacilities" runat="server" Text="" CssClass="buttonHidden" />
            <asp:Button ID="btnGallery" runat="server" Text="" CssClass="buttonHidden" />
            <asp:Button ID="btnHuntingSeason" runat="server" Text="" CssClass="buttonHidden" />
            <asp:Button ID="btnhuntingTypes" runat="server" Text="" CssClass="buttonHidden" />
            <asp:Button ID="btnfarmDescDetail" runat="server" Text="" CssClass="buttonHidden" />
            <asp:Button ID="btnFeatures" runat="server" Text="" CssClass="buttonHidden" />
            <asp:Button ID="btnfacilitiesDetail" runat="server" Text="" CssClass="buttonHidden" />
            <asp:Button ID="btnSpecificFeature" runat="server" Text="" CssClass="buttonHidden" />
            <asp:Button ID="btnTerms" runat="server" Text="" CssClass="buttonHidden" />
        </div>
    </form>
    <script type="text/javascript">


        function thisonload() {
            alert("test load");
        };

        $(document).ready(function () {

            var Colordiv = document.getElementById("divDescriptHdr");
            alert("test load1");
            alert = sessionStorage.getItem("divDescriptHdr");
            if (sessionStorage.getItem("divDescriptHdr") == 'inline-block') {
                Colordiv.style.display = 'none';

            } else {
                Colordiv.style.display = 'inline-block';
            }
        });

        function ToggleDetails(pnlDiv, imgDown, imgUp) {
            var Colordiv = document.getElementById(pnlDiv);
            var CustImgDown = document.getElementById(imgDown);
            var CustImgUp = document.getElementById(imgUp);

            if (Colordiv.style.display == 'none') {
                Colordiv.style.display = 'inline-block';
                CustImgDown.style.display = 'none';
                CustImgUp.style.display = 'inline-block';
                sessionStorage.setItem(pnlDiv, 'inline-block');
            } else {
                Colordiv.style.display = 'none';
                CustImgDown.style.display = 'inline-block';
                CustImgUp.style.display = 'none';
                sessionStorage.setItem(pnlDiv, 'none');
            }

        }

        function showPanel(selecbutton) {
            document.getElementById(selecbutton).click();
        }
        function HideLabel() {
            document.getElementById('<%=imgUpdateDescription.ClientID%>').style = "display:none";
         }
    </script>
    <script type="text/javascript">
         function autoHide() {
             alert("auto hide")
             setTimeout(function () { document.getlementById('<%=imgUpdateDescription.ClientID%>').style.display = 'none'; }, 5000);
         }
    </script>
</body>
</html>
