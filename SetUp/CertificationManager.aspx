<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="CertificationManager.aspx.vb" Inherits="SetUp_CertificationManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style1 {
            width: 159px;
        }

        .divMainContainer {
            display: inline-block;
            width: 60%;
            vertical-align: top;
        }

        .divFormMng {
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div>
                <div class="divMainContainer">
                    <div>&nbsp;</div>
                    <div>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" Width="51px" />
                    </div>
                    <div class="yellowHeader">Certificate Options:</div>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No Certifates available to select">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" Text="View" ControlStyle-CssClass="nextPrevButton" CommandName="View">
                                    <ControlStyle CssClass="nextPrevButton"></ControlStyle>
                                </asp:ButtonField>
                                <asp:BoundField DataField="id" HeaderText="Id" />
                                <asp:BoundField DataField="Description" HeaderText="Description" />
                                <asp:BoundField DataField="Active" HeaderText="Active" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>

                    </div>
                </div>

                <div align="center" class="divFormMng">
                    <div>&nbsp;</div>
                    <div align="left" id="pnlDetail" runat="server" visible="false" style="border-left-style: solid; border-width: thin; border-color: #FFD42A; border-bottom-style: solid;">
                        <div>
                            <asp:Label ID="lblId" runat="server"></asp:Label>
                        </div>
                        <div>
                            Description:&nbsp;
                                        <asp:TextBox ID="txtDescription" runat="server" MaxLength="200" CssClass="textbox"></asp:TextBox>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <asp:CheckBox ID="chkActive" runat="server" TextAlign="Left" Text="Active" Checked="True" />
                        </div>
                        <div>&nbsp;</div>
                        <div align="center">
                            <div class="auto-style1">
                                <div style="float: left">
                                    <asp:Button ID="btnUpdate" runat="server" Text="Update" CssClass="button" />
                                </div>
                                <div>
                                    <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="button" />
                                </div>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                    </div>
                </div>
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>

</asp:Content>
