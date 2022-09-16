using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTPORemaingQtyServiceContract : XppObjectBase
    {
        private decimal inventQtyField;

        private bool inventQtyFieldSpecified;

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

        public ApntAxHHTPORemaingQtyServiceContract()
        {
        }
    }
}