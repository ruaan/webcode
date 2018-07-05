<%@ Page Language="VB" AutoEventWireup="false" CodeFile="eventDetails.aspx.vb" Inherits="BookingSystem_eventDetails" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <h3>Events for</h3>
            <table>
                <tr valign="top">
                    <td><b>Event Title:</b></td>
                    <td><asp:Label id="txtTitle" runat="server" /></td>
                </tr>

                <tr valign="top">
                    <td><b>Event Description:</b></td>
                    <td><asp:Label id="txtDescription" runat="server" /></td>
                </tr>

                <tr valign="top">
                    <td><b>Event Date:</b></td>
                    <td><asp:Label id="txtDate" runat="server" /></td>
                </tr>

                <tr valign="top">
                    <td><b>Category:</b></td>
                    <td>
                        <asp:Image id="imgCategory" runat="server" ImageAlign="absmiddle" />                        
                        <asp:Label id="txtCategory" runat="server" />
                    </td>
                </tr>

            </table>
    </form>
</body>
</html>
