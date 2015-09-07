Imports SGCVU.BE
Imports SGCVU.DA
Imports System.Configuration

Public Class cmpAsignarBonoRepuesto

    Public Shared Function fn_AsignarBonoRepuesto(ByVal pBEMaquina As BE_Maquina, ByVal pUsuario As String)
        Try
            Dim BEUFPFAHD0 As New BE_UFPFAHD0
            Dim BEUFPRV010_UFPRV110 As New BE_UFPRV010_UFPRV110
            Dim BEUMPBRHD0 As New BE_UMPBRHD0

            Dim liBEUFPFAHD0 As New List(Of BE_UFPFAHD0)
            Dim liBEUFPRV010_UFPRV110 As New List(Of BE_UFPRV010_UFPRV110)
            Dim liBEUMPBRHD0 As New List(Of BE_UMPBRHD0)

            With BEUFPFAHD0
                .strORDEN = pBEMaquina.str_OrdenAsignada 'pi_BEOrden.str_Orden
                .strCODCLI = pBEMaquina.str_ClienteId 'pi_BEOrden.str_CodCliente
                .strSUNTIP = pBEMaquina.str_SUNTIP 'pi_BEOrden.strSUNTIP
                .intSUNPRE = pBEMaquina.int_SUNPRE 'pi_BEOrden.intSUNPRE
                .intSUNNUM = pBEMaquina.int_SUNNUM 'pi_BEOrden.intSUNNUM
            End With

            If pBEMaquina.int_NoTieneNroorden = 1 Then
                liBEUFPFAHD0 = clsUFPFAHD0.fn_Select_UFPFAHD0_NumFactura(BEUFPFAHD0) 'Se obtiene por el número de factura y no por el número de orden.
            Else
                liBEUFPFAHD0 = clsUFPFAHD0.fn_Select_UFPFAHD0(BEUFPFAHD0) 'Se obtiene la Factura que se encuentra en el registro de "Facturas de impresión (UFPFAHD0). Si está vendida."
                If Not IsNothing(liBEUFPFAHD0) Then
                    If liBEUFPFAHD0.Count = 0 Then
                        liBEUFPFAHD0 = clsUFPFAHD0.fn_Select_UFPFAHD0_2(BEUFPFAHD0) 'Si aún no está vendida.
                    End If
                End If
            End If

            If liBEUFPFAHD0.Count > 0 Then
                BEUFPFAHD0 = liBEUFPFAHD0(0)
                With BEUFPRV010_UFPRV110
                    .strCLPR = BEUFPFAHD0.strTIPDOC
                    .strSUNTIP = BEUFPFAHD0.strSUNTIP
                    .strSUNPRE = BEUFPFAHD0.intSUNPRE
                    .strSUNNUM = BEUFPFAHD0.intSUNNUM
                    .strNUMIAS = BEUFPFAHD0.strNUMDRE
                End With

                If pBEMaquina.int_NoTieneNroorden = 1 Then
                    liBEUFPRV010_UFPRV110 = clsUFPRV010_UFPRV110.fn_Select_UFPRV010_UFPRV110_Factura_NoOrden(BEUFPRV010_UFPRV110)
                Else
                    liBEUFPRV010_UFPRV110 = clsUFPRV010_UFPRV110.fn_Select_UFPRV010_UFPRV110_Factura(BEUFPRV010_UFPRV110) 'Se obtiene los datos de "Registro de ventas" (UFPRV010) y de "Registro de modificaciones" (UFPRV110)
                End If

                Dim tieneCuenta70 As Boolean = False
                Dim datosBonoRepuesto = (From v In liBEUFPRV010_UFPRV110 Where v.strCUENTA.StartsWith("7")).Take(1)
                If datosBonoRepuesto.Count = 0 Then
                    datosBonoRepuesto = (From v In liBEUFPRV010_UFPRV110 Where v.strCUENTA.StartsWith("49") Or v.strCUENTA.StartsWith("1222")).Take(1)
                Else
                    tieneCuenta70 = True
                End If
                If datosBonoRepuesto.Count > 0 Then
                    BEUFPRV010_UFPRV110 = datosBonoRepuesto.ElementAt(0)

                    'LLenar los datos para el registro
                    BEUMPBRHD0 = fn_LlenarDatos_BEUMPBRHD0(pBEMaquina, pUsuario, BEUFPFAHD0, BEUFPRV010_UFPRV110)

                    'Verificar registro
                    liBEUMPBRHD0 = clsUMPBRHD0.fn_Select_UMPBRHD0_OrdenContrato_SQLSERVER(BEUMPBRHD0)
                    Dim strRetorno As String = String.Empty

                    If Not IsNothing(liBEUFPFAHD0) Then
                        If liBEUMPBRHD0.Count = 0 Then
                            strRetorno = clsUMPBRHD0.fn_Insert_UMPBRHD0_SQLSERVER(BEUMPBRHD0) 'Registra
                        Else
                            strRetorno = clsUMPBRHD0.fn_Update_UMPBRHD0_SQLSERVER(BEUMPBRHD0) 'Actualiza
                        End If
                    End If

                    If strRetorno = "1" And tieneCuenta70 Then
                        Try
                            'Insertar en Db2
                            liBEUMPBRHD0 = clsUMPBRHD0.fn_Select_UMPBRHD0_OrdenContrato_DB2(BEUMPBRHD0) 'Validación
                            If Not IsNothing(liBEUMPBRHD0) Then
                                If liBEUMPBRHD0.Count = 0 Then
                                    clsUMPBRHD0.fn_Insert_UMPBRHD0_DB2(BEUMPBRHD0) 'Registro DB2
                                Else
                                    'clsUMPBRHD0.fn_Update_UMPBRHD0_DB2(BEUMPBRHD0) 'Actualiza DB2
                                End If
                            End If
                            'Actualiza el campo estadoTmp del SQL Server
                            clsUMPBRHD0.fn_Update_EstadoTmp(BEUMPBRHD0)

                        Catch ex As Exception
                        End Try
                    End If

                End If

            End If

            Return True
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Private Shared Function fn_LlenarDatos_BEUMPBRHD0(ByVal pBEMaquina As BE_Maquina, ByVal pi_strIdUsuario As String, ByVal pi_BEUFPFAHD0 As BE_UFPFAHD0, ByVal pi_BEUFPRV010_UFPRV110 As BE_UFPRV010_UFPRV110) As BE_UMPBRHD0
        Dim BEUMPBRHD0 As New BE_UMPBRHD0
        Dim fechaActual As Date = Date.Now

        With BEUMPBRHD0
            .int_IdOrden = 1 'pBEMaquina.
            .str_EstadoTmp = "0"
            .int_CORP = pi_BEUFPFAHD0.intCORP
            .int_CIA = pBEMaquina.str_CompaniaId
            .int_BONONRO = 0 'En Db2 se ingresa el max(BONONRO)+1
            .int_SECUENCIA = 0 'Fijo
            .dec_BONOVALOR = pBEMaquina.dec_BonoRptoMonto
            .dec_BONOSALDO = pBEMaquina.dec_BonoRptoMonto
            .str_BONOMONEDA = pi_BEUFPFAHD0.strMONEDA
            If pi_BEUFPRV010_UFPRV110.intCNTRD8 <> "0" Then .int_BONOFECEMI = pi_BEUFPRV010_UFPRV110.intCNTRD8 Else .int_BONOFECEMI = pi_BEUFPRV010_UFPRV110.intFECDOC
            .int_BONOFECVEN = clsUtil.fn_strFecha_Date_A_String_YYYYMMDD(clsUtil.fn_detFecha_String_A_Date(.int_BONOFECEMI).AddMonths(6))
            .int_BONOPORREP = ConfigurationManager.AppSettings("PorcentajeBonoRpto").ToString
            .str_BONOCTAREP = ConfigurationManager.AppSettings("CuentaBonoRpto").ToString
            .int_BONOPORPRI = ConfigurationManager.AppSettings("PorcentajePrime").ToString
            .str_BONOCTAPRI = pi_BEUFPRV010_UFPRV110.strCUENTA.Substring(0, 5)
            .int_BONOPORSER = 0 'Fijo
            .str_BONOCTASER = String.Empty 'Fijo
            'datos de la factura Prime
            .int_OFIC = pi_BEUFPFAHD0.intOFIC
            .int_ANODOC = pi_BEUFPRV010_UFPRV110.intFECDOC.ToString().Substring(0, 4)
            .str_TIPDOC = pi_BEUFPFAHD0.strTIPDOC
            .str_NUMORI = pi_BEUFPFAHD0.strNUMORI
            .int_NUMPAG = pi_BEUFPFAHD0.intNUMPAG
            .str_NUMDRE = pi_BEUFPFAHD0.strNUMDRE
            .str_TIPCTA = pi_BEUFPFAHD0.strTIPCTA
            .str_CODCLI = pi_BEUFPFAHD0.strCODCLI
            .int_OFICLI = pi_BEUFPFAHD0.intOFICLI
            .str_SUNTIP = pi_BEUFPFAHD0.strSUNTIP
            .int_SUNPRE = pi_BEUFPFAHD0.intSUNPRE
            .int_SUNNUM = pi_BEUFPFAHD0.intSUNNUM
            .str_RSOCIA = pi_BEUFPFAHD0.strRSOCIA
            .str_MONEDA = pi_BEUFPFAHD0.strMONEDA
            .int_PERCON = pi_BEUFPFAHD0.intPERCON
            .int_FECEMI = pi_BEUFPFAHD0.intFECINC
            .str_CENCOS = pi_BEUFPFAHD0.strCENCOS
            .int_DIVISI = pi_BEUFPFAHD0.intDIVISI
            .str_LINVIG = pi_BEUFPFAHD0.strLINVIG
            .dec_TIPCAM = pi_BEUFPFAHD0.decTIPCAM
            .dec_VALAF16 = pi_BEUFPFAHD0.decVALAF16
            .dec_IMPOR16 = pi_BEUFPFAHD0.decIMPOR16
            .dec_IMPOR21 = pi_BEUFPFAHD0.decIMPOR21
            .str_BONOCTT = ConfigurationManager.AppSettings("BonoCTT").ToString()
            .int_BONOFILE = ConfigurationManager.AppSettings("BonoFile").ToString()
            .str_SISTEMA = pi_BEUFPFAHD0.strSISTEMA
            .str_ORDEN = pi_BEUFPFAHD0.strORDEN
            .str_TEXTOM = pi_BEUFPFAHD0.strTEXTOM
            .str_CLIAD = pi_BEUFPFAHD0.strCLIAD
            .int_FECINC = clsUtil.fn_strFecha_Date_A_String_YYYYMMDD(fechaActual)
            .int_HORINC = clsUtil.fn_strHora_Date_A_String_hhmmss(fechaActual)
            .str_USUINC = pi_strIdUsuario
        End With

        Return BEUMPBRHD0
    End Function
End Class
