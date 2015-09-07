Imports SGCVU.BE

Public Class cmpCrearNumeroCarta
    Public Shared Function fn_CrearNumeroCarta() As Integer
        Try
            Dim liBEContadorCarta As New List(Of BE_ContadorCarta)
            Dim BEContadorCarta As New BE_ContadorCarta

            Dim intNumeroCarta As Integer = 0

            liBEContadorCarta = clsContadorCarta.fn_Transaction_ContadorCarta(BEContadorCarta)

            For Each it As BE_ContadorCarta In liBEContadorCarta
                intNumeroCarta = it.int_NumeroCarta
            Next it

            Return intNumeroCarta
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
