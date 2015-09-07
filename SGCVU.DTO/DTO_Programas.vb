Public Class DTO_Programas

    Public Property strCodigo As String
    Public Property strDescripcion As String
    Public Property intFlujo As Integer = 0
    'Public Property intEstado As Boolean = False

    Public Sub PrepareData()

        If Not strCodigo Is Nothing Then strCodigo = strCodigo.Trim()
        If Not strDescripcion Is Nothing Then strDescripcion = strDescripcion.Trim()
        If intFlujo <> Nothing Then intFlujo = intFlujo
        'If intEstado <> Nothing Then intEstado = intEstado

    End Sub

End Class
