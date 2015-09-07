Imports System.Configuration
Imports SGCVU.BE
Imports IBM.Data.DB2.iSeries
Imports System.String
Imports SGCVU.DA

Public Class clsUMPTBAD0

    Public Shared Function fn_Select_ListaUMPTBAD0(ByVal pi_BEUMPTBAD0 As BE_UMPTBAD0) As List(Of BE_UMPTBAD0)
        Try
            Dim strEnviaCorreo As String = ConfigurationManager.AppSettings("EnviaCorreo").ToString
            Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

            If ConfigurationManager.AppSettings("EnviaCorreo").ToString = "Test" Then
                strLibro = "LIBT99"
            ElseIf ConfigurationManager.AppSettings("EnviaCorreo").ToString = "TestQA" Then
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{}}

            Dim liBEUMPTBAD0 As New List(Of BE_UMPTBAD0)
            'MODIFICADO  : 31/07/2015
            'POR         : Carlos E.
            'Descripción : Se modificó la consulta para filtrar por n° serie o modelo 

            Dim strConsulta As String = String.Empty

            If pi_BEUMPTBAD0.int_TipoBusqueda = 2 Then 'BUSQUEDA POR MODELO
                strConsulta = Concat("SELECT CORP, CIA, TRIM(CODADI) AS CODADI, TRIM(PMODEL) AS PMODEL, TRIM(PREFIJ) AS PREFIJ, MONTO ", _
                                               "FROM ", strLibro, ".UMPTBAD0 ", _
                                               "WHERE TRIM(CODADI) = '", pi_BEUMPTBAD0.str_CODADI.Trim, "' ", _
                                               "AND TRIM(PMODEL) = '", pi_BEUMPTBAD0.str_PMODEL.Trim, "' ")
            Else 'BUSQUEDA POR N° SERIE
                strConsulta = Concat("SELECT CORP, CIA, TRIM(CODADI) AS CODADI, TRIM(PMODEL) AS PMODEL, TRIM(PREFIJ) AS PREFIJ, MONTO ", _
                                               "FROM ", strLibro, ".UMPTBAD0 ", _
                                               "WHERE TRIM(CODADI) = '", pi_BEUMPTBAD0.str_CODADI.Trim, "' ", _
                                               "AND TRIM(PREFIJ) = '", pi_BEUMPTBAD0.str_PREFIJ.Trim, "' ")
            End If

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUMPTBAD0, objArrParametros)

            Return liBEUMPTBAD0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
