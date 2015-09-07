Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsMaster_Table

    Public Shared Function fn_Select_MasterTable_ByKey(ByVal pi_BeMaquinaApoyo As BE_Master_Table) As List(Of BE_Master_Table)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MasterTable_Key"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeMaquinaApoyo.str_MasterTable_Key.GetType)
                .strSourceColumn = pi_BeMaquinaApoyo.str_MasterTable_Key
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBeMasterTable As New List(Of BE_Master_Table)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_MasterTable_ByKey", True, liBeMasterTable, liBEParametro)
            Return liBeMasterTable

        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
