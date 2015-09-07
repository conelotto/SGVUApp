Imports IBM.Data.DB2.iSeries
Imports System.Configuration

Imports SGCVU.BE
Imports SGCVU.DTO

Public Class clsAS400

   Public Shared Function fn_AbrirConexion() As iDB2Connection
      Try
         Dim strCn As String = ConfigurationManager.ConnectionStrings("cnLIBR08").ConnectionString
         Dim cnAS400 As New iDB2Connection(strCn)

         If cnAS400.State <> ConnectionState.Open Then
            cnAS400.Open()
         End If

         Return cnAS400
      Catch ex As Exception
         Return Nothing
      End Try
   End Function

   Public Shared Sub sb_CerrarConexion(ByVal pi_cnAs400 As iDB2Connection)
      Try
         If pi_cnAs400.State <> ConnectionState.Closed Then
            pi_cnAs400.Close()
         End If
      Catch ex As Exception
         Throw ex
      End Try
   End Sub

   Public Shared Sub fn_EjecutarSelect(ByVal pi_strConsulta As String, ByRef po_liEntidad As Object, ByVal pi_objParametros As Object)
      Dim cnAS400 As New iDB2Connection
      Try
         cnAS400 = fn_AbrirConexion()

         Dim da As New iDB2DataAdapter(pi_strConsulta, cnAS400)
         Dim ds As New DataSet

         With da.SelectCommand
            .CommandType = CommandType.Text
            sb_CargaParametros(da.SelectCommand, pi_objParametros)
            .CommandTimeout = 600
            '.ExecuteReader()
         End With

         da.Fill(ds, "dtb")

         fn_MapeoEntidad(ds.Tables(0), po_liEntidad)
      Catch ex As Exception
         Throw ex
      Finally
         sb_CerrarConexion(cnAS400)
      End Try
   End Sub

   Public Shared Function fn_EjecutarSelect(Of T)(ByVal pi_strConsulta As String, ByVal pi_objParametros As Object)
      Dim cnAS400 As New iDB2Connection
      Try
         cnAS400 = fn_AbrirConexion()

         Dim da As New iDB2DataAdapter(pi_strConsulta, cnAS400)
         Dim ds As New DataSet

         With da.SelectCommand
            .CommandType = CommandType.Text
            sb_CargaParametros(da.SelectCommand, pi_objParametros)
            .CommandTimeout = 600
            '.ExecuteReader()
         End With

         da.Fill(ds, "dtb")

         Return clsConvertDatatableToList.fn_ConvertToList(Of T)(ds.Tables(0))
      Catch ex As Exception
         Throw ex
      Finally
         sb_CerrarConexion(cnAS400)
      End Try
   End Function

   Public Overloads Shared Sub sb_CargaParametros(ByRef po_db2Cmd As iDB2Command, ByVal pi_objParms(,) As Object)
      Try
         Dim intContador As Integer = 0

         With po_db2Cmd
            For intContador = pi_objParms.GetLowerBound(0) To pi_objParms.GetUpperBound(0)
               Dim db2Par As New iDB2Parameter

               db2Par.ParameterName = pi_objParms(intContador, 0)
               db2Par.iDB2DbType = pi_objParms(intContador, 1)
               db2Par.Value = pi_objParms(intContador, 2)

               If pi_objParms(intContador, 1) = iDB2DbType.iDB2SmallInt Or pi_objParms(intContador, 1) = iDB2DbType.iDB2Integer Then
                  If Not (pi_objParms(intContador, 2) Is Nothing Or CStr(pi_objParms(intContador, 2)) = String.Empty) Then
                     db2Par.Value = CInt(pi_objParms(intContador, 2))
                  Else
                     'Par.Value = Parms(i, 2)
                     db2Par.Value = Convert.DBNull
                  End If
               End If

               If pi_objParms(intContador, 1) = iDB2DbType.iDB2Decimal Or pi_objParms(intContador, 1) = iDB2DbType.iDB2Double Then
                  If Not (pi_objParms(intContador, 2) Is Nothing Or CStr(pi_objParms(intContador, 2)) = String.Empty) Then
                     db2Par.Value = CDbl(pi_objParms(intContador, 2))
                  Else
                     'Par.Value = Parms(i, 2)
                     db2Par.Value = Convert.DBNull
                  End If
               End If

               If pi_objParms(intContador, 3) <> Nothing Then db2Par.Size = pi_objParms(intContador, 3)

               .Parameters.Add(db2Par)
            Next intContador
         End With
      Catch ex As Exception
      End Try
   End Sub

   Public Shared Sub sb_Update(ByVal pi_strConsulta As String) ', ByRef po_liEntidad As Object)
      Dim cnAS400 As New iDB2Connection
      Try
         cnAS400 = fn_AbrirConexion()

         Dim cmm As New iDB2Command(pi_strConsulta, cnAS400)
         With cmm
            .CommandText = pi_strConsulta
            .ExecuteNonQuery()
         End With

      Catch ex As Exception
         Throw ex
      Finally
         sb_CerrarConexion(cnAS400)
      End Try
   End Sub

   Public Shared Sub sb_AgregarPaginacion(ByRef pi_strConsulta, ByVal pi_intPagina, ByVal pi_intCantidadRegistros)
      Dim intDesde = (pi_intPagina * pi_intCantidadRegistros - pi_intCantidadRegistros) + 1
      Dim intHasta = pi_intPagina * pi_intCantidadRegistros

      pi_strConsulta = String.Format("SELECT * FROM ({0}) AS CONSULTA WHERE ROWNUM BETWEEN {1} AND {2}", pi_strConsulta, intDesde, intHasta)
   End Sub

    Public Shared Function fn_ObtenerNombreLibro()
        Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

        If ConfigurationManager.AppSettings("EnviaCorreo").ToString = "Test" Then
            strLibro = "LIBT99"
        ElseIf ConfigurationManager.AppSettings("EnviaCorreo").ToString = "TestQA" Then
            strLibro = "LIBT99"
        End If

        Return strLibro
    End Function

