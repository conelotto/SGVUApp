Imports System.Web
Imports System.Web.Services
Imports SGCVU.DTO
Imports System.Web.Script.Serialization
Imports System.IO

Public Class EliminarArchivo
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        If (context.Request.Browser.Browser.ToUpper() = "IE" Or context.Request.Browser.Browser = "InternetExplorer") And context.Request.Browser.MajorVersion < 10 Then
            context.Response.ContentType = "text/html"
        Else
            context.Response.ContentType = "json"
        End If

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Dim js As JavaScriptSerializer = New JavaScriptSerializer()

        Try
            Dim nombreArchivo As String = HttpContext.Current.Request.Form("nombre").ToString

            EliminarArchivo(nombreArchivo)
        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format(ex.Message)
        End Try

        Dim jsonObject = js.Serialize(objRpta)
        context.Response.Write(jsonObject.ToString())
    End Sub

    Public Shared Function EliminarArchivo(ByVal nombreGenerado As String) As Boolean
        Dim directorioOrigen As String = HttpContext.Current.Request.PhysicalApplicationPath + "temp\"

        If File.Exists(directorioOrigen & nombreGenerado.ToString()) Then
            File.Delete(directorioOrigen & nombreGenerado.ToString())
            Return True
        End If

        Return False
    End Function

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class