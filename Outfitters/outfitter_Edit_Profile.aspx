<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="outfitter_Edit_Profile.aspx.vb" Inherits="Outfitters_outfitter_Edit_Profile" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            border-top: 2px solid white;
            border-bottom: 2px solid white;
            padding: 5px;
            display: inline-block;
            width: 700px;
            cursor: pointer;
            background-color: #e2e2e2;
            vertical-align: middle;
            font-size: medium;
            border-left-color: white;
            border-left-width: 2px;
            border-right-color: white;
            border-right-width: 2px;
        }

        .auto-style3 {
            border-top: 2px solid white;
            border-bottom: 2px solid white;
            padding: 5px;
            display: inline-block;
            width: 639px;
            cursor: pointer;
            background-color: #e2e2e2;
            vertical-align: middle;
            font-size: medium;
            border-left-color: white;
            border-left-width: 2px;
            border-right-color: white;
            border-right-width: 2px;
        }

        .auto-style4 {
            width: 812px;
        }

        .auto-style5 {
            width: 606px;
        }

        .auto-style8 {
            width: 674px;
        }

        .auto-style9 {
            width: 648px;
        }

        .auto-style10 {
            height: 8px;
        }

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

        .headers {
            font-weight: bold;
            font-size: large;
        }

        .cellSize {
            height: 27px;
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="mainPageWrapper" style="align-content: center;" onload="thisonload()">
        <div class="div_MainBlock">
            <div style="text-align: left; width: 1050px; display: inline-block;">
                <div>&nbsp;</div>
                <div class="h1">Manage Outfitter Profile</div>
                <div>&nbsp;<asp:Label ID="Label1" runat="server" Text=""></asp:Label></div>
                <div style="background-color: #86B250; color: #FFFFFF; font-size: large; font-family: Calibri;" class="auto-style2">&nbsp;<asp:Label ID="lblFarmName" runat="server"></asp:Label>&nbsp;
                    <asp:Label ID="lblFarmId" runat="server" ForeColor="Transparent"></asp:Label></div>
                <div>&nbsp;</div>
                <div id="divAllBlock" runat="server" style="display: inline-block">

                    <%--Countries were we hunt--%>
                    <div id="divCountries" runat="server" style="display: inline-block; vertical-align: top; padding-right: 20px;" class="auto-style4">
                        <div id="divCountriesHdr">
                            <div id="pnlCountries" runat="server" visible="false">
                                <div>
                                    <asp:GridView ID="gridCountries" Width="50%" runat="server" AutoGenerateColumns="False" Font-Size="Small">
                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" CommandName="myEdit" ImageUrl="~/Images/Icons/select.png" Text="Select" />
                                            <asp:BoundField DataField="CountryId" HeaderText="Id" />
                                            <asp:BoundField DataField="Name" HeaderText="Country" />
                                            <asp:ButtonField ButtonType="Image" CommandName="Remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove" />
                                        </Columns>
                                    </asp:GridView>
                                </div>
                                <div>
                                    <asp:DropDownList ID="cmbCountry" runat="server" DataSourceID="SqlDataSourceCountry" DataTextField="Name" DataValueField="Country_Id"></asp:DropDownList>&nbsp;
                                    <asp:SqlDataSource ID="SqlDataSourceCountry" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Country_Id], [Name] FROM [tblCountries] ORDER BY [Name]"></asp:SqlDataSource>
                                    <asp:Button ID="Button1" runat="server" Text="Add Country" BackColor="#3E432F" BorderStyle="None" ForeColor="White" Width="100px" />
                                </div>
                                <div>&nbsp;</div>
                                <div style="border-top-style: solid; border-width: thin">
                                    <asp:Panel ID="pnlCountry" Visible="false" runat="server">
                                        <div>&nbsp;</div>
                                        <div class="headers" style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" onclick="showPanel('<%=btnC.ClientID %>')">&nbsp;<asp:Image ID="Image6" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;&nbsp;&nbsp;<asp:Label ID="lblCountry" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="lblCountryId" ForeColor="Transparent" runat="server" Text=""></asp:Label></div>
                                        <div>&nbsp;</div>
                                        <asp:Panel ID="pnlC" Visible="false" runat="server">
                                            <div>
                                                <asp:GridView ID="gridLodges" Width="70%" runat="server" AutoGenerateColumns="False" Font-Size="Small">
                                                    <Columns>
                                                        <asp:ButtonField ButtonType="Image" CommandName="myEdit" ImageUrl="~/Images/Icons/select.png" Text="Select" />
                                                        <asp:BoundField DataField="id" HeaderText="Id" />
                                                        <asp:BoundField DataField="Name" HeaderText="Country" />
                                                        <asp:BoundField DataField="LodgeId" HeaderText="Lodge Id" />
                                                        <asp:BoundField DataField="FarmName" HeaderText="Lodge Name" />
                                                        <asp:ButtonField ButtonType="Image" CommandName="Remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div>
                                                <asp:DropDownList ID="ddlLodges" runat="server" DataTextField="FarmName" DataValueField="id"></asp:DropDownList>&nbsp;
                                                <asp:Button ID="Button2" runat="server" Text="Add Lodge" BackColor="#3E432F" BorderStyle="None" ForeColor="White" Width="100px" />
                                            </div>
                                            <div>&nbsp;</div>
                                        </asp:Panel>
                                    </asp:Panel>
                                </div>
                                <div>&nbsp;</div>

                                <div style="border-top-style: solid; border-width: thin">
                                    <asp:Panel ID="pnlLodges" Visible="false" runat="server">
                                        <div>&nbsp;</div>
                                        <div class="headers" style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;">&nbsp;&nbsp;&nbsp;<asp:Label ID="lblLodgeName" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="lblLodgeId" ForeColor="Transparent" runat="server" Text=""></asp:Label></div>
                                        <div>&nbsp;</div>
                                        <div class="headers" onclick="showPanel('<%=btnDRates.ClientID %>')">
                                            <asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;Daily Rates</div>
                                        <div>&nbsp;</div>
                                        <asp:Panel ID="pnlDRates" Visible="false" runat="server">
                                            <div>
                                                <asp:GridView ID="gridDailyRates" Width="75%" runat="server" AutoGenerateColumns="False" Font-Size="Small">
                                                    <Columns>
                                                        <asp:BoundField DataField="id" HeaderText="Id" />
                                                        <asp:BoundField DataField="FarmName" HeaderText="Lodge Name" />
                                                        <asp:BoundField DataField="RateName" HeaderText="Rate Name" />
                                                        <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                                        <asp:BoundField DataField="PerDay" HeaderText="Per Day" />
                                                        <asp:ButtonField ButtonType="Image" CommandName="Remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="divFormMng">
                                                <div class="cellSize">Rate Name</div>
                                                <div>
                                                    <asp:TextBox ID="txtRateName" CssClass="textbox" Width="120px" runat="server"></asp:TextBox></div>
                                            </div>
                                            <div class="divFormMng">
                                                <div class="cellSize">Rate</div>
                                                <div>
                                                    <asp:TextBox ID="txtRate" CssClass="textbox" Width="120px" runat="server"></asp:TextBox></div>
                                            </div>
                                            <div class="divFormMng">
                                                <div class="cellSize">Per Days</div>
                                                <div>
                                                    <asp:DropDownList ID="ddlPerDays" runat="server" Width="120px">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>
                                                        <asp:ListItem>7</asp:ListItem>
                                                        <asp:ListItem>8</asp:ListItem>
                                                        <asp:ListItem>9</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div>
                                                <asp:Button ID="Button3" runat="server" Text="Add this Rate" BackColor="#3E432F" BorderStyle="None" ForeColor="White" Width="100px" />&nbsp;&nbsp;&nbsp;<asp:Label ID="Label2" ForeColor="Red" runat="server" Text=""></asp:Label></div>
                                            <div>&nbsp;</div>
                                        </asp:Panel>

                                        <div>&nbsp;</div>
                                        <div class="headers" onclick="showPanel('<%=btnR.ClientID %>')">
                                            <asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;Animal Rates</div>
                                        <div>&nbsp;</div>
                                        <asp:Panel ID="pnlR" Visible="false" runat="server">
                                            <div>
                                                <asp:GridView ID="gridAnimalRates" Width="75%" runat="server" AutoGenerateColumns="False" Font-Size="Small">
                                                    <Columns>
                                                        <asp:BoundField DataField="id" HeaderText="Id" />
                                                        <asp:BoundField DataField="FarmName" HeaderText="Lodge Name" />
                                                        <asp:BoundField DataField="RateName" HeaderText="Rate Name" />
                                                        <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                                        <asp:ButtonField ButtonType="Image" CommandName="Remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="divFormMng">
                                                <div class="cellSize">Rate Name</div>
                                                <div>
                                                    <asp:TextBox ID="txtRateNameAnimal" CssClass="textbox" Width="120px" runat="server"></asp:TextBox></div>
                                            </div>
                                            <div class="divFormMng">
                                                <div class="cellSize">Rate</div>
                                                <div>
                                                    <asp:TextBox ID="txtRateAnimal" CssClass="textbox" Width="120px" runat="server"></asp:TextBox></div>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div>
                                                <asp:Button ID="Button4" runat="server" Text="Add this Rate" BackColor="#3E432F" BorderStyle="None" ForeColor="White" Width="100px" />&nbsp;&nbsp;&nbsp;<asp:Label ID="Label3" ForeColor="Red" runat="server" Text=""></asp:Label></div>
                                            <div>&nbsp;</div>
                                        </asp:Panel>

                                        <div>&nbsp;</div>
                                        <div class="headers" onclick="showPanel('<%=btnAccRate.ClientID %>')">
                                            <asp:Image ID="Image10" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;Accommodation Rates</div>
                                        <div>&nbsp;</div>
                                        <asp:Panel ID="pnlAccRate" Visible="false" runat="server">
                                            <div>
                                                <asp:GridView ID="gridAccRate" Width="75%" runat="server" AutoGenerateColumns="False" Font-Size="Small">
                                                    <Columns>
                                                        <asp:BoundField DataField="id" HeaderText="Id" />
                                                        <asp:BoundField DataField="FarmName" HeaderText="Lodge Name" />
                                                        <asp:BoundField DataField="RateName" HeaderText="Rate Name" />
                                                        <asp:BoundField DataField="Rate" HeaderText="Rate" />
                                                        <asp:BoundField DataField="PerDay" HeaderText="Per Day" />
                                                        <asp:ButtonField ButtonType="Image" CommandName="Remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove" />
                                                    </Columns>
                                                </asp:GridView>
                                            </div>
                                            <div class="divFormMng">
                                                <div class="cellSize">Rate Name</div>
                                                <div>
                                                    <asp:TextBox ID="txtRateNameAccRate" CssClass="textbox" Width="120px" runat="server"></asp:TextBox></div>
                                            </div>
                                            <div class="divFormMng">
                                                <div class="cellSize">Rate</div>
                                                <div>
                                                    <asp:TextBox ID="txtRateAccRate" CssClass="textbox" Width="120px" runat="server"></asp:TextBox></div>
                                            </div>

                                            <div class="divFormMng">
                                                <div class="cellSize">Per Days</div>
                                                <div>
                                                    <asp:DropDownList ID="ddlPerDayAccRate" runat="server" Width="120px">
                                                        <asp:ListItem>1</asp:ListItem>
                                                        <asp:ListItem>2</asp:ListItem>
                                                        <asp:ListItem>3</asp:ListItem>
                                                        <asp:ListItem>4</asp:ListItem>
                                                        <asp:ListItem>5</asp:ListItem>
                                                        <asp:ListItem>6</asp:ListItem>
                                                        <asp:ListItem>7</asp:ListItem>
                                                        <asp:ListItem>8</asp:ListItem>
                                                        <asp:ListItem>9</asp:ListItem>
                                                        <asp:ListItem>10</asp:ListItem>
                                                    </asp:DropDownList>
                                                </div>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div>
                                                <asp:Button ID="btnAddAccRate" runat="server" Text="Add this Rate" BackColor="#3E432F" BorderStyle="None" ForeColor="White" Width="100px" />&nbsp;&nbsp;&nbsp;<asp:Label ID="Label4" ForeColor="Red" runat="server" Text=""></asp:Label></div>
                                            <div>&nbsp;</div>
                                        </asp:Panel>

                                        <div>&nbsp;</div>
                                        <div class="headers" onclick="showPanel('<%=btnAccGallery.ClientID %>')">
                                            <asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;Accommodation Gallery</div>
                                        <div>&nbsp;</div>
                                        <asp:Panel ID="pnlAccGallery" runat="server" Visible="False">
                                            <div>
                                                <asp:Panel ID="pnlFarmSelect" runat="server" Visible="True">
                                                    <div style="padding: 5px;">
                                                        <div>
                                                            Click &quot;Create New Album&quot; to create a new album.<br />
                                                            After Album is created click on the Select Icon&nbsp;
                                                            <asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/select.png" />
                                                            to open the Album.
                                                        </div>
                                                        <div>
                                                            <asp:Button ID="btnAddMain" runat="server" CssClass="button" Text="Create New Album" /></div>
                                                        <div>&nbsp;</div>
                                                        <div>
                                                            <div class="divFormMng" style="vertical-align: top;">
                                                                <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" BorderColor="#666666" BorderStyle="Solid" BorderWidth="2px" Width="350px" ShowHeader="False">
                                                                    <Columns>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="ViewLine" ImageUrl="~/Images/Icons/select.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:ButtonField>
                                                                        <asp:BoundField DataField="id" HeaderText="Id" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Left" Width="20px"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Name" HeaderText="Main Folder" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="EditLine" ImageUrl="~/Images/Icons/edit.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:ButtonField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="myDelete" ImageUrl="~/Images/Icons/trash.png" HeaderText="Delete"></asp:ButtonField>
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#184D43" ForeColor="White" />
                                                                </asp:GridView>
                                                            </div>
                                                            <div class="divFormMng" style="width: 30px;">&nbsp;</div>
                                                            <div class="divFormMng" style="vertical-align: top;">
                                                                <asp:Panel ID="pnlAddMain" runat="server" Visible="false">
                                                                    <div>#<asp:TextBox ID="txtMainFolderId" runat="server" Width="10px" BorderStyle="None" BackColor="Transparent"></asp:TextBox></div>
                                                                    <div class="divFormMng">
                                                                        <div class="divFormMng" style="width: 150px;">Name : </div>
                                                                        <div class="divFormMng">
                                                                            <asp:TextBox ID="txtMainName" runat="server" Width="250px" CssClass="textbox"></asp:TextBox></div>
                                                                    </div>
                                                                    <div>
                                                                        <div class="divFormMng" style="width: 150px;">Description (optional) : </div>
                                                                        <div class="divFormMng">
                                                                            <asp:TextBox ID="TextBox1" runat="server" Height="40px" TextMode="MultiLine" Width="250px" CssClass="textbox"></asp:TextBox></div>
                                                                    </div>
                                                                    <div>
                                                                        <div class="divFormMng" style="width: 150px;">&nbsp;</div>
                                                                        <div class="divFormMng">
                                                                            <asp:Button ID="btnSubmitMain" runat="server" CssClass="nextPrevButton" Text="Submit" /></div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div>
                                                <asp:Panel ID="pnlSub" runat="server" Visible="false">
                                                    <div style="border-top-style: solid; border-width: thin; padding: 5px;">
                                                        <div>
                                                            Click on &quot;Create New Sub Album&quot; to create a Sub Album.<br />
                                                            After Sub Album is created click on the Select Icon&nbsp;
                                                            <asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icons/select.png" />
                                                            to load images.
                                                        </div>
                                                        <div>&nbsp;</div>
                                                        <div class="headers">
                                                            <span class="HeaderLabel">#</span>
                                                            <asp:Label ID="lblMainId" runat="server" Text="" CssClass="HeaderLabel"></asp:Label>&nbsp;
                                                            <asp:Label ID="txtMain" runat="server" Text="" CssClass="HeaderLabel"></asp:Label>
                                                        </div>
                                                        <div>&nbsp;</div>
                                                        <div>
                                                            <asp:Button ID="btnAddSubFolder" runat="server" CssClass="button" Text="Create New Sub Album" /></div>
                                                        <div>&nbsp;</div>
                                                        <div>
                                                            <div class="divFormMng" style="vertical-align: top;">
                                                                <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" BorderColor="#666666" BorderStyle="Solid" BorderWidth="2px" Width="350px" ShowHeader="False">
                                                                    <Columns>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="ViewLine" ImageUrl="~/Images/Icons/select.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:ButtonField>
                                                                        <asp:BoundField DataField="subId" HeaderText="Id" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Name" HeaderText="Main Folder" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="EditLine" ImageUrl="~/Images/Icons/edit.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:ButtonField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="myDelete" ImageUrl="~/Images/Icons/trash.png" HeaderText="Delete"></asp:ButtonField>
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#184D43" ForeColor="White" />
                                                                </asp:GridView>
                                                            </div>
                                                            <div class="divFormMng" style="width: 30px;">&nbsp;</div>
                                                            <div class="divFormMng" style="vertical-align: top;">
                                                                <asp:Panel ID="pnlSubFolder" runat="server" Visible="false">
                                                                    <div>#<asp:TextBox ID="txtsubId" runat="server" Width="10px" BorderStyle="None" BackColor="Transparent"></asp:TextBox></div>
                                                                    <div class="divFormMng">
                                                                        <div class="divFormMng" style="width: 150px;">Name : </div>
                                                                        <div class="divFormMng">
                                                                            <asp:TextBox ID="txtSub" runat="server" Width="250px" CssClass="textbox"></asp:TextBox></div>
                                                                    </div>
                                                                    <div>
                                                                        <div class="divFormMng" style="width: 150px;">Description (optional) : </div>
                                                                        <div class="divFormMng">
                                                                            <asp:TextBox ID="TextBox2" runat="server" Height="40px" TextMode="MultiLine" Width="250px" CssClass="textbox"></asp:TextBox></div>
                                                                    </div>
                                                                    <div>
                                                                        <div class="divFormMng" style="width: 150px;">&nbsp;</div>
                                                                        <div class="divFormMng">
                                                                            <asp:Button ID="btnAdd" runat="server" CssClass="nextPrevButton" Text="Submit" /></div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div>
                                                <asp:Panel ID="pnlPhotos" runat="server" Visible="false">
                                                    <div style="border-top-style: solid; border-width: thin; padding: 5px;">
                                                        <div class="headers"><span class="HeaderLabel">#</span><asp:Label ID="lblMain1" runat="server" Text="" CssClass="HeaderLabel"></asp:Label></div>
                                                        <div class="headers"><span class="HeaderLabel">#</span><asp:Label ID="txtSubId1" runat="server" Text="" CssClass="HeaderLabel"></asp:Label>&nbsp;<asp:Label ID="txtSub1" runat="server" Text="" CssClass="HeaderLabel"></asp:Label></div>
                                                        <div>&nbsp;</div>
                                                        <div>
                                                            <div class="divFormMng" style="width: 150px;">Photo Name : </div>
                                                            <div class="divFormMng">
                                                                <asp:TextBox ID="txtPhoto" runat="server" Width="300px" CssClass="textbox"></asp:TextBox>&nbsp(20 characters)</div>
                                                        </div>
                                                        <div>
                                                            <div class="divFormMng" style="width: 150px;">&nbsp;</div>
                                                            <div class="divFormMng">
                                                                <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" />&nbsp;(97 x 102)</div>
                                                        </div>
                                                        <div>
                                                            <div class="divFormMng" style="width: 150px;">&nbsp;</div>
                                                            <div class="divFormMng">
                                                                <asp:Button ID="btnUpload" runat="server" CssClass="button" Text="Update" /></div>
                                                        </div>
                                                        <div>&nbsp;</div>
                                                        <div>
                                                            <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                                                        </div>
                                                        <div>&nbsp;</div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div>&nbsp;</div>
                                        </asp:Panel>

                                        <div>&nbsp;</div>
                                        <div class="headers" onclick="showPanel('<%=btnDinnerGallery.ClientID %>')">
                                            <asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;Themed Dinner Gallery</div>
                                        <div>&nbsp;</div>
                                        <asp:Panel ID="pnlDinner" runat="server" Visible="False">
                                            <div>
                                                <asp:Panel ID="pnlDinnerMain" runat="server" Visible="True">
                                                    <div style="padding: 5px;">
                                                        <div>
                                                            Click &quot;Create New Album&quot; to create a new album.<br />
                                                            After Album is created click on the Select Icon&nbsp;
                                                            <asp:Image ID="Image8" runat="server" ImageUrl="~/Images/Icons/select.png" />
                                                            to open the Album.
                                                        </div>
                                                        <div>
                                                            <asp:Button ID="btnAddMainDinner" runat="server" CssClass="button" Text="Create New Album" /></div>
                                                        <div>&nbsp;</div>
                                                        <div>
                                                            <div class="divFormMng" style="vertical-align: top;">
                                                                <asp:GridView ID="gridDinnerMain" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" BorderColor="#666666" BorderStyle="Solid" BorderWidth="2px" Width="350px" ShowHeader="False">
                                                                    <Columns>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="ViewLine" ImageUrl="~/Images/Icons/select.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:ButtonField>
                                                                        <asp:BoundField DataField="id" HeaderText="Id" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Left" Width="20px"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Name" HeaderText="Main Folder" ItemStyle-Width="250px" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Left" Width="250px"></ItemStyle>
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="EditLine" ImageUrl="~/Images/Icons/edit.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center"></ItemStyle>
                                                                        </asp:ButtonField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="myDelete" ImageUrl="~/Images/Icons/trash.png" HeaderText="Delete"></asp:ButtonField>
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#184D43" ForeColor="White" />
                                                                </asp:GridView>
                                                            </div>
                                                            <div class="divFormMng" style="width: 30px;">&nbsp;</div>
                                                            <div class="divFormMng" style="vertical-align: top;">
                                                                <asp:Panel ID="pnlAddMainDinner" runat="server" Visible="false">
                                                                    <div>#<asp:TextBox ID="txtMainFolderIdDinner" runat="server" Width="10px" BorderStyle="None" BackColor="Transparent"></asp:TextBox></div>
                                                                    <div class="divFormMng">
                                                                        <div class="divFormMng" style="width: 150px;">Name : </div>
                                                                        <div class="divFormMng">
                                                                            <asp:TextBox ID="txtMainNameDinner" runat="server" Width="250px" CssClass="textbox"></asp:TextBox></div>
                                                                    </div>
                                                                    <div>
                                                                        <div class="divFormMng" style="width: 150px;">Description (optional) : </div>
                                                                        <div class="divFormMng">
                                                                            <asp:TextBox ID="TextBox1Dinner" runat="server" Height="40px" TextMode="MultiLine" Width="250px" CssClass="textbox"></asp:TextBox></div>
                                                                    </div>
                                                                    <div>
                                                                        <div class="divFormMng" style="width: 150px;">&nbsp;</div>
                                                                        <div class="divFormMng">
                                                                            <asp:Button ID="btnSubmitMainDinner" runat="server" CssClass="nextPrevButton" Text="Submit" /></div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div>
                                                <asp:Panel ID="pnlDinnerSub" runat="server" Visible="false">
                                                    <div style="border-top-style: solid; border-width: thin; padding: 5px;">
                                                        <div>
                                                            Click on &quot;Create New Sub Album&quot; to create a Sub Album.<br />
                                                            After Sub Album is created click on the Select Icon&nbsp;
                                                            <asp:Image ID="Image9" runat="server" ImageUrl="~/Images/Icons/select.png" />
                                                            to load images.
                                                        </div>
                                                        <div>&nbsp;</div>
                                                        <div class="headers">
                                                            <span class="HeaderLabel">#</span>
                                                            <asp:Label ID="lblMainIdDinner" runat="server" Text="" CssClass="HeaderLabel"></asp:Label>&nbsp;
                                                            <asp:Label ID="txtMainDinner" runat="server" Text="" CssClass="HeaderLabel"></asp:Label>
                                                        </div>
                                                        <div>&nbsp;</div>
                                                        <div>
                                                            <asp:Button ID="btnAddSubFolderDinner" runat="server" CssClass="button" Text="Create New Sub Album" /></div>
                                                        <div>&nbsp;</div>
                                                        <div>
                                                            <div class="divFormMng" style="vertical-align: top;">
                                                                <asp:GridView ID="gridDinnerSub" runat="server" AutoGenerateColumns="False" Font-Names="Calibri" Font-Size="Small" BorderColor="#666666" BorderStyle="Solid" BorderWidth="2px" Width="350px" ShowHeader="False">
                                                                    <Columns>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="ViewLine" ImageUrl="~/Images/Icons/select.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:ButtonField>
                                                                        <asp:BoundField DataField="subId" HeaderText="Id" ItemStyle-Width="20px" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Left" Width="20px" />
                                                                        </asp:BoundField>
                                                                        <asp:BoundField DataField="Name" HeaderText="Main Folder" ItemStyle-Width="300px" ItemStyle-HorizontalAlign="Left">
                                                                            <ItemStyle HorizontalAlign="Left" Width="300px" />
                                                                        </asp:BoundField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="EditLine" ImageUrl="~/Images/Icons/edit.png" Text="Edit Line" ItemStyle-HorizontalAlign="Center">
                                                                            <ItemStyle HorizontalAlign="Center" />
                                                                        </asp:ButtonField>
                                                                        <asp:ButtonField ButtonType="Image" CommandName="myDelete" ImageUrl="~/Images/Icons/trash.png" HeaderText="Delete"></asp:ButtonField>
                                                                    </Columns>
                                                                    <HeaderStyle BackColor="#184D43" ForeColor="White" />
                                                                </asp:GridView>
                                                            </div>
                                                            <div class="divFormMng" style="width: 30px;">&nbsp;</div>
                                                            <div class="divFormMng" style="vertical-align: top;">
                                                                <asp:Panel ID="pnlSubFolderDinner" runat="server" Visible="false">
                                                                    <div>#<asp:TextBox ID="txtsubIdDinner" runat="server" Width="10px" BorderStyle="None" BackColor="Transparent"></asp:TextBox></div>
                                                                    <div class="divFormMng">
                                                                        <div class="divFormMng" style="width: 150px;">Name : </div>
                                                                        <div class="divFormMng">
                                                                            <asp:TextBox ID="txtSubDinner" runat="server" Width="250px" CssClass="textbox"></asp:TextBox></div>
                                                                    </div>
                                                                    <div>
                                                                        <div class="divFormMng" style="width: 150px;">Description (optional) : </div>
                                                                        <div class="divFormMng">
                                                                            <asp:TextBox ID="TextBox2Dinner" runat="server" Height="40px" TextMode="MultiLine" Width="250px" CssClass="textbox"></asp:TextBox></div>
                                                                    </div>
                                                                    <div>
                                                                        <div class="divFormMng" style="width: 150px;">&nbsp;</div>
                                                                        <div class="divFormMng">
                                                                            <asp:Button ID="btnAddDinner" runat="server" CssClass="nextPrevButton" Text="Submit" /></div>
                                                                    </div>
                                                                </asp:Panel>
                                                            </div>
                                                        </div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div>
                                                <asp:Panel ID="pnlDinnerPhoto" runat="server" Visible="false">
                                                    <div style="border-top-style: solid; border-width: thin; padding: 5px;">
                                                        <div class="headers"><span class="HeaderLabel">#</span><asp:Label ID="lblMain1Dinner" runat="server" Text="" CssClass="HeaderLabel"></asp:Label></div>
                                                        <div class="headers"><span class="HeaderLabel">#</span><asp:Label ID="txtSubId1Dinner" runat="server" Text="" CssClass="HeaderLabel"></asp:Label>&nbsp;<asp:Label ID="txtSub1Dinner" runat="server" Text="" CssClass="HeaderLabel"></asp:Label></div>
                                                        <div>&nbsp;</div>
                                                        <div>
                                                            <div class="divFormMng" style="width: 150px;">Photo Name : </div>
                                                            <div class="divFormMng">
                                                                <asp:TextBox ID="txtPhotoDinner" runat="server" Width="300px" CssClass="textbox"></asp:TextBox>&nbsp(20 characters)</div>
                                                        </div>
                                                        <div>
                                                            <div class="divFormMng" style="width: 150px;">&nbsp;</div>
                                                            <div class="divFormMng">
                                                                <asp:FileUpload ID="FileUpload2" runat="server" CssClass="textbox" />&nbsp;(97 x 102)</div>
                                                        </div>
                                                        <div>
                                                            <div class="divFormMng" style="width: 150px;">&nbsp;</div>
                                                            <div class="divFormMng">
                                                                <asp:Button ID="btnUploadDinner" runat="server" CssClass="button" Text="Update" /></div>
                                                        </div>
                                                        <div>&nbsp;</div>
                                                        <div>
                                                            <asp:PlaceHolder ID="PlaceHolder2" runat="server"></asp:PlaceHolder>
                                                        </div>
                                                        <div>&nbsp;</div>
                                                    </div>
                                                </asp:Panel>
                                            </div>
                                            <div>&nbsp;</div>
                                        </asp:Panel>
                                    </asp:Panel>
                                </div>
                                <div>&nbsp;</div>
                                <div class="auto-style10">&nbsp;<asp:Label ID="lblMsg" runat="server" Text=""></asp:Label></div>
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>

    <img alt="" src="javascript:javascript:thisonload()" />
    <asp:Button ID="btnDRates" runat="server" Text="" CssClass="buttonHidden" />
    <asp:Button ID="btnR" runat="server" Text="" CssClass="buttonHidden" />
    <asp:Button ID="btnAccGallery" runat="server" Text="" CssClass="buttonHidden" />
    <asp:Button ID="btnC" runat="server" Text="" CssClass="buttonHidden" />
    <asp:Button ID="btnDinnerGallery" runat="server" Text="" CssClass="buttonHidden" />
    <asp:Button ID="btnAccRate" runat="server" Text="" CssClass="buttonHidden" />


    <script type="text/javascript">
        <%--function TogglemyDetails(Type) {
            var hiddenType
            if (document.getElementById('<%= HiddenType.ClientID %>').value == Type) {
                Type = '';
                hiddenType = document.getElementById('<%= HiddenType.ClientID %>');
                hiddenType.value = '';
                var btnType = document.getElementById('<%= btnTabClick.ClientID %>');
                btnType.click();
            } else {
                hiddenType = document.getElementById('<%= HiddenType.ClientID %>');
                hiddenType.value = Type;
                var btnType = document.getElementById('<%= btnTabClick.ClientID %>');
                btnType.click();
            }            
        }--%>

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

    </script>

</asp:Content>



