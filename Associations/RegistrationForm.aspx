<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="RegistrationForm.aspx.vb" Inherits="Associations_RegistrationForm" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
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

        .Column1 {
            width: 200px;
            display: inline-block;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
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
                                <td colspan="4"><i><b>Principal Member:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Surname:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtSurname" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td width="15%">First Name:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtName" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Cellphone:</td>
                                <td>
                                    <asp:TextBox ID="txtCellphone" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>ID Number:</td>
                                <td>
                                    <asp:TextBox ID="txtIdNo" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Email Address:</td>
                                <td>
                                    <asp:TextBox ID="txtEmail" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="4"><i><b>Additional Family Members:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Spouse Sex:</td>
                                <td width="35%" align="left">
                                    <asp:RadioButtonList ID="rdbSpouseSex" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td width="15%">&nbsp;</td>
                                <td width="35%">&nbsp;</td>
                            </tr>
                            <tr>
                                <td height="27">Surname:</td>
                                <td>
                                    <asp:TextBox ID="txtSpouseSurname" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>First Name:</td>
                                <td>
                                    <asp:TextBox ID="txtSpouseName" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Cellphone:</td>
                                <td>
                                    <asp:TextBox ID="txtSpouseCell" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>ID Number</td>
                                <td>
                                    <asp:TextBox ID="txtSpouseIdNo" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Occupation:</td>
                                <td>
                                    <asp:TextBox ID="txtSpouseOccupation" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="4"><i><b>1st Family Member:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Surname:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtSurname1" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td width="15%">First Name:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtName1" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Cellphone:</td>
                                <td>
                                    <asp:TextBox ID="txtCell1" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>ID Number</td>
                                <td>
                                    <asp:TextBox ID="txtIdNo1" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Sex:</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbSex1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:RadioButtonList ID="rdbSchool1" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Student</asp:ListItem>
                                        <asp:ListItem>Scholar</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="4"><i><b>2nd Family Member:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Surname:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtSurname2" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td width="15%">First Name:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtName2" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Cellphone:</td>
                                <td>
                                    <asp:TextBox ID="txtCell2" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>ID Number</td>
                                <td>
                                    <asp:TextBox ID="txtIdNo2" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Sex:</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbSex2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:RadioButtonList ID="rdbSchool2" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Student</asp:ListItem>
                                        <asp:ListItem>Scholar</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="4"><i><b>3rd Family Member:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Surname:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtSurname3" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td width="15%">First Name:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtName3" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Cellphone:</td>
                                <td>
                                    <asp:TextBox ID="txtCell3" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>ID Number</td>
                                <td>
                                    <asp:TextBox ID="txtIdNo3" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Sex:</td>
                                <td align="left">
                                    <asp:RadioButtonList ID="rdbSex3" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Male</asp:ListItem>
                                        <asp:ListItem>Female</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                                <td align="left" colspan="2">
                                    <asp:RadioButtonList ID="rdbSchool3" runat="server" RepeatDirection="Horizontal">
                                        <asp:ListItem>Student</asp:ListItem>
                                        <asp:ListItem>Scholar</asp:ListItem>
                                    </asp:RadioButtonList>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="4"><i><b>Nominated By:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Nominated By:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtNominated" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td width="15%">Cell No:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtNominatedCell" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Email Address:</td>
                                <td>
                                    <asp:TextBox ID="txtNominatedEmail" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>Member No:</td>
                                <td>
                                    <asp:TextBox ID="txtNominatedMemNo" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td>
                        <table width="70%" align="center" celpadding="0" cellspacing="0" style="border-color: #000000; border-bottom-style: solid; border-width: thin">
                            <tr>
                                <td colspan="4"><i><b>General Information:</b></i></td>
                            </tr>
                            <tr>
                                <td height="27" width="15%">Street Name:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtStreetName" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td width="15%">Postal Address:</td>
                                <td width="35%">
                                    <asp:TextBox ID="txtPostalAddr1" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Street No:</td>
                                <td>
                                    <asp:TextBox ID="txtStreetNo" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtPostalAddr2" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Complex Name:</td>
                                <td>
                                    <asp:TextBox ID="txtComplexName" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtPostalAddr3" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Complex No:</td>
                                <td>
                                    <asp:TextBox ID="txtComplexNo" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>
                                    <asp:TextBox ID="txtPostalAddr4" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td height="27">Suburb:</td>
                                <td>
                                    <asp:TextBox ID="txtSuburb" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td height="27">City/Town:</td>
                                <td>
                                    <asp:TextBox ID="txtCity" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td height="27">Province:</td>
                                <td>
                                    <asp:TextBox ID="txtProv" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td height="27">Code:</td>
                                <td>
                                    <asp:TextBox ID="txtZipCode" Width="250px" CssClass="textbox" runat="server"></asp:TextBox></td>
                                <td>&nbsp;</td>
                                <td>&nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="4">&nbsp;</td>
                            </tr>
                        </table>
                    </td>
                </tr>
                <tr>
                    <td height="27" align="center">&nbsp;<asp:Label ID="lblMsg" runat="server" Text="" ForeColor="Red"></asp:Label></td>
                </tr>
                <tr>
                    <td height="35" align="center">
                        <asp:Button ID="btnSubmit" runat="server" Text="Submit" CssClass="button" Width="200px" /></td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Content>
