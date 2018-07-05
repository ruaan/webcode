<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Association_Admin_Members_App.aspx.vb" Inherits="Associations_Association_Admin_Members_App" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
      <style type="text/css">
        body {
            background-color:#394025;
            margin:0;
}
        .auto-style1 {
            width: 100%;
        }
          .divFilter {
            border: 1px solid #8d9296;
           
            font-size: medium;
            background-color: #5B6849;
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            font-family:Calibri;
            color:white;
        }

        .divResult {
            display: inline-block;
            vertical-align: top;
            text-align: left;
            padding-left: 10px;
        }

        

        .div_Farm_Block {
            border: 1px solid #333333;
            background-color: #F8F8F8;
            padding: 15px;
            font-family: Calibri;
            color: #333333;
            cursor:pointer;
        }

        .div_Picture_Style {
            width: 80px;
            height: 80px;
            display: inline-block;
        }

        .div_Farm_header {
            font-size: large;
            font-weight: bold
        }

        .div_Middle_Block {
            width: 300px;
            vertical-align: top;
            padding: 0px 10px 10px 10px;
            display: inline-block;
        }

        .div_right_block {
            width: 200px;
            vertical-align: top;
            padding-top: 0px;
            padding-left: 20px;
            display: inline-block;
            border-left-style: solid;
            border-width: thin;
            border-color: #FFFFFF;
        }

        .image_Style {
            width: 100%;
            height: 100%;
        }

        .div_text_block {
            height: 190px;
        }

        .icon_style {
            padding: 5px;
            display: inline-block;
        }

        .rateStar {
            width: 28px;
            height: 28px;
        }

        .div_facility_block {
            min-height: 150px;
        }

        .facilities {
            padding-bottom: 5px;
        }

        .drop_icon {
            width: 16px;
            height: 16px;
        }

        .header_icon {
            width: 21px;
            height: 21px;
            vertical-align: middle;
        }

        .arrow_icon {
            vertical-align: middle;
        }

        .header_text {
            padding-left: 5px;
        }
        .chkBoxList {
            margin-right: 10px;
            padding-right: 10px;
            padding-left: 10px;
            padding-bottom: 5px;
            
            width: 100%;
        }
        .thisButton{
            background-color:#7DB35C; 
            border-style:none;
            color:white;
            font-size:14px;
        }
        </style>
