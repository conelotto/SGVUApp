Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsExpediente_Programas

    Public Shared Function fn_Select_ExpedienteProgramas_ByApoyo(ByVal pi_BeExpedienteProgramas As BE_Expediente_Programas) As List(Of BE_Expediente_Programas)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeExpedienteProgramas.int_ApoyoId.GetType)
                .strSourceColumn = pi_BeExpedienteProgramas.int_ApoyoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBeExpedienteProgramas As New List(Of BE_Expediente_Programas)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_ExpedienteProgramas_ByApoyo", True, liBeExpedienteProgramas, liBEParametro)
            Return liBeExpedienteProgramas

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
