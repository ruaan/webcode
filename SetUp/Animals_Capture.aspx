<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Animals_Capture.aspx.vb" Inherits="SetUp_Animals_Capture" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="h1">Capture Animals</div>
    <div style="vertical-align: top;" class="divMainContainerBackgroundColour">
        <div id="animalList" class="divFormMng" style="width: 30%; vertical-align: top;">
            <div>
                <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="lineButton" />
            </div>
            <div>&nbsp;</div>
            <div>
                <asp:TextBox ID="txtSearch" runat="server" CssClass="textbox"></asp:TextBox><asp:ImageButton ID="imgBtnSearch" runat="server" ImageUrl="~/Images/Icons/search.png" />
            </div>
            <div>&nbsp;</div>
            <asp:GridView ID="grdAnimals" runat="server" AutoGenerateColumns="False" GridLines="None" EmptyDataText="No Animals" ShowHeader="False">
                <Columns>
                    <asp:BoundField DataField="id" InsertVisible="False" ReadOnly="True" SortExpression="id">
                        <ItemStyle ForeColor="#494D50" />
                    </asp:BoundField>
                    <asp:BoundField DataField="Name" SortExpression="Description" HeaderText="Description" />
                    <asp:ButtonField ButtonType="Image" CommandName="View" ImageUrl="~/Images/Icons/edit.png" Text="Edit" />
                    <asp:ButtonField ButtonType="Image" CommandName="remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove" />
                </Columns>
            </asp:GridView>
            <asp:SqlDataSource ID="SqlAnimals" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT id, Name FROM [tbl_Animals]  ORDER BY [Name]"></asp:SqlDataSource>
        </div>
        <div runat="server" visible="false" id="divDetails" class="divFormMng" style="border: thin solid #BBB530; width: 60%; vertical-align: top; padding-left: 10px;">
            <div class="yellowHeader">Details</div>
            <div>&nbsp;<asp:Label ID="lblAnimalId" runat="server" Text=""></asp:Label></div>
            <div class="divFormMng">
                <div>Name</div>
                <div>
                    <asp:TextBox ID="txtName" runat="server" CssClass="textbox"></asp:TextBox>

                </div>
            </div>
            <div class="divFormMng" style="width: 10%">&nbsp;</div>
            <div class="divFormMng">
                <div>Scientific Name</div>
                <div>
                    <asp:TextBox ID="txtScientificName" runat="server" CssClass="textbox"></asp:TextBox>

                </div>

            </div>
            <div>&nbsp;</div>

            <div>
                <div>General Info</div>
                <div>
                    <asp:TextBox ID="txtInfo" runat="server" TextMode="MultiLine" CssClass="textbox" Width="80%"></asp:TextBox>
                </div>
            </div>
            <div>&nbsp;</div>
            <div>&nbsp;</div>
            <div>
                <table style="width: 100%;">
                    <tr>
                        <td>&nbsp;</td>
                        <td>Male</td>
                        <td>Female</td>
                    </tr>
                    <tr>
                        <td>Avg Mass</td>
                        <td>
                            <asp:TextBox ID="txtMaleMass" runat="server" CssClass="textbox"></asp:TextBox>Kg
                        </td>
                        <td>
                            <asp:TextBox ID="txtFeMaleMass" runat="server" CssClass="textbox"></asp:TextBox>Kg
                        </td>
                    </tr>
                    <tr>
                        <td>Avg Height</td>
                        <td>
                            <asp:TextBox ID="txtMaleHeight" runat="server" CssClass="textbox"></asp:TextBox>Cm
                        </td>
                        <td>
                            <asp:TextBox ID="txtFemaleHeight" runat="server" CssClass="textbox"></asp:TextBox>Cm
                        </td>
                    </tr>
                </table>
            </div>
            <div>&nbsp;</div>
            <div>
                <div class="divFormMng">
                    <div>Minimum Calibre</div>
                    <div>
                        <asp:TextBox ID="txtMinCalibre" runat="server" CssClass="textbox"></asp:TextBox>
                    </div>
                </div>
                <div class="divFormMng" style="width: 10%">&nbsp;</div>
                <div class="divFormMng">
                    <div>Recommended Calibre</div>
                    <div>
                        <asp:TextBox ID="txtRecommendedCalibre" runat="server" CssClass="textbox"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div>&nbsp;</div>
            <div>
                <div>Notes on Hunting</div>
                <div>
                    <asp:TextBox ID="txtHuntingNotes" runat="server" TextMode="MultiLine" CssClass="textbox" Width="80%"></asp:TextBox>
                </div>
            </div>
            <div>&nbsp;</div>
            <div>
                <div>Notes on Shot placement</div>
                <div>
                    <asp:TextBox ID="txtShotplacementNotes" runat="server" TextMode="MultiLine" CssClass="textbox" Width="80%"></asp:TextBox>
                </div>
            </div>
            <div>&nbsp;</div>
            <div style="text-align: center">
                <asp:Button ID="btnUpdateDescription" runat="server" Text="Update" CssClass="nextPrevButton" /><asp:Label ID="lblUpdateAnimal" runat="server"></asp:Label><asp:Button ID="btnClose" runat="server" Text="Close" CssClass="nextPrevButton" />
            </div>
            <div>&nbsp;</div>
            <div>&nbsp;</div>
            <div id="divPic" runat="server" style="width: 90%;">

                <div class="divContainer">
                    <div class="divFormMng">
                        <div>Front Picture</div>
                        <div>
                            <asp:Image ID="imgFront" runat="server" Width="124px" Height="124px" ImageUrl="~/Images/Animals/animal_PlaceHolder.jpg" />
                        </div>
                    </div>
                    <div class="divFormMng">
                        <div>Side Picture (optional, not used anywhere currently)</div>
                        <div>
                            <asp:Image ID="ImgSide" runat="server" Width="124px" Height="124px" ImageUrl="~/Images/Animals/animal_PlaceHolder.jpg" />
                        </div>
                    </div>
                    <div>&nbsp</div>
                    <div class="divFormMng">
                        <div>Spoor Picture</div>
                        <div>
                            <asp:Image ID="imgSpoort" runat="server" Width="124px" Height="124px" ImageUrl="~/Images/Animals/animal_PlaceHolder.jpg" />
                        </div>
                    </div>
                    <div class="divFormMng">
                        <div>Dung Picture</div>
                        <div>
                            <asp:Image ID="imgDung" runat="server" Width="124px" Height="124px" ImageUrl="~/Images/Animals/animal_PlaceHolder.jpg" />
                        </div>
                    </div>
                    <div>&nbsp</div>
                    <div>Shot Placement</div>
                    <div class="divFormMng">
                        <div>Side</div>
                        <div>
                            <asp:Image ID="imgShotSide" runat="server" Width="124px" Height="124px" ImageUrl="~/Images/Animals/animal_PlaceHolder.jpg" />
                        </div>
                    </div>
                    <div class="divFormMng">
                        <div>Front</div>
                        <div>
                            <asp:Image ID="imgShotFront" runat="server" Width="124px" Height="124px" ImageUrl="~/Images/Animals/animal_PlaceHolder.jpg" />
                        </div>
                    </div>
                    <div>&nbsp</div>
                    <div>&nbsp;</div>
                    <div>
                        What Picture are you uploading: &nbsp;
                        <asp:DropDownList ID="cmbPicType" runat="server" CssClass="textbox">
                            <asp:ListItem>SELECT</asp:ListItem>
                            <asp:ListItem>Front</asp:ListItem>
                            <asp:ListItem>Side</asp:ListItem>
                            <asp:ListItem>Spoor</asp:ListItem>
                            <asp:ListItem>Dung</asp:ListItem>
                            <asp:ListItem Value="ShotSide">Shot Placement Side</asp:ListItem>
                            <asp:ListItem Value="ShotFront">Shot Placement Front</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                    <div>&nbsp;</div>
                    <asp:FileUpload ID="FileUpload1" runat="server" CssClass="textbox" /><div>
                        <asp:Button ID="btnUploadProfilePic" runat="server" Text="Upload" CssClass="nextPrevButton" /><asp:Label ID="lblUploadMsg" runat="server"></asp:Label>
                    </div>
                    <%--<div>Picture can not exceed xxxkb and dimensions xxx heigt and xxx width.</div>--%>
                    <div>&nbsp;</div>
                </div>

            </div>
            <div>&nbsp</div>
        </div>
        <div id="divConfirmDelete" runat="server" visible="false" style="border: thin solid #BBB530" class="divFormMng">
            <div id="divareUsure" runat="server" visible="false">
                Are you sure you want to remove this animal? &nbsp; this action cannot be undone.
                <div style="text-align: center">
                    <asp:Button ID="btnYes" runat="server" Text="Yes" CssClass="nextPrevButton" /><asp:Label ID="lblDelNote" runat="server"></asp:Label><asp:Button ID="btnNo" runat="server" Text="No" CssClass="nextPrevButton" />
                </div>
                <div>&nbsp</div>
            </div>
            <div id="divDenied" runat="server">
                This animal is linked to the following farms and can therefore not be deleted.
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
        </div>
    </div>
    <div>&nbsp</div>
    <div></div>

    </div>
</asp:Content>

