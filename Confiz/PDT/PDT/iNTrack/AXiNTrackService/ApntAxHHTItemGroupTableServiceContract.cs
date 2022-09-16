using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTItemGroupTableServiceContract : XppObjectBase
    {
        private string itemGroupIdField;

        private string nameField;

        [XmlElement(IsNullable = true)]
        public string ItemGroupId
        {
            get
            {
                return this.itemGroupIdField;
            }
            set
            {
                this.itemGroupIdField = value;
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

        public ApntAxHHTItemGroupTableServiceContract()
        {
        }
    }
}