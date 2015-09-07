Imports SGCVU.BE

Public Class cmpAsignarBonoRitmo5

    Public Shared Function fn_AsignarBonoRitmo5(ByVal pi_BEOrden As BE_Maquina)
        Try
            Dim BEUMPTBAD0 As New BE_UMPTBAD0

            Dim liBEUMPTBAD0 As New List(Of BE_UMPTBAD0)



            Dim intCantidadBonoRitmo5 As Integer = IIf(pi_BEOrden.int_Ritmo5Cant = 0,
                                                       pi_BEOrden.dec_Ritmo5Monto,
                                                       pi_BEOrden.int_Ritmo5Cant)

            'VERIFICAR CODIGO SAP SI LA BUSQUEDA ES POR N SERIE O MODELO:
            Dim TipoBusqueda As Integer = 1
            Dim beBonoSAP As New BE_Beneficio 'BE_Maquina_Beneficio
            Dim beResultado As BE_Beneficio = Nothing
            Try
                beBonoSAP.int_ClaseId = 2
                beBonoSAP.str_BeneficioIdSapDEV = pi_BEOrden.str_XmlSap
                beBonoSAP.str_Sistema = Configuration.ConfigurationManager.AppSettings("EnviaCorreo")
                beResultado = clsBeneficio.fn_Select_Beneficio(beBonoSAP).Find(Function(c) c.str_SAPCalculado = pi_BEOrden.str_XmlSap And c.int_ClaseId = 2)
                TipoBusqueda = beResultado.int_TipoBusqueda
            Catch
                TipoBusqueda = 1 'Por defecto busqueda por N serie
            End Try
            ''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''''

            'Buscar SAP Produccion
            Dim SapProduccion As String = String.Empty
            SapProduccion = beResultado.str_BeneficioIdSapPRD

            With BEUMPTBAD0
                'SE MODIFICA OBTENER SAP DESDE LA TABLA ORDENABONO - CARLOS B 20150701
                .str_CODADI = SapProduccion
                '  pi_BEOrden.strIdSapBonoRitmo5Premium,
                ' pi_BEOrden.strIdSapBonoRitmo5Superior)
                .str_PREFIJ = pi_BEOrden.str_SerieMaquina.Substring(1, 3)
                .str_PMODEL = pi_BEOrden.str_ModeloProductoDesc
                .int_TipoBusqueda = TipoBusqueda
            End With



            liBEUMPTBAD0 = clsUMPTBAD0.fn_Select_ListaUMPTBAD0(BEUMPTBAD0)

            If liBEUMPTBAD0.Count > 0 Then
                BEUMPTBAD0 = liBEUMPTBAD0(0)
                pi_BEOrden.dec_Ritmo5Monto = intCantidadBonoRitmo5 * BEUMPTBAD0.dec_MONTO
                'pi_BEOrden.strBonoRitmo5Cant = intCantidadBonoRitmo5
                clsMaquina.fn_Update_CantidadMontoRitmo5(pi_BEOrden)
            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

End Class
