<%@ Page Language="VB" AutoEventWireup="false" CodeFile="Member_Registration_Mobi.aspx.vb" Inherits="Member_Registration_Mobi" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <style>
         .divsE {
             display: inline-block;
         }

         .divMainContainer {
             display: inline-block;
             width: 70%;
         }

         .divFormMng {
             display: inline-block;
         }

         .auto-style4 {
             font-size: xx-large;
             width: 7px;
         }

         .auto-style5 {
             width: 7px;
         }

         .auto-style6 {
             width: 349px;
         }

         .auto-style7 {
             width: 51px;
         }

         .textbox {
             -moz-border-radius: 3px;
             border-radius: 3px;
             border: 1px solid #8d9296;
             color: #a3a3a3;
             padding: 4px;
             font-size: 48px;
         }

         .auto-style8 {
             width: 181px;
             height: 72px;
         }
     </style>
</head>
<body>
    <form id="form1" runat="server">
            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
         <asp:UpdatePanel ID="UpdatePanel1" runat="server"><ContentTemplate>
             <div style="width:100%; background-color: #3E432F;">
                 <div style="display:inline-block">
                     <img alt="" src="Images/Logos/eco-hunter-log-large.png" /></div>
                 <div style="display:inline-block; font-size: 70px; color: #FFFFFF; font-family: Calibri;">Member Registration</div>
             </div>
    <div height="40px">&nbsp;</div>
    <div valign="top" style="clip: rect(0px, auto, auto, auto); font-size: 48px; font-family: Calibri; color: #333333;">
        <div id="pnlPersonalDetails" runat="server" class="divMainContainer" style="border-width: thin; border-color: #FFFF00; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;">
            <div class="h1" style="font-size: 60px">Personal Information</div>
            <div>&nbsp;</div>
            <div class="divFormMng">
                <div>Title</div>
                <div>
                    <asp:DropDownList ID="cmbTitle" runat="server" CssClass="textbox">
                        <asp:ListItem>Mr</asp:ListItem>
                        <asp:ListItem>Mrs</asp:ListItem>
                        <asp:ListItem>Dr</asp:ListItem>
                        <asp:ListItem>Prof</asp:ListItem>
                        <asp:ListItem>Adv</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div class="divFormMng">
                <div>Initials</div>
                <div>
                    <asp:TextBox ID="txtInitials" runat="server" CssClass="textbox" MaxLength="10" ></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Full Name</div>
                <div>
                    <asp:TextBox ID="txtFullNames" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Last Name</div>
                <div>
                    <asp:TextBox ID="txtSurname" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div>&nbsp;</div>
            <div>
                <div class="divFormMng">
                    <div>Gender</div>
                    <div>
                        <asp:RadioButtonList ID="rdbGender" runat="server">
                            <asp:ListItem>Male</asp:ListItem>
                            <asp:ListItem>Female</asp:ListItem>
                        </asp:RadioButtonList>
                    </div>
                </div>
                <div style="vertical-align: bottom;" class="divFormMng">
                    <div>Preferred Name</div>
                    <div>
                        <asp:TextBox ID="txtPreferredName" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                    </div>
                </div>
                <div style="vertical-align: bottom;" class="divFormMng">
                    <div>Email Address</div>
                    <div>
                        <asp:TextBox ID="txtEmail" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div>&nbsp;</div>
            <div>
                <div style="vertical-align: bottom;" class="divFormMng">
                    <div>Mobile Number</div>
                    <div>
                        <asp:TextBox ID="txtCell" runat="server" CssClass="textbox" MaxLength="14" TextMode="Phone"></asp:TextBox>
                    </div>
                </div>
                <div style="vertical-align: bottom;" class="divFormMng">
                    <div>Business Telephone Number</div>
                    <div>
                        <asp:TextBox ID="txtWorkTel" runat="server" CssClass="textbox" MaxLength="14" ></asp:TextBox>
                    </div>
                </div>
                <div style="vertical-align: bottom;" class="divFormMng">
                    <div>Home Telephone Number</div>
                    <div>
                        <asp:TextBox ID="txtWorkTel0" runat="server" CssClass="textbox" MaxLength="14" ></asp:TextBox>
                    </div>
                </div>
            </div>
            <div>&nbsp;</div>
            <div style="display:none;">
                <div style="vertical-align: bottom;" class="divFormMng">
                    <div>Country</div>
                    <div>
                        <asp:DropDownList ID="cmbCountry" runat="server" CssClass="textbox">
                            <asp:ListItem>South Africa</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                <div style="vertical-align: bottom;" class="divFormMng">
                    <div>Identity Number</div>
                    <div>
                        <asp:TextBox ID="txtIdDoc" runat="server" CssClass="textbox" MaxLength="13" Width="185px"></asp:TextBox>
                    </div>
                </div>
                <div style="vertical-align: bottom;" class="divFormMng">
                    <div>Passport Number</div>
                    <div>
                        <asp:TextBox ID="txtPassport" runat="server" CssClass="textbox" MaxLength="20" Width="155px"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div>&nbsp;</div>
            <div style="vertical-align: bottom;" class="divFormMng">
                <div>Nationality</div>
                <div>
                    <asp:DropDownList ID="cmbNationality" runat="server" CssClass="textbox">
                        <asp:ListItem>South Africa</asp:ListItem>
                    </asp:DropDownList>
                </div>
            </div>
            <div>&nbsp;</div>
            <div style="text-align: right">
                &nbsp;<asp:Button ID="btnSavePersonal" runat="server" Text="Save" CssClass="nextPrevButton" Visible="False" />&nbsp;<asp:Button ID="btnPerNext" runat="server" Text="Register" CssClass="lineButton" BackColor="#86B24F" BorderStyle="None" Font-Size="48px" ForeColor="White" />
            </div>
            <div style="text-align: right">
                <asp:Label ID="lblPreSubmit" runat="server" Text=""></asp:Label></div>
        </div>


        <div id="pnlMedical" runat="server" class="divMainContainer" style="border-width: thin; border-color: #FFFF00; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;" visible="False">
            <div class="h1">Medical Information</div>
            <div>&nbsp;</div>
          
            <div class="divFormMng">
                <div>Medical aid scheme</div>
                <div>
                    <asp:TextBox ID="txtMedicalAidScheme" runat="server" CssClass="textbox" MaxLength="50" ></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Medical aid no</div>
                <div>
                    <asp:TextBox ID="txtMedicalAidNo" runat="server" CssClass="textbox" MaxLength="20"></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Main Member</div>
                <div>
                    <asp:TextBox ID="txtMedicalAidMainMember" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div>&nbsp;</div>
            <div>
           Please add any allergies: 
                            <asp:TextBox ID="txtAlergies" runat="server" CssClass="textbox" MaxLength="200" Width="301px"></asp:TextBox>
                            <asp:Button ID="btnAddAllergies" runat="server" CssClass="button" Text="Add" Width="53px" />
            </div>
            <div>&nbsp;</div>
         <div id="divMedicalConditions" runat="server">
             <div>Medical Conditions and Allergies</div>
             <div>
                 <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" GridLines="None" ShowHeader="False">
                                <Columns>
                                    <asp:BoundField DataField="Allergie" />
                                </Columns>
                            </asp:GridView>
             </div>
         </div>
            <div>&nbsp;</div>
            <div style="text-align: right">
                <asp:Button ID="btnMedicalPrev" runat="server" Text="Previous" CssClass="lineButton" />&nbsp;<asp:Button ID="btnSaveMedical" runat="server" Text="Save" CssClass="nextPrevButton" />&nbsp;<asp:Button ID="btnMedicalNext" runat="server" Text="Next" CssClass="lineButton" />
            </div>
        </div>

          <div id="pnlNextofKin" runat="server" class="divMainContainer" style="border-width: thin; border-color: #FFFF00; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;" visible="False">
            <div class="h1">Next of Kin</div>
            <div>&nbsp;</div>
          <div><asp:Button ID="btnAddNextKin" runat="server" CssClass="button" Text="Add" />
              <div id="pnlAddNextKin" runat="server" visible="false">
                  <div>
                       <div class="divFormMng">
                <div>Name</div>
                <div>
                    <asp:TextBox ID="txtNextKinName" runat="server" CssClass="textbox" MaxLength="50" ></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Last Name</div>
                <div>
                    <asp:TextBox ID="txtNextKinName0" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Relationship</div>
                <div>
                    <asp:TextBox ID="txtNextKinRelationship" runat="server" CssClass="textbox" MaxLength="20"></asp:TextBox>
                </div>
            </div>
                  </div>
                  <div>&nbsp;</div>
                   <div>
                       <div class="divFormMng">
                <div>Email Address</div>
                <div>
                    <asp:TextBox ID="txtNextKinEmail" runat="server" CssClass="textbox" MaxLength="50" ></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Mobile Number</div>
                <div>
                    <asp:TextBox ID="txtNextKinCell" runat="server" CssClass="textbox" MaxLength="20"></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Alternative Number</div>
                <div>
                    <asp:TextBox ID="txtNextKinCell0" runat="server" CssClass="textbox" MaxLength="20"></asp:TextBox>
                </div>
            </div>
                  </div>
                  <div>&nbsp;</div>
              <div style="align-items:center"> <asp:Button ID="btnSaveAddNextKin" runat="server" CssClass="button" Text="Save" />
                                                        &nbsp;
                                                        <asp:Button ID="btnCancelAddNextKin" runat="server" CssClass="button" Text="Cancel" /></div>
              </div>
              <div>&nbsp;</div>
              </div>
          
            
          
            <div>&nbsp;</div>
      <div><asp:GridView ID="grdNextKin" runat="server" AutoGenerateColumns="False" BorderStyle="None" Font-Size="Small" Width="80%" GridLines="None" ShowHeader="False">
                                            <Columns>
                                                <asp:BoundField DataField="Name">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Relationship">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="EmailAddress">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="MobileNo" />
                                                <asp:BoundField DataField="AlternativeNo" />
                                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/edit.png" Text="Edit">
                                                <ControlStyle BorderStyle="None" />
                                                <HeaderStyle BorderStyle="None" />
                                                <ItemStyle BorderStyle="None" />
                                                </asp:ButtonField>
                                                <asp:ButtonField ButtonType="Image" CommandName="Remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove">
                                                <HeaderStyle BorderStyle="None" />
                                                <ItemStyle BorderStyle="None" />
                                                </asp:ButtonField>
                                                <asp:BoundField DataField="id">
                                                <ItemStyle BorderStyle="None" ForeColor="#494D50" />
                                                </asp:BoundField>
                                            </Columns>
                                        </asp:GridView></div>
            <div>&nbsp;</div>
            <div style="text-align: right">
                <asp:Button ID="btnNextKinPrevious" runat="server" Text="Previous" CssClass="lineButton" />&nbsp;<asp:Button ID="btnSaveNextKin" runat="server" Text="Save" CssClass="nextPrevButton" />&nbsp;<asp:Button ID="btnNextKinNext" runat="server" Text="Next" CssClass="lineButton" />
            </div>
        </div>
    
        
        <div id="pnlAddress" runat="server" class="divMainContainer" style="border-width: thin; border-color: #FFFF00; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;" visible="False">
            <div class="h1">Address & Domicile</div>
            <div>&nbsp;</div>
          
            <div class="divFormMng">
                <div>Residential Address</div>
                <div>
                    <asp:TextBox placeholder="Street Name" ID="txtHomeStreet" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                    <asp:TextBox placeholder="No" ID="txtHomeStreetNo" runat="server" AutoCompleteType="Cellular" CssClass="textbox" MaxLength="10" Width="51px"></asp:TextBox>
                </div>
            </div>
       <div>&nbsp;</div>
           
       <div class="divFormMng">
 <div>
                    <asp:TextBox placeholder="Complex Name" ID="txtHomeComplex" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                                        <asp:TextBox ID="txtComplexNo" placeholder="No" runat="server" AutoCompleteType="Cellular" CssClass="textbox" MaxLength="10"  Width="51px"></asp:TextBox>
                </div>
            </div>
            <div>&nbsp;</div>
            <div>
              <div class="divFormMng">
 <div>
                  <asp:TextBox ID="txtHomeSuburb" placeholder="Suburb" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                </div>
            </div>
                </div>
            <div>&nbsp;</div>
             <div class="divFormMng">
 <div>
                 <asp:TextBox placeholder="City"  ID="txtHomeCity" runat="server" CssClass="textbox" MaxLength="100" Width="160px"></asp:TextBox>
                                        <asp:DropDownList ID="cmbHomeProvince" runat="server" CssClass="textbox">
                                        </asp:DropDownList>
                                        <asp:TextBox placeholder="Postal Code" ID="txtHomePostal" runat="server" CssClass="textbox" MaxLength="10" Width="107px"></asp:TextBox>
                </div>
            </div>
            <div>&nbsp;</div>
            <div>&nbsp;</div>
             <div class="divFormMng">
                <div>Business Address</div>
                <div>
                    <asp:TextBox placeholder="Street Name" ID="txtWorkStreet" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                    <asp:TextBox placeholder="No" ID="txtworkStreetNo" runat="server" CssClass="textbox" MaxLength="10" Width="51px"></asp:TextBox>
                </div>
            </div>
       <div>&nbsp;</div>
           
       <div class="divFormMng">
 <div>
                     <asp:TextBox ID="txtWorkComplex" Placeholder="Complex/Building Name" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                                        <asp:TextBox ID="txtWorkComplexNo" runat="server" CssClass="textbox" MaxLength="10" placeholder="No" Width="51px"></asp:TextBox>
                </div>
            </div>
            <div>&nbsp;</div>
            <div>
              <div class="divFormMng">
 <div>
                  <asp:TextBox ID="txtWorkSuburb" placeholder="Suburb" runat="server" CssClass="textbox" MaxLength="100" Width="355px"></asp:TextBox>
                </div>
            </div>
                </div>
            <div>&nbsp;</div>
             <div class="divFormMng">
 <div>
                  <asp:TextBox placeholder="City"  ID="txtWorkCity" runat="server"  CssClass="textbox" MaxLength="100" Width="160px"></asp:TextBox>
                                        <asp:DropDownList ID="cmbWorkProvince" runat="server" CssClass="textbox">
                                        </asp:DropDownList>
                                        <asp:TextBox placeholder="Postal Code" ID="txtWorkPostal" runat="server"  CssClass="textbox" MaxLength="10" Width="107px"></asp:TextBox>
                </div>
            </div>
            <div>&nbsp;</div>




            <div style="text-align: right">
                <asp:Button ID="btnAddressPrevious" runat="server" Text="Previous" CssClass="lineButton" />&nbsp;<asp:Button ID="btnSaveAddress" runat="server" Text="Save" CssClass="nextPrevButton" />&nbsp;<asp:Button ID="btnAddressNext" runat="server" Text="Next" CssClass="lineButton" />
            </div>
        </div>

  <div id="pnlHuntingDetails" runat="server" class="divMainContainer" style="border-width: thin; border-color: #FFFF00; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid; " visible="False">
            <div class="h1">Hunting Accreditation</div>
            <div>&nbsp;</div>
      <div>
                       <div class="divFormMng">
                <div>Dedicated Hunter Member Number</div>
                <div>
                    <asp:TextBox ID="txtDedicatedHunterNo" runat="server" CssClass="textbox" MaxLength="20" Width="226px" ></asp:TextBox>
                </div>
            </div>
          <div class="divFormMng">
               <div>&nbsp;</div>
                <div>
                    &nbsp;
                </div>
          </div>
            <div class="divFormMng">
                <div>Dedicated Sport Shooter Number</div>
                <div>
                    <asp:TextBox ID="txtDedicatedSportNo" runat="server" CssClass="textbox" MaxLength="20" Width="226px"></asp:TextBox>
                </div>
            </div>
            
                  </div>
         
          
            
          
            <div>&nbsp;</div>
      <div>
          <div class="yellowHeader">Certification</div>
          <div>
               <asp:GridView ID="GridView4" runat="server" AutoGenerateColumns="False" DataKeyNames="id" DataSourceID="sqlCertification" GridLines="None">
                                <Columns>
                                    <asp:BoundField DataField="id" HeaderText="" InsertVisible="False" ReadOnly="True" SortExpression="id" >
                                    <ItemStyle ForeColor="#494D50" />
                                    </asp:BoundField>
                                    <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                                    <asp:TemplateField HeaderText="">
                                                            <ItemTemplate>
                                                                <asp:CheckBox ID="ChkCertificate" runat="server"   />
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Certificate No">
                                                            <ItemTemplate>
                                                                <asp:TextBox ID="txtCertNo" runat="server" CssClass="textbox" MaxLength="50" Width="100px"/>
                                                            </ItemTemplate>
                                                        </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="sqlCertification" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT * FROM [tbl_Certificate_Descriptions] WHERE Active = 'True'"></asp:SqlDataSource>
          </div>
      </div>
            <div>&nbsp;</div>
      <div>
          <div class="divFormMng">
              <div class="yellowHeader">Registered Firearms</div>
              <div><asp:Button ID="btnAddFireArm" runat="server" CssClass="button" Text="Add Firearm" /></div>
                <div id="pnlAddFireArm" runat="server" visible="false">
                  <div>
                       <div class="divFormMng">
                <div>Description</div>
                <div>
                    <asp:TextBox ID="txtFireArmDesc" runat="server" CssClass="textbox" MaxLength="100" ></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Serial No</div>
                <div>
                    <asp:TextBox ID="txtFireArmSerial" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Lisence No</div>
                <div>
                    <asp:TextBox ID="txtFireArmLisence" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                </div>
            </div>
                  </div>
                 
                  <div>&nbsp;</div>
              <div style="align-items:center"> <asp:Button ID="btnAddFireArmUpdate" runat="server" CssClass="button" Text="Save" />
                                                        &nbsp;
                                                        <asp:Button ID="btnAddFireArmCancel" runat="server" CssClass="button" Text="Cancel" /></div>
              </div>

          </div>

           <div>
          <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BorderStyle="None" EmptyDataText="No Fire Arms Registered" Font-Size="Small" Width="60%">
                                            <Columns>
                                                <asp:BoundField DataField="Description" HeaderText="Description">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="SerialNo" HeaderText="Serial No">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="LisenceNo" HeaderText="Lisence No">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/edit.png" Text="Edit">
                                                <ControlStyle BorderStyle="None" />
                                                <HeaderStyle BorderStyle="None" />
                                                <ItemStyle BorderStyle="None" />
                                                </asp:ButtonField>
                                                <asp:ButtonField ButtonType="Image" Text="Remove" ImageUrl="~/Images/Icons/trash.png" CommandName="Remove">
                                                
                                                <HeaderStyle BorderStyle="None" />
                                                <ItemStyle BorderStyle="None" />
                                                
                                                </asp:ButtonField>
                                            </Columns>
                                        </asp:GridView>
      </div>



      </div>
            <div>&nbsp;</div>
      <div>
          <div class="divFormMng">
              <div class="yellowHeader">Permits</div>
              <div><asp:Button ID="btnAddPermit" runat="server" CssClass="button" Text="Add Permit" /></div>
                <div id="pnlPermits" runat="server" visible="false">
                  <div>
                       <div class="divFormMng">
                <div>Description</div>
                <div>
                    <asp:TextBox ID="txtPermitDesc" runat="server" CssClass="textbox" MaxLength="200" ></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Province</div>
                <div>
                    <asp:TextBox ID="txtPermitProvince" runat="server" CssClass="textbox" MaxLength="100"></asp:TextBox>
                </div>
            </div>
            <div class="divFormMng">
                <div>Number</div>
                <div>
                    <asp:TextBox ID="txtPermitNumber" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                </div>
            </div>
                        <div class="divFormMng">
                <div>Expiry Date</div>
                <div>
                    <asp:TextBox ID="txtPermitExp" runat="server" CssClass="textbox" MaxLength="20"></asp:TextBox>
                </div>
            </div>
                  </div>
                 
                  <div>&nbsp;</div>
              <div style="align-items:center"> <asp:Button ID="btnAddPermitUpdate" runat="server" CssClass="button" Text="Save" />
                                                        &nbsp;
                                                        <asp:Button ID="btnAddPermitCancel" runat="server" CssClass="button" Text="Cancel" /></div>
              </div>

          </div>

           <div>
          <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderStyle="None" EmptyDataText="No Fire Arms Registered" Font-Size="Small" GridLines="Horizontal" Width="60%">
                                            <Columns>
                                                <asp:BoundField DataField="Permit_Description" HeaderText="Permit Description" />
                                                <asp:BoundField DataField="Province_State" HeaderText="Province/State" />
                                                <asp:BoundField DataField="Permit_No" HeaderText="Permit No" />
                                                <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" />
                                                <asp:ButtonField ButtonType="Image" Text="Edit" CommandName="Edit" ImageUrl="~/Images/Icons/edit.png">
                                                </asp:ButtonField>
                                                <asp:ButtonField ButtonType="Image" CommandName="Remove" ImageUrl="~/Images/Icons/trash.png" Text="Remove">
                                                
                                                </asp:ButtonField>
                                            </Columns>
                                        </asp:GridView>
      </div>



      </div>
         <div>&nbsp;</div>
      <div>
          <div class="yellowHeader">Associations</div>
          <div>
               <asp:GridView ID="GridView5" runat="server" AutoGenerateColumns="False" DataKeyNames="Association_Id" DataSourceID="SqlAssociation" GridLines="None">
                                            <Columns>
                                                <asp:BoundField DataField="Association_Id" InsertVisible="False" ReadOnly="True" SortExpression="Association_Id">
                                                <ItemStyle ForeColor="#494D50" />
                                                </asp:BoundField>
                                                <asp:BoundField DataField="Name" HeaderText="Association" SortExpression="Name" />
                                                <asp:TemplateField HeaderText="">
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="ChkAssociation" runat="server" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField HeaderText="Member No">
                                                    <ItemTemplate>
                                                        <asp:TextBox ID="txtAssociationMemberNo" runat="server" CssClass="textbox" MaxLength="50" Width="100px" />
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                        <asp:SqlDataSource ID="SqlAssociation" runat="server" ConnectionString="<%$ ConnectionStrings:MainConnection %>" SelectCommand="SELECT [Association_Id], [Name] FROM [tbl_Associations] WHERE Active = 'True' ORDER BY [Name]"></asp:SqlDataSource>
          </div>
      </div>
       <div>&nbsp;</div>
            <div style="text-align: right">
                <asp:Button ID="btnHuntPrev" runat="server" Text="Previous" CssClass="lineButton" />&nbsp;<asp:Button ID="btnSaveHunting" runat="server" Text="Save" CssClass="nextPrevButton" />&nbsp;<asp:Button ID="btnHuntNext" runat="server" Text="Next" CssClass="lineButton" />
            </div>
      <div>&nbsp;</div>
     


        </div>



       


          <div id="pnlMembershipFee" runat="server" class="divMainContainer" style="border-width: thin; border-color: #FFFF00; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;" visible="False">
            <div class="h1">Membership</div>
            <div>&nbsp;</div>
          
             <div style="align-items:flex-start">
                 <asp:Panel ID="Panel1" runat="server" BackColor="#F7F7F7" >
                                    <table style="width:100%;">
                                        <tr>
                                            <td style="font-weight: bold" class="auto-style6">Invoice</td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">Annual Membership fee (<asp:Label ID="lblMembershipPeriod" runat="server"></asp:Label>
                                                )</td>
                                            <td class="auto-style7">1</td>
                                            <td>
                                                <asp:Label ID="lblMembershipFee" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">
                                                <asp:Label ID="Label3" runat="server"></asp:Label>
                                            </td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td>
                                                <asp:Label ID="lblPaidAmount" runat="server"></asp:Label>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">&nbsp;</td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td>&nbsp;</td>
                                        </tr>
                                        <tr>
                                            <td class="auto-style6">Due</td>
                                            <td class="auto-style7">&nbsp;</td>
                                            <td>
                                               <asp:Label ID="lblDue" runat="server" Font-Bold="True"></asp:Label>
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
             </div>
           
            <div>&nbsp;</div>
           
              <div style="align-items:center">
                  
                  <div class="divFormMng">
                      <div><asp:Button ID="btnPayNow" runat="server" CssClass="button" Text="Pay Now" Visible="False" /></div>
                      <div>&nbsp;</div>
                  </div>
                   <div class="divFormMng">
                      <div>&nbsp;</div>
                      <div>&nbsp;</div>
                  </div>
                   <div class="divFormMng">
                      <div><asp:Button ID="btnPayLater" runat="server" CssClass="button" Text="Pay Later" Visible="False" />
                          <asp:Button ID="Button1" runat="server" Text="Register" />
                          <asp:Label ID="lblsubmitMsg" runat="server"></asp:Label>
                       </div>
                      <div style="display:none;">Limited functionailty</div>
                  </div>
   
              </div>

             <div>&nbsp;</div>
       
            <div style="text-align: right">
                <asp:Button ID="btnMembershipPrev" runat="server" Text="Previous" CssClass="lineButton" />
            </div>
        </div>

