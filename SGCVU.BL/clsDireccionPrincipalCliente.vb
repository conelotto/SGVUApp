Imports SGCVU.BE
Imports SGCVU.DA

Imports System.String
Imports IBM.Data.DB2.iSeries
Imports System.Configuration
Public Class clsDireccionPrincipalCliente

    Public Shared Function fn_Select_ListaDireccionPrincipalCliente(ByVal pi_BEDireccionPrincipalCliente As BE_DireccionPrincipalCliente) As List(Of BE_DireccionPrincipalCliente)
        Try
            Dim strEnviaCorreo As String = ConfigurationManager.AppSettings("EnviaCorreo").ToString
            Dim strLibro As String = String.Empty

            If strEnviaCorreo = String.Empty Then
                strLibro = ConfigurationManager.AppSettings("cnLIBR08").ToString()
            Else
                strLibro = "LIBT99"
            End If

            Dim strLPDBS As String = ConfigurationManager.AppSettings("LPDBS").ToString

            Dim objArrParametros(,) As Object = {{"CUNO", iDB2DbType.iDB2VarChar, pi_BEDireccionPrincipalCliente.str_CUNO, Nothing}}


            Dim liBEDireccionPrincipalCliente As New List(Of BE_DireccionPrincipalCliente)

            Dim strConsulta As String = Concat("SELECT    ", _
                                               "         F.CUNO as CUNO ", _
                                               "         ,F.SPADL1 as DIRECCION ", _
                                               "         ,TRIM(I.APARTADO) as COD_DEPARTAMENTO ", _
                                               "         ,I.DESCRIPE AS NOM_DEPARTAMENTO ", _
                                               "         ,TRIM(J.APARTADO) as COD_PROVINCIA ", _
                                               "         ,J.DESCRIPE AS NOM_PROVINCIA ", _
                                               "         ,LEFT(TRIM(K.APARTADO),3) as COD_DISTRITO ", _
                                               "         ,K.DESCRIPE AS NOM_DISTRITO ", _
                                               "FROM     ", strLibro, ".cipship0 F ", _
                                               "      LEFT OUTER JOIN   ", strLPDBS, ".UFPSC160 I ", _
                                               "         ON    I.TABLA = 'UGE' ", _
                                               "         AND   LEFT(I.CODIGO,3) = '604' ", _
                                               "         AND   SUBSTR(I.CODIGO, 9, 4) = '0000' ", _
                                               "         AND   TRIM(I.APARTADO) = TRIM(f.dlvste) ", _
                                               "      LEFT OUTER JOIN   ", strLPDBS, ".UFPSC160 J ", _
                                               "         ON    J.TABLA = 'UGE' ", _
                                               "         AND   LEFT(J.CODIGO,3) = '604' ", _
                                               "         AND   SUBSTR(J.CODIGO, 11, 2) = '00' ", _
                                               "         AND   SUBSTR(J.CODIGO, 9, 4) != '0000' ", _
                                               "         AND   TRIM(J.APARTADO) = TRIM(f.dlvcty) ", _
                                               "      LEFT OUTER JOIN   ", strLPDBS, ".UFPSC160 K ", _
                                               "         ON    K.TABLA = 'UGE' ", _
                                               "         AND   LEFT(K.CODIGO,3) = '604' ", _
                                               "         AND   SUBSTR(K.CODIGO, 9, 2) != '00' ", _
                                               "         AND   SUBSTR(K.CODIGO, 11, 2) != '00' ", _
                                               "         AND   TRIM(K.APARTADO) = LEFT(TRIM(f.SPADL5),3) ", _
                                               "WHERE    F.CUNO = '", pi_BEDireccionPrincipalCliente.str_CUNO, "' ", _
                                               "AND      F.SQNO8 = 0 ", _
                                               "FETCH FIRST 1 ROWS ONLY")

            clsAS400.fn_EjecutarSelect(strConsulta, liBEDireccionPrincipalCliente, objArrParametros)

            Return liBEDireccionPrincipalCliente
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
