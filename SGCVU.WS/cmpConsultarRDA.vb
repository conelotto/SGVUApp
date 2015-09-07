Imports System.Configuration

Public Class cmpConsultarRDA

   Private entorno As String

   Private consultarRDA As IConsultarRDA

   Public Sub New()
      entorno = ConfigurationManager.AppSettings("EnviaCorreo").ToString()
      If entorno = "Test" Then
         consultarRDA = New ConsultarRDA_DES()
      ElseIf entorno = "TestQA" Then
         consultarRDA = New ConsultarRDA_QA()
      Else
         consultarRDA = Nothing
      End If
   End Sub

   Public Function ObtenerRDAsAsignadosFechaHora(ByVal fechaInicial As Date?, ByVal fechaFinal As Date)
      Try
         Dim datosRDAs As IList(Of ZRda) = consultarRDA.ObtenerRDAsAsignadosFechaHora(fechaInicial, fechaFinal)
         Return datosRDAs
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ObtenerRDAAsignadoOrden(ByVal orden As String)
      Try
         Dim rda As ZRda = consultarRDA.ObtenerRDAAsignadoOrden(orden)
         Return rda
      Catch ex As Exception
         Throw ex
      End Try
   End Function

End Class