using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTInventTableServiceContract : XppObjectBase
    {
        private string itemGroupIdField;

        private string itemIdField;

        private string itemNameField;

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
        public string ItemId
        {
            get
            {
                return this.itemIdField;
            }
            set
            {
                this.itemIdField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string ItemName
        {
            get
            {
                return this.itemNameField;
            }
            set
            {
                this.itemNameField = value;
            }
        }

        public ApntAxHHTInventTableServiceContract()
        {
        }
    }
}