using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTDocSetupServiceContract : XppObjectBase
    {
        private HHTModule hHTModuleField;

        private bool hHTModuleFieldSpecified;

        private string inventLocationIdField;

        private NoYes negativeStockAllowedField;

        private bool negativeStockAllowedFieldSpecified;

        private NoYes showStockField;

        private bool showStockFieldSpecified;

        private NoYes backdatedDocAllowedField;

        private bool backdatedDocAllowedFieldSpecified;

        public NoYes backdatedDocAllowed
        {
            get
            {
                return this.backdatedDocAllowedField;
            }
            set
            {
                this.backdatedDocAllowedField = value;
            }
        }

        [XmlIgnore]
        public bool backdatedDocAllowedSpecified
        {
            get
            {
                return this.backdatedDocAllowedFieldSpecified;
            }
            set
            {
                this.backdatedDocAllowedFieldSpecified = value;
            }
        }

        public HHTModule HHTModule
        {
            get
            {
                return this.hHTModuleField;
            }
            set
            {
                this.hHTModuleField = value;
            }
        }

        [XmlIgnore]
        public bool HHTModuleSpecified
        {
            get
            {
                return this.hHTModuleFieldSpecified;
            }
            set
            {
                this.hHTModuleFieldSpecified = value;
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

        public NoYes NegativeStockAllowed
        {
            get
            {
                return this.negativeStockAllowedField;
            }
            set
            {
                this.negativeStockAllowedField = value;
            }
        }

        [XmlIgnore]
        public bool NegativeStockAllowedSpecified
        {
            get
            {
                return this.negativeStockAllowedFieldSpecified;
            }
            set
            {
                this.negativeStockAllowedFieldSpecified = value;
            }
        }

        public NoYes ShowStock
        {
            get
            {
                return this.showStockField;
            }
            set
            {
                this.showStockField = value;
            }
        }

        [XmlIgnore]
        public bool ShowStockSpecified
        {
            get
            {
                return this.showStockFieldSpecified;
            }
            set
            {
                this.showStockFieldSpecified = value;
            }
        }

        public ApntAxHHTDocSetupServiceContract()
        {
        }
    }
}