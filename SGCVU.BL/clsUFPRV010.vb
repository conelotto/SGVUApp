Imports System.Configuration
Imports System.String
Imports SGCVU.DA
Imports SGCVU.BE
Imports IBM.Data.DB2.iSeries

Public Class clsUFPRV010

    Public Shared Function fn_Select_ListaUFPRV010(ByVal pi_BEUFPRV010 As BE_UFPRV010) As List(Of BE_UFPRV010)
        Try
            Dim strEnviaCorreo As String = ConfigurationManager.AppSettings("EnviaCorreo").ToString
            Dim strLibro As String = String.Empty

            If strEnviaCorreo = String.Empty Then
                strLibro = ConfigurationManager.AppSettings("cnLIBR08").ToString()
            Else
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{"ORDEN", iDB2DbType.iDB2VarChar, pi_BEUFPRV010.str_REFEREN, Nothing}}

            Dim liBEUFPRV010 As New List(Of BE_UFPRV010)

            Dim strConsulta As String = Concat("SELECT   A.REFEREN,A.INDSIT,A.CLIE,A.CLIAD,A.FECDOC,A.SUNTIP,A.SUNPRE,A.SUNNUM,A.NUMDOC ", _
                                               "         ,D.CTTNO1 ", _
                                               "         ,COALESCE(C.CNTRD8,'0') AS CNTRD8 ", _
                                               "FROM     ", strLibro, ".UFPRV010 A ", _
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
                                               "AND      TRIM(A.REFEREN) = '", pi_BEUFPRV010.str_REFEREN, "' ", _
                                               "ORDER BY COALESCE(C.CNTRD8,'0') DESC ", _
                                               "FETCH FIRST 1 ROWS ONLY ")
            'EMPCTRE0 Y empctrh0 -> ARCHIVOS DE CONTRATOS
            'SOLO TRAEMOS EL PRIMER REGISTRO ORDENADO POR FECHA DE MAYOR A MENOR

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUFPRV010, objArrParametros)

            Return liBEUFPRV010
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_ListaUFPRV010_x_NroSunat(ByVal pi_BEUFPRV010 As BE_UFPRV010, ByVal pi_strIndicadorElectronica As String) As List(Of BE_UFPRV010)
        Try
            Dim strEnviaCorreo As String = ConfigurationManager.AppSettings("EnviaCorreo").ToString
            Dim strLibro As String = String.Empty

            If strEnviaCorreo = String.Empty Then
                strLibro = ConfigurationManager.AppSettings("cnLIBR08").ToString()
            Else
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{"ORDEN", iDB2DbType.iDB2VarChar, pi_BEUFPRV010.str_REFEREN, Nothing}}

            Dim liBEUFPRV010 As New List(Of BE_UFPRV010)
            Dim strTipoFA As String
            If pi_strIndicadorElectronica = "S" Then
                strTipoFA = "'FA','BO'"
            Else
                strTipoFA = "'CR'"
            End If

            Dim strConsulta As String = Concat("SELECT   A.REFEREN,A.INDSIT,A.CLIE,A.CLIAD,A.FECDOC,A.SUNTIP,A.SUNPRE,A.SUNNUM,A.NUMDOC ", _
                                               "         ,D.CTTNO1 ", _
                                               "         ,COALESCE(C.CNTRD8,0) AS CNTRD8 ", _
                                               "FROM     ", strLibro, ".UFPRV010 A ", _
                                               "      LEFT OUTER JOIN      ", strLibro, ".EMPEQPI0 D ", _
                                               "         ON    D.IDNO1 = A.REFEREN ", _
                                               "      LEFT OUTER JOIN      ", strLibro, ".EMPCTRE0 B ", _
                                               "         ON    B.IDNO1 = D.IDNO1 ", _
                                               "         AND   B.CTTNO1 = LEFT(A.NUMDOC,6) ", _
                                               "      LEFT OUTER JOIN      ", strLibro, ".empctrh0 C ", _
                                               "         ON    C.CTTNO1 = B.CTTNO1 ", _
                                               "WHERE    TRIM(A.NSUNTI) = '' ", _
                                               "AND      TRIM(A.INDSIT) <> '*' ", _
                                               "AND      TRIM(A.SUNTIP) = '", pi_BEUFPRV010.str_SUNTIP, "' ", _
                                               "AND      A.SUNPRE = ", pi_BEUFPRV010.str_SUNPRE.Trim, " ", _
                                               "AND      A.SUNNUM = ", pi_BEUFPRV010.str_SUNNUM.Trim, " ", _
                                               "AND      TRIM(A.CLPR) in (", strTipoFA, ") ", _
                                               "ORDER BY COALESCE(C.CNTRD8,0) DESC ", _
                                               "FETCH FIRST 1 ROWS ONLY ")
            'EMPCTRE0 Y empctrh0 -> ARCHIVOS DE CONTRATOS
            'SOLO TRAEMOS EL PRIMER REGISTRO ORDENADO POR FECHA DE MAYOR A MENOR

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUFPRV010, objArrParametros)

            Return liBEUFPRV010
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
