<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Outfitters_app.aspx.vb" Inherits="Outfitters_app" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style>
        body {
            background-color: #394025;
            margin: 0;
        }

        .divFilter {
            border: 1px solid #8d9296;
            padding: 4px;
            font-size: large;
            background-color: #5B6849;
            display: inline-block;
            vertical-align: top;
            width: 100%;
            text-align: left;
            font-family: Calibri;
            color: white;
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
            cursor: pointer;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
          <div id="mainPageWrapper">
            <div id="mainBlock" class="div_MainBlock">
                <img alt="" src="Images/Headings/outfitters.jpg" style ="width:100%"/>
                   <div class="divFilter" id="divFilter">
                    
            <div class="h1" >Search Outfitters</div>
            <div>&nbsp;</div>
           <div>Country: <asp:DropDownList ID="cmbCountry" runat="server" AutoPostBack="True" DataSourceID="SqlDataSourceCountries" DataTextField="Name" DataValueField="Country_Id"></asp:DropDownList>
               <asp:SqlDataSource ID="SqlDataSourceCountries" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Country_Id], [Name] FROM [tblCountries] WHERE ([Active] = @Active) ORDER BY [Name]">
                   <SelectParameters>
                       <asp:Parameter DefaultValue="True" Name="Active" Type="Boolean" />
                   </SelectParameters>
               </asp:SqlDataSource>
                       </div>
            <div>&nbsp;</div>
            <div style="width: 96%; cursor:pointer;" id="divLocationHdr" class="inline_Panel_Header" onclick="ToggleDetails('divLocationDtl','imgLocationDown','imgLocationUp')">
                <div style="display: inline-block">
                    <img alt="" src="Images/Icons/Farm_Search/Main/location.png" class="header_icon" /></div>
                <div style="display: inline-block;" class="header_text">Location</div>
                <div style="display: inline-block; float: right;">
                    <img id="imgLocationUp" alt="" src="Images/Icons/numUp.png" style="display: none" class="arrow_icon" />
                    <img id="imgLocationDown" alt="" src="Images/Icons/numDown.png"  class="arrow_icon"  />
                </div>
                <div style="display: inline-block;">&nbsp;</div>
            </div>
            <div id="divLocationDtl" style="display:none; width:100%">
                <asp:CheckBoxList ID="chkLocation" runat="server" DataTextField="Name" DataValueField="ProvinceId" Width="100%" CssClass="chkBoxList"></asp:CheckBoxList>
                <asp:SqlDataSource ID="SqlDataSourceLocation" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Name], [ProvinceId] FROM [tblProvince] ORDER BY [Name]"></asp:SqlDataSource>
             
                </div>
 
       
            <div>&nbsp;</div>
            <div style="width: 96%"  id="divBtn" ">
                <div style="display: inline-block; width: 2%">&nbsp;</div>
                    <div style="display: inline-block; " class="e-style2">
                       
                        <asp:Button ID="btnClearAll" runat="server" Text="Clear All" CssClass="button" Width="83px" Visible="False" />
                    </div>
                    <div style="display: inline-block; float:right">
                    </div>
                 <div align="center" style="">
                          <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="~/Images/Icons/Farm_Search/filtersearchbar.png" />
                    </div>

            </div>

            <div>&nbsp;</div>
        </div>
               
                <div class="divResult" id="divResult">
             
                    <div>&nbsp;</div>
                    <div style="width:100%">
                    <asp:PlaceHolder ID="PlaceHolder4" runat="server"></asp:PlaceHolder>
                        </div>
                </div>

             
            </div>
        
        </div>
  
    <script type="text/javascript">

        function ToggleDetails(pnlDiv, imgDown, imgUp) {
            var Colordiv = document.getElementById(pnlDiv);
            var CustImgDown = document.getElementById(imgDown);
            var CustImgUp = document.getElementById(imgUp);

            if (Colordiv.style.display == 'none') {
                Colordiv.style.display = 'inline-block';
                CustImgDown.style.display = 'none';
                CustImgUp.style.display = 'inline-block';
            } else {
                Colordiv.style.display = 'none';
                CustImgDown.style.display = 'inline-block';
                CustImgUp.style.display = 'none';
            }

        }

     


</script>
    </form>
</body>
</html>
