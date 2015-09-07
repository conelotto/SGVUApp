Imports System.Web
Imports System.Web.Services
Imports SGCVU.BE
Imports SGCVU.BL
Imports SGCVU.DTO
Imports Microsoft.Reporting.WebForms
Imports System.Web.Script.Serialization
Imports System.IO
Imports System.Web.UI.HtmlControls
Imports System.Reflection
Imports System.Globalization

Public Class ApoyoFabricante
    Implements System.Web.IHttpHandler
    Implements System.Web.SessionState.IRequiresSessionState

    Sub ProcessRequest(ByVal context As HttpContext) Implements IHttpHandler.ProcessRequest
      Try
         Dim strPathReport As String = String.Empty
         Dim _Filter As DTO_Apoyo_Flujo = New JavaScriptSerializer().Deserialize(Of DTO_Apoyo_Flujo)(HttpContext.Current.Request.Form("jsonFiltro").ToString)

         Dim _rptBeApoyoFlujo As New List(Of BE_Apoyo_Flujo)
         _rptBeApoyoFlujo = clsApoyo_Flujo.fn_Select_ApoyoFlujo_ByFilter(_Filter)

         If _rptBeApoyoFlujo IsNot Nothing AndAlso _rptBeApoyoFlujo.Count > 0 Then

            strPathReport = System.Web.HttpContext.Current.Server.MapPath("~")
            strPathReport += "app.ApoyoFabricante\Reports\rpt_FlujoApoyo.rdlc"

            Dim rvwReport As New Microsoft.Reporting.WebForms.ReportViewer()
            rvwReport.LocalReport.ReportPath = strPathReport
            rvwReport.LocalReport.DataSources.Clear()
            Dim rptDataSource As New ReportDataSource("DataSet1")
            rptDataSource.Value = _rptBeApoyoFlujo
            rvwReport.LocalReport.DataSources.Add(rptDataSource)

            Dim warnings As Warning()
            Dim streamIds As String()
            Dim strMimeType As String = String.Empty
            Dim strEncoding As String = String.Empty
            Dim strExtension As String = String.Empty

            Dim bytes As Byte() = rvwReport.LocalReport.Render("Excel", Nothing, strMimeType, strEncoding, strExtension, streamIds, warnings)

            context.Response.Buffer = True
            context.Response.Clear()
            context.Response.ClearHeaders()
            context.Response.ClearContent()
            context.Response.AppendHeader("content-length", bytes.Length)
            context.Response.ContentType = strMimeType
            context.Response.AddHeader("content-disposition", Convert.ToString("attachment; filename=" + "Flujo_Apoyo_Fabricante" + ".") & strExtension)
            context.Response.SetCookie(New HttpCookie("fileDownload", "True") With {.Path = "/"})
            context.Response.BinaryWrite(bytes)
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