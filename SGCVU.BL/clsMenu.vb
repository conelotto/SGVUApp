Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsMenu

    ''' <summary>
    '''  Selecciona todos los menu padre.
    ''' </summary>
    ''' <param name="pi_BEMenu"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Select_MenuParent_ByIdModulo(ByVal pi_BEMenu As BE_Menu) As List(Of BE_Menu)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ModuloId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMenu.int_ModuloId.GetType)
                .strSourceColumn = pi_BEMenu.int_ModuloId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEMenu As New List(Of BE_Menu)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_MenuParent_ModuloId", True, liBEMenu, liBEParametro)

            Return liBEMenu
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    ''' <summary>
    ''' Selecciona todos los menu hijo.
    ''' </summary>
    ''' <param name="pi_BEMenu"></param>
    ''' <returns></returns>
    ''' <remarks></remarks>
    Public Shared Function fn_Select_MenuChild_ByIdModulo(ByVal pi_BEMenu As BE_Menu) As List(Of BE_Menu)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ModuloId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEMenu.int_ModuloId.GetType)
                .strSourceColumn = pi_BEMenu.int_ModuloId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEMenu As New List(Of BE_Menu)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_MenuChild_ModuloId", True, liBEMenu, liBEParametro)

            Return liBEMenu
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
