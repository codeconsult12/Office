using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTCustVendServiceContract : XppObjectBase
    {
        private int deadLineDaysField;

        private bool deadLineDaysFieldSpecified;

        private string vendAccountField;

        private string vendNameField;

        public int DeadLineDays
        {
            get
            {
                return this.deadLineDaysField;
            }
            set
            {
                this.deadLineDaysField = value;
            }
        }

        [XmlIgnore]
        public bool DeadLineDaysSpecified
        {
            get
            {
                return this.deadLineDaysFieldSpecified;
            }
            set
            {
                this.deadLineDaysFieldSpecified = value;
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

        public ApntAxHHTCustVendServiceContract()
        {
        }
    }
}