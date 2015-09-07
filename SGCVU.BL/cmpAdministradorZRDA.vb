Imports SGCVU.WS
Imports SGCVU.BL
Imports SGCVU.BE
Imports System.Transactions

Public Class cmpAdministradorZRDA

    Public lRdas As IList(Of ZRda)
    Public zRda As ZRda

    Public Sub New(ByVal pi_lRdas As IList(Of ZRda))
        lRdas = pi_lRdas
    End Sub

    Public Sub New(ByVal pi_rda As ZRda)
        zRda = pi_rda
    End Sub

    Public Sub RegistrarRDAsEnTemporal()
        Using scope As New TransactionScope()
            For Each rda In lRdas
                zRda = rda
                Dim idTempZRda As Integer = RegistrarRDA()
                If idTempZRda <> 0 Then
                    RegistrarBeneficios(idTempZRda)
                End If
            Next
            scope.Complete()
        End Using
    End Sub

    Public Function RegistrarRDAEnTemporal() As Integer
        Dim idTempZRda As Integer = 0

        Using scope As New TransactionScope()
            idTempZRda = RegistrarRDA()
            If idTempZRda <> 0 Then
                RegistrarBeneficios(idTempZRda)
            End If
            scope.Complete()
        End Using

        Return idTempZRda
    End Function

    Private Function RegistrarRDA() As Integer
        If zRda Is Nothing Then
            Throw New Exception("El ZRda a guardar en el Temporal es NULO.")
        Else
            Dim BETempZRda As BE_Temp_ZRda = ObtenerObjBE_Temp_ZRda(zRda)

            Dim resultado As String = clsTemp_ZRda.fn_Insert_Update_Temp_ZRda(BETempZRda)
            If Not resultado.StartsWith("1") Then
                Throw New Exception(String.Format("Error al momento de registrar en el Temporal. Pedido: {0} - Orden: {1}", BETempZRda.str_IdPedido, BETempZRda.str_OrdAsignada))
            End If

            Return Convert.ToInt32(resultado.Split("_")(1))
        End If
    End Function

    Private Sub RegistrarBeneficios(ByVal IdTemporalZRda As Integer)
        For Each item In zRda.Beneficios
            Dim BETempZBeneficio As BE_Temp_ZBeneficio = ObtenerObjBE_Temp_ZBeneficio(item, IdTemporalZRda)

            Dim resultado As String = clsTemp_ZBeneficio.fn_Insert_Temp_ZBeneficio(BETempZBeneficio)
            If resultado <> "1" Then
                Throw New Exception(String.Format("Error al momento de registrar los Beneficios del temporal. Pedido: {0} - Orden: {1}", zRda.IdPedido, zRda.AsigEquipo.OrdAsignada))
            End If
        Next
    End Sub

    Private Function ObtenerObjBE_Temp_ZRda(ByVal rda As ZRda) As BE_Temp_ZRda
        Dim BETemp_ZRda As BE_Temp_ZRda = New BE_Temp_ZRda

        With BETemp_ZRda
            .str_OrgFact = rda.OrgFact
            .str_OrdAsignada = rda.AsigEquipo.OrdAsignada
            .int_IdPosicion = rda.Posicion.IdPosicion
            .str_Status = rda.Status
            .det_Fecha = rda.Fecha
            .str_NroMotor = rda.NroMotor
            .str_IdPedido = rda.IdPedido
            .str_OfiVentasFac = rda.OfiVentasFac
            .str_OfiVentasFacTxt = rda.OfiVentasFacTxt
            .str_Oportunidad = rda.Oportunidad
            .str_ApoyoFab = rda.ApoyoFab
            .str_Eliminado = rda.Eliminado
            .str_FormaPago = rda.Posicion.FormaPago
            .str_FormaPagoTxt = rda.Posicion.FormaPagoTxt
            .str_CodDbs = rda.AsigEquipo.CodDbs
            .str_CtaInventario = rda.AsigEquipo.CtaInventario
            .str_Serie = rda.AsigEquipo.Serie
            .str_AFabricacion = rda.AsigEquipo.AFabricacion
            .str_Numero = rda.AsigEquipo.Numero
            .str_FechaCre = rda.FechaCre
            .str_HoraCre = rda.HoraCre
            .str_FechaMod = rda.FechaMod
            .str_HoraMod = rda.HoraMod

            For Each implicado In rda.Implicados
                Select Case implicado.Funcion
                    Case ConstantesWS.codigoFuncionResponsable
                        .str_IdExtSocNegResponsable = implicado.IdExtSocNeg
                        .str_IdSapSocNegResponsable = implicado.IdSapSocNeg
                        .str_NombreResponsable = implicado.Nombre
                    Case ConstantesWS.codigoFuncionCliente
                        .str_IdExtSocNegCliente = implicado.IdExtSocNeg
                        .str_IdSapSocNegCliente = implicado.IdSapSocNeg
                        .str_NombreCliente = implicado.Nombre
                    Case ConstantesWS.codigoFuncionEntidadFinanciera
                        .str_IdExtSocNegEntidadFinanciera = implicado.IdExtSocNeg
                        .str_IdSapSocNegEntidadFinanciera = implicado.IdSapSocNeg
                        .str_NombreEntidadFinanciera = implicado.Nombre
                End Select
            Next

        End With

        Return BETemp_ZRda
    End Function

    Private Function ObtenerObjBE_Temp_ZBeneficio(ByVal beneficio As ZBeneficio, ByVal IdTempZRda As Integer) As BE_Temp_ZBeneficio
        Dim BETempZBeneficio As BE_Temp_ZBeneficio = New BE_Temp_ZBeneficio()

        With BETempZBeneficio
            .int_IdTemp_ZRda = IdTempZRda
            .str_Codigo = beneficio.Codigo
            .str_Descripcion = beneficio.Descripcion
            .int_Cantidad = beneficio.Cantidad
        End With

        Return BETempZBeneficio
    End Function

End Class