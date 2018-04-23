Imports System
Imports DevExpress.Xpo

Namespace DXGrid_BindingToXPODataSource

    Public Class ProductDataObject
        Inherits XPObject

        Public Sub New()
            MyBase.New()
            ' This constructor is used when an object is loaded from a persistent storage.
            ' Do not place any code here.
        End Sub

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
            ' This constructor is used when an object is loaded from a persistent storage.
            ' Do not place any code here.
        End Sub

        Public Overrides Sub AfterConstruction()
            MyBase.AfterConstruction()
            ' Place here your initialization code.
        End Sub

        Private fProductName As String
        Public Property ProductName() As String
            Get
                Return fProductName
            End Get
            Set(ByVal value As String)
                SetPropertyValue(Of String)("ProductName", fProductName, value)
            End Set
        End Property

        Private fUnitPrice As Integer
        Public Property UnitPrice() As Integer
            Get
                Return fUnitPrice
            End Get
            Set(ByVal value As Integer)
                SetPropertyValue(Of Integer)("UnitPrice", fUnitPrice, value)
            End Set
        End Property
    End Class
End Namespace