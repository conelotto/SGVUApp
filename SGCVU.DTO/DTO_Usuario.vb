Public Class DTO_Usuario

    Public Property strApellidos As String
    Public Property strNombres As String
    Public Property strUsuarioWindows As String
    Public Property strCompania As String

    Public Sub PrepareData()

        If Not strApellidos Is Nothing Then strApellidos = strApellidos.Trim()
        If Not strNombres Is Nothing Then strNombres = strNombres.Trim()
        If Not strUsuarioWindows Is Nothing Then strUsuarioWindows = strUsuarioWindows.Trim()
        If Not strCompania Is Nothing Then strCompania = strCompania.Trim()

    End Sub

End Class
