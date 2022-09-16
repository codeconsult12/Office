using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTCustomerServiceContract : XppObjectBase
    {
        private string custAccountField;

        private string custNameField;

        [XmlElement(IsNullable = true)]
        public string CustAccount
        {
            get
            {
                return this.custAccountField;
            }
            set
            {
                this.custAccountField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string CustName
        {
            get
            {
                return this.custNameField;
            }
            set
            {
                this.custNameField = value;
            }
        }

        public ApntAxHHTCustomerServiceContract()
        {
        }
    }
}