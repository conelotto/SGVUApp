Imports System.Web
Imports System.Web.Services
Imports SGCVU.BE
Imports SGCVU.BL
Imports SGCVU.DTO
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Web.UI.HtmlControls

Public Class MaquinaArchivo
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest

        Try

            Dim _strExtencion As String = String.Empty
            Dim _Filter As DTO_SearchParameters = New JavaScriptSerializer().Deserialize(Of DTO_SearchParameters)(HttpContext.Current.Request.Form("jsonFiltro").ToString)

            Dim _liBeMaquinaArchivo As New List(Of BE_MaquinaArchivo)
            Dim _BEMaquinaArchivo As New BE_MaquinaArchivo
            _BEMaquinaArchivo.str_OrdenAsignada = _Filter.strOrdenAsignada
            _BEMaquinaArchivo.int_IdClase = 2
            _liBeMaquinaArchivo = clsMaquina.fn_Select_MaquinaArchivo(_BEMaquinaArchivo) 'clsApoyo_Flujo.fn_Select_ApoyoFlujo_Washout_ByKey(_Filter)

            If _BEMaquinaArchivo IsNot Nothing AndAlso _liBeMaquinaArchivo.Count > 0 Then

                _strExtencion = String.Format("{0}{1}", "application/", _liBeMaquinaArchivo(0).str_NombreArchivo)
                context.Response.Clear()
                context.Response.Buffer = True
                context.Response.ClearHeaders()
                context.Response.ClearContent()
                context.Response.AppendHeader("content-length", DirectCast(_liBeMaquinaArchivo(0).bin_Archivo, Byte()).Length)
                context.Response.ContentType = _strExtencion
                context.Response.AddHeader("content-disposition", "attachment;filename=" + _liBeMaquinaArchivo(0).str_NombreArchivo)
                context.Response.SetCookie(New HttpCookie("fileDownload", "True") With {.Path = "/"})
                context.Response.BinaryWrite(DirectCast(_liBeMaquinaArchivo(0).bin_Archivo, Byte()))
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