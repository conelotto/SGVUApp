Imports System.Reflection

Public Class clsConvertDatatableToList

   Public Shared Function fn_ConvertToList(Of T)(ByVal pi_dtb As DataTable) As IList(Of T)
      If pi_dtb Is Nothing Then
         Return Nothing
      End If
      Dim rows As New List(Of DataRow)()
      For Each row As DataRow In pi_dtb.Rows
         rows.Add(row)
      Next
      Return fn_ConvertTo(Of T)(rows)
   End Function

   Private Shared Function fn_ConvertTo(Of T)(ByVal pi_row As IList(Of DataRow)) As IList(Of T)
      Dim list As IList(Of T) = Nothing
      If pi_row IsNot Nothing Then
         list = New List(Of T)()
         For Each row As DataRow In pi_row
            Dim item As T = fn_CreateItem(Of T)(row)
            list.Add(item)
         Next
      End If
      Return list
   End Function

   Private Shared Function fn_CreateItem(Of T)(ByVal pi_row As DataRow) As T
      Dim columnName As String
      Dim obj As T = Nothing
      If pi_row IsNot Nothing Then
         obj = Activator.CreateInstance(Of T)()
         For Each column As DataColumn In pi_row.Table.Columns
            columnName = column.ColumnName
            'Get property with same columnName
            Dim prop As PropertyInfo = obj.[GetType]().GetProperty(columnName, BindingFlags.Public Or BindingFlags.Instance Or BindingFlags.IgnoreCase)

            If prop IsNot Nothing Then
               'Get value for the column
               Dim value As Object = If((pi_row(columnName).[GetType]() = GetType(DBNull)), Nothing, pi_row(columnName))
               'Set property value
               If value Is Nothing Then
                  prop.SetValue(obj, value, Nothing)
               Else
                  If If(Nullable.GetUnderlyingType(prop.PropertyType), prop.PropertyType) <> value.GetType() Then
                     prop.SetValue(obj, Convert.ChangeType(value, prop.PropertyType), Nothing)
                  Else
                     prop.SetValue(obj, value, Nothing)
                  End If
               End If

            End If
         Next
      End If
      Return obj
   End Function

End Class