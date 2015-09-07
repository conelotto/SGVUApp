Imports SGCVU.BE
Imports SGCVU.BL
Imports System.Reflection
Imports System.Globalization
Imports SGCVU.DTO
Imports System.Web.Security
Imports System.String

Public Class frmGenerarIncidente
    Inherits System.Web.UI.Page

#Region "SERVICIOS WEB"

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerIncidentes(ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String, ByVal pIdCompania As String, ByVal pCodCliente As String, ByVal pDesCliente As String)
        'Threading.Thread.Sleep(1000)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()

        Try

            Dim liBEMaquina As New List(Of DTO_Maquina)
            Dim vBE_Maquina As New BE_Maquina

            Dim total As Integer = 0

            With vBE_Maquina
                .str_CompaniaId = pIdCompania.Trim
                .str_ClienteId = pCodCliente.Trim
                .str_ClienteDesc = pDesCliente.Trim
            End With

            liBEMaquina = clsMaquina.fn_Select_Maquina_CodCliente(total, page, rows, vBE_Maquina)

            If liBEMaquina.Count > 0 Then
                total = liBEMaquina.Item(0).TotalRegistros
            End If

            objRpta.data = New With {Key .rows = liBEMaquina,
                                           .page = page,
                                           .total = Math.Ceiling(total / Convert.ToDecimal(rows)),
                                           .records = total
                                          } 'liBEMaquina
            Return objRpta.data

        Catch ex As Exception
            objRpta.success = False
        End Try

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GenerarExpediente(ByVal pOrdenes As String)

        Dim Orden() As String = pOrdenes.Split(",")
        Dim liBEOrdenes As New List(Of BE_Maquina)
        Dim BEOrden As BE_Maquina
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Dim Mensaje As String = String.Empty
        Try
            For Each item As String In Orden
                BEOrden = New BE_Maquina
                BEOrden = clsMaquina.fn_Select_Maquina_Orden(item)
                liBEOrdenes.Add(BEOrden)
            Next


            If liBEOrdenes.Count > 0 Then
                ''''''''''''''''''''''''''''''''''''''''''''''''''''
                ''Proceso de creación de expediente''
                Dim intExpedienteId As Integer = 0
                intExpedienteId = cmpCrearExpediente.fn_CrearExpedienteNew("1", liBEOrdenes, False)
                ''''''''''''''''''''''''''''''''''''''''''''''''''''

                If intExpedienteId > 0 Then
                    Mensaje = Concat("Se creo el expediente N° ", intExpedienteId.ToString.PadLeft(5, "0"), ".")
                Else
                    Mensaje = "Las ordenes seleccionadas no cumplen las validaciones necesarias para crear expediente"
                End If

            End If
            objRpta.data = Mensaje

            Return objRpta

        Catch ex As Exception
            objRpta.success = False
        End Try
    End Function

#End Region

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

End Class