using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTPricecCheckerServiceContract : XppObjectBase
    {
        private string hHTDataFieldField;

        [XmlElement(IsNullable = true)]
        public string HHTDataField
        {
            get
            {
                return this.hHTDataFieldField;
            }
            set
            {
                this.hHTDataFieldField = value;
            }
        }

        public ApntAxHHTPricecCheckerServiceContract()
        {
        }
    }
}