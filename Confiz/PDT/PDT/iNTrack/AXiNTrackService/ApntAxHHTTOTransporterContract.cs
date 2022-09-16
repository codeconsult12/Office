using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTTOTransporterContract : XppObjectBase
    {
        private string transportIdField;

        private string transporterNameField;

        [XmlElement(IsNullable = true)]
        public string TransporterName
        {
            get
            {
                return this.transporterNameField;
            }
            set
            {
                this.transporterNameField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string TransportId
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

        public ApntAxHHTTOTransporterContract()
        {
        }
    }
}