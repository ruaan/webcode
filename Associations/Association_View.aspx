<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Association_View.aspx.vb" Inherits="Associations_Association_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style type="text/css">
        .auto-style2 {
            width: 800px;
            align-content: center;
            margin: 0 auto;
            text-align: left;
            padding-left: 5px;
        }

        .Animal_Pic {
            height: 150px;
            width: 150px;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <div id="mainPageWrapper">
        <div class="div_MainBlock" style="text-align: left; align-content: center>
            <div>&nbsp;</div>
            <div id="divDetails" class="auto-style2">
                <div class="h1">Associations</div>
                <div>&nbsp;</div>
                <div>
                    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
                </div>
            </div>
        </div>
    </div>
</asp:Content>

