<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="Animal_View.aspx.vb" Inherits="Animal_View" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="Server">
    <style>
        #mainPageWrapper1 {
            text-align: center;
            font-family: Calibri;
        }

        .MainImage-style {
            width: 171px;
            height: 180px;
        }

        .Geninfo-style {
            width: 1056px;
            align-content: center;
        }

        .img-style2 {
            width: 150px;
            height: 150px;
        }

        .div_details1 {
            display: inline-block;
            vertical-align: top;
            width: 800px;
            text-align: left;
            padding-left: 5px;
            padding-right: 5px;
            border: thin solid #333333
        }

        .name-style3 {
            width: 75%;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="Server">
    <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder>
</asp:Content>

