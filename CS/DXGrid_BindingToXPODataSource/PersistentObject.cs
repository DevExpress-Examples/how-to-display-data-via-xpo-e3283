using System;
using DevExpress.Xpo;

namespace DXGrid_BindingToXPODataSource {

    public class ProductDataObject : XPObject {
        public ProductDataObject()
            : base() {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public ProductDataObject(Session session)
            : base(session) {
            // This constructor is used when an object is loaded from a persistent storage.
            // Do not place any code here.
        }

        public override void AfterConstruction() {
            base.AfterConstruction();
            // Place here your initialization code.
        }

        private string fProductName;
        public string ProductName {
            get { return fProductName; }
            set { SetPropertyValue<string>("ProductName", ref fProductName, value); }
        }

        private int fUnitPrice;
        public int UnitPrice {
            get { return fUnitPrice; }
            set { SetPropertyValue<int>("UnitPrice", ref fUnitPrice, value); }
        }
    }
}