Public Class DTO_SearchParameters

    Public Property intApoyoId As Integer = 0
    Public Property strOrdenAsignada As String = String.Empty
    Public Property intExpedienteId As Integer = 0
    Public Property intClaseId As Integer = 0
    Public Property intAttachedFieldId As Integer = 0

    Public Sub PrepareData()

        If intApoyoId <> Nothing Then intApoyoId = intApoyoId
        If intAttachedFieldId <> Nothing Then intAttachedFieldId = intAttachedFieldId
        If strOrdenAsignada <> Nothing Then strOrdenAsignada = strOrdenAsignada
        If intExpedienteId <> Nothing Then intExpedienteId = intExpedienteId
        If intClaseId <> Nothing Then intClaseId = intClaseId
    End Sub

End Class
