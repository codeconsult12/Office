using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTStockCountServiceContract : XppObjectBase
    {
        private string hHTBinCodeField;

        private NoYes hHTConfirmedField;

        private bool hHTConfirmedFieldSpecified;

        private string hHTNameField;

        private string hHTSerialNoField;

        private string hHTStockNoSeriesField;

        private string hHTUserIdField;

        private NoYes hHTValidItemField;

        private bool hHTValidItemFieldSpecified;

        private int integerField;

        private bool integerFieldSpecified;

        private string inventLocationIdField;

        private decimal inventQtyField;

        private bool inventQtyFieldSpecified;

        private string itemBarCodeField;

        private decimal lineNumField;

        private bool lineNumFieldSpecified;

        private NoYes noYesIdField;

        private bool noYesIdFieldSpecified;

        private string referenceNumberField;

        private DateTime transDateTimeField;

        private bool transDateTimeFieldSpecified;

        [XmlElement(IsNullable = true)]
        public string HHTBinCode
        {
            get
            {
                return this.hHTBinCodeField;
            }
            set
            {
                this.hHTBinCodeField = value;
            }
        }

        public NoYes HHTConfirmed
        {
            get
            {
                return this.hHTConfirmedField;
            }
            set
            {
                this.hHTConfirmedField = value;
            }
        }

        [XmlIgnore]
        public bool HHTConfirmedSpecified
        {
            get
            {
                return this.hHTConfirmedFieldSpecified;
            }
            set
            {
                this.hHTConfirmedFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTName
        {
            get
            {
                return this.hHTNameField;
            }
            set
            {
                this.hHTNameField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTSerialNo
        {
            get
            {
                return this.hHTSerialNoField;
            }
            set
            {
                this.hHTSerialNoField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTStockNoSeries
        {
            get
            {
                return this.hHTStockNoSeriesField;
            }
            set
            {
                this.hHTStockNoSeriesField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTUserId
        {
            get
            {
                return this.hHTUserIdField;
            }
            set
            {
                this.hHTUserIdField = value;
            }
        }

        public NoYes HHTValidItem
        {
            get
            {
                return this.hHTValidItemField;
            }
            set
            {
                this.hHTValidItemField = value;
            }
        }

        [XmlIgnore]
        public bool HHTValidItemSpecified
        {
            get
            {
                return this.hHTValidItemFieldSpecified;
            }
            set
            {
                this.hHTValidItemFieldSpecified = value;
            }
        }

        public int Integer
        {
            get
            {
                return this.integerField;
            }
            set
            {
                this.integerField = value;
            }
        }

        [XmlIgnore]
        public bool IntegerSpecified
        {
            get
            {
                return this.integerFieldSpecified;
            }
            set
            {
                this.integerFieldSpecified = value;
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

        public decimal LineNum
        {
            get
            {
                return this.lineNumField;
            }
            set
            {
                this.lineNumField = value;
            }
        }

        [XmlIgnore]
        public bool LineNumSpecified
        {
            get
            {
                return this.lineNumFieldSpecified;
            }
            set
            {
                this.lineNumFieldSpecified = value;
            }
        }

        public NoYes NoYesId
        {
            get
            {
                return this.noYesIdField;
            }
            set
            {
                this.noYesIdField = value;
            }
        }

        [XmlIgnore]
        public bool NoYesIdSpecified
        {
            get
            {
                return this.noYesIdFieldSpecified;
            }
            set
            {
                this.noYesIdFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string ReferenceNumber
        {
            get
            {
                return this.referenceNumberField;
            }
            set
            {
                this.referenceNumberField = value;
            }
        }

        public DateTime TransDateTime
        {
            get
            {
                return this.transDateTimeField;
            }
            set
            {
                this.transDateTimeField = value;
            }
        }

        [XmlIgnore]
        public bool TransDateTimeSpecified
        {
            get
            {
                return this.transDateTimeFieldSpecified;
            }
            set
            {
                this.transDateTimeFieldSpecified = value;
            }
        }

        public ApntAxHHTStockCountServiceContract()
        {
        }
    }
}