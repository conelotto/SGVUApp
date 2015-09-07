Imports SGCVU.BE
Imports SGCVU.BL
Imports System.Reflection
Imports Microsoft.Practices.EnterpriseLibrary.ExceptionHandling

Public Class frmTipoFlujo
    Inherits System.Web.UI.Page

    Protected Sub Page_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    End Sub

    Private Shared Property Session_TipoFlujo() As Object
        Get
            Return HttpContext.Current.Session("SessionTipoFlujo")
        End Get
        Set(ByVal value As Object)
            HttpContext.Current.Session("SessionTipoFlujo") = value
        End Set
    End Property

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function GetData_TipoFlujo(ByVal sortColumn As String, ByVal sortOrder As String, ByVal pageSize As String, ByVal currentPage As String)

        Dim BETipoFlujo As New BE_TipoFlujo
        Dim liBETipoFlujo As New List(Of BE_TipoFlujo)

        liBETipoFlujo = clsTipoFlujo.fn_Select_TipoFlujo(BETipoFlujo)
        Dim dtTipoFlujo As DataTable = ToDataTable(liBETipoFlujo)
        Dim sgResult = New s_GridResult

        If liBETipoFlujo IsNot Nothing AndAlso liBETipoFlujo.Count > 0 Then

            Dim srdAdded = New List(Of s_RowData)
            Dim fila As Integer = 1

            Try
                For Each drFila As DataRow In dtTipoFlujo.Rows
                    Dim srdNew = New s_RowData
                    srdNew.id = fila
                    ReDim srdNew.cell(6)
                    srdNew.cell(0) = drFila.Item(0)
                    srdNew.cell(1) = drFila.Item(1)
                    srdNew.cell(2) = drFila.Item(2)
                    srdNew.cell(3) = drFila.Item(3)
                    srdNew.cell(4) = drFila.Item(4)
                    srdNew.cell(5) = drFila.Item(5)
                    fila = fila + 1
                    srdAdded.Add(srdNew)
                Next
            Finally
            End Try

            sgResult.rows = srdAdded.ToArray
            sgResult.page = Val(currentPage)
            sgResult.total = dtTipoFlujo.Rows.Count
            sgResult.records = srdAdded.Count

        End If
        Return sgResult

    End Function

    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function Delete_TipoFlujo(ByVal int_TipoFlujoId As String)

        Dim strResult As String = String.Empty

        Try
            Dim BETipoFlujo As New BE_TipoFlujo
            BETipoFlujo.int_TipoFlujoId = int_TipoFlujoId
            clsTipoFlujo.fn_Delete_TipoFlujo(BETipoFlujo)
            strResult = "1"

        Catch ex As Exception
            strResult = "0"
            Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try

        Return strResult

    End Function
    <System.Web.Services.WebMethod(EnableSession:=True)>
    Public Shared Function Save_TipoFlujo(ByVal strOperacion As String, ByVal strPrimaryKey As String, ByVal strTipoFlujo As String, ByVal strUsuario As String) As String

        Dim strResult As String = String.Empty
        '    Dim BEUsuarioLDAP As New BE_UsuarioLDAP
        'BEUsuarioLDAP = Session.Item("BE_UsuarioLDAP")

        Try

            Dim BETipoFlujo As New BE_TipoFlujo
            BETipoFlujo.str_TipoFlujoDesc = strTipoFlujo

            Select Case strOperacion.ToUpper
                Case "N"
                    BETipoFlujo.str_UsuarioCreacion = "COSAPISOFTANALISTA6"
                    clsTipoFlujo.fn_Insert_TipoFlujo(BETipoFlujo)
                    Exit Select
                Case "M"
                    BETipoFlujo.int_TipoFlujoId = strPrimaryKey
                    BETipoFlujo.str_UsuarioModificacion = "COSAPISOFTANALISTA6" ' BEUsuarioLDAP.sAMAccountName
                    clsTipoFlujo.fn_Update_TipoFlujo(BETipoFlujo)
                    Exit Select
            End Select

            strResult = "1"

        Catch ex As Exception

            strResult = "2"
            Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try

        Return strResult

    End Function

    Public Structure s_GridResult
        Dim page As Integer
        Dim total As Integer
        Dim records As Integer
        Dim rows() As s_RowData
    End Structure

    Public Structure s_RowData
        Dim id As Integer
        Dim cell() As String
    End Structure

    Public Shared Function ToDataTable(Of T)(ByVal items As List(Of T)) As DataTable
        Dim dataTable As New DataTable(GetType(T).Name)
        Dim Props As PropertyInfo() = GetType(T).GetProperties(BindingFlags.[Public] Or BindingFlags.Instance)
        For Each prop As PropertyInfo In Props
            dataTable.Columns.Add(prop.Name)
        Next
        For Each item As T In items
            Dim values = New Object(Props.Length - 1) {}
            For i As Integer = 0 To Props.Length - 1
                values(i) = Props(i).GetValue(item, Nothing)
            Next
            dataTable.Rows.Add(values)
        Next
        Return dataTable
    End Function

End Class