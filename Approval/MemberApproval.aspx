<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="MemberApproval.aspx.vb" Inherits="Approval_MemberApproval" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
    <style>
        .div_Center{
            text-align:center;
        }
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <div>
        <div>&nbsp;</div>
        <div class="h1">Pre-Reg Authorisation</div>
        <div>&nbsp;</div>
        <div id="divGrid">
            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" EmptyDataText="There are no Applications waiting for approval.">
                            <Columns>
                                <asp:ButtonField ButtonType="Button" CommandName="view" Text="Select"  ControlStyle-CssClass="nextPrevButton"  />
                                <asp:BoundField DataField="Pre_Id" HeaderText="PreReg Id" />
                                <asp:BoundField DataField="Surname" HeaderText="Surname" />
                                <asp:BoundField DataField="PreferredName" HeaderText="Preferred Name" />
                                <asp:BoundField DataField="IDNo" HeaderText="IDNo/ Passport" />
                                <asp:BoundField DataField="DateApplied" DataFormatString="{0:dd/MM/yyyy  HH:mm}" HeaderText="Date Applied" HtmlEncode="False" />
                                <asp:ButtonField ButtonType="Button" CommandName="approve" Text="Quick Approve"  ControlStyle-CssClass="nextPrevButton"  />
                                <asp:ButtonField ButtonType="Button" CommandName="decline" Text="Quick Decline"  ControlStyle-CssClass="nextPrevButton"  />
                            </Columns>
                        </asp:GridView>
        </div>
        <div><asp:Label ID="lblMsg" runat="server"></asp:Label></div>
         <div>&nbsp;</div>
        <div  id="divDetails" runat="server" visible ="false" class="divContainer" style="border: thin solid #BBB530; padding-left: 20px; width:80%">
            <div class="yellowHeader">Application Details</div>
            <div>&nbsp;</div>
            <div>
                <div>Pre-Reg Id:  <asp:Label ID="lblPreRegId" runat="server"></asp:Label></div>
            </div>
            <div>
                <div style="font-weight: bold" class="divFormMng">Date Applied:</div>&nbsp;<div class="divFormMng"><asp:Label ID="lblDateApplied" runat="server" ></asp:Label></div>
            </div>
            <div>&nbsp;</div>
            <div style="vertical-align:top">
            <div class="divFormMng" style="padding: 20px; border: thin solid #C0C0C0;">
                 <div class="divFormMng">
                <div>Title</div>
                <div>
                    <asp:Label ID="lblTitle" runat="server" ></asp:Label>
                </div>
            </div>
            <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">
                <div>Initials</div>
                <div>
                    <asp:Label ID="lblInitials" runat="server" ></asp:Label>
                </div>
            </div>
             <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">
                <div>Full Name</div>
                <div>
                    <asp:Label ID="lblFullNames" runat="server"></asp:Label>
                </div>
            </div>
             <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">
                <div>Last Name</div>
                <div>
                   <asp:Label ID="lblSurname" runat="server" ></asp:Label>
                </div>
            </div>
<div>&nbsp;</div>
           
            <div class="divFormMng">
                <div>Preferred Name</div>
                <div>
                    <asp:Label ID="LblPreferredName" runat="server"></asp:Label>
                </div>
            </div>
             <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">
                <div>Gender</div>
                <div>
                   <asp:Label ID="lblGender" runat="server"></asp:Label>
                </div>
            </div>
                 <div>&nbsp;</div>
                 <div class="divFormMng">
                <div>Referred By</div>
                <div>
                   <asp:Label ID="lblRefBy" runat="server"></asp:Label>&nbsp;<asp:Label ID="lblReferName" runat="server" Text=""></asp:Label>
                                       &nbsp; <asp:Button ID="btnViewRefBy" runat="server" Text="View" CssClass="nextPrevButton" />
                </div>
            </div>
                 <div>&nbsp;</div>
                 <div>&nbsp;</div>
                </div>
            <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng" style="padding: 20px; border: thin solid #C0C0C0;">
            
            <div class="divFormMng">
                <div>Country</div>
                <div>
                    <asp:Label ID="lblCountry" runat="server"></asp:Label>
                </div>
            </div>
             <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">
                <div>Nationality</div>
                <div>
                   <asp:Label ID="lblNationality" runat="server"></asp:Label>
                </div>
            </div>
            <div>&nbsp;</div>
                  <div class="divFormMng">
                <div>Identity Number</div>
                <div>
                    <asp:Label ID="lblIdNo" runat="server"></asp:Label>
                </div>
            </div>
             <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">
                <div>Passport Number</div>
                <div>
                   <asp:Label ID="lblPassport" runat="server"></asp:Label>
                </div>
            </div>
                <div>&nbsp;</div>
                 <div class="divFormMng">
                <div>Email</div>
                <div>
                     <asp:Label ID="lblEmail" runat="server"></asp:Label>
                </div>
            </div>
             <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">
                <div>Mobile Number</div>
                <div>
                    <asp:Label ID="lblCell" runat="server"></asp:Label>
                </div>
            </div>
             
                 <div>&nbsp;</div>
                             <div class="divFormMng">&nbsp;</div>
            <div class="divFormMng">
                <div>Business Telephone Number</div>
                <div>
                   <asp:Label ID="lblWorkTel" runat="server"></asp:Label>
                </div>
            </div>
                </div>
                </div>
             <div>&nbsp;</div>
            <div class="div_Center">
                <div class="divFormMng"> <asp:Button ID="btnapprove" runat="server" Text="Approve" CssClass="nextPrevButton" /></div>
                 <div class="divFormMng">&nbsp;</div>
                <div class="divFormMng"> <asp:Button ID="btnDecline" runat="server" Text="Decline" CssClass="nextPrevButton" /></div>
                 <div class="divFormMng">&nbsp;</div>
                <div class="divFormMng"> <asp:Button ID="btnCancel" runat="server" Text="Cancel" CssClass="nextPrevButton" /></div>
            </div>
             <div>&nbsp;</div>

            </div>

        </div>

   
   </asp:Content>

