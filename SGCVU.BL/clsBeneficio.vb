Imports SGCVU.BE
Imports SGCVU.DA
Imports System.Data.Common

Public Class clsBeneficio

    Public Shared Function fn_Select_Beneficio(ByVal pi_BEBeneficio As BE_Beneficio) As List(Of BE_Beneficio)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BeneficioDesc"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEBeneficio.str_BeneficioDesc.GetType)
                .strSourceColumn = pi_BEBeneficio.str_BeneficioDesc
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ClaseId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEBeneficio.int_ClaseId.GetType)
                .strSourceColumn = pi_BEBeneficio.int_ClaseId
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SAP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEBeneficio.str_SAPCalculado.GetType)
                .strSourceColumn = pi_BEBeneficio.str_SAPCalculado
            End With
            liBEParametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SISTEMA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEBeneficio.str_Sistema.GetType)
                .strSourceColumn = pi_BEBeneficio.str_Sistema
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEBeneficio As New List(Of BE_Beneficio)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_Tipo_Bono", True, liBEBeneficio, liBEParametro)

            Return liBEBeneficio
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_BeneficioArchivo(ByVal pi_BEBeneficioArchivo As BE_BeneficioArchivo) As List(Of BE_BeneficioArchivo)
        Try
            Dim liBEParametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BeneficioId"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEBeneficioArchivo.int_BeneficioId.GetType)
                .strSourceColumn = pi_BEBeneficioArchivo.int_BeneficioId
            End With
            liBEParametro.Add(EntParametroSQL)

            Dim liBEBeneficioArchivo As New List(Of BE_BeneficioArchivo)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_BeneficioArchivo", True, liBEBeneficioArchivo, liBEParametro)

            Return liBEBeneficioArchivo

        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
