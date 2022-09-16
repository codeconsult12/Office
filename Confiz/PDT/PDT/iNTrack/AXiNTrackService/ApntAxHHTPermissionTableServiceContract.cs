using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTPermissionTableServiceContract : XppObjectBase
    {
        private HHTModule hHTModuleField;

        private bool hHTModuleFieldSpecified;

        private string hHTRoleCodeField;

        public HHTModule HHTModule
        {
            get
            {
                return this.hHTModuleField;
            }
            set
            {
                this.hHTModuleField = value;
            }
        }

        [XmlIgnore]
        public bool HHTModuleSpecified
        {
            get
            {
                return this.hHTModuleFieldSpecified;
            }
            set
            {
                this.hHTModuleFieldSpecified = value;
            }
        }

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

        public ApntAxHHTPermissionTableServiceContract()
        {
        }
    }
}