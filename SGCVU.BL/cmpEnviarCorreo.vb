Imports System.Net.Mail
Imports System.Configuration
Imports System.String

Imports SGCVU.BE

Public Class cmpEnviarCorreo

    'Public Overloads Shared Function fn_EnviaCorreo(ByVal pi_strDe As String, _
    '                                                ByVal pi_strPara As String, _
    '                                                ByVal pi_strAsunto As String, _
    '                                                ByVal pi_strCuerpoMensaje As String, _
    '                                                ByVal pi_liAdjunto As List(Of BE_Adjuntos), _
    '                                                ByRef po_strError As String) As Boolean
    '   Try
    '      Dim bolSuccess As Boolean = False

    '      Dim smtp As New SmtpClient()

    '      Dim strServidorCorreo As String = ConfigurationManager.AppSettings("ServidorCorreo").ToString
    '      Dim strPuerto As String = ConfigurationManager.AppSettings("Puerto").ToString
    '      Dim strClave As String = ConfigurationManager.AppSettings("Clave").ToString

    '      Dim strCorreo As String() = pi_strDe.Split("@"c)
    '      Dim strCuenta As String = String.Empty 'strCorreo(0).ToString()

    '      For Each it As String In strCorreo
    '         strCuenta = it.ToString
    '         Exit For
    '      Next it

    '      Dim mmMessage As MailMessage = New MailMessage

    '      'capturo todos los anexos
    '      For Each it As BE_Adjuntos In pi_liAdjunto
    '         If it.strPathArchivoAdjunto <> String.Empty Then
    '            If System.IO.File.Exists(it.strPathArchivoAdjunto) Then
    '               Dim myAttachment As Attachment = New Attachment(it.strPathArchivoAdjunto)
    '               mmMessage.Attachments.Add(myAttachment)
    '            End If
    '         End If
    '      Next it

    '      With mmMessage
    '         .From = New MailAddress(pi_strDe)
    '         .Subject = pi_strAsunto
    '         .IsBodyHtml = True
    '         .Body = pi_strCuerpoMensaje
    '      End With

    '      smtp.Host = strServidorCorreo
    '      smtp.Port = CInt(strPuerto)
    '      smtp.Credentials = New System.Net.NetworkCredential(strCuenta, strClave)

    '      Dim strEnviarCorreo As String = ConfigurationManager.AppSettings("EnviaCorreo").ToString

    '      Select Case strEnviarCorreo
    '         Case "Test"
    '            mmMessage.To.Add(pi_strDe)
    '         Case "TestQA"
    '            mmMessage.To.Add(pi_strDe)
    '         Case String.Empty
    '            mmMessage.To.Add(pi_strPara)
    '      End Select

    '      'Message.Bcc.Add(CopiaOCulta)
    '      Try
    '         smtp.Send(mmMessage)

    '         bolSuccess = True
    '      Catch ex As Exception
    '         po_strError = ex.ToString
    '         bolSuccess = False
    '      End Try

    '      Return bolSuccess
    '   Catch ex As Exception
    '      po_strError = ex.ToString
    '      Return False
    '      Throw ex
    '   End Try
    'End Function

   Public Overloads Shared Function fn_EnviaCorreo(ByVal pi_strDe As String, _
                                                   ByVal pi_strPara As String, _
                                                   ByVal pi_strAsunto As String, _
                                                   ByVal pi_strCuerpoMensaje As String, _
                                                   ByRef po_strError As String) As Boolean
      Try
         Dim bolSuccess As Boolean = False

         Dim smtp As New SmtpClient()

         Dim strServidorCorreo As String = ConfigurationManager.AppSettings("ServidorCorreo").ToString
         Dim strPuerto As String = ConfigurationManager.AppSettings("Puerto").ToString
         Dim strClave As String = ConfigurationManager.AppSettings("Clave").ToString

         Dim strCorreo As String() = pi_strDe.Split("@"c)
         Dim strCuenta As String = String.Empty 'strCorreo(0).ToString()

         For Each it As String In strCorreo
            strCuenta = it.ToString
            Exit For
         Next it

         Dim mmMessage As MailMessage = New MailMessage

         With mmMessage
            '.Attachments.Add(myAttachment)
            .From = New MailAddress(pi_strDe)
            .Subject = pi_strAsunto
            .IsBodyHtml = True
            .Body = pi_strCuerpoMensaje
         End With

         smtp.Host = strServidorCorreo
         smtp.Port = CInt(strPuerto)
         smtp.Credentials = New System.Net.NetworkCredential(strCuenta, strClave)

         Dim strEnviarCorreo As String = ConfigurationManager.AppSettings("EnviaCorreo").ToString

         Select Case strEnviarCorreo
            Case "Test"
               mmMessage.To.Add(pi_strDe)
            Case "TestQA"
               mmMessage.To.Add(pi_strDe)
            Case String.Empty
               mmMessage.To.Add(pi_strPara)
         End Select

         'Message.Bcc.Add(CopiaOCulta)
         Try
            smtp.Send(mmMessage)

            bolSuccess = True
         Catch ex As Exception
            po_strError = ex.ToString
            bolSuccess = False
         End Try

         Return bolSuccess
      Catch ex As Exception
         po_strError = ex.ToString
         Return False
         Throw ex
      End Try
   End Function

End Class
