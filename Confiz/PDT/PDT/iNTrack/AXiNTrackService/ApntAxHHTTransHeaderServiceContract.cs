using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTTransHeaderServiceContract : XppObjectBase
    {
        private DateTime documentDateField;

        private bool documentDateFieldSpecified;

        private string driverNameField;

        private DateTime exptectedDateField;

        private bool exptectedDateFieldSpecified;

        private string fromLocationNameField;

        private HHTAccountType hHTAccountTypeField;

        private bool hHTAccountTypeFieldSpecified;

        private NoYes hHTConfirmedField;

        private bool hHTConfirmedFieldSpecified;

        private HHTEntryType hHTEntryTypeField;

        private bool hHTEntryTypeFieldSpecified;

        private string hHTNameField;

        private string hHTSourceNameField;

        private string hHTSourceNoField;

        private string hHTTransctionTypeField;

        private string hHTUserIdField;

        private string inventLocationIdField;

        private string inventLocationIdFromField;

        private string inventLocationIdToField;

        private string invoiceIdField;

        private int noOfRecordsField;

        private bool noOfRecordsFieldSpecified;

        private NoYes noYesIdField;

        private bool noYesIdFieldSpecified;

        private string referenceNumberField;

        private string remarksField;

        private string toLocationNameField;

        private decimal totalQuantityField;

        private bool totalQuantityFieldSpecified;

        private string trackingIdField;

        private DateTime transDateTimeField;

        private bool transDateTimeFieldSpecified;

        private string transactionIDField;

        private string transportIdField;

        private string truckNoField;

        public DateTime DocumentDate
        {
            get
            {
                return this.documentDateField;
            }
            set
            {
                this.documentDateField = value;
            }
        }

        [XmlIgnore]
        public bool DocumentDateSpecified
        {
            get
            {
                return this.documentDateFieldSpecified;
            }
            set
            {
                this.documentDateFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string DriverName
        {
            get
            {
                return this.driverNameField;
            }
            set
            {
                this.driverNameField = value;
            }
        }

        public DateTime ExptectedDate
        {
            get
            {
                return this.exptectedDateField;
            }
            set
            {
                this.exptectedDateField = value;
            }
        }

        [XmlIgnore]
        public bool ExptectedDateSpecified
        {
            get
            {
                return this.exptectedDateFieldSpecified;
            }
            set
            {
                this.exptectedDateFieldSpecified = value;
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
        public string HHTSourceName
        {
            get
            {
                return this.hHTSourceNameField;
            }
            set
            {
                this.hHTSourceNameField = value;
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

        [XmlElement(IsNullable = true)]
        public string InvoiceId
        {
            get
            {
                return this.invoiceIdField;
            }
            set
            {
                this.invoiceIdField = value;
            }
        }

        public int NoOfRecords
        {
            get
            {
                return this.noOfRecordsField;
            }
            set
            {
                this.noOfRecordsField = value;
            }
        }

        [XmlIgnore]
        public bool NoOfRecordsSpecified
        {
            get
            {
                return this.noOfRecordsFieldSpecified;
            }
            set
            {
                this.noOfRecordsFieldSpecified = value;
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

        [XmlElement(IsNullable = true)]
        public string Remarks
        {
            get
            {
                return this.remarksField;
            }
            set
            {
                this.remarksField = value;
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

        public decimal TotalQuantity
        {
            get
            {
                return this.totalQuantityField;
            }
            set
            {
                this.totalQuantityField = value;
            }
        }

        [XmlIgnore]
        public bool TotalQuantitySpecified
        {
            get
            {
                return this.totalQuantityFieldSpecified;
            }
            set
            {
                this.totalQuantityFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string TrackingId
        {
            get
            {
                return this.trackingIdField;
            }
            set
            {
                this.trackingIdField = value;
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
        public string TransportId
        {
            get
            {
                return this.transportIdField;
            }
            set
            {
                this.transportIdField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string TruckNo
        {
            get
            {
                return this.truckNoField;
            }
            set
            {
                this.truckNoField = value;
            }
        }

        public ApntAxHHTTransHeaderServiceContract()
        {
        }
    }
}