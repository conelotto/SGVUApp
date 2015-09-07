Imports SGCVU.BE
Imports SGCVU.DA

Imports System.String
Imports IBM.Data.DB2.iSeries
Imports System.Configuration

Public Class clsUMPBRHD0

    Public Shared Function fn_Select_UMPBRHD0_OrdenContrato_SQLSERVER(ByVal pi_BEUMPBRHD0 As BE_UMPBRHD0) As List(Of BE_UMPBRHD0)
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ORDEN"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_ORDEN.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_ORDEN
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NUMORI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_NUMORI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_NUMORI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim liBEUMPBRHD0 As New List(Of BE_UMPBRHD0)

            clsSQLServer.sb_EjecutarSelect("cnFSASGCVU", "P_BRR5_S_UMPBRHD0_ORDEN_CONTRATO", True, liBEUMPBRHD0, liEnt_Parametro)

            Return liBEUMPBRHD0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Insert_UMPBRHD0_SQLSERVER(ByVal pi_BEUMPBRHD0 As BE_UMPBRHD0) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdOrden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_IdOrden.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_IdOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoTmp"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_EstadoTmp.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_EstadoTmp
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CORP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_CORP.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_CORP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CIA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_CIA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_CIA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONONRO"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONONRO.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONONRO
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SECUENCIA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_SECUENCIA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_SECUENCIA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOVALOR"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_BONOVALOR.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_BONOVALOR
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOSALDO"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_BONOSALDO.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_BONOSALDO
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOMONEDA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOMONEDA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOMONEDA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOFECEMI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOFECEMI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOFECEMI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOFECVEN"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOFECVEN.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOFECVEN
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOPORREP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOPORREP.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOPORREP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOCTAREP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOCTAREP.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOCTAREP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOPORPRI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOPORPRI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOPORPRI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOCTAPRI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOCTAPRI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOCTAPRI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOPORSER"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOPORSER.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOPORSER
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOCTASER"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOCTASER.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOCTASER
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OFIC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_OFIC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_OFIC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ANODOC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_ANODOC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_ANODOC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TIPDOC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_TIPDOC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_TIPDOC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NUMORI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_NUMORI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_NUMORI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NUMPAG"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_NUMPAG.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_NUMPAG
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NUMDRE"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_NUMDRE.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_NUMDRE
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TIPCTA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_TIPCTA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_TIPCTA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CODCLI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_CODCLI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_CODCLI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OFICLI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_OFICLI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_OFICLI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNTIP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_SUNTIP.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_SUNTIP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNPRE"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_SUNPRE.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_SUNPRE
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNNUM"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_SUNNUM.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_SUNNUM
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RSOCIA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_RSOCIA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_RSOCIA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MONEDA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_MONEDA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_MONEDA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@PERCON"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_PERCON.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_PERCON
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FECEMI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_FECEMI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_FECEMI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CENCOS"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_CENCOS.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_CENCOS
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DIVISI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_DIVISI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_DIVISI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@LINVIG"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_LINVIG.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_LINVIG
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TIPCAM"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_TIPCAM.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_TIPCAM
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@VALAF16"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_VALAF16.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_VALAF16
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IMPOR16"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_IMPOR16.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_IMPOR16
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IMPOR21"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_IMPOR21.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_IMPOR21
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOCTT"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOCTT.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOCTT
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOFILE"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOFILE.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOFILE
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SISTEMA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_SISTEMA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_SISTEMA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ORDEN"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_ORDEN.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_ORDEN
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TEXTOM"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_TEXTOM.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_TEXTOM
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CLIAD"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_CLIAD.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_CLIAD
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FECINC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_FECINC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_FECINC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@HORINC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_HORINC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_HORINC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@USUINC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_USUINC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_USUINC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_I_UMPBRHD0", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Update_UMPBRHD0_SQLSERVER(ByVal pi_BEUMPBRHD0 As BE_UMPBRHD0) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IdOrden"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_IdOrden.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_IdOrden
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@EstadoTmp"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_EstadoTmp.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_EstadoTmp
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CORP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_CORP.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_CORP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CIA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_CIA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_CIA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONONRO"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONONRO.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONONRO
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SECUENCIA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_SECUENCIA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_SECUENCIA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOVALOR"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_BONOVALOR.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_BONOVALOR
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOSALDO"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_BONOSALDO.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_BONOSALDO
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOMONEDA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOMONEDA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOMONEDA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOFECEMI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOFECEMI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOFECEMI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOFECVEN"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOFECVEN.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOFECVEN
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOPORREP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOPORREP.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOPORREP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOCTAREP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOCTAREP.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOCTAREP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOPORPRI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOPORPRI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOPORPRI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOCTAPRI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOCTAPRI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOCTAPRI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOPORSER"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOPORSER.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOPORSER
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOCTASER"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOCTASER.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOCTASER
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OFIC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_OFIC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_OFIC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ANODOC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_ANODOC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_ANODOC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TIPDOC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_TIPDOC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_TIPDOC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NUMORI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_NUMORI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_NUMORI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NUMPAG"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_NUMPAG.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_NUMPAG
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NUMDRE"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_NUMDRE.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_NUMDRE
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TIPCTA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_TIPCTA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_TIPCTA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CODCLI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_CODCLI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_CODCLI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@OFICLI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_OFICLI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_OFICLI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNTIP"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_SUNTIP.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_SUNTIP
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNPRE"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_SUNPRE.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_SUNPRE
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SUNNUM"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_SUNNUM.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_SUNNUM
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@RSOCIA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_RSOCIA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_RSOCIA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@MONEDA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_MONEDA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_MONEDA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@PERCON"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_PERCON.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_PERCON
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FECEMI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_FECEMI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_FECEMI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CENCOS"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_CENCOS.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_CENCOS
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@DIVISI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_DIVISI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_DIVISI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@LINVIG"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_LINVIG.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_LINVIG
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TIPCAM"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_TIPCAM.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_TIPCAM
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@VALAF16"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_VALAF16.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_VALAF16
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IMPOR16"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_IMPOR16.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_IMPOR16
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@IMPOR21"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.dec_IMPOR21.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.dec_IMPOR21
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOCTT"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOCTT.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOCTT
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOFILE"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOFILE.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOFILE
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@SISTEMA"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_SISTEMA.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_SISTEMA
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ORDEN"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_ORDEN.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_ORDEN
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@TEXTOM"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_TEXTOM.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_TEXTOM
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@CLIAD"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_CLIAD.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_CLIAD
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@FECINC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_FECINC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_FECINC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@HORINC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_HORINC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_HORINC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@USUINC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_USUINC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_USUINC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnFSASGCVU", "P_BRR5_U_UMPBRHD0", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Function fn_Select_UMPBRHD0_OrdenContrato_DB2(ByVal pi_BEUMPBRHD0 As BE_UMPBRHD0) As List(Of BE_UMPBRHD0)
        Try
            Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

            If ConfigurationManager.AppSettings("EnviaCorreo").ToString = "Test" Then
                strLibro = "LIBT99"
            ElseIf ConfigurationManager.AppSettings("EnviaCorreo").ToString = "TestQA" Then
                strLibro = "LIBT99"
            End If

            Dim objArrParametros(,) As Object = {{}}


            Dim liBEUMPBRHD0 As New List(Of BE_UMPBRHD0)

            Dim strConsulta As String = Concat("SELECT TRIM(ORDEN) AS ORDEN, BONOFILE ", _
                                               "FROM ", strLibro, ".UMPBRHD0 ", _
                                               "WHERE TRIM(ORDEN) = '", pi_BEUMPBRHD0.str_ORDEN, "' ", _
                                               "AND TRIM(NUMORI) = '", pi_BEUMPBRHD0.str_NUMORI, "'")

            clsAS400.fn_EjecutarSelect(strConsulta, liBEUMPBRHD0, objArrParametros)

            Return liBEUMPBRHD0
        Catch ex As Exception
            Throw ex
        End Try
    End Function

    Public Shared Sub fn_Insert_UMPBRHD0_DB2(ByVal pi_BEUMPBRHD0 As BE_UMPBRHD0)
        Try
            Dim strLibro As String = ConfigurationManager.AppSettings("cnLIBR08").ToString

            If ConfigurationManager.AppSettings("EnviaCorreo").ToString = "Test" Then
                strLibro = "LIBT99"
            ElseIf ConfigurationManager.AppSettings("EnviaCorreo").ToString = "TestQA" Then
                strLibro = "LIBT99"
            End If

            Dim strUsuario As String = String.Empty
            If pi_BEUMPBRHD0.str_USUINC.Length > 10 Then
                strUsuario = pi_BEUMPBRHD0.str_USUINC.Substring(0, 10)
            Else
                strUsuario = pi_BEUMPBRHD0.str_USUINC
            End If

            Dim strConsulta As String = Concat("INSERT INTO ", strLibro, ".UMPBRHD0 ", _
                                               "( CORP, CIA, BONONRO", _
                                               ", SECUENCIA, BONOVALOR, BONOSALDO", _
                                               ", BONOMONEDA, BONOFECEMI, BONOFECVEN", _
                                               ", BONOPORREP, BONOCTAREP, BONOPORPRI", _
                                               ", BONOCTAPRI, BONOPORSER, BONOCTASER", _
                                               ", OFIC, ANODOC, TIPDOC", _
                                               ", NUMORI, NUMPAG, NUMDRE", _
                                               ", TIPCTA, CODCLI, OFICLI", _
                                               ", SUNTIP, SUNPRE, SUNNUM", _
                                               ", RSOCIA, MONEDA, PERCON", _
                                               ", FECEMI, CENCOS, DIVISI", _
                                               ", LINVIG, TIPCAM, VALAF16", _
                                               ", IMPOR16, IMPOR21, BONOCTT", _
                                               ", BONOFILE, SISTEMA, ORDEN", _
                                               ", TEXTOM, CLIAD, FECINC", _
                                               ", HORINC, USUINC) ", _
                                               "VALUES", _
                                               "(", pi_BEUMPBRHD0.int_CORP, ", ", pi_BEUMPBRHD0.int_CIA, ", (select max(BONONRO)+1 from ", strLibro, ".UMPBRHD0)", _
                                               ", ", pi_BEUMPBRHD0.int_SECUENCIA, ", ", pi_BEUMPBRHD0.dec_BONOVALOR, ", ", pi_BEUMPBRHD0.dec_BONOSALDO, "", _
                                               ", '", pi_BEUMPBRHD0.str_BONOMONEDA, "', ", pi_BEUMPBRHD0.int_BONOFECEMI, ", ", pi_BEUMPBRHD0.int_BONOFECVEN, "", _
                                               ", ", pi_BEUMPBRHD0.int_BONOPORREP, ", ", pi_BEUMPBRHD0.str_BONOCTAREP, ", ", pi_BEUMPBRHD0.int_BONOPORPRI, "", _
                                               ", ", pi_BEUMPBRHD0.str_BONOCTAPRI, ", ", pi_BEUMPBRHD0.int_BONOPORSER, ", '", pi_BEUMPBRHD0.str_BONOCTASER, "'", _
                                               ", ", pi_BEUMPBRHD0.int_OFIC, ", ", pi_BEUMPBRHD0.int_ANODOC, ", '", pi_BEUMPBRHD0.str_TIPDOC, "'", _
                                               ", '", pi_BEUMPBRHD0.str_NUMORI, "', ", pi_BEUMPBRHD0.int_NUMPAG, ", '", pi_BEUMPBRHD0.str_NUMDRE, "'", _
                                               ", '", pi_BEUMPBRHD0.str_TIPCTA, "', '", pi_BEUMPBRHD0.str_CODCLI, "', '", pi_BEUMPBRHD0.int_OFICLI, "'", _
                                               ", '", pi_BEUMPBRHD0.str_SUNTIP, "', ", pi_BEUMPBRHD0.int_SUNPRE, ", ", pi_BEUMPBRHD0.int_SUNNUM, "", _
                                               ", '", pi_BEUMPBRHD0.str_RSOCIA, "', '", pi_BEUMPBRHD0.str_MONEDA, "', ", pi_BEUMPBRHD0.int_PERCON, "", _
                                               ", ", pi_BEUMPBRHD0.int_FECEMI, ", '", pi_BEUMPBRHD0.str_CENCOS, "', ", pi_BEUMPBRHD0.int_DIVISI, "", _
                                               ", ", pi_BEUMPBRHD0.str_LINVIG, ", ", pi_BEUMPBRHD0.dec_TIPCAM, ", ", pi_BEUMPBRHD0.dec_VALAF16, "", _
                                               ", ", pi_BEUMPBRHD0.dec_IMPOR16, ", ", pi_BEUMPBRHD0.dec_IMPOR21, ", '", pi_BEUMPBRHD0.str_BONOCTT, "'", _
                                               ", ", pi_BEUMPBRHD0.int_BONOFILE, ", '", pi_BEUMPBRHD0.str_SISTEMA, "', '", pi_BEUMPBRHD0.str_ORDEN, "'", _
                                               ", '", pi_BEUMPBRHD0.str_TEXTOM, "', '", pi_BEUMPBRHD0.str_CLIAD, "', ", pi_BEUMPBRHD0.int_FECINC, "", _
                                               ", ", pi_BEUMPBRHD0.int_HORINC, ", '", strUsuario, "')")

            clsAS400.sb_Update(strConsulta)
        Catch ex As Exception
            Throw ex
        End Try
    End Sub

    Public Shared Function fn_Update_EstadoTmp(ByVal pi_BEUMPBRHD0 As BE_UMPBRHD0) As String
        Try
            Dim liEnt_Parametro As New List(Of clsEntidad_ParametroSQL)
            Dim EntParametroSQL As New clsEntidad_ParametroSQL

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ORDEN"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_ORDEN.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_ORDEN
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@NUMORI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_NUMORI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_NUMORI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOFECEMI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOFECEMI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOFECEMI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOFECVEN"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_BONOFECVEN.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_BONOFECVEN
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@BONOCTAPRI"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.str_BONOCTAPRI.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.str_BONOCTAPRI
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            EntParametroSQL = New clsEntidad_ParametroSQL
            With EntParametroSQL
                .strParameterName = "@ANODOC"
                .typDbType = clsEntidad_ParametroSQL.fn_GetDBType(pi_BEUMPBRHD0.int_ANODOC.GetType)
                .strSourceColumn = pi_BEUMPBRHD0.int_ANODOC
            End With
            liEnt_Parametro.Add(EntParametroSQL)

            Dim strReturn As String = String.Empty
            Dim strParametroSalida As String = String.Empty

            Try
                strParametroSalida = clsSQLServer.fn_EjecutarUpdate_Insert_Delete("cnBonos", "P_BRR5_U_UMPBRHD0_EstadoTmp", True, strReturn, liEnt_Parametro)

                If Not strParametroSalida = String.Empty Then strReturn = strParametroSalida
            Catch ex As Exception
                strReturn = String.Empty
            End Try

            Return strReturn
        Catch ex As Exception
            Throw ex
        End Try
    End Function
End Class
