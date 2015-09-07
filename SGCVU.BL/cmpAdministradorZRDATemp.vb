Imports SGCVU.BE
Imports SGCVU.BL
Imports System.Transactions
Imports SGCVU.EX
Imports System.Text

Public Class cmpAdministradorZRDATemp

    Public liTempZRdas As IList(Of BE_Temp_ZRda)
    Public tempZRda As BE_Temp_ZRda

    Private BEMaquinaActual As BE_Maquina
    Private BEMaquina_RDA As BE_Maquina

    Private liBeneficiosNuevos As IList(Of BE_Maquina_Beneficio)
    Private liBeneficiosModificados As IList(Of BE_Maquina_Beneficio)
    Private liBeneficiosEliminados As IList(Of BE_Maquina_Beneficio)

    Public Sub New()
        liTempZRdas = clsTemp_ZRda.fn_Select_Temp_ZRda_Estado("0")
    End Sub

    Public Sub New(ByVal pi_IdTempZRda As Integer)
        tempZRda = clsTemp_ZRda.fn_Select_Temp_ZRda_Id(pi_IdTempZRda)
    End Sub

    Public Sub ActualizarDatosTempRDAs_Maquina()
        For Each item In liTempZRdas
            Try
                tempZRda = item
                ActualizarDatosTempRDA_Maquina()
            Catch ex As Exception
                cmpRegistroInterno.RegistrarLogInterno("ERROR", ex.Message)
            End Try
        Next

        cmpRegistroInterno.RegistrarLogInterno("INFO", String.Format("Datos de los RDAs(Temporal) actualizados en las Máquinas. {0} registros obtenidos.", liTempZRdas.Count))
    End Sub

    Public Sub ActualizarDatosTempRDA_Maquina()
        If tempZRda IsNot Nothing Then
            Using scope As New TransactionScope()
                BEMaquinaActual = clsMaquina.fn_Select_Maquina_Orden(tempZRda.str_OrdAsignada)
                If BEMaquinaActual Is Nothing Then
                    Throw New Exception(String.Format("La Máquina con orden {0} no existe en el sistema de GESTION COMERCIAL", tempZRda.str_OrdAsignada))
                Else
                    BEMaquina_RDA = ObtenerObjMaquina(tempZRda)

                    If BEMaquinaActual.str_EstadoMaquina = "R" Then
                        Dim cmpReserva As cmpReserva = New cmpReserva(BEMaquina_RDA.str_OrdenAsignada, "system")
                        cmpReserva.AnularReservaPorAsignacion()
                    End If

                    Dim resultado As String = clsMaquina.fn_Update_Maquina_Asignacion(BEMaquina_RDA, "system")
                    If resultado <> "1" Then
                        Throw New Exception(String.Format("Error al momento de actualizar los datos del RDA(Temporal) a la Máquina. Pedido: {0} - Orden: {1}", BEMaquina_RDA.str_PedidoId, BEMaquina_RDA.str_OrdenAsignada))
                    Else
                        ActualizarDatosTempBeneficios()
                        RegistrarAlertaAsignacion()

                        Dim resulTemp As String = clsTemp_ZRda.fn_Update_Temp_ZRda_Estado(tempZRda.int_IdTemp_ZRda, "1")
                        If resulTemp <> "1" Then
                            Throw New Exception(String.Format("Error al momento de actualizar el estado del Temporal con Id: {0}", tempZRda.int_IdTemp_ZRda))
                        End If
                    End If

                    scope.Complete()
                End If
            End Using
        End If
    End Sub

    Private Sub ActualizarDatosTempBeneficios()
        LlenarListasBeneficios()

        Dim resultado As String = ""

        For Each item In liBeneficiosEliminados
            resultado = clsMaquina_Beneficio.fn_Delete_Maquina_Beneficio(item)
            If resultado <> "1" Then
                Throw New Exception(String.Format("Error al momento de eliminar el beneficio con código {0} de la orden {1}", item.int_BeneficioId, item.str_OrdenAsignada))
            End If
        Next

        For Each item In liBeneficiosModificados
            resultado = clsMaquina_Beneficio.fn_Update_Maquina_Beneficio(item)
            If resultado <> "1" Then
                Throw New Exception(String.Format("Error al momento de actualizar el beneficio con código {0} de la orden {1}", item.int_BeneficioId, item.str_OrdenAsignada))
            End If
        Next

        For Each item In liBeneficiosNuevos
            resultado = clsMaquina_Beneficio.fn_Insert_Maquina_Beneficio(item)
            If resultado <> "1" Then
                Throw New Exception(String.Format("Error al momento de ingresar el beneficio con código {0} de la orden {1}", item.int_BeneficioId, item.str_OrdenAsignada))
            End If
        Next
    End Sub

    Private Sub LlenarListasBeneficios()
        liBeneficiosEliminados = New List(Of BE_Maquina_Beneficio)
        liBeneficiosModificados = New List(Of BE_Maquina_Beneficio)
        liBeneficiosNuevos = New List(Of BE_Maquina_Beneficio)

        Dim liBEZTempBeneficio As List(Of BE_Temp_ZBeneficio) = clsTemp_ZBeneficio.fn_Select_Temp_ZBeneficio_IdTempZRda(tempZRda.int_IdTemp_ZRda)
        Dim liBEMaquinaBeneficio As List(Of BE_Maquina_Beneficio) = clsMaquina_Beneficio.fn_Select_Maquina_Beneficio_Orden_Pedido(tempZRda.str_OrdAsignada, tempZRda.str_IdPedido)

        For Each beneficio In liBEMaquinaBeneficio
            Dim encontroEnListaTemporal As Boolean = False

            For Each tempBeneficio In liBEZTempBeneficio
                If beneficio.int_BeneficioId = tempBeneficio.str_Codigo Then
                    encontroEnListaTemporal = True

                    'Verificar si el beneficio fue modificado
                    If beneficio.str_Descripcion <> tempBeneficio.str_Descripcion Or beneficio.dec_Monto <> tempBeneficio.int_Cantidad Then
                        Dim BEMaquinaBeneficioMod As BE_Maquina_Beneficio = New BE_Maquina_Beneficio()
                        With BEMaquinaBeneficioMod
                            .str_OrdenAsignada = beneficio.str_OrdenAsignada
                            .str_PedidoId = beneficio.int_BeneficioId
                            .int_BeneficioId = beneficio.int_BeneficioId
                            .str_Descripcion = tempBeneficio.str_Descripcion
                            .dec_Monto = tempBeneficio.int_Cantidad
                        End With
                        liBeneficiosModificados.Add(BEMaquinaBeneficioMod)
                    End If

                    liBEZTempBeneficio.Remove(tempBeneficio)

                    Exit For
                End If
            Next

            'Agregar a la lista los beneficios eliminados
            If Not encontroEnListaTemporal Then
                Dim BEMaquinaBeneficioEli As BE_Maquina_Beneficio = New BE_Maquina_Beneficio()
                With BEMaquinaBeneficioEli
                    .str_OrdenAsignada = beneficio.str_OrdenAsignada
                    .str_PedidoId = beneficio.str_PedidoId
                    .int_BeneficioId = beneficio.int_BeneficioId
                    .str_Descripcion = beneficio.str_Descripcion
                    .dec_Monto = beneficio.dec_Monto
                End With
                liBeneficiosEliminados.Add(BEMaquinaBeneficioEli)
            End If
        Next

        'Agregar a la lista los beneficios nuevos
        For Each tempBeneficio In liBEZTempBeneficio
            Dim BEMaquinaBeneficioNuevo As BE_Maquina_Beneficio = New BE_Maquina_Beneficio()
            With BEMaquinaBeneficioNuevo
                .str_OrdenAsignada = tempZRda.str_OrdAsignada
                .str_PedidoId = tempZRda.str_IdPedido
                .int_BeneficioId = tempBeneficio.str_Codigo
                .str_Descripcion = tempBeneficio.str_Descripcion
                .dec_Monto = tempBeneficio.int_Cantidad
            End With
            liBeneficiosNuevos.Add(BEMaquinaBeneficioNuevo)
        Next
    End Sub

    Private Sub RegistrarAlertaAsignacion()
        Dim textoPrincipal As String = ""
        Dim textoBeneficiosNuevos As String = ""
        Dim textoApoyo As String = ""
        Dim textoAsunto As String = ""
        Dim actividadId As Integer = 0

        If BEMaquinaActual.str_PedidoId = Nothing Or BEMaquinaActual.str_PedidoId.Trim() = "" Or BEMaquinaActual.str_PedidoId.Trim() <> BEMaquina_RDA.str_PedidoId.Trim() Then
            textoPrincipal = If(BEMaquinaActual.str_PedidoId = Nothing Or BEMaquinaActual.str_PedidoId.Trim() = "",
                                ObtenerTextoPrincipalNuevoPedido(),
                                ObtenerTextoPrincipalCambioPedido())
            textoBeneficiosNuevos = If(liBeneficiosNuevos.Count > 0, ObtenerTextoBeneficiosNuevos(""), "No tiene beneficios.")
            textoApoyo = If(BEMaquina_RDA.str_ApoyoFabricanteIndicador = "1", "SI", "NO")

            textoPrincipal = textoPrincipal.Replace("@ORDEN", BEMaquina_RDA.str_OrdenAsignada)
            textoPrincipal = textoPrincipal.Replace("@PEDIDO", BEMaquina_RDA.str_PedidoId)
            textoPrincipal = textoPrincipal.Replace("@BENEFICIOS", textoBeneficiosNuevos)
            textoPrincipal = textoPrincipal.Replace("@APOYO", textoApoyo)

            textoAsunto = String.Format("Asignación de Máquina")
            actividadId = Constantes.Actividad_AsignacionMaquina
        ElseIf liBeneficiosEliminados.Count > 0 Or liBeneficiosModificados.Count > 0 Or liBeneficiosNuevos.Count > 0 Or BEMaquinaActual.str_ApoyoFabricanteIndicador <> BEMaquina_RDA.str_ApoyoFabricanteIndicador Then
            Dim textoCambiosBeneficios As StringBuilder = New StringBuilder()
            If liBeneficiosEliminados.Count > 0 Then
                textoCambiosBeneficios.AppendLine(String.Format("{0} <br>", ObtenerTextoBeneficiosEliminados("Eliminados")))
            End If
            If liBeneficiosModificados.Count > 0 Then
                textoCambiosBeneficios.AppendLine(String.Format("{0} <br>", ObtenerTextoBeneficiosModificados("Modificados")))
            End If
            If liBeneficiosNuevos.Count > 0 Then
                textoCambiosBeneficios.AppendLine(String.Format("{0} <br>", ObtenerTextoBeneficiosNuevos("Nuevos")))
            End If

            If textoCambiosBeneficios.ToString() <> "" Then
                textoPrincipal = ObtenerTextoPrincipalIgualPedido_Beneficios()

                textoPrincipal = textoPrincipal.Replace("@ORDEN", BEMaquina_RDA.str_OrdenAsignada)
                textoPrincipal = textoPrincipal.Replace("@BENEFICIOS", textoCambiosBeneficios.ToString())
            End If

            If BEMaquinaActual.str_ApoyoFabricanteIndicador <> BEMaquina_RDA.str_ApoyoFabricanteIndicador Then
                textoPrincipal = textoPrincipal + ObtenerTextoPrincipalIgualPedido_Apoyo()
                textoPrincipal = textoPrincipal.Replace("@APOYO", If(BEMaquina_RDA.str_ApoyoFabricanteIndicador = "1",
                                                                     String.Format("La Orden {0} tiene Apoyo de Fabricante", BEMaquina_RDA.str_OrdenAsignada),
                                                                     String.Format("La Orden {0} no tiene Apoyo de Fabricante", BEMaquina_RDA.str_OrdenAsignada)))
            End If

            If textoPrincipal <> "" Then
                textoAsunto = "Cambio en el Apoyo de la Máquina"
                actividadId = Constantes.Actividad_ModificacionBeneficiosApoyo
            End If
        End If

        If textoPrincipal <> "" Then
            Dim BEAlertas As BE_Alertas = New BE_Alertas()
            With BEAlertas
                .str_MensajeAsunto = textoAsunto
                .str_MensajeContenido = textoPrincipal
                .str_UsuarioRegistro = "system"
            End With

            'Registrar alerta en la BD
            Dim resultadoAlerta As String = clsAlertas.fn_Insert_Alerta(BEAlertas, Constantes.Modulo_GestionInventario, BEMaquina_RDA.str_CompaniaId, actividadId)
            If resultadoAlerta <> "1" Then
                Throw New Exception(String.Format("Error al momento de registrar la Alerta de asignación. Máquina {0} - Pedido {1}", BEMaquina_RDA.str_OrdenAsignada, BEMaquina_RDA.str_PedidoId))
            End If
        End If
    End Sub

    Private Function ObtenerObjMaquina(ByVal BETempZRda As BE_Temp_ZRda) As BE_Maquina
        Dim BEMaquina As BE_Maquina = New BE_Maquina()

        With BEMaquina
            .str_OrdenAsignada = BETempZRda.str_OrdAsignada
            .str_PedidoId = BETempZRda.str_IdPedido
            .int_PosicionId = BETempZRda.int_IdPosicion
            .str_ApoyoFabricanteIndicador = If(Trim(BETempZRda.str_ApoyoFab) = "", "0", "1")
            .str_VendedorId = BETempZRda.str_IdSapSocNegResponsable
            .str_VendedorDesc = BETempZRda.str_NombreResponsable
            .str_ClienteId = BETempZRda.str_IdExtSocNegCliente
            .str_ClienteDesc = BETempZRda.str_NombreCliente
            .str_ClienteFacturaId = BETempZRda.str_IdExtSocNegEntidadFinanciera
            .str_ClienteFacturaDesc = BETempZRda.str_NombreEntidadFinanciera
            .str_CompaniaId = BETempZRda.str_OrgFact.PadLeft(3, "0")
        End With

        Return BEMaquina
    End Function

    Private Function ObtenerTextoBeneficiosEliminados(ByVal titulo As String) As String
        Dim texto As String = ""

        If liBeneficiosEliminados.Count > 0 Then
            Dim cambios As StringBuilder = New StringBuilder()
            For Each item In liBeneficiosEliminados
                cambios.AppendLine("<tr><td style='border: 1px solid black; padding: 4px'>" + item.int_BeneficioId.ToString() + "</td><td style='border: 1px solid black; padding: 4px'>" + item.str_Descripcion.ToString() + "</td><td style='border: 1px solid black; padding: 4px'>" + item.dec_Monto.ToString() + "</td></tr>")
            Next

            texto = ObtenerTextoCabeceraCambios(titulo)
            texto = texto.Replace("@CONTENIDO", cambios.ToString())
        End If

        Return texto
    End Function

    Private Function ObtenerTextoBeneficiosModificados(ByVal titulo As String) As String
        Dim texto As String = ""

        If liBeneficiosModificados.Count > 0 Then
            Dim cambios As StringBuilder = New StringBuilder()
            For Each item In liBeneficiosModificados
                cambios.AppendLine("<tr><td style='border: 1px solid black; padding: 4px'>" + item.int_BeneficioId.ToString() + "</td><td style='border: 1px solid black; padding: 4px'>" + item.str_Descripcion.ToString() + "</td><td style='border: 1px solid black; padding: 4px'>" + item.dec_Monto.ToString() + "</td></tr>")
            Next

            texto = ObtenerTextoCabeceraCambios(titulo)
            texto = texto.Replace("@CONTENIDO", cambios.ToString())
        End If

        Return texto
    End Function

    Private Function ObtenerTextoBeneficiosNuevos(ByVal titulo As String) As String
        Dim texto As String = ""

        If liBeneficiosNuevos.Count > 0 Then
            Dim cambios As StringBuilder = New StringBuilder()
            For Each item In liBeneficiosNuevos
                cambios.AppendLine("<tr><td style='border: 1px solid black; padding: 4px'>" + item.int_BeneficioId.ToString() + "</td><td style='border: 1px solid black; padding: 4px'>" + item.str_Descripcion.ToString() + "</td><td style='border: 1px solid black; padding: 4px'>" + item.dec_Monto.ToString() + "</td></tr>")
            Next

            texto = ObtenerTextoCabeceraCambios(titulo)
            texto = texto.Replace("@CONTENIDO", cambios.ToString())
        End If

        Return texto
    End Function

    Private Function ObtenerTextoCabeceraCambios(ByVal titulo As String) As String
        Dim texto As StringBuilder = New StringBuilder()
        If titulo <> "" Then
            texto.AppendLine("<p style='font-size: 12px; font-family: arial'><b>" + titulo + ":</b></p>")
        End If
        texto.AppendLine("<table style='cellpadding: 0; border-collapse: collapse; width: 500px; font-size: 12px; font-family: arial'>")
        texto.AppendLine("<thead>")
        texto.AppendLine("<tr><th style='border: 1px solid black; padding: 4px; font-weight: bold'>Código</th><th style='border: 1px solid black; padding: 4px; font-weight: bold'>Descripición</th><th style='border: 1px solid black; padding: 4px; font-weight: bold'>Cantidad</th></tr></thead>")
        texto.AppendLine("<tbody>")
        texto.AppendLine("@CONTENIDO")
        texto.AppendLine("</tbody>")
        texto.AppendLine("</table>")
        Return texto.ToString()
    End Function

    Private Function ObtenerTextoPrincipalIgualPedido_Beneficios() As String
        Return "<p style='font-size: 12px; font-family: arial'>Se registraron cambios en los Beneficios de la Orden @ORDEN.</p><div>@BENEFICIOS</diV>"
    End Function

    Private Function ObtenerTextoPrincipalIgualPedido_Apoyo() As String
        Return "<p style='font-size: 12px; font-family: arial'>@APOYO</p>"
    End Function

    Private Function ObtenerTextoPrincipalNuevoPedido() As String
        Return "<p style='font-size: 12px; font-family: arial'>La máquina @ORDEN fue ASIGNADA (Pedido: @PEDIDO).</p>" & _
               "<div><p style='font-size: 12px; font-family: arial'>Beneficios:</p>" & _
               "@BENEFICIOS</div>" & _
               "<p style='font-size: 12px; font-family: arial'>Apoyo Fabricante: @APOYO</p>"
    End Function

    Private Function ObtenerTextoPrincipalCambioPedido() As String
        Return "<p style='font-size: 12px; font-family: arial'>La máquina @ORDEN fue ASIGNADA a un nuevo Pedido (Pedido: @PEDIDO).</p>" & _
               "<div><p style='font-size: 12px; font-family: arial'>Beneficios:</p>" & _
               "@BENEFICIOS</div>" & _
               "<p style='font-size: 12px; font-family: arial'>Apoyo Fabricante: @APOYO</p>"
    End Function

End Class