</head>
<body>
    <form id="form1" runat="server">
          <div>
             <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
        <div id="divSearch" style="  font-size: large">
               <div class="divFilter" id="divFilter">
                    
            <div class="h1" >Association Members</div>
           
            <div style="padding: 5px; border-style: none none solid none; border-width: thin; border-color: #86B24F; width: 96%; cursor:pointer; font-size: larger;" id="divLocationHdr" class="inline_Panel_Header" >
               
                <div style="display: inline-block;" class="header_text">
                     <asp:DropDownList ID="DropDownList1" runat="server" AutoPostBack="True" DataTextField="Name" DataValueField="Association_Id"></asp:DropDownList>
                </div>
               
                <div style="display: inline-block;">&nbsp;</div>
            </div>
          
 
            

           
            
            <div>&nbsp;</div>
            <div style="width: 96%" id="additional" class="inline_Panel_Header">
                <div style="width: 90%">
                    <div style="display: inline-block; width: 2%">&nbsp;</div>
                    <div style="display: inline-block; width: 70%">
                        <div>Search Member by Name</div>
                        <div style="vertical-align:middle;">
                            <asp:TextBox ID="txtMemName" runat="server" Width="250px" CssClass="textbox"></asp:TextBox>&nbsp;</div>

                    </div>
                </div>
            </div>
         
            <div>&nbsp;</div>
            <div style="width: 96%"  id="divBtn" ">
                <div>
 <div>
                    <asp:Button ID="Button3" runat="server" Text="Add Member" CssClass="thisButton"/>

 </div>
                <div id="divAddPanel" runat="server" style="border: thin solid #86B24F">
                    <div id="divaddSearch" runat="server" visible="false">
                    <div>Search for the member using, Name, Surname, Idno, Mobile number or Email address: &nbsp; </div>
                    <div><asp:TextBox ID="txtMemberSearch" runat="server" CssClass="textbox" Width="222px"></asp:TextBox> &nbsp;<asp:ImageButton ID="ImageButton2" runat="server" ImageUrl="~/Images/Icons/search.png" /></div>
                        </div>
                    <div id="divSelect" runat="server" visible="false">
                           <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False"  ShowFooter="True" Width="794px" EmptyDataText="No Members matches your search.">

                                        <Columns>
                                            <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/select.png" Text="Select" />
                                            <asp:BoundField DataField="MemberId">
                                                <ItemStyle ForeColor="White" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="Surname" HeaderText="Surname" />
                                            <asp:BoundField DataField="FullName" HeaderText="Full Name" />
                                            <asp:BoundField HeaderText="Title" DataField="Title">
                                                <ItemStyle HorizontalAlign="Center" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Preffered Name" DataField="PreferredName">
                                                <ItemStyle HorizontalAlign="Left" />
                                            </asp:BoundField>
                                            <asp:BoundField HeaderText="Id No" DataField="IDNo">
                                                <FooterStyle Font-Bold="True" HorizontalAlign="Right" />
                                                <ItemStyle HorizontalAlign="Right" />
                                            </asp:BoundField>
                                            <asp:BoundField DataField="CellNo" HeaderText="Mobile No" />
                                            <asp:BoundField DataField="Email" HeaderText="Email" />
                                        </Columns>
                                    </asp:GridView>
                    </div>
                    <div id="divAddDetails" runat="server" visible="false" style="border: thin solid #86B24F; padding: 5px">
                        <div> Eco-Hunter Id:  <asp:Label ID="lblEcohunterId" runat="server" Text="Label"></asp:Label></div>
                        <div> Name:  <asp:Label ID="lblAddName" runat="server" Text="Label"></asp:Label></div>
                        <div> Association Membership No:  <asp:TextBox ID="txtAssociationNo" runat="server" CssClass="textbox"></asp:TextBox></div>
                        <div align="center">
                            <asp:Button ID="Button1" runat="server" Text="Submit" CssClass="thisButton" /> &nbsp;<asp:Button ID="Button2" runat="server" Text="Cancel" CssClass="thisButton" /></div>
                    </div>
                </div>



                </div>
                    <div style="display: inline-block; " class="auto-style2">
                       
                    </div>
                    <div align="center" style="display: inline-block; " class="auto-style1">
                         <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/Farm_Search/filtersearchbar.png" />
                    </div>
                <div>
                    <asp:Button ID="btnClearAll" runat="server" Text="Clear All" BorderStyle="None" Font-Size="Larger" Visible="False" /></div>

            </div>

            <div>&nbsp;</div>
        </div>

        </div>
 <div style="font-family: Calibri; color: #424531;">
             <table align="center" style="width: 90%;">
                <tr>
                    <td style="color: #FFFFFF; font-size: medium;">
                       <div id="divSearchClick" onclick="ToggleSearch('divSearch','imgAvailabilityDown','imgAvailabilityUp')" style="font-size: larger; display:none;" > <img alt="" src="Images/Icons/Farm_Search/filter.png" />VIEW FILTERS</div></td>
                </tr>
                <tr>
                    <td style="color: #FFFFFF; font-size: large;">
                        &nbsp;</td>
                </tr>
                <tr>
                    <td>
                        <asp:PlaceHolder ID="PlaceHolder1" runat="server"></asp:PlaceHolder> <asp:Label ID="Label1" runat="server" ForeColor="White"></asp:Label>
                    </td>
                </tr>
                <tr>
                    <td>&nbsp;</td>
                </tr>
            </table>
        </div>




        </div>
    </form>
</body>
</html>
