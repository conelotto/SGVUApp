Imports SGCVU.BE
Imports SGCVU.DTO
Imports SGCVU.WS
Imports System.Transactions
Imports SGCVU.EX

Public Class cmpAdministradorMaquinasAsignadas

    Private liBEMaquina As List(Of BE_Maquina)

    Public Sub New()
        liBEMaquina = clsMaquina.fn_Select_Maquina_Asignadas()
    End Sub

    Public Sub VerificarMaquinasAsignadas()
        For Each item In liBEMaquina
            item.str_EstadoMaquina = "N"
            Try
                Dim consultarRDA = New cmpConsultarRDA()
                Dim rda As ZRda = consultarRDA.ObtenerRDAAsignadoOrden(item.str_OrdenAsignada)

                If rda Is Nothing Then
                    Dim liDTOConsultaInventarioMaquina = clsMaquina.fn_Select_Maquina_Estado_LIBRE_TRANSITO(item.str_OrdenAsignada)
                    If liDTOConsultaInventarioMaquina.Count > 0 Then
                        item.str_EstadoMaquina = If(liDTOConsultaInventarioMaquina(0).EstadoMaquina <> "T", "L", "T")
                    End If

                    Dim resultado As String = clsMaquina.fn_Update_Maquina_Asignacion_Anular(item, ObtenerBEAlertaAnulacion(item), "system")
                    If resultado <> "1" Then
                        Throw New Exception(String.Format("Error al momento de Anular la ASIGNACIÓN de la Orden {0}", item.str_OrdenAsignada))
                    End If
                End If
            Catch ex As Exception
                cmpRegistroInterno.RegistrarLogInterno("ERROR", ex.Message)
            End Try
        Next
    End Sub

    Private Function ObtenerBEAlertaAnulacion(ByVal pi_BEMaquina As BE_Maquina)
        Dim BEAlerta As BE_Alertas = New BE_Alertas()

        Dim mensaje As String = ObtenerTextoAsignacionAnulada()
        mensaje = mensaje.Replace("@MAQUINA", pi_BEMaquina.str_OrdenAsignada)
        mensaje = mensaje.Replace("@PEDIDO", pi_BEMaquina.str_PedidoId)

        With BEAlerta
            .str_MensajeAsunto = "Asignación de Máquina ANULADA"
            .str_MensajeContenido = mensaje
        End With

        Return BEAlerta
    End Function

    Private Function ObtenerTextoAsignacionAnulada() As String
        Return "<p style='font-size: 12px; font-family: arial'>La Asignación de la máquina @MAQUINA (Pedido @PEDIDO) fue ANULADA.</p>"
    End Function

End Class