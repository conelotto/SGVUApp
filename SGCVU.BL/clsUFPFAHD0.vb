Imports SGCVU.BE
Imports SGCVU.DA
Imports System.Configuration
Imports System.String
Public Class clsUFPFAHD0

    Public Shared Function fn_Select_UFPFAHD0(ByVal pi_BEUFPFAHD0 As BE_UFPFAHD0) As List(Of BE_UFPFAHD0)
        Try
            Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

            If ConfigurationManager.AppSettings("EnviaCorreo").ToString = "Test" Then
                strLibro = "LIBT99"
            ElseIf ConfigurationManager.AppSettings("EnviaCorreo").ToString = "TestQA" Then
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{}}

            Dim liBEUFPFAHD0 As New List(Of BE_UFPFAHD0)

            Dim strConsulta As String = Concat("SELECT TRIM(A.ORDEN) AS ORDEN, A.TIPDOC, TRIM(A.NUMORI) AS NUMORI, ", _
                                               "TRIM(A.NUMDRE) AS NUMDRE, TRIM(A.CODCLI) AS CODCLI, A.SUNTIP, A.SUNPRE, A.SUNNUM, A.FECINC, ", _
                                               "A.OFIC, A.NUMPAG, A.TIPCTA, A.OFICLI, TRIM(A.RSOCIA) AS RSOCIA, A.MONEDA, A.PERCON, ", _
                                               "A.FECEMI, A.CENCOS, A.DIVISI, A.LINVIG, A.TIPCAM, A.VALAF16, A.IMPOR16, A.IMPOR21, A.SISTEMA, A.TEXTOM, A.CLIAD, A.CORP ", _
                                               "FROM ", strLibro, ".UFPFAHD0 A ", _
                                               "WHERE TRIM(A.ORDEN) = '", pi_BEUFPFAHD0.strORDEN, "' ", _
                                               "AND LENGTH(TRIM(A.NUMORI)) = 8 AND RIGHT(TRIM(A.NUMORI), 2) = '01' ", _
                                               "AND TRIM(A.CODCLI) = '", pi_BEUFPFAHD0.strCODCLI, "' ", _
                                               "AND LEFT(TRIM(A.NUMDRE), 2) = 'VT' ", _
                                               "ORDER BY A.FECINC DESC ", _
                                               "FETCH FIRST 1 ROWS ONLY")

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUFPFAHD0, objArrParametros)

            Return liBEUFPFAHD0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_UFPFAHD0_2(ByVal pi_BEUFPFAHD0 As BE_UFPFAHD0) As List(Of BE_UFPFAHD0)
        Try
            Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

            If ConfigurationManager.AppSettings("EnviaCorreo").ToString = "Test" Then
                strLibro = "LIBT99"
            ElseIf ConfigurationManager.AppSettings("EnviaCorreo").ToString = "TestQA" Then
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{}}

            Dim liBEUFPFAHD0 As New List(Of BE_UFPFAHD0)

            Dim strConsulta As String = Concat("SELECT TRIM(A.ORDEN) AS ORDEN, A.TIPDOC, TRIM(A.NUMORI) AS NUMORI, ", _
                                               "TRIM(A.NUMDRE) AS NUMDRE, TRIM(A.CODCLI) AS CODCLI, A.SUNTIP, A.SUNPRE, A.SUNNUM, A.FECINC, ", _
                                               "A.OFIC, A.NUMPAG, A.TIPCTA, A.OFICLI, TRIM(A.RSOCIA) AS RSOCIA, A.MONEDA, A.PERCON, ", _
                                               "A.FECEMI, A.CENCOS, A.DIVISI, A.LINVIG, A.TIPCAM, A.VALAF16, A.IMPOR16, A.IMPOR21, A.SISTEMA, A.TEXTOM, A.CLIAD, A.CORP ", _
                                               "FROM ", strLibro, ".UFPFAHD0 A ", _
                                               "WHERE TRIM(A.ORDEN) = '", pi_BEUFPFAHD0.strORDEN, "' ", _
                                               "AND LENGTH(TRIM(A.NUMORI)) > 8 ", _
                                               "AND TRIM(A.CODCLI) = '", pi_BEUFPFAHD0.strCODCLI, "' ", _
                                               "AND LEFT(TRIM(A.NUMDRE), 2) = 'VT' ", _
                                               "ORDER BY A.FECINC DESC ", _
                                               "FETCH FIRST 1 ROWS ONLY")

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUFPFAHD0, objArrParametros)

            Return liBEUFPFAHD0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_UFPFAHD0_NumFactura(ByVal pi_BEUFPFAHD0 As BE_UFPFAHD0) As List(Of BE_UFPFAHD0)
        Try
            Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

            If ConfigurationManager.AppSettings("EnviaCorreo").ToString = "Test" Then
                strLibro = "LIBT99"
            ElseIf ConfigurationManager.AppSettings("EnviaCorreo").ToString = "TestQA" Then
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{}}

            Dim liBEUFPFAHD0 As New List(Of BE_UFPFAHD0)

            Dim strConsulta As String = Concat("SELECT TRIM(A.ORDEN) AS ORDEN, A.TIPDOC, TRIM(A.NUMORI) AS NUMORI, ", _
                                               "TRIM(A.NUMDRE) AS NUMDRE, TRIM(A.CODCLI) AS CODCLI, A.SUNTIP, A.SUNPRE, A.SUNNUM, A.FECINC, ", _
                                               "A.OFIC, A.NUMPAG, A.TIPCTA, A.OFICLI, TRIM(A.RSOCIA) AS RSOCIA, A.MONEDA, A.PERCON, ", _
                                               "A.FECEMI, A.CENCOS, A.DIVISI, A.LINVIG, A.TIPCAM, A.VALAF16, A.IMPOR16, A.IMPOR21, A.SISTEMA, A.TEXTOM, A.CLIAD, A.CORP ", _
                                               "FROM ", strLibro, ".UFPFAHD0 A ", _
                                               "WHERE TRIM(A.CODCLI) = '", pi_BEUFPFAHD0.strCODCLI, "' ", _
                                               "AND A.SUNTIP = '", pi_BEUFPFAHD0.strSUNTIP, "' ", _
                                               "AND A.SUNPRE = ", pi_BEUFPFAHD0.intSUNPRE, " ", _
                                               "AND A.SUNNUM = ", pi_BEUFPFAHD0.intSUNNUM, " ", _
                                               "ORDER BY A.FECINC DESC ", _
                                               "FETCH FIRST 1 ROWS ONLY")

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUFPFAHD0, objArrParametros)

            Return liBEUFPFAHD0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
