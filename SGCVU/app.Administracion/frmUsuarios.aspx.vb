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

Public Class frmUsuarios
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If Not IsPostBack Then

        End If
    End Sub


    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_Usuarios(ByVal page As Integer, ByVal rows As Integer, ByVal sidx As String, ByVal sord As String, ByVal Filter As DTO_Usuario)
        Try

            Dim _ListBeUsuarios As New List(Of BE_Usuarios)
            Dim _ListUsuarios = New List(Of Object)
            Dim _BeUsuarios As New BE_Usuarios
            Dim _Result = New s_GridResult
            Dim _CantReg As Integer = rows

            Filter.PrepareData()
            _ListBeUsuarios = clsUsuarios.fn_Select_Usuarios_ByFilter(Filter)

            If _ListBeUsuarios IsNot Nothing AndAlso _ListBeUsuarios.Count > 0 Then

                For Each item In _ListBeUsuarios
                    _ListUsuarios.Add(New With {
                        Key .int_UsuarioId = item.int_UsuarioId,
                        .str_CompaniaId = item.str_CompaniaId,
                        .str_CompaniaDes = item.str_CompaniaDes,
                        .str_Usuario_Login = item.str_Usuario_Login,
                        .str_Usuario_Nombres = item.str_Usuario_Nombres,
                        .str_Usuario_Apellidos = item.str_Usuario_Apellidos,
                        .str_Usuario_Email = item.str_Usuario_Email,
                        .str_NroPersonal = item.str_NroPersonal,
                        .str_CodigoAdrian = item.str_CodigoAdrian,
                        .str_CodigoSAP = item.str_CodigoSAP,
                        .str_Funcion = item.str_Funcion,
                        .str_Cargo = item.str_Cargo,
                        .det_FechaCreacion = item.det_FechaCreacion,
                        .str_UsuarioCreacion = item.str_UsuarioCreacion,
                        .det_FechaModificacion = item.det_FechaModificacion,
                        .str_UsuarioModificacion = item.str_UsuarioModificacion,
                        .bl_Usuario_Status = item.bl_Usuario_Status,
                        .bl_Module_Administracion = item.bl_Module_Administracion,
                        .bl_Module_GestionInventario = item.bl_Module_GestionInventario,
                        .bl_Module_ApoyoFabricante = item.bl_Module_ApoyoFabricante,
                        .bl_Module_Bonos = item.bl_Module_Bonos
                    })
                Next item

                _Result.rows = _ListUsuarios
                _Result.page = page
                _Result.total = Math.Ceiling(10D / Convert.ToDecimal(rows))
                _Result.records = _ListUsuarios.Count

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
    Public Shared Function GetData_Module()
        Try

            Dim _ListMasterTable As New List(Of BE_Master_Table)
            Dim _BeMasterTable As New BE_Master_Table

            _BeMasterTable.str_MasterTable_Key = "Modules"
            _ListMasterTable = clsMaster_Table.fn_Select_MasterTable_ByKey(_BeMasterTable)
            Return _ListMasterTable

        Catch ex As Exception
            Throw ex
        End Try
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_RolesAdmin(ByVal UsuarioId As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()

        Try

            Dim _ListBeRoles As New List(Of BE_Roles)
            Dim _ListRoles = New List(Of Object)
            Dim _BeRoles As New BE_Roles

            _BeRoles.int_UsuarioId = UsuarioId
            _BeRoles.int_ModuloId = 37

            _ListBeRoles = clsRoles.fn_Select_RolesByModulo(_BeRoles)

            If _ListBeRoles IsNot Nothing AndAlso _ListBeRoles.Count > 0 Then
                For Each item In _ListBeRoles
                    _ListRoles.Add(New With {
                        Key .int_RolId = item.int_RolId,
                        .int_ModuloId = item.int_ModuloId,
                        .str_RolesDes = item.str_RolesDes,
                        .bl_UsuariosRolesStatus = item.bl_UsuariosRolesStatus
                    })
                Next item

                objRpta.data = _ListRoles

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_RolesApoyo(ByVal UsuarioId As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()

        Try

            Dim _ListBeRoles As New List(Of BE_Roles)
            Dim _ListRoles = New List(Of Object)
            Dim _BeRoles As New BE_Roles

            _BeRoles.int_UsuarioId = UsuarioId
            _BeRoles.int_ModuloId = 24

            _ListBeRoles = clsRoles.fn_Select_RolesByModulo(_BeRoles)

            If _ListBeRoles IsNot Nothing AndAlso _ListBeRoles.Count > 0 Then
                For Each item In _ListBeRoles
                    _ListRoles.Add(New With {
                        Key .int_RolId = item.int_RolId,
                        .int_ModuloId = item.int_ModuloId,
                        .str_RolesDes = item.str_RolesDes,
                        .bl_UsuariosRolesStatus = item.bl_UsuariosRolesStatus
                    })
                Next item

                objRpta.data = _ListRoles

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_RolesGestion(ByVal UsuarioId As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()

        Try

            Dim _ListBeRoles As New List(Of BE_Roles)
            Dim _ListRoles = New List(Of Object)
            Dim _BeRoles As New BE_Roles

            _BeRoles.int_UsuarioId = UsuarioId
            _BeRoles.int_ModuloId = 23

            _ListBeRoles = clsRoles.fn_Select_RolesByModulo(_BeRoles)

            If _ListBeRoles IsNot Nothing AndAlso _ListBeRoles.Count > 0 Then
                For Each item In _ListBeRoles
                    _ListRoles.Add(New With {
                        Key .int_RolId = item.int_RolId,
                        .int_ModuloId = item.int_ModuloId,
                        .str_RolesDes = item.str_RolesDes,
                        .bl_UsuariosRolesStatus = item.bl_UsuariosRolesStatus
                    })
                Next item

                objRpta.data = _ListRoles

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_RolesBonos(ByVal UsuarioId As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()

        Try

            Dim _ListBeRoles As New List(Of BE_Roles)
            Dim _ListRoles = New List(Of Object)
            Dim _BeRoles As New BE_Roles

            _BeRoles.int_UsuarioId = UsuarioId
            _BeRoles.int_ModuloId = 25

            _ListBeRoles = clsRoles.fn_Select_RolesByModulo(_BeRoles)

            If _ListBeRoles IsNot Nothing AndAlso _ListBeRoles.Count > 0 Then
                For Each item In _ListBeRoles
                    _ListRoles.Add(New With {
                        Key .int_RolId = item.int_RolId,
                        .int_ModuloId = item.int_ModuloId,
                        .str_RolesDes = item.str_RolesDes,
                        .bl_UsuariosRolesStatus = item.bl_UsuariosRolesStatus
                    })
                Next item

                objRpta.data = _ListRoles

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function RegistrarUsuario(ByVal Nombres As String, ByVal Apellidos As String, ByVal Login As String, ByVal Email As String, ByVal CompaniaId As String,
                                            ByVal TypeTrans As String, ByVal UsuarioId As String, ByVal NroPersonal As String, ByVal CodigoAdrian As String, ByVal CodigoSAP As String, ByVal Funcion As String, ByVal Cargo As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _BeUsuarios As New BE_Usuarios
            Dim rpta As String = String.Empty

            With _BeUsuarios
                .str_Usuario_Nombres = Nombres
                .str_Usuario_Apellidos = Apellidos
                .str_Usuario_Login = Login
                .str_Usuario_Email = Email
                .str_NroPersonal = NroPersonal
                .str_CodigoAdrian = CodigoAdrian
                .str_CodigoSAP = CodigoSAP
                .str_Funcion = Funcion
                .str_Cargo = Cargo
                .str_CompaniaId = CompaniaId

                If TypeTrans = "1" Then
                    .str_UsuarioCreacion = HttpContext.Current.Session("LoginAuthentications")
                    rpta = clsUsuarios.fn_Insert_Usuarios(_BeUsuarios)
                ElseIf TypeTrans = "2" Then
                    .int_UsuarioId = Integer.Parse(UsuarioId)
                    .str_UsuarioModificacion = HttpContext.Current.Session("LoginAuthentications")
                    rpta = clsUsuarios.fn_Update_Usuarios(_BeUsuarios)
                End If

            End With

            If rpta <> "OKEY" Then
                Throw New Exception("Error al registrar usuario.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function EliminarUsuario(ByVal UsuarioId As String, ByVal UsuarioLogin As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _BeUsuarios As New BE_Usuarios

            With _BeUsuarios
                .int_UsuarioId = Integer.Parse(UsuarioId)
                .str_Usuario_Login = UsuarioLogin
            End With

            Dim rpta As String = clsUsuarios.fn_Delete_Usuarios(_BeUsuarios)

            If rpta <> "OKEY" Then
                Throw New Exception("Error al eliminar usuario.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function DeshabilitarUsuario(ByVal UsuarioId As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _BeUsuarios As New BE_Usuarios

            With _BeUsuarios
                .int_UsuarioId = Integer.Parse(UsuarioId)
                .str_UsuarioModificacion = HttpContext.Current.Session("LoginAuthentications")
            End With

            Dim rpta As String = clsUsuarios.fn_Disabled_Usuarios(_BeUsuarios)

            If rpta <> "OKEY" Then
                Throw New Exception("Error al deshabilitar usuario.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function ObtenerDatosEmpleados(ByVal CodigoEmpleado As String)
        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Try
            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim consultarDatos = New cmpConsultarCRM()
            Dim dataEmpleados = consultarDatos.ObtenerDatosPersonal(CodigoEmpleado)

            objRpta.data = dataEmpleados
        Catch ex As Exception
            objRpta.success = False
            '   objRpta.msg = cmpExcepcion.AdministrarExcepcion(ex, Modulo.InventarioComercial, HttpContext.Current.Session("LoginAuthentications"), HttpContext.Current.Session("IPAuthentications"), HttpContext.Current.Session("MacAuthentications"))
        End Try
        Return objRpta
    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_CuentaInventario(ByVal Usuario As String)

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()

        Try

            Dim _ListBeRoles As New List(Of BE_CuentaUsuario)
            Dim _ListRoles = New List(Of Object)
            Dim _BeRoles As New BE_CuentaUsuario

            _BeRoles.str_IdUsuario = Usuario

            _ListBeRoles = clsUsuarios.fn_Select_UsuariosCuentasInventario(_BeRoles)

            If _ListBeRoles IsNot Nothing AndAlso _ListBeRoles.Count > 0 Then
                For Each item In _ListBeRoles
                    _ListRoles.Add(New With {
                        Key .str_IdCuenta = item.str_IdCuenta,
                    .str_DescCuentaInventario = item.str_DescCuentaInventario,
                    .str_IdUsuario = item.str_IdUsuario,
                    .bl_CuentaUsuarioStatus = item.bl_CuentaUsuarioStatus
                    })
                Next item

                objRpta.data = _ListRoles

            End If

        Catch ex As Exception
            Throw ex
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function Asignar_CuentaInventario(ByVal Usuario As String, ByVal ListTemp As List(Of String()))

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Dim blRpta As Boolean = True
        Dim rpta As String = String.Empty

        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim _BeUsuarios As New BE_Usuarios

            If ListTemp IsNot Nothing AndAlso ListTemp.Count > 0 Then

                Dim dtDataCuentas As New DataTable()

                Dim cols As Integer = 0
                For Each array In ListTemp
                    If array.Length > cols Then
                        cols = array.Length
                    End If
                Next

                For i As Integer = 0 To cols - 1
                    dtDataCuentas.Columns.Add()
                Next

                For Each array In ListTemp
                    dtDataCuentas.Rows.Add(array)
                Next

                If dtDataCuentas IsNot Nothing Then

                    Using _Conec As New SqlConnection(ConfigurationManager.ConnectionStrings("cnFSASGCVU").ToString())

                        Dim mapping0 As New SqlBulkCopyColumnMapping("Column1", "IdCuenta")
                        Dim mapping1 As New SqlBulkCopyColumnMapping("Column2", "IdUsuario")

                        Try
                            _Conec.Open()
                            Dim bulkCopy As New SqlBulkCopy(_Conec)
                            bulkCopy.ColumnMappings.Add(mapping0)
                            bulkCopy.ColumnMappings.Add(mapping1)
                            bulkCopy.DestinationTableName = "Temp_UsuarioCuentaInventario"
                            bulkCopy.WriteToServer(dtDataCuentas)

                            blRpta = True

                        Catch ex As Exception
                            blRpta = False
                        Finally
                            _Conec.Close()
                        End Try

                    End Using

                    If blRpta = True Then
                        _BeUsuarios.str_Usuario_Login = Usuario
                        _BeUsuarios.str_UsuarioCreacion = HttpContext.Current.Session("LoginAuthentications")
                        rpta = clsUsuarios.fn_Insert_UsuariosCuentasInventario(_BeUsuarios)
                    ElseIf blRpta = False Then
                        rpta = "FALSE"
                    End If

                    If rpta <> "OKEY" Then
                        Throw New Exception("Error al registrar solicitud.")
                    End If

                    objRpta.data = rpta

                End If

            End If

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function Asignar_RolesPermisos(ByVal UsuarioId As String, ByVal mAdmin As Boolean, ByVal mGestion As Boolean, ByVal mApoyo As Boolean, ByVal mBonos As Boolean,
                                                  ByVal ListTempAdmin As List(Of String()), ByVal ListTempGestion As List(Of String()),
                                                  ByVal ListTempApoyo As List(Of String()), ByVal ListTempBono As List(Of String()))

        Dim objRpta As DTO_RptaPeticion = New DTO_RptaPeticion()
        Dim blRpta As Boolean = True
        Dim rpta As String = String.Empty
        Dim TypeTransaction As Integer = 0

        Try

            If HttpContext.Current.Session("LoginAuthentications") Is Nothing Then
                objRpta.sesionValida = False
                Return objRpta
            End If

            Dim dtRolesPermisos As New DataTable()

            If ListTempAdmin IsNot Nothing AndAlso ListTempAdmin.Count > 0 Then
                Dim cols As Integer = 0
                For Each array In ListTempAdmin
                    If array.Length > cols Then
                        cols = array.Length
                    End If
                Next

                For i As Integer = 0 To cols - 1
                    dtRolesPermisos.Columns.Add()
                Next

                For Each array In ListTempAdmin
                    dtRolesPermisos.Rows.Add(array)
                Next
            End If

            If ListTempGestion IsNot Nothing AndAlso ListTempGestion.Count > 0 Then
                Dim cols As Integer = 0
                For Each array In ListTempGestion
                    If array.Length > cols Then
                        cols = array.Length
                    End If
                Next

                For i As Integer = 0 To cols - 1
                    dtRolesPermisos.Columns.Add()
                Next

                For Each array In ListTempGestion
                    dtRolesPermisos.Rows.Add(array)
                Next
            End If

            If ListTempApoyo IsNot Nothing AndAlso ListTempApoyo.Count > 0 Then
                Dim cols As Integer = 0
                For Each array In ListTempApoyo
                    If array.Length > cols Then
                        cols = array.Length
                    End If
                Next

                For i As Integer = 0 To cols - 1
                    dtRolesPermisos.Columns.Add()
                Next

                For Each array In ListTempApoyo
                    dtRolesPermisos.Rows.Add(array)
                Next
            End If

            If ListTempBono IsNot Nothing AndAlso ListTempBono.Count > 0 Then
                Dim cols As Integer = 0
                For Each array In ListTempBono
                    If array.Length > cols Then
                        cols = array.Length
                    End If
                Next

                For i As Integer = 0 To cols - 1
                    dtRolesPermisos.Columns.Add()
                Next

                For Each array In ListTempBono
                    dtRolesPermisos.Rows.Add(array)
                Next
            End If

            'If (ListTempAdmin IsNot Nothing AndAlso ListTempAdmin.Count > 0) AndAlso (ListTempGestion IsNot Nothing AndAlso ListTempGestion.Count > 0) AndAlso
            '    (ListTempApoyo IsNot Nothing AndAlso ListTempApoyo.Count > 0) AndAlso (ListTempBono IsNot Nothing AndAlso ListTempBono.Count > 0) Then

            If dtRolesPermisos IsNot Nothing AndAlso dtRolesPermisos.Rows.Count > 0 Then
                Using _Conec As New SqlConnection(ConfigurationManager.ConnectionStrings("cnFSASGCVU").ToString())
                    Dim mapping0 As New SqlBulkCopyColumnMapping("Column1", "UsuarioId")
                    Dim mapping1 As New SqlBulkCopyColumnMapping("Column2", "RolId")

                    Try
                        _Conec.Open()
                        Dim bulkCopy As New SqlBulkCopy(_Conec)
                        bulkCopy.ColumnMappings.Add(mapping0)
                        bulkCopy.ColumnMappings.Add(mapping1)
                        bulkCopy.DestinationTableName = "Temp_UsuariosRoles"
                        bulkCopy.WriteToServer(dtRolesPermisos)

                        blRpta = True

                    Catch ex As Exception
                        blRpta = False
                    Finally
                        _Conec.Close()
                    End Try
                End Using

                TypeTransaction = 1

                '   End If

            Else
                TypeTransaction = 2
            End If

            If blRpta = True Then

                Dim _BeUsuariosMod As New BE_Usuarios_Modulos
                _BeUsuariosMod.int_UsuarioId = Integer.Parse(UsuarioId)
                _BeUsuariosMod.bl_Module_Administracion = mAdmin
                _BeUsuariosMod.bl_Module_GestionInventario = mGestion
                _BeUsuariosMod.bl_Module_ApoyoFabricante = mApoyo
                _BeUsuariosMod.bl_Module_Bonos = mBonos
                _BeUsuariosMod.int_TypeTransaction = TypeTransaction
                _BeUsuariosMod.str_UsuarioCreacion = HttpContext.Current.Session("LoginAuthentications")
                rpta = clsUsuariosModulos.fn_Insert_UsuariosModulos(_BeUsuariosMod)

            ElseIf blRpta = False Then
                rpta = "FALSE"
            End If

            If rpta <> "OKEY" Then
                Throw New Exception("Error al registrar solicitud.")
            End If

            objRpta.data = rpta

        Catch ex As Exception
            objRpta.success = False
            objRpta.msg = String.Format("Message: {0} - StackTrace: {1}", ex.Message, ex.StackTrace)
        End Try

        Return objRpta

    End Function




End Class