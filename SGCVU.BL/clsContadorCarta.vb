Imports SGCVU.BE
Imports SGCVU.DA

Public Class clsContadorCarta
    Public Shared Function fn_Transaction_ContadorCarta(ByVal pi_BEContadorCarta As BE_ContadorCarta) As List(Of BE_ContadorCarta)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL


            Dim liBEContadorCarta As New List(Of BE_ContadorCarta)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_T_CONTADOR_CARTA", True, liBEContadorCarta, liEnt_Parametro)

            Return liBEContadorCarta
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
