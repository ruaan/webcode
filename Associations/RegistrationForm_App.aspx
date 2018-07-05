<%@ Page Language="VB" AutoEventWireup="false" CodeFile="RegistrationForm_App.aspx.vb" Inherits="Associations_RegistrationForm_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
        .divFormMng {
            display: inline-block;
            vertical-align: top;
        }
        .divMainContainer {
            display: inline-block;
            /*width: 30%;*/
            vertical-align: top;
        }
        .divPagewide {
            vertical-align: top;
        }
        .Column1{
            width: 200px;
            display: inline-block;
        }
        .button {
    -moz-border-radius: 3px;
    border-radius: 3px;
    border: 1px solid #8d9296;
    color: #a3a3a3;
    padding: 4px;
    background-color: #7DB15C;
    color: white;
}
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <%--<Triggers>
            <asp:PostBackTrigger ControlID="btnSave" />
        </Triggers>--%>
        <ContentTemplate>
            <table width="100%" align="center" celpadding="0" cellspacing="0">
                <tr>
                    <td height="45">Membership Registration:</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td height="27" align="left">&nbsp;&nbsp;&nbsp;<asp:Label ID="lblHeader" Font-Size="Medium" runat="server" Text=""></asp:Label>&nbsp;</td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="2"><i><b>Principal Member:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Surname:</td>
                                <td width="35%"><asp:TextBox ID="txtSurname" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">First Name:</td>
                                <td>
                                    <asp:TextBox ID="txtName" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">ID Number:</td>
                                <td>
                                    <asp:TextBox ID="txtIdNo" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">Cellphone:</td>
                                <td>
                                    <asp:TextBox ID="txtCellphone" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">Email Address:</td>
                                <td><asp:TextBox ID="txtEmail" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="2"><i><b>Additional Family Members:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Spouse Sex:</td>
                                <td width="35%" align="left">
                                    <asp:RadioButtonList ID="rdbSpouseSex" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">Surname:</td>
                                <td><asp:TextBox ID="txtSpouseSurname" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">First Name:</td>
                                <td>
                                    <asp:TextBox ID="txtSpouseName" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">ID Number</td>
                                <td>
                                    <asp:TextBox ID="txtSpouseIdNo" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">Cellphone:</td>
                                <td><asp:TextBox ID="txtSpouseCell" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Occupation:</td>
                                <td><asp:TextBox ID="txtSpouseOccupation" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="2"><i><b>1st Family Member:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Surname:</td>
                                <td width="35%"><asp:TextBox ID="txtSurname1" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">First Name:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtName1" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">ID Number</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtIdNo1" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">Cellphone:</td>
                                <td><asp:TextBox ID="txtCell1" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Sex:</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbSex1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">&nbsp;</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbSchool1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Student</asp:ListItem>
                                        <asp:ListItem>Scholar</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="2"><i><b>2nd Family Member:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Surname:</td>
                                <td width="35%"><asp:TextBox ID="txtSurname2" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">First Name:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtName2" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">ID Number</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtIdNo2" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">Cellphone:</td>
                                <td><asp:TextBox ID="txtCell2" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Sex:</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbSex2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">&nbsp;</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbSchool2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Student</asp:ListItem>
                                        <asp:ListItem>Scholar</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="2"><i><b>3rd Family Member:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Surname:</td>
                                <td width="35%"><asp:TextBox ID="txtSurname3" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">First Name:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtName3" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">ID Number:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtIdNo3" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">Cellphone:</td>
                                <td><asp:TextBox ID="txtCell3" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Sex:</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbSex3" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">&nbsp;</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbSchool3" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Student</asp:ListItem>
                                        <asp:ListItem>Scholar</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>   
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="2"><i><b>Nominated By:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Nominated By:</td>
                                <td width="35%"><asp:TextBox ID="txtNominated" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Cell No:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtNominatedCell" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">Email Address:</td>
                                <td><asp:TextBox ID="txtNominatedEmail" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Member No:</td>
                                <td>
                                    <asp:TextBox ID="txtNominatedMemNo" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr> 
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="2"><i><b>General Information:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Street Name:</td>
                                <td width="35%"><asp:TextBox ID="txtStreetName" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Street No:</td>
                                <td><asp:TextBox ID="txtStreetNo" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Complex Name:</td>
                                <td><asp:TextBox ID="txtComplexName" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Complex No:</td>
                                <td><asp:TextBox ID="txtComplexNo" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Suburb:</td>
                                <td><asp:TextBox ID="txtSuburb" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">City/Town:</td>
                                <td><asp:TextBox ID="txtCity" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Province:</td>
                                <td><asp:TextBox ID="txtProv" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Code:</td>
                                <td><asp:TextBox ID="txtZipCode" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Postal Address:</td>
                                <td>
                                    <asp:TextBox ID="txtPostalAddr1" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtPostalAddr2" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtPostalAddr3" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td height="27">&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtPostalAddr4" runat="server" CssClass="textbox" Width="250px"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center">&nbsp;<asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                </tr> 
                <tr>
                    <td height="35" align="center"><asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" Width="200px" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>                
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </form>
</body>
</html>
