Imports System.Web
Imports System.Web.Services
Imports SGCVU.BE
Imports SGCVU.BL
Imports SGCVU.DTO
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Web.UI.HtmlControls
Public Class ExpedienteArchivoFirmado
    Implements System.Web.IHttpHandler

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
        Try

            Dim _strExtencion As String = String.Empty
            Dim _Filter As DTO_SearchParameters = New JavaScriptSerializer().Deserialize(Of DTO_SearchParameters)(HttpContext.Current.Request.Form("jsonFiltro").ToString)
            Dim ExpedientrArchivo As New BE_ExpedienteArchivoFirmado
            Dim _liBeExpedienteArchivo As New List(Of BE_ExpedienteArchivoFirmado)
            Dim _BEExpedienteArchivo As New BE_ExpedienteArchivoFirmado
            _BEExpedienteArchivo.int_ExpedienteId = _Filter.intExpedienteId
            _liBeExpedienteArchivo = clsExpediente.fn_Select_ExpedienteArchivofirmado(_BEExpedienteArchivo) ' clsMaquina.fn_Select_MaquinaArchivo(_BEExpedienteArchivo) 'clsApoyo_Flujo.fn_Select_ApoyoFlujo_Washout_ByKey(_Filter)
            Dim bytes As Byte() = Nothing
            If _liBeExpedienteArchivo.Count > 0 Then
                ExpedientrArchivo = _liBeExpedienteArchivo.Find(Function(c) c.int_ClaseId = _Filter.intClaseId)

                If (IsNothing(ExpedientrArchivo)) Then Return
                bytes = ExpedientrArchivo.bin_Archivo ' _liBeExpedienteArchivo.Find(Function(c) c.int_ClaseId = _Filter.intClaseId).bin_Archivo

            End If

            If _BEExpedienteArchivo IsNot Nothing AndAlso _liBeExpedienteArchivo.Count > 0 Then
                _strExtencion = String.Format("{0}{1}", "application/", ExpedientrArchivo.str_NombreArchivo)
                context.Response.Clear()
                context.Response.Buffer = True
                context.Response.ClearHeaders()
                context.Response.ClearContent()
                context.Response.AppendHeader("content-length", DirectCast(bytes, Byte()).Length)
                context.Response.ContentType = _strExtencion
                context.Response.AddHeader("content-disposition", "attachment;filename=" + ExpedientrArchivo.str_NombreArchivo)
                context.Response.SetCookie(New HttpCookie("fileDownload", "True") With {.Path = "/"})
                context.Response.BinaryWrite(DirectCast(bytes, Byte()))
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