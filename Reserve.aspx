<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Reserve.aspx.vb" Inherits="Reserve" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">

    <style>
        .div_Reserve_Block {
            border: 1px solid #333333;
            background-color: #F8F8F8;
            padding: 15px;
            font-family: Calibri;
            color: #333333;
            cursor: pointer;
        }

        .div_Picture_Style {
            width: 141px;
            height: 141px;
            display: inline-block;
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

        .icon_style {
            padding: 5px;
            display: inline-block;
        }

        .auto-style2 {
            width: 483px;
            vertical-align: top;
            padding: 0px 10px 10px 10px;
            display: inline-block;
        }

        .auto-style3 {
            width: 115px;
        }

        .auto-style4 {
            border-left: thin solid #FFFFFF;
            width: 230px;
            vertical-align: top;
            padding-top: 0px;
            padding-left: 5px;
            padding-right: 5px;
            display: inline-block;
            border-right-color: #FFFFFF;
            border-right-width: thin;
            border-top-color: #FFFFFF;
            border-top-width: thin;
            border-bottom-color: #FFFFFF;
            border-bottom-width: thin;
        }

        .auto-style5 {
            width: 101px;
        }

        .auto-style6 {
            width: 762px;
        }

        .div_Totals {
            width: 78px;
            display: inline-block;
            padding-right: 10px;
            padding-bottom: 5px;
            padding-left: 5px;
        }

        .div_YourAccount {
            width: 119px;
            display: inline-block;
            background-color: #C0C0C0;
            padding-bottom: 5px;
            padding-left: 5px;
            padding-right: 5px;
            text-align: right;
        }

        .div_AccountHeading {
            background-color: #666666;
            color: #F0F0F0;
            padding-bottom: 5px;
            padding-left: 5px;
            font-weight: bold;
        }


        .div_AccountSubHeading {
            background-color: #808080;
            color: #F0F0F0;
            padding-bottom: 5px;
            padding-left: 5px;
            font-weight: bold;
        }

        .flight-textbox-style {
            width: 300px;
            height: 30px;
            border-style: none;
            background-color: #5B8EC5;
            color: #FFFFFF;
            font-size: large;
        }

        .Flight-buttons {
            width: 83px;
            height: 90px;
        }

        .Flight-Space {
            width: 15px;
        }

        .Flight-dropdown {
            width: 134px;
            height: 90px;
        }

        .Flight-SearchButton {
            width: 332px;
            height: 53px;
        }

        .Flight-MainBlock {
            width: 364px;
        }

        .auto-style7 {
            width: 194px;
            height: 53px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="mainPageWrapper" style="align-content: center;">
        <div class="div_MainBlock">
            <div style="text-align: left; width: 1050px; display: inline-block;">
                <div>&nbsp;</div>
                <div class="h1">Your Hunting Trip</div>
                <div>
                    <asp:Label ID="Label1" runat="server" Text="Label" ForeColor="White"></asp:Label>
                </div>
                <div style="vertical-align: top">
                    <div style="display: inline-block; vertical-align: top" class="auto-style6">
                        <div id="famrid2" class="div_Reserve_Block">
                            <div class="div_Picture_Style">

                                <asp:Image ID="imgFarm" runat="server" ImageUrl="Farms/Images/FarmProfiles/1Main.jpg" class="image_Style" />
                            </div>
                            <div class="auto-style2">

                                <div class="div_text_block">

                                    <div style="padding-bottom: 10px">
                                        <div style="display: inline-block; padding-right: 40px;">
                                            <div><strong>Game Farm:</strong></div>
                                            <div>
                                                <asp:Label ID="lblGameFarm" runat="server" Text=""></asp:Label>
                                                <asp:HiddenField ID="HiddenFieldFarmId" runat="server" />
                                                <asp:HiddenField ID="HiddenFieldAccom" runat="server" />
                                                <asp:HiddenField ID="HiddenFieldAdditional" runat="server" />
                                            </div>
                                        </div>
                                    </div>
                                    <div style="padding-bottom: 10px">
                                        <div style="display: inline-block; padding-right: 40px;">
                                            <div><strong>Dates:</strong></div>
                                            <div>
                                                <asp:Label ID="lblDates" runat="server" Text=""></asp:Label>

                                            </div>
                                        </div>
                                        <div>
                                            <div><strong>Total Days:</strong></div>
                                            <div>
                                                <asp:Label ID="lblDaysCount" runat="server" Text=""></asp:Label>
                                                Days
                                            </div>
                                        </div>
                                    </div>

                                    <div>
                                        <div>
                                            Total in Party:<strong>
                                                <asp:Label ID="lblTotalParty" runat="server" Text="5"></asp:Label></strong>
                                        </div>
                                        <div style="display: inline-block; padding-right: 40px;">
                                            <div><strong>Hunters:</strong></div>
                                            <div style="text-align: center">
                                                <asp:Label ID="lblHunterCount" runat="server" Text="4"></asp:Label>
                                            </div>
                                        </div>
                                        <div style="display: inline-block; padding-left: 20px;">
                                            <div><strong>Guests:</strong></div>
                                            <div style="text-align: center">
                                                <asp:Label ID="lblGuestCount" runat="server" Text="1"></asp:Label>
                                            </div>
                                        </div>
                                    </div>
                                </div>



                            </div>

                        </div>
                        <div>&nbsp;</div>
                        <div style="padding-left: 10px">
                            <div style="vertical-align: top">
                                Trip Name:
                            <asp:TextBox ID="txtUniqueName" runat="server" Width="400px" CssClass="textbox"></asp:TextBox>
                                &nbsp;<asp:Button ID="btnSaveName" runat="server" BackColor="White" BorderStyle="None" ForeColor="#86B24F" Text="Save" Style="cursor: pointer" />
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                Adding the names of the members in the party will create a chat group between Eco Hunter Members.</br>You can split the bill between the members as well.
                            <div style="background-color: #86B24F">
                                Members of the party
                            </div>
                                <div>
                                    <div>&nbsp;</div>
                                    <asp:Button ID="Button6" runat="server" Text="Add Member" CssClass="lineButton" />
                                    <asp:Button ID="btnAddMember" runat="server" BackColor="White" BorderStyle="None" ForeColor="#86B24F" Style="cursor: pointer" />
                                    <cc1:ModalPopupExtender ID="btnAddMember_ModalPopupExtender" runat="server" BehaviorID="btnAddMember_ModalPopupExtender" Drag="True" DropShadow="True" PopupControlID="pnlAddMember" PopupDragHandleControlID="pnladdMemberHandle" TargetControlID="btnAddMember">
                                    </cc1:ModalPopupExtender>
                                    <div>&nbsp;</div>
                                    <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False">
                                        <Columns>
                                            <asp:BoundField DataField="id" />
                                            <asp:BoundField DataField="Name" HeaderText="Name" />
                                            <asp:BoundField DataField="huntertype" HeaderText="Hunter Type" />
                                            <asp:BoundField HeaderText="For your Account" DataField="WhoPays">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="HunterGuest" />
                                        </Columns>
                                    </asp:GridView>
                                    <asp:Label ID="lblMemberMsg" runat="server"></asp:Label>
                                    <asp:HiddenField ID="HiddenFieldOwnAccountQty" runat="server" Value="0" />
                                </div>
                            </div>
                            <div>&nbsp;</div>
                            <div>

                                <div style="background-color: #86B24F">
                                    Animals
                                </div>
                                <div>
                                    <div>&nbsp;</div>
                                    <asp:Button ID="Button1" runat="server" BackColor="White" BorderStyle="None" ForeColor="#86B24F" Text="Add Species" Style="cursor: pointer" />
                                    <cc1:ModalPopupExtender ID="Button1_ModalPopupExtender" runat="server" BehaviorID="Button1_ModalPopupExtender" Drag="True" DropShadow="True" PopupControlID="pnlAddSpecies" PopupDragHandleControlID="pnlSpeciesHandle" TargetControlID="Button1">
                                    </cc1:ModalPopupExtender>
                                    <div>&nbsp;</div>

                                    <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" Width="80%" ShowFooter="True">

                                        <Columns>
                                            <asp:BoundField DataField="id">
                                                <ItemStyle ForeColor="White" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Name" HeaderText="Animal" />
                                            <asp:BoundField DataField="Sex" HeaderText="Sex" />
                                            <asp:BoundField HeaderText="Qty" DataField="Qty">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Price Each" DataField="Price" DataFormatString="{0:###,##0.00}" HtmlEncode="False">
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Total" DataField="Total" DataFormatString="{0:###,##0.00}" HtmlEncode="False">
                                                <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                        </Columns>
                                    </asp:GridView>

                                </div>
                                <div>&nbsp;</div>
                            </div>


                            <div>&nbsp;</div>
                            <div>

                                <div style="background-color: #86B24F">
                                    Travel
                                </div>
                                <div>
                                    <div>&nbsp;</div>
                                    <div>

                                        <input id="btnTravel" type="button" value="Do you want to book a flight or Rent a Car?" class="button" onclick="ToggleDiv('divFlights')" style="cursor: pointer" />

                                    </div>

                                    <div>&nbsp;</div>




                                    <div id="divFlights" style="display: none">
                                        <div style="padding: 10px; background-color: #454346" class="Flight-MainBlock">
                                            <div style="text-align: center; font-size: x-large; padding-top: 15px; padding-bottom: 15px; color: #CCCCCC;">Book Your Flights</div>
                                            <div>&nbsp</div>
                                            <div>
                                                <div style="display: inline-block">
                                                    <asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Icons/btnflights.jpg" />

                                                </div>
                                                <div style="display: inline-block">
                                                    &nbsp;
                                                </div>
                                                <div style="display: inline-block">
                                                    <asp:ImageButton ID="ImageButton4" runat="server" ImageUrl="~/Images/Icons/btnCarhire.jpg" />

                                                </div>
                                                <div>
                                                    &nbsp;
                                                </div>
                                                <div style="padding-bottom: 5px">
                                                    <input id="cityFrom" type="text" class="flight-textbox-style" />
                                                    <div id="log" class="flight-textbox-style"></div>
                                                </div>
                                                <div style="padding-bottom: 5px">
                                                    <input id="cityTo" type="text" class="flight-textbox-style" />
                                                    <div id="log2" class="flight-textbox-style"></div>
                                                </div>
                                                <div>&nbsp;</div>
                                                <div>
                                                    <div style="display: inline-block; background-color: #EBECEE; text-align: center" class="Flight-buttons">
                                                        <div>Depart</div>
                                                        <div>December</div>
                                                        <div style="color: #37C4D6; font-weight: bold; font-size: x-large">
                                                            <asp:Label ID="Label5" runat="server" Text="15"></asp:Label>
                                                        </div>
                                                        <div style="padding-bottom: 5px">Friday</div>
                                                    </div>
                                                    <div style="display: inline-block" class="Flight-Space">
                                                        &nbsp;
                                                    </div>
                                                    <div style="display: inline-block; background-color: #EBECEE; text-align: center" class="Flight-buttons">
                                                        <div>Return</div>
                                                        <div>December</div>
                                                        <div style="color: #37C4D6; font-weight: bold; font-size: x-large">
                                                            <asp:Label ID="Label6" runat="server" Text="20"></asp:Label>
                                                        </div>
                                                        <div style="padding-bottom: 5px">Monday</div>
                                                    </div>
                                                    <div style="display: inline-block" class="Flight-Space">
                                                        &nbsp;
                                                    </div>
                                                    <div style="display: inline-block; background-color: #EBECEE; text-align: center; vertical-align: top;" class="Flight-dropdown">
                                                        <div style="display: inline-block;">
                                                            <img alt="" src="Images/Icons/flights_11.jpg" />
                                                        </div>
                                                        <div style="display: inline-block;">
                                                            <asp:DropDownList ID="DropDownList5" runat="server" BackColor="White" Font-Size="X-Large">
                                                                <asp:ListItem>1</asp:ListItem>
                                                                <asp:ListItem>2</asp:ListItem>
                                                                <asp:ListItem>3</asp:ListItem>
                                                                <asp:ListItem>4</asp:ListItem>
                                                                <asp:ListItem>5</asp:ListItem>
                                                                <asp:ListItem>6</asp:ListItem>
                                                                <asp:ListItem>7</asp:ListItem>
                                                                <asp:ListItem>8</asp:ListItem>
                                                            </asp:DropDownList>
                                                        </div>
                                                        <div style="padding: 12px 0px 10px 0px">
                                                            <asp:DropDownList ID="DropDownList6" runat="server" BackColor="White" Font-Names="Calibri">
                                                                <asp:ListItem>Economy</asp:ListItem>
                                                                <asp:ListItem>Premium Economy</asp:ListItem>
                                                                <asp:ListItem>Business</asp:ListItem>
                                                                <asp:ListItem>First</asp:ListItem>
                                                            </asp:DropDownList>

                                                        </div>
                                                    </div>

                                                </div>
                                                <div>&nbsp;</div>
                                                <div>
                                                    <input id="Button12" type="button" value="Search for Available Flights" style="background-color: #454346; color: #CCCCCC; border: 1px solid #CCCCCC; font-size: large;" class="Flight-SearchButton" />
                                                </div>
                                            </div>
                                            <div>&nbsp;</div>
                                        </div>
                                    </div>


                                </div>
                                <div>&nbsp;</div>
                            </div>


                            <div>&nbsp;</div>
                            <div>


                                <div>



                                    <div>&nbsp;</div>

                                </div>
                                <div>&nbsp;</div>
                            </div>

                        </div>

                    </div>

                    <div style="display: inline-block; vertical-align: top">
                        <div class="auto-style4" style="background-color: #E5E3E5; display: none;">
                            <div>
                                <div style="display: inline-block;">
                                    <div><strong>Total</strong></div>
                                    <div>R14 368.00</div>
                                </div>
                                <div>&nbsp;</div>
                                <div style="display: inline-block;">
                                    <div><strong>Deposit</strong></div>
                                    <div>R3 627.00</div>
                                    <div style="font-size: small; color: #666666;">Pay deposit before 28/12/2017.</div>
                                </div>
                                <div>&nbsp;</div>
                                <div style="display: inline-block;">
                                    <div><strong>Final payment</strong></div>
                                    <div>R10 741.00</div>
                                    <div style="font-size: small; color: #666666;">Final payment can be done onsite.</div>
                                </div>
                            </div>
                            <div style="border-bottom-style: solid; border-width: thin; border-color: #333333">&nbsp;</div>
                            <div>&nbsp;</div>
                            <div style="display: inline-block" class="auto-style3">
                                Accommodation:
                            </div>
                            <div style="display: inline-block; text-align: right" class="auto-style5">
                                R14 368.00
                            </div>

                            <div style="font-size: small; color: #666666;">
                                Daily rate x 4 days for 5 guests
                            </div>
                            <div>&nbsp;</div>
                            <div style="display: inline-block" class="auto-style3">
                                Additional:
                            </div>
                            <div style="display: inline-block; text-align: right" class="auto-style5">
                                R14 368.00
                            </div>

                            <div style="font-size: small; color: #666666;">
                                Daily rate x 4 days for 5 guests
                            </div>
                            <div>&nbsp;</div>

                        </div>
                        <div class="auto-style4" style="background-color: #E5E3E5">

                            <asp:PlaceHolder ID="PlaceHolderBilling" runat="server"></asp:PlaceHolder>
                            <asp:HiddenField ID="HiddenFieldDepositPercentage" runat="server" />
                            <asp:HiddenField ID="HiddenFieldDepositPeriod" runat="server" />

                            <asp:HiddenField ID="HiddenFieldTotalDue" runat="server" />
                            <asp:HiddenField ID="HiddenFieldDepositValue" runat="server" />
                            <asp:HiddenField ID="HiddenFieldDepositDue" runat="server" />
                            <asp:HiddenField ID="HiddenFieldFinalPayment" runat="server" />
                            <asp:HiddenField ID="HiddenFieldAccomValue" runat="server" />
                            <asp:HiddenField ID="HiddenFieldAdditionalValue" runat="server" />
                            <asp:HiddenField ID="HiddenFieldSpeciesValue" runat="server" />
                            <asp:HiddenField ID="HiddenFieldExtraValue" runat="server" />
                            <asp:HiddenField ID="HiddenFieldTotalDueYou" runat="server" />
                            <asp:HiddenField ID="HiddenFieldDepositValueYou" runat="server" />
                            <asp:HiddenField ID="HiddenFieldFinalPaymentYou" runat="server" />
                            <asp:HiddenField ID="HiddenFieldAccomValueYou" runat="server" />
                            <asp:HiddenField ID="HiddenFieldAdditionalValueYou" runat="server" />



                            <div style="padding: 10px; background-color: #E2E2E2;">
                                <div style="font-weight: bold; text-align: center;">
                                    <asp:Button ID="btnReserve" runat="server" Text="Reserve" Style="background-color: #454346; color: #CCCCCC; border: 1px solid #CCCCCC; font-size: large;" class="auto-style7" />
                                </div>
                            </div>
                        </div>

                    </div>


                </div>

            </div>


        </div>
    </div>

    <asp:Panel ID="pnlAddMember" runat="server" BackColor="White" BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" Width="575px">
        <asp:Panel ID="pnladdMemberHandle" runat="server" BackColor="#86B24F">Add member to your Party.</asp:Panel>
        <div style="padding-left: 5px">
            <div>&nbsp;</div>

            <div>
                Is this person an Eco-Hunter Member? 
                <asp:Button ID="btnMemberYes" runat="server" Text="Yes" CssClass="button" />
                &nbsp;<asp:Button ID="btnMemberNo" runat="server" Text="No" CssClass="button" />&nbsp;
                <asp:Button ID="btnMainCancel" runat="server" CssClass="button" Text="Close" />
            </div>
            <div>&nbsp;</div>
            <div>
                <asp:Panel ID="pnlEcoMemberYes" runat="server" Visible="False" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" Width="556px">
                    <div>&nbsp;</div>
                    <div style="padding-left: 5px">
                        Enter Mobile number/ Id Number or Email address:
                            <asp:TextBox ID="txtMemberSearch" runat="server"></asp:TextBox>
                        <asp:Button ID="btnMemberSearch" runat="server" BackColor="White" BorderStyle="None" ForeColor="#86B24F" Style="cursor: pointer" Text="Search" />
                    </div>
                    <div>&nbsp;</div>
                    <div id="divEcoMember">
                        <asp:Panel ID="pnlMemberDetails" runat="server" Visible="False">

                            <div>&nbsp;</div>
                            <div id="divMemberDetails" style="padding-left: 5px">
                                <asp:Panel ID="pnlMember2Add" runat="server">
                                    <div style="display: inline-block">
                                        <img alt="" src="" />
                                    </div>
                                    <div style="display: inline-block; padding-left: 10px;">
                                        <asp:Label ID="lblNameToAdd" runat="server" Text="" Font-Bold="True"></asp:Label>&nbsp;
                             <asp:Label ID="lblCellToAdd" runat="server" Text=""></asp:Label>&nbsp;
                             <asp:Label ID="lblEmailtoAdd" runat="server" Text=""></asp:Label>&nbsp;<asp:Label ID="lblId2Add" runat="server"></asp:Label>
                                    </div>
                                    <div>
                                        <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                            <asp:ListItem Selected="True">Hunter</asp:ListItem>
                                            <asp:ListItem>Guest</asp:ListItem>
                                        </asp:RadioButtonList>
                                    </div>
                                    <div>
                                        <asp:CheckBox ID="CheckBox2" runat="server" TextAlign="Left" Text="Bill for his/her Own Account" Checked="True" />
                                    </div>
                                </asp:Panel>
                            </div>
                            <div>&nbsp;</div>
                            <div style="text-align: center">
                                <asp:Button ID="Button4" runat="server" Text="Add" CssClass="button" />&nbsp;
                        <asp:Button ID="Button5" runat="server" Text="Cancel" CssClass="button" />
                            </div>
                            <div>&nbsp;</div>
                        </asp:Panel>

                        <asp:Panel ID="pnlMembernotfound" runat="server" Visible="False">
                            <div>&nbsp;</div>
                            <div style="text-align: center">Member not found.</div>
                            <div>&nbsp;</div>
                        </asp:Panel>


                    </div>

                </asp:Panel>
                <asp:Panel ID="pnlEcoMemberNo" runat="server" Visible="False" BorderColor="#666666" BorderStyle="Solid" BorderWidth="1px" Width="556px">
                    <div id="divNonEcoMember">
                        <div>&nbsp;</div>
                        <div>Non Eco-Hunter Members bill will be for your account.</div>
                        <div>&nbsp;</div>
                        <div>
                            Name:
                            <asp:TextBox ID="txtNonMemberName" runat="server"></asp:TextBox>
                        </div>
                        <div>
                            Hunter Type:
                            <asp:DropDownList ID="DropDownList1" runat="server">
                                <asp:ListItem>Occasional Hunter</asp:ListItem>
                                <asp:ListItem>Dedicated Hunter</asp:ListItem>
                                <asp:ListItem>Proffesional Hunter</asp:ListItem>
                                <asp:ListItem>Guest</asp:ListItem>
                            </asp:DropDownList>
                        </div>
                    </div>
                    <div>&nbsp;</div>
                    <div style="text-align: center">
                        <asp:Button ID="Button2" runat="server" Text="Add" CssClass="button" />&nbsp;
                        <asp:Button ID="Button3" runat="server" Text="Cancel" CssClass="button" />
                    </div>
                    <div>&nbsp;</div>
                </asp:Panel>
            </div>
            <div>&nbsp;</div>
            <div style="text-align: center">
            </div>
            <div>&nbsp;</div>

        </div>



    </asp:Panel>


    <asp:Panel ID="pnlAddSpecies" runat="server" Width="664px" BackColor="White">
        <asp:Panel ID="pnlSpeciesHandle" runat="server" BackColor="#86B24F">Add Species.</asp:Panel>
        <div style="padding-left: 10px">
            <div>
                Only add species that will be for your account.<br>
                    <br></br>
                    Eco-Hunter members in your party will receive an Email inviting them to add species to their account.</br>
            </div>
            <div>&nbsp</div>
            <div style="text-align: center">
                <asp:Button ID="btnAnimalSubmit" runat="server" Text="Submit" CssClass="button" />
                &nbsp;
             <asp:Button ID="btnAnimalClose" runat="server" Text="Close" CssClass="button" />

            </div>
            <div>&nbsp</div>
            <div>
                <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False">
                    <Columns>
                        <asp:BoundField DataField="id">
                            <ItemStyle ForeColor="White" />
                        </asp:BoundField>
                        <asp:BoundField DataField="Description" HeaderText="Group" />
                        <asp:BoundField DataField="Name" HeaderText="Game" />
                        <asp:BoundField DataField="Male_Price" HeaderText="Male Price" />
                        <asp:BoundField DataField="Female_Price" HeaderText="Female Price" />
                        <asp:BoundField DataField="Trophy_Price" HeaderText="Trophy Price" />
                        <asp:TemplateField HeaderText="Male">
                            <ItemTemplate>
                                <asp:DropDownList ID="cmbAnimalMale" runat="server">

                                    <asp:ListItem>0</asp:ListItem>
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

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Female">
                            <ItemTemplate>
                                <asp:DropDownList ID="cmbAnimalFeMale" runat="server">

                                    <asp:ListItem>0</asp:ListItem>
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

                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Trophy">
                            <ItemTemplate>
                                <asp:DropDownList ID="cmbAnimalTrophy" runat="server">

                                    <asp:ListItem>0</asp:ListItem>
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

                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
            <div>&nbsp;</div>
        </div>
    </asp:Panel>



    <script type="text/javascript">

        function ToggleDetails(divShow) {
            var divEcoMember = document.getElementById('divEcoMember');
            var divnonEcoMember = document.getElementById('divNonEcoMember');


            if (divShow == 'member') {
                divEcoMember.style.display = 'block';
                divnonEcoMember.style.display = 'none';
            } else {
                divEcoMember.style.display = 'none';
                divnonEcoMember.style.display = 'block';
            }

        }


        function ToggleDiv(divShow) {
            var divToShow = document.getElementById(divShow);

            if (divToShow.style.display == 'none') {
                divToShow.style.display = 'block';
            } else {
                divToShow.style.display = 'none';
            }
        }


    </script>
</asp:Content>

