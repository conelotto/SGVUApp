Imports System.Web
Imports System.Web.Services
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Net
Imports System.Net.Sockets

Public Class CargaBase
    Implements System.Web.IHttpHandler

    Public Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        If (context.Request.Browser.Browser.ToUpper() = "IE" Or context.Request.Browser.Browser = "InternetExplorer") And context.Request.Browser.MajorVersion < 10 Then
            context.Response.ContentType = "text/html"
        Else
            context.Response.ContentType = "json"
        End If

        Dim Resultado As String = String.Empty
        Dim listaRespuesta = New List(Of RptaCarga)
        Dim js As JavaScriptSerializer = New JavaScriptSerializer()

        For Each archivo In context.Request.Files
            Dim hpf As HttpPostedFile = TryCast(context.Request.Files(archivo), HttpPostedFile)

            If hpf.ContentLength = 0 Then
                Continue For
            End If

            Dim rpta As RptaCarga = New RptaCarga()

            Dim sizeFile As Integer = hpf.ContentLength
            Dim mimeTypeFile As String = hpf.ContentType
            Dim width As Integer = 0
            Dim height As Integer = 0

            Dim nombreArchivo As String = String.Empty
            Dim nuevoNombre As String = String.Empty
            Dim rutaArchivo As String

            If HttpContext.Current.Request.Browser.Browser.ToUpper() = "IE" Then
                Dim archivos As String() = hpf.FileName.Split(New Char() {"\"c})
                nombreArchivo = archivos(archivos.Length - 1)
            Else
                nombreArchivo = hpf.FileName
            End If

            Dim directorioUpload As String = HttpContext.Current.Request.PhysicalApplicationPath + "\temp\"

            Dim extensionFile As String = System.IO.Path.GetExtension(nombreArchivo)
            Dim ipUsuario As String = ObtenerIp()

            nuevoNombre = Date.Now.Ticks.ToString() + "-" + ipUsuario.Replace(":", String.Empty).Replace(".", String.Empty) + extensionFile
            rutaArchivo = directorioUpload + nuevoNombre

            Try
                If Not Directory.Exists(directorioUpload) Then
                    Directory.CreateDirectory(directorioUpload)
                End If

                hpf.SaveAs(rutaArchivo)

                rpta.nuevoNombre = nuevoNombre
                rpta.nombreArchivo = nombreArchivo
            Catch ex As Exception
                rpta.nuevoNombre = ""
                rpta.nombreArchivo = ""
            End Try

            listaRespuesta.Add(rpta)
        Next archivo

        Dim archivosSubidos = listaRespuesta.ToArray()
        Dim jsonObject = js.Serialize(archivosSubidos)
        context.Response.Write(jsonObject.ToString())
    End Sub

    Private Shared Function ObtenerIp() As String
        Dim localIP As String = String.Empty
        Try
            Dim host As IPHostEntry = Dns.GetHostEntry(Dns.GetHostName())
            For Each ip As IPAddress In host.AddressList
                If ip.AddressFamily = AddressFamily.InterNetwork Then
                    localIP = ip.ToString()
                    Exit For
                End If
            Next
        Catch
            localIP = "127.0.0.1"
        End Try
        Return If((localIP.Replace(" ", String.Empty) <> "::1"), localIP, "127.0.0.1")
    End Function

    ReadOnly Property IsReusable() As Boolean Implements IHttpHandler.IsReusable
        Get
            Return False
        End Get
    End Property

End Class

Public Class RptaCarga

    Property nombreArchivo As String
    Property nuevoNombre As String

End Class