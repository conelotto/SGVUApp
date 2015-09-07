Imports SGCVU.DTO
Imports SGCVU.DA
Imports System.Configuration
Imports System.String

Public Class clsSalesRecordCardFecha

    Public Shared Function fn_Select_FechaSalesRecordCard(ByVal strOrdenAsignada As String, ByVal strClienteFactId As String) As String
        Try
            Dim strLibro As String = clsAS400.fn_ObtenerNombreLibro()
            Dim objArrParametros(,) As Object = {{}}

            Dim strScriptSQL As String = String.Empty

            strScriptSQL = Concat(" SELECT A.SCTRD8 AS FEC_SRC FROM  ", strLibro, ".EMPDTRF0 A ", "WHERE A.EQMFSN = '", strOrdenAsignada, "' AND A.CUNO = '", strClienteFactId, "' AND A.SCTRNI = 'T' ")
            Return clsAS400.fn_EjecutarSelect(Of DTO_Consulta_Inventario_Maquina)(strScriptSQL, objArrParametros)

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_FechaSalesRecordCardNull() As List(Of DTO_Consulta_FechasSalesRecordCard)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim liBeProgramas As New List(Of DTO_Consulta_FechasSalesRecordCard)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Programas", True, liBeProgramas, liBEParametro)

            Return liBeProgramas
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
