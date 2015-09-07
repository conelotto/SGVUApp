Imports SGCVU.BE
Imports SGCVU.BL
Imports SGCVU.DTO
Imports System.IO

Public Class frmApoyoFabricante_UploadFiles
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        If Me.IsPostBack = False Then

            lblApoyoId.Text = String.Empty
            lblOrdenAsignada.Text = String.Empty
            lblUserName.Text = String.Empty

            If Request.QueryString("vApoyoId") IsNot Nothing Then
                If Request.QueryString("vOrdenAsignada") IsNot Nothing Then
                    If Session("LoginAuthentications") IsNot Nothing Then
                        lblApoyoId.Text = Request.QueryString("vApoyoId")
                        lblOrdenAsignada.Text = Request.QueryString("vOrdenAsignada")
                        lblUserName.Text = Session("LoginAuthentications").ToString
                        lblSolicitudNum.Visible = True
                        lblSolicitudNum.Text = String.Empty
                        lblSolicitudNum.Text = Request.QueryString("vOrdenAsignada")
                        btnUploadAttachedFile.Enabled = True
                    Else
                        lblSolicitudNum.Text = String.Empty
                        lblSolicitudNum.Visible = False
                        btnUploadAttachedFile.Enabled = False
                    End If
                Else
                    btnUploadAttachedFile.Enabled = False
                End If
            Else
                btnUploadAttachedFile.Enabled = False
            End If

        End If

    End Sub

    Protected Sub btnUploadAttachedFile_Click(ByVal sender As Object, ByVal e As EventArgs) Handles btnUploadAttachedFile.Click

        Dim _strAnswer As String = String.Empty
        Dim _strExtension As String = String.Empty
        Dim _beExpedienteDocAdjunto As New BE_Expediente_DocumentosAdjuntos
        Dim flUplAttachedFiles As FileUpload = CType(flUplAttachedFile, FileUpload)

        If (lblApoyoId.Text <> String.Empty And lblOrdenAsignada.Text <> String.Empty And lblUserName.Text <> String.Empty) Then

            _strExtension = Path.GetExtension(flUplAttachedFiles.PostedFile.FileName)

            If (_strExtension = ".doc") OrElse (_strExtension = ".docx") OrElse (_strExtension = ".xls") OrElse (_strExtension = ".xlsx") OrElse (_strExtension = ".pdf") Then

                Dim File As HttpPostedFile = flUplAttachedFiles.PostedFile
                Dim byte_File As Byte() = Nothing
                byte_File = New Byte(File.ContentLength - 1) {}
                File.InputStream.Read(byte_File, 0, File.ContentLength)
                _beExpedienteDocAdjunto.str_ArchivoNombre = Path.GetFileName(flUplAttachedFiles.PostedFile.FileName)
                _beExpedienteDocAdjunto.byte_ArchivoAdjunto = byte_File

                If _beExpedienteDocAdjunto.str_ArchivoNombre <> String.Empty And _beExpedienteDocAdjunto.byte_ArchivoAdjunto IsNot Nothing Then

                    _beExpedienteDocAdjunto.int_ApoyoId = Integer.Parse(lblApoyoId.Text)
                    _beExpedienteDocAdjunto.str_UsuarioCreacion = lblUserName.Text
                    _strAnswer = clsExpediente_DocumentosAdjuntos.fn_Insert_ExpedienteDocumentosAdjuntos(_beExpedienteDocAdjunto)

                    lblApoyoId.Text = String.Empty
                    lblOrdenAsignada.Text = String.Empty
                    lblUserName.Text = String.Empty
                    lblSolicitudNum.Text = String.Empty
                    lblSolicitudNum.Visible = False

                End If

            Else
                ScriptManager.RegisterStartupScript(Me, [GetType](), "showalert", "alert('Advertencia: Verificar datos ingresados.' + '\n' + 'Extensión de archivo no es valida.');", True)
            End If

        Else

        End If

    End Sub
End Class