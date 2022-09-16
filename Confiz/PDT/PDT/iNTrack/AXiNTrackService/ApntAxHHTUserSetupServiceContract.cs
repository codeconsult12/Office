using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTUserSetupServiceContract : XppObjectBase
    {
        private NoYes backdatedDocAllowedField;

        private bool backdatedDocAllowedFieldSpecified;

        private string hHTUserIdField;

        private string nameField;

        private string passwordField;

        private NoYes showCostPriceField;

        private bool showCostPriceFieldSpecified;

        private NoYes showStockField;

        private bool showStockFieldSpecified;

        public NoYes BackdatedDocAllowed
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
        public bool BackdatedDocAllowedSpecified
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
        public string Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        public NoYes ShowCostPrice
        {
            get
            {
                return this.showCostPriceField;
            }
            set
            {
                this.showCostPriceField = value;
            }
        }

        [XmlIgnore]
        public bool ShowCostPriceSpecified
        {
            get
            {
                return this.showCostPriceFieldSpecified;
            }
            set
            {
                this.showCostPriceFieldSpecified = value;
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

        public ApntAxHHTUserSetupServiceContract()
        {
        }
    }
}