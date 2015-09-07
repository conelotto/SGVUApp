Imports System.String
Imports SGCVU.BE
Imports SGCVU.BL

Public Class _Default
   Inherits System.Web.UI.Page

   Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
      If Me.IsPostBack = False Then
         If Not Session.Item("UserAuthentications") Is Nothing Then
            Dim BEUsuarios As New BE_Usuarios_Modulos
            Dim liBEUsuarios As New List(Of BE_Usuarios_Modulos)

            BEUsuarios.str_UsuarioLogin = Session("LoginAuthentications").ToString()
            liBEUsuarios = clsUsuariosModulos.fn_Select_UsuariosModulos_ByLogin(BEUsuarios)

            If liBEUsuarios IsNot Nothing AndAlso liBEUsuarios.Count > 0 Then

               If liBEUsuarios(0).bl_Module_GestionInventario = True Then
                  tdReservaUnidades.Visible = True
               ElseIf liBEUsuarios(0).bl_Module_GestionInventario = False Then
                  tdReservaUnidades.Visible = False
               End If

               If liBEUsuarios(0).bl_Module_ApoyoFabricante = True Then
                  tdApoyoFabricante.Visible = True
               ElseIf liBEUsuarios(0).bl_Module_ApoyoFabricante = False Then
                  tdApoyoFabricante.Visible = False
               End If

               If liBEUsuarios(0).bl_Module_Bonos = True Then
                  tdBonos.Visible = True
               ElseIf liBEUsuarios(0).bl_Module_Bonos = False Then
                  tdBonos.Visible = False
               End If

               If liBEUsuarios(0).bl_Module_Administracion = True Then
                  tdAdministracion.Visible = True
               ElseIf liBEUsuarios(0).bl_Module_Administracion = False Then
                  tdAdministracion.Visible = False
               End If

            End If
         End If
      End If
   End Sub

   Protected Sub imgbtn_ReservaUnidades_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtn_ReservaUnidades.Click
      Dim strPathUrl As String = String.Format("~\app.ReservaUnidades\frmWorkflow_ReservaUnidades.aspx")
      Response.Redirect(strPathUrl)
   End Sub

   Protected Sub imgbtn_Bonos_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtn_Bonos.Click
      Dim strPathUrl As String = String.Format("~/app.Bonos/frmResultado.aspx")
      Response.Redirect(strPathUrl)
   End Sub

   Protected Sub imgbtn_Administracion_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtn_Administracion.Click
      Dim strPathUrl As String = String.Format("~/app.Administracion/frmAdministracionDefault.aspx")
      Response.Redirect(strPathUrl)
   End Sub

   Protected Sub imgbtn_ApoyoFabricante_Click(ByVal sender As Object, ByVal e As System.Web.UI.ImageClickEventArgs) Handles imgbtn_ApoyoFabricante.Click
      Dim strPathUrl As String = String.Format("~/app.ApoyoFabricante/frmApoyoFabricante_workflow.aspx")
      Response.Redirect(strPathUrl)
   End Sub
End Class