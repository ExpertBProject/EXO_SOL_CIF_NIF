﻿'------------------------------------------------------------------------------
' <auto-generated>
'     Este código fue generado por una herramienta.
'     Versión de runtime:4.0.30319.42000
'
'     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
'     se vuelve a generar el código.
' </auto-generated>
'------------------------------------------------------------------------------

Option Strict On
Option Explicit On


Namespace AEAT
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ServiceModel.ServiceContractAttribute([Namespace]:="http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacione"& _ 
        "s/es/aeat/burt/jdit/ws/VNifV2.wsdl", ConfigurationName:="AEAT.VNifV2")>  _
    Public Interface VNifV2
        
        'CODEGEN: Se está generando un contrato de mensaje, ya que la operación VNifV2 no es RPC ni está encapsulada en un documento.
        <System.ServiceModel.OperationContractAttribute(Action:="", ReplyAction:="*"),  _
         System.ServiceModel.XmlSerializerFormatAttribute(SupportFaults:=true)>  _
        Function VNifV2(ByVal request As AEAT.Entrada) As AEAT.Salida
        
        <System.ServiceModel.OperationContractAttribute(Action:="", ReplyAction:="*")>  _
        Function VNifV2Async(ByVal request As AEAT.Entrada) As System.Threading.Tasks.Task(Of AEAT.Salida)
    End Interface
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacione"& _ 
        "s/es/aeat/burt/jdit/ws/VNifV2Ent.xsd")>  _
    Partial Public Class VNifV2EntContribuyente
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private nifField As String
        
        Private nombreField As String
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>  _
        Public Property Nif() As String
            Get
                Return Me.nifField
            End Get
            Set
                Me.nifField = value
                Me.RaisePropertyChanged("Nif")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=1)>  _
        Public Property Nombre() As String
            Get
                Return Me.nombreField
            End Get
            Set
                Me.nombreField = value
                Me.RaisePropertyChanged("Nombre")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    '''<remarks/>
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.8.3761.0"),  _
     System.SerializableAttribute(),  _
     System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.ComponentModel.DesignerCategoryAttribute("code"),  _
     System.Xml.Serialization.XmlTypeAttribute(AnonymousType:=true, [Namespace]:="http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacione"& _ 
        "s/es/aeat/burt/jdit/ws/VNifV2Sal.xsd")>  _
    Partial Public Class VNifV2SalContribuyente
        Inherits Object
        Implements System.ComponentModel.INotifyPropertyChanged
        
        Private nifField As String
        
        Private nombreField As String
        
        Private resultadoField As String
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=0)>  _
        Public Property Nif() As String
            Get
                Return Me.nifField
            End Get
            Set
                Me.nifField = value
                Me.RaisePropertyChanged("Nif")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=1)>  _
        Public Property Nombre() As String
            Get
                Return Me.nombreField
            End Get
            Set
                Me.nombreField = value
                Me.RaisePropertyChanged("Nombre")
            End Set
        End Property
        
        '''<remarks/>
        <System.Xml.Serialization.XmlElementAttribute(Order:=2)>  _
        Public Property Resultado() As String
            Get
                Return Me.resultadoField
            End Get
            Set
                Me.resultadoField = value
                Me.RaisePropertyChanged("Resultado")
            End Set
        End Property
        
        Public Event PropertyChanged As System.ComponentModel.PropertyChangedEventHandler Implements System.ComponentModel.INotifyPropertyChanged.PropertyChanged
        
        Protected Sub RaisePropertyChanged(ByVal propertyName As String)
            Dim propertyChanged As System.ComponentModel.PropertyChangedEventHandler = Me.PropertyChangedEvent
            If (Not (propertyChanged) Is Nothing) Then
                propertyChanged(Me, New System.ComponentModel.PropertyChangedEventArgs(propertyName))
            End If
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class Entrada
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacione"& _ 
            "s/es/aeat/burt/jdit/ws/VNifV2Ent.xsd", Order:=0),  _
         System.Xml.Serialization.XmlArrayItemAttribute("Contribuyente", IsNullable:=false)>  _
        Public VNifV2Ent() As AEAT.VNifV2EntContribuyente
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal VNifV2Ent() As AEAT.VNifV2EntContribuyente)
            MyBase.New
            Me.VNifV2Ent = VNifV2Ent
        End Sub
    End Class
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0"),  _
     System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced),  _
     System.ServiceModel.MessageContractAttribute(IsWrapped:=false)>  _
    Partial Public Class Salida
        
        <System.ServiceModel.MessageBodyMemberAttribute([Namespace]:="http://www2.agenciatributaria.gob.es/static_files/common/internet/dep/aplicacione"& _ 
            "s/es/aeat/burt/jdit/ws/VNifV2Sal.xsd", Order:=0),  _
         System.Xml.Serialization.XmlArrayItemAttribute("Contribuyente", IsNullable:=false)>  _
        Public VNifV2Sal() As AEAT.VNifV2SalContribuyente
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal VNifV2Sal() As AEAT.VNifV2SalContribuyente)
            MyBase.New
            Me.VNifV2Sal = VNifV2Sal
        End Sub
    End Class
    
    <System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Public Interface VNifV2Channel
        Inherits AEAT.VNifV2, System.ServiceModel.IClientChannel
    End Interface
    
    <System.Diagnostics.DebuggerStepThroughAttribute(),  _
     System.CodeDom.Compiler.GeneratedCodeAttribute("System.ServiceModel", "4.0.0.0")>  _
    Partial Public Class VNifV2Client
        Inherits System.ServiceModel.ClientBase(Of AEAT.VNifV2)
        Implements AEAT.VNifV2
        
        Public Sub New()
            MyBase.New
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String)
            MyBase.New(endpointConfigurationName)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As String)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal endpointConfigurationName As String, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(endpointConfigurationName, remoteAddress)
        End Sub
        
        Public Sub New(ByVal binding As System.ServiceModel.Channels.Binding, ByVal remoteAddress As System.ServiceModel.EndpointAddress)
            MyBase.New(binding, remoteAddress)
        End Sub
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function AEAT_VNifV2_VNifV2(ByVal request As AEAT.Entrada) As AEAT.Salida Implements AEAT.VNifV2.VNifV2
            Return MyBase.Channel.VNifV2(request)
        End Function
        
        Public Function VNifV2(ByVal VNifV2Ent() As AEAT.VNifV2EntContribuyente) As AEAT.VNifV2SalContribuyente()
            Dim inValue As AEAT.Entrada = New AEAT.Entrada()
            inValue.VNifV2Ent = VNifV2Ent
            Dim retVal As AEAT.Salida = CType(Me,AEAT.VNifV2).VNifV2(inValue)
            Return retVal.VNifV2Sal
        End Function
        
        <System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Advanced)>  _
        Function AEAT_VNifV2_VNifV2Async(ByVal request As AEAT.Entrada) As System.Threading.Tasks.Task(Of AEAT.Salida) Implements AEAT.VNifV2.VNifV2Async
            Return MyBase.Channel.VNifV2Async(request)
        End Function
        
        Public Function VNifV2Async(ByVal VNifV2Ent() As AEAT.VNifV2EntContribuyente) As System.Threading.Tasks.Task(Of AEAT.Salida)
            Dim inValue As AEAT.Entrada = New AEAT.Entrada()
            inValue.VNifV2Ent = VNifV2Ent
            Return CType(Me,AEAT.VNifV2).VNifV2Async(inValue)
        End Function
    End Class
End Namespace