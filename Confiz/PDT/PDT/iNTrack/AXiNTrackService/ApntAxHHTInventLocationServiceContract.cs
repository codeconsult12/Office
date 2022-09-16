using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTInventLocationServiceContract : XppObjectBase
    {
        private string inventLocationIdField;

        private string inventLocationNameField;

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
        public string InventLocationName
        {
            get
            {
                return this.inventLocationNameField;
            }
            set
            {
                this.inventLocationNameField = value;
            }
        }

        public ApntAxHHTInventLocationServiceContract()
        {
        }
    }
}