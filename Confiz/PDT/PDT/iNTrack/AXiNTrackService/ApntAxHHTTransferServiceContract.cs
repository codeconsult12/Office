using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTTransferServiceContract : XppObjectBase
    {
        private DateTime createdDateTimeField;

        private bool createdDateTimeFieldSpecified;

        private string driverNameField;

        private string fromLocationNameField;

        private string inventLocationIdFromField;

        private string inventLocationIdToField;

        private string inventTransferIdField;

        private InventTransferStatus inventTransferStatusField;

        private bool inventTransferStatusFieldSpecified;

        private DateTime receiveDateField;

        private bool receiveDateFieldSpecified;

        private DateTime shipDateField;

        private bool shipDateFieldSpecified;

        private string toLocationNameField;

        private string trackingIdField;

        private string truckNoField;

        private string transportIdField;

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

        public InventTransferStatus InventTransferStatus
        {
            get
            {
                return this.inventTransferStatusField;
            }
            set
            {
                this.inventTransferStatusField = value;
            }
        }

        [XmlIgnore]
        public bool InventTransferStatusSpecified
        {
            get
            {
                return this.inventTransferStatusFieldSpecified;
            }
            set
            {
                this.inventTransferStatusFieldSpecified = value;
            }
        }

        public DateTime ReceiveDate
        {
            get
            {
                return this.receiveDateField;
            }
            set
            {
                this.receiveDateField = value;
            }
        }

        [XmlIgnore]
        public bool ReceiveDateSpecified
        {
            get
            {
                return this.receiveDateFieldSpecified;
            }
            set
            {
                this.receiveDateFieldSpecified = value;
            }
        }

        public DateTime ShipDate
        {
            get
            {
                return this.shipDateField;
            }
            set
            {
                this.shipDateField = value;
            }
        }

        [XmlIgnore]
        public bool ShipDateSpecified
        {
            get
            {
                return this.shipDateFieldSpecified;
            }
            set
            {
                this.shipDateFieldSpecified = value;
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
        public string transportId
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

        public ApntAxHHTTransferServiceContract()
        {
        }
    }
}