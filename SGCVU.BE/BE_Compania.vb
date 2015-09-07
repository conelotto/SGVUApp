Public Class BE_Compania

#Region "Atributos"

    Private _str_CompaniaCod As String = String.Empty
    Private _str_CompaniaDes As String = String.Empty
    Private _int_CompaniaID As Integer = 0

#End Region

#Region "Propiedades"

    Public Property str_CompaniaCod() As String
        Get
            Return _str_CompaniaCod
        End Get
        Set(ByVal value As String)
            _str_CompaniaCod = value
        End Set
    End Property

    Public Property str_CompaniaDes() As String
        Get
            Return _str_CompaniaDes
        End Get
        Set(ByVal value As String)
            _str_CompaniaDes = value
        End Set
    End Property

    Public Property int_CompaniaID() As Integer
        Get
            Return _int_CompaniaID
        End Get
        Set(ByVal value As Integer)
            _int_CompaniaID = value
        End Set
    End Property

#End Region
End Class
