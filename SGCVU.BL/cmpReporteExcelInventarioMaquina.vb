Imports NPOI.SS.UserModel
Imports NPOI.HSSF.UserModel
Imports SGCVU.DTO
Imports System.IO
Imports System.Reflection
Imports NPOI.HSSF.Util

Public Class cmpReporteExcelInventarioMaquina

   Private book As IWorkbook

   Private styleCabecera As ICellStyle
   Private styleSolicitoLevanteSI As ICellStyle
   Private styleSolicitoLevanteNO As ICellStyle
   Private styleSemaforoVerde As ICellStyle
   Private styleSemaforoAmarillo As ICellStyle
   Private styleSemaforoRojo As ICellStyle
   Private styleUbicVerde As ICellStyle
   Private styleUbicRojo As ICellStyle

   Private liDTOMaquinas As List(Of DTO_Consulta_Inventario_Maquina)
   Private liDTOColumnas As List(Of DTO_Configuracion_Columnas_Usuario)

   Private rowNum As Integer = 1
   Private columNum As Integer = 0

   Public Sub New(ByVal pi_liDTOMaquinas As List(Of DTO_Consulta_Inventario_Maquina), ByVal pi_liDTOColumnas As List(Of DTO_Configuracion_Columnas_Usuario))
      liDTOMaquinas = pi_liDTOMaquinas
      liDTOColumnas = pi_liDTOColumnas

      'Crear documento excel
      book = New HSSFWorkbook()

      'Definir lo Estilos
      Dim fontBold As IFont = book.CreateFont()
      fontBold.Boldweight = FontBoldWeight.Bold

      Dim fontSolLevanteSI As IFont = book.CreateFont()
      fontSolLevanteSI.Color = HSSFColor.Green.Index

      Dim fontSolLevanteNO As IFont = book.CreateFont()
      fontSolLevanteNO.Color = HSSFColor.Red.Index

      Dim fontSemaforoVerde As IFont = book.CreateFont()
      fontSemaforoVerde.FontHeightInPoints = 12
      fontSemaforoVerde.Color = HSSFColor.Green.Index

      Dim fontSemaforoAmarillo As IFont = book.CreateFont()
      fontSemaforoAmarillo.FontHeightInPoints = 12
      fontSemaforoAmarillo.Color = HSSFColor.Yellow.Index

      Dim fontSemaforoRojo As IFont = book.CreateFont()
      fontSemaforoRojo.FontHeightInPoints = 12
      fontSemaforoRojo.Color = HSSFColor.Red.Index

      Dim fontUbicacion As IFont = book.CreateFont()
      fontUbicacion.Color = HSSFColor.White.Index

      styleCabecera = book.CreateCellStyle()
      styleCabecera.Alignment = HorizontalAlignment.Center
      styleCabecera.SetFont(fontBold)

      styleSolicitoLevanteSI = book.CreateCellStyle()
      styleSolicitoLevanteSI.SetFont(fontSolLevanteSI)
      styleSolicitoLevanteSI.Alignment = HorizontalAlignment.Center

      styleSolicitoLevanteNO = book.CreateCellStyle()
      styleSolicitoLevanteNO.SetFont(fontSolLevanteNO)
      styleSolicitoLevanteNO.Alignment = HorizontalAlignment.Center

      styleSemaforoVerde = book.CreateCellStyle()
      styleSemaforoVerde.SetFont(fontSemaforoVerde)
      styleSemaforoVerde.Alignment = HorizontalAlignment.Center

      styleSemaforoAmarillo = book.CreateCellStyle()
      styleSemaforoAmarillo.SetFont(fontSemaforoAmarillo)
      styleSemaforoAmarillo.Alignment = HorizontalAlignment.Center

      styleSemaforoRojo = book.CreateCellStyle()
      styleSemaforoRojo.SetFont(fontSemaforoRojo)
      styleSemaforoRojo.Alignment = HorizontalAlignment.Center

      styleUbicVerde = book.CreateCellStyle()
      styleUbicVerde.SetFont(fontUbicacion)
      styleUbicVerde.FillForegroundColor = HSSFColor.Green.Index
      styleUbicVerde.FillPattern = FillPattern.SolidForeground

      styleUbicRojo = book.CreateCellStyle()
      styleUbicRojo.SetFont(fontUbicacion)
      styleUbicRojo.FillForegroundColor = HSSFColor.Red.Index
      styleUbicRojo.FillPattern = FillPattern.SolidForeground
   End Sub

   Public Function fn_ObtenerDocumento()
      Try
         'Crear la hoja de excel
         Dim hoja As ISheet = book.CreateSheet("Inventario de Máquinas")

         'Cabecera
         Dim rowCabecera As IRow = hoja.CreateRow(rowNum)
         For Each item In liDTOColumnas
            rowCabecera.CreateCell(columNum).SetCellValue(item.DescripcionColumna)
            rowCabecera.GetCell(columNum).CellStyle = styleCabecera
            columNum += 1
         Next (item)

         rowNum += 1
         columNum = 0

         'Detalle
         For Each item In liDTOMaquinas
            Dim rowDetalle = hoja.CreateRow(rowNum)
            For Each columna In liDTOColumnas
               AgregarCelda(item, columna, rowDetalle, columNum)
               columNum += 1
            Next columna
            rowNum += 1
            columNum = 0
         Next item

         'Ajustar ancho de las columnas
         For i = 0 To liDTOColumnas.Count - 1
            hoja.AutoSizeColumn(i)
         Next

         Dim ms = New MemoryStream()
         book.Write(ms)

         Return ms.GetBuffer()
      Catch ex As Exception
         Throw ex
      End Try
   End Function

   Private Sub AgregarCelda(ByVal item As DTO_Consulta_Inventario_Maquina, ByVal columna As DTO_Configuracion_Columnas_Usuario, ByRef rowDetalle As IRow, ByVal columNum As Integer)
      If Not AsignarValorColumnaEspecial(item, columna, rowDetalle, columNum) Then
         Dim prop As PropertyInfo = item.[GetType]().GetProperty(columna.NombreColumna, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.IgnoreCase)
         If prop IsNot Nothing Then
            Dim value = prop.GetValue(item, Nothing)
            If value IsNot Nothing Then
               Dim tipoParametroFinal As Type = If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType)
               Dim nombreTipo = tipoParametroFinal.Name
               Select Case nombreTipo
                  Case "String"
                     rowDetalle.CreateCell(columNum).SetCellValue(value.ToString)
                  Case "DateTime"
                     rowDetalle.CreateCell(columNum).SetCellValue(Convert.ToDateTime(value).ToString("dd/MM/yyyy"))
                  Case "Int32"
                     rowDetalle.CreateCell(columNum).SetCellValue(Convert.ToInt32(value))
                  Case "Decimal"
                     rowDetalle.CreateCell(columNum).SetCellValue(Convert.ToDecimal(value))
               End Select
            Else
               rowDetalle.CreateCell(columNum).SetCellValue("")
            End If
         End If
      End If
   End Sub

   Private Function AsignarValorColumnaEspecial(ByVal item As DTO_Consulta_Inventario_Maquina, ByVal columna As DTO_Configuracion_Columnas_Usuario, ByRef rowDetalle As IRow, ByVal columNum As Integer)
      Dim prop As PropertyInfo = item.[GetType]().GetProperty(columna.NombreColumna, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.IgnoreCase)
      Dim value = prop.GetValue(item, Nothing)

      Select Case prop.Name
         Case "SolicitoLevante"
            If item.LevanteAduaneroFecha Is Nothing Then
               If value = "1" Then
                  rowDetalle.CreateCell(columNum).SetCellValue("SI")
                  rowDetalle.GetCell(columNum).CellStyle = styleSolicitoLevanteSI
               Else
                  rowDetalle.CreateCell(columNum).SetCellValue("NO")
                  rowDetalle.GetCell(columNum).CellStyle = styleSolicitoLevanteNO
               End If
            Else
               rowDetalle.CreateCell(columNum).SetCellValue("")
            End If
            Return True
         Case "Semaforo"
            If item.Semaforo IsNot Nothing Then
               rowDetalle.CreateCell(columNum).SetCellValue("●")
               If item.Semaforo <= 6 Then
                  rowDetalle.GetCell(columNum).CellStyle = styleSemaforoVerde
               ElseIf item.Semaforo >= 7 And item.Semaforo <= 12 Then
                  rowDetalle.GetCell(columNum).CellStyle = styleSemaforoAmarillo
               ElseIf item.Semaforo >= 13 Then
                  rowDetalle.GetCell(columNum).CellStyle = styleSemaforoRojo
               End If
            Else
               rowDetalle.CreateCell(columNum).SetCellValue("")
            End If
            Return True
         Case "UbicacionDesc"
            If item.UbicacionDesc = "DEMO" Then
               rowDetalle.CreateCell(columNum).SetCellValue(item.DiasUbicacion.ToString + " - " + item.UbicacionDesc)
               If item.DiasUbicacion < 15 Then
                  rowDetalle.GetCell(columNum).CellStyle = styleUbicVerde
               Else
                  rowDetalle.GetCell(columNum).CellStyle = styleUbicRojo
               End If
            Else
               rowDetalle.CreateCell(columNum).SetCellValue(item.UbicacionDesc)
            End If
            Return True
         Case Else
            Return False
      End Select
   End Function

End Class