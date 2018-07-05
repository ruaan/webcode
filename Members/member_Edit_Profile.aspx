<%@ Page Title="" Language="VB" MasterPageFile="~/MasterPageGreenLF.master" AutoEventWireup="false" CodeFile="member_Edit_Profile.aspx.vb" Inherits="Members_member_Edit_Profile" %>
<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" Runat="Server">
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
    </style>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
        <Triggers>
            <asp:PostBackTrigger ControlID="btnUpload" />
        </Triggers>
        <ContentTemplate>
        <div height="40px">&nbsp;</div>
    <div valign="top" style="clip: rect(0px, auto, auto, auto);">
        <div id="pnlPersonalDetails" runat="server" class="divMainContainer" style="border-width: thin; border-color: #000000; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;">
            <div class="h1">Personal Information</div>
            <div>&nbsp;</div>
            
            <div class="divFormMng">
                <div><asp:Image ID="Image1" runat="server" BorderColor="#3E432F" BorderStyle="Solid" BorderWidth="2px" Height="200px" Width="200px" /> </div>
                <div>&nbsp;</div>
                <div>Picture can not exceed 500kb and dimensions 200px height and 200px width</div>
                <div><asp:FileUpload ID="FileUpload1" runat="server" /></div>
                <div>&nbsp;</div>
                <div><asp:Button ID="btnUpload" runat="server" Text="Upload" CssClass="button" Width="80px" />&nbsp;<asp:Label ID="lblUploadMsg" runat="server" Text=""></asp:Label></div>
            </div>

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
                    <asp:TextBox ID="txtInitials" runat="server" CssClass="textbox" MaxLength="10" Width="49px"></asp:TextBox>
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
                        <asp:TextBox ID="txtWorkTel" runat="server" CssClass="textbox" MaxLength="14" Width="185px"></asp:TextBox>
                    </div>
                </div>
                <div style="vertical-align: bottom;" class="divFormMng">
                    <div>Home Telephone Number</div>
                    <div>
                        <asp:TextBox ID="txtWorkTel0" runat="server" CssClass="textbox" MaxLength="14" Width="155px"></asp:TextBox>
                    </div>
                </div>
            </div>
            <div>&nbsp;</div>
            <div>
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
                <asp:Label ID="lblMsgPersonal" runat="server" Text=""></asp:Label>
                &nbsp;<asp:Button ID="btnSavePersonal" runat="server" Text="Save" CssClass="button" />&nbsp;<asp:Button ID="btnPerNext" runat="server" Text="Next" CssClass="lineButton" />
            </div>
        </div>


        <div id="pnlMedical" runat="server" class="divMainContainer" style="border-width: thin; border-color: #000000; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;" visible="False">
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
                <asp:Label ID="lblMsgMedical" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnMedicalPrev" runat="server" Text="Previous" CssClass="lineButton" />&nbsp;<asp:Button ID="btnSaveMedical" runat="server" Text="Save" CssClass="button" />&nbsp;<asp:Button ID="btnMedicalNext" runat="server" Text="Next" CssClass="lineButton" />
            </div>
        </div>

          <div id="pnlNextofKin" runat="server" class="divMainContainer" style="border-width: thin; border-color: #000000; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;" visible="False">
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
              <div style="align-items:center"> <asp:Button ID="btnSaveAddNextKin" runat="server" CssClass="button" Text="Save" Width="80px" />
                                                        &nbsp;
                                                        <asp:Button ID="btnCancelAddNextKin" runat="server" CssClass="button" Text="Cancel" Width="80px" /></div>
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
                                                <asp:BoundField DataField="Surname">
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
                                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/edit.png" Text="Edit" CommandName="myEdit">
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
                <asp:Label ID="lblMsgKin" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnNextKinPrevious" runat="server" Text="Previous" CssClass="lineButton" />&nbsp;<asp:Button ID="btnSaveNextKin" runat="server" Text="Save" CssClass="button" />&nbsp;<asp:Button ID="btnNextKinNext" runat="server" Text="Next" CssClass="lineButton" />
            </div>
        </div>
    
        
        <div id="pnlAddress" runat="server" class="divMainContainer" style="border-width: thin; border-color: #000000; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;" visible="False">
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
                                        <asp:DropDownList ID="cmbHomeProvince" runat="server" DataTextField="Name" DataValueField="ProvinceId" CssClass="textbox">
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
                                        <asp:DropDownList ID="cmbWorkProvince" runat="server" DataTextField="Name" DataValueField="ProvinceId" CssClass="textbox">
                                        </asp:DropDownList>
                                        <asp:TextBox placeholder="Postal Code" ID="txtWorkPostal" runat="server"  CssClass="textbox" MaxLength="10" Width="107px"></asp:TextBox>
                </div>
            </div>
            <div>&nbsp;</div>




            <div style="text-align: right">
                <asp:Label ID="lblMsgAddress" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnAddressPrevious" runat="server" Text="Previous" CssClass="lineButton" />&nbsp;<asp:Button ID="btnSaveAddress" runat="server" Text="Save" CssClass="button" />&nbsp;<asp:Button ID="btnAddressNext" runat="server" Text="Next" CssClass="lineButton" />
            </div>
        </div>

  <div id="pnlHuntingDetails" runat="server" class="divMainContainer" style="border-width: thin; border-color: #000000; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid; background-color: #ffffff;" visible="False">
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
              <div><asp:Button ID="btnAddFireArm" runat="server" CssClass="button" Text="Add Firearm" Width="100px" /></div>
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
            <div class="divFormMng">
                <div>Expiry Date</div>
                <div>
                    <asp:TextBox ID="txtExpiryDate" runat="server" CssClass="textbox" MaxLength="50"></asp:TextBox>
                    <cc1:CalendarExtender ID="txtDateFrom_CalendarExtender" runat="server" BehaviorID="txtDateFrom_CalendarExtender" TodaysDateFormat="yyyy/MM/dd" TargetControlID="txtExpiryDate"></cc1:CalendarExtender>
                </div>
            </div>
                  </div>
                 
                  <div>&nbsp;</div>
              <div style="align-items:center"> <asp:Button ID="btnAddFireArmUpdate" runat="server" CssClass="button" Text="Save" Width="80px" />
                                                        &nbsp;
                                                        <asp:Button ID="btnAddFireArmCancel" runat="server" CssClass="button" Text="Cancel" Width="80px" /></div>
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
                                                <asp:BoundField DataField="ExpiryDate" DataFormatString="{0:yyyy/MM/dd}" HeaderText="Expiry Date">
                                                <HeaderStyle HorizontalAlign="Left" />
                                                <ItemStyle HorizontalAlign="Left" />
                                                </asp:BoundField>
                                                <asp:ButtonField ButtonType="Image" ImageUrl="~/Images/Icons/edit.png" CommandName="myEdit" Text="Edit">
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
              <div><asp:Button ID="btnAddPermit" runat="server" CssClass="button" Text="Add Permit" Width="100px" /></div>
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
              <div style="align-items:center"> <asp:Button ID="btnAddPermitUpdate" runat="server" CssClass="button" Text="Save" Width="80px" />
                                                        &nbsp;
                                                        <asp:Button ID="btnAddPermitCancel" runat="server" CssClass="button" Text="Cancel" Width="80px" /></div>
              </div>

          </div>

           <div>
          <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BorderStyle="None" EmptyDataText="No Fire Arms Registered" Font-Size="Small" GridLines="Horizontal" Width="60%">
                                            <Columns>
                                                <asp:BoundField DataField="Permit_Description" HeaderText="Permit Description" />
                                                <asp:BoundField DataField="Province_State" HeaderText="Province/State" />
                                                <asp:BoundField DataField="Permit_No" HeaderText="Permit No" />
                                                <asp:BoundField DataField="ExpiryDate" HeaderText="Expiry Date" />
                                                <asp:ButtonField ButtonType="Image" Text="Edit" CommandName="myEdit" ImageUrl="~/Images/Icons/edit.png">
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
                <asp:Label ID="lblMsgHunting" runat="server" Text=""></asp:Label>
                <asp:Button ID="btnHuntPrev" runat="server" Text="Previous" CssClass="lineButton" />&nbsp;<asp:Button ID="btnSaveHunting" runat="server" Text="Save" CssClass="button" />&nbsp;
            </div>
      <div>&nbsp;</div>   
        </div>


        <div id="DivPassword" runat="server" class="divMainContainer" style="border-width: thin; border-color: #000000; padding: 7px 5px 5px 5px; border-bottom-style: solid; border-left-style: solid;" visible="False">
            <div class="h1">Change Password</div>
            <div>&nbsp;</div>
          <div>Old Password: <asp:TextBox ID="txtOldPassword" runat="server" TextMode="Password"></asp:TextBox></div>
       
            <div>&nbsp;</div>
           <div>New Password: <asp:TextBox ID="txtnewPassword" runat="server" TextMode="Password"></asp:TextBox></div>
            <div>&nbsp;</div>
      <div>Confirm Password: <asp:TextBox ID="txtConfirmPassword" runat="server" TextMode="Password"></asp:TextBox></div>
          
            <div style="text-align: right">
                <asp:Label ID="lblPassword" runat="server"></asp:Label>
                &nbsp;<asp:Button ID="btnPasswordSave" runat="server" Text="Save" CssClass="button" />&nbsp;</div>
        </div>  


       

        <div class="divFormMng" style="border-width: thin; border-color: #000000; vertical-align:top; border-top-style: solid; border-right-style: solid; border-left-style: inset; border-bottom-style: solid;">
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
                        <td>&nbsp;</td>
                        <td class="auto-style5">&nbsp;</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Button ID="Button1" runat="server" CssClass="lineButton" Text="Change Password " />
                        </td>
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
    <div> <asp:Label ID="lblId" runat="server" ForeColor="#ffffff" Text=""></asp:Label></div>
          </ContentTemplate></asp:UpdatePanel>
</asp:Content>