<div id="pnlUserDetails" runat="server" class="divMainContainer" style="border-width: thin; border-color: #FFFF00; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;" visible="False">
            <div class="h1">User Details</div>
            <div>&nbsp;</div>
          <div>
              We are ready to create your log in details!
          </div>
           <div>
               <asp:Label ID="lblLimitedFunction" runat="server"></asp:Label>
           </div>
           
            <div>&nbsp;</div>
           <div>
               Member Id
           </div>
    <div>
         <asp:Label ID="lblMemberId" runat="server"></asp:Label>
    </div>
<div>&nbsp;</div>
    <div>User Email</div>
    <div><asp:Label ID="lblUserName" runat="server"></asp:Label></div>
       <div>&nbsp;</div>
    <div>Please enter and confirm a password</div>
    <div>
         <asp:TextBox ID="txtPassword"  runat="server" CssClass="textbox" TextMode="Password"  MaxLength="20"></asp:TextBox>
    </div>
    <div>
         <asp:TextBox ID="txtPassword0" placeholder="Confirm Password" runat="server" CssClass="textbox" TextMode="Password"  MaxLength="20"></asp:TextBox>
    </div>
     <div>&nbsp;</div>
    <div><asp:Button ID="btnCreateUser" runat="server" CssClass="button" Text="Create User Profile" BackColor="#86B24F" BorderStyle="None" Font-Size="48px" ForeColor="White" /><asp:Label ID="lblUserMsg" runat="server"></asp:Label></div>
     <div>&nbsp;</div>
            <div style="text-align: right">
                <asp:Button ID="btnUserPrev" runat="server" Text="Previous" CssClass="lineButton" Visible="False" />
            </div>
        </div>
       

        <div class="divFormMng" style="border-width: thin; border-color: #FFFF00; vertical-align:top; border-top-style: solid; border-right-style: solid; border-left-style: inset; visibility: hidden;">
        <table font-size: small;">
                    
                    <tr>
                        <td class="h1">Form Management</td>
                        <td class="auto-style4">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td class="textbox">
                            
                            <asp:Button ID="lblProcessPersonal" runat="server" CssClass="lineButton" Text="1. Personal Information" />
                        </td>
                        <td class="auto-style5" >
                            <asp:Image ID="imgPersoCheck" runat="server" ImageUrl="~/Images/Icons/warning.png" />
                        </td>
                    </tr>
                    <tr>
                        <td  class="textbox">
                            <asp:Button ID="lblProcessMed" runat="server" CssClass="lineButton" Text="2. Medical Details" />
                        </td>
                        <td class="auto-style5">
                            <asp:Image ID="imgMediCheck" runat="server" ImageUrl="~/Images/Icons/warning.png" />
                        </td>
                    </tr>
                    <tr>
                        <td  class="textbox">
                            <asp:Button ID="lblProcessNextKin" runat="server" CssClass="lineButton" Text="3. Next of Kin"></asp:Button>
                        </td>
                        <td class="auto-style5">
                            <asp:Image ID="imgKinCheck" runat="server" ImageUrl="~/Images/Icons/warning.png" />
                        </td>
                    </tr>
                    <tr>
                        <td  class="textbox">
                            <asp:Button ID="lblProcessAddress" runat="server"  CssClass="lineButton" Text="4. Address"></asp:Button>
                        </td>
                        <td class="auto-style5">
                            <asp:Image ID="imgAddressCheck" runat="server" ImageUrl="~/Images/Icons/warning.png" />
                        </td>
                    </tr>
                    <tr>
                        <td  class="textbox">
                            <asp:Button ID="lblProcessHunting" runat="server"  CssClass="lineButton" Text="5. Hunting Details"></asp:Button>
                        </td>
                        <td class="auto-style5">
                            <asp:Image ID="imgHuntingCheck" runat="server" ImageUrl="~/Images/Icons/warning.png" />
                        </td>
                    </tr>
                    
                    <tr>
                        <td  class="textbox">
                            <asp:Button ID="lblProcessMembership" runat="server"   CssClass="lineButton"  Text="6. Membership Fee"></asp:Button>
                        </td>
                        <td class="auto-style5">
                            <asp:Image ID="Image6" runat="server" ImageUrl="~/Images/Icons/warning.png" />
                        </td>
                    </tr>
                   
                    <tr>
                        <td>&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="lblProcessMembership0" runat="server" CssClass="lineButton" Text="Manage Account" />
                        </td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                </table>
                                                      </div>
      </div> 
    <div> <asp:Label ID="lblId" runat="server" ForeColor="White" Text="8"></asp:Label></div>
          </ContentTemplate></asp:UpdatePanel>
    </form>
</body>
</html>
