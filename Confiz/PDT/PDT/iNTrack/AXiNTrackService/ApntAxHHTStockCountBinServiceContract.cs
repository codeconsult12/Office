using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTStockCountBinServiceContract : XppObjectBase
    {
        private string hHTBinCodeField;

        private string hHTStockNoSeriesField;

        private string inventLocationIdField;

        private NoYes noYesIdField;

        private bool noYesIdFieldSpecified;

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

        public ApntAxHHTStockCountBinServiceContract()
        {
        }
    }
}