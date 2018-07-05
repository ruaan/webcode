Imports System.Data
Partial Class farm_view_app
    Inherits System.Web.UI.Page
    Dim dsInfo As DataSet

    Protected Sub Page_Load(sender As Object, e As EventArgs) Handles Me.Load

        Try
            HiddenFarmId.Value = Request.QueryString("id")

            GetinitialData()
            LoadPhotos()
            GetPricing()
            PlaceHolder1.Controls.Add(New LiteralControl(GetGeninfo))
            PlaceHolder2.Controls.Add(New LiteralControl(GetTerms))
            PlaceHolder3.Controls.Add(New LiteralControl(GetAnimals))
            PlaceHolder4.Controls.Add(New LiteralControl(GetReviews))
            PlaceHolder5.Controls.Add(New LiteralControl(GetGallery))


            Dim rating() As String = GetRating(HiddenFarmId.Value)
            If rating(0) > 0 Then
                lblRating.Text = "( " & rating(0) & " )"
            Else
                lblRating.Text = ""
            End If

            If rating(1) = "1" Then
                Image14.Visible = True
            ElseIf rating(1) = "2" Then
                Image14.Visible = True
                Image13.Visible = True
            ElseIf rating(1) = "3" Then
                Image14.Visible = True
                Image13.Visible = True
                Image12.Visible = True
            ElseIf rating(1) = "4" Then
                Image14.Visible = True
                Image13.Visible = True
                Image12.Visible = True
                Image11.Visible = True
            ElseIf rating(1) = "5" Then
                Image14.Visible = True
                Image13.Visible = True
                Image12.Visible = True
                Image11.Visible = True
                Image10.Visible = True
            End If



        Catch ex As Exception
            Response.Redirect("FarmsApp.aspx")
        End Try


        btnFarmDescription.OnClientClick = "javascript:window.history.go(-1);return false;"

    End Sub


    Private Function GetGeninfo() As String
        Dim htmlString As String = ""

        htmlString &= "  <div id='divInfo'>"

        htmlString &= "                     <div id='infoBlock'  class='div_infoBlock'>"
        htmlString &= "                          <div id='div_info_Terms'>"
        htmlString &= "                         <div>&nbsp;</div>"
        Try
            If dsInfo.Tables(0).Rows.Count = 0 Then
                GetGenInfoData()
            End If
        Catch ex As Exception
            GetGenInfoData()
        End Try

        Try
            htmlString &= "                         <div Style='padding-left:10px'>"
            Dim longText As String = dsInfo.Tables(0).Rows(0).Item("Long_Description").ToString.Trim
            If longText = "" Then
                longText = dsInfo.Tables(0).Rows(0).Item("Short_Description").ToString.Trim
            End If
            longText = longText.Replace("" & vbCrLf & vbCrLf & "", "</br></br>")
            htmlString &= longText
            htmlString &= "                         </div>"
        Catch ex As Exception

        End Try

        Dim dsHunting As New DataSet
        dsHunting = GetHuntingData()
        Dim dsItems As New DataSet

        Dim LScount, LSsp As Integer


        htmlString &= "  <div>&nbsp;</div>"
        htmlString &= "      <div>"


        LScount = dsHunting.Tables(0).Rows.Count - 1

        If LScount > -1 Then



            '//// Hunting Types
            htmlString &= "          <div style='border-top-style: solid; border-width: thin; border-color: #333333;  padding-left: 10px;'>" 'a
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "              <div>"
            htmlString &= "                  <div  style='font-weight: bold'>"
            htmlString &= "                      Hunting Types"
            htmlString &= "                  </div>"
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "                  <div style='display: inline-block;'>"


            For LSsp = 0 To LScount

                htmlString &= "                      <div style='align-items: center;  padding-left: 10px;'>" '1
                htmlString &= "                          <div style='display: inline-block; vertical-align: middle'>" '2
                htmlString &= "                              <img alt='' src='Images/Icons/Farm_Search/HuntType/" & dsHunting.Tables(0).Rows(LSsp).Item("IconPath").ToString.Trim & "' />"
                htmlString &= "                          </div>" '2
                htmlString &= "                          <div style='display: inline-block; padding-left: 10px;'>" & dsHunting.Tables(0).Rows(LSsp).Item("Type").ToString.Trim & "</div>"
                htmlString &= "                      </div>" '1

            Next



            htmlString &= "                  </div>"
            htmlString &= "              </div>"
            htmlString &= "          </div>"
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "      <div>&nbsp;</div>"


        End If

        '//// Facilities

        dsItems = GetFacilityData()
        LScount = dsItems.Tables(0).Rows.Count - 1

        If LScount > -1 Then



            htmlString &= "      <div>"
            htmlString &= "          <div style='border-top-style: solid; border-width: thin; border-color: #333333;  padding-left: 10px;'>"
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "              <div>"
            htmlString &= "                  <div   style='font-weight: bold'>"
            htmlString &= "                      Facilities"
            htmlString &= "  "
            htmlString &= "                  </div>"
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "                  <div style='display: inline-block;'>"


            For LSsp = 0 To LScount

                htmlString &= "                      <div style='align-items: center;  padding-left: 10px;'>" '1
                htmlString &= "                          <div style='display: inline-block; vertical-align: middle'>" '2
                htmlString &= "                              <img alt='' src='Images/Icons/Farm_Search/HuntType/" & dsItems.Tables(0).Rows(LSsp).Item("IconPath").ToString.Trim & "' />"
                htmlString &= "                          </div>" '2
                htmlString &= "                          <div style='display: inline-block; padding-left: 10px;'>" & dsItems.Tables(0).Rows(LSsp).Item("Type").ToString.Trim & "</div>"
                htmlString &= "                      </div>" '1

            Next



            htmlString &= "                  </div>"
            htmlString &= "              </div>"
            htmlString &= "          </div>"
            htmlString &= "      </div>"
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "      <div>&nbsp;</div>"


        End If

        '////Additional Services


        dsItems = GetAdditionalServiceData()
        LScount = dsItems.Tables(0).Rows.Count - 1

        If LScount > -1 Then



            htmlString &= "      <div>"
            htmlString &= "          <div style='border-top-style: solid; border-width: thin; border-color: #333333;  padding-left: 10px;'>"
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "              <div>"
            htmlString &= "                  <div   style='font-weight: bold'>"
            htmlString &= "                      Additional Services"
            htmlString &= "  "
            htmlString &= "                  </div>"
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "                  <div style='display: inline-block;'>"
            For LSsp = 0 To LScount


                htmlString &= "                      <div style='align-items: center'>"
                htmlString &= "                          <div style='display: inline-block; vertical-align: middle'>"
                htmlString &= "                              <img alt='' src='' />"
                htmlString &= "                          </div>"
                htmlString &= "                          <div style='display: inline-block; padding-left: 10px;'>"
                htmlString &= "                              <div style='display: inline-block; padding-left: 10px;'>"
                htmlString &= dsItems.Tables(0).Rows(LSsp).Item("Type").ToString.Trim

                If dsItems.Tables(0).Rows(LSsp).Item("Chargeable").ToString.Trim = "True" Then
                    htmlString &= " <div>"
                    htmlString &= dsItems.Tables(0).Rows(LSsp).Item("Price").ToString.Trim & " Per " & dsItems.Tables(0).Rows(LSsp).Item("Unit").ToString.Trim
                    htmlString &= " </div>"
                End If


                htmlString &= "                              </div>"
                htmlString &= "                          </div>"
                htmlString &= "                      </div>"
                htmlString &= "  "

                htmlString &= "      <div>&nbsp;</div>"
            Next
            htmlString &= "                  </div>"
            htmlString &= "              </div>"
            htmlString &= "          </div>"
            htmlString &= "      </div>"
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "      <div>&nbsp;</div>"


        End If



        '/////Hunting Months

        dsItems = GetHuntingMonthData()
        LScount = dsItems.Tables(0).Rows.Count - 1

        Dim columnCount As Integer = dsItems.Tables(0).Rows.Count
        columnCount = columnCount / 2

        Dim Column1 As String = ""
        Dim Column2 As String = ""

        For LSsp = 0 To columnCount - 1

            Column1 &= "                      <div style='align-items: center'>"
            Column1 &= "                          <div style='display: inline-block; vertical-align: middle'>"
            Column1 &= "                              <img alt='' src='' />"
            Column1 &= "                          </div>"
            Column1 &= "                          <div style='display: inline-block; padding-left: 10px;'>"
            Column1 &= dsItems.Tables(0).Rows(LSsp).Item("HuntingMonth").ToString.Trim
            Column1 &= "                          </div>"
            Column1 &= "                      </div>"
        Next

        For LSsp = columnCount To LScount

            Column2 &= "                      <div style='align-items: center'>" '1
            Column2 &= "                          <div style='display: inline-block; vertical-align: middle'>" '2
            Column2 &= "                              <img alt='' src='' />"
            Column2 &= "                          </div>" '2
            Column2 &= "                          <div style='display: inline-block; padding-left: 10px;'>" '3
            Column2 &= dsItems.Tables(0).Rows(LSsp).Item("HuntingMonth").ToString.Trim
            Column2 &= "                          </div>" '3
            Column2 &= "                      </div>" '1
        Next

        If LScount > -1 Then



            htmlString &= "      <div>" '1
            htmlString &= "          <div style='border-top-style: solid; border-width: thin; border-color: #333333;  padding-left: 10px;'>" '2
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "              </div>" '2
            htmlString &= "                  <div   style='font-weight: bold;  padding-left: 10px;'>" '3
            htmlString &= "                      Hunting Months"
            htmlString &= "                  </div>" '3
            htmlString &= "              <div>&nbsp;</div>"

            htmlString &= "                  <div style='display: inline-block;'>" '4

            htmlString &= Column1
            htmlString &= "                  </div>" '4
            htmlString &= "                  <div style='display: inline-block;' class='auto-style2'>" '5
            htmlString &= "                      &nbsp;"
            htmlString &= "                  </div>" '5


            htmlString &= "                  <div style='display: inline-block;'>" '6



            htmlString &= Column2

            htmlString &= "                  </div>" '6
            htmlString &= "      </div>" '1
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "      <div>&nbsp;</div>"


        End If



        '///Eco Tourism\\\

        dsItems = GetEcoTourismData()
        LScount = dsItems.Tables(0).Rows.Count - 1

        If LScount > -1 Then



            htmlString &= "      <div>"
            htmlString &= "          <div style='border-top-style: solid; border-width: thin; border-color: #333333;  padding-left: 10px;'>"
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "              <div>"
            htmlString &= "                  <div   style='font-weight: bold'>"
            htmlString &= "                      Eco Tourism"
            htmlString &= "  "
            htmlString &= "                  </div>"
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "                  <div style='display: inline-block;'>"



            For LSsp = 0 To LScount

                htmlString &= "                      <div style='align-items: center;  padding-left: 10px;'>" '1
                htmlString &= "                          <div style='display: inline-block; vertical-align: middle'>" '2
                htmlString &= "                              <img alt='' src='Images/Icons/Farm_Search/HuntType/" & dsItems.Tables(0).Rows(LSsp).Item("IconPath").ToString.Trim & "' />"
                htmlString &= "                          </div>" '2
                htmlString &= "                          <div style='display: inline-block; padding-left: 10px;'>" & dsItems.Tables(0).Rows(LSsp).Item("Type").ToString.Trim & "</div>"
                htmlString &= "                      </div>" '1

            Next


            htmlString &= "  "
            htmlString &= "                  </div>"
            htmlString &= "              </div>"
            htmlString &= "          </div>"
            htmlString &= "      </div>"
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "      <div>&nbsp;</div>"

        End If

        '///Territory\\\

        dsItems = GetTerrainData()

        LScount = dsItems.Tables(0).Rows.Count - 1

        If LScount > -1 Then


            htmlString &= "      <div>"
            htmlString &= "          <div style='border-top-style: solid; border-width: thin; border-color: #333333;  padding-left: 10px;'>"
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "              </div>"
            htmlString &= "                  <div   style='font-weight: bold'>"
            htmlString &= "                      Territory"
            htmlString &= "                  </div>"
            htmlString &= "              <div>&nbsp;</div>"
            htmlString &= "                  <div style='display: inline-block'>"
            htmlString &= "                      <div style='display: inline-block;'>"
            htmlString &= "                          <div style='align-items: center'>"
            htmlString &= "                              <div style='display: inline-block; vertical-align: middle'>"
            htmlString &= "                                  <img alt='' src='' />"
            htmlString &= "                              </div>"
            htmlString &= "                              <div style='display: inline-block; padding-left: 10px;'>"
            htmlString &= "                                  <div style='display: inline-block; padding-left: 10px;'>"
            htmlString &= "                                      Area within game fencing<div style='text-align: center'>" & dsItems.Tables(0).Rows(0).Item("Hectares_withing_Gamingfence").ToString.Trim & " Hectares</div>"
            htmlString &= "                                  </div>"
            htmlString &= "                              </div>"
            htmlString &= "                          </div>"
            htmlString &= "  "
            htmlString &= "                      </div>"
            htmlString &= "  "
            htmlString &= "  "
            htmlString &= "                      <div style='display: inline-block; padding-left: 20px;'>"
            htmlString &= "                          <div style='align-items: center'>"
            htmlString &= "                              <div style='display: inline-block; vertical-align: middle'>"
            htmlString &= "                                  <img alt='' src='' />"
            htmlString &= "                              </div>"
            htmlString &= "                              <div style='display: inline-block; padding-left: 10px;'>"
            htmlString &= "                                  <div style='display: inline-block; padding-left: 10px;'>"
            htmlString &= "                                      Savannah<div style='text-align: center'>" & dsItems.Tables(0).Rows(0).Item("Savannah_Perc").ToString.Trim & "%</div>"
            htmlString &= "                                  </div>"
            htmlString &= "                              </div>"
            htmlString &= "                          </div>"
            htmlString &= "  "
            htmlString &= "                      </div>"
            htmlString &= "  "
            htmlString &= "                      <div style='display: inline-block; padding-left: 20px;'>"
            htmlString &= "                          <div style='align-items: center'>"
            htmlString &= "                              <div style='display: inline-block; vertical-align: middle'>"
            htmlString &= "                                  <img alt='' src='' />"
            htmlString &= "                              </div>"
            htmlString &= "                              <div style='display: inline-block; padding-left: 10px;'>"
            htmlString &= "                                  <div style='display: inline-block; padding-left: 10px;'>"
            htmlString &= "                                      Mountains & Hills<div style='text-align: center'>" & dsItems.Tables(0).Rows(0).Item("Mountains_Hills_Perc").ToString.Trim & "%</div>"
            htmlString &= "                                  </div>"
            htmlString &= "                              </div>"
            htmlString &= "                          </div>"
            htmlString &= "  "
            htmlString &= "                      </div>"
            htmlString &= "                      <div>&nbsp;</div>"


            If dsItems.Tables(0).Rows(0).Item("Rivers").ToString.Trim = "True" Then
                htmlString &= "                      <div style='display: inline-block;'>" '1
                htmlString &= "                          <div style='align-items: center'>"
                htmlString &= "                              <div style='display: inline-block; vertical-align: middle'>"
                htmlString &= "                                  <img alt='' src='' />"
                htmlString &= "                              </div>"
                htmlString &= "                              <div style='display: inline-block; padding-left: 10px;'>"
                htmlString &= "                                  <div style='display: inline-block; padding-left: 10px;'>Rivers</div>"
                htmlString &= "                              </div>"
                htmlString &= "                          </div>"
                htmlString &= "                      </div>"
            End If




            If dsItems.Tables(0).Rows(0).Item("Natural_Lakes").ToString.Trim = "True" Then
                htmlString &= "  "
                htmlString &= "  "
                htmlString &= "                      <div style='display: inline-block; padding-left: 20px;'>"
                htmlString &= "                          <div style='align-items: center'>"
                htmlString &= "                              <div style='display: inline-block; vertical-align: middle'>"
                htmlString &= "                                  <img alt='' src='' />"
                htmlString &= "                              </div>"
                htmlString &= "                              <div style='display: inline-block; padding-left: 10px;'>"
                htmlString &= "                                  <div style='display: inline-block; padding-left: 10px;'>Natural Lakes</div>"
                htmlString &= "                              </div>"
                htmlString &= "                          </div>"
                htmlString &= "                      </div>"
                htmlString &= "  "
            End If




            If dsItems.Tables(0).Rows(0).Item("Dam").ToString.Trim = "True" Then
                htmlString &= "                      <div style='display: inline-block; padding-left: 20px;'>"
                htmlString &= "                          <div style='align-items: center'>"
                htmlString &= "                              <div style='display: inline-block; vertical-align: middle'>"
                htmlString &= "                                  <img alt='' src='' />"
                htmlString &= "                              </div>"
                htmlString &= "                              <div style='display: inline-block; padding-left: 10px;'>"
                htmlString &= "                                  <div style='display: inline-block; padding-left: 10px;'>Dam</div>"
                htmlString &= "                              </div>"
                htmlString &= "                          </div>"
                htmlString &= "  "
                htmlString &= "                      </div>"
                htmlString &= "  "
            End If


            htmlString &= "                  </div>"
            htmlString &= "  "
            htmlString &= "              </div>"

        End If


        htmlString &= "      </div>"
        htmlString &= "                     </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"


        Return htmlString

    End Function
    Private Function GetTerms() As String
        Dim htmlString As String = ""

        htmlString &= "  <div id='divInfo'>"


        htmlString &= "                     <div id='infoBlock'  class='div_infoBlock'>"
        htmlString &= "                          <div id='div_info_Terms'>"
        htmlString &= "                         <div>&nbsp;</div>"

        Dim dsTerms As New DataSet
        dsTerms = GetTermsData()
        Dim count As Integer = dsTerms.Tables(0).Rows.Count - 1
        Dim sp As Integer

        Dim itemName As String = ""
        htmlString &= "<div>"
        For sp = 0 To count
            If itemName <> dsTerms.Tables(0).Rows(sp).Item("TermsItem").ToString.Trim Then
                If sp <> 0 Then

                    htmlString &= "<div>&nbsp;</div>"
                End If

                htmlString &= "<div><strong>"

                htmlString &= dsTerms.Tables(0).Rows(sp).Item("TermsItem").ToString.Trim
                itemName = dsTerms.Tables(0).Rows(sp).Item("TermsItem").ToString.Trim
                htmlString &= "</strong></div>"
                htmlString &= "              <div>&nbsp;</div>"
            End If
            htmlString &= "<div>"
            htmlString &= dsTerms.Tables(0).Rows(sp).Item("Item").ToString.Trim
            htmlString &= "</div>"

        Next
        htmlString &= "</div>"
        htmlString &= "</div>"
        htmlString &= "</div>"
        htmlString &= "</div>"


        Return htmlString

    End Function
    Private Function GetAnimals() As String
        Dim htmlString As String = ""

        htmlString &= "  <div id='divInfo'>"
        htmlString &= "                     <asp:HiddenField ID='HiddenType' runat='server' />"

        htmlString &= "                     <div id='infoBlock'  class='div_infoBlock'>"
        htmlString &= "                          <div id='div_info_Terms'>"
        htmlString &= "                         <div>&nbsp;</div>"
        Dim dsTerms As New DataSet
        dsTerms = GetAnimalData()
        Dim count As Integer = dsTerms.Tables(0).Rows.Count - 1
        Dim sp As Integer

        Dim itemName As String = ""

        For sp = 0 To count
            htmlString &= " <div>&nbsp;</div>"
            htmlString &= "     <div style='background-color: #F8F8F8; border: 1px solid #333333; width:98%' onclick=""location.href ='Animal_View_App.aspx?animalId=" & dsTerms.Tables(0).Rows(sp).Item("AnimalId").ToString.Trim & "'"" >"
            htmlString &= "         <div style='padding: 10px; display: inline-block'>"
            htmlString &= "             <img alt='' src='Images/Animals/" & dsTerms.Tables(0).Rows(sp).Item("AnimalId").ToString.Trim & "Front.jpg' class='Animal_Pic' />"
            htmlString &= "         </div>"
            htmlString &= "         <div style='padding: 10px; display: inline-block; vertical-align: top; color: #333333;'>"
            htmlString &= "             <div style='font-size: large; font-weight: bold;'>"
            htmlString &= dsTerms.Tables(0).Rows(sp).Item("Name").ToString.Trim
            htmlString &= "   </div>"
            htmlString &= "         </div>"
            htmlString &= "     </div>"
        Next
        htmlString &= "                     </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"

        Return htmlString

    End Function
    Private Function GetGallery() As String
        Dim htmlString As String = ""
        Dim getAlbum As New AlbumViewer

        Dim AlbumString As String = ""
        AlbumString = getAlbum.GetAlbum("Farm", HiddenFarmId.Value.Trim)
        htmlString &= "  <div id='divInfo'>"
        htmlString &= "                     <asp:HiddenField ID='HiddenType' runat='server' />"

        htmlString &= "                     <div id='infoBlock'  class='div_infoBlock'>"
        htmlString &= "                          <div id='div_info_Terms'>"
        htmlString &= "                         <div>&nbsp;</div>"
        htmlString &= AlbumString
        htmlString &= "                     </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"


        Return htmlString

    End Function

    Private Function GetReviews() As String
        Dim htmlString As String = ""

        Dim DsReview As New DataSet
        DsReview = GetReviewdata()

        Dim count As Integer = DsReview.Tables(0).Rows.Count - 1
        Dim sp As Integer



        htmlString &= "  <div id='divInfo'>"
        htmlString &= "                     <asp:HiddenField ID='HiddenType' runat='server' />"
        htmlString &= "                     <div id='infoBlock'  class='div_infoBlock'>"
        htmlString &= "                          <div id='div_info_Terms'>"
        htmlString &= "                         <div>&nbsp;</div>"

        If count < 1 Then
            htmlString &= "No Reviews..."
        Else
            For sp = 0 To count
                htmlString &= " <div style='font-family: Calibri; font-size: large; color: #333333'>"
                htmlString &= "             <div>"
                htmlString &= DsReview.Tables(0).Rows(sp).Item("Review").ToString.Trim
                htmlString &= "   </div>"
                htmlString &= "             <div style='color: #666666; font-size: medium;border-width: thin; border-color: #808080; color: #666666; border-bottom-style: solid;'>"
                htmlString &= "                 <div style='display:inline-block;'>"
                htmlString &= DsReview.Tables(0).Rows(sp).Item("thisName").ToString.Trim
                htmlString &= "                 </div>"
                htmlString &= "                 <div style='display:inline-block; padding-left: 20px;'>"
                htmlString &= CDate(DsReview.Tables(0).Rows(sp).Item("Date").ToString.Trim).ToString("dd/MM/yyyy")
                htmlString &= "                 </div>"
                htmlString &= "             </div>"
                htmlString &= " </div>"
                htmlString &= "<div>&nbsp;</div>"
            Next
        End If

        htmlString &= "                     </div>"
        htmlString &= "                     </div>"
        htmlString &= "                 </div>"


        Return htmlString

    End Function




    Private Function GetGenInfoData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT        id, FarmName, Country, Province, ClosestTown, GPS_Longitude, GPS_Latitude, Short_Description, Long_Description, TelNo, CellNo, Email, CompanyName, CompanyRegNo, UseBookingSystem, BookingContactName, "
        str &= "                          BookingContactSurname, BookingEmail, BookingCell, OwnerName, OwnerSurname, OwnerTitle, OwnerInitials, OwnerPreferredNAme, OwnerIdNo, OwnerGender, OwnerNationality, OwnerPassportNo, OwnerEmail, "
        str &= "                          Owner_Res_StreetName, Owner_Res_StreetNo, Owner_Res_ComplexName, Owner_Res_ComplexNo, Owner_Res_Suburb, Owner_Res_Province, Owner_Res_PostalCode, Status"
        str &= " FROM            tbl_Farm"
        str &= " WHERE        (id = @id)"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        dsInfo = ds

        Return ds
    End Function
    Private Function GetReviewdata() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= "  SELECT        dbo.tbl_Farm_Reviews.id, dbo.tbl_Farm_Reviews.FarmId, dbo.tbl_Farm_Reviews.MemberId, dbo.tbl_Farm_Reviews.Date, dbo.tbl_Farm_Reviews.RatingId, dbo.tbl_Farm_Reviews.Review, "
        str &= "                           dbo.tbl_Member.PreferredName + ' ' + dbo.tbl_Member.Surname AS thisName"
        str &= "  FROM            dbo.tbl_Farm_Reviews INNER JOIN"
        str &= "                           dbo.tbl_Member ON dbo.tbl_Farm_Reviews.MemberId = dbo.tbl_Member.MemberId"
        str &= "  WHERE        (dbo.tbl_Farm_Reviews.FarmId = @FarmId)"
        str &= "  ORDER BY dbo.tbl_Farm_Reviews.Date DESC"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try


        Return ds

    End Function
    Private Function GetTermsData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Farmid", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT        id, FarmId, itemOrder, TermsItem, Line, Item"
        str &= " FROM            tbl_Farm_Terms"
        str &= " WHERE        (FarmId = @Farmid)"
        str &= " ORDER BY itemOrder, Line"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        dsInfo = ds

        Return ds
    End Function

    Private Function GetTerrainData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Farmid", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= "  SELECT        id, FarmId, Hectares_withing_Gamingfence, Savannah_Perc, Mountains_Hills_Perc, Rivers, Natural_Lakes, Dam"
        str &= "  FROM            tbl_Farm_Terrain"
        str &= " WHERE (FarmId = @FarmId)"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        dsInfo = ds

        Return ds
    End Function
    Private Function GetHuntingMonthData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Farmid", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT HuntingMonth"
        str &= " FROM tbl_Farm_HuntingMonths"
        str &= " WHERE (FarmId = @FarmId)"
        str &= " ORDER BY HuntingMonthInteger"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        dsInfo = ds

        Return ds
    End Function

    Private Function GetEcoTourismData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Farmid", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= "  SELECT        tbl_EcoTourism_Types.Eco_Tourism AS Type, tbl_EcoTourism_Types.IconPath"
        str &= " FROM            tbl_Farm_EcoTourism_Types INNER JOIN"
        str &= "                     tbl_EcoTourism_Types ON tbl_Farm_EcoTourism_Types.EcoTourism_Id = tbl_EcoTourism_Types.id"
        str &= " WHERE (FarmId = @FarmId)"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        dsInfo = ds

        Return ds
    End Function
    Private Function GetFacilityData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Farmid", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT        tbl_Facility_Types.FacilityType AS Type, tbl_Facility_Types.IconPath"
        str &= " FROM            tbl_Farm_Facilities INNER JOIN"
        str &= "                          tbl_Facility_Types ON tbl_Farm_Facilities.FacilityId = tbl_Facility_Types.id"
        str &= " WHERE        (tbl_Farm_Facilities.FarmId = @FarmId)"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        dsInfo = ds

        Return ds
    End Function

    Private Function GetAdditionalServiceData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Farmid", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT  ExtraServiceDescription AS Type, Chargeable, Price, Unit"
        str &= " FROM tbl_Farm_ExtraService"
        str &= "  WHERE (FarmId = @Farmid)"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        dsInfo = ds

        Return ds
    End Function
    Private Function GetHuntingData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Farmid", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT        tbl_Hunting_Types.HuntingType AS Type, tbl_Hunting_Types.IconPath AS IconPath"
        str &= " FROM            tbl_Farm_Hunting_Types INNER JOIN"
        str &= "                          tbl_Hunting_Types ON tbl_Farm_Hunting_Types.Hunting_Type_Id = tbl_Hunting_Types.id"
        str &= " WHERE        (tbl_Farm_Hunting_Types.FarmId = @FarmId)"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        dsInfo = ds

        Return ds
    End Function

    Private Function GetAnimalData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Farmid", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT        tbl_Farm_Animal.id, tbl_Farm_Animal.FarmId, tbl_Farm_Animal.AnimalId, tbl_Farm_Animal.AvailableToHunt, tbl_Farm_Animal.Male_Price, tbl_Farm_Animal.Female_Price, tbl_Farm_Animal.Trophy_Price, "
        str &= "                          tbl_Farm_Animal.Inches, tbl_Farm_Animal.Visiting_Country, tbl_Farm_Animal.Active, tbl_Animals.Name, tbl_Animals.Comments"
        str &= " FROM            tbl_Farm_Animal INNER JOIN"
        str &= "                          tbl_Animals ON tbl_Farm_Animal.AnimalId = tbl_Animals.id"
        str &= " WHERE        (tbl_Farm_Animal.FarmId = @Farmid) AND (Visiting_Country = '1')"
        str &= " ORDER BY tbl_Animals.Name"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        dsInfo = ds

        Return ds
    End Function
    Private Function GetinitialData() As DataSet
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@id", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT        id, FarmName, Country, Province, ClosestTown, GPS_Longitude, GPS_Latitude, Short_Description, Long_Description, TelNo, CellNo, Email, CompanyName, CompanyRegNo, UseBookingSystem, BookingContactName, "
        str &= "                          BookingContactSurname, BookingEmail, BookingCell, OwnerName, OwnerSurname, OwnerTitle, OwnerInitials, OwnerPreferredNAme, OwnerIdNo, OwnerGender, OwnerNationality, OwnerPassportNo, OwnerEmail, "
        str &= "                          Owner_Res_StreetName, Owner_Res_StreetNo, Owner_Res_ComplexName, Owner_Res_ComplexNo, Owner_Res_Suburb, Owner_Res_Province, Owner_Res_PostalCode, Status"
        str &= " FROM            tbl_Farm"
        str &= " WHERE        (id = @id)"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        lblHeading.Text = ds.Tables(0).Rows(0).Item("FarmName").ToString.Trim
        HiddenLatitude.Value = ds.Tables(0).Rows(0).Item("GPS_Latitude").ToString.Trim
        HiddenLongitude.Value = ds.Tables(0).Rows(0).Item("GPS_Longitude").ToString.Trim

        dsInfo = ds

        Return ds
    End Function

    Private Sub LoadPhotos()


        Dim SavePath As String = ""
        Dim pathname As String = "Farms\Images\FarmProfiles\"
        Dim pathnameRoot As String
        pathnameRoot = Server.MapPath(pathname)
        SavePath = pathnameRoot


        If System.IO.File.Exists(SavePath & HiddenFarmId.Value.Trim & "Main.jpg") Then
            Image1.ImageUrl = "~/Farms/Images/FarmProfiles/" & HiddenFarmId.Value.Trim & "Main.jpg"
        Else
            Image1.ImageUrl = "~/Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & HiddenFarmId.Value.Trim & "SideTop.jpg") Then
            Image2.ImageUrl = "~/Farms/Images/FarmProfiles/" & HiddenFarmId.Value.Trim & "SideTop.jpg"
        Else
            Image2.ImageUrl = "~/Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & HiddenFarmId.Value.Trim & "SideMiddel.jpg") Then
            Image3.ImageUrl = "~/Farms/Images/FarmProfiles/" & HiddenFarmId.Value.Trim & "SideMiddel.jpg"
        Else
            Image3.ImageUrl = "~/Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg"
        End If
        If System.IO.File.Exists(SavePath & HiddenFarmId.Value.Trim & "SideBottom.jpg") Then
            Image4.ImageUrl = "~/Farms/Images/FarmProfiles/" & HiddenFarmId.Value.Trim & "SideBottom.jpg"
        Else
            Image4.ImageUrl = "~/Farms/Images/FarmProfiles/ProfilePlaceHolder.jpg"
        End If

    End Sub
    Private Function GetRating(FarmId As String) As String()

        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@FarmId", FarmId.Trim)

        Dim str As String = ""
        str &= " SELECT COUNT(id) AS COUNT, SUM(Rating) AS Rating, SUM(Rating) / COUNT(id) AS AvgRate, SUM(Rating) / COUNT(id) / 2 AS stars"
        str &= " FROM tbl_Farm_Rating"
        str &= " WHERE (FarmId = @FarmId)"

        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")
        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        Dim Count(2) As String

        Count(0) = ds.Tables(0).Rows(0).Item("AvgRate").ToString
        Count(1) = ds.Tables(0).Rows(0).Item("stars").ToString
        If Count(0) = "" Then
            Count(0) = "0"
        End If
        If Count(1) = "" Then
            Count(1) = "0"
        End If

        Return Count

    End Function


    Protected Sub ImageButton1_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton1.Click
        Response.Redirect("farm_reserve1.aspx?id=" & HiddenFarmId.Value)
    End Sub


    Private Sub GetPricing()
        Dim myconnection As New SqlClient.SqlConnection
        myconnection.ConnectionString = Web.Configuration.WebConfigurationManager.ConnectionStrings.Item("MainConnection").ToString
        Dim cmd As New SqlClient.SqlCommand

        cmd.Parameters.AddWithValue("@Farmid", HiddenFarmId.Value.Trim)
        Dim str As String = ""

        str &= " SELECT   id, FarmId, HunterPrice, GuestPrice"
        str &= " FROM            tbl_Farm_Pricing"
        str &= " WHERE (FarmId = @FarmId)"


        cmd.CommandText = str
        cmd.CommandType = CommandType.Text
        cmd.Connection = myconnection

        Dim ds As New DataSet()
        Dim da As New SqlClient.SqlDataAdapter()
        Dim tbl As New DataTable
        Try
            myconnection.Open()
            da.SelectCommand = cmd
            da.Fill(ds, "Auto")

        Catch ex As Exception

        Finally
            myconnection.Close()
        End Try

        Try
            If IsNumeric(ds.Tables(0).Rows(0).Item("HunterPrice").ToString) Then
                ImageButton1.Visible = True
                Try
                    lblHuntRate.Text = CDbl(ds.Tables(0).Rows(0).Item("HunterPrice").ToString).ToString("###,##0.00")
                Catch ex As Exception

                End Try
                Try
                    lblGuestRate.Text = CDbl(ds.Tables(0).Rows(0).Item("GuestPrice").ToString).ToString("###,##0.00")

                Catch ex As Exception

                End Try

            Else
                ImageButton1.Visible = False
            End If
        Catch ex As Exception
            ImageButton1.Visible = False
        End Try
        Try
            If Request.Cookies("memberid").Value.Trim = "0" Then
                ImageButton1.Visible = False
            End If
        Catch ex As Exception

        End Try


    End Sub


    Protected Sub ImageButton2_Click(sender As Object, e As ImageClickEventArgs) Handles ImageButton2.Click
        Response.Redirect("Farms/AddReview.aspx?farmid=" & HiddenFarmId.Value.Trim)
    End Sub
End Class
