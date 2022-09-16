using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTUserLocationServiceContract : XppObjectBase
    {
        private string hHTRoleCodeField;

        private string hHTUserIdField;

        private string inventLocationIdField;

        [XmlElement(IsNullable = true)]
        public string HHTRoleCode
        {
            get
            {
                return this.hHTRoleCodeField;
            }
            set
            {
                this.hHTRoleCodeField = value;
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

        public ApntAxHHTUserLocationServiceContract()
        {
        }
    }
}