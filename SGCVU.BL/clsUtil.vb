Imports System.String
Imports System.Configuration
Imports System.Linq

Public Class clsUtil

   Public Shared Sub sb_LimpiarTextBox(ByVal pi_Page As Object)
      Try
         Dim miCtrl As Object
         'recorremos todos los controles en el userform llamado UFConfiguracion
         For Each miCtrl In pi_Page.Form.Controls 'Me.Page.Form.Controls
            If TypeName(miCtrl) = "ContentPlaceHolder" Then
               For Each itCtrl In miCtrl.Controls
                  'verificamos que sea un control Textbox
                  If TypeName(itCtrl) = "TextBox" Then
                     itCtrl.Text = String.Empty
                  End If

                  'verificamos que sea un control DropDownList
                  If TypeName(itCtrl) = "DropDownList" Then
                     itCtrl.SelectedIndex = 0
                  End If

                  'verificamos que sea una grilla GridView
                  If TypeName(itCtrl) = "GridView" Then
                     itCtrl.DataBind()
                  End If
               Next itCtrl
            End If
         Next miCtrl
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Shared Function fn_detFecha_String_A_Date(ByVal pi_strFecha As String) As DateTime
      Try
         Dim detFecha As DateTime = DateTime.ParseExact(pi_strFecha, "yyyyMMdd", Nothing)

         Return detFecha
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_strFecha_Date_A_String_YYYYMMDD(ByVal pi_dtmFecha As DateTime) As String
      Try
         Dim strFecha As String = String.Empty 'pi_dtmFecha.ToString("yyyyMMdd")

         Dim strYear As String = pi_dtmFecha.Year.ToString
         Dim strMonth As String = pi_dtmFecha.Month.ToString.PadLeft(2, "0"c)
         Dim strDay As String = pi_dtmFecha.Day.ToString.PadLeft(2, "0"c)

         strFecha = Concat(strYear, strMonth, strDay)

         Return strFecha
      Catch ex As Exception
         'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
         Throw ex
      End Try
   End Function

   Public Shared Function fn_FechaLarga(ByVal pi_detFecha As DateTime) As String
      Try
         Dim strFechaTexto As String = String.Empty

         ''strFechaTexto = FormatDateTime(pi_detFecha, vbLongDate)
         'strFechaTexto = pi_detFecha.ToLongDateString

         ''quitamos el día de la semana (lunes, martes, ...) y la coma
         'strFechaTexto = Mid(strFechaTexto, InStr(strFechaTexto, ",") + 2, Len(strFechaTexto))

         Dim strDia As String = String.Empty
         Dim strMes As String = String.Empty
         Dim strAnho As String = String.Empty

         Dim intDia As Integer = pi_detFecha.Day
         Dim intMes As Integer = pi_detFecha.Month
         Dim intAnho As Integer = pi_detFecha.Year

         'formatear Dia
         strDia = intDia.ToString.PadLeft(2, "0")

         'formatear Mes
         Select Case intMes
            Case 1
               strMes = "Enero"
            Case 2
               strMes = "Febreo"
            Case 3
               strMes = "Marzo"
            Case 4
               strMes = "Abril"
            Case 5
               strMes = "Mayo"
            Case 6
               strMes = "Junio"
            Case 7
               strMes = "Julio"
            Case 8
               strMes = "Agosto"
            Case 9
               strMes = "Septiembre"
            Case 10
               strMes = "Octubre"
            Case 11
               strMes = "Noviembre"
            Case 12
               strMes = "Diciembre"
         End Select

         'Formatear Año
         strAnho = intAnho.ToString.PadLeft(4, "0")

         strFechaTexto = Concat(strDia, " de ", strMes, ", ", strAnho)

         Return strFechaTexto
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_strHora_Date_A_String_hhmmss(ByVal pi_dtmFecha As DateTime) As String
      Try
         Dim strFecha As String = pi_dtmFecha.ToString("HHmmss")

         'Dim strHour As String = pi_dtmFecha.Hour.ToString.PadLeft(2, "0"c)
         'Dim strMinute As String = pi_dtmFecha.Minute.ToString.PadLeft(2, "0"c)
         'Dim strSecond As String = pi_dtmFecha.Minute.ToString.PadLeft(2, "0"c)

         'strFecha = Concat(strHour, strMinute, strSecond)

         Return strFecha
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_NumeroALetras(ByVal pi_strNumero As String) As String
      '********Declara variables de tipo cadena************
      Dim strPalabras As String = String.Empty
      Dim strEntero As String = String.Empty
      Dim strDecimal As String = String.Empty
      Dim strFlag As String = String.Empty

      '********Declara variables de tipo entero***********
      Dim num, x, y As Integer

      strFlag = "N"

      '**********Número Negativo***********
      If Mid(pi_strNumero, 1, 1) = "-" Then
         pi_strNumero = Mid(pi_strNumero, 2, pi_strNumero.ToString.Length - 1).ToString
         strPalabras = "menos "
      End If

      '**********Si tiene ceros a la izquierda*************
      For x = 1 To pi_strNumero.ToString.Length
         If Mid(pi_strNumero, 1, 1) = "0" Then
            pi_strNumero = Mid(pi_strNumero, 2, pi_strNumero.ToString.Length).ToString.Trim
            If pi_strNumero.ToString.Trim.Length = 0 Then strPalabras = String.Empty
         Else
            Exit For
         End If
      Next

      '*********Dividir parte entera y decimal************
      For y = 1 To Len(pi_strNumero)
         If Mid(pi_strNumero, y, 1) = "." Then
            strFlag = "S"
         Else
            If strFlag = "N" Then
               strEntero = strEntero + Mid(pi_strNumero, y, 1)
            Else
               strDecimal = strDecimal + Mid(pi_strNumero, y, 1)
            End If
         End If
      Next y

      If Len(strDecimal) = 1 Then strDecimal = Concat(strDecimal, "0")

      '**********proceso de conversión***********
      strFlag = "N"

      If Val(pi_strNumero) <= 999999999 Then
         For y = Len(strEntero) To 1 Step -1
            num = Len(strEntero) - (y - 1)
            Select Case y
               Case 3, 6, 9
                  '**********Asigna las palabras para las centenas***********
                  Select Case Mid(strEntero, num, 1)
                     Case "1"
                        If Mid(strEntero, num + 1, 1) = "0" And Mid(strEntero, num + 2, 1) = "0" Then
                           strPalabras = Concat(strPalabras, "cien ")
                        Else
                           strPalabras = Concat(strPalabras, "ciento ")
                        End If
                     Case "2"
                        strPalabras = Concat(strPalabras, "doscientos ")
                     Case "3"
                        strPalabras = Concat(strPalabras, "trescientos ")
                     Case "4"
                        strPalabras = Concat(strPalabras, "cuatrocientos ")
                     Case "5"
                        strPalabras = Concat(strPalabras, "quinientos ")
                     Case "6"
                        strPalabras = Concat(strPalabras, "seiscientos ")
                     Case "7"
                        strPalabras = Concat(strPalabras, "setecientos ")
                     Case "8"
                        strPalabras = Concat(strPalabras, "ochocientos ")
                     Case "9"
                        strPalabras = Concat(strPalabras, "novecientos ")
                  End Select
               Case 2, 5, 8
                  '*********Asigna las palabras para las decenas************
                  Select Case Mid(strEntero, num, 1)
                     Case "1"
                        If Mid(strEntero, num + 1, 1) = "0" Then
                           strFlag = "S"
                           strPalabras = Concat(strPalabras, "diez ")
                        End If
                        If Mid(strEntero, num + 1, 1) = "1" Then
                           strFlag = "S"
                           strPalabras = Concat(strPalabras, "once ")
                        End If
                        If Mid(strEntero, num + 1, 1) = "2" Then
                           strFlag = "S"
                           strPalabras = Concat(strPalabras, "doce ")
                        End If
                        If Mid(strEntero, num + 1, 1) = "3" Then
                           strFlag = "S"
                           strPalabras = Concat(strPalabras, "trece ")
                        End If
                        If Mid(strEntero, num + 1, 1) = "4" Then
                           strFlag = "S"
                           strPalabras = Concat(strPalabras, "catorce ")
                        End If
                        If Mid(strEntero, num + 1, 1) = "5" Then
                           strFlag = "S"
                           strPalabras = Concat(strPalabras, "quince ")
                        End If
                        If Mid(strEntero, num + 1, 1) > "5" Then
                           strFlag = "N"
                           strPalabras = Concat(strPalabras, "dieci")
                        End If
                     Case "2"
                        If Mid(strEntero, num + 1, 1) = "0" Then
                           strPalabras = Concat(strPalabras, "veinte ")
                           strFlag = "S"
                        Else
                           strPalabras = Concat(strPalabras, "veinti")
                           strFlag = "N"
                        End If
                     Case "3"
                        If Mid(strEntero, num + 1, 1) = "0" Then
                           strPalabras = Concat(strPalabras, "treinta ")
                           strFlag = "S"
                        Else
                           strPalabras = Concat(strPalabras, "treinta y ")
                           strFlag = "N"
                        End If
                     Case "4"
                        If Mid(strEntero, num + 1, 1) = "0" Then
                           strPalabras = Concat(strPalabras, "cuarenta ")
                           strFlag = "S"
                        Else
                           strPalabras = Concat(strPalabras, "cuarenta y ")
                           strFlag = "N"
                        End If
                     Case "5"
                        If Mid(strEntero, num + 1, 1) = "0" Then
                           strPalabras = Concat(strPalabras, "cincuenta ")
                           strFlag = "S"
                        Else
                           strPalabras = Concat(strPalabras, "cincuenta y ")
                           strFlag = "N"
                        End If
                     Case "6"
                        If Mid(strEntero, num + 1, 1) = "0" Then
                           strPalabras = Concat(strPalabras, "sesenta ")
                           strFlag = "S"
                        Else
                           strPalabras = Concat(strPalabras, "sesenta y ")
                           strFlag = "N"
                        End If
                     Case "7"
                        If Mid(strEntero, num + 1, 1) = "0" Then
                           strPalabras = Concat(strPalabras, "setenta ")
                           strFlag = "S"
                        Else
                           strPalabras = Concat(strPalabras, "setenta y ")
                           strFlag = "N"
                        End If
                     Case "8"
                        If Mid(strEntero, num + 1, 1) = "0" Then
                           strPalabras = Concat(strPalabras, "ochenta ")
                           strFlag = "S"
                        Else
                           strPalabras = Concat(strPalabras, "ochenta y ")
                           strFlag = "N"
                        End If
                     Case "9"
                        If Mid(strEntero, num + 1, 1) = "0" Then
                           strPalabras = Concat(strPalabras, "noventa ")
                           strFlag = "S"
                        Else
                           strPalabras = Concat(strPalabras, "noventa y ")
                           strFlag = "N"
                        End If
                  End Select
               Case 1, 4, 7
                  '*********Asigna las palabras para las unidades*********
                  Select Case Mid(strEntero, num, 1)
                     Case "1"
                        If strFlag = "N" Then
                           If y = 1 Then
                              strPalabras = Concat(strPalabras, "uno ")
                           Else
                              strPalabras = Concat(strPalabras, "un ")
                           End If
                        End If
                     Case "2"
                        If strFlag = "N" Then strPalabras = Concat(strPalabras, "dos ")
                     Case "3"
                        If strFlag = "N" Then strPalabras = Concat(strPalabras, "tres ")
                     Case "4"
                        If strFlag = "N" Then strPalabras = Concat(strPalabras, "cuatro ")
                     Case "5"
                        If strFlag = "N" Then strPalabras = Concat(strPalabras, "cinco ")
                     Case "6"
                        If strFlag = "N" Then strPalabras = Concat(strPalabras, "seis ")
                     Case "7"
                        If strFlag = "N" Then strPalabras = Concat(strPalabras, "siete ")
                     Case "8"
                        If strFlag = "N" Then strPalabras = Concat(strPalabras, "ocho ")
                     Case "9"
                        If strFlag = "N" Then strPalabras = Concat(strPalabras, "nueve ")
                  End Select
            End Select

            '***********Asigna la palabra mil***************
            If y = 4 Then
               If Mid(strEntero, 6, 1) <> "0" Or Mid(strEntero, 5, 1) <> "0" Or Mid(strEntero, 4, 1) <> "0" Or _
               (Mid(strEntero, 6, 1) = "0" And Mid(strEntero, 5, 1) = "0" And Mid(strEntero, 4, 1) = "0" And _
               Len(strEntero) <= 6) Then strPalabras = Concat(strPalabras, "mil ")
            End If

            '**********Asigna la palabra millón*************
            If y = 7 Then
               If Len(strEntero) = 7 And Mid(strEntero, 1, 1) = "1" Then
                  strPalabras = Concat(strPalabras, "millón ")
               Else
                  strPalabras = Concat(strPalabras, "millones ")
               End If
            End If
         Next y

         '**********Une la parte entera y la parte decimal*************
         If strDecimal <> String.Empty Then
            fn_NumeroALetras = Concat(strPalabras, "con ", strDecimal)
         Else
            fn_NumeroALetras = strPalabras
         End If
      Else
         fn_NumeroALetras = String.Empty
      End If
   End Function

   Public Shared Function fn_NumeroALetrasBancario(ByVal pi_strNumero As String) As String
      Try
         Dim strRetorno As String = String.Empty

         '********Declara variables de tipo cadena************
         Dim strPalabras As String = String.Empty
         Dim strEntero As String = String.Empty
         Dim strDecimal As String = String.Empty
         Dim strFlag As String = String.Empty

         '********Declara variables de tipo entero***********
         Dim num, x, y As Integer

         strFlag = "N"

         '**********Número Negativo***********
         If Mid(pi_strNumero, 1, 1) = "-" Then
            pi_strNumero = Mid(pi_strNumero, 2, pi_strNumero.ToString.Length - 1).ToString
            strPalabras = "menos "
         End If

         '**********Si tiene ceros a la izquierda*************
         For x = 1 To pi_strNumero.ToString.Length
            If Mid(pi_strNumero, 1, 1) = "0" Then
               pi_strNumero = Mid(pi_strNumero, 2, pi_strNumero.ToString.Length).ToString.Trim
               If pi_strNumero.ToString.Trim.Length = 0 Then strPalabras = String.Empty
            Else
               Exit For
            End If
         Next

         '*********Dividir parte entera y decimal************
         For y = 1 To Len(pi_strNumero)
            If Mid(pi_strNumero, y, 1) = "." Then
               strFlag = "S"
            Else
               If strFlag = "N" Then
                  strEntero = strEntero + Mid(pi_strNumero, y, 1)
               Else
                  strDecimal = strDecimal + Mid(pi_strNumero, y, 1)
               End If
            End If
         Next y

         If Len(strDecimal) = 1 Then
            strDecimal = Concat(strDecimal, "0")
         ElseIf Len(strDecimal) > 2 Then
            strDecimal = Mid(strDecimal, 1, 2)
         End If

         '**********proceso de conversión***********
         strFlag = "N"

         If Val(pi_strNumero) <= 999999999 Then
            For y = Len(strEntero) To 1 Step -1
               num = Len(strEntero) - (y - 1)
               Select Case y
                  Case 3, 6, 9
                     '**********Asigna las palabras para las centenas***********
                     Select Case Mid(strEntero, num, 1)
                        Case "1"
                           If Mid(strEntero, num + 1, 1) = "0" And Mid(strEntero, num + 2, 1) = "0" Then
                              strPalabras = Concat(strPalabras, "cien ")
                           Else
                              strPalabras = Concat(strPalabras, "ciento ")
                           End If
                        Case "2"
                           strPalabras = Concat(strPalabras, "doscientos ")
                        Case "3"
                           strPalabras = Concat(strPalabras, "trescientos ")
                        Case "4"
                           strPalabras = Concat(strPalabras, "cuatrocientos ")
                        Case "5"
                           strPalabras = Concat(strPalabras, "quinientos ")
                        Case "6"
                           strPalabras = Concat(strPalabras, "seiscientos ")
                        Case "7"
                           strPalabras = Concat(strPalabras, "setecientos ")
                        Case "8"
                           strPalabras = Concat(strPalabras, "ochocientos ")
                        Case "9"
                           strPalabras = Concat(strPalabras, "novecientos ")
                     End Select
                  Case 2, 5, 8
                     '*********Asigna las palabras para las decenas************
                     Select Case Mid(strEntero, num, 1)
                        Case "0"
                           strFlag = "N"
                        Case "1"
                           If Mid(strEntero, num + 1, 1) = "0" Then
                              strFlag = "S"
                              strPalabras = Concat(strPalabras, "diez ")
                           End If
                           If Mid(strEntero, num + 1, 1) = "1" Then
                              strFlag = "S"
                              strPalabras = Concat(strPalabras, "once ")
                           End If
                           If Mid(strEntero, num + 1, 1) = "2" Then
                              strFlag = "S"
                              strPalabras = Concat(strPalabras, "doce ")
                           End If
                           If Mid(strEntero, num + 1, 1) = "3" Then
                              strFlag = "S"
                              strPalabras = Concat(strPalabras, "trece ")
                           End If
                           If Mid(strEntero, num + 1, 1) = "4" Then
                              strFlag = "S"
                              strPalabras = Concat(strPalabras, "catorce ")
                           End If
                           If Mid(strEntero, num + 1, 1) = "5" Then
                              strFlag = "S"
                              strPalabras = Concat(strPalabras, "quince ")
                           End If
                           If Mid(strEntero, num + 1, 1) > "5" Then
                              strFlag = "N"
                              strPalabras = Concat(strPalabras, "dieci")
                           End If
                        Case "2"
                           If Mid(strEntero, num + 1, 1) = "0" Then
                              strPalabras = Concat(strPalabras, "veinte ")
                              strFlag = "S"
                           Else
                              strPalabras = Concat(strPalabras, "veinti")
                              strFlag = "N"
                           End If
                        Case "3"
                           If Mid(strEntero, num + 1, 1) = "0" Then
                              strPalabras = Concat(strPalabras, "treinta ")
                              strFlag = "S"
                           Else
                              strPalabras = Concat(strPalabras, "treinta y ")
                              strFlag = "N"
                           End If
                        Case "4"
                           If Mid(strEntero, num + 1, 1) = "0" Then
                              strPalabras = Concat(strPalabras, "cuarenta ")
                              strFlag = "S"
                           Else
                              strPalabras = Concat(strPalabras, "cuarenta y ")
                              strFlag = "N"
                           End If
                        Case "5"
                           If Mid(strEntero, num + 1, 1) = "0" Then
                              strPalabras = Concat(strPalabras, "cincuenta ")
                              strFlag = "S"
                           Else
                              strPalabras = Concat(strPalabras, "cincuenta y ")
                              strFlag = "N"
                           End If
                        Case "6"
                           If Mid(strEntero, num + 1, 1) = "0" Then
                              strPalabras = Concat(strPalabras, "sesenta ")
                              strFlag = "S"
                           Else
                              strPalabras = Concat(strPalabras, "sesenta y ")
                              strFlag = "N"
                           End If
                        Case "7"
                           If Mid(strEntero, num + 1, 1) = "0" Then
                              strPalabras = Concat(strPalabras, "setenta ")
                              strFlag = "S"
                           Else
                              strPalabras = Concat(strPalabras, "setenta y ")
                              strFlag = "N"
                           End If
                        Case "8"
                           If Mid(strEntero, num + 1, 1) = "0" Then
                              strPalabras = Concat(strPalabras, "ochenta ")
                              strFlag = "S"
                           Else
                              strPalabras = Concat(strPalabras, "ochenta y ")
                              strFlag = "N"
                           End If
                        Case "9"
                           If Mid(strEntero, num + 1, 1) = "0" Then
                              strPalabras = Concat(strPalabras, "noventa ")
                              strFlag = "S"
                           Else
                              strPalabras = Concat(strPalabras, "noventa y ")
                              strFlag = "N"
                           End If
                     End Select
                  Case 1, 4, 7
                     '*********Asigna las palabras para las unidades*********
                     Select Case Mid(strEntero, num, 1)
                        Case "1"
                           If strFlag = "N" Then
                              If y = 1 Then
                                 strPalabras = Concat(strPalabras, "uno ")
                              Else
                                 strPalabras = Concat(strPalabras, "un ")
                              End If
                           End If
                        Case "2"
                           If strFlag = "N" Then strPalabras = Concat(strPalabras, "dos ")
                        Case "3"
                           If strFlag = "N" Then strPalabras = Concat(strPalabras, "tres ")
                        Case "4"
                           If strFlag = "N" Then strPalabras = Concat(strPalabras, "cuatro ")
                        Case "5"
                           If strFlag = "N" Then strPalabras = Concat(strPalabras, "cinco ")
                        Case "6"
                           If strFlag = "N" Then strPalabras = Concat(strPalabras, "seis ")
                        Case "7"
                           If strFlag = "N" Then strPalabras = Concat(strPalabras, "siete ")
                        Case "8"
                           If strFlag = "N" Then strPalabras = Concat(strPalabras, "ocho ")
                        Case "9"
                           If strFlag = "N" Then strPalabras = Concat(strPalabras, "nueve ")
                     End Select
               End Select

               '***********Asigna la palabra mil***************
               If y = 4 Then
                  If Mid(strEntero, 6, 1) <> "0" Or Mid(strEntero, 5, 1) <> "0" Or Mid(strEntero, 4, 1) <> "0" Or _
                  (Mid(strEntero, 6, 1) = "0" And Mid(strEntero, 5, 1) = "0" And Mid(strEntero, 4, 1) = "0" And _
                  Len(strEntero) <= 6) Then strPalabras = Concat(strPalabras, "mil ")
               End If

               '**********Asigna la palabra millón*************
               If y = 7 Then
                  If Len(strEntero) = 7 And Mid(strEntero, 1, 1) = "1" Then
                     strPalabras = Concat(strPalabras, "millón ")
                  Else
                     strPalabras = Concat(strPalabras, "millones ")
                  End If
               End If
            Next y

            '**********Une la parte entera y la parte decimal*************
            If strDecimal <> String.Empty Then
               strRetorno = Concat(strPalabras, "y ", strDecimal, "/100")
            Else
               strRetorno = Concat(strPalabras, "y 00/100")
            End If
         Else
            strRetorno = String.Empty
         End If


         'strRetorno = StrConv(strRetorno, VbStrConv.ProperCase)
         strRetorno = Concat(UCase(Left(strRetorno, 1)), LCase(Mid(strRetorno, 2)))

         Return strRetorno
      Catch ex As Exception
         Throw ex

         Return String.Empty
      End Try
   End Function

   Public Shared Sub sb_ValidacionesCliente(ByVal pi_objRegularExpressionValidator As Object)
      Try
         Dim expValidacion As String = ConfigurationManager.AppSettings("Validacion1").ToString

         pi_objRegularExpressionValidator.ValidationExpression = expValidacion
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Shared Function fn_ConvertCentimeterToPoints(ByVal pi_dblCentimeter As Double) As Double
      Try
         Dim dblCentimeter As Double = 0.0

         Dim dblPoint As Double = 28.3464567072

         dblCentimeter = pi_dblCentimeter * dblPoint

         Return dblCentimeter
      Catch ex As Exception
         Throw ex

         Return 0.0
      End Try
   End Function

   Public Shared Sub sb_AgregaLinea(ByRef po_obj As Object, ByVal pi_strMensaje As String)
      Try
         po_obj.Text = Concat(po_obj.Text, vbCrLf, pi_strMensaje)
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Shared Function fn_ConvertirArrayAString(ByVal pi_liStr As List(Of String), ByVal pi_agregarComillas As Boolean) As String
      Dim strFinal As String = String.Empty
      Dim strComillas As String = If(pi_agregarComillas, "'", "")

      For Each item As String In pi_liStr
         If item <> String.Empty Then
            strFinal += strComillas + item + strComillas + ","
         End If
      Next item

      If strFinal.Length > 0 Then
         strFinal = strFinal.Substring(0, strFinal.Length - 1)
      End If

      Return strFinal
   End Function

   ''' <summary>
   ''' Convierte una cadena con formato 'dd/MM/yyyy', 'dd-MM-yyyy' o 'ddMMyyyy' al formato 'yyyy-MM-dd', 'yyyy/MM/dd' o 'yyyyMMdd'
   ''' </summary>
   ''' <param name="pi_strFecha">String con el formato 'dd/MM/yyyy', 'dd-MM-yyyy', 'ddMMyyyy'</param>
   ''' <param name="pi_strSeparador">Cadena para separar el año, mes y día</param>
   ''' <returns>Cadena con el formato 'yyyy-MM-dd', 'yyyy/MM/dd', 'yyyyMMdd'</returns>
   ''' <remarks></remarks>
   Public Shared Function fn_strFecha_String_ddMMyyyy_A_String_yyyyMMdd(ByVal pi_strFecha As String, ByVal pi_strSeparador As String) As String
      If pi_strFecha = String.Empty Or pi_strFecha Is Nothing Then
         Return Nothing
      Else
         Dim strFechaFinal As String = String.Empty

         pi_strFecha = pi_strFecha.Replace("/", String.Empty)
         pi_strFecha = pi_strFecha.Replace("-", String.Empty)

         Dim strDia = pi_strFecha.Substring(0, 2)
         Dim strMes = pi_strFecha.Substring(2, 2)
         Dim strAnio = pi_strFecha.Substring(4, 4)

         strFechaFinal = String.Format("{1}{0}{2}{0}{3}", pi_strSeparador, strAnio, strMes, strDia)

         Return strFechaFinal
      End If
   End Function

End Class