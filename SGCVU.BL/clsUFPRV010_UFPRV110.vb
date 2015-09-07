Imports IBM.Data.DB2.iSeries
Imports System.Configuration
Imports SGCVU.BE
Imports System.String
Imports SGCVU.DA
Public Class clsUFPRV010_UFPRV110

    Public Shared Function fn_Select_ListaUFPRV010_UFPRV110(ByVal pi_BEUFPRV010_UFPRV110 As BE_UFPRV010_UFPRV110) As List(Of BE_UFPRV010_UFPRV110)
        Try
            Dim strEnviaCorreo As String = ConfigurationManager.AppSettings("EnviaCorreo").ToString
            Dim strLibro As String = String.Empty

            If strEnviaCorreo = String.Empty Then
                strLibro = ConfigurationManager.AppSettings("cnLIBR08").ToString()
            Else
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{"ORDEN", iDB2DbType.iDB2VarChar, pi_BEUFPRV010_UFPRV110.str_REFEREN, Nothing}}

            Dim liBEUFPRV010_UFPRV110 As New List(Of BE_UFPRV010_UFPRV110)

            Dim strConsulta As String = Concat("SELECT   X.REFEREN,SUM(X.IMPDOL) AS IMPDOL ", _
                                               "FROM     ( ", _
                                               "SELECT   A.REFEREN,A.INDSIT,A.SISTEMA,A.CLIE,A.CLIAD,A.FECDOC,A.CLPR,A.SUNTIP,A.SUNPRE,A.SUNNUM,A.NUMDOC ", _
                                               "         ,D.CTTNO1 ", _
                                               "         ,COALESCE(C.CNTRD8,0) AS CNTRD8 ", _
                                             "         ,E.CUENTA,E.ASIEN ", _
                                             "         ,CASE E.ASIEN ", _
                                             "            WHEN  'A' ", _
                                             "               THEN  E.IMPDOL ", _
                                             "            ELSE     E.IMPDOL * (-1) ", _
                                             "         END IMPDOL ", _
                                             "         ,'1' AS ORIGEN ", _
                                             "FROM     ", strLibro, ".UFPRV010 A ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".UFPRV020 E ", _
                                             "         ON    E.CLPR = A.CLPR ", _
                                             "         AND   E.SUNTIP = A.SUNTIP ", _
                                             "         AND   E.SUNNUM = A.SUNNUM ", _
                                             "         AND   E.SUNPRE = A.SUNPRE ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".EMPEQPI0 D ", _
                                             "         ON    D.IDNO1 = A.REFEREN ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".EMPCTRE0 B ", _
                                             "         ON    B.IDNO1 = D.IDNO1 ", _
                                             "         AND   B.CTTNO1 = LEFT(A.NUMDOC,6) ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".empctrh0 C ", _
                                             "         ON    C.CTTNO1 = B.CTTNO1 ", _
                                             "WHERE    A.SUNTIP IN ('FA','BO') ", _
                                             "AND      TRIM(A.NSUNTI) = '' ", _
                                             "AND      TRIM(A.INDSIT) <> '*' ", _
                                             "AND      TRIM(A.REFEREN) = '", pi_BEUFPRV010_UFPRV110.str_REFEREN, "' ", _
                                             "AND      (LEFT(E.CUENTA,2) IN ('70','72','74','49') ", _
                                             "         OR    E.CUENTA IN ('762100','762200','122210')) ", _
                                             "             ", _
                                             "         UNION ALL ", _
                                             "             ", _
                                             "SELECT   A.REFEREN,A.INDSIT,A.SISTEMA,A.CLIE,A.CLIAD,A.FECDOC,A.CLPR,A.SUNTIP,A.SUNPRE,A.SUNNUM,A.NUMDOC ", _
                                             "         ,D.CTTNO1 ", _
                                             "         ,COALESCE(C.CNTRD8,0) AS CNTRD8 ", _
                                             "         ,E.CUENTA,E.ASIEN ", _
                                             "         ,CASE E.ASIEN ", _
                                             "            WHEN  'A' ", _
                                             "               THEN  E.IMPDOL ", _
                                             "            ELSE     E.IMPDOL * (-1) ", _
                                             "         END IMPDOL ", _
                                             "         ,'2' AS ORIGEN ", _
                                             "FROM     ", strLibro, ".UFPRV110 A ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".UFPRV120 E ", _
                                             "         ON    E.CLPR = A.CLPR ", _
                                             "         AND   E.SUNTIP = A.SUNTIP ", _
                                             "         AND   E.SUNNUM = A.SUNNUM ", _
                                             "         AND   E.SUNPRE = A.SUNPRE ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".EMPEQPI0 D ", _
                                             "         ON    D.IDNO1 = A.REFEREN ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".EMPCTRE0 B ", _
                                             "         ON    B.IDNO1 = D.IDNO1 ", _
                                             "         AND   B.CTTNO1 = LEFT(A.NUMDOC,6) ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".empctrh0 C ", _
                                             "         ON    C.CTTNO1 = B.CTTNO1 ", _
                                             "WHERE    A.SUNTIP IN ('FA','BO') ", _
                                             "AND      TRIM(A.NSUNTI) = '' ", _
                                             "AND      TRIM(A.INDSIT) <> '*' ", _
                                             "AND      TRIM(A.REFEREN) = '", pi_BEUFPRV010_UFPRV110.str_REFEREN, "' ", _
                                             "AND      (LEFT(E.CUENTA,2) IN ('70','72','74','49') ", _
                                             "         OR    E.CUENTA IN ('762100','762200','122210')) ", _
                                             "                ", _
                                             ") X ", _
                                             "GROUP BY X.REFEREN")
            'EMPCTRE0 Y empctrh0 -> ARCHIVOS DE CONTRATOS
            'SOLO TRAEMOS EL PRIMER REGISTRO ORDENADO POR FECHA DE MAYOR A MENOR

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUFPRV010_UFPRV110, objArrParametros)

            Return liBEUFPRV010_UFPRV110
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_ListaUFPRV010_UFPRV110_NumFactura(ByVal pi_BEUFPRV010_UFPRV110 As BE_UFPRV010_UFPRV110) As List(Of BE_UFPRV010_UFPRV110)
        Try
            Dim strEnviaCorreo As String = ConfigurationManager.AppSettings("EnviaCorreo").ToString
            Dim strLibro As String = String.Empty

            If strEnviaCorreo = String.Empty Then
                strLibro = ConfigurationManager.AppSettings("cnLIBR08").ToString()
            Else
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{}}

            Dim liBEUFPRV010_UFPRV110 As New List(Of BE_UFPRV010_UFPRV110)

            Dim strConsulta As String = Concat("SELECT   X.REFEREN,SUM(X.IMPDOL) AS IMPDOL ", _
                                               "FROM     ( ", _
                                               "SELECT   A.REFEREN,A.INDSIT,A.SISTEMA,A.CLIE,A.CLIAD,A.FECDOC,A.CLPR,A.SUNTIP,A.SUNPRE,A.SUNNUM,A.NUMDOC ", _
                                               "         ,D.CTTNO1 ", _
                                               "         ,COALESCE(C.CNTRD8,0) AS CNTRD8 ", _
                                             "         ,E.CUENTA,E.ASIEN ", _
                                             "         ,CASE E.ASIEN ", _
                                             "            WHEN  'A' ", _
                                             "               THEN  E.IMPDOL ", _
                                             "            ELSE     E.IMPDOL * (-1) ", _
                                             "         END IMPDOL ", _
                                             "         ,'1' AS ORIGEN ", _
                                             "FROM     ", strLibro, ".UFPRV010 A ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".UFPRV020 E ", _
                                             "         ON    E.CLPR = A.CLPR ", _
                                             "         AND   E.SUNTIP = A.SUNTIP ", _
                                             "         AND   E.SUNNUM = A.SUNNUM ", _
                                             "         AND   E.SUNPRE = A.SUNPRE ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".EMPEQPI0 D ", _
                                             "         ON    D.IDNO1 = A.REFEREN ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".EMPCTRE0 B ", _
                                             "         ON    B.IDNO1 = D.IDNO1 ", _
                                             "         AND   B.CTTNO1 = LEFT(A.NUMDOC,6) ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".empctrh0 C ", _
                                             "         ON    C.CTTNO1 = B.CTTNO1 ", _
                                             "WHERE    TRIM(A.NSUNTI) = '' ", _
                                             "AND      TRIM(A.INDSIT) <> '*' ", _
                                             "AND      TRIM(A.CLPR) = '", pi_BEUFPRV010_UFPRV110.strCLPR, "' ", _
                                             "AND      TRIM(A.SUNTIP) = '", pi_BEUFPRV010_UFPRV110.strSUNTIP, "' ", _
                                             "AND      A.SUNPRE = ", pi_BEUFPRV010_UFPRV110.strSUNPRE, " ", _
                                             "AND      A.SUNNUM = ", pi_BEUFPRV010_UFPRV110.strSUNNUM, " ", _
                                             "AND      (LEFT(E.CUENTA,2) IN ('70','72','74','49') ", _
                                             "         OR    E.CUENTA IN ('762100','762200','122210')) ", _
                                             "             ", _
                                             "         UNION ALL ", _
                                             "             ", _
                                             "SELECT   A.REFEREN,A.INDSIT,A.SISTEMA,A.CLIE,A.CLIAD,A.FECDOC,A.CLPR,A.SUNTIP,A.SUNPRE,A.SUNNUM,A.NUMDOC ", _
                                             "         ,D.CTTNO1 ", _
                                             "         ,COALESCE(C.CNTRD8,0) AS CNTRD8 ", _
                                             "         ,E.CUENTA,E.ASIEN ", _
                                             "         ,CASE E.ASIEN ", _
                                             "            WHEN  'A' ", _
                                             "               THEN  E.IMPDOL ", _
                                             "            ELSE     E.IMPDOL * (-1) ", _
                                             "         END IMPDOL ", _
                                             "         ,'2' AS ORIGEN ", _
                                             "FROM     ", strLibro, ".UFPRV110 A ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".UFPRV120 E ", _
                                             "         ON    E.CLPR = A.CLPR ", _
                                             "         AND   E.SUNTIP = A.SUNTIP ", _
                                             "         AND   E.SUNNUM = A.SUNNUM ", _
                                             "         AND   E.SUNPRE = A.SUNPRE ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".EMPEQPI0 D ", _
                                             "         ON    D.IDNO1 = A.REFEREN ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".EMPCTRE0 B ", _
                                             "         ON    B.IDNO1 = D.IDNO1 ", _
                                             "         AND   B.CTTNO1 = LEFT(A.NUMDOC,6) ", _
                                             "      LEFT OUTER JOIN      ", strLibro, ".empctrh0 C ", _
                                             "         ON    C.CTTNO1 = B.CTTNO1 ", _
                                             "WHERE    TRIM(A.NSUNTI) = '' ", _
                                             "AND      TRIM(A.INDSIT) <> '*' ", _
                                             "AND      TRIM(A.CLPR) = '", pi_BEUFPRV010_UFPRV110.strCLPR, "' ", _
                                             "AND      TRIM(A.SUNTIP) = '", pi_BEUFPRV010_UFPRV110.strSUNTIP, "' ", _
                                             "AND      A.SUNPRE = ", pi_BEUFPRV010_UFPRV110.strSUNPRE, " ", _
                                             "AND      A.SUNNUM = ", pi_BEUFPRV010_UFPRV110.strSUNNUM, " ", _
                                             "AND      (LEFT(E.CUENTA,2) IN ('70','72','74','49') ", _
                                             "         OR    E.CUENTA IN ('762100','762200','122210')) ", _
                                             "                ", _
                                             ") X ", _
                                             "GROUP BY X.REFEREN")
            'EMPCTRE0 Y empctrh0 -> ARCHIVOS DE CONTRATOS
            'SOLO TRAEMOS EL PRIMER REGISTRO ORDENADO POR FECHA DE MAYOR A MENOR

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUFPRV010_UFPRV110, objArrParametros)

            Return liBEUFPRV010_UFPRV110
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_UFPRV010_UFPRV110_Factura_NoOrden(ByVal pi_BEUFPRV010_UFPRV110 As BE_UFPRV010_UFPRV110) As List(Of BE_UFPRV010_UFPRV110)
        Try
            Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

            If ConfigurationManager.AppSettings("EnviaCorreo").ToString = "Test" Then
                strLibro = "LIBT99"
            ElseIf ConfigurationManager.AppSettings("EnviaCorreo").ToString = "TestQA" Then
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{}}

            Dim liBEUFPRV010_UFPRV110 As New List(Of BE_UFPRV010_UFPRV110)

            Dim strConsulta As String = Concat("SELECT TRIM(A.REFEREN) AS REFEREN, A.SISTEMA, A.CLIE, A.CLIAD, A.FECDOC, A.SUNTIP, A.SUNPRE, A.SUNNUM, TRIM(A.NUMDOC) AS NUMDOC, TRIM(A.NUMIAS) AS NUMIAS ", _
                                               "      , E.CUENTA, E.ASIEN, E.IMPDOL ", _
                                               "      , '010' AS ORIGEN ", _
                                               "FROM ", strLibro, ".UFPRV010 A ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".UFPRV020 E ON E.CLPR = A.CLPR AND E.SUNTIP = A.SUNTIP AND E.SUNNUM = A.SUNNUM AND E.SUNPRE = A.SUNPRE ", _
                                               "WHERE A.SUNTIP IN ('FA', 'BO') ", _
                                               "      AND TRIM(A.NSUNTI) = '' ", _
                                               "      AND TRIM(A.INDSIT) <> '*' ", _
                                               "      AND A.CLPR = 'CR", _
                                               "      AND A.SUNTIP = '", pi_BEUFPRV010_UFPRV110.strSUNTIP, "' ", _
                                               "      AND A.SUNPRE = ", pi_BEUFPRV010_UFPRV110.strSUNPRE, " ", _
                                               "      AND A.SUNNUM = ", pi_BEUFPRV010_UFPRV110.strSUNNUM, " ", _
                                               "      AND E.ASIEN = 'A' ", _
                                               "      AND (LEFT(E.CUENTA, 2) IN ('70', '72', '74', '49') OR E.CUENTA IN ('762100', '762200', '122210')) ", _
                                               "UNION ALL ", _
                                               "SELECT TRIM(A.REFEREN) AS REFEREN, A.SISTEMA, A.CLIE, A.CLIAD, A.FECDOC, A.SUNTIP, A.SUNPRE, A.SUNNUM, TRIM(A.NUMDOC) AS NUMDOC, TRIM(A.NUMIAS) AS NUMIAS ", _
                                               "      , E.CUENTA, E.ASIEN, E.IMPDOL ", _
                                               "      , '110' AS ORIGEN ", _
                                               "FROM ", strLibro, ".UFPRV110 A ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".UFPRV120 E ON E.CLPR = A.CLPR AND E.SUNTIP = A.SUNTIP AND E.SUNNUM = A.SUNNUM AND E.SUNPRE = A.SUNPRE ", _
                                               "WHERE A.SUNTIP IN ('FA', 'BO') ", _
                                               "      AND TRIM(A.NSUNTI) = '' ", _
                                               "      AND TRIM(A.INDSIT) <> '*' ", _
                                               "      AND A.CLPR = 'CR' ", _
                                               "      AND A.SUNTIP = '", pi_BEUFPRV010_UFPRV110.strSUNTIP, "' ", _
                                               "      AND A.SUNPRE = ", pi_BEUFPRV010_UFPRV110.strSUNPRE, " ", _
                                               "      AND A.SUNNUM = ", pi_BEUFPRV010_UFPRV110.strSUNNUM, " ", _
                                               "      AND E.ASIEN = 'A' ", _
                                               "      AND (LEFT(E.CUENTA, 2) IN ('70', '72', '74', '49') OR E.CUENTA IN ('762100', '762200', '122210')) ", _
                                               "ORDER BY FECDOC DESC, ORIGEN DESC, CNTRD8 DESC")

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUFPRV010_UFPRV110, objArrParametros)

            Return liBEUFPRV010_UFPRV110
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_UFPRV010_UFPRV110_Factura(ByVal pi_BEUFPRV010_UFPRV110 As BE_UFPRV010_UFPRV110) As List(Of BE_UFPRV010_UFPRV110)
        Try
            Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

            If ConfigurationManager.AppSettings("EnviaCorreo").ToString = "Test" Then
                strLibro = "LIBT99"
            ElseIf ConfigurationManager.AppSettings("EnviaCorreo").ToString = "TestQA" Then
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{}}

            Dim liBEUFPRV010_UFPRV110 As New List(Of BE_UFPRV010_UFPRV110)

            Dim strConsulta As String = Concat("SELECT TRIM(A.REFEREN) AS REFEREN, A.SISTEMA, A.CLIE, A.CLIAD, A.FECDOC, A.SUNTIP, A.SUNPRE, A.SUNNUM, TRIM(A.NUMDOC) AS NUMDOC, TRIM(A.NUMIAS) AS NUMIAS ", _
                                               "      , D.CTTNO1 ", _
                                               "      , COALESCE(C.CNTRD8, 0) AS CNTRD8 ", _
                                               "      , E.CUENTA, E.ASIEN, E.IMPDOL ", _
                                               "      , F.INVI ", _
                                               "      , '010' AS ORIGEN ", _
                                               "FROM ", strLibro, ".UFPRV010 A ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".UFPRV020 E ON E.CLPR = A.CLPR AND E.SUNTIP = A.SUNTIP AND E.SUNNUM = A.SUNNUM AND E.SUNPRE = A.SUNPRE ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".EMPEQPD0 F ON F.IDNO1 = A.REFEREN ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".EMPEQPI0 D ON D.IDNO1 = A.REFEREN ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".EMPCTRE0 B ON B.IDNO1 = D.IDNO1 AND B.CTTNO1 = LEFT(A.NUMDOC, 6) ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".empctrh0 C ON C.CTTNO1 = B.CTTNO1 ", _
                                               "WHERE A.SUNTIP IN ('FA', 'BO') ", _
                                               "      AND TRIM(A.NSUNTI) = '' ", _
                                               "      AND TRIM(A.INDSIT) <> '*' ", _
                                               "      AND A.CLPR = '", pi_BEUFPRV010_UFPRV110.strCLPR, "' ", _
                                               "      AND A.SUNTIP = '", pi_BEUFPRV010_UFPRV110.strSUNTIP, "' ", _
                                               "      AND A.SUNPRE = ", pi_BEUFPRV010_UFPRV110.strSUNPRE, " ", _
                                               "      AND A.SUNNUM = ", pi_BEUFPRV010_UFPRV110.strSUNNUM, " ", _
                                               "      AND TRIM(A.NUMIAS) = '", pi_BEUFPRV010_UFPRV110.strNUMIAS, "' ", _
                                               "      AND E.ASIEN = 'A' ", _
                                               "      AND (LEFT(E.CUENTA, 2) IN ('70', '72', '74', '49') OR E.CUENTA IN ('762100', '762200', '122210')) ", _
                                               "UNION ALL ", _
                                               "SELECT TRIM(A.REFEREN) AS REFEREN, A.SISTEMA, A.CLIE, A.CLIAD, A.FECDOC, A.SUNTIP, A.SUNPRE, A.SUNNUM, TRIM(A.NUMDOC) AS NUMDOC, TRIM(A.NUMIAS) AS NUMIAS ", _
                                               "      , D.CTTNO1 ", _
                                               "      , COALESCE(C.CNTRD8,0) AS CNTRD8 ", _
                                               "      , E.CUENTA, E.ASIEN, E.IMPDOL ", _
                                               "      , F.INVI ", _
                                               "      , '110' AS ORIGEN ", _
                                               "FROM ", strLibro, ".UFPRV110 A ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".UFPRV120 E ON E.CLPR = A.CLPR AND E.SUNTIP = A.SUNTIP AND E.SUNNUM = A.SUNNUM AND E.SUNPRE = A.SUNPRE ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".EMPEQPD0 F ON F.IDNO1 = A.REFEREN ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".EMPEQPI0 D ON D.IDNO1 = A.REFEREN ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".EMPCTRE0 B ON B.IDNO1 = D.IDNO1 AND B.CTTNO1 = LEFT(A.NUMDOC, 6) ", _
                                               "      LEFT OUTER JOIN ", strLibro, ".empctrh0 C ON C.CTTNO1 = B.CTTNO1 ", _
                                               "WHERE A.SUNTIP IN ('FA', 'BO') ", _
                                               "      AND TRIM(A.NSUNTI) = '' ", _
                                               "      AND TRIM(A.INDSIT) <> '*' ", _
                                               "      AND A.CLPR = '", pi_BEUFPRV010_UFPRV110.strCLPR, "' ", _
                                               "      AND A.SUNTIP = '", pi_BEUFPRV010_UFPRV110.strSUNTIP, "' ", _
                                               "      AND A.SUNPRE = ", pi_BEUFPRV010_UFPRV110.strSUNPRE, " ", _
                                               "      AND A.SUNNUM = ", pi_BEUFPRV010_UFPRV110.strSUNNUM, " ", _
                                               "      AND TRIM(A.NUMIAS) = '", pi_BEUFPRV010_UFPRV110.strNUMIAS, "' ", _
                                               "      AND E.ASIEN = 'A' ", _
                                               "      AND (LEFT(E.CUENTA, 2) IN ('70', '72', '74', '49') OR E.CUENTA IN ('762100', '762200', '122210')) ", _
                                               "ORDER BY FECDOC DESC, ORIGEN DESC, CNTRD8 DESC")

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUFPRV010_UFPRV110, objArrParametros)

            Return liBEUFPRV010_UFPRV110
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
