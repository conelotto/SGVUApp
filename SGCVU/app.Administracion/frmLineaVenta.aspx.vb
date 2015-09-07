Imports SGCVU.BE
Imports SGCVU.BL
Imports SGCVU.DTO
Imports SGCVU.WS
Imports System.Reflection
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms

Public Class frmLineaVenta
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_LineaVenta(ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String, ByVal Filter As DTO_LineaVenta)
        Try

            Dim _ListBe As New List(Of BE_LineaVentaMaestro)
            Dim _List = New List(Of Object)
            Dim _Be As New BE_LineaVentaMaestro
            Dim _Result = New s_GridResult
            Dim _CantReg As Integer = rows

            Filter.PrepareData()
            _ListBe = clsLineaVentaMaestro.fn_Select_LineaVenta_ByFilter(Filter)

            If _ListBe IsNot Nothing AndAlso _ListBe.Count > 0 Then

                For Each item In _ListBe
                    _List.Add(New With {
                        Key .int_IdLineaVenta = item.int_IdLineaVenta,
                              .str_DescLineaVenta = item.str_DescLineaVenta,
                              .str_NombreFirma = item.str_NombreFirma,
                              .str_CargoFirma = item.str_CargoFirma,
                              .str_NombreImagenFirma = item.str_NombreImagenFirma,
                              .str_ImagenFirmaNombre = item.str_NombreImagenFirma,
                              .str_IdCompania = item.str_IdCompania,
                              .str_CompaniaDes = item.str_CompaniaDes,
                              .int_DiasReserva = item.int_DiasReserva,
                              .bl_Washout = item.bl_Washout,
                              .det_FechaCreacion = item.det_FechaCreacion,
                              .str_UsuarioCreacion = item.str_UsuarioCreacion,
                              .bl_StatusLineaVenta = item.bl_StatusLineaVenta
                    })
                Next item

                _Result.rows = _List
                _Result.page = page
                _Result.total = Math.Ceiling(10D / Convert.ToDecimal(rows))
                _Result.records = _List.Count

            End If

            Return _Result


        Catch ex As Exception
            Throw ex
        End Try

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function EliminarLineaVenta(ByVal LineaId As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _Be As New BE_LineaVentaMaestro

            With _Be
                .int_IdLineaVenta = Integer.Parse(LineaId)
                .str_UsuarioModificacion = HttpContext.Current.Session("LoginAuthentications")
            End With

            Dim rpta As String = clsLineaVentaMaestro.fn_Delete_LineaVentaMaestro(_Be)

            If rpta <> "OKEY" Then
                Throw New Exception("Error al deshabilitar linea de venta.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function RegistrarLineaVenta(ByVal TypeTrans As String, ByVal LineaVentaId As String, ByVal LineaVenta As String, ByVal FirmaNombre As String, ByVal FirmaCargo As String, ByVal Dias As String, ByVal Washout As Boolean, ByVal CompaniaId As String, ByVal Firma As Object)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim rpta As String = String.Empty
            Dim strFile As String = String.Empty
            Dim ListFile() As String = Nothing
            Dim Folder As String = String.Empty
            Dim UploadDirectory As String = String.Empty
            Dim _strFile() As String = Nothing
            Dim _strUrlFile As String = String.Empty
            Dim _FileBytes As Byte() = Nothing
            Dim _TipoAlmacenamiento As Integer = 0

            strFile = Firma

            If strFile <> String.Empty Then
                Folder = ConfigurationManager.AppSettings("ArchivosTemporales")
                UploadDirectory = HttpContext.Current.Request.PhysicalApplicationPath + Folder
                ListFile = strFile.Split(",")
                For Each item As String In ListFile
                    _strFile = item.Split("|")
                    _strUrlFile = UploadDirectory & _strFile(0)
                    _FileBytes = File.ReadAllBytes(_strUrlFile)
                Next
                _TipoAlmacenamiento = 1
            Else
                _TipoAlmacenamiento = 2
            End If

            Dim _Be As New BE_LineaVentaMaestro

            With _Be

                .str_DescLineaVenta = LineaVenta
                .str_NombreFirma = FirmaNombre
                .str_CargoFirma = FirmaCargo
                .int_DiasReserva = Integer.Parse(Dias)
                .bl_Washout = Washout
                .str_IdCompania = CompaniaId
                .int_TipoTransaccion = TypeTrans

                If _TipoAlmacenamiento = 1 Then
                    .str_NombreImagenFirma = _strFile(1)
                    .byte_ImagenFirma = _FileBytes
                End If

                If TypeTrans = "1" Then
                    .str_UsuarioCreacion = HttpContext.Current.Session("LoginAuthentications")
                    rpta = clsLineaVentaMaestro.fn_Insert_LineaVentaMaestro(_Be)
                ElseIf TypeTrans = "2" Then
                    .int_IdLineaVenta = Integer.Parse(LineaVentaId)
                    .int_TipoTransaccion = _TipoAlmacenamiento
                    .str_UsuarioModificacion = HttpContext.Current.Session("LoginAuthentications")
                    rpta = clsLineaVentaMaestro.fn_Update_LineaVentaMaestro(_Be)
                End If

            End With

            If rpta <> "OKEY" Then
                Throw New Exception("Error al registrar linea de venta.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function


    Public Structure s_GridResult
        Dim page As Integer
        Dim total As Integer
        Dim records As Integer
        Dim rows As List(Of Object)
    End Structure

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_Enterprice()
        Try

            Dim _ListMasterTable As New List(Of BE_Master_Table)
            Dim _BeMasterTable As New BE_Master_Table

            _BeMasterTable.str_MasterTable_Key = "Enterprice"
            _ListMasterTable = clsMaster_Table.fn_Select_MasterTable_ByKey(_BeMasterTable)
            Return _ListMasterTable

        Catch ex As Exception
            Throw ex
        End Try
    End Function


End Class