Imports SGCVU.WS.WS_CRM_QA
Imports System.String

Friend Class ConsultarCRM_QA
   Inherits ConsultarWS_Base
   Implements IConsultarCRM

   Private wsGestionComercial As ZWS_GESTION_COMERCIAL

   Public Sub New()
      MyBase.New()
      wsGestionComercial = New ZWS_GESTION_COMERCIAL()
      wsGestionComercial.Credentials = credenciales
   End Sub

   Public Function ObtenerDatosOportunidad(ByVal pi_strOportunidad As String) As Object Implements IConsultarCRM.ObtenerDatosOportunidad
      Dim objDatosOportunidad As Object = Nothing
      Dim ipOportunidad As ZES_IP_OPORTUNIDAD = New ZES_IP_OPORTUNIDAD()
      ipOportunidad.OBJECT_ID = pi_strOportunidad

      Dim oportunidades(0) As ZES_IP_OPORTUNIDAD
      oportunidades(0) = ipOportunidad

      Dim dataOportunidad As ZSOA_DATA_OPORTUNIDAD = New ZSOA_DATA_OPORTUNIDAD()
      dataOportunidad.IT_OBJECT_ID = oportunidades

      Dim dataOportunidadResponse As ZSOA_DATA_OPORTUNIDADResponse = wsGestionComercial.ZSOA_DATA_OPORTUNIDAD(dataOportunidad)

      Dim bpOportunidad As ZES_BP_OPORTUNIDAD = Nothing
      If dataOportunidadResponse.ET_BP_OPORTUNIDAD.Length > 0 Then
         bpOportunidad = dataOportunidadResponse.ET_BP_OPORTUNIDAD(0)

         Dim bpSocioNegocio As ZES_BP_SOCIO_NEGOCIO = ObtenerDatosSocioNegocio(bpOportunidad.PARTNER_INT)
         Dim bpEmpleado As ZES_BP_EMPLEADO = ObtenerDatosEmpleado(bpOportunidad.PARTNER_RESP, True)

         Dim clienteId As String = ""
         Dim clienteDesc As String = ""
         Dim vendedorId As String = ""
         Dim vendedorDesc As String = ""

         If bpSocioNegocio IsNot Nothing Then
            clienteId = bpSocioNegocio.CORPORA
            clienteDesc = bpSocioNegocio.NAMEOR1
         End If

         If bpEmpleado IsNot Nothing Then
            vendedorId = bpEmpleado.PERNR
            vendedorDesc = Concat(bpEmpleado.NAME_LAST, " ", bpEmpleado.NAME_FIRST)
         End If

         objDatosOportunidad = New With {Key .clienteId = clienteId, .clienteDesc = clienteDesc, .vendedorId = vendedorId, .vendedorDesc = vendedorDesc}
      End If

      Return objDatosOportunidad
   End Function

   Public Function ObtenerDatosPersonal(ByVal pi_strNumeroPersonal As String) As Empleado Implements IConsultarCRM.ObtenerDatosPersonal
      Dim bpEmpleado As ZES_BP_EMPLEADO = ObtenerDatosEmpleado(pi_strNumeroPersonal, False)
      Dim empleado As Empleado = New Empleado()
      With empleado
         .CodigoSAP = bpEmpleado.PARTNER
         .NroPersonal = bpEmpleado.PERNR
         .Nombres = bpEmpleado.NAME_FIRST
         .Apellidos = bpEmpleado.NAME_LAST
         .Funcion = bpEmpleado.FUNCION
         .Cargo = bpEmpleado.CARGO
         .CodigoAdrian = bpEmpleado.BU_SORT1
      End With
      Return empleado
   End Function

   Private Function ObtenerDatosEmpleado(ByVal pi_strCodigo As String, ByVal pi_esCodigoSAP As Boolean)
      Dim ipEmpleado As ZES_IP_EMPLEADO = New ZES_IP_EMPLEADO()

      If pi_esCodigoSAP Then
         ipEmpleado.PARTNER = pi_strCodigo
      Else
         ipEmpleado.PERNR = pi_strCodigo
      End If

      Dim empleados(0) As ZES_IP_EMPLEADO
      empleados(0) = ipEmpleado

      Dim dataEmpleado As ZSOA_DATA_EMPLEADO = New ZSOA_DATA_EMPLEADO()
      dataEmpleado.IT_EMPLEADO = empleados

      Dim dataEmpleadoResponse As ZSOA_DATA_EMPLEADOResponse = wsGestionComercial.ZSOA_DATA_EMPLEADO(dataEmpleado)

      Dim bpEmpleado As ZES_BP_EMPLEADO = Nothing
      If dataEmpleadoResponse.ET_BP_EMPLEADO.Length > 0 Then
         bpEmpleado = dataEmpleadoResponse.ET_BP_EMPLEADO(0)
      End If

      Return bpEmpleado
   End Function

   Private Function ObtenerDatosSocioNegocio(ByVal pi_strCodigo As String)
      Dim ipSocioNegocio As ZES_IP_SOCIO_NEGOCIO = New ZES_IP_SOCIO_NEGOCIO()
      ipSocioNegocio.PARTNER = pi_strCodigo

      Dim sociosNegocio(0) As ZES_IP_SOCIO_NEGOCIO
      sociosNegocio(0) = ipSocioNegocio

      Dim datasocioNegocio As ZSOA_DATA_SOCIO_NEGOCIO = New ZSOA_DATA_SOCIO_NEGOCIO()
      datasocioNegocio.IT_SOCIO_NEGOCIO = sociosNegocio

      Dim dataSocioNegocioResponse As ZSOA_DATA_SOCIO_NEGOCIOResponse = wsGestionComercial.ZSOA_DATA_SOCIO_NEGOCIO(datasocioNegocio)

      Dim bpSocioNegocio As ZES_BP_SOCIO_NEGOCIO = Nothing
      If dataSocioNegocioResponse.ET_BP_SOCIO_NEGOCIO.Length > 0 Then
         bpSocioNegocio = dataSocioNegocioResponse.ET_BP_SOCIO_NEGOCIO(0)
      End If

      Return bpSocioNegocio
   End Function

End Class