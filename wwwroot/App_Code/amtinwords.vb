Imports Microsoft.VisualBasic

Public Class amtinwords
    'Main Function
     Function strReplicate(ByVal str As String, ByVal intD As Integer) As String
        'This fucntion padded "0" after the number to evaluate hundred, thousand and on....
        'using this function you can replicate any Charactor with given string.
        Dim i As Integer
        strReplicate = ""
        For i = 1 To intD
            strReplicate = strReplicate + str
        Next
        Return strReplicate
    End Function
    Function SpellNumber(ByVal Num As Decimal) As String
        'I have created this function for converting amount in indian rupees (INR). 
        'You can manipulate as you wish like decimal setting, Doller (any currency) Prefix.

        Dim strNum As String
        Dim strNumDec As String
        Dim StrWord As String
        strNum = Num

        If InStr(1, strNum, ".") <> 0 Then
            strNumDec = Mid(strNum, InStr(1, strNum, ".") + 1)

            If Len(strNumDec) = 1 Then
                strNumDec = strNumDec + "0"
            End If
            If Len(strNumDec) > 2 Then
                strNumDec = Mid(strNumDec, 1, 2)
            End If

            strNum = Mid(strNum, 1, InStr(1, strNum, ".") - 1)
            'StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " and Paise" + cWord3(CDbl(strNumDec)), "")
            StrWord = IIf(CDbl(strNum) = 1, "", "") + NumToWord(CDbl(strNum)) + IIf(CDbl(strNumDec) > 0, " Taka and Paise" + cWord3(CDbl(strNumDec)), "")
        Else
            ' StrWord = IIf(CDbl(strNum) = 1, " Rupee ", " Rupees ") + NumToWord(CDbl(strNum))
            StrWord = IIf(CDbl(strNum) = 1, "", "") + NumToWord(CDbl(strNum)) & " Taka "
        End If
        SpellNumber = StrWord ' & " Only"
        Return SpellNumber
    End Function
    Function NumToWord(ByVal Num As Decimal) As String
        'I divided this function in two part.
        '1. Three or less digit number.
        '2. more than three digit number.
        Dim strNum As String
        Dim StrWord As String
        strNum = Num

        If Len(strNum) <= 3 Then
            StrWord = cWord3(CDbl(strNum))
        Else
            StrWord = cWordG3(CDbl(Mid(strNum, 1, Len(strNum) - 3))) + " " + cWord3(CDbl(Mid(strNum, Len(strNum) - 2)))
        End If
        NumToWord = StrWord
    End Function
    Function cWordG3(ByVal Num As Decimal) As String
        '2. more than three digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        strNum = Num
        If Len(strNum) Mod 2 <> 0 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            If readNum <> "0" Then
                StrWord = retWord(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 1) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 2)
        End If
        While Not Len(strNum) = 0
            readNum = CDbl(Mid(strNum, 1, 2))
            If readNum <> "0" Then
                StrWord = StrWord + " " + cWord3(readNum)
                readNum = CDbl("1" + strReplicate("0", Len(strNum) - 2) + "000")
                StrWord = StrWord + " " + retWord(readNum)
            End If
            strNum = Mid(strNum, 3)
        End While
        cWordG3 = StrWord
        Return cWordG3
    End Function
    Function cWord3(ByVal Num As Decimal) As String
        '1. Three or less digit number.
        Dim strNum As String = ""
        Dim StrWord As String = ""
        Dim readNum As String = ""
        If Num < 0 Then Num = Num * -1
        strNum = Num

        If Len(strNum) = 3 Then
            readNum = CDbl(Mid(strNum, 1, 1))
            StrWord = retWord(readNum) + " Hundred"
            strNum = Mid(strNum, 2, Len(strNum))
        End If

        If Len(strNum) <= 2 Then
            If CDbl(strNum) >= 0 And CDbl(strNum) <= 20 Then
                StrWord = StrWord + " " + retWord(CDbl(strNum))
            Else
                StrWord = StrWord + " " + retWord(CDbl(Mid(strNum, 1, 1) + "0")) + " " + retWord(CDbl(Mid(strNum, 2, 1)))
            End If
        End If

        strNum = CStr(Num)
        cWord3 = StrWord
        Return cWord3
    End Function

    Function retWord(ByVal Num As Decimal) As String
        'This two dimensional array store the primary word convertion of number.
        retWord = ""
        Dim ArrWordList(,) As Object = {{0, ""}, {1, "One"}, {2, "Two"}, {3, "Three"}, {4, "Four"}, _
                                        {5, "Five"}, {6, "Six"}, {7, "Seven"}, {8, "Eight"}, {9, "Nine"}, _
                                        {10, "Ten"}, {11, "Eleven"}, {12, "Twelve"}, {13, "Thirteen"}, {14, "Fourteen"}, _
                                        {15, "Fifteen"}, {16, "Sixteen"}, {17, "Seventeen"}, {18, "Eighteen"}, {19, "Nineteen"}, _
                                        {20, "Twenty"}, {30, "Thirty"}, {40, "Forty"}, {50, "Fifty"}, {60, "Sixty"}, _
                                        {70, "Seventy"}, {80, "Eighty"}, {90, "Ninety"}, {100, "Hundred"}, {1000, "Thousand"}, _
                                        {100000, "Lakh"}, {10000000, "Crore"}}

        Dim i As Integer
        For i = 0 To UBound(ArrWordList)
            If Num = ArrWordList(i, 0) Then
                retWord = ArrWordList(i, 1)
                Exit For
            End If
        Next
        Return retWord
    End Function




    'Function SpellNumber(ByVal MyNumber As String) As String
    '    Dim Dollars As String = ""
    '    Dim Cents As String = ""
    '    Dim Temp As String = ""
    '    Dim DecimalPlace, Count As Integer
    '    Dim Place(9) As String
    '    Place(2) = " Thousand "
    '    ' Place(3) = " Lac "
    '    Place(3) = " Million "
    '    Place(4) = " Billion "
    '    Place(5) = " Trillion "
    '    ' String representation of amount.
    '    MyNumber = Trim(Str(MyNumber))
    '    ' Position of decimal place 0 if none.
    '    DecimalPlace = InStr(MyNumber, ".")
    '    ' Convert cents and set MyNumber to dollar amount.
    '    If DecimalPlace > 0 Then
    '        Cents = GetTens(Left(Mid(MyNumber, DecimalPlace + 1) & _
    '        "00", 2))
    '        MyNumber = Trim(Left(MyNumber, DecimalPlace - 1))
    '    End If
    '    Count = 1
    '    Do While MyNumber <> ""
    '        Temp = GetHundreds(Right(MyNumber, 3))
    '        If Temp <> "" Then Dollars = Temp & Place(Count) & Dollars
    '        If Len(MyNumber) > 3 Then
    '            MyNumber = Left(MyNumber, Len(MyNumber) - 3)
    '        Else
    '            MyNumber = ""
    '        End If
    '        Count = Count + 1
    '    Loop
    '    Select Case Dollars
    '        Case ""
    '            Dollars = " "
    '        Case "One"
    '            Dollars = "One "
    '        Case Else
    '            Dollars = Dollars & ""
    '    End Select
    '    Select Case Cents
    '        Case ""
    '            Cents = ""
    '        Case "One"
    '            Cents = " and One Paise"
    '        Case Else
    '            Cents = " and " & Cents & " Paise"
    '    End Select
    '    SpellNumber = Dollars & Cents
    'End Function
    '' Converts a number from 100-999 into text 
    'Function GetHundreds(ByVal MyNumber As String) As String
    '    Dim Result As String
    '    If Val(MyNumber) = 0 Then : Return "" : Exit Function : End If
    '    MyNumber = Right("000" & MyNumber, 3)
    '    ' Convert the hundreds place.
    '    If Mid(MyNumber, 1, 1) <> "0" Then
    '        Result = GetDigit(Mid(MyNumber, 1, 1)) & " Hundred "
    '    End If
    '    ' Convert the tens and ones place.
    '    If Mid(MyNumber, 2, 1) <> "0" Then
    '        Result = Result & GetTens(Mid(MyNumber, 2))
    '    Else
    '        Result = Result & GetDigit(Mid(MyNumber, 3))
    '    End If
    '    GetHundreds = Result
    'End Function
    '' Converts a number from 10 to 99 into text. 
    'Function GetTens(ByVal TensText As String) As String
    '    Dim Result As String
    '    Result = ""           ' Null out the temporary function value.
    '    If Val(Left(TensText, 1)) = 1 Then   ' If value between 10-19...
    '        Select Case Val(TensText)
    '            Case 10 : Result = "Ten"
    '            Case 11 : Result = "Eleven"
    '            Case 12 : Result = "Twelve"
    '            Case 13 : Result = "Thirteen"
    '            Case 14 : Result = "Fourteen"
    '            Case 15 : Result = "Fifteen"
    '            Case 16 : Result = "Sixteen"
    '            Case 17 : Result = "Seventeen"
    '            Case 18 : Result = "Eighteen"
    '            Case 19 : Result = "Nineteen"
    '            Case Else
    '        End Select
    '    Else                                 ' If value between 20-99...
    '        Select Case Val(Left(TensText, 1))
    '            Case 2 : Result = "Twenty "
    '            Case 3 : Result = "Thirty "
    '            Case 4 : Result = "Forty "
    '            Case 5 : Result = "Fifty "
    '            Case 6 : Result = "Sixty "
    '            Case 7 : Result = "Seventy "
    '            Case 8 : Result = "Eighty "
    '            Case 9 : Result = "Ninety "
    '            Case Else
    '        End Select
    '        Result = Result & GetDigit _
    '        (Right(TensText, 1))  ' Retrieve ones place.
    '    End If
    '    GetTens = Result
    'End Function
    '' Converts a number from 1 to 9 into text. 
    'Function GetDigit(ByVal Digit As String) As String
    '    Select Case Val(Digit)
    '        Case 1 : GetDigit = "One"
    '        Case 2 : GetDigit = "Two"
    '        Case 3 : GetDigit = "Three"
    '        Case 4 : GetDigit = "Four"
    '        Case 5 : GetDigit = "Five"
    '        Case 6 : GetDigit = "Six"
    '        Case 7 : GetDigit = "Seven"
    '        Case 8 : GetDigit = "Eight"
    '        Case 9 : GetDigit = "Nine"
    '        Case Else : GetDigit = ""
    '    End Select
    'End Function
End Class
