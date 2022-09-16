using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTSuppItemsServiceContract : XppObjectBase
    {
        private decimal discountPercentField;

        private bool discountPercentFieldSpecified;

        private decimal discountperUnitField;

        private bool discountperUnitFieldSpecified;

        private DateTime fromDateField;

        private bool fromDateFieldSpecified;

        private string itemNameField;

        private string purchUnitField;

        private NoYes suppItemFreeField;

        private bool suppItemFreeFieldSpecified;

        private string suppItemIdField;

        private string suppItemNameField;

        private string suppUnitField;

        private DateTime toDateField;

        private bool toDateFieldSpecified;

        private decimal purchQtyField;

        private bool purchQtyFieldSpecified;

        private decimal suppQtyField;

        private bool suppQtyFieldSpecified;

        public decimal DiscountPercent
        {
            get
            {
                return this.discountPercentField;
            }
            set
            {
                this.discountPercentField = value;
            }
        }

        [XmlIgnore]
        public bool DiscountPercentSpecified
        {
            get
            {
                return this.discountPercentFieldSpecified;
            }
            set
            {
                this.discountPercentFieldSpecified = value;
            }
        }

        public decimal DiscountperUnit
        {
            get
            {
                return this.discountperUnitField;
            }
            set
            {
                this.discountperUnitField = value;
            }
        }

        [XmlIgnore]
        public bool DiscountperUnitSpecified
        {
            get
            {
                return this.discountperUnitFieldSpecified;
            }
            set
            {
                this.discountperUnitFieldSpecified = value;
            }
        }

        public DateTime FromDate
        {
            get
            {
                return this.fromDateField;
            }
            set
            {
                this.fromDateField = value;
            }
        }

        [XmlIgnore]
        public bool FromDateSpecified
        {
            get
            {
                return this.fromDateFieldSpecified;
            }
            set
            {
                this.fromDateFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string ItemName
        {
            get
            {
                return this.itemNameField;
            }
            set
            {
                this.itemNameField = value;
            }
        }

        public decimal purchQty
        {
            get
            {
                return this.purchQtyField;
            }
            set
            {
                this.purchQtyField = value;
            }
        }

        [XmlIgnore]
        public bool purchQtySpecified
        {
            get
            {
                return this.purchQtyFieldSpecified;
            }
            set
            {
                this.purchQtyFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string PurchUnit
        {
            get
            {
                return this.purchUnitField;
            }
            set
            {
                this.purchUnitField = value;
            }
        }

        public NoYes SuppItemFree
        {
            get
            {
                return this.suppItemFreeField;
            }
            set
            {
                this.suppItemFreeField = value;
            }
        }

        [XmlIgnore]
        public bool SuppItemFreeSpecified
        {
            get
            {
                return this.suppItemFreeFieldSpecified;
            }
            set
            {
                this.suppItemFreeFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string SuppItemId
        {
            get
            {
                return this.suppItemIdField;
            }
            set
            {
                this.suppItemIdField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string SuppItemName
        {
            get
            {
                return this.suppItemNameField;
            }
            set
            {
                this.suppItemNameField = value;
            }
        }

        public decimal suppQty
        {
            get
            {
                return this.suppQtyField;
            }
            set
            {
                this.suppQtyField = value;
            }
        }

        [XmlIgnore]
        public bool suppQtySpecified
        {
            get
            {
                return this.suppQtyFieldSpecified;
            }
            set
            {
                this.suppQtyFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string SuppUnit
        {
            get
            {
                return this.suppUnitField;
            }
            set
            {
                this.suppUnitField = value;
            }
        }

        public DateTime ToDate
        {
            get
            {
                return this.toDateField;
            }
            set
            {
                this.toDateField = value;
            }
        }

        [XmlIgnore]
        public bool ToDateSpecified
        {
            get
            {
                return this.toDateFieldSpecified;
            }
            set
            {
                this.toDateFieldSpecified = value;
            }
        }

        public ApntAxHHTSuppItemsServiceContract()
        {
        }
    }
}