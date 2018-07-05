<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="addFarm.aspx.vb" Inherits="SetUp_Registrations_addFarm" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .divsE {
            display: inline-block;
        }

        .divMainContainer {
            display: inline-block;
            width: 70%;
        }

        .divFormMng {
            display: inline-block;
        }

        .auto-style4 {
            font-size: xx-large;
            width: 7px;
        }

        .auto-style5 {
            width: 7px;
        }

        .auto-style6 {
            width: 575px;
        }

        .auto-style8 {
            display: inline-block;
            width: 51%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div height="40px">&nbsp;</div>
            <div valign="top" style="clip: rect(0px, auto, auto, auto);">
                <div id="pnlFarmDetails" runat="server" class="auto-style8" style="border-width: thin; border-color: #FFFF00; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid; background-color: #F0F0F0;">
                    <div class="divFormMng">
                        <div class="h1">Farm Details</div>
                        <div>&nbsp;</div>
                        <div>
                            <div>Farm Name</div>
                            <div>
                                <asp:TextBox ID="txtFarmName" runat="server" CssClass="textbox" Width="100%"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div class="divFormMng">
                            <div>Country</div>
                            <div>
                                <asp:DropDownList ID="cmbFarmCountry" runat="server" CssClass="textbox" DataSourceID="SqlDataSourceCountry" DataTextField="Name" DataValueField="Country_Id" AutoPostBack="True"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceCountry" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Country_Id], [Name] FROM [tblCountries] ORDER BY [Name]"></asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="divFormMng">
                            <div>Province</div>
                            <div>
                                <asp:DropDownList ID="cmbProvince" runat="server" CssClass="textbox" DataSourceID="SqlDataSourceProvince" DataTextField="Name" DataValueField="ProvinceId"></asp:DropDownList>
                                <asp:SqlDataSource ID="SqlDataSourceProvince" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [ProvinceId], [Name] FROM [tblProvince] WHERE ([CountryId] = @CountryId) ORDER BY [Name]">
                                    <SelectParameters>
                                        <asp:ControlParameter ControlID="cmbFarmCountry" DefaultValue="1" Name="CountryId" PropertyName="SelectedValue" Type="Int32" />
                                    </SelectParameters>
                                </asp:SqlDataSource>
                            </div>
                        </div>
                        <div class="divFormMng">
                            <div>Closest Town</div>
                            <div>
                                <asp:TextBox ID="txtClosestTown" runat="server" CssClass="textbox"></asp:TextBox>

                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <%-- <div>

                        <div class="divFormMng">
                            <div>Longitude</div>
                            <div>
                                <asp:TextBox ID="txtLongitude" runat="server" CssClass="textbox"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng">
                            <div>Latitude</div>
                            <div>
                                <asp:TextBox ID="txtLatitide" runat="server" CssClass="textbox"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng">
                            <div>&nbsp</div>
                            <div>
                                <asp:Button ID="btnCurrentLocation" runat="server" Text="Use Current Location" CssClass="nextPrevButton" Visible="False" />
                            </div>
                        </div>
                        </div>--%>
                        <div>&nbsp</div>
                        <div>
                            <div style="vertical-align: bottom;" class="divFormMng">
                                <div>Farm Email</div>
                                <div>
                                    <asp:TextBox ID="txtFarmEmail" runat="server" CssClass="textbox"></asp:TextBox>
                                </div>
                            </div>
                            <div style="vertical-align: bottom;" class="divFormMng">
                                <div>Farm Telephone Number</div>
                                <div>
                                    <asp:TextBox ID="txtFarmTel" runat="server" CssClass="textbox" MaxLength="14" Width="185px"></asp:TextBox>
                                </div>
                            </div>
                            <div style="vertical-align: bottom;" class="divFormMng">
                                <div>Mobile Number</div>
                                <div>
                                    <asp:TextBox ID="txtFarmMobile" runat="server" CssClass="textbox" MaxLength="14" Width="155px"></asp:TextBox>
                                </div>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <%-- <div>
                            <div style="vertical-align: bottom;" class="divFormMng">
                                <div>Company Name</div>
                                <div>
                                    <asp:TextBox ID="txtCompanyName" runat="server" CssClass="textbox"></asp:TextBox>
                                </div>
                            </div>
                            <div style="vertical-align: bottom;" class="divFormMng">
                                <div>Company Registration Number</div>
                                <div>
                                    <asp:TextBox ID="txtCompRegNr" runat="server" CssClass="textbox" MaxLength="14" Width="185px"></asp:TextBox>
                                </div>
                            </div>--%>
                        <div>&nbsp;</div>
                        <div style="text-align: right">
                            <asp:Button ID="btnFarmNext" runat="server" Text="Next" CssClass="lineButton" Visible="False" /><asp:Button ID="Button2" runat="server" Text="Submit" CssClass="button" />
                            <div>
                                <asp:Label ID="lblSubmitValidate" runat="server"></asp:Label></div>
                        </div>
                    </div>
                </div>
            </div>

            <div id="pnlPersonalDetails" visible="false" runat="server" class="auto-style8" style="border-width: thin; border-color: #3E432F; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;">
                <div class="h1">Owner Information</div>
                <div>&nbsp;</div>
                <div class="divFormMng">
                    <div>Title</div>
                    <div>
                        <asp:DropDownList ID="cmbTitle" runat="server" CssClass="textbox">
                            <asp:ListItem>Mr</asp:ListItem>
                            <asp:ListItem>Mrs</asp:ListItem>
                            <asp:ListItem>Dr</asp:ListItem>
                            <asp:ListItem>Prof</asp:ListItem>
                            <asp:ListItem>Adv</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div class="divFormMng">
                    <div>Initials</div>
                    <div>
                        <asp:TextBox ID="txtInitials" runat="server" CssClass="textbox" MaxLength="10" Width="49px"></asp:TextBox>
                    </div>
                </div>
                <div class="divFormMng">
                    <div>Full Name</div>
                    <div>
                        <asp:TextBox ID="txtFullNames" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
                <div class="divFormMng">
                    <div>Last Name</div>
                    <div>
                        <asp:TextBox ID="txtSurname" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div>
                    <div class="divFormMng">
                        <div>Gender</div>
                        <div>
                            <asp:RadioButtonList ID="rdbGender" runat="server">
                                <asp:ListItem>Male</asp:ListItem>
                                <asp:ListItem>Female</asp:ListItem>
                            </asp:RadioButtonList>
                        </div>
                    </div>
                    <div style="vertical-align: bottom;" class="divFormMng">
                        <div>Preferred Name</div>
                        <div>
                            <asp:TextBox ID="txtPreferredName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                        </div>
                    </div>
                    <div style="vertical-align: bottom;" class="divFormMng">
                        <div>Email Address</div>
                        <div>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div>
                    <div style="vertical-align: bottom;" class="divFormMng">
                        <div>Mobile Number</div>
                        <div>
                            <asp:TextBox ID="txtCell" runat="server" CssClass="textbox" MaxLength="14" TextMode="Phone"></asp:TextBox>
                        </div>
                    </div>
                    <div style="vertical-align: bottom;" class="divFormMng">
                        <div>Business Telephone Number</div>
                        <div>
                            <asp:TextBox ID="txtWorkTel" runat="server" CssClass="textbox" MaxLength="14" Width="185px"></asp:TextBox>
                        </div>
                    </div>
                    <div style="vertical-align: bottom;" class="divFormMng">
                        <div>Home Telephone Number</div>
                        <div>
                            <asp:TextBox ID="txtWorkTel0" runat="server" CssClass="textbox" MaxLength="14" Width="155px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div>
                    <div style="vertical-align: bottom;" class="divFormMng">
                        <div>Country</div>
                        <div>
                            <asp:DropDownList ID="cmbCountry" runat="server" CssClass="textbox">
                                <asp:ListItem>South Africa</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div style="vertical-align: bottom;" class="divFormMng">
                        <div>Identity Number</div>
                        <div>
                            <asp:TextBox ID="txtIdDoc" runat="server" CssClass="textbox" MaxLength="13" Width="185px"></asp:TextBox>
                        </div>
                    </div>
                    <div style="vertical-align: bottom;" class="divFormMng">
                        <div>Passport Number</div>
                        <div>
                            <asp:TextBox ID="txtPassport" runat="server" CssClass="textbox" MaxLength="20" Width="155px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div style="vertical-align: bottom;" class="divFormMng">
                    <div>Nationality</div>
                    <div>
                        <asp:DropDownList ID="cmbNationality" runat="server" CssClass="textbox">
                            <asp:ListItem>South Africa</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div style="text-align: right" class="auto-style6">
                    <asp:Button ID="Button1" runat="server" Text="Previous" CssClass="lineButton" />&nbsp;&nbsp;<asp:Button ID="btnPerNext" runat="server" Text="Next" CssClass="lineButton" />
                </div>
            </div>

            <div id="pnlAddress" runat="server" class="auto-style8" style="border-width: thin; border-color: #FFFF00; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;" visible="False">
                <div class="h1">Address & Domicile</div>
                <div>&nbsp;</div>

                <div class="divFormMng">
                    <div>Residential Address</div>
                    <div>
                        <asp:TextBox placeholder="Street Name" ID="txtHomeStreet" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                        <asp:TextBox placeholder="No" ID="txtHomeStreetNo" runat="server" AutoCompleteType="Cellular" CssClass="textbox" MaxLength="10" Width="51px"></asp:TextBox>
                    </div>
                </div>
                <div>&nbsp;</div>

                <div class="divFormMng">
                    <div>
                        <asp:TextBox placeholder="Complex Name" ID="txtHomeComplex" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                        <asp:TextBox ID="txtComplexNo" placeholder="No" runat="server" AutoCompleteType="Cellular" CssClass="textbox" MaxLength="10" Width="51px"></asp:TextBox>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div>
                    <div class="divFormMng">
                        <div>
                            <asp:TextBox ID="txtHomeSuburb" placeholder="Suburb" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div class="divFormMng">
                    <div>
                        <asp:TextBox placeholder="City" ID="txtHomeCity" runat="server" CssClass="textbox" MaxLength="100" Width="160px"></asp:TextBox>
                        <asp:DropDownList ID="cmbHomeProvince" runat="server" CssClass="textbox">
                        </asp:DropDownList>
                        <asp:TextBox placeholder="Postal Code" ID="txtHomePostal" runat="server" CssClass="textbox" MaxLength="10" Width="107px"></asp:TextBox>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div>&nbsp;</div>
                <div class="divFormMng">
                    <div>Business Address</div>
                    <div>
                        <asp:TextBox placeholder="Street Name" ID="txtWorkStreet" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                        <asp:TextBox placeholder="No" ID="txtworkStreetNo" runat="server" CssClass="textbox" MaxLength="10" Width="51px"></asp:TextBox>
                    </div>
                </div>
                <div>&nbsp;</div>

                <div class="divFormMng">
                    <div>
                        <asp:TextBox ID="txtWorkComplex" Placeholder="Complex/Building Name" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                        <asp:TextBox ID="txtWorkComplexNo" runat="server" CssClass="textbox" MaxLength="10" placeholder="No" Width="51px"></asp:TextBox>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div>
                    <div class="divFormMng">
                        <div>
                            <asp:TextBox ID="txtWorkSuburb" placeholder="Suburb" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div class="divFormMng">
                    <div>
                        <asp:TextBox placeholder="City" ID="txtWorkCity" runat="server" CssClass="textbox" MaxLength="100" Width="160px"></asp:TextBox>
                        <asp:DropDownList ID="cmbWorkProvince" runat="server" CssClass="textbox">
                        </asp:DropDownList>
                        <asp:TextBox placeholder="Postal Code" ID="txtWorkPostal" runat="server" CssClass="textbox" MaxLength="10" Width="107px"></asp:TextBox>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div>
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
                <div>&nbsp;</div>
                <div style="text-align: right" class="auto-style6">
                    <asp:Button ID="btnAddressPrevious" runat="server" Text="Previous" CssClass="lineButton" />&nbsp;&nbsp;<asp:Button ID="btnAddressNext" runat="server" Text="Submit" CssClass="button" />
                </div>
                <div style="text-align: right">
                </div>
            </div>

            <div id="pnlUserDetails" runat="server" runat="server" class="divMainContainer" style="border-width: thin; border-color: #FFFF00; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid; background-color: #F0F0F0;" visible="False">
                <div class="h1">User Details</div>
                <div>&nbsp;</div>
                <div>
                    We are ready to create your log in details!
                </div>
                <div>
                    <asp:Label ID="lblLimitedFunction" runat="server"></asp:Label>
                </div>
                <div>&nbsp;</div>
                <div>
                    Member Id
                </div>
                <div>
                    <asp:Label ID="lblMemberId" runat="server"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblFarmId" runat="server"></asp:Label>
                </div>
                <div>&nbsp;</div>
                <div>User Name</div>
                <div>
                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox"></asp:TextBox>
                </div>
                <div>&nbsp;</div>
                <div>Please enter and confirm a password</div>
                <div>
                    <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" TextMode="Password" Width="152px" MaxLength="20"></asp:TextBox>
                </div>
                <div>
                    <asp:TextBox ID="txtPassword0" placeholder="Confirm Password" runat="server" CssClass="textbox" TextMode="Password" Width="152px" MaxLength="20"></asp:TextBox>
                </div>
                <div>&nbsp;</div>
                <div>
                    <asp:Button ID="btnCreateUser" runat="server" CssClass="button" Text="Create User Profile" /><asp:Label ID="lblUserMsg" runat="server"></asp:Label>
                </div>
                <div>&nbsp;</div>
                <div style="text-align: right">
                    <asp:HiddenField ID="HiddenFieldUserId" runat="server" />
                </div>
            </div>

            <%--  <div id="pnlFormManager" class="divFormMng" runat="server" style="border-width: thin; border-color: #3E432F; vertical-align: top; border-top-style: solid; border-right-style: solid; border-left-style: inset;">
                    <table style="font-size: small">
                        <tr>
                            <td class="h1">Form Management</td>
                            <td class="auto-style4">&nbsp;</td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                        </tr>
                        <tr>
                            <td class="textbox">

                                <asp:Button ID="lblProcessFarmDetails" runat="server" CssClass="lineButton" Text="1. Farm Details" />
                            </td>
                            <td class="auto-style5">
                                <asp:Image ID="imgFarmDetCheck" runat="server" ImageUrl="~/Images/Icons/warning.png" />
                            </td>
                        </tr>
                        <tr>
                            <td class="textbox">
                                <asp:Button ID="lblProcessContact" runat="server" CssClass="lineButton" Text="2. Owner Details" />
                            </td>
                            <td class="auto-style5">
                                <asp:Image ID="imgOwnerCheck" runat="server" ImageUrl="~/Images/Icons/warning.png" />
                            </td>
                        </tr>
                        <tr>
                            <td class="textbox">
                                <asp:Button ID="lblProcessAddress" runat="server" CssClass="lineButton" Text="3. Owner Address"></asp:Button>
                            </td>
                            <td class="auto-style5">
                                <asp:Image ID="imgAddressCheck" runat="server" ImageUrl="~/Images/Icons/warning.png" />
                            </td>
                        </tr>
                        <tr>
                            <td>&nbsp;</td>
                            <td class="auto-style5">&nbsp;</td>
                        </tr>

                    </table>
                </div>--%>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

