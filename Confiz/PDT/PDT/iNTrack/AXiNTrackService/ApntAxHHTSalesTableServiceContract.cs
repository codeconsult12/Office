using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTSalesTableServiceContract : XppObjectBase
    {
        private string addressingField;

        private string apntStoreAddressingField;

        private DateTime createdDateTimeField;

        private bool createdDateTimeFieldSpecified;

        private string custAccountField;

        private string custNameField;

        private string inventLocationIdField;

        private string nameField;

        private string phoneField;

        private string salesIdField;

        private DateTime shippingDateRequestedField;

        private bool shippingDateRequestedFieldSpecified;

        [XmlElement(IsNullable = true)]
        public string Addressing
        {
            get
            {
                return this.addressingField;
            }
            set
            {
                this.addressingField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string ApntStoreAddressing
        {
            get
            {
                return this.apntStoreAddressingField;
            }
            set
            {
                this.apntStoreAddressingField = value;
            }
        }

        public DateTime CreatedDateTime
        {
            get
            {
                return this.createdDateTimeField;
            }
            set
            {
                this.createdDateTimeField = value;
            }
        }

        [XmlIgnore]
        public bool CreatedDateTimeSpecified
        {
            get
            {
                return this.createdDateTimeFieldSpecified;
            }
            set
            {
                this.createdDateTimeFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string CustAccount
        {
            get
            {
                return this.custAccountField;
            }
            set
            {
                this.custAccountField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string CustName
        {
            get
            {
                return this.custNameField;
            }
            set
            {
                this.custNameField = value;
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
        public string Name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string Phone
        {
            get
            {
                return this.phoneField;
            }
            set
            {
                this.phoneField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string SalesId
        {
            get
            {
                return this.salesIdField;
            }
            set
            {
                this.salesIdField = value;
            }
        }

        public DateTime ShippingDateRequested
        {
            get
            {
                return this.shippingDateRequestedField;
            }
            set
            {
                this.shippingDateRequestedField = value;
            }
        }

        [XmlIgnore]
        public bool ShippingDateRequestedSpecified
        {
            get
            {
                return this.shippingDateRequestedFieldSpecified;
            }
            set
            {
                this.shippingDateRequestedFieldSpecified = value;
            }
        }

        public ApntAxHHTSalesTableServiceContract()
        {
        }
    }
}