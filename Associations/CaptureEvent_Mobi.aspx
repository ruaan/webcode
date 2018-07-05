<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageMobi.master" AutoEventWireup="false" CodeFile="CaptureEvent_Mobi.aspx.vb" Inherits="Associations_CaptureEvent1_Mobi" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        body {
            background-color: #394025;
            margin: 0;
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
            font-size: 60px;
            color: white;
        }

        .divPagewide {
            vertical-align: top;
        }

        .Column1 {
            width: 50%;
            display: inline-block;
            height: 27px;
        }

        .cellHeight {
            /*height: 27px;*/
        }

        .buttonHidden {
            border: none;
            background-color: transparent;
        }

        .headers {
            font-size: 60px;
        }

        .button {
            font-size: 60px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div class="divMainContainer">
        <div>Capture Event :</div>
        <div>&nbsp;</div>
        <div>
            <div class="Column1">Association:</div>
            <div class="divFormMng">
                <asp:DropDownList ID="ddlAssociations" runat="server" Width="250px" DataTextField="Name" DataValueField="Association_Id" AutoPostBack="true" Font-Size="60px"></asp:DropDownList></div>
        </div>
        <div>
            <asp:Panel ID="pnlEvents" Visible="false" runat="server">
                <div class="Column1">Event Type:</div>
                <div class="divFormMng">
                    <asp:DropDownList ID="ddlEvents" runat="server" Width="250px" DataTextField="Event_Name" DataValueField="event_id" AutoPostBack="true" Font-Size="60px"></asp:DropDownList></div>
            </asp:Panel>
        </div>
        <div class="cellHeight">&nbsp;<asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label></div>
        <div>
            <asp:Panel ID="pnlMember" Visible="false" runat="server">
                <div class="cellHeight" style="display: inline-block;">Member Name:</div>
                <div class="cellHeight" style="display: inline-block;">
                    <asp:Label ID="lblName" runat="server" Text=""></asp:Label></div>
                <div>&nbsp;</div>
                <div class="cellHeight" style="display: inline-block;">Date:</div>
                <div class="cellHeight" style="display: inline-block;">
                    <asp:TextBox ID="txtDate" CssClass="textbox" Width="250px" runat="server" Font-Size="60px"></asp:TextBox>
                    <cc1:CalendarExtender ID="CalendarExtender1" runat="server" TargetControlID="txtDate" TodaysDateFormat="yyyy/MM/dd" PopupPosition="BottomRight" />
                </div>
                <div>&nbsp;</div>
                <div class="cellHeight" style="display: inline-block;">Member No:</div>
                <div class="cellHeight" style="display: inline-block;">
                    <asp:Label ID="lblMemberNo" runat="server" Text=""></asp:Label></div>
                <div>&nbsp;</div>
                <div class="cellHeight" style="display: inline-block;">ID No:</div>
                <div class="cellHeight" style="display: inline-block;">
                    <asp:Label ID="lblIdNo" runat="server" Text=""></asp:Label></div>
                <div style="width: 20%;">&nbsp;</div>
            </asp:Panel>
        </div>
        <div>
            <asp:Panel ID="pnlMain" Visible="false" runat="server">
                <div class="headers" style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-family: Calibri;" onclick="showPanel('<%=btnPostiveScoring.ClientID %>')">&nbsp;Animal Targets (Positive Scoring)</div>
                <div>
                    <asp:Panel ID="pnl1" Visible="false" runat="server">
                        <div>&nbsp;</div>
                        <div>
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" Width="100%" Font-Size="40px" Font-Names="Calibri">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Id" />
                                    <asp:BoundField DataField="Name" HeaderText="Target Type" />
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Distance Meters" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMeters" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x30" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX30" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x20" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX20" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x15" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX15" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x10" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX10" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x5" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX5" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                        </div>
                        <div>&nbsp;</div>
                        <div style="align-content: center;">
                            <asp:Button ID="btnSave1" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                    </asp:Panel>
                </div>

                <div>&nbsp;</div>
                <div class="headers" style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-family: Calibri;" onclick="showPanel('<%=btnVBulls.ClientID %>')">&nbsp;Animal Targets (V-Bulls)</div>
                <div>
                    <asp:Panel ID="pnl2" Visible="false" runat="server">
                        <div>&nbsp;</div>
                        <div>
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="100%" Font-Size="40px" Font-Names="Calibri">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Id" />
                                    <asp:BoundField DataField="Name" HeaderText="Target Type" />
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x0.1" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX01" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                        </div>
                        <div>&nbsp;</div>
                        <div style="align-content: center;">
                            <asp:Button ID="btnSave2" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                    </asp:Panel>
                </div>

                <div>&nbsp;</div>
                <div class="headers" style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-family: Calibri;" onclick="showPanel('<%=btnNegativeScoring.ClientID %>')">&nbsp;Animal Targets (Negative Scoring)</div>
                <div>
                    <asp:Panel ID="pnl3" Visible="false" runat="server">
                        <div>&nbsp;</div>
                        <div>
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" Width="100%" Font-Size="40px" Font-Names="Calibri">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Id" />
                                    <asp:BoundField DataField="Name" HeaderText="Target Type" />
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Distance Meters" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMeters" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x-30" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX30" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x-20" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX20" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x-15" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX15" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x-10" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX10" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="x-5" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX5" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                        </div>
                        <div>&nbsp;</div>
                        <div style="align-content: center;">
                            <asp:Button ID="btnSave3" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                    </asp:Panel>
                </div>

                <div>&nbsp;</div>
                <div class="headers" style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-family: Calibri;" onclick="showPanel('<%=btnScoringTotals.ClientID %>')">&nbsp;Animal Targets (Scoring Totals)</div>
                <div>
                    <asp:Panel ID="pnl4" Visible="false" runat="server">
                        <div>&nbsp;</div>
                        <div>
                            <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" Width="100%" Font-Size="40px" Font-Names="Calibri">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="Id" />
                                    <asp:BoundField DataField="Name" HeaderText="Target Type" />
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Total" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtMeters" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Shots Fired" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX30" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="Max Scoring" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX20" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField ItemStyle-Width="10%" HeaderText="% Success" ItemStyle-HorizontalAlign="Center">
                                        <ItemTemplate>
                                            <asp:TextBox ID="txtX15" runat="server" Width="90px" Font-Size="40px"></asp:TextBox>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <HeaderStyle BackColor="#CCCCCC" />
                            </asp:GridView>
                        </div>
                        <div>&nbsp;</div>
                        <div style="align-content: center;">
                            <asp:Button ID="btnSave4" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                    </asp:Panel>
                </div>

                <div>&nbsp;</div>
                <div class="headers" style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-family: Calibri;" onclick="showPanel('<%=btnRange.ClientID %>')">&nbsp;Range Name & Conditions</div>
                <div>
                    <asp:Panel ID="pnl5" Visible="false" runat="server">
                        <div>&nbsp;</div>
                        <div>
                            <div class="divFormMng" style="width: 50%;">Range Name</div>
                            <div class="divFormMng">
                                <asp:TextBox ID="txtRangeName" Width="300px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox></div>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <div class="divFormMng" style="width: 50%;">Temperature</div>
                            <div class="divFormMng">
                                <asp:TextBox ID="txtTemperature" Width="300px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <div class="divFormMng" style="width: 50%;">Wind Speed</div>
                            <div class="divFormMng">
                                <asp:TextBox ID="txtWindSpeed" Width="300px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <div class="divFormMng" style="width: 50%;">Wind Direction</div>
                            <div class="divFormMng">
                                <asp:TextBox ID="txtWindDirection" Width="300px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <div class="divFormMng" style="width: 50%;">Pressure</div>
                            <div class="divFormMng">
                                <asp:TextBox ID="txtPressure" Width="300px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <div class="divFormMng" style="width: 50%;">Humidity</div>
                            <div class="divFormMng">
                                <asp:TextBox ID="txtHumidity" Width="300px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <div class="divFormMng" style="width: 50%;">Altitude</div>
                            <div class="divFormMng">
                                <asp:TextBox ID="txtAltitude" Width="300px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <div class="divFormMng" style="width: 50%;">Target Direction</div>
                            <div class="divFormMng">
                                <asp:TextBox ID="txtTargetDirection" Width="300px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <div class="divFormMng" style="width: 50%;">Calibre Gun</div>
                            <div class="divFormMng">
                                <asp:TextBox ID="txtCalibreGun" Width="300px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div>
                            <div class="divFormMng" style="width: 50%;">Bullet Grain</div>
                            <div class="divFormMng">
                                <asp:TextBox ID="txtBulletGrain" Width="300px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div style="align-content: center;">
                            <asp:Button ID="btnSave5" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                    </asp:Panel>
                </div>

                <div>&nbsp;</div>
                <div class="headers" style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-family: Calibri;" onclick="showPanel('<%=btnGong.ClientID %>')">&nbsp;Gong</div>
                <div>
                    <asp:Panel ID="pnl6" Visible="false" runat="server">
                        <div>&nbsp;</div>
                        <div class="divFormMng" style="width: 33%;">
                            <div>Gong 1 (x30)</div>
                            <div>
                                <asp:TextBox ID="txtGong1" Width="200px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox></div>
                        </div>
                        <div class="divFormMng" style="width: 33%;">
                            <div>Gong 2 (x30)</div>
                            <div>
                                <asp:TextBox ID="txtGong2" Width="200px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng" style="width: 33%;">
                            <div>Gong 3 (x30)</div>
                            <div>
                                <asp:TextBox ID="txtGong3" Width="200px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng" style="width: 33%;">
                            <div>Gong 4 (x30)</div>
                            <div>
                                <asp:TextBox ID="txtGong4" Width="200px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng" style="width: 33%;">
                            <div>Gong 5 (x30)</div>
                            <div>
                                <asp:TextBox ID="txtGong5" Width="200px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div class="divFormMng" style="width: 33%;">
                            <div>Total</div>
                            <div>
                                <asp:TextBox ID="txtGongTotal" Width="200px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng" style="width: 33%;">
                            <div>Shots Fired <span style="font-size: xx-small;">(SF)</span></div>
                            <div>
                                <asp:TextBox ID="txtGongSF" Width="200px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng" style="width: 33%;">
                            <div>Max Scoring <span style="font-size: xx-small;">(SF)x30</span></div>
                            <div>
                                <asp:TextBox ID="txtGongMS" Width="200px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng" style="width: 33%;">
                            <div>% Success<span style="font-size: xx-small;">Total/Max Scoring</span></div>
                            <div>
                                <asp:TextBox ID="txtGongSuccess" Width="200px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div style="align-content: center;">
                            <asp:Button ID="btnSave6" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                    </asp:Panel>
                </div>

                <div>&nbsp;</div>
                <div class="headers" style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-family: Calibri;" onclick="showPanel('<%=btnGongTotals.ClientID %>')">&nbsp;Gong Totals</div>
                <div style="font-size: 30px;">
                    <asp:Panel ID="pnl7" Visible="false" runat="server">
                        <div>&nbsp;</div>
                        <div class="divFormMng" style="width: 15%;">
                            <div><b>Total</b></div>
                            <div>&nbsp;</div>
                            <div>Animal Targets</div>
                            <div>&nbsp;</div>
                            <div>Gong Scoring</div>
                            <div>&nbsp;</div>
                            <div>Event Total</div>
                        </div>
                        <div class="divFormMng" style="width: 15%;">
                            <div>Total</div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtAnimalTargetTotal" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtGongScoringTotal" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtEventTotalTotal" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng" style="width: 15%;">
                            <div>Shots Fired</div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtAnimalTargetSF" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtGongScoringSF" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtEventTotalSF" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng" style="width: 15%;">
                            <div>Max Scoring</div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtAnimalTargetMS" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtGongScoringMS" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtEventTotalMS" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div class="divFormMng" style="width: 15%;">
                            <div>% Success</div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtAnimalTargetSuccess" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtGongScoringSuccess" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:TextBox ID="txtEventTotalSuccess" Width="80px" Font-Size="60px" CssClass="textbox" runat="server"></asp:TextBox>
                            </div>
                        </div>
                        <div>&nbsp;</div>
                        <div style="align-content: center;">
                            <asp:Button ID="btnSave7" runat="server" Text="Save" CssClass="button" Width="250px" /></div>
                    </asp:Panel>
                </div>

                <div>&nbsp;</div>
                <div class="headers" style="border: thin solid #333333; background-color: #E2E2E2; color: #333333; font-family: Calibri;" onclick="showPanel('<%=btnUpload.ClientID %>')">&nbsp;Upload Scoresheet</div>
                <div>
                    <asp:Panel ID="pnl8" Visible="false" runat="server">
                        <div>&nbsp;</div>
                        <div>Upload Scoresheet:&nbsp;<asp:FileUpload ID="FileUpload1" Width="300px" runat="server" Font-Size="60px" /></div>
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

    <script type="text/javascript">
        function showPanel(selecbutton) {
            document.getElementById(selecbutton).click();
        }
    </script>

</asp:Content>
