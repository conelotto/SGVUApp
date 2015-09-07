Imports SGCVU.BE
Imports SGCVU.BL
Imports System.Web.Security
Imports System.Security.Principal
Imports System.Net
Imports System.Net.Sockets
Imports System.Net.NetworkInformation
Imports SGCVU.BL.FormsAuth

Public Class Login1

    Inherits System.Web.UI.Page

    Dim strUserName As String = String.Empty
    Dim strPassword As String = String.Empty

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Me.IsPostBack = False Then
            If Not Session.Item("UserAuthentications") Is Nothing Then
                FormsAuthentication.RedirectFromLoginPage(Log.UserName, False)
            End If
        End If
    End Sub

    Protected Sub LoginUser_Authenticate(ByVal sender As Object, ByVal e As AuthenticateEventArgs)

        Dim Login As New clsLogin
        Dim BEUsuarios As New BE_Usuarios
        Dim liBEUsuarios As New List(Of BE_Usuarios)

        If Log.UserName <> String.Empty And Log.Password <> String.Empty Then

            Dim adPath As String = ConfigurationManager.AppSettings("LDAP")
            Dim adAuth As LdapAuthentication = New LdapAuthentication(adPath)

            Try
                If (True = adAuth.IsAuthenticated(Log.UserName, Log.Password)) Then

                    BEUsuarios.str_Usuario_Login = Log.UserName
                    liBEUsuarios = clsUsuarios.fn_Select_Usuarios(BEUsuarios)

                    If liBEUsuarios IsNot Nothing AndAlso liBEUsuarios.Count > 0 Then

                        Session.Item("UserAuthentications") = String.Format("{0} {1}", liBEUsuarios(0).str_Usuario_Nombres, liBEUsuarios(0).str_Usuario_Apellidos)
                        Session.Item("LoginAuthentications") = liBEUsuarios(0).str_Usuario_Login
                        Session.Item("IPAuthentications") = ObtenerIp()
                        Session.Item("MacAuthentications") = ObtenerDireccionMAC()

                        If Session("UserAuthentications") <> Nothing Then
                            FormsAuthentication.RedirectFromLoginPage(Log.UserName, False)
                        End If

                    End If

                Else
                    '   Me.lblMensajes.Text = "Authentication did not succeed. Check user name and password."
                End If


            Catch ex As Exception
                '  Me.lblMensajes.Text = "Error authenticating. " & ex.Message
            End Try

        End If
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

    Private Shared Function ObtenerDireccionMAC() As String
        Dim macAddress As String = String.Empty
        For Each nic As NetworkInterface In NetworkInterface.GetAllNetworkInterfaces()
            If nic.OperationalStatus = OperationalStatus.Up Then
                macAddress += nic.GetPhysicalAddress().ToString()
                Exit For
            End If
        Next
        Return (macAddress)
    End Function

End Class