Imports System.Web
Imports System.Web.Services
Imports SGCVU.BE
Imports SGCVU.BL
Imports SGCVU.DTO
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Web.UI.HtmlControls

Public Class WashoutFile
    Implements System.Web.IHttpHandler
    Implements System.Web.SessionState.IRequiresSessionState

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            Dim _strExtencion As String = String.Empty
            Dim _Filter As DTO_SearchParameters = New JavaScriptSerializer().Deserialize(Of DTO_SearchParameters)(HttpContext.Current.Request.Form("jsonFiltro").ToString)

            Dim _BeApoyoFlujo As New List(Of BE_Apoyo_Flujo)
            _BeApoyoFlujo = clsApoyo_Flujo.fn_Select_ApoyoFlujo_Washout_ByKey(_Filter)

            If _BeApoyoFlujo IsNot Nothing AndAlso _BeApoyoFlujo.Count > 0 Then

                _strExtencion = String.Format("{0}{1}", "application/", _BeApoyoFlujo(0).str_WashoutArchivo.Substring(_BeApoyoFlujo(0).str_WashoutArchivo.IndexOf("."c) + 1))
                context.Response.Clear()
                context.Response.Buffer = True
                context.Response.ClearHeaders()
                context.Response.ClearContent()
                context.Response.AppendHeader("content-length", DirectCast(_BeApoyoFlujo(0).byte_Washout, Byte()).Length)
                context.Response.ContentType = _strExtencion
                context.Response.AddHeader("content-disposition", "attachment;filename=" + _BeApoyoFlujo(0).str_WashoutArchivo)
                context.Response.SetCookie(New HttpCookie("fileDownload", "True") With {.Path = "/"})
                context.Response.BinaryWrite(DirectCast(_BeApoyoFlujo(0).byte_Washout, Byte()))
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