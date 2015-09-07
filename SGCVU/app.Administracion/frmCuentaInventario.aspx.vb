Imports SGCVU.BE
Imports SGCVU.BL
Imports SGCVU.DTO
Imports System.Reflection
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms

Public Class frmCuentaInventario
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_CuentaInventario(ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String, ByVal Filter As DTO_CuentaInventario)
        Try

            Dim _ListBeCuenta As New List(Of BE_CuentaInventarioMaestro)
            Dim _ListCuenta = New List(Of Object)
            Dim _BeCuenta As New BE_CuentaInventarioMaestro
            Dim _Result = New s_GridResult
            Dim _CantReg As Integer = rows

            Filter.PrepareData()
            _ListBeCuenta = clsCuentaInventarioMaestro.fn_Select_CuentaInventario_ByFilter(Filter)

            If _ListBeCuenta IsNot Nothing AndAlso _ListBeCuenta.Count > 0 Then

                For Each item In _ListBeCuenta
                    _ListCuenta.Add(New With {
                        Key .int_IdCuentaInventario = item.int_IdCuentaInventario,
                        .str_IdCuenta = item.str_IdCuenta,
                        .str_DescCuentaInventario = item.str_DescCuentaInventario,
                        .int_IdLineaVenta = item.int_IdLineaVenta,
                        .str_DescLineaVenta = item.str_DescLineaVenta,
                        .det_FechaModificacion = item.det_FechaModificacion,
                        .str_UsuarioModificacion = item.str_UsuarioModificacion
                    })
                Next item

                _Result.rows = _ListCuenta
                _Result.page = page
                _Result.total = Math.Ceiling(10D / Convert.ToDecimal(rows))
                _Result.records = _ListCuenta.Count

            End If

            Return _Result


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    Public Structure s_GridResult
        Dim page As Integer
        Dim total As Integer
        Dim records As Integer
        Dim rows As List(Of Object)
    End Structure

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_LineaVenta()
        Try
            Dim _ListBeLineaVenta As New List(Of BE_LineaVentaMaestro)
            Dim _BeLineaVenta As New BE_LineaVentaMaestro
            _ListBeLineaVenta = clsLineaVentaMaestro.fn_Select_LineaVenta_All()

            Return _ListBeLineaVenta

        Catch ex As Exception
            Throw ex
        End Try

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function AsignarLineaVenta(ByVal CuentaInventarioId As String, ByVal LineaVentaId As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _BeCuenta As New BE_CuentaInventarioMaestro

            With _BeCuenta
                .int_IdCuentaInventario = Integer.Parse(CuentaInventarioId)
                .int_IdLineaVenta = Integer.Parse(LineaVentaId)
                .str_UsuarioModificacion = HttpContext.Current.Session("LoginAuthentications")
            End With

            Dim rpta As String = clsCuentaInventarioMaestro.fn_Update_CuentaInventario_LineaVenta(_BeCuenta)

            If rpta <> "OKEY" Then
                Throw New Exception("Error al asignar linea de vents.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

End Class