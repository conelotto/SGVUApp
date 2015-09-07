Imports SGCVU.BE
Imports SGCVU.DA
Imports SGCVU.DTO

Public Class clsExpediente_DocumentosAdjuntos

    Public Shared Function fn_Select_ExpedienteDocumentosAdjuntos_ByKey(ByVal Filter As DTO_SearchParameters) As List(Of BE_Expediente_DocumentosAdjuntos)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ExpedienteId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(Filter.intAttachedFieldId.GetType)
                .strSourceColumn = Filter.intAttachedFieldId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBeExpedienteDocAdj As New List(Of BE_Expediente_DocumentosAdjuntos)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_ExpedienteDocumentosAdjuntos_ById", True, liBeExpedienteDocAdj, liBEParametro)
            Return liBeExpedienteDocAdj

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_ExpedienteDocumentosAdjuntos_ByApoyoId(ByVal pi_BeExpedienteDocAdj As BE_Expediente_DocumentosAdjuntos) As List(Of BE_Expediente_DocumentosAdjuntos)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeExpedienteDocAdj.int_ApoyoId.GetType)
                .strSourceColumn = pi_BeExpedienteDocAdj.int_ApoyoId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBeExpedienteDocAdj As New List(Of BE_Expediente_DocumentosAdjuntos)
            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_ExpedienteDocumentosAdjuntos_ByApoyoId", True, liBeExpedienteDocAdj, liBEParametro)
            Return liBeExpedienteDocAdj

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_ExpedienteDocumentosAdjuntos(ByVal pi_BeExpedienteDocAdj As BE_Expediente_DocumentosAdjuntos) As String

        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ApoyoId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeExpedienteDocAdj.int_ApoyoId.GetType)
                .strSourceColumn = pi_BeExpedienteDocAdj.int_ApoyoId
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ArchivoNombre"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeExpedienteDocAdj.str_ArchivoNombre.GetType)
                .strSourceColumn = pi_BeExpedienteDocAdj.str_ArchivoNombre
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ArchivoAdjunto"
                .typDbType = DbType.Binary
                .byteSourceColumn = pi_BeExpedienteDocAdj.byte_ArchivoAdjunto
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@UsuarioCreacion"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BeExpedienteDocAdj.str_UsuarioCreacion.GetType)
                .strSourceColumn = pi_BeExpedienteDocAdj.str_UsuarioCreacion
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_ExpedienteDocumentosAdjuntos", True, strReturn, liBEParametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn

        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class
