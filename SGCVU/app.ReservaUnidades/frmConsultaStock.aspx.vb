Imports SGCVU.DTO

Public Class frmConsultaStock
   Inherits System.Web.UI.Page

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If Not Page.IsPostBack Then
         If Session.Item("UserAuthentications") Is Nothing Then
            FormsAuthentication.SignOut()
            FormsAuthentication.RedirectToLoginPage()
         End If
      End If
   End Sub

   <System.Web.Services.WebMethod(EnableSession:=True)>
   Public Shared Function ConsultarStock()
      Threading.Thread.Sleep(1000)
      Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
      Try
         Dim loginUsuario As String = HttpContext.Current.Session("LoginAuthentications")
         Dim liCuentas = New List(Of Object)

         objRpta.data = liCuentas
      Catch ex As Exception
         objRpta.success = False
         objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
      End Try
      Return objRpta
   End Function

End Class