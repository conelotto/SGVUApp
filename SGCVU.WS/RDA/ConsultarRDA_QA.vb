Imports SGCVU.WS.WS_RDA_QA

Friend Class ConsultarRDA_QA
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
         consultaRda.FechacreacioniSpecified = True
            consultaRda.Fechacreacioni = CDate(fechaInicial).ToString(ConstantesWS.formatoFecha)
            consultaRda.HoracreacioniSpecified = True
            consultaRda.Horacreacioni = CDate(fechaInicial).ToString(ConstantesWS.formatoHora)
        End If
        consultaRda.FechacreacionfSpecified = True
        consultaRda.Fechacreacionf = fechaFinal.ToString(ConstantesWS.formatoFecha)
        consultaRda.HoracreacionfSpecified = True
        consultaRda.Horacreacionf = fechaFinal.ToString(ConstantesWS.formatoHora)

      Dim consultaRdaResponse As ZrfcConsultaRdaResponse = wsConsultaRDA.ZrfcConsultaRda(consultaRda)

      Return consultaRdaResponse
   End Function

   Public Function ObtenerRDAAsignadoOrden(ByVal orden As String) As ZRda Implements IConsultarRDA.ObtenerRDAAsignadoOrden
      Return Nothing
   End Function

End Class