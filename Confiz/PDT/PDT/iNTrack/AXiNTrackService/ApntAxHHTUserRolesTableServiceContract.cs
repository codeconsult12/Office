using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTUserRolesTableServiceContract : XppObjectBase
    {
        private string hHTRoleCodeField;

        private string nameField;

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

        public ApntAxHHTUserRolesTableServiceContract()
        {
        }
    }
}