using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTPurchLineServiceContract : XppObjectBase
    {
        private string descriptionField;

        private decimal inventQtyField;

        private bool inventQtyFieldSpecified;

        private string itemBarCodeField;

        private string itemIdField;

        private string purchExternalItemIdField;

        private string purchIdField;

        private long recIdField;

        private bool recIdFieldSpecified;

        private string tradeInventTransIdField;

        private string unitIdField;

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

        public decimal InventQty
        {
            get
            {
                return this.inventQtyField;
            }
            set
            {
                this.inventQtyField = value;
            }
        }

        [XmlIgnore]
        public bool InventQtySpecified
        {
            get
            {
                return this.inventQtyFieldSpecified;
            }
            set
            {
                this.inventQtyFieldSpecified = value;
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
        public string PurchExternalItemId
        {
            get
            {
                return this.purchExternalItemIdField;
            }
            set
            {
                this.purchExternalItemIdField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string PurchId
        {
            get
            {
                return this.purchIdField;
            }
            set
            {
                this.purchIdField = value;
            }
        }

        public long RecId
        {
            get
            {
                return this.recIdField;
            }
            set
            {
                this.recIdField = value;
            }
        }

        [XmlIgnore]
        public bool RecIdSpecified
        {
            get
            {
                return this.recIdFieldSpecified;
            }
            set
            {
                this.recIdFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string TradeInventTransId
        {
            get
            {
                return this.tradeInventTransIdField;
            }
            set
            {
                this.tradeInventTransIdField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string UnitId
        {
            get
            {
                return this.unitIdField;
            }
            set
            {
                this.unitIdField = value;
            }
        }

        public ApntAxHHTPurchLineServiceContract()
        {
        }
    }
}