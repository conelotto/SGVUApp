Imports System.Configuration

Public Class cmpConsultarCRM

   Private entorno As String

   Private consultarCRM As IConsultarCRM

   Public Sub New()
      entorno = ConfigurationManager.AppSettings("EnviaCorreo").ToString()

      If entorno = "Test" Then
         consultarCRM = New ConsultarCRM_DES()
      ElseIf entorno = "TestQA" Then
         consultarCRM = New ConsultarCRM_QA()
      Else
         consultarCRM = Nothing
      End If
   End Sub

   Public Function ObtenerDatosOportunidad(ByVal pi_strOportunidad As String)
      Try
         Dim datosOportunidad As Object = consultarCRM.ObtenerDatosOportunidad(pi_strOportunidad)
         Return datosOportunidad
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Function ObtenerDatosPersonal(ByVal pi_strNumeroPersonal As String) As Empleado
      Try
         Dim datosPersonal As Empleado = consultarCRM.ObtenerDatosPersonal(pi_strNumeroPersonal)
         Return datosPersonal
      Catch ex As Exception
         Throw ex
      End Try
   End Function

End Class