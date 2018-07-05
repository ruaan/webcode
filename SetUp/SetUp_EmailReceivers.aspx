<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="SetUp_EmailReceivers.aspx.vb" Inherits="SetUp_SetUp_EmailReceivers" %>

<asp:Content ID="head" ContentPlaceHolderID="head" runat="Server">
    <style>
        .divFormMng {
            display: inline-block;
            vertical-align: top;
        }

        .divMainContainer {
            display: inline-block;
            width: 40%;
            vertical-align: top;
        }

        .divPagewide {
            vertical-align: top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="divPagewide">
                <div class="divMainContainer">
                    <div>&nbsp;</div>
                    <div>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" Width="51px" />
                    </div>
                    <div class="yellowHeader">Email Receivers:</div>
                    <div>&nbsp;</div>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No Email Receivers Recorded!!!">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" Text="View" ControlStyle-CssClass="nextPrevButton" CommandName="View">
                                    <ControlStyle CssClass="nextPrevButton"></ControlStyle>
                                </asp:ButtonField>
                                <asp:BoundField DataField="id" HeaderText="Id" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Active" HeaderText="Active" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

                    </div>
                </div>
                <div class="divFormMng">
                    <div>&nbsp;</div>
                    <div>
                        &nbsp;
                    </div>
                </div>
                <div id="pnlDetail" visible="false" runat="server" class="divFormMng">
                    <div>&nbsp;</div>
                    <div align="left" id="Div1" runat="server" style="border-left-style: solid; border-width: thin; border-color: #FFD42A; border-bottom-style: solid;">
                        <div>
                            <asp:Label ID="lblId" runat="server"></asp:Label>
                        </div>
                        <div>
                            Name:&nbsp;
                                        <asp:TextBox ID="txtEco_Tourism" runat="server" MaxLength="200" CssClass="textbox"></asp:TextBox>

                        </div>
                        <div>&nbsp;</div>
                        <div>
                            Email Address:&nbsp;
                                        <asp:TextBox ID="txtEmail" runat="server" MaxLength="200" CssClass="textbox" Width="149px"></asp:TextBox>

                        </div>
                        <div>&nbsp;</div>

                        <div>
                            <asp:CheckBox ID="chkActive" runat="server" TextAlign="Left" Text="Active" Checked="True" />
                        </div>
                        <div>&nbsp;</div>
                        <div align="center">
                            <div class="auto-style1">
                                <div style="display: inline-block">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" />
                                </div>
                                &nbsp;<div style="display: inline-block">
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" />
                                </div>
                                &nbsp;<div style="display: inline-block">
                                    <asp:Button ID="btnRemove" runat="server" Text="Delete" CssClass="button" />
                                </div>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div id="pnlRemoveConfirm" runat="server" visible="false" style="border: thin solid #FFD42A">
                            <div>
                                Are you sure you want to remove this Email receiver?<br />
                                This action cannot be reversed.
                            </div>
                            <div>&nbsp;</div>
                            <div align="center">
                                <div class="auto-style1">
                                    <div style="display: inline-block">
                                        <asp:Button ID="btnDeleteYes" runat="server" Text="Yes" CssClass="button" />
                                    </div>
                                    &nbsp;<div style="display: inline-block">
                                        <asp:Button ID="btnDeleteCancel" runat="server" Text="Cancel" CssClass="button" />
                                    </div>
                                </div>
                            </div>
                            <div>&nbsp;</div>
                        </div>
                        <div>&nbsp;</div>
                    </div>
                    <div>&nbsp;</div>
                    <div id="pnlEmails" runat="server" style="border-right-style: solid; border-bottom-style: solid; border-width: thin; border-color: #FFD42A">
                        <div>Emails that this Receiver receives:</div>
                        <div>
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" EmptyDataText="This user will not receive any emails.">
                                <Columns>
                                    <asp:BoundField DataField="EmailTypeId" HeaderText="Id" />
                                    <asp:BoundField DataField="EmailType" HeaderText="Email Type" />
                                    <asp:BoundField DataField="Active" HeaderText="Active" />
                                    <asp:ButtonField ButtonType="Image" Text="Remove" ImageUrl="~/Images/Icons/trash.png" CommandName="Remove"></asp:ButtonField>
                                    <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/edit.png" Text="Edit" CommandName="deactive" />
                                </Columns>
                            </asp:GridView>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <asp:Button ID="btnaddEmail" runat="server" Text="Add Email" CssClass="nextPrevButton" />
                        </div>
                        <div>&nbsp;</div>
                        <div id="pnlEmailList" runat="server" visible="false">
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" EmptyDataText="This user will not receive any emails.">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Id" />
                                    <asp:BoundField DataField="EmailType" HeaderText="Email Type" />
                                    <asp:TemplateField HeaderText="">
                                        <ItemTemplate>
                                            <asp:CheckBox ID="Chkreceive" runat="server" />
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <div>
                                <asp:Button ID="btnSumbit" runat="server" Text="Submit" CssClass="nextPrevButton" />
                                &nbsp;
                                <asp:Button ID="btnEmailListCancel" runat="server" Text="Cancel" CssClass="nextPrevButton" />
                            </div>
                            <div>&nbsp;</div>
                        </div>

                    </div>
                    <div>&nbsp;</div>
                    <div>
                        <asp:Button ID="btnDone" runat="server" Text="Done" CssClass="nextPrevButton" />
                    </div>
                </div>

            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

