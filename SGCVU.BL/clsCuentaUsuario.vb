Imports System.String
Imports IBM.Data.DB2.iSeries
Imports System.Configuration
Imports SGCVU.BE
Imports SGCVU.DA
Public Class clsCuentaUsuario
    Public Shared Function fn_Select_Cuenta(ByVal pi_strIdCuenta As String) As List(Of BE_CuentaUsuario2)
        Try
            Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

            Dim objArrParametros(,) As Object = {{"ORDEN", iDB2DbType.iDB2VarChar, String.Empty, Nothing}}


            Dim liBECuentaUsuario As New List(Of BE_CuentaUsuario2)

            Dim strConsulta As String = Concat("SELECT   '' AS IdUsuario ", _
                                               "         ,TRIM(A.CUNO) AS IdCuenta ", _
                                               "         ,TRIM(B.CUNM) || TRIM(B.CUNM2) AS CuentaDesc ", _
                                               "FROM     ", strLibro, ".EMPEDRF0 A ", _
                                               "      LEFT OUTER JOIN      ", strLibro, ".CIPNAME0 B ", _
                                               "         ON    TRIM(B.CUNO) = TRIM(A.CUNO) ", _
                                               "WHERE    LEFT(TRIM(A.CUNO),1) <> '*' ", _
                                               "AND      LEFT(TRIM(B.CUNM),1) <> '*' ", _
                                               "AND      TRIM(A.CUNO) = '", pi_strIdCuenta, "'")

            clsAS400.fn_EjecutarSelect(strConsulta, liBECuentaUsuario, objArrParametros)

            Return liBECuentaUsuario
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Function
End Class
