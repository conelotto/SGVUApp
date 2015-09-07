Public Class DTO_LineaVenta

    Public Property DescLineaVenta As String = String.Empty
    Public Property NombreFirma As String = String.Empty
    Public Property CargoFirma As String = String.Empty
    Public Property IdCompania As String = String.Empty


    Public Sub PrepareData()

        If Not DescLineaVenta Is Nothing Then DescLineaVenta = DescLineaVenta.Trim()
        If Not NombreFirma Is Nothing Then NombreFirma = NombreFirma.Trim()
        If Not CargoFirma Is Nothing Then CargoFirma = CargoFirma.Trim()
        If Not IdCompania Is Nothing Then IdCompania = IdCompania.Trim()

    End Sub

End Class
