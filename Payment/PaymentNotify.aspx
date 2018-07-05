<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="PaymentNotify.aspx.vb" Inherits="Payment_PaymentNotify" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

    <input  name="m_payment_id" type="text" />
    <input  name="payment_status" type="text" /><br />
    <br />
    <asp:Label ID="lblPaymentStatus" runat="server" Text=""></asp:Label>
    <asp:Label ID="llbAmount_gross" runat="server" Text="10"></asp:Label>
&nbsp;

    <script>

        

    </script>

</asp:Content>

