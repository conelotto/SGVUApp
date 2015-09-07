Imports SGCVU.BE
Imports SGCVU.DTO
Imports SGCVU.EX
Imports System.Transactions

Public Class cmpReserva

    Private BEReserva As BE_Reserva

    Private liStrOdenes As IList(Of String)

    Private strOrden As String
    Private loginUsuario As String

    Public Sub New(ByVal pi_DTOReserva As DTO_Reserva, ByVal pi_strUsuario As String)
        BEReserva = New BE_Reserva()

        With BEReserva
            .str_OrdenAsignada = pi_DTOReserva.ordenAsignada
            .str_ReservaClienteId = pi_DTOReserva.clienteId
            .str_ReservaVendedorId = pi_DTOReserva.vendedorId
            .str_ReservaSucursal = "sucursal DEMO"
            .det_ReservaFecha = pi_DTOReserva.fechaNegociacion
            .det_ValidezReservaFecha = pi_DTOReserva.fechaLimiteReserva
            .str_ReservaUsuarioId = pi_strUsuario
            .str_UsuarioCreacion = pi_strUsuario
            .str_ClienteDesc = pi_DTOReserva.clienteDesc
            .str_VendedorDesc = pi_DTOReserva.vendedorDesc
            .str_Oportunidad = pi_DTOReserva.oportunidad
            .str_Observaciones = pi_DTOReserva.observaciones
        End With

        loginUsuario = pi_strUsuario
    End Sub

    Public Sub New(ByVal pi_liStrOrdenes As IList(Of String), ByVal pi_strUsuario As String)
        liStrOdenes = pi_liStrOrdenes
        loginUsuario = pi_strUsuario
    End Sub

    Public Sub New(ByVal pi_strOrden As String, ByVal pi_strUsuario As String)
        strOrden = pi_strOrden
        loginUsuario = pi_strUsuario
    End Sub

    Public Sub IngresarReserva()
        Dim BEAlerta As BE_Alertas = New BE_Alertas()

        Dim mensaje As String = ObtenerTextoCreacionReserva()
        mensaje = mensaje.Replace("@MAQUINA", BEReserva.str_OrdenAsignada)

        With BEAlerta
            .str_MensajeAsunto = "Creación de Reserva"
            .str_MensajeContenido = mensaje
        End With

        Dim resultado As String = clsReserva.fn_Insert_Reserva(BEReserva, BEAlerta)

        If resultado <> "1" Then
            Throw New Exception("Error al ejecutar el procedimiento de registrar Reserva.")
        End If
    End Sub

    Public Sub AnularReservas()
        Dim mensaje As String = ObtenerTextoAnulacionReserva()

        Dim BEAlerta As BE_Alertas = New BE_Alertas()
        With BEAlerta
            .str_MensajeAsunto = "Anulación de Reserva"
            .str_UsuarioRegistro = loginUsuario
        End With

        Dim dicEstados As New Dictionary(Of String, String)
        For Each orden As String In liStrOdenes
            dicEstados.Add(orden, ObtenerEstadoMaquina(orden))
        Next

        Using scope As New TransactionScope()
            For Each orden As String In liStrOdenes
                BEAlerta.str_MensajeContenido = mensaje.Replace("@MAQUINA", orden)

                If clsReserva.fn_Update_Anular_Reserva(orden, dicEstados(orden), BEAlerta) <> "1" Then
                    Throw New Exception(String.Format("Error al ejecutar el procedimiento de Anular Reserva para la Máquina {0}.", orden))
                End If
            Next

            scope.Complete()
        End Using
    End Sub

    Public Sub AnularReservaPorAsignacion()
        Dim mensaje As String = ObtenerTextoAnulacionReserva()

        Dim BEAlerta As BE_Alertas = New BE_Alertas()
        With BEAlerta
            .str_MensajeAsunto = "Anulación de Reserva"
            .str_MensajeContenido = mensaje.Replace("@MAQUINA", strOrden)
            .str_UsuarioRegistro = loginUsuario
        End With

        If clsReserva.fn_Update_Anular_Reserva(strOrden, "A", BEAlerta) <> "1" Then
            Throw New Exception(String.Format("Error al ejecutar el procedimiento de Anular Reserva para la Máquina {0}.", strOrden))
        End If
    End Sub

    Private Function ObtenerEstadoMaquina(ByVal pi_strOrden As String) As String
        Dim estadoMaquina As String = "N"

        Dim liDTOConsultaInventarioMaquina As List(Of DTO_Consulta_Inventario_Maquina)

        liDTOConsultaInventarioMaquina = clsMaquina.fn_Select_Maquina_Estado_LIBRE_TRANSITO(pi_strOrden)
        If liDTOConsultaInventarioMaquina.Count > 0 Then
            estadoMaquina = If(liDTOConsultaInventarioMaquina(0).EstadoMaquina <> "T", "L", "T")
        End If

        Return estadoMaquina
    End Function

    Private Function ObtenerTextoCreacionReserva() As String
        Return "<p style='font-size: 12px; font-family: arial'>Se creó la reserva de la Máquina @MAQUINA.</p>"
    End Function

    Private Function ObtenerTextoAnulacionReserva() As String
        Return "<p style='font-size: 12px; font-family: arial'>Se anuló la reserva de la Máquina @MAQUINA.</p>"
    End Function

End Class