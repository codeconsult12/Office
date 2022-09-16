using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTBarcodeTableServiceContract : XppObjectBase
    {
        private string descriptionField;

        private string hHTDataFieldField;

        private NoYes hHTInvalidBarcodeField;

        private bool hHTInvalidBarcodeFieldSpecified;

        private string inventLocationIdField;

        private string itemBarCodeField;

        private string itemIdField;

        private string itemPrimaryVendIdField;

        private decimal onHandQtyField;

        private bool onHandQtyFieldSpecified;

        private string primaryStoreIdField;

        private DateTime transDateField;

        private bool transDateFieldSpecified;

        [XmlElement(IsNullable = true)]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTDataField
        {
            get
            {
                return this.hHTDataFieldField;
            }
            set
            {
                this.hHTDataFieldField = value;
            }
        }

        public NoYes HHTInvalidBarcode
        {
            get
            {
                return this.hHTInvalidBarcodeField;
            }
            set
            {
                this.hHTInvalidBarcodeField = value;
            }
        }

        [XmlIgnore]
        public bool HHTInvalidBarcodeSpecified
        {
            get
            {
                return this.hHTInvalidBarcodeFieldSpecified;
            }
            set
            {
                this.hHTInvalidBarcodeFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string InventLocationId
        {
            get
            {
                return this.inventLocationIdField;
            }
            set
            {
                this.inventLocationIdField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string ItemBarCode
        {
            get
            {
                return this.itemBarCodeField;
            }
            set
            {
                this.itemBarCodeField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string ItemId
        {
            get
            {
                return this.itemIdField;
            }
            set
            {
                this.itemIdField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string ItemPrimaryVendId
        {
            get
            {
                return this.itemPrimaryVendIdField;
            }
            set
            {
                this.itemPrimaryVendIdField = value;
            }
        }

        public decimal OnHandQty
        {
            get
            {
                return this.onHandQtyField;
            }
            set
            {
                this.onHandQtyField = value;
            }
        }

        [XmlIgnore]
        public bool OnHandQtySpecified
        {
            get
            {
                return this.onHandQtyFieldSpecified;
            }
            set
            {
                this.onHandQtyFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string PrimaryStoreId
        {
            get
            {
                return this.primaryStoreIdField;
            }
            set
            {
                this.primaryStoreIdField = value;
            }
        }

        public DateTime TransDate
        {
            get
            {
                return this.transDateField;
            }
            set
            {
                this.transDateField = value;
            }
        }

        [XmlIgnore]
        public bool TransDateSpecified
        {
            get
            {
                return this.transDateFieldSpecified;
            }
            set
            {
                this.transDateFieldSpecified = value;
            }
        }

        public ApntAxHHTBarcodeTableServiceContract()
        {
        }
    }
}