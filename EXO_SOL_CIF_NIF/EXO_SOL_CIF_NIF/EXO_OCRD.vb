Imports System.ServiceModel
Imports System.Xml
Imports SAPbouiCOM
Public Class EXO_OCRD
    Inherits EXO_UIAPI.EXO_DLLBase

    Public Sub New(ByRef oObjGlobal As EXO_UIAPI.EXO_UIAPI, ByRef actualizar As Boolean, usaLicencia As Boolean, idAddOn As Integer)
        MyBase.New(oObjGlobal, actualizar, False, idAddOn)

        If actualizar Then
            cargaCampos()
        End If
    End Sub

    Private Sub cargaCampos()
        If objDIAPI.comunes.esAdministrador() Then
            objGlobal.escribeLog("El usuario es administrador")
            'Definicion descuentos financieros
            Dim oXML As String = ""

            If Not objDIAPI.OGEN.existeVariable("ValidaCIF_Cert") Then
                objDIAPI.OGEN.fijarValorVariable("ValidaCIF_Cert", "")
            End If

            If Not objDIAPI.OGEN.existeVariable("ValidaCIF_Pass") Then
                objDIAPI.OGEN.fijarValorVariable("ValidaCIF_Pass", "")
            End If

            If Not objDIAPI.OGEN.existeVariable("ValidaCIF_AvisoRestriccion") Then
                objDIAPI.OGEN.fijarValorVariable("ValidaCIF_AvisoRestriccion", "A")
            End If
        Else
            objGlobal.escribeLog("El usuario NO es administrador")
        End If
    End Sub
    Public Overrides Function filtros() As EventFilters
        Dim filtrosXML As Xml.XmlDocument = New Xml.XmlDocument
        filtrosXML.LoadXml(objGlobal.funciones.leerEmbebido(Me.GetType(), "XML_FILTROS.xml"))
        Dim filtro As SAPbouiCOM.EventFilters = New SAPbouiCOM.EventFilters()
        filtro.LoadFromXML(filtrosXML.OuterXml)

        Return filtro
    End Function
    Public Overrides Function menus() As System.Xml.XmlDocument
        Return Nothing
    End Function
    Public Overrides Function SBOApp_ItemEvent(infoEvento As ItemEvent) As Boolean
        Try
            If infoEvento.InnerEvent = False Then
                If infoEvento.BeforeAction = False Then
                    Select Case infoEvento.FormTypeEx
                        Case "134"
                            Select Case infoEvento.EventType
                                Case SAPbouiCOM.BoEventTypes.et_COMBO_SELECT

                                Case SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED

                                Case SAPbouiCOM.BoEventTypes.et_CLICK

                                Case SAPbouiCOM.BoEventTypes.et_DOUBLE_CLICK

                                Case SAPbouiCOM.BoEventTypes.et_VALIDATE

                                Case SAPbouiCOM.BoEventTypes.et_KEY_DOWN

                                Case SAPbouiCOM.BoEventTypes.et_MATRIX_LINK_PRESSED

                                Case SAPbouiCOM.BoEventTypes.et_FORM_RESIZE

                            End Select
                    End Select
                ElseIf infoEvento.BeforeAction = True Then
                    Select Case infoEvento.FormTypeEx
                        Case "134"

                            Select Case infoEvento.EventType
                                Case SAPbouiCOM.BoEventTypes.et_COMBO_SELECT

                                Case SAPbouiCOM.BoEventTypes.et_CLICK

                                Case SAPbouiCOM.BoEventTypes.et_ITEM_PRESSED

                                Case SAPbouiCOM.BoEventTypes.et_VALIDATE
                                    If EventHandler_VALIDATE_Before(infoEvento) = False Then
                                        GC.Collect()
                                        Return False
                                    End If
                                Case SAPbouiCOM.BoEventTypes.et_KEY_DOWN

                                Case SAPbouiCOM.BoEventTypes.et_MATRIX_LINK_PRESSED

                                Case SAPbouiCOM.BoEventTypes.et_DOUBLE_CLICK

                            End Select
                    End Select
                End If
            Else
                If infoEvento.BeforeAction = False Then
                    Select Case infoEvento.FormTypeEx
                        Case "134"
                            Select Case infoEvento.EventType
                                Case SAPbouiCOM.BoEventTypes.et_FORM_VISIBLE

                                Case SAPbouiCOM.BoEventTypes.et_FORM_LOAD

                                Case SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST

                            End Select
                    End Select
                Else
                    Select Case infoEvento.FormTypeEx
                        Case "134"
                            Select Case infoEvento.EventType
                                Case SAPbouiCOM.BoEventTypes.et_CHOOSE_FROM_LIST

                                Case SAPbouiCOM.BoEventTypes.et_PICKER_CLICKED

                            End Select
                    End Select
                End If
            End If

            Return MyBase.SBOApp_ItemEvent(infoEvento)
        Catch exCOM As System.Runtime.InteropServices.COMException
            objGlobal.Mostrar_Error(exCOM, EXO_UIAPI.EXO_UIAPI.EXO_TipoMensaje.Excepcion)
            Return False
        Catch ex As Exception
            objGlobal.Mostrar_Error(ex, EXO_UIAPI.EXO_UIAPI.EXO_TipoMensaje.Excepcion)
            Return False
        End Try
    End Function
    Public Overrides Function SBOApp_FormDataEvent(infoEvento As BusinessObjectInfo) As Boolean
        Dim resultado As Boolean = True
        Dim formulario As SAPbouiCOM.Form = Nothing
        Try
            If infoEvento.BeforeAction Then
                Select Case infoEvento.FormTypeEx
                    Case "134"
                        Select Case infoEvento.EventType
                            Case BoEventTypes.et_FORM_DATA_ADD, BoEventTypes.et_FORM_DATA_UPDATE
                                formulario = objGlobal.SBOApp.Forms.Item(infoEvento.FormUID)
                                If formulario.DataSources.DBDataSources.Item("OCRD").GetValue("CardName", 0) = "" Or formulario.DataSources.DBDataSources.Item("OCRD").GetValue("LicTradNum", 0) = "" Then
                                    objGlobal.SBOApp.MessageBox("La razón social y el CIF son obligatorios.")
                                    Return False
                                Else
                                    If Left(formulario.DataSources.DBDataSources.Item("OCRD").GetValue("LicTradNum", 0), 2) = "ES" Then
                                        resultado = ComprobarCIFporAEAT(formulario, infoEvento)
                                    End If
                                End If
                        End Select
                End Select
            End If
        Catch exCOM As System.Runtime.InteropServices.COMException
            objGlobal.Mostrar_Error(exCOM, EXO_UIAPI.EXO_UIAPI.EXO_TipoMensaje.Excepcion)
            Return False
        Catch ex As Exception
            objGlobal.Mostrar_Error(ex, EXO_UIAPI.EXO_UIAPI.EXO_TipoMensaje.Excepcion)
            Return False
        Finally
            EXO_CleanCOM.CLiberaCOM.Form(formulario)
        End Try
        Return resultado
    End Function
    Private Function EventHandler_VALIDATE_Before(ByRef pVal As ItemEvent) As Boolean
        Dim oForm As SAPbouiCOM.Form = objGlobal.SBOApp.Forms.Item(pVal.FormUID)

        EventHandler_VALIDATE_Before = False
        Try
            Select Case pVal.ColUID
                Case "41"
                    'Controlamos el CIF
                    If ComprobarCIFporAEAT(oForm, pVal) = True Then
                        If ComprobarsiExisteCIF(oForm) = True Then
                            EventHandler_VALIDATE_Before = True
                        Else
                            EventHandler_VALIDATE_Before = False
                        End If
                    Else
                        EventHandler_VALIDATE_Before = False
                    End If
                Case Else
                    EventHandler_VALIDATE_Before = True
            End Select


        Catch exCOM As System.Runtime.InteropServices.COMException
            objGlobal.Mostrar_Error(exCOM, EXO_UIAPI.EXO_UIAPI.EXO_TipoMensaje.Excepcion)
        Catch ex As Exception
            objGlobal.Mostrar_Error(ex, EXO_UIAPI.EXO_UIAPI.EXO_TipoMensaje.Excepcion)
        Finally
            EXO_CleanCOM.CLiberaCOM.liberaCOM(CType(oForm, Object))
        End Try
    End Function
    Private Function ComprobarCIFporAEAT(ByRef formulario As SAPbouiCOM.Form, ByRef infoEvento As BusinessObjectInfo) As Boolean
        ComprobarCIFporAEAT = False
        Try

            'comprobamos si la variable tiene control de cif
            Dim TipoComprobacion As String = objGlobal.refDi.OGEN.valorVariable("ValidaCIF_AvisoRestriccion")

            Dim ValidaCIF_Cert As String = objGlobal.refDi.OGEN.valorVariable("ValidaCIF_Cert")
            Dim ValidaCIF_Pass As String = objGlobal.refDi.comunes.cifrador.desencripta(objGlobal.refDi.OGEN.valorVariable("ValidaCIF_Pass"))

            If ValidaCIF_Pass = "" Or ValidaCIF_Cert = "" Then
                objGlobal.SBOApp.SetStatusBarMessage("Configure correctamente los parametros del certificado de la AEAT", BoMessageTime.bmt_Short, True)
                Return False
            End If

            Dim bError As Boolean = False

            If TipoComprobacion <> "N" Then

                'Recogemos el certificado
                Dim CertificadoCorrecto As New System.Security.Cryptography.X509Certificates.X509Certificate2()
                CertificadoCorrecto = New System.Security.Cryptography.X509Certificates.X509Certificate2(ValidaCIF_Cert, ValidaCIF_Pass)

                'Desde una dll no podemos leer el app.config de la dll, ya que sería el del kernel.
                'Por tanto hay que crear la configuración del binding y el endpoint en el código y pasarselo a la propia llamada.
                Dim binding As BasicHttpBinding = New BasicHttpBinding()
                binding.Name = "VNifV2SoapBinding"
                binding.Security.Mode = BasicHttpSecurityMode.Transport
                binding.Security.Transport.ClientCredentialType = HttpClientCredentialType.Certificate

                Dim endpoint As EndpointAddress = New System.ServiceModel.EndpointAddress("https://www1.agenciatributaria.gob.es/wlpl/BURT-JDIT/ws/VNifV2SOAP")

                'comenzamos la llamada
                Dim clientews As AEAT.VNifV2Client = New AEAT.VNifV2Client(binding, endpoint)

                clientews.ClientCredentials.ClientCertificate.Certificate = CertificadoCorrecto
                clientews.ClientCredentials.UseIdentityConfiguration = True

                Dim contribuyente(0) As AEAT.VNifV2EntContribuyente
                contribuyente(0) = New AEAT.VNifV2EntContribuyente

                contribuyente(0).Nif = formulario.DataSources.DBDataSources.Item("OCRD").GetValue("LicTradNum", 0).Substring(2) 'CType(formulario.Items.Item("41").Specific, SAPbouiCOM.EditText).Value.Substring(2)
                contribuyente(0).Nombre = formulario.DataSources.DBDataSources.Item("OCRD").GetValue("CardName", 0) 'CType(formulario.Items.Item("7").Specific, SAPbouiCOM.EditText).Value

                Dim oEntrada As New AEAT.Entrada
                oEntrada.VNifV2Ent = contribuyente

                objGlobal.SBOApp.SetStatusBarMessage("Validando CIF con AEAT.", BoMessageTime.bmt_Short, False)
                Dim osalida As AEAT.Salida = clientews.AEAT_VNifV2_VNifV2(oEntrada)
                Dim res As String = osalida.VNifV2Sal(0).Resultado

                'info del doc de la AEAT
                ' “Identificado” Si el contribuyente se identifica con los datos identificativos aportados. Se devuelven los datos de apellidos y nombre asociados al NIF.
                '- “No identificado-similar”: Si el contribuyente no se identifica con los datos identificativos aportados por diferencias menores en los apellidos y nombre. Se devuelven los datos de apellidos y nombre asociados al NIF.
                '- “No identificado”: Si el contribuyente no se identifica con los datos identificativos aportados. Se devuelven los datos de NIF y apellidos y nombre aportados.
                '- “Identificado-Baja”. Si el contribuyente se identifica con el NIF aportado, y está en estado baja. Se devuelve el NIF actual y su razón social.
                '- “Identificado-Revocado”. Si el contribuyente se identifica con el NIF y esta revocado

                If res = "IDENTIFICADO" Then
                    objGlobal.SBOApp.SetStatusBarMessage("CIF correcto. Cliente " + osalida.VNifV2Sal(0).Nombre.ToString, BoMessageTime.bmt_Short, False)
                ElseIf res = "NO IDENTIFICADO-SIMILAR" Then
                    objGlobal.SBOApp.SetStatusBarMessage("CIF correcto, nombre similar, revisar datos en la ficha: " + osalida.VNifV2Sal(0).Nombre.ToString, BoMessageTime.bmt_Short, True)
                    bError = True
                ElseIf res = "IDENTIFICADO-BAJA" Then
                    objGlobal.SBOApp.SetStatusBarMessage("CIF dado de baja. " + osalida.VNifV2Sal(0).Nombre.ToString, BoMessageTime.bmt_Short, False)
                    bError = True
                ElseIf res = "NO IDENTIFICADO-REVOCADO" Then
                    objGlobal.SBOApp.SetStatusBarMessage("CIF rebocado. " + osalida.VNifV2Sal(0).Nombre.ToString, BoMessageTime.bmt_Short, True)
                    bError = True
                Else
                    objGlobal.SBOApp.SetStatusBarMessage("CIF no identificado: " + osalida.VNifV2Sal(0).Nif.ToString, BoMessageTime.bmt_Short, True)
                    bError = True
                End If

                If bError = True Then
                    If TipoComprobacion = "A" Then

                        Dim respuestaTraspasar As Integer = objGlobal.SBOApp.MessageBox("El CIF no está identificado. ¿Continuar?", 1, "OK", "Cancelar")
                        If respuestaTraspasar <> 1 Then
                            Return False
                        Else
                            Return True
                        End If

                    ElseIf TipoComprobacion = "R" Then
                        objGlobal.SBOApp.MessageBox("El CIF no está identificado.")
                        Return False
                    End If
                End If

            End If

        Catch ex As Exception
            If ex.Message = "Salt no tiene al menos ocho bytes." Then
                objGlobal.SBOApp.MessageBox("Revise los datos del certificado")
            Else
                objGlobal.SBOApp.MessageBox(ex.Message)
            End If
        End Try
    End Function
    Private Function ComprobarsiExisteCIF(ByRef oForm As SAPbouiCOM.Form) As Boolean
        ComprobarsiExisteCIF = False
        Dim sSQL As String = "" : Dim sNIF As String = "" : Dim sTipo As String = "" : Dim sMensaje As String = ""
        Dim oRs As SAPbobsCOM.Recordset = CType(objGlobal.compañia.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset), SAPbobsCOM.Recordset)
        Dim sTable_Origen As String = ""
        Try
            sTable_Origen = CType(oForm.Items.Item("5").Specific, SAPbouiCOM.EditText).DataBind.TableName
            sNIF = CType(oForm.Items.Item("41").Specific, SAPbouiCOM.EditText).Value.ToString
            sTipo = oForm.DataSources.DBDataSources.Item(sTable_Origen).GetValue("CardType", 0).ToString
            sSQL = "SELECT ""CardCode"",""CardName"" FROM ""OCRD"" WHERE ""CardType""='" & sTipo & "' "
            sSQL &= " WHERE ""LicTradNum""='" & sNIF & "'"
            oRs.DoQuery(sSQL)
            If oRs.RecordCount > 0 Then
                sMensaje = "Ya existe el Nº de Identificación fiscal con el Interlocutor: " & oRs.Fields.Item("CardCode").Value.ToString
                sMensaje &= " - " & oRs.Fields.Item("CardName").Value.ToString
                sMensaje &= ChrW(10) & ChrW(13)
                sMensaje &= "¿Desea continuar?"
                If objGlobal.SBOApp.MessageBox(sMensaje, 2, "Sí", "No") = 1 Then
                    ComprobarsiExisteCIF = False
                Else
                    ComprobarsiExisteCIF = True
                End If
            Else
                ComprobarsiExisteCIF = True
            End If
        Catch ex As Exception
            objGlobal.SBOApp.MessageBox(ex.Message)
        Finally
            EXO_CleanCOM.CLiberaCOM.liberaCOM(CType(oRs, Object))
        End Try
    End Function
End Class
