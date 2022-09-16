using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTPurchTableServicesContract : XppObjectBase
    {
        private string addressingField;

        private string apntStoreAddressingField;

        private DateTime createdDateTimeField;

        private bool createdDateTimeFieldSpecified;

        private DateTime deliveryDateField;

        private bool deliveryDateFieldSpecified;

        private string inventLocationIdField;

        private string nameField;

        private string phoneField;

        private string phoneMobileField;

        private string purchIdField;

        private string vendAccountField;

        private string vendNameField;

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

        public DateTime DeliveryDate
        {
            get
            {
                return this.deliveryDateField;
            }
            set
            {
                this.deliveryDateField = value;
            }
        }

        [XmlIgnore]
        public bool DeliveryDateSpecified
        {
            get
            {
                return this.deliveryDateFieldSpecified;
            }
            set
            {
                this.deliveryDateFieldSpecified = value;
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
        public string PhoneMobile
        {
            get
            {
                return this.phoneMobileField;
            }
            set
            {
                this.phoneMobileField = value;
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

        [XmlElement(IsNullable = true)]
        public string VendAccount
        {
            get
            {
                return this.vendAccountField;
            }
            set
            {
                this.vendAccountField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string VendName
        {
            get
            {
                return this.vendNameField;
            }
            set
            {
                this.vendNameField = value;
            }
        }

        public ApntAxHHTPurchTableServicesContract()
        {
        }
    }
}