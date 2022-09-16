using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTRegisterTableServiceContract : XppObjectBase
    {
        private string hHTMAcAddressField;

        private string hHTNameField;

        [XmlElement(IsNullable = true)]
        public string HHTMAcAddress
        {
            get
            {
                return this.hHTMAcAddressField;
            }
            set
            {
                this.hHTMAcAddressField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTName
        {
            get
            {
                return this.hHTNameField;
            }
            set
            {
                this.hHTNameField = value;
            }
        }

        public ApntAxHHTRegisterTableServiceContract()
        {
        }
    }
}