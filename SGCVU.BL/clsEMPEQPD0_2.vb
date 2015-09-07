Imports SGCVU.BE
Imports SGCVU.DA
Imports System.Data.Common
Imports SGCVU.DTO
Imports System.Configuration
Imports IBM.Data.DB2.iSeries
Imports System.String
Public Class clsEMPEQPD0_2

    Public Shared Function fn_Select_ListaEMPEQPD0(ByVal pOrden As String) As List(Of BE_EMPEQPD2)
        Try
            Dim strEnviaCorreo As String = ConfigurationManager.AppSettings("EnviaCorreo").ToString
            Dim strLibro As String = String.Empty

            If strEnviaCorreo = String.Empty Then
                strLibro = ConfigurationManager.AppSettings("cnLIBR08").ToString()
            Else
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{"ORDEN", iDB2DbType.iDB2VarChar, pOrden, Nothing}}


            Dim liBEEMPEQPD0 As New List(Of BE_EMPEQPD2)

            Dim strConsulta As String = String.Concat("SELECT   TRIM(A.IDNO1) AS IDNO1 ", _
                                               "         ,TRIM(A.PRHDT8) AS PRHDT8 ", _
                                               "         ,TRIM(A.INVI) AS INVI ", _
                                               "         ,TRIM(A.RDMSR1) AS RDMSR1 ", _
                                               "         ,TRIM(A.CUNO) AS CUNO ", _
                                               "         ,TRIM(A.LCUNO) AS LCUNO ", _
                                               "         ,TRIM(A.PDRFDS) AS PDRFDS ", _
                                               "         ,TRIM(A.DSPMDL) AS DSPMDL ", _
                                               "         ,TRIM(A.LOC1) AS LOC1 ", _
                                               "         ,TRIM(A.CPIDNO) AS CPIDNO ", _
                                               "         ,TRIM(A.EQMFS2) AS EQMFS2 ", _
                                               "         ,TRIM(A.PRCLST) AS PRCLST ", _
                                               "FROM ", strLibro, ".EMPEQPD0 A ", _
                                               "WHERE    A.IDNO1 = '", pOrden, "'")

            clsAS400.fn_EjecutarSelect(strConsulta, liBEEMPEQPD0, objArrParametros)

            Return liBEEMPEQPD0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    'Adicionado: 20141226
    'Filtro de invi = S o Y Nivardo
    Public Shared Function fn_Select_ListaEMPEQPD0_INVISY(ByVal pi_BEEMPEQPD0 As BE_EMPEQPD2) As List(Of BE_EMPEQPD2)
        Try
            Dim strEnviaCorreo As String = ConfigurationManager.AppSettings("EnviaCorreo").ToString
            Dim strLibro As String = String.Empty

            If strEnviaCorreo = String.Empty Then
                strLibro = ConfigurationManager.AppSettings("cnLIBR08").ToString()
            Else
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{"ORDEN", iDB2DbType.iDB2VarChar, pi_BEEMPEQPD0.str_IDNO1, Nothing}}


            Dim liBEEMPEQPD0 As New List(Of BE_EMPEQPD2)

            Dim strConsulta As String = Concat("SELECT   TRIM(A.IDNO1) AS IDNO1 ", _
                                               "         ,TRIM(A.PRHDT8) AS PRHDT8 ", _
                                               "         ,TRIM(A.INVI) AS INVI ", _
                                               "         ,TRIM(A.RDMSR1) AS RDMSR1 ", _
                                               "         ,TRIM(A.CUNO) AS CUNO ", _
                                               "         ,TRIM(A.LCUNO) AS LCUNO ", _
                                               "         ,TRIM(A.PDRFDS) AS PDRFDS ", _
                                               "         ,TRIM(A.DSPMDL) AS DSPMDL ", _
                                               "         ,TRIM(A.LOC1) AS LOC1 ", _
                                               "         ,TRIM(A.CPIDNO) AS CPIDNO ", _
                                               "         ,TRIM(A.EQMFS2) AS EQMFS2 ", _
                                               "         ,TRIM(A.PRCLST) AS PRCLST ", _
                                               "FROM ", strLibro, ".EMPEQPD0 A ", _
                                               "WHERE    A.INVI IN ('S','Y') ", _
                                               "AND      A.IDNO1 = '", pi_BEEMPEQPD0.str_IDNO1, "'")

            clsAS400.fn_EjecutarSelect(strConsulta, liBEEMPEQPD0, objArrParametros)

            Return liBEEMPEQPD0
        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
