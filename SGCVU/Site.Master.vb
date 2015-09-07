Imports SGCVU.BE
Imports SGCVU.BL
Imports System.Data.SqlClient

Public Class Site
   Inherits System.Web.UI.MasterPage

   Dim strPathUrl As String = String.Empty
   Dim strItemMenu As String = String.Empty
   Dim strCodModule As String = String.Empty

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      Try
         If Not Page.IsPostBack Then
            Me.Page.Title = ConfigurationManager.AppSettings("SystemName").ToString

            If Not Session.Item("UserAuthentications") Is Nothing Then
               Me.lblUserName.Text = String.Empty
               Me.lblUserProfile.Text = String.Empty
               Me.lblUserFlow.Text = String.Empty
               Me.lblUserName.Text = String.Format("<b>{0}:</b> {1}", "Bienvenido", Session("UserAuthentications"))
               Me.lblUserProfile.Text = String.Format("<b>{0}:</b> {1}", "Perfil de Acceso", "Consulta General")
               Me.lblUserFlow.Text = String.Format("<b>{0}:</b> {1}", "Perfil de Flujo", "Administrador")

               hdfModule.Value = fn_ObtenerModuloSegunUrl(Page.AppRelativeTemplateSourceDirectory)

               If hdfModule.Value <> String.Empty Then
                  CreatedDynamicMenu(hdfModule.Value)
               End If
            Else
               FormsAuthentication.SignOut()
               FormsAuthentication.RedirectToLoginPage()
            End If

         End If
      Catch ex As Exception
         '   Dim rethrow As Boolean = Exception.HandleException(ex, "ExHandling")
         Throw ex
      End Try
   End Sub

   Private Sub CreatedDynamicMenu(ByVal intModuleId As Integer)
      Dim table As New DataTable()
      Dim strCon As String = System.Configuration.ConfigurationManager.ConnectionStrings("cnFSASGCVU").ConnectionString
      Dim conn As New SqlConnection(strCon)
      Dim sql As String = "SELECT MenuId, ModuloId, Menu, Menu_URL, MenuParentId, Menu_Status, FechaCreacion, FechaModificacion, UsuarioCreacion, UsuarioModificacion FROM dbo.Menu WHERE Menu_Status <> 0 AND ModuloId = '" & intModuleId & "'"
      Dim cmd As New SqlCommand(sql, conn)
      Dim da As New SqlDataAdapter(cmd)
      da.Fill(table)
      Dim view As New DataView(table)
      view.RowFilter = "MenuParentId is NULL"
      For Each row As DataRowView In view
         Dim menuItem As New MenuItem(row("Menu").ToString(), row("MenuId").ToString())
         menuItem.NavigateUrl = row("Menu_URL").ToString()
         NavigationMenu.Items.Add(menuItem)
         AddChildItems(table, menuItem)
      Next
   End Sub

   Private Sub AddChildItems(ByVal table As DataTable, ByVal menuItem As MenuItem)
      Dim viewItem As New DataView(table)
      viewItem.RowFilter = "MenuParentId=" + menuItem.Value
      For Each childView As DataRowView In viewItem
         strItemMenu = String.Format("{0}{1}", " ", childView("Menu"))
         Dim childItem As New MenuItem(strItemMenu, childView("MenuId").ToString())
         childItem.NavigateUrl = childView("Menu_URL").ToString()
         menuItem.ChildItems.Add(childItem)
         AddChildItems(table, childItem)
      Next
   End Sub

   Protected Sub imbtnHome_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imbtnHome.Click
      Response.Redirect("~/Default.aspx")
   End Sub

   Protected Sub imgbtnCloseSession_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtnCloseSession.Click
      Session.Clear()
      FormsAuthentication.RedirectToLoginPage()
   End Sub

   Private Function fn_ObtenerModuloSegunUrl(ByVal pi_url As String)
      If pi_url.Contains("app.Administracion") Then
         Return "1"
      ElseIf pi_url.Contains("app.ApoyoFabricante") Then
         Return "2"
      ElseIf pi_url.Contains("app.ReservaUnidades") Then
         Return "3"
      ElseIf pi_url.Contains("app.Bonos") Then
         Return "4"
      Else
         Return ""
      End If
   End Function
End Class