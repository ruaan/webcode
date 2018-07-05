<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Association_Event_Control.aspx.vb" Inherits="Associations_Association_Event_Control" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    .auto-style4 {
            width: 851px;
            cursor: pointer;
        }
        .auto-style5 {
            width: 444px;
        }
        .auto-style6 {
            width: 80px;
        }
        .auto-style7 {
            width: 222px;
        }
        .auto-style8 {
            width: 106px;
        }
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="mainPageWrapper">
        <div class="div_MainBlock" style="text-align: left; align-content: center">
            <div>&nbsp;</div>
            <div id="divDetails" class="div_Details">
                <div class="h1">
                    Events for
                    <asp:Label ID="lblAssociationName" runat="server" Text=""></asp:Label>
                </div>
                <div>&nbsp;</div>
                <div>
                    <asp:Button ID="btnNewEvent" runat="server" Text="New Event" CssClass="button" />
                    <asp:Label ID="lblMsg" runat="server"></asp:Label>
                </div>
                <div>&nbsp;</div>
                <div>
                    <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="Association_Id"></asp:DropDownList>

                    <div>&nbsp;</div>
                    <div>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                    </div>
                </div>

                <asp:Panel ID="Panel1" runat="server" Width="417px" BorderColor="White">
                    <asp:Panel ID="Panel2" runat="server" BackColor="#86B24F" Font-Bold="True">
                        Edit Function
                    </asp:Panel>
                    <div style="background-color: #F8F8F8; border: 1px solid #333333;" class="auto-style4">



                        <div style='padding: 10px; display: inline-block'>
                            <div>
                                Event Name:
                                <asp:TextBox ID="TextBox1" runat="server" CssClass="textbox" Width="263px"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:DropDownList ID="DropDownList2" runat="server">
                                    <asp:ListItem>Meeting</asp:ListItem>
                                    <asp:ListItem>Shooting Range</asp:ListItem>
                                </asp:DropDownList>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                Date:
                                <asp:TextBox ID="TextBox2" runat="server" CssClass="textbox" Width="100px"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                Time:
                                <asp:TextBox ID="TextBox3" runat="server" CssClass="textbox" Width="99px"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                Description:
                                <asp:TextBox ID="TextBox4" runat="server" CssClass="textbox" Width="263px" Height="50px" MaxLength="500" TextMode="MultiLine"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                Venue:
                                <asp:TextBox ID="TextBox5" runat="server" CssClass="textbox" Width="280px"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>Address</div>
                            <div>
                                <asp:TextBox ID="TextBox6" runat="server" CssClass="textbox" Width="330px"></asp:TextBox>
                            </div>
                            <div>
                                <asp:TextBox ID="TextBox7" runat="server" CssClass="textbox" Width="330px"></asp:TextBox>
                            </div>
                            <div>
                                <asp:TextBox ID="TextBox8" runat="server" CssClass="textbox" Width="330px"></asp:TextBox>
                            </div>
                            <div>&nbsp;</div>
                            <div>
                                <asp:CheckBox ID="CheckBox1" runat="server" TextAlign="Left" Text="Allow Pre-Booking" />
                            </div>
                            <div>
                                <asp:CheckBox ID="CheckBox2" runat="server" TextAlign="Left" Text="Create QR-Code" />
                            </div>
                            <div>
                                <asp:Label ID="lblEditId" runat="server" Text="" ForeColor="White"></asp:Label>
                            </div>
                            <div id="divBtn" runat="server" style="padding: 5px; border: thin solid #333333; display: inline-block" class="auto-style7">
                                &nbsp;<asp:Button ID="Button1" runat="server" Text="Save" BackColor="#333333" BorderStyle="None" ForeColor="#AAABAB" Height="27px" Width="61px" />
                                &nbsp;&nbsp;
                    <asp:Button ID="Button2" runat="server" Text="Cancel" BackColor="#333333" BorderStyle="None" ForeColor="#AAABAB" Height="27px" Width="61px" />
                            </div>

                        </div>

                    </div>

                </asp:Panel>


            </div>
        </div>
    </div>
    <asp:Button ID="btnBook" runat="server" BackColor="White" BorderStyle="None" />
    <cc1:ModalPopupExtender ID="btnBook_ModalPopupExtender" runat="server" BehaviorID="btnBook_ModalPopupExtender" Drag="True" DropShadow="True" DynamicServicePath="" PopupControlID="Panel1" PopupDragHandleControlID="Panel2" TargetControlID="btnRemove">
    </cc1:ModalPopupExtender>
    <asp:Button ID="btnRemove" runat="server" BackColor="White" BorderStyle="None" />
    <asp:HiddenField ID="HiddenFieldEventId" runat="server" />
    <asp:HiddenField ID="HiddenFieldBookStatus" runat="server" />

    <script type="text/javascript">

        function EditEvent(eventId, BookStatus) {
            var thisEventId = document.getElementById('<%=HiddenFieldEventId.ClientID%>');
            var thisBookStatus = document.getElementById('<%=HiddenFieldBookStatus.ClientID%>');
            thisEventId.value = eventId;
            thisBookStatus.value = BookStatus;
            document.getElementById('<%=btnBook.ClientID%>').click();
        }

        function RemoveBook(eventId, BookStatus) {
            var thisEventId = document.getElementById('<%=HiddenFieldEventId.ClientID%>');
            var thisBookStatus = document.getElementById('<%=HiddenFieldBookStatus.ClientID%>');
            thisEventId.value = eventId;
            thisBookStatus.value = BookStatus;
            document.getElementById('<%=btnRemove.ClientID%>').click();
        }
    </script>
</asp:Content>

