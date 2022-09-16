using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTTransactionTableServiceContract : XppObjectBase
    {
        private string apntReasonCodeField;

        private string descriptionField;

        private decimal excessQtyField;

        private bool excessQtyFieldSpecified;

        private NoYes fOCField;

        private bool fOCFieldSpecified;

        private string fromLocationNameField;

        private HHTAccountType hHTAccountTypeField;

        private bool hHTAccountTypeFieldSpecified;

        private string hHTBoxNoField;

        private NoYes hHTConfirmedField;

        private bool hHTConfirmedFieldSpecified;

        private HHTEntryType hHTEntryTypeField;

        private bool hHTEntryTypeFieldSpecified;

        private string hHTNameField;

        private string hHTSerialNoField;

        private string hHTSourceNoField;

        private string hHTTransctionTypeField;

        private string hHTUserIdField;

        private string inventLocationIdField;

        private string inventLocationIdFromField;

        private string inventLocationIdToField;

        private decimal inventQtyField;

        private bool inventQtyFieldSpecified;

        private string itemBarCodeField;

        private string itemIdField;

        private decimal lineNumField;

        private bool lineNumFieldSpecified;

        private decimal netAmountField;

        private bool netAmountFieldSpecified;

        private decimal qtyField;

        private bool qtyFieldSpecified;

        private long refRecIdField;

        private bool refRecIdFieldSpecified;

        private string referenceNumberField;

        private decimal shorageQtyField;

        private bool shorageQtyFieldSpecified;

        private string sourceNameField;

        private string toLocationNameField;

        private string tradeInventTransIdField;

        private DateTime transDateTimeField;

        private bool transDateTimeFieldSpecified;

        private string transReferenceNumberField;

        private string transactionIDField;

        private string unitIDInventoryField;

        private decimal unitPriceField;

        private bool unitPriceFieldSpecified;

        [XmlElement(IsNullable = true)]
        public string ApntReasonCode
        {
            get
            {
                return this.apntReasonCodeField;
            }
            set
            {
                this.apntReasonCodeField = value;
            }
        }

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

        public decimal ExcessQty
        {
            get
            {
                return this.excessQtyField;
            }
            set
            {
                this.excessQtyField = value;
            }
        }

        [XmlIgnore]
        public bool ExcessQtySpecified
        {
            get
            {
                return this.excessQtyFieldSpecified;
            }
            set
            {
                this.excessQtyFieldSpecified = value;
            }
        }

        public NoYes FOC
        {
            get
            {
                return this.fOCField;
            }
            set
            {
                this.fOCField = value;
            }
        }

        [XmlIgnore]
        public bool FOCSpecified
        {
            get
            {
                return this.fOCFieldSpecified;
            }
            set
            {
                this.fOCFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string FromLocationName
        {
            get
            {
                return this.fromLocationNameField;
            }
            set
            {
                this.fromLocationNameField = value;
            }
        }

        public HHTAccountType HHTAccountType
        {
            get
            {
                return this.hHTAccountTypeField;
            }
            set
            {
                this.hHTAccountTypeField = value;
            }
        }

        [XmlIgnore]
        public bool HHTAccountTypeSpecified
        {
            get
            {
                return this.hHTAccountTypeFieldSpecified;
            }
            set
            {
                this.hHTAccountTypeFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTBoxNo
        {
            get
            {
                return this.hHTBoxNoField;
            }
            set
            {
                this.hHTBoxNoField = value;
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

        public HHTEntryType HHTEntryType
        {
            get
            {
                return this.hHTEntryTypeField;
            }
            set
            {
                this.hHTEntryTypeField = value;
            }
        }

        [XmlIgnore]
        public bool HHTEntryTypeSpecified
        {
            get
            {
                return this.hHTEntryTypeFieldSpecified;
            }
            set
            {
                this.hHTEntryTypeFieldSpecified = value;
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
        public string HHTSourceNo
        {
            get
            {
                return this.hHTSourceNoField;
            }
            set
            {
                this.hHTSourceNoField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTTransctionType
        {
            get
            {
                return this.hHTTransctionTypeField;
            }
            set
            {
                this.hHTTransctionTypeField = value;
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
        public string InventLocationIdFrom
        {
            get
            {
                return this.inventLocationIdFromField;
            }
            set
            {
                this.inventLocationIdFromField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string InventLocationIdTo
        {
            get
            {
                return this.inventLocationIdToField;
            }
            set
            {
                this.inventLocationIdToField = value;
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

        public decimal NetAmount
        {
            get
            {
                return this.netAmountField;
            }
            set
            {
                this.netAmountField = value;
            }
        }

        [XmlIgnore]
        public bool NetAmountSpecified
        {
            get
            {
                return this.netAmountFieldSpecified;
            }
            set
            {
                this.netAmountFieldSpecified = value;
            }
        }

        public decimal Qty
        {
            get
            {
                return this.qtyField;
            }
            set
            {
                this.qtyField = value;
            }
        }

        [XmlIgnore]
        public bool QtySpecified
        {
            get
            {
                return this.qtyFieldSpecified;
            }
            set
            {
                this.qtyFieldSpecified = value;
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

        public long RefRecId
        {
            get
            {
                return this.refRecIdField;
            }
            set
            {
                this.refRecIdField = value;
            }
        }

        [XmlIgnore]
        public bool RefRecIdSpecified
        {
            get
            {
                return this.refRecIdFieldSpecified;
            }
            set
            {
                this.refRecIdFieldSpecified = value;
            }
        }

        public decimal ShorageQty
        {
            get
            {
                return this.shorageQtyField;
            }
            set
            {
                this.shorageQtyField = value;
            }
        }

        [XmlIgnore]
        public bool ShorageQtySpecified
        {
            get
            {
                return this.shorageQtyFieldSpecified;
            }
            set
            {
                this.shorageQtyFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string SourceName
        {
            get
            {
                return this.sourceNameField;
            }
            set
            {
                this.sourceNameField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string ToLocationName
        {
            get
            {
                return this.toLocationNameField;
            }
            set
            {
                this.toLocationNameField = value;
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
        public string TransactionID
        {
            get
            {
                return this.transactionIDField;
            }
            set
            {
                this.transactionIDField = value;
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

        [XmlElement(IsNullable = true)]
        public string TransReferenceNumber
        {
            get
            {
                return this.transReferenceNumberField;
            }
            set
            {
                this.transReferenceNumberField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string UnitIDInventory
        {
            get
            {
                return this.unitIDInventoryField;
            }
            set
            {
                this.unitIDInventoryField = value;
            }
        }

        public decimal UnitPrice
        {
            get
            {
                return this.unitPriceField;
            }
            set
            {
                this.unitPriceField = value;
            }
        }

        [XmlIgnore]
        public bool UnitPriceSpecified
        {
            get
            {
                return this.unitPriceFieldSpecified;
            }
            set
            {
                this.unitPriceFieldSpecified = value;
            }
        }

        public ApntAxHHTTransactionTableServiceContract()
        {
        }
    }
}