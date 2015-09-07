Imports SGCVU.BE
Imports SGCVU.BL
Imports SGCVU.DTO
Imports System.Reflection
Imports System.Globalization
Imports System.Data.SqlClient
Imports System.IO
Imports System.Web.UI.HtmlControls
Imports Microsoft.Reporting.WebForms

Public Class frmApoyoFabricante_Programas
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_Programas(ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String, ByVal Filter As DTO_Programas)
        Try

            Dim _ListBeProgramas As New List(Of BE_Programas)
            Dim _ListProgramas = New List(Of Object)
            Dim _BeUsuarios As New BE_Programas
            Dim _Result = New s_GridResult
            Dim _CantReg As Integer = rows

            Filter.PrepareData()
            _ListBeProgramas = clsProgramas.fn_Select_Programas_ByFilter(Filter)

            If _ListBeProgramas IsNot Nothing AndAlso _ListBeProgramas.Count > 0 Then

                For Each item In _ListBeProgramas
                    _ListProgramas.Add(New With {
                        Key .int_ProgramasId = item.int_ProgramasId,
                            .str_IdProgramaCAT = item.str_IdProgramaCAT,
                            .str_DescPrograma = item.str_DescPrograma,
                            .det_FechaInicio = item.det_FechaInicio,
                            .det_FechaFin = item.det_FechaFin,
                            .det_FechaCreacion = item.det_FechaCreacion,
                            .str_UsuarioCreacion = item.str_UsuarioCreacion,
                            .det_FechaModificacion = item.det_FechaModificacion,
                            .str_UsuarioModificacion = item.str_UsuarioModificacion,
                            .str_RolFlujoDesc = item.str_RolFlujoDesc,
                            .bl_ProgramaStatus = item.bl_ProgramaStatus,
                            .int_RolFlujoId = item.int_RolFlujoId})
                Next item

                _Result.rows = _ListProgramas
                _Result.page = page
                _Result.total = Math.Ceiling(10D / Convert.ToDecimal(rows))
                _Result.records = _ListProgramas.Count

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
    Public Shared Function GetData_Flujo()
        Try

            Dim _ListRolFlujo As New List(Of BE_RolFlujos)
            Dim _BeRolFlujo As New BE_RolFlujos

            _BeRolFlujo.int_TipoFlujoId = 1
            _ListRolFlujo = clsRolFlujos.fn_Select_RolFlujo_ByIdTipoFlujo(_BeRolFlujo)
            Return _ListRolFlujo

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_Status()
        Try

            Dim _ListMasterTable As New List(Of BE_Master_Table)
            Dim _BeMasterTable As New BE_Master_Table

            _BeMasterTable.str_MasterTable_Key = "Estados"
            _ListMasterTable = clsMaster_Table.fn_Select_MasterTable_ByKey(_BeMasterTable)
            Return _ListMasterTable

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function RegistrarProgramas(ByVal Codigo As String, ByVal Descripcion As String, ByVal Flujo As String, ByVal FechaInicio As String, ByVal FechaFin As String, ByVal TypeTrans As String, ByVal ProgramaId As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _BeProgramas As New BE_Programas
            Dim rpta As String = String.Empty

            With _BeProgramas
                .str_IdProgramaCAT = Codigo
                .str_DescPrograma = Descripcion
                .int_RolFlujoId = Integer.Parse(Flujo)
                .det_FechaInicio = DateTime.Parse(FechaInicio)
                .det_FechaFin = DateTime.Parse(FechaFin)

                If TypeTrans = "1" Then
                    .str_UsuarioCreacion = HttpContext.Current.Session("LoginAuthentications")
                    rpta = clsProgramas.fn_Insert_Programas(_BeProgramas)
                ElseIf TypeTrans = "2" Then
                    .int_ProgramasId = Integer.Parse(ProgramaId)
                    .str_UsuarioModificacion = HttpContext.Current.Session("LoginAuthentications")
                    rpta = clsProgramas.fn_Update_Programas(_BeProgramas)
                End If

            End With


            If rpta <> "OKEY" Then
                Throw New Exception("Error al registrar programa.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function EliminarProgramas(ByVal ProgramaId As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _BeProgramas As New BE_Programas

            With _BeProgramas
                .int_ProgramasId = Integer.Parse(ProgramaId)
                .str_UsuarioModificacion = HttpContext.Current.Session("LoginAuthentications")
            End With

            Dim rpta As String = clsProgramas.fn_Delete_Programas(_BeProgramas)

            If rpta <> "OKEY" Then
                Throw New Exception("Error al deshabilitar programa.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

End Class