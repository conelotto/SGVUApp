Imports System.Web
Imports System.Web.Services
Imports SGCVU.BE
Imports SGCVU.BL
Imports SGCVU.DTO
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Web.UI.HtmlControls

Public Class AttachedFiles
    Implements System.Web.IHttpHandler
    Implements System.Web.SessionState.IRequiresSessionState

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            Dim _strExtencion As String = String.Empty
            Dim _Filter As DTO_SearchParameters = New JavaScriptSerializer().Deserialize(Of DTO_SearchParameters)(HttpContext.Current.Request.Form("jsonFiltro").ToString)

            Dim _BeExpedienteAttached As New List(Of BE_Expediente_DocumentosAdjuntos)
            _BeExpedienteAttached = clsExpediente_DocumentosAdjuntos.fn_Select_ExpedienteDocumentosAdjuntos_ByKey(_Filter)

            If _BeExpedienteAttached IsNot Nothing AndAlso _BeExpedienteAttached.Count > 0 Then

                _strExtencion = String.Format("{0}{1}", "application/", _BeExpedienteAttached(0).str_ArchivoNombre.Substring(_BeExpedienteAttached(0).str_ArchivoNombre.IndexOf("."c) + 1))
                context.Response.Clear()
                context.Response.Buffer = True
                context.Response.ClearHeaders()
                context.Response.ClearContent()
                context.Response.AppendHeader("content-length", DirectCast(_BeExpedienteAttached(0).byte_ArchivoAdjunto, Byte()).Length)
                context.Response.ContentType = _strExtencion
                context.Response.AddHeader("content-disposition", "attachment;filename=" + _BeExpedienteAttached(0).str_ArchivoNombre)
                context.Response.SetCookie(New HttpCookie("fileDownload", "True") With {.Path = "/"})
                context.Response.BinaryWrite(DirectCast(_BeExpedienteAttached(0).byte_ArchivoAdjunto, Byte()))
                context.ApplicationInstance.CompleteRequest()

            End If

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