Imports System.Windows
Imports DevExpress.Xpo
Imports DevExpress.Xpo.DB

Namespace DXGrid_BindingToXPODataSource
    ''' <summary>
    ''' Interaction logic for MainWindow.xaml
    ''' </summary>
    Partial Public Class MainWindow
        Inherits Window

        Public Sub New()
            InitDAL()
            GenerateData()
            InitializeComponent()
            grid.ItemsSource = New XPCollection(Of ProductDataObject)()
        End Sub

'        
'         * Creates a new DAL with the specified settings and initializes the XpoDefault.DataLayer property.
'         * As a result, all the units of work (or sessions) will by default access the "Product" database
'         * using the specified path.
'         
        Private Sub InitDAL()
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(AccessConnectionProvider.GetConnectionString("c:\database\product.mdb"), AutoCreateOption.DatabaseAndSchema)
        End Sub

        ' Generates sample data if the "Product" database is empty.
        Private Sub GenerateData()
            If Session.DefaultSession.FindObject(Of ProductDataObject)(Nothing) IsNot Nothing Then
                Return
            End If
            Using uow As New UnitOfWork()
                Dim pdo1 As New ProductDataObject(uow) With {.ProductName = "Product A", .UnitPrice = 99}
                Dim pdo2 As New ProductDataObject(uow) With {.ProductName = "Product B", .UnitPrice = 199}
                uow.CommitChanges()
            End Using
        End Sub
    End Class
End Namespace
