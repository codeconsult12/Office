using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTOnHandQtyServiceContract : XppObjectBase
    {
        private string inventLocationIdField;

        private decimal inventQtyField;

        private bool inventQtyFieldSpecified;

        private decimal totalItemsSoldField;

        private bool totalItemsSoldFieldSpecified;

        private decimal totalItemsSold30DaysField;

        private bool totalItemsSold30DaysFieldSpecified;

        private decimal totalItemsSold60DaysField;

        private bool totalItemsSold60DaysFieldSpecified;

        private decimal totalItemsSold90DaysField;

        private bool totalItemsSold90DaysFieldSpecified;

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

        public decimal TotalItemsSold
        {
            get
            {
                return this.totalItemsSoldField;
            }
            set
            {
                this.totalItemsSoldField = value;
            }
        }

        public decimal TotalItemsSold30Days
        {
            get
            {
                return this.totalItemsSold30DaysField;
            }
            set
            {
                this.totalItemsSold30DaysField = value;
            }
        }

        [XmlIgnore]
        public bool TotalItemsSold30DaysSpecified
        {
            get
            {
                return this.totalItemsSold30DaysFieldSpecified;
            }
            set
            {
                this.totalItemsSold30DaysFieldSpecified = value;
            }
        }

        public decimal TotalItemsSold60Days
        {
            get
            {
                return this.totalItemsSold60DaysField;
            }
            set
            {
                this.totalItemsSold60DaysField = value;
            }
        }

        [XmlIgnore]
        public bool TotalItemsSold60DaysSpecified
        {
            get
            {
                return this.totalItemsSold60DaysFieldSpecified;
            }
            set
            {
                this.totalItemsSold60DaysFieldSpecified = value;
            }
        }

        public decimal TotalItemsSold90Days
        {
            get
            {
                return this.totalItemsSold90DaysField;
            }
            set
            {
                this.totalItemsSold90DaysField = value;
            }
        }

        [XmlIgnore]
        public bool TotalItemsSold90DaysSpecified
        {
            get
            {
                return this.totalItemsSold90DaysFieldSpecified;
            }
            set
            {
                this.totalItemsSold90DaysFieldSpecified = value;
            }
        }

        [XmlIgnore]
        public bool TotalItemsSoldSpecified
        {
            get
            {
                return this.totalItemsSoldFieldSpecified;
            }
            set
            {
                this.totalItemsSoldFieldSpecified = value;
            }
        }

        public ApntAxHHTOnHandQtyServiceContract()
        {
        }
    }
}