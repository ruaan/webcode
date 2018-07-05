<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="AssociationManager.aspx.vb" Inherits="SetUp_AssociationManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .divFormMng {
            display: inline-block;
            vertical-align: top;
        }

        .divMainContainer {
            display: inline-block;
            /*width: 30%;*/
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
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
        <ContentTemplate>
            <div class="divPagewide">
                <div class="divMainContainer">
                    <div>&nbsp;</div>
                    <div class="yellowHeader">Associations:</div>
                    <div>&nbsp;</div>
                    <div>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" Width="51px" /></div>
                    <div>&nbsp;</div>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No Associations available to select" Width="100%">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" Text="View" ControlStyle-CssClass="button" CommandName="View">
                                    <ControlStyle CssClass="button" />
                                </asp:ButtonField>
                                <asp:BoundField DataField="Association_Id" HeaderText="Id" />
                                <asp:BoundField DataField="Name" HeaderText="Association" />
                                <asp:BoundField DataField="Active" HeaderText="Active" />
                                <asp:ButtonField ButtonType="Button" CommandName="Users" Text="Users" ControlStyle-CssClass="button">
                                    <ControlStyle CssClass="button" />
                                </asp:ButtonField>
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div>&nbsp;</div>
                    <div>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

                    </div>
                </div>
                <div class="divFormMng" style="width: 30px;">
                    <div>&nbsp;</div>
                    <div>&nbsp;</div>
                </div>
                <div id="pnlDetail" visible="false" runat="server" class="divFormMng">
                    <div>&nbsp;</div>
                    <div align="left" id="Div1" runat="server" style="border-left-style: solid; border-width: thin; border-color: #000000; border-bottom-style: solid;">
                        <div style="padding: 5px;">

                            <div class="divFormMng">
                                <div>
                                    <asp:Image ID="Image1" runat="server" BorderColor="#3E432F" BorderStyle="Solid" BorderWidth="2px" Height="200px" Width="200px" />
                                </div>
                                <div>&nbsp;</div>
                                <div>Picture can not exceed 500kb and dimensions 300px height and 300px width</div>
                                <div>
                                    <asp:FileUpload ID="FileUpload1" runat="server" /></div>
                                <div>&nbsp;</div>
                                <div>
                                    <asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="button" Width="80px" />&nbsp;<asp:Label ID="lblUploadMsg" runat="server" Text=""></asp:Label></div>
                            </div>

                            <div>#<asp:Label ID="lblId" runat="server"></asp:Label></div>

                            <div class="Column1">Association Name:</div>
                            <div style="display: inline-block;">
                                <asp:TextBox ID="txtDescription" runat="server" MaxLength="200" CssClass="textbox"></asp:TextBox></div>
                            <div>&nbsp;</div>

                            <div class="Column1">Contact Person:</div>
                            <div style="display: inline-block;">
                                <asp:TextBox ID="TextBox1" runat="server" MaxLength="200" CssClass="textbox"></asp:TextBox></div>
                            <div>&nbsp;</div>

                            <div class="Column1">Email Address:</div>
                            <div style="display: inline-block;">
                                <asp:TextBox ID="TextBox2" runat="server" MaxLength="200" CssClass="textbox"></asp:TextBox></div>
                            <div>&nbsp;</div>

                            <div class="Column1">Telephone Number:</div>
                            <div style="display: inline-block;">
                                <asp:TextBox ID="TextBox3" runat="server" MaxLength="200" CssClass="textbox"></asp:TextBox></div>
                            <div>&nbsp;</div>

                            <div class="Column1">Short Description:</div>
                            <div style="display: inline-block;">
                                <asp:TextBox ID="txtShort" runat="server" MaxLength="500" CssClass="textbox" TextMode="MultiLine" Rows="5" Width="500px"></asp:TextBox></div>
                            <div>&nbsp;</div>

                            <div class="Column1">Long Description:</div>
                            <div style="display: inline-block;">
                                <asp:TextBox ID="txtLong" runat="server" CssClass="textbox" TextMode="MultiLine" Rows="5" Width="500px"></asp:TextBox></div>
                            <div>&nbsp;</div>

                            <div>
                                <asp:CheckBox ID="chkActive" runat="server" TextAlign="Left" Text="Active" Checked="True" /></div>
                            <div>&nbsp;</div>

                            <div align="center">
                                <div class="auto-style1">
                                    <div style="float: left">
                                        <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" /></div>
                                    <div>
                                        <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" /></div>
                                </div>
                            </div>
                            <div>&nbsp;</div>
                        </div>
                    </div>
                </div>

                <div class="divFormMng">
                    <div>&nbsp;</div>
                    <asp:Panel ID="pnlUsers" runat="server" CssClass="panel" Visible="False">
                        <table style="width: 100%;">
                            <tr>
                                <td>Users Linked to:
                                <asp:Label ID="lblassociationName" runat="server"></asp:Label>
                                    <asp:Label ID="lblAssocId" runat="server" ForeColor="White"></asp:Label>
                                </td>
                                <td align="right">
                                    <asp:Button ID="Button2" runat="server" CssClass="lineButton" Text="Close" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" EmptyDataText="No Users linked to this Association">
                                        <Columns>
                                            <asp:BoundField />
                                            <asp:BoundField DataField="id" HeaderText="Link Id" />
                                            <asp:BoundField DataField="NickName" HeaderText="Actual Name" />
                                            <asp:BoundField DataField="UserId" HeaderText="User Id" />
                                            <asp:BoundField DataField="Type" HeaderText="Type" />
                                            <asp:BoundField DataField="UserName" HeaderText="User Name" />
                                            <asp:BoundField DataField="UserActive" HeaderText="User Active" />
                                            <asp:BoundField DataField="LastLoggedIn" HeaderText="Last Logged In" />
                                        </Columns>
                                    </asp:GridView>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Button ID="Button3" runat="server" CssClass="button" Text="Create user for this association" />
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <asp:Panel ID="pnlCreateUser" runat="server" CssClass="panel" Visible="False">
                                        <table style="width: 100%;">
                                            <tr>
                                                <td>Actual Name</td>
                                                <td>
                                                    <asp:TextBox ID="txtActualUser" runat="server" CssClass="textbox" Width="210px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>User Email:</td>
                                                <td>
                                                    <asp:TextBox ID="txtUserName" runat="server" CssClass="textbox" Width="210px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>Password:</td>
                                                <td>
                                                    <asp:TextBox ID="txtPassword" runat="server" CssClass="textbox" Width="210px"></asp:TextBox>
                                                </td>
                                            </tr>
                                            <tr>
                                                <td>&nbsp;</td>
                                                <td>
                                                    <asp:Button ID="Button4" runat="server" Text="Save" CssClass="button" />
                                                    &nbsp;
                                                <asp:Button ID="Button5" runat="server" Text="Cancel" CssClass="button" />
                                                    <asp:Label ID="lblUserMsg" runat="server"></asp:Label>
                                                </td>
                                            </tr>
                                        </table>
                                    </asp:Panel>
                                </td>
                            </tr>
                        </table>
                    </asp:Panel>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

