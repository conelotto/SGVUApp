Imports SGCVU.DA
Imports SGCVU.BE
Imports System.DirectoryServices
Imports System.Configuration

Public Class clsLogin

    Public Shared Function fn_Login(ByVal pi_strIdUsuario As String, ByVal pi_strClaveUsuario As String) As DirectoryEntry
        Try
            Dim LDAP As New clsLDAP
            Dim DirEntry As New DirectoryEntry

            DirEntry = LDAP.fn_LoginLDAP(pi_strIdUsuario, pi_strClaveUsuario)

            If Not DirEntry Is Nothing Then
                Return DirEntry
            Else
                Return Nothing
            End If

        Catch ex As Exception
            Throw ex
        End Try

    End Function


End Class
