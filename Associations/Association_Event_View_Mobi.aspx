<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageMobi.master" AutoEventWireup="false" CodeFile="Association_Event_View_Mobi.aspx.vb" Inherits="Associations_Association_Event_View_Mobi" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        body {
            background-color: #424531;
            font-family: Calibri;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="ContentPlaceHolder2" runat="Server">
    <div id="mainPageWrapper">
        <div class="div_MainBlock" style="text-align: left; align-content: center">
            <div>&nbsp;</div>
            <div id="divDetails" style="width: 100%" class="div_Details">
                <div class="h1" style="font-size: 48px; background-color: #FFFFFF;">Events for
                    <asp:Label ID="lblAssociationName" runat="server" Text=""></asp:Label></div>
                <div>&nbsp;</div>
                <div style="font-size: 48px; background-color: #FFFFFF;">
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btnBook" runat="server" BackColor="#424531" BorderStyle="None" />
    <asp:Button ID="btnRemove" runat="server" BackColor="#424531" BorderColor="White" BorderStyle="None" />
    <asp:HiddenField ID="HiddenFieldEventId" runat="server" />
    <asp:HiddenField ID="HiddenFieldBookStatus" runat="server" />

    <script type="text/javascript">

        function Book(eventId, BookStatus) {
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

