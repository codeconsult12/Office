using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTModuleMappingServiceContract : XppObjectBase
    {
        private string descriptionField;

        private string hHTTransctionTypeField;

        [XmlElement(IsNullable = true)]
        public string Description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTTransctionType
        {
            get
            {
                return this.hHTTransctionTypeField;
            }
            set
            {
                this.hHTTransctionTypeField = value;
            }
        }

        public ApntAxHHTModuleMappingServiceContract()
        {
        }
    }
}