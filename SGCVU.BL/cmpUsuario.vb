Imports SGCVU.DTO
Imports System.String
Imports SGCVU.DA
Imports SGCVU.BE
Public Class cmpUsuario

   Public Shared Function fn_Buscar_Usuario(ByVal pi_strCodigoUsuario As String, ByVal pi_strNombreUsuario As String, ByVal pi_intPagina As Integer, ByVal pi_cantidadRegistros As Integer) As List(Of DTO_Vendedor)
      Try
         Dim strConsulta As String = ""

         Dim strSELECT As String = Concat(" UPPER(LTRIM(RTRIM(a.NombreCompleto))) AS NombreCompleto ", _
                                          ",LOWER(LTRIM(RTRIM(a.EmailTrabajo))) AS EmailTrabajo ", _
                                          ",LTRIM(RTRIM(a.Codigo)) AS Codigo ")

         Dim strFROM_WHERE As String = Concat(" FROM v_Servicio_WEBTrabajador a ", _
                                        "WHERE	a.SituacionTrabaj = 1 ", _
                                        "AND		a.SociedadId = '05' ")

         If pi_strCodigoUsuario <> "" And Not pi_strCodigoUsuario Is Nothing Then strFROM_WHERE += Concat(" AND LTRIM(RTRIM(a.Codigo)) = RIGHT('00000000' + LTRIM(RTRIM('", pi_strCodigoUsuario, "')),8) ")
         If pi_strNombreUsuario <> "" And Not pi_strNombreUsuario Is Nothing Then strFROM_WHERE += Concat(" AND	a.NombreCompleto LIKE '%", pi_strNombreUsuario, "%' ")

         If pi_intPagina = 0 Or pi_cantidadRegistros = 0 Then
            strConsulta = Concat("SELECT ", strSELECT, strFROM_WHERE, " ORDER BY a.NombreCompleto")
         Else
            Dim intDesde = (pi_intPagina - 1) * pi_cantidadRegistros + 1
            Dim intHasta = pi_intPagina * pi_cantidadRegistros

            strConsulta = Concat("SELECT * FROM (SELECT ", strSELECT, ", ROW_NUMBER() over(order by a.NombreCompleto) AS RowNum ", strFROM_WHERE, ") AS Consulta WHERE RowNum BETWEEN ", intDesde, " AND ", intHasta)
         End If

         Return clsSQLServer.fn_EjecutarSelect(Of DTO_Vendedor)("cnAdryan", strConsulta, False, Nothing)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Public Shared Function fn_Buscar_Usuario_Total(ByVal pi_strCodigoUsuario As String, ByVal pi_strNombreUsuario As String) As Object
      Try
         Dim strConsulta As String = Concat("SELECT	COUNT(*) ", _
                                             "FROM		v_Servicio_WEBTrabajador a ", _
                                             "WHERE	a.SituacionTrabaj = 1 ", _
                                             "AND		a.SociedadId = '05' ")

         If pi_strCodigoUsuario <> "" And Not pi_strCodigoUsuario Is Nothing Then strConsulta += Concat(" AND LTRIM(RTRIM(a.Codigo)) = RIGHT('00000000' + LTRIM(RTRIM('", pi_strCodigoUsuario, "')),8) ")
         If pi_strNombreUsuario <> "" And Not pi_strNombreUsuario Is Nothing Then strConsulta += Concat(" AND	a.NombreCompleto LIKE '%", pi_strNombreUsuario, "%' ")

         Return clsSQLServer.fn_EjecutarSelect_Escalar("cnAdryan", strConsulta, False, Nothing)
      Catch ex As Exception
         Throw ex
      End Try
   End Function

    Public Shared Function fn_Select_ListaTrabajadorAdryan3(ByVal pi_BETrabajadorAdryan As BE_TrabajadorAdryan) As List(Of BE_TrabajadorAdryan)
        Try
            Dim strConsulta As String = Concat("SELECT	LTRIM(RTRIM(A.COMPANIA)) AS COMPANIA ", _
                                               "			,LTRIM(RTRIM(A.CODIGO)) AS CODIGO ", _
                                               "			,LTRIM(RTRIM(A.SUCURSAL)) AS SUCURSAL ", _
                                               "			,LTRIM(RTRIM(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(REPLACE(COALESCE(A.DESC_SUCURSAL,''),'S.AV.',''),'SUC.',''),'OFICINA',''),'OFIC.',''),'OPERACION',''),'PY.MIN',''),'O.',''),'OP.MI.',''),'P.M.',''),'OPERACIONES',''),'P.VARIOS',''),'PROYECTO',''),'PY.',''),'PY.C.I-',''),'PY.CONS.',''),'PY.MI.',''),'PY.VAR.',''),'PY.VARIOS',''),'S.',''),'S.PRINC.',''),'S.PTO',''),'SEDE',''),'SUCUR.',''),'SUCURSAL',''))) AS DESC_SUCURSAL ", _
                                               "			,LTRIM(RTRIM(A.NOMBRE)) AS NOMBRE ", _
                                               "			,LTRIM(RTRIM(A.MATRICULA)) AS MATRICULA ", _
                                               "			,LTRIM(RTRIM(A.EMAIL_TRABAJO)) AS CORREO ", _
                                               "FROM		v_trabajadores_todos A ", _
                                               "WHERE		A.COMPANIA = '", pi_BETrabajadorAdryan.str_COMPANIA, "' ", _
                                               "AND		COALESCE(A.CODIGO,'') <> '' ", _
                                               "AND		(A.MATRICULA like '%", pi_BETrabajadorAdryan.str_MATRICULA, "%' ", _
                                               "AND      LTRIM(RTRIM(A.NOMBRE)) like '%", pi_BETrabajadorAdryan.str_NOMBRE, "%')")

            Dim liBETrabajadorAdryan As New List(Of BE_TrabajadorAdryan)

            clsSQLServer.sb_EjecutarSelect("cnAdryan", strConsulta, False, liBETrabajadorAdryan, Nothing)

            Return liBETrabajadorAdryan
        Catch ex As Exception
            'Dim rethrow As Boolean = ExceptionPolicy.HandleException(ex, "ExHandling")
            Throw ex
        End Try
    End Function

End Class