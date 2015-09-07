Imports SGCVU.BE
Imports System.Linq
Imports System.Transactions

Public Class cmpMaquinaInventario

    Private liBEMaquina As IList(Of BE_Maquina)

    Private loginUsuario As String

    Public Sub New(ByVal pi_strUsuario As String, ByVal pi_ordenes As IList(Of String))
        loginUsuario = pi_strUsuario

        liBEMaquina = New List(Of BE_Maquina)
        For Each item As String In pi_ordenes
            liBEMaquina.Add(clsMaquina.fn_Select_Maquina_Orden(item))
        Next
        liBEMaquina = (From m In liBEMaquina Where m IsNot Nothing Select m).ToList()
    End Sub

    Public Sub SolicitarLevante()
        Dim resultado As String

        Using scope As New TransactionScope()
            For Each maquina As BE_Maquina In liBEMaquina
                resultado = clsMaquina.fn_Update_SolicitoLevante_Maquina(maquina.str_OrdenAsignada, ObtenerBEAlertaLevante(maquina))
                If resultado <> "1" Then
                    Throw New Exception(String.Format("Error al momento de ejecutar el procedimiento de Solicitar Levante. Máquina {0}", maquina.str_OrdenAsignada))
                End If
            Next

            scope.Complete()
        End Using
    End Sub

    Private Function ObtenerBEAlertaLevante(ByVal pi_Maquina As BE_Maquina) As BE_Alertas
        Dim BEAlerta As BE_Alertas = New BE_Alertas()

        Dim mensaje As String = ObtenerTextoAlertaLevante()
        mensaje = mensaje.Replace("@MAQUINA", pi_Maquina.str_OrdenAsignada)

        With BEAlerta
            .str_MensajeAsunto = "Solicitud de Levante"
            .str_MensajeContenido = mensaje
            .str_UsuarioRegistro = loginUsuario
        End With

        Return BEAlerta
    End Function

    Private Function ObtenerTextoAlertaLevante() As String
        Return "<p style='font-size: 12px; font-family: arial'>Se solicitó Levante para la máquina @MAQUINA.</p>"
    End Function

End Class