Imports SGCVU.WS.WS_RDA_DES
Imports System.Linq

Friend Class ConsultarRDA_DES
   Inherits ConsultarWS_Base
   Implements IConsultarRDA

   Private wsConsultaRDA As ZWS_CONSULTA_RDA

   Public Sub New()
      MyBase.New()
      wsConsultaRDA = New ZWS_CONSULTA_RDA()
      wsConsultaRDA.Credentials = credenciales
   End Sub

   Public Function ObtenerRDAsAsignadosFechaHora(ByVal fechaInicial As Date?, ByVal fechaFinal As Date) As IList(Of ZRda) Implements IConsultarRDA.ObtenerRDAsAsignadosFechaHora
      Dim consultaRda As ZrfcConsultaRda = New ZrfcConsultaRda()

      Dim liGuid As New List(Of ZesGuidRda)
      Dim liOperacion As New List(Of ZesIdoperacion)
      Dim liOrden As New List(Of ZesOrdasignada)

      consultaRda.TGuid = liGuid.ToArray
      consultaRda.TIdoperacion = liOperacion.ToArray
      consultaRda.TOrdenasignada = liOrden.ToArray

      If fechaInicial IsNot Nothing Then
            consultaRda.Fechacreacioni = CDate(fechaInicial).ToString(ConstantesWS.formatoFecha)
            consultaRda.Horacreacioni = CDate(fechaInicial).ToString(ConstantesWS.formatoHora)
        End If
        consultaRda.Fechacreacionf = fechaFinal.ToString(ConstantesWS.formatoFecha)
        consultaRda.Horacreacionf = fechaFinal.ToString(ConstantesWS.formatoHora)

        Dim consultaRdaResponse As ZrfcConsultaRdaResponse = wsConsultaRDA.ZrfcConsultaRda(consultaRda)
        Dim rdas As IList(Of ZRda) = ObtenerZrdas(consultaRdaResponse)

        Return rdas
    End Function

    Public Function ObtenerRDAAsignadoOrden(ByVal orden As String) As ZRda Implements IConsultarRDA.ObtenerRDAAsignadoOrden
        Dim consultaRda As ZrfcConsultaRda = New ZrfcConsultaRda()

        Dim liGuid As New List(Of ZesGuidRda)
        Dim liOperacion As New List(Of ZesIdoperacion)
        Dim liOrden As New List(Of ZesOrdasignada)() From {New ZesOrdasignada With {.Ordasignada = orden}}

        consultaRda.TGuid = liGuid.ToArray
        consultaRda.TIdoperacion = liOperacion.ToArray
        consultaRda.TOrdenasignada = liOrden.ToArray

        Dim consultaRdaResponse As ZrfcConsultaRdaResponse = wsConsultaRDA.ZrfcConsultaRda(consultaRda)
        Dim rdas As IList(Of ZRda) = ObtenerZrdas(consultaRdaResponse)

        If rdas.Count > 0 Then
            Return rdas(0)
        Else
            Return Nothing
        End If
    End Function

    Private Function ObtenerZrdas(ByVal consultaRdaResponse As ZrfcConsultaRdaResponse)
        Dim rdas As IList(Of ZRda) = New List(Of ZRda)

        Dim responseRdas() As ZesRda = consultaRdaResponse.EtZrda

        If responseRdas.Length > 0 Then
            For index = 0 To responseRdas.Length - 1
                Dim item As ZesRda = responseRdas(index)

                If item.Status = ConstantesWS.codigoEstadoAsignado Then
                    Dim rda As ZRda = New ZRda()
                    With rda
                        .OrgFact = item.Orgfact
                        .Status = item.Status
                        .Fecha = item.Fecha
                        .NroMotor = item.NroMotor
                        .IdPedido = item.Idpedido
                        .OfiVentasFac = item.Ofiventasfac
                        .OfiVentasFacTxt = item.OfiventasfacTxt
                        .Oportunidad = item.Oportunidad
                        .ApoyoFab = item.ApoyoFab
                        .Eliminado = item.Eliminado
                        .FechaCre = item.Fechacre
                        .HoraCre = item.Horacre
                        .FechaMod = item.Fechamod
                        .HoraMod = item.Horamod

                        .Posicion = ObtenerPosicion(consultaRdaResponse.EtZposicion, item.Idpedido)
                        .AsigEquipo = ObtenerAsigEquipo(consultaRdaResponse.EtZasigEquipo, item.Idpedido)

                        .Implicados = ObtenerImplicados(consultaRdaResponse.EtZlistaImplicado, item.Idpedido)
                        .Precios = ObtenerPrecios(consultaRdaResponse.EtZdetPrecios, item.Idpedido)
                        .Beneficios = ObtenerBeneficios(consultaRdaResponse.EtZbeneficios, item.Idpedido)
                    End With

                    If rda.AsigEquipo Is Nothing Or rda.AsigEquipo Is Nothing Then
                        Continue For
                    End If

                    rdas.Add(rda)
                End If
            Next
        End If

        Return rdas
    End Function

    Private Function ObtenerPosicion(ByVal responsePosiciones() As ZesPosicion, ByVal idPedido As String)
        Dim posicion As ZPosicion = Nothing

        Dim lResponsePosiciones = (From p In responsePosiciones.Cast(Of ZesPosicion)().ToList() Where p.Idpedido = idPedido).Take(1)
        Dim responsePosicion As ZesPosicion = Nothing
        If lResponsePosiciones.Count > 0 Then
            responsePosicion = lResponsePosiciones.ElementAt(0)
        End If

        If responsePosicion IsNot Nothing Then
            posicion = New ZPosicion()
            With posicion
                .IdPosicion = responsePosicion.Idposicion
                .FormaPago = responsePosicion.FormaPago
                .FormaPagoTxt = responsePosicion.FormaPagoTxt
            End With
        End If

        Return posicion
    End Function

    Private Function ObtenerAsigEquipo(ByVal responseAsigEquipos() As ZesAsigEquipo, ByVal idPedido As String)
        Dim asigEquipo As ZAsigEquipo = Nothing

        Dim lResponseAsigEquipos = (From p In responseAsigEquipos.Cast(Of ZesAsigEquipo)().ToList() Where p.Idpedido = idPedido).Take(1)
        Dim responseAsigEquipo As ZesAsigEquipo = Nothing
        If lResponseAsigEquipos.Count > 0 Then
            responseAsigEquipo = responseAsigEquipos.ElementAt(0)
        End If

        If responseAsigEquipo IsNot Nothing Then
            asigEquipo = New ZAsigEquipo()
            With asigEquipo
                .OrdAsignada = responseAsigEquipo.Ordasignada
                .CodDbs = responseAsigEquipo.Coddbs
                .CtaInventario = responseAsigEquipo.Ctainventario
                .Serie = responseAsigEquipo.Serie
                .AFabricacion = responseAsigEquipo.Afabricacion
                .Numero = responseAsigEquipo.Numero
            End With
        End If

        Return asigEquipo
    End Function

    Private Function ObtenerImplicados(ByVal responseImplicados() As ZesListaImplicado, ByVal idPedido As String)
        Dim implicados As IList(Of ZImplicado) = New List(Of ZImplicado)

        Dim lReponseImplicados = responseImplicados.Cast(Of ZesListaImplicado)().ToList().
           Where(Function(i) i.Idpedido = idPedido _
                    And (i.Funcion = ConstantesWS.codigoFuncionResponsable Or i.Funcion = ConstantesWS.codigoFuncionCliente Or i.Funcion = ConstantesWS.codigoFuncionEntidadFinanciera))
        For Each item In lReponseImplicados
            Dim implicado As ZImplicado = New ZImplicado()
            With implicado
                .IdExtSocNeg = item.Idextsocneg
                .IdSapSocNeg = item.Idsapsocneg
                .Funcion = item.Funcion
                .FuncionTxt = item.Funciontxt
                .Nombre = item.Nombre
            End With

            implicados.Add(implicado)
        Next

        Return implicados
    End Function

   Private Function ObtenerPrecios(ByVal responsePrecios() As ZesDetPrecios, ByVal idPedido As String)
      Dim precios As IList(Of ZDetPrecio) = New List(Of ZDetPrecio)

      Dim lResponsePrecios = responsePrecios.Cast(Of ZesDetPrecios)().ToList().Where(Function(i) i.Idpedido = idPedido)
      For Each item In lResponsePrecios
         Dim precio As ZDetPrecio = New ZDetPrecio()
         With precio
            .Valor = item.Valor
         End With

         precios.Add(precio)
      Next

      Return precios
   End Function

   Private Function ObtenerBeneficios(ByVal responseBeneficios() As ZesBeneficios, ByVal idPedido As String)
      Dim beneficios As IList(Of ZBeneficio) = New List(Of ZBeneficio)

      Dim lResponseBeneficios = responseBeneficios.Cast(Of ZesBeneficios)().ToList().Where(Function(i) i.Idpedido = idPedido)
      For Each item In lResponseBeneficios
         Dim beneficio As ZBeneficio = New ZBeneficio()
         With beneficio
            .Codigo = item.Codigo
            .Descripcion = item.Descripcion
            .Cantidad = item.Cantidad
         End With

         beneficios.Add(beneficio)
      Next

      Return beneficios
   End Function

End Class