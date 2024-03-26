Imports Microsoft.VisualBasic
Imports System.Data
Imports System.Data.SqlClient
Public Class genfunction
    Dim strconnection = ConfigurationSettings.AppSettings("ConnectionString1")
    Dim Myconnection As SqlConnection
    Dim Mycommand, Mycommand1 As SqlCommand
    Dim mynewrecord As SqlCommand
    Dim strnewrecord As String
    Dim Mydataadapter, Mydataadapter1 As SqlDataAdapter
    Dim dv, dv1 As New DataView
    Dim mydataset, mydataset1 As New DataSet
    Function remove_specialchar(ByVal input_string As String) As String
        Dim corrected_string
        corrected_string = input_string.ToString.Replace("/", "").ToString.Replace("-", "").ToString.Replace("_", "").ToString.Replace("+", "").ToString.Replace("=", "").ToString.Replace(")", "").ToString.Replace("(", "").ToString.Replace("*", "").ToString.Replace("&", "").ToString.Replace("^", "").ToString.Replace("%", "").ToString.Replace("$", "").ToString.Replace("#", "").ToString.Replace("@", "").ToString.Replace("!", "").ToString.Replace("~", "").ToString.Replace("`", "").ToString.Replace(".", "").ToString.Replace(">", "").ToString.Replace("<", "").ToString.Replace(":", "").ToString.Replace(";", "").ToString.Replace("""", "").ToString.Replace("'", "''").ToString.Replace("{", "").ToString.Replace("[", "").ToString.Replace("}", "").ToString.Replace("]", "").ToString.Replace("|", "").ToString.Replace("\", "").ToString ' .Replace(",", "").ToString
        Return corrected_string
    End Function

    Function remove_specialchar_for_mail(ByVal input_string As String) As String
        Dim corrected_string
        corrected_string = input_string.ToString.Replace("/", "").ToString.Replace("-", "").ToString.Replace("_", "").ToString.Replace("+", "").ToString.Replace("=", "").ToString.Replace(")", "").ToString.Replace("(", "").ToString.Replace("*", "").ToString.Replace("&", "").ToString.Replace("^", "").ToString.Replace("%", "").ToString.Replace("$", "").ToString.Replace("#", "").ToString.Replace("!", "").ToString.Replace("~", "").ToString.Replace("`", "").ToString.Replace(">", "").ToString.Replace("<", "").ToString.Replace(":", "").ToString.Replace(";", "").ToString.Replace("""", "").ToString.Replace("'", "''").ToString.Replace("{", "").ToString.Replace("[", "").ToString.Replace("}", "").ToString.Replace("]", "").ToString.Replace("|", "").ToString.Replace("\", "").ToString ' .Replace(",", "").ToString .ToString.Replace("@", "").ToString.Replace(".", "")
        Return corrected_string
    End Function

    Function remove_specialchar_for_date(ByVal input_string As String) As String
        Dim corrected_string
        corrected_string = input_string.ToString.Replace("-", "").ToString.Replace("_", "").ToString.Replace("+", "").ToString.Replace("=", "").ToString.Replace(")", "").ToString.Replace("(", "").ToString.Replace("*", "").ToString.Replace("&", "").ToString.Replace("^", "").ToString.Replace("%", "").ToString.Replace("$", "").ToString.Replace("#", "").ToString.Replace("!", "").ToString.Replace("~", "").ToString.Replace("`", "").ToString.Replace(".", "").ToString.Replace(">", "").ToString.Replace("<", "").ToString.Replace(":", "").ToString.Replace(";", "").ToString.Replace("""", "").ToString.Replace("'", "''").ToString.Replace("{", "").ToString.Replace("[", "").ToString.Replace("}", "").ToString.Replace("]", "").ToString.Replace("|", "").ToString.Replace("\", "").ToString.Replace("@", "").ToString ' .Replace(",", "").ToString .ToString.Replace("@", "") .Replace("/", "").ToString
        Return corrected_string
    End Function
    Function populate_grid(ByVal qry As String, ByVal gridview As GridView)
        If qry <> "" Then
            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()

           


            strnewrecord = qry
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "vehicle_model")
            gridview.DataSource = mydataset.Tables(0)
            gridview.DataBind()
            mydataset.Tables.Clear()

            Myconnection.Close()
            gridview.SelectedIndex = -1

            'If gridview.Rows.Count = 0 Then
            '    gridview.DataSource = Nothing
            '    gridview.DataBind()
            'End If
        End If

    End Function
    Function populate_detailsview(ByVal qry As String, ByVal gridview As DetailsView)
        If qry <> "" Then
            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()




            strnewrecord = qry
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "vehicle_model")
            gridview.DataSource = mydataset.Tables(0)
            gridview.DataBind()
            mydataset.Tables.Clear()

            Myconnection.Close()
            '  gridview.SelectedIndex = -1

            'If gridview.Rows.Count = 0 Then
            '    gridview.DataSource = Nothing
            '    gridview.DataBind()
            'End If
        End If

    End Function


    Function populate_detailsviewotherdv(ByVal qry As String, ByVal gridview As DetailsView)
        If qry <> "" Then
            'Myconnection1 = New System.Data.SqlClient.SqlConnection(strconnection)
            'Myconnection1.Open()




            strnewrecord = qry
            Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter1 = New SqlDataAdapter(Mycommand1)
            Mydataadapter1.Fill(mydataset1, "vehicle_model")
            gridview.DataSource = mydataset1.Tables(0)
            gridview.DataBind()
            mydataset1.Tables.Clear()

            ' Myconnection1.Close()
            '  gridview.SelectedIndex = -1

            'If gridview.Rows.Count = 0 Then
            '    gridview.DataSource = Nothing
            '    gridview.DataBind()
            'End If
        End If

    End Function
    Function populate_datalist(ByVal qry As String, ByVal gridview As DataList)
        If qry <> "" Then
            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()




            strnewrecord = qry
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "vehicle_model")
            gridview.DataSource = mydataset.Tables(0)
            gridview.DataBind()
            mydataset.Tables.Clear()

            Myconnection.Close()
            '  gridview.SelectedIndex = -1

            'If gridview.Rows.Count = 0 Then
            '    gridview.DataSource = Nothing
            '    gridview.DataBind()
            'End If
        End If

    End Function

    Function populate_datalistotherdv(ByVal qry As String, ByVal gridview As DataList)
        If qry <> "" Then
            'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            'Myconnection.Open()




            strnewrecord = qry
            Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter1 = New SqlDataAdapter(Mycommand1)
            Mydataadapter1.Fill(mydataset1, "vehicle_model")
            gridview.DataSource = mydataset1.Tables(0)
            gridview.DataBind()
            mydataset1.Tables.Clear()

            '   Myconnection.Close()
            '  gridview.SelectedIndex = -1

            'If gridview.Rows.Count = 0 Then
            '    gridview.DataSource = Nothing
            '    gridview.DataBind()
            'End If
        End If

    End Function
    Function populate_checkboxlist(ByVal qry As String, ByVal checkboxlist As CheckBoxList, ByVal checkboxdisplay As String, ByVal checkboxvalue As String)
        If qry <> "" Then
            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()

            strnewrecord = qry
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "vehicle_model")
            checkboxlist.DataSource = mydataset.Tables(0)
            checkboxlist.DataTextField = checkboxdisplay.ToString
            checkboxlist.DataValueField = checkboxvalue.ToString

            checkboxlist.DataBind()
            mydataset.Tables.Clear()

            Myconnection.Close()
            'gridview.SelectedIndex = -1
        End If

    End Function
    Function populate_radiolist(ByVal qry As String, ByVal RadioButtonList As RadioButtonList, ByVal checkboxdisplay As String, ByVal checkboxvalue As String)
        If qry <> "" Then
            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()

            strnewrecord = qry
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "vehicle_model")
            RadioButtonList.DataSource = mydataset.Tables(0)
            RadioButtonList.DataTextField = checkboxdisplay.ToString
            RadioButtonList.DataValueField = checkboxvalue.ToString

            RadioButtonList.DataBind()
            mydataset.Tables.Clear()

            Myconnection.Close()
            'gridview.SelectedIndex = -1
        End If

    End Function

    Function populate_dropdownlist(ByVal qry As String, ByVal DropDownList As DropDownList, ByVal checkboxdisplay As String, ByVal checkboxvalue As String)
        If qry <> "" Then
            Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            Myconnection.Open()

            strnewrecord = qry
            Mycommand = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter = New SqlDataAdapter(Mycommand)
            Mydataadapter.Fill(mydataset, "vehicle_model")
            DropDownList.DataSource = mydataset.Tables(0)
            DropDownList.DataTextField = checkboxdisplay.ToString
            DropDownList.DataValueField = checkboxvalue.ToString

            DropDownList.DataBind()
            mydataset.Tables.Clear()

            Myconnection.Close()
            'gridview.SelectedIndex = -1
        End If

    End Function
    Function populate_dropdownlist1(ByVal qry As String, ByVal DropDownList As DropDownList, ByVal checkboxdisplay As String, ByVal checkboxvalue As String)
        If qry <> "" Then
            'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
            'Myconnection.Open()

            strnewrecord = qry
            Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
            Mydataadapter1 = New SqlDataAdapter(Mycommand1)
            Mydataadapter1.Fill(mydataset1, "vehicle_model")
            DropDownList.DataSource = mydataset1.Tables(0)
            DropDownList.DataTextField = checkboxdisplay.ToString
            DropDownList.DataValueField = checkboxvalue.ToString

            DropDownList.DataBind()
            mydataset1.Tables.Clear()

            '  Myconnection.Close()
            'gridview.SelectedIndex = -1
        End If

    End Function

    Function create_table(ByVal qry As String) As String
        'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        'Myconnection.Open()

        Dim htmltbl
        htmltbl = ""
        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        If dv1.Count > 0 Then
            htmltbl = "<table cellspacing='0'cellpadding='2' border='1'><tr>"
            Dim k
            For k = 0 To dv1.Table.Columns.Count - 1
                htmltbl = htmltbl & "<td align='left; valign='top'><b>" & dv1.Table.Columns(k).ToString & "</b></td>"

            Next
            htmltbl = htmltbl & "</tr>"

            Dim i
            For i = 0 To dv1.Count - 1
                htmltbl = htmltbl & "<tr>"
                Dim j
                For j = 0 To dv1.Table.Columns.Count - 1
                    If IsDate(dv1(i)(j).ToString) Then
                        Dim tdt As New Date
                        tdt = dv1(i)(j).ToString
                        htmltbl = htmltbl & "<td align='left; valign='top'>" & tdt.ToString("dd/MM/yyyy") & "</td>"
                    Else
                        htmltbl = htmltbl & "<td align='left; valign='top'>" & dv1(i)(j).ToString & "</td>"
                    End If


                Next
                htmltbl = htmltbl & "</tr>"
            Next
            htmltbl = htmltbl & "</table>"
        End If
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        'Myconnection.Close()
        Return htmltbl
    End Function

    Function create_table_vertical(ByVal qry As String) As String
        'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        'Myconnection.Open()

        Dim htmltbl
        htmltbl = ""
        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        If dv1.Count > 0 Then
            htmltbl = "<table cellspacing='0'cellpadding='2' border='1'>"
            'Dim k
            'For k = 0 To dv1.Table.Columns.Count - 1
            '    htmltbl = htmltbl & "<td align='left; valign='top'><b>" & dv1.Table.Columns(k).ToString & "</b></td>"

            'Next
            'htmltbl = htmltbl & "</tr>"

            Dim i
            For i = 0 To dv1.Count - 1

                Dim j
                For j = 0 To dv1.Table.Columns.Count - 1
                    If IsDate(dv1(i)(j).ToString) Then
                        Dim tdt As New Date
                        tdt = dv1(i)(j)
                        htmltbl = htmltbl & "<tr>"
                        If dv1.Table.Columns(j).ToString.Substring(0, 1).ToUpper = "T" Then
                            htmltbl = htmltbl & "<td align='left; valign='top'><b>" & dv1.Table.Columns(j).ToString.Substring(1) & "</b></td>"
                            htmltbl = htmltbl & "<td align='left; valign='top'>" & tdt.ToString("dd/MM/yyyy hh:mm tt") & "</td></tr>"

                        Else
                            htmltbl = htmltbl & "<td align='left; valign='top'><b>" & dv1.Table.Columns(j).ToString & "</b></td>"
                            htmltbl = htmltbl & "<td align='left; valign='top'>" & tdt.ToString("dd/MM/yyyy") & "</td></tr>"

                        End If
                     Else
                        htmltbl = htmltbl & "<tr>"
                        htmltbl = htmltbl & "<td align='left; valign='top'><b>" & dv1.Table.Columns(j).ToString & "</b></td>"
                        htmltbl = htmltbl & "<td align='left; valign='top'>" & dv1(i)(j).ToString & "</td></tr>"
                    End If
                   

                Next
                '  htmltbl = htmltbl & "</tr>"
                If i < dv1.Count - 1 Then
                    htmltbl = htmltbl & "<tr><td colspan='2'>&nbsp;</td></tr>"
                End If
            Next
            htmltbl = htmltbl & "</table>"
        End If
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        'Myconnection.Close()
        Return htmltbl
    End Function
    Function create_table2(ByVal qry As String) As String
        'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        'Myconnection.Open()

        Dim htmltbl
        htmltbl = ""
        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        If dv1.Count > 0 Then
            htmltbl = "<table cellspacing='0'cellpadding='2' border='1' width='100%'>"
            Dim k
            'For k = 0 To dv1.Table.Columns.Count - 1
            '    htmltbl = htmltbl & "<td align='left; valign='top'><b>" & dv1.Table.Columns(k).ToString & "</b></td>"

            'Next
            'htmltbl = htmltbl & "</tr>"

            Dim i
            For i = 0 To dv1.Count - 1
                htmltbl = htmltbl & "<tr>"
                Dim j
                For j = 0 To dv1.Table.Columns.Count - 1
                    If IsDate(dv1(i)(j).ToString) Then
                        Dim tdt As New Date
                        tdt = dv1(i)(j)
                        htmltbl = htmltbl & "<td align='left; valign='top'>" & tdt.ToString("dd/MM/yyyy") & "</td>"
                    Else
                        htmltbl = htmltbl & "<td align='left; valign='top'>" & dv1(i)(j).ToString & "</td>"
                    End If


                Next
                htmltbl = htmltbl & "</tr>"
            Next
            htmltbl = htmltbl & "</table>"
        End If
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        'Myconnection.Close()
        Return htmltbl
    End Function
    Function create_table3(ByVal qry As String) As String
        'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        'Myconnection.Open()

        Dim htmltbl
        htmltbl = ""
        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        If dv1.Count > 0 Then
            htmltbl = "<table cellspacing='0'cellpadding='2' border='0' width='100%'>"
            Dim k
            'For k = 0 To dv1.Table.Columns.Count - 1
            '    htmltbl = htmltbl & "<td align='left; valign='top'><b>" & dv1.Table.Columns(k).ToString & "</b></td>"

            'Next
            'htmltbl = htmltbl & "</tr>"

            Dim i
            For i = 0 To dv1.Count - 1
                htmltbl = htmltbl & "<tr>"
                htmltbl = htmltbl & "<td align='left; valign='top'>" & (i + 1).ToString & "</td>"
                Dim j
                For j = 0 To dv1.Table.Columns.Count - 1
                    If IsDate(dv1(i)(j).ToString) Then
                        Dim tdt As New Date
                        tdt = dv1(i)(j)
                        htmltbl = htmltbl & "<td align='left; valign='top'>" & tdt.ToString("dd/MM/yyyy") & "</td>"
                    Else
                        htmltbl = htmltbl & "<td align='left; valign='top'>" & dv1(i)(j).ToString & "</td>"
                    End If


                Next
                htmltbl = htmltbl & "</tr>"
            Next
            htmltbl = htmltbl & "</table>"
        End If
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        'Myconnection.Close()
        Return htmltbl
    End Function
    Function create_table1(ByVal qry As String) As String
        'Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        'Myconnection.Open()

        Dim htmltbl
        htmltbl = ""
        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        If dv1.Count > 0 Then
            htmltbl = "<table cellspacing='0'cellpadding='2' border='1' width='50%'><tr>"
            Dim k
            For k = 0 To dv1.Table.Columns.Count - 1
                htmltbl = htmltbl & "<td align='left; valign='top'><b>" & dv1.Table.Columns(k).ToString & "</b></td>"

            Next
            htmltbl = htmltbl & "</tr>"

            Dim i
            For i = 0 To dv1.Count - 1
                htmltbl = htmltbl & "<tr>"
                Dim j
                For j = 0 To dv1.Table.Columns.Count - 1
                    If IsDate(dv1(i)(j).ToString) Then
                        Dim tdt As New DateTime
                        tdt = dv1(i)(j)
                        htmltbl = htmltbl & "<td align='left; valign='top'>" & tdt.ToString("dd/MM/yyyy hh:mm tt") & "</td>"
                    Else
                        htmltbl = htmltbl & "<td align='left; valign='top'>" & dv1(i)(j).ToString & "</td>"
                    End If


                Next
                htmltbl = htmltbl & "</tr>"
            Next
            htmltbl = htmltbl & "</table>"
        End If
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        'Myconnection.Close()
        Return htmltbl
    End Function
    Function create_table_with_connection(ByVal qry As String) As String
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        Dim htmltbl
        htmltbl = ""
        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        If dv1.Count > 0 Then
            htmltbl = "<table cellspacing='0'cellpadding='2' border='1'><tr>"
            Dim k
            For k = 0 To dv1.Table.Columns.Count - 1
                htmltbl = htmltbl & "<td align='left; valign='top'><b>" & dv1.Table.Columns(k).ToString & "</b></td>"

            Next
            htmltbl = htmltbl & "</tr>"

            Dim i
            For i = 0 To dv1.Count - 1
                htmltbl = htmltbl & "<tr>"
                Dim j
                For j = 0 To dv1.Table.Columns.Count - 1
                    htmltbl = htmltbl & "<td align='left; valign='top'>" & dv1(i)(j).ToString & "</td>"

                Next
                htmltbl = htmltbl & "</tr>"
            Next
            htmltbl = htmltbl & "</table>"
        End If
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        Myconnection.Close()
        Return htmltbl
    End Function
    Function gridviewcheckbox_select(ByVal qry As String, ByVal gridview As GridView, ByVal checkbox As String, ByVal fieldindex As Integer, ByVal colindex As Integer)
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()
        Dim k
        For k = 0 To gridview.Rows.Count - 1
            Dim chk As New CheckBox
            chk = gridview.Rows(k).FindControl(checkbox)
            chk.Checked = False
        Next
        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        If dv1.Count > 0 Then
            Dim i
            For i = 0 To dv1.Count - 1
                Dim j
                For j = 0 To gridview.Rows.Count - 1
                    Dim chk As New CheckBox
                    chk = gridview.Rows(j).FindControl(checkbox)

                    If dv1(i)(fieldindex).ToString = gridview.Rows(j).Cells(colindex).Text Then
                        chk.Checked = True
                        'Else
                        '    chk.Checked = False
                    End If
                Next
            Next
        End If
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        Myconnection.Close()
    End Function

    Function returnvaluefromdv(ByVal qry As String, ByVal fieldindex As Integer)
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        Dim retvalue
        retvalue = ""
        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        If dv1.Count > 0 Then
            retvalue = dv1(0)(fieldindex).ToString

        End If
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        Myconnection.Close()
        Return retvalue
    End Function

    Function cleardv()
        Try
            dv1.Table.Clear()
            mydataset1.Tables.Clear()
        Catch ex As Exception

        End Try


        Try
            dv.Table.Clear()
            mydataset.Tables.Clear()
        Catch ex As Exception

        End Try
    End Function
    Function returndv(ByVal qry As String)
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        ' Dim retvalue As New DataView

        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        'retvalue.Table = dv1.Table
        Return dv1
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        Myconnection.Close()
        'Return retvalue
        'retvalue.Table.Clear()
    End Function


    Function returnvaluefromdvdtformat(ByVal qry As String, ByVal fieldindex As Integer)
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        Dim retvalue As DateTime
        retvalue = Nothing
        Dim flag
        flag = 0
        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        If dv1.Count > 0 Then
            Try
                Dim dt As New DateTime
                dt = dv1(0)(fieldindex)
                retvalue = dt '.ToString("dd/MM/yyyy hh:mm:ss tt")
                flag = 1
            Catch ex As Exception

            End Try


        End If
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        Myconnection.Close()
        If flag = 1 Then
            Return retvalue
        Else
            Return ""
        End If

    End Function
    Function checkexistancefromdv(ByVal qry As String) As Boolean
        Myconnection = New System.Data.SqlClient.SqlConnection(strconnection)
        Myconnection.Open()

        Dim retvalue
        retvalue = False
        strnewrecord = qry
        Mycommand1 = New SqlCommand(strnewrecord, Myconnection)
        Mydataadapter1 = New SqlDataAdapter(Mycommand1)
        Mydataadapter1.Fill(mydataset1, "vehicle_model")
        dv1.Table = mydataset1.Tables(0)
        If dv1.Count > 0 Then
            retvalue = True

        End If
        dv1.Table.Clear()
        mydataset1.Tables.Clear()
        Myconnection.Close()
        Return retvalue
    End Function


    Function getdate(ByVal x As String) As DateTime
        Dim arr()
        arr = Split(x, "/")
        Dim dt1 As New DateTime
        dt1 = New Date(Val(arr(2).ToString), Val(arr(1).ToString), Val(arr(0)).ToString)
        getdate = dt1
    End Function

    Function getdatefromdb(ByVal x As String) As DateTime
        Dim arr1()
        arr1 = Split(x, " ")
        Dim arr2()
        arr2 = Split(arr1(0).ToString, "/")
        Dim dt1 As New DateTime
        dt1 = New Date(Val(arr2(2).ToString), Val(arr2(0).ToString), Val(arr2(1)).ToString)
        getdatefromdb = dt1
    End Function

    Function getdatetimefromdb(ByVal x As String) As String
        Dim arr1()
        arr1 = Split(x, " ")
        Dim arr2()
        arr2 = Split(arr1(0).ToString, "/")
        Dim arr3()
        arr3 = Split(arr1(1).ToString, ":")

        Dim dt1 As New DateTime
        Dim tt
        If arr1(2).ToString = "PM" Then
            dt1 = New Date(Val(arr2(2).ToString), Val(arr2(0).ToString), Val(arr2(1).ToString), Val(arr3(0).ToString), Val(arr3(1).ToString), 0)
            tt = "PM"
        Else
            dt1 = New Date(Val(arr2(2).ToString), Val(arr2(0).ToString), Val(arr2(1).ToString), Val(arr3(0).ToString), Val(arr3(1).ToString), 0)
            tt = "AM"
        End If
        getdatetimefromdb = dt1.ToString("dd/MM/yyyy hh:mm") & " " & tt.ToString
    End Function
    Function roundup(ByVal x As String)
        Dim y As String
        y = Format(Val(x) / 100, "percent")
        roundup = y.ToString().Replace("%", "")
    End Function
    Function roundup1(ByVal x As String)
        Dim x1
        If Val(x) < 0 Then
            x1 = Val(x) * -1
        Else
            x1 = x
        End If
        Dim y As String
        y = Format(Val(x1) / 100, "percent")
        If Val(x) >= 0 Then
            roundup1 = y.ToString().Replace("%", "")
        Else
            roundup1 = "(" & y.ToString().Replace("%", "") & ")"
        End If

    End Function
End Class
