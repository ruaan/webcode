<%@ Page Language="VB" AutoEventWireup="false" CodeFile="AddReview.aspx.vb" Inherits="Farms_AddReview" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: #e2e2e2;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <div style="font-family: Calibri; color: #333333">
                <div style="font-size: large">
                    Rating for
                <asp:Label ID="lblFarmName" runat="server"></asp:Label>
                    &nbsp;<asp:Label ID="lblFarmId" runat="server"></asp:Label>
                    <asp:HiddenField ID="HiddenFieldmem" runat="server" />
                </div>
                <div>&nbsp;</div>
                <div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>

                </div>
                <div>&nbsp;</div>
                <div>
                    <div>Review</div>
                    <div>
                        <asp:TextBox ID="txtReview" runat="server" Height="84px" TextMode="MultiLine" Width="98%" Font-Size="Larger" BackColor="#e2e2e2" BorderColor="Gray" BorderStyle="Solid"></asp:TextBox>
                    </div>
                    <div>&nbsp;</div>
                    <asp:Button ID="Button1" runat="server" Text="Submit" BackColor="#86B24F" BorderStyle="None" Font-Size="Large" ForeColor="White" />
                    <div>

                        <asp:Button ID="btnRate" runat="server" BackColor="#E2E2E2" BorderStyle="None" />
                        <asp:HiddenField ID="HiddenFieldrateId" runat="server" />
                        <asp:HiddenField ID="HiddenFieldRateScore" runat="server" />

                    </div>
                </div>
            </div>
        </div>
    </form>
    <script type="text/javascript">
        function SaveRating(Type, Score, divId) {

            var hiddenType = document.getElementById('<%= HiddenFieldrateId.ClientID %>');
             hiddenType.value = Type;

             var hiddenScore = document.getElementById('<%= HiddenFieldRateScore.ClientID %>');
            hiddenScore.value = Score;

            var Colordiv = document.getElementById(divId);
            Colordiv.style.backgroundColor = '#0EDE57';

            document.getElementById('<%=btnRate.ClientID%>').click();

            var Colordiv = document.getElementById(divId);
            Colordiv.style.backgroundColor = '#0EDE57';
        }
    </script>
</body>
</html>
