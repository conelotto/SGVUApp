Imports SGCVU.DTO
Imports SGCVU.BL

Module Module1

    Sub Main()

        Try

            Dim _ListFechaSRCNull As New List(Of DTO_Consulta_FechasSalesRecordCard)
            Dim _FechaSRCDB2 = String.Empty
            Dim _strClienteFact = String.Empty
            Dim _strOrdenAsignada = String.Empty

            Dim _BeFechaSRC As New DTO_Consulta_FechasSalesRecordCard
            _ListFechaSRCNull = clsSalesRecordCardFecha.fn_Select_FechaSalesRecordCardNull()

            If _ListFechaSRCNull IsNot Nothing AndAlso _ListFechaSRCNull.Count > 0 Then

                For Each item In _ListFechaSRCNull
                    _FechaSRCDB2 = clsSalesRecordCardFecha.fn_Select_FechaSalesRecordCard(item.OrdenAsignada, item.ClienteFacturacion)

                Next

            End If

        Catch ex As Exception

        End Try

    End Sub

End Module
