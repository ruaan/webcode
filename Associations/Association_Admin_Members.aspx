<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Association_Admin_Members.aspx.vb" Inherits="Associations_Association_Admin_Members" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        .auto-style2 {
            width: 800px;
            align-content: center;
            margin: 0 auto;
            text-align: left;
            padding-left: 5px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div>&nbsp;</div>
    <div id="mainPageWrapper">
        <div class="div_MainBlock" style="text-align: left; align-content: center">
            <div>&nbsp;</div>
            <div id="divDetails" class="auto-style2">
                <div class="h1">Associations Members</div>
                <div>&nbsp;</div>
                <div>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="Association_Id"></asp:DropDownList>
                </div>
                <div>
                    <asp:Button ID="Button3" runat="server" Text="Add Member" CssClass="lineButton" />
                </div>
                <div id="divAddPanel" runat="server" style="border: thin solid #86B24F">
                    <div id="divaddSearch" runat="server" visible="false">
                        <div>Search for the member using, Name, Surname, Idno, Mobile number or Email address: &nbsp; </div>
                        <div>
                            <asp:TextBox ID="txtMemberSearch" runat="server" CssClass="textbox" Width="222px"></asp:TextBox>
                            &nbsp;<asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/search.png" /></div>
                    </div>
                    <div id="divSelect" runat="server" visible="false">
                        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="794px" EmptyDataText="No Members matches your search.">

                            <Columns>
                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/select.png" Text="Select" />
                                <asp:BoundField DataField="MemberId">
                                    <ItemStyle ForeColor="White" />
                                </asp:BoundField>
                                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                                <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                                <asp:BoundField HeaderText="Title" DataField="Title">
                                    <ItemStyle HorizontalAlign="Center" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Preffered Name" DataField="PreferredName">
                                    <ItemStyle HorizontalAlign="Left" />
                                </asp:BoundField>
                                <asp:BoundField HeaderText="Id No" DataField="IDNo">
                                    <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                    <ItemStyle HorizontalAlign="Right" />
                                </asp:BoundField>
                                <asp:BoundField DataField="CellNo" HeaderText="Mobile No" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                            </Columns>
                        </asp:GridView>
                    </div>
                    <div id="divAddDetails" runat="server" visible="false" style="border: thin solid #86B24F; padding: 5px">
                        <div>Eco-Hunter Id: 
                            <asp:Label ID="lblEcohunterId" runat="server" Text="Label"></asp:Label></div>
                        <div>Name: 
                            <asp:Label ID="lblAddName" runat="server" Text="Label"></asp:Label></div>
                        <div>Association Membership No: 
                            <asp:TextBox ID="txtAssociationNo" runat="server" CssClass="textbox"></asp:TextBox></div>
                        <div align="center">
                            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="button" />
                            &nbsp;<asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="button" />
                        </div>
                    </div>
                </div>
                <div>&nbsp;</div>
                <div>

                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" ShowFooter="True" Width="794px" EmptyDataText="No Members in system">

                        <Columns>
                            <asp:BoundField DataField="MemberId">
                                <ItemStyle ForeColor="White" />
                            </asp:BoundField>
                            <asp:BoundField DataField="Surname" HeaderText="Surname" />
                            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                            <asp:BoundField HeaderText="Title" DataField="Title">
                                <ItemStyle HorizontalAlign="Center" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Preffered Name" DataField="PreferredName">
                                <ItemStyle HorizontalAlign="Left" />
                            </asp:BoundField>
                            <asp:BoundField HeaderText="Id No" DataField="IDNo">
                                <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                <ItemStyle HorizontalAlign="Right" />
                            </asp:BoundField>
                            <asp:BoundField DataField="CellNo" HeaderText="Mobile No" />
                            <asp:BoundField DataField="Email" HeaderText="Email" />
                        </Columns>
                    </asp:GridView>

                </div>
            </div>
        </div>
    </div>
</asp:Content>

