Public Class clsEntidad_ParametroSQL

   Public strParameterName As String = String.Empty
   'Public typDbType As SqlDbType = Nothing
   Public typDbType As System.Data.DbType
   Public intSize As Integer = 0
   Public strSourceColumn As Object = Nothing
   Public byteSourceColumn As Byte() = Nothing             'TODO: Validar - 20141222 - Adicionado para poder enviar datos binarios - N
   Public intDirection As ParameterDirection = ParameterDirection.Input

   Public Shared Function fn_GetDBType(ByVal pi_Type As System.Type) As System.Data.DbType
      Try
         Dim sqlParameter As SqlClient.SqlParameter
         'Dim sqlParameter As Common.DbParameter '= Nothing
         Dim typeConverter As System.ComponentModel.TypeConverter

         sqlParameter = New SqlClient.SqlParameter()
         'sqlParameter = New Common.DbParameter()
         typeConverter = System.ComponentModel.TypeDescriptor.GetConverter(sqlParameter.DbType)

         If typeConverter.CanConvertFrom(pi_Type) Then
            sqlParameter.DbType = typeConverter.ConvertFrom(pi_Type.Name)
         Else
            'Try brute force
            Try
               sqlParameter.DbType = typeConverter.ConvertFrom(pi_Type.Name)
            Catch ex As Exception
               'Do Nothing
            End Try
         End If

         Return sqlParameter.DbType  'sqlParameter.SqlDbType
      Catch ex As Exception
         Throw ex
      End Try
   End Function

End Class