#Region "Mapeo de Entidades"

    'Entidad Maquina
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEMaquina As List(Of BE_Maquina))
        Try
            Dim liBEMaquina As New List(Of BE_Maquina)
            Dim BEMaquina As New BE_Maquina

            For Each drw As DataRow In pi_dtb.Rows
                BEMaquina = New BE_Maquina
                With BEMaquina

                End With

                liBEMaquina.Add(BEMaquina)
            Next drw

            po_liBEMaquina = liBEMaquina
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad EMPEQPD0
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEEMPEQPD0 As List(Of BE_EMPEQPD2))
        Try
            Dim liBEEMPEQPD0 As New List(Of BE_EMPEQPD2)
            Dim BEEMPEQPD0 As New BE_EMPEQPD2

            For Each drw As DataRow In pi_dtb.Rows
                BEEMPEQPD0 = New BE_EMPEQPD2

                With BEEMPEQPD0
                    If IsDBNull(drw.Item("IDNO1")) Then .str_IDNO1 = .str_IDNO1 Else .str_IDNO1 = drw.Item("IDNO1")
                    If IsDBNull(drw.Item("PRHDT8")) Then .str_PRHDT8 = .str_PRHDT8 Else .str_PRHDT8 = drw.Item("PRHDT8")
                    If IsDBNull(drw.Item("INVI")) Then .str_INVI = .str_INVI Else .str_INVI = drw.Item("INVI")
                    If IsDBNull(drw.Item("RDMSR1")) Then .str_RDMSR1 = .str_RDMSR1 Else .str_RDMSR1 = drw.Item("RDMSR1")
                    If IsDBNull(drw.Item("CUNO")) Then .str_CUNO = .str_CUNO Else .str_CUNO = drw.Item("CUNO")
                    If IsDBNull(drw.Item("LCUNO")) Then .str_LCUNO = .str_LCUNO Else .str_LCUNO = drw.Item("LCUNO")
                    If IsDBNull(drw.Item("PDRFDS")) Then .str_PDRFDS = .str_PDRFDS Else .str_PDRFDS = drw.Item("PDRFDS")
                    If IsDBNull(drw.Item("DSPMDL")) Then .str_DSPMDL = .str_DSPMDL Else .str_DSPMDL = drw.Item("DSPMDL")
                    If IsDBNull(drw.Item("LOC1")) Then .str_LOC1 = .str_LOC1 Else .str_LOC1 = drw.Item("LOC1")
                    If IsDBNull(drw.Item("CPIDNO")) Then .str_CPIDNO = .str_CPIDNO Else .str_CPIDNO = drw.Item("CPIDNO")
                    'TODO Validar
                    'Modificado por:Nivardo.
                    'Campos adicionados para poder ingresar bonos con facturacion manual
                    If IsDBNull(drw.Item("EQMFS2")) Then .str_EQMFS2 = .str_EQMFS2 Else .str_EQMFS2 = drw.Item("EQMFS2")
                    If IsDBNull(drw.Item("PRCLST")) Then .str_PRCLST = .str_PRCLST Else .str_PRCLST = drw.Item("PRCLST")
                    'If IsDBNull (drw .Item ("")) then . = . else . = drw .Item ("")
                    'If IsDBNull (drw .Item ("")) then . = . else . = drw .Item ("")
                    'If IsDBNull (drw .Item ("")) then . = . else . = drw .Item ("")
                    'If IsDBNull (drw .Item ("")) then . = . else . = drw .Item ("")
                    'If IsDBNull (drw .Item ("")) then . = . else . = drw .Item ("")
                End With

                liBEEMPEQPD0.Add(BEEMPEQPD0)
            Next drw

            po_liBEEMPEQPD0 = liBEEMPEQPD0
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBECuentaUsuario As List(Of BE_CuentaUsuario2))
        Try
            Dim liBECuentaUsuario As New List(Of BE_CuentaUsuario2)
            Dim BECuentaUsuario As New BE_CuentaUsuario2

            For Each drw As DataRow In pi_dtb.Rows
                BECuentaUsuario = New BE_CuentaUsuario2
                With BECuentaUsuario
                    If IsDBNull(drw.Item("IdUsuario")) Then .str_IdUsuario = .str_IdUsuario Else .str_IdUsuario = drw.Item("IdUsuario")
                    If IsDBNull(drw.Item("IdCuenta")) Then .str_IdCuenta = .str_IdCuenta Else .str_IdCuenta = drw.Item("IdCuenta")
                    If IsDBNull(drw.Item("CuentaDesc")) Then .str_CuentaDesc = .str_CuentaDesc Else .str_CuentaDesc = drw.Item("CuentaDesc")
                End With

                liBECuentaUsuario.Add(BECuentaUsuario)
            Next drw

            po_liBECuentaUsuario = liBECuentaUsuario
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEUFPRV010_UFPRV110 As List(Of BE_UFPRV010_UFPRV110))
        Try
            Dim liBEUFPRV010_UFPRV110 As New List(Of BE_UFPRV010_UFPRV110)
            Dim BEUFPRV010_UFPRV110 As New BE_UFPRV010_UFPRV110

            For Each drw As DataRow In pi_dtb.Rows
                BEUFPRV010_UFPRV110 = New BE_UFPRV010_UFPRV110

                With BEUFPRV010_UFPRV110
                    If IsDBNull(drw.Item("REFEREN")) Then .str_REFEREN = .str_REFEREN Else .str_REFEREN = drw.Item("REFEREN")
                    If IsDBNull(drw.Item("IMPDOL")) Then .dec_IMPDOL = .dec_IMPDOL Else .dec_IMPDOL = drw.Item("IMPDOL")
                    If drw.Table.Columns.Contains("SISTEMA") Then If IsDBNull(drw.Item("SISTEMA")) Then .strSISTEMA = .strSISTEMA Else .strSISTEMA = drw.Item("SISTEMA")
                    If drw.Table.Columns.Contains("CLIE") Then If IsDBNull(drw.Item("CLIE")) Then .strCLIE = .strCLIE Else .strCLIE = drw.Item("CLIE")
                    If drw.Table.Columns.Contains("CLIAD") Then If IsDBNull(drw.Item("CLIAD")) Then .strCLIAD = .strCLIAD Else .strCLIAD = drw.Item("CLIAD")
                    If drw.Table.Columns.Contains("FECDOC") Then If IsDBNull(drw.Item("FECDOC")) Then .intFECDOC = .intFECDOC Else .intFECDOC = drw.Item("FECDOC")
                    If drw.Table.Columns.Contains("SUNTIP") Then If IsDBNull(drw.Item("SUNTIP")) Then .strSUNTIP = .strSUNTIP Else .strSUNTIP = drw.Item("SUNTIP")
                    If drw.Table.Columns.Contains("SUNPRE") Then If IsDBNull(drw.Item("SUNPRE")) Then .strSUNPRE = .strSUNPRE Else .strSUNPRE = drw.Item("SUNPRE")
                    If drw.Table.Columns.Contains("SUNNUM") Then If IsDBNull(drw.Item("SUNNUM")) Then .strSUNNUM = .strSUNNUM Else .strSUNNUM = drw.Item("SUNNUM")
                    If drw.Table.Columns.Contains("NUMDOC") Then If IsDBNull(drw.Item("NUMDOC")) Then .strNUMDOC = .strNUMDOC Else .strNUMDOC = drw.Item("NUMDOC")
                    If drw.Table.Columns.Contains("NUMIAS") Then If IsDBNull(drw.Item("NUMIAS")) Then .strNUMIAS = .strNUMIAS Else .strNUMIAS = drw.Item("NUMIAS")
                    If drw.Table.Columns.Contains("CTTNO1") Then If IsDBNull(drw.Item("CTTNO1")) Then .strCTTNO1 = .strCTTNO1 Else .strCTTNO1 = drw.Item("CTTNO1")
                    If drw.Table.Columns.Contains("CNTRD8") Then If IsDBNull(drw.Item("CNTRD8")) Then .intCNTRD8 = .intCNTRD8 Else .intCNTRD8 = drw.Item("CNTRD8")
                    If drw.Table.Columns.Contains("CUENTA") Then If IsDBNull(drw.Item("CUENTA")) Then .strCUENTA = .strCUENTA Else .strCUENTA = drw.Item("CUENTA")
                    If drw.Table.Columns.Contains("ASIEN") Then If IsDBNull(drw.Item("ASIEN")) Then .strASIEN = .strASIEN Else .strASIEN = drw.Item("ASIEN")
                    If drw.Table.Columns.Contains("INVI") Then If IsDBNull(drw.Item("INVI")) Then .strINVI = .strINVI Else .strINVI = drw.Item("INVI")
                    If drw.Table.Columns.Contains("ORIGEN") Then If IsDBNull(drw.Item("ORIGEN")) Then .strORIGEN = .strORIGEN Else .strORIGEN = drw.Item("ORIGEN")
                End With

                liBEUFPRV010_UFPRV110.Add(BEUFPRV010_UFPRV110)
            Next drw

            po_liBEUFPRV010_UFPRV110 = liBEUFPRV010_UFPRV110
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEUFPRV010 As List(Of BE_UFPRV010))
        Try
            Dim liBEUFPRV010 As New List(Of BE_UFPRV010)
            Dim BEUFPRV010 As New BE_UFPRV010

            For Each drw As DataRow In pi_dtb.Rows
                BEUFPRV010 = New BE_UFPRV010

                With BEUFPRV010
                    If IsDBNull(drw.Item("REFEREN")) Then .str_REFEREN = .str_REFEREN Else .str_REFEREN = drw.Item("REFEREN")
                    If IsDBNull(drw.Item("INDSIT")) Then .str_INDSIT = .str_INDSIT Else .str_INDSIT = drw.Item("INDSIT")
                    If IsDBNull(drw.Item("CLIE")) Then .str_CLIE = .str_CLIE Else .str_CLIE = drw.Item("CLIE")
                    If IsDBNull(drw.Item("CLIAD")) Then .str_CLIAD = .str_CLIAD Else .str_CLIAD = drw.Item("CLIAD")
                    If IsDBNull(drw.Item("FECDOC")) Then .str_FECDOC = .str_FECDOC Else .str_FECDOC = drw.Item("FECDOC")
                    If IsDBNull(drw.Item("SUNTIP")) Then .str_SUNTIP = .str_SUNTIP Else .str_SUNTIP = drw.Item("SUNTIP")
                    If IsDBNull(drw.Item("SUNPRE")) Then .str_SUNPRE = .str_SUNPRE Else .str_SUNPRE = drw.Item("SUNPRE")
                    If IsDBNull(drw.Item("SUNNUM")) Then .str_SUNNUM = .str_SUNNUM Else .str_SUNNUM = drw.Item("SUNNUM")
                    If IsDBNull(drw.Item("NUMDOC")) Then .str_NUMDOC = .str_NUMDOC Else .str_NUMDOC = drw.Item("NUMDOC")
                    If IsDBNull(drw.Item("CTTNO1")) Then .str_CTTNO1 = .str_CTTNO1 Else .str_CTTNO1 = drw.Item("CTTNO1")
                    If IsDBNull(drw.Item("CNTRD8")) Then .str_CNTRD8 = .str_CNTRD8 Else .str_CNTRD8 = drw.Item("CNTRD8")
                    'If IsDBNull (drw .Item ("")) then . = . else . = drw .Item ("")
                    'If IsDBNull (drw .Item ("")) then . = . else . = drw .Item ("")
                    'If IsDBNull (drw .Item ("")) then . = . else . = drw .Item ("")
                End With

                liBEUFPRV010.Add(BEUFPRV010)
            Next drw

            po_liBEUFPRV010 = liBEUFPRV010
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    'Entidad DireccionPrincipalCliente
    Public Shared Sub fn_MapeoEntidad(ByVal pi_dtb As DataTable, ByRef po_liBEDireccionPrincipalCliente As List(Of BE_DireccionPrincipalCliente))
        Try
            Dim liBEDireccionPrincipalCliente As New List(Of BE_DireccionPrincipalCliente)
            Dim BEDireccionPrincipalCliente As New BE_DireccionPrincipalCliente

            For Each drw As DataRow In pi_dtb.Rows
                BEDireccionPrincipalCliente = New BE_DireccionPrincipalCliente

                With BEDireccionPrincipalCliente
                    If pi_dtb.Columns.Contains("CUNO") Then If IsDBNull(drw.Item("CUNO")) Then .str_CUNO = .str_CUNO Else .str_CUNO = drw.Item("CUNO")
                    If pi_dtb.Columns.Contains("DIRECCION") Then If IsDBNull(drw.Item("DIRECCION")) Then .str_DIRECCION = .str_DIRECCION Else .str_DIRECCION = drw.Item("DIRECCION")
                    If pi_dtb.Columns.Contains("COD_DEPARTAMENTO") Then If IsDBNull(drw.Item("COD_DEPARTAMENTO")) Then .str_COD_DEPARTAMENTO = .str_COD_DEPARTAMENTO Else .str_COD_DEPARTAMENTO = drw.Item("COD_DEPARTAMENTO")
                    If pi_dtb.Columns.Contains("NOM_DEPARTAMENTO") Then If IsDBNull(drw.Item("NOM_DEPARTAMENTO")) Then .str_NOM_DEPARTAMENTO = .str_NOM_DEPARTAMENTO Else .str_NOM_DEPARTAMENTO = drw.Item("NOM_DEPARTAMENTO")
                    If pi_dtb.Columns.Contains("COD_PROVINCIA") Then If IsDBNull(drw.Item("COD_PROVINCIA")) Then .str_COD_PROVINCIA = .str_COD_PROVINCIA Else .str_COD_PROVINCIA = drw.Item("COD_PROVINCIA")
                    If pi_dtb.Columns.Contains("NOM_PROVINCIA") Then If IsDBNull(drw.Item("NOM_PROVINCIA")) Then .str_NOM_PROVINCIA = .str_NOM_PROVINCIA Else .str_NOM_PROVINCIA = drw.Item("NOM_PROVINCIA")
                    If pi_dtb.Columns.Contains("COD_DISTRITO") Then If IsDBNull(drw.Item("COD_DISTRITO")) Then .str_COD_DISTRITO = .str_COD_DISTRITO Else .str_COD_DISTRITO = drw.Item("COD_DISTRITO")
                    If pi_dtb.Columns.Contains("NOM_DISTRITO") Then If IsDBNull(drw.Item("NOM_DISTRITO")) Then .str_NOM_DISTRITO = .str_NOM_DISTRITO Else .str_NOM_DISTRITO = drw.Item("NOM_DISTRITO")
                    'If IsDBNull (drw .Item ("")) then . = . else . = drw .Item ("")
                End With

                liBEDireccionPrincipalCliente.Add(BEDireccionPrincipalCliente)
            Next drw

            po_liBEDireccionPrincipalCliente = liBEDireccionPrincipalCliente
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

#End Region

End Class
