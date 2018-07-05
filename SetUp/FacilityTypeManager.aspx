<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="FacilityTypeManager.aspx.vb" Inherits="SetUp_FacilityTypeManager" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .divFormMng {
            display: inline-block;
            vertical-align: top;
        }

        .divMainContainer {
            display: inline-block;
            width: 60%;
            vertical-align: top;
        }

        .divPagewide {
            vertical-align: top;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <ContentTemplate>
            <div class="divPagewide">
                <div class="divMainContainer">
                    <div>&nbsp;</div>
                    <div>
                        <asp:Button ID="btnAdd" runat="server" Text="Add" CssClass="button" Width="51px" />
                    </div>
                    <div class="yellowHeader">Facility Types:</div>
                    <div>
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="No Facilities available to select">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" Text="View" ControlStyle-CssClass="nextPrevButton" CommandName="View">
                                    <ControlStyle CssClass="nextPrevButton"></ControlStyle>
                                </asp:ButtonField>
                                <asp:BoundField DataField="id" HeaderText="Id" />
                                <asp:BoundField DataField="FacilityType" HeaderText="Facility" />
                                <asp:BoundField DataField="Active" HeaderText="Active" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div>
                        <asp:Label ID="lblMessage" runat="server" Text=""></asp:Label>
                    </div>
                </div>
                <div id="pnlDetail" visible="false" runat="server" class="divFormMng">
                    <div align="center">
                        <div>&nbsp;</div>
                        <div align="left" style="border-left-style: solid; border-width: thin; border-color: #FFD42A; border-bottom-style: solid;">
                            <div>
                                <asp:Label ID="lblId" runat="server"></asp:Label>
                            </div>
                            <div>
                                Facility:&nbsp;
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
            </div>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>

