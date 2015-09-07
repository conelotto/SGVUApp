Imports System.Web
Imports System.Web.Services
Imports SGCVU.DTO
Imports System.Web.Script.Serialization
Imports SGCVU.BL

Public Class MaquinasInventario
   Implements System.Web.IHttpHandler, System.Web.SessionState.IRequiresSessionState

   Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
      Try
         Dim filtro As DTO_Filtro_Maquina_Inventario = New JavaScriptSerializer().Deserialize(Of DTO_Filtro_Maquina_Inventario)(HttpContext.Current.Request.Form("jsonFiltro").ToString)
         Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")

         'Obtener Datos
         Dim total As Integer = 0
         Dim liDTOMaquinas As List(Of DTO_Consulta_Inventario_Maquina) = clsMaquina.fn_Select_Maquina_Consulta_Inventario(total, 0, 0, filtro, loginUsuario)
         Dim liDTOColumnas As List(Of DTO_Configuracion_Columnas_Usuario) = clsConfiguracion_Columnas_Usuario.fn_Select_Configuracion_Columnas_Usuario_Activas("InventarioMaquina", loginUsuario)

         Dim cmpReporteExcel = New cmpReporteExcelInventarioMaquina(liDTOMaquinas, liDTOColumnas)
         Dim contArchivo = cmpReporteExcel.fn_ObtenerDocumento()

         'Forzar descarga del archivo
         context.Response.Buffer = True
         context.Response.Clear()
         context.Response.ClearHeaders()
         context.Response.ClearContent()
         context.Response.AppendHeader("content-length", contArchivo.Length)
         context.Response.ContentType = "application/octet-stream"
         context.Response.AddHeader("content-disposition", String.Format("attachment; filename={0}", "Inventario de Máquinas.xls"))
         context.Response.SetCookie(New HttpCookie("fileDownload", "True") With {.Path = "/"})
         context.Response.BinaryWrite(contArchivo)
         context.ApplicationInstance.CompleteRequest()
      Catch ex As Exception
         context.Response.Write(ex.Message)
      End Try
   End Sub

   ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
      Get
         Return False
      End Get
   End Property

End Class