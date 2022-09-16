using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTTransferLineServiceContract : XppObjectBase
    {
        private string descriptionField;

        private string inventTransferIdField;

        private string itemBarcodeField;

        private string itemIdField;

        private decimal qtyShippedField;

        private bool qtyShippedFieldSpecified;

        private decimal qtyTransferField;

        private bool qtyTransferFieldSpecified;

        private long recIdField;

        private bool recIdFieldSpecified;

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

        [XmlElement(IsNullable = true)]
        public string InventTransferId
        {
            get
            {
                return this.inventTransferIdField;
            }
            set
            {
                this.inventTransferIdField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string ItemBarcode
        {
            get
            {
                return this.itemBarcodeField;
            }
            set
            {
                this.itemBarcodeField = value;
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

        public decimal QtyShipped
        {
            get
            {
                return this.qtyShippedField;
            }
            set
            {
                this.qtyShippedField = value;
            }
        }

        [XmlIgnore]
        public bool QtyShippedSpecified
        {
            get
            {
                return this.qtyShippedFieldSpecified;
            }
            set
            {
                this.qtyShippedFieldSpecified = value;
            }
        }

        public decimal QtyTransfer
        {
            get
            {
                return this.qtyTransferField;
            }
            set
            {
                this.qtyTransferField = value;
            }
        }

        [XmlIgnore]
        public bool QtyTransferSpecified
        {
            get
            {
                return this.qtyTransferFieldSpecified;
            }
            set
            {
                this.qtyTransferFieldSpecified = value;
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

        public ApntAxHHTTransferLineServiceContract()
        {
        }
    }
}