<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Association_Event_View_App.aspx.vb" Inherits="Associations_Association_Event_View_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../StyleSheets/StyleSheet2.css" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div id="mainPageWrapper">
            <div class="div_MainBlock" style="text-align: left; align-content: center">
                <div>&nbsp;</div>
                <div id="divDetails" style="width: 100%" class="div_Details">
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
    </form>
</body>
</html>
