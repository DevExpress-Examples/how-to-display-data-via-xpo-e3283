using System.Windows;
using DevExpress.Xpo;
using DevExpress.Xpo.DB;

namespace DXGrid_BindingToXPODataSource {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitDAL();
            GenerateData();
            InitializeComponent();
            grid.ItemsSource = new XPCollection<ProductDataObject>();
        }

        /*
         * Creates a new DAL with the specified settings and initializes the XpoDefault.DataLayer property.
         * As a result, all the units of work (or sessions) will by default access the "Product" database
         * using the specified path.
         */
        private void InitDAL() {
            XpoDefault.DataLayer = XpoDefault.GetDataLayer(
                AccessConnectionProvider.GetConnectionString(@"c:\database\product.mdb"),
                AutoCreateOption.DatabaseAndSchema
            );
        }

        // Generates sample data if the "Product" database is empty.
        private void GenerateData() {
            if (Session.DefaultSession.FindObject<ProductDataObject>(null) != null) return;
            using (UnitOfWork uow = new UnitOfWork()) {
                ProductDataObject pdo1 = new ProductDataObject(uow) { ProductName = "Product A", UnitPrice = 99 };
                ProductDataObject pdo2 = new ProductDataObject(uow) { ProductName = "Product B", UnitPrice = 199 };
                uow.CommitChanges();
            }
        }
    }
}
