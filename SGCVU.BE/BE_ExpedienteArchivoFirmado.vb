﻿Public Class BE_ExpedienteArchivoFirmado
    Public Property int_ExpedienteId As Integer
    Public Property str_NombreArchivo As String
    Public Property int_IdClase As Integer
    Public Property bin_Archivo As Byte() = Nothing
    Public Property str_UsuarioCreacion As String
    Public Property dt_FechaCreacion As DateTime
    Public Property str_UsuarioModificacion As String
    Public Property dt_FechaModificacion As DateTime
End Class
