Imports System.String
Imports System.DirectoryServices
Imports System.Configuration

Public Class clsLDAP

   Public Function fn_LoginLDAP(ByVal pi_strNombreUsuario As String, ByVal pi_strClaveUsuario As String) As DirectoryEntry
      Try
         Dim strDominio As String = ConfigurationManager.AppSettings("LDAP")
         Dim strDomFerreyros As String = ConfigurationManager.AppSettings("Dominio")
         Dim strDominioPassword As String = Concat(strDomFerreyros, "@\", pi_strNombreUsuario)

         Dim objUser As DirectoryEntry
         Dim objDirectoryEntry As New DirectoryEntry(strDominio, strDominioPassword, pi_strClaveUsuario)
            objUser = objDirectoryEntry

         Return objUser
      Catch ex As Exception
         Return Nothing
      End Try
   End Function

   Public Shared Function fn_ObtenerCorreoLDAP_IdUsuario(ByVal pi_strIdUsuario As String) As String
      Try

         Dim objDirectoryEntry As New DirectoryEntry
         Dim objDirectorySearcher As New DirectorySearcher '(objDirectoryEntry)

         objDirectoryEntry = AutenticaLDAP()
         objDirectorySearcher = New DirectorySearcher(objDirectoryEntry)

         Dim objUser As DirectoryEntry
            Dim objSearchResult As SearchResult
         objDirectorySearcher.Filter = Concat("(SAMAccountName=", pi_strIdUsuario, ")") 'mail
         objSearchResult = objDirectorySearcher.FindOne()
         objUser = objSearchResult.GetDirectoryEntry()


         Dim NameDA() As String = objUser.Name.Split("="c)



         Dim strCorreo As String = String.Empty
         If Not objUser.Properties("mail").Value Is Nothing Then strCorreo = objUser.Properties("mail").Value.ToString()

         Return strCorreo
      Catch ex As Exception
         Return String.Empty
      End Try
   End Function

   Public Shared Function fn_Obtener_SAMAccountName_LDAP_IdUsuario(ByVal pi_strCorreoUsuario As String, ByVal pi_strEmployeeID As String) As String
      Try


         Dim objDirectoryEntry As New DirectoryEntry
         Dim objDirectorySearcher As New DirectorySearcher '(objDirectoryEntry)

         objDirectoryEntry = AutenticaLDAP()
         objDirectorySearcher = New DirectorySearcher(objDirectoryEntry)

         Dim objUser As DirectoryEntry

         Dim objSearchResult As SearchResult

         If pi_strCorreoUsuario <> String.Empty AndAlso pi_strEmployeeID = String.Empty Then
            objDirectorySearcher.Filter = Concat("(&(objectCategory=person)(objectClass=user)(mail=", pi_strCorreoUsuario, "))")
         ElseIf pi_strCorreoUsuario = String.Empty AndAlso pi_strEmployeeID <> String.Empty Then
            objDirectorySearcher.Filter = Concat("(employeeID=", pi_strEmployeeID, ")")
         End If

         Dim collUsers As SearchResultCollection = objDirectorySearcher.FindAll()

         objSearchResult = collUsers(0)

         objUser = objSearchResult.GetDirectoryEntry()

         Dim NameDA() As String = objUser.Name.Split("="c)

            Dim strSAMAccountName As String = String.Empty
         If Not objUser.Properties("SAMAccountName").Value Is Nothing Then strSAMAccountName = objUser.Properties("SAMAccountName").Value.ToString()

         Return strSAMAccountName
      Catch ex As Exception
         Return String.Empty
      End Try
   End Function


   Private Shared Function AutenticaLDAP() As DirectoryEntry
      Try
         Dim strDominio As String = ConfigurationManager.AppSettings("LDAP").ToString
         Dim strDomFerreyros As String = ConfigurationManager.AppSettings("Dominio").ToString

         Dim usrAppBb As String = ConfigurationManager.AppSettings("usrAppBb").ToString
         Dim pasAppBb As String = ConfigurationManager.AppSettings("pasAppBb").ToString

         Dim strDominioPassword As String = Concat(strDomFerreyros, "@\", usrAppBb)

         Dim objDirectoryEntry As New DirectoryEntry '(strDominio, strDominioPassword, pasAppBb)
         objDirectoryEntry = New DirectoryEntry(strDominio, strDominioPassword, pasAppBb)

         Dim objDirectorySearcher As New DirectorySearcher(objDirectoryEntry)

         Return objDirectoryEntry
      Catch ex As Exception
         Return Nothing
      End Try
   End Function

End Class
