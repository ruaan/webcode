<%@ Page Language="VB" AutoEventWireup="false" CodeFile="CaptureEvent_App.aspx.vb" Inherits="Associations_CaptureEvent1_App" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        body {
            background-color: #394025;
            margin: 0;
        }

        .auto-style1 {
            width: 100%;
        }

        .divFilter {
            border: 1px solid #8d9296;
            font-size: medium;
            background-color: #5B6849;
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            font-family: Calibri;
            color: white;
        }

        .divResult {
            display: inline-block;
            vertical-align: top;
            text-align: left;
            padding-left: 10px;
        }



        .div_Farm_Block {
            border: 1px solid #333333;
            background-color: #F8F8F8;
            padding: 15px;
            font-family: Calibri;
            color: #333333;
            cursor: pointer;
        }

        .div_Picture_Style {
            width: 80px;
            height: 80px;
            display: inline-block;
        }

        .div_Farm_header {
            font-size: large;
            font-weight: bold
        }

        .div_Middle_Block {
            width: 300px;
            vertical-align: top;
            padding: 0px 10px 10px 10px;
            display: inline-block;
        }

        .div_right_block {
            width: 200px;
            vertical-align: top;
            padding-top: 0px;
            padding-left: 20px;
            display: inline-block;
            border-left-style: solid;
            border-width: thin;
            border-color: #FFFFFF;
        }

        .image_Style {
            width: 100%;
            height: 100%;
        }

        .div_text_block {
            height: 190px;
        }

        .icon_style {
            padding: 5px;
            display: inline-block;
        }

        .rateStar {
            width: 28px;
            height: 28px;
        }

        .div_facility_block {
            min-height: 150px;
        }

        .facilities {
            padding-bottom: 5px;
        }

        .drop_icon {
            width: 16px;
            height: 16px;
        }

        .header_icon {
            width: 21px;
            height: 21px;
            vertical-align: middle;
        }

        .arrow_icon {
            vertical-align: middle;
        }

        .header_text {
            padding-left: 5px;
        }

        .chkBoxList {
            margin-right: 10px;
            padding-right: 10px;
            padding-left: 10px;
            padding-bottom: 5px;
            width: 100%;
        }

        .thisButton {
            background-color: #7DB35C;
            border-style: none;
            color: white;
            font-size: 14px;
        }

        .divFormMng {
            display: inline-block;
            vertical-align: top;
        }

        .divMainContainer {
            display: inline-block;
            width: 1050px;
            vertical-align: top;
            align-content: center;
            text-align: left;
        }

        .divPagewide {
            vertical-align: top;
        }

        .Column1 {
            width: 200px;
            display: inline-block;
            height: 27px;
        }

        .cellHeight {
            height: 27px;
        }

        .buttonHidden {
            border: none;
            background-color: transparent;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
            <div id="divSearch" style="font-size: large">
                <div class="divFilter" id="divFilter">
                    <div>
                        <div>&nbsp;</div>
                        <div class="h1">Capture Event :</div>
                        <div>&nbsp;</div>
                        <div>
                            <div class="Column1">Association:</div>
                            <div class="divFormMng">
                                <asp:DropDownList ID="ddlAssociations" runat="server" Width="250px" DataTextField="Name" DataValueField="Association_Id" AutoPostBack="true"></asp:DropDownList></div>
                        </div>
                        <div>
                            <asp:Panel ID="pnlEvents" Visible="false" runat="server">
                                <div class="Column1">Event Type:</div>
                                <div class="divFormMng">
                                    <asp:DropDownList ID="ddlEvents" runat="server" Width="250px" DataTextField="Event_Name" DataValueField="event_id" AutoPostBack="true"></asp:DropDownList></div>
                            </asp:Panel>
                        </div>
                        <div class="cellHeight">&nbsp;<asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label></div>
                        <div>
                            <asp:Panel ID="pnlMember" Visible="false" runat="server">
                                <div class="divFormMng" style="width: 20%;">
                                    <div class="cellHeight">Member Name:</div>
                                    <div class="cellHeight">
                                        <asp:Label ID="lblName" runat="server" Text=""></asp:Label></div>
                                </div>
                                <div class="divFormMng" style="width: 20%;">
                                    <div class="cellHeight">Date:</div>
                                    <div class="cellHeight">
                                        <asp:TextBox ID="txtDate" CssClass="textbox" Width="200px" runat="server"></asp:TextBox>
                                        <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" TodaysDateFormat="yyyy/MM/dd" PopupPosition="BottomRight" />
                                    </div>
                                </div>
                                <div class="divFormMng" style="width: 20%;">
                                    <div class="cellHeight">Member No:</div>
                                    <div class="cellHeight">
                                        <asp:Label ID="lblMemberNo" runat="server" Text=""></asp:Label></div>
                                </div>
                                <div class="divFormMng" style="width: 20%;">
                                    <div class="cellHeight">ID No:</div>
                                    <div class="cellHeight">
                                        <asp:Label ID="lblIdNo" runat="server" Text=""></asp:Label></div>
                                </div>
                                <div class="divFormMng" style="width: 20%;">&nbsp;</div>
                            </asp:Panel>
                        </div>
                        <div>
                            <asp:Panel ID="pnlMain" Visible="false" runat="server">
                                <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" onclick="showPanel('<%=btnPostiveScoring.ClientID %>')">&nbsp;<asp:Image ID="Image6" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;&nbsp;&nbsp;Animal Targets (Positive Scoring)</div>
                                <div>
                                    <asp:Panel ID="pnl1" Visible="false" runat="server">
                                        <div>&nbsp;</div>
                                        <div>
                                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="80%" Font-Size="Small">
                                                <Columns>
                                                    <asp:BoundField DataField="id" HeaderText="Id" />
                                                    <asp:BoundField DataField="Name" HeaderText="Target Type" />
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Distance Meters">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtMeters" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x30">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX30" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x20">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX20" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x15">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX15" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x10">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX10" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x5">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX5" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div style="align-content: center;">
                                            <asp:Button ID="btnSave1" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                                    </asp:Panel>
                                </div>

                                <div>&nbsp;</div>
                                <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" onclick="showPanel('<%=btnVBulls.ClientID %>')">&nbsp;<asp:Image ID="Image1" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;&nbsp;&nbsp;Animal Targets (V-Bulls)</div>
                                <div>
                                    <asp:Panel ID="pnl2" Visible="false" runat="server">
                                        <div>&nbsp;</div>
                                        <div>
                                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="30%" Font-Size="Small">
                                                <Columns>
                                                    <asp:BoundField DataField="id" HeaderText="Id" />
                                                    <asp:BoundField DataField="Name" HeaderText="Target Type" />
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x0.1">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX01" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div style="align-content: center;">
                                            <asp:Button ID="btnSave2" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                                    </asp:Panel>
                                </div>

                                <div>&nbsp;</div>
                                <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" onclick="showPanel('<%=btnNegativeScoring.ClientID %>')">&nbsp;<asp:Image ID="Image2" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;&nbsp;&nbsp;Animal Targets (Negative Scoring)</div>
                                <div>
                                    <asp:Panel ID="pnl3" Visible="false" runat="server">
                                        <div>&nbsp;</div>
                                        <div>
                                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="80%" Font-Size="Small">
                                                <Columns>
                                                    <asp:BoundField DataField="id" HeaderText="Id" />
                                                    <asp:BoundField DataField="Name" HeaderText="Target Type" />
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Distance Meters">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtMeters" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x-30">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX30" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x-20">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX20" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x-15">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX15" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x-10">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX10" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x-5">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX5" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div style="align-content: center;">
                                            <asp:Button ID="btnSave3" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                                    </asp:Panel>
                                </div>

                                <div>&nbsp;</div>
                                <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" onclick="showPanel('<%=btnScoringTotals.ClientID %>')">&nbsp;<asp:Image ID="Image3" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;&nbsp;&nbsp;Animal Targets (Scoring Totals)</div>
                                <div>
                                    <asp:Panel ID="pnl4" Visible="false" runat="server">
                                        <div>&nbsp;</div>
                                        <div>
                                            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Width="65%" Font-Size="Small">
                                                <Columns>
                                                    <asp:BoundField DataField="id" HeaderText="Id" />
                                                    <asp:BoundField DataField="Name" HeaderText="Target Type" />
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Total">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtMeters" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Shots Fired">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX30" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Max Scoring">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX20" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="% Success">
                                                        <ItemTemplate>
                                                            <asp:TextBox ID="txtX15" runat="server" Width="50px"></asp:TextBox>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div style="align-content: center;">
                                            <asp:Button ID="btnSave4" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                                    </asp:Panel>
                                </div>

                                <div>&nbsp;</div>
                                <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" onclick="showPanel('<%=btnRange.ClientID %>')">&nbsp;<asp:Image ID="Image4" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;&nbsp;&nbsp;Range Name & Conditions</div>
                                <div>
                                    <asp:Panel ID="pnl5" Visible="false" runat="server">
                                        <div>&nbsp;</div>
                                        <div>
                                            <div class="divFormMng" style="width: 200px;">Range Name</div>
                                            <div class="divFormMng">
                                                <asp:TextBox ID="txtRangeName" Width="500px" CssClass="textbox" runat="server"></asp:TextBox></div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Temperature</div>
                                            <div>
                                                <asp:TextBox ID="txtTemperature" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Wind Speed</div>
                                            <div>
                                                <asp:TextBox ID="txtWindSpeed" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Wind Direction</div>
                                            <div>
                                                <asp:TextBox ID="txtWindDirection" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Pressure</div>
                                            <div>
                                                <asp:TextBox ID="txtPressure" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Humidity</div>
                                            <div>
                                                <asp:TextBox ID="txtHumidity" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Altitude</div>
                                            <div>
                                                <asp:TextBox ID="txtAltitude" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Target Direction</div>
                                            <div>
                                                <asp:TextBox ID="txtTargetDirection" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Calibre Gun</div>
                                            <div>
                                                <asp:TextBox ID="txtCalibreGun" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Bullet Grain</div>
                                            <div>
                                                <asp:TextBox ID="txtBulletGrain" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div style="align-content: center;">
                                            <asp:Button ID="btnSave5" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                                    </asp:Panel>
                                </div>

                                <div>&nbsp;</div>
                                <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" onclick="showPanel('<%=btnGong.ClientID %>')">&nbsp;<asp:Image ID="Image5" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;&nbsp;&nbsp;Gong</div>
                                <div>
                                    <asp:Panel ID="pnl6" Visible="false" runat="server">
                                        <div>&nbsp;</div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Gong 1 (x30)</div>
                                            <div>
                                                <asp:TextBox ID="txtGong1" Width="120px" CssClass="textbox" runat="server"></asp:TextBox></div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Gong 2 (x30)</div>
                                            <div>
                                                <asp:TextBox ID="txtGong2" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Gong 3 (x30)</div>
                                            <div>
                                                <asp:TextBox ID="txtGong3" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Gong 4 (x30)</div>
                                            <div>
                                                <asp:TextBox ID="txtGong4" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Gong 5 (x30)</div>
                                            <div>
                                                <asp:TextBox ID="txtGong5" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Total</div>
                                            <div>
                                                <asp:TextBox ID="txtGongTotal" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Shots Fired <span style="font-size: xx-small;">(SF)</span></div>
                                            <div>
                                                <asp:TextBox ID="txtGongSF" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Max Scoring <span style="font-size: xx-small;">(SF)x30</span></div>
                                            <div>
                                                <asp:TextBox ID="txtGongMS" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">% Success<span style="font-size: xx-small;">Total/Max Scoring</span></div>
                                            <div>
                                                <asp:TextBox ID="txtGongSuccess" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div style="align-content: center;">
                                            <asp:Button ID="btnSave6" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                                    </asp:Panel>
                                </div>

                                <div>&nbsp;</div>
                                <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" onclick="showPanel('<%=btnGongTotals.ClientID %>')">&nbsp;<asp:Image ID="Image7" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;&nbsp;&nbsp;Gong Totals</div>
                                <div>
                                    <asp:Panel ID="pnl7" Visible="false" runat="server">
                                        <div>&nbsp;</div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;"><b>Total</b></div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px; height: 27px;">Animal Targets</div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px; height: 27px;">Gong Scoring</div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px; height: 27px;">Event Total</div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Total</div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtAnimalTargetTotal" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtGongScoringTotal" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtEventTotalTotal" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Shots Fired</div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtAnimalTargetSF" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtGongScoringSF" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtEventTotalSF" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">Max Scoring</div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtAnimalTargetMS" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtGongScoringMS" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtEventTotalMS" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div class="divFormMng">
                                            <div style="width: 150px;">% Success</div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtAnimalTargetSuccess" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtGongScoringSuccess" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                            <div>&nbsp;</div>
                                            <div style="width: 150px;">
                                                <asp:TextBox ID="txtEventTotalSuccess" Width="120px" CssClass="textbox" runat="server"></asp:TextBox>
                                            </div>
                                        </div>
                                        <div>&nbsp;</div>
                                        <div style="align-content: center;">
                                            <asp:Button ID="btnSave7" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                                    </asp:Panel>
                                </div>

                                <div>&nbsp;</div>
                                <div style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-size: large; font-family: Calibri;" onclick="showPanel('<%=btnUpload.ClientID %>')">&nbsp;<asp:Image ID="Image8" runat="server" ImageUrl="~/Images/Icons/numDown1.png" />&nbsp;&nbsp;&nbsp;Upload Scoresheet</div>
                                <div>
                                    <asp:Panel ID="pnl8" Visible="false" runat="server">
                                        <div>&nbsp;</div>
                                        <div>Upload Scoresheet:&nbsp;<asp:FileUpload ID="FileUpload1" Width="300px" runat="server" /></div>
                                        <div>&nbsp;</div>
                                        <div style="align-content: center;">
                                            <asp:Button ID="btnSave8" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                                    </asp:Panel>
                                </div>

                            </asp:Panel>
                        </div>
                    </div>
                    <img alt="" src="javascript:javascript:thisonload()" />
                    <asp:Button ID="btnPostiveScoring" runat="server" Text="" CssClass="buttonHidden" />
                    <asp:Button ID="btnVBulls" runat="server" Text="" CssClass="buttonHidden" />
                    <asp:Button ID="btnNegativeScoring" runat="server" Text="" CssClass="buttonHidden" />
                    <asp:Button ID="btnScoringTotals" runat="server" Text="" CssClass="buttonHidden" />
                    <asp:Button ID="btnRange" runat="server" Text="" CssClass="buttonHidden" />
                    <asp:Button ID="btnGong" runat="server" Text="" CssClass="buttonHidden" />
                    <asp:Button ID="btnGongTotals" runat="server" Text="" CssClass="buttonHidden" />
                    <asp:Button ID="btnUpload" runat="server" Text="" CssClass="buttonHidden" />
                    <asp:HiddenField ID="HiddenField1" runat="server" />
                </div>
            </div>
        </div>

        <script type="text/javascript">
            function showPanel(selecbutton) {
                document.getElementById(selecbutton).click();
            }
        </script>

    </form>
</body>
</html>
