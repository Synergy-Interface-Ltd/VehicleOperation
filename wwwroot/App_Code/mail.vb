Imports Microsoft.VisualBasic
Imports System.Net.Mail

Public Class mail
    Public Function shootmail(ByVal mailto, ByVal mailfrom, ByVal subject, ByVal body, ByVal host, ByVal uid, ByVal pwd)
        'Try
        Dim objMM1 As New MailMessage()
        Dim objMM As New MailMessage()

        objMM1.To.Add(Trim(mailto))



        objMM1.From = New MailAddress(mailfrom, "Asian Donors")

        objMM1.Subject = subject



        objMM1.Body = body
        objMM1.IsBodyHtml = True

        Dim smtp As New System.Net.Mail.SmtpClient()
        smtp.Host = host
        smtp.UseDefaultCredentials = True
        smtp.Credentials = New System.Net.NetworkCredential(uid.ToString, pwd.ToString)
        smtp.Port = 25
        'smtp.EnableSsl = True

        smtp.Send(objMM1)


        'Catch

        'End Try

    End Function
End Class
