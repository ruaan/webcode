<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Association_Event_View.aspx.vb" Inherits="Associations_Association_Event_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="mainPageWrapper">
        <div class="div_MainBlock" style="text-align: left; align-content: center">
            <div>&nbsp;</div>
            <div id="divDetails" class="div_Details">
                <div class="h1">Events for
                    <asp:Label ID="lblAssociationName" runat="server" Text=""></asp:Label></div>
                <div>&nbsp;</div>
                <div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
    <asp:Button ID="btnBook" runat="server" BackColor="White" BorderStyle="None" />
    <asp:Button ID="btnRemove" runat="server" BackColor="White" BorderColor="White" BorderStyle="None" />
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

