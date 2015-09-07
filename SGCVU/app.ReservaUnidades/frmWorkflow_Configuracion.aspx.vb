Imports SGCVU.DTO
Imports SGCVU.BL

Public Class frmWorkflow_Configuracion
   Inherits System.Web.UI.Page

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

   End Sub

   <System.Web.Services.WebMethod(EnableSession:=True)>
   Public Shared Function ObtenerColumnasConfiguracion()
      Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
      Try
         Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")
         Dim liDTOConfiguracionColumnasUsuario = clsConfiguracion_Columnas_Usuario.fn_Select_Configuracion_Columnas_Usuario("InventarioMaquina", loginUsuario)

         objRpta.data = liDTOConfiguracionColumnasUsuario
      Catch ex As Exception
         objRpta.success = False
         objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
      End Try
      Return objRpta
   End Function

   <System.Web.Services.WebMethod(EnableSession:=True)>
   Public Shared Function GuardarColumnasConfiguracionUsuario(ByVal idsConfiguracionColumnas As List(Of String))
      Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
      Try
         Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")
         Dim rpta As String = clsConfiguracion_Columnas_Usuario.fn_Update_Configuracion_Columnas_Usuario(loginUsuario, "InventarioMaquina", idsConfiguracionColumnas)

         objRpta.data = rpta
      Catch ex As Exception
         objRpta.success = False
         objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
      End Try
      Return objRpta
   End Function

End Class