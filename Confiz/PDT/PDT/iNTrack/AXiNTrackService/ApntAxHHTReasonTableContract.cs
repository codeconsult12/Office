using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTReasonTableContract : XppObjectBase
    {
        private ApntADJType apntADJTypeField;

        private bool apntADJTypeFieldSpecified;

        private string apntReasonCodeField;

        private string descriptionField;

        public ApntADJType ApntADJType
        {
            get
            {
                return this.apntADJTypeField;
            }
            set
            {
                this.apntADJTypeField = value;
            }
        }

        [XmlIgnore]
        public bool ApntADJTypeSpecified
        {
            get
            {
                return this.apntADJTypeFieldSpecified;
            }
            set
            {
                this.apntADJTypeFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string ApntReasonCode
        {
            get
            {
                return this.apntReasonCodeField;
            }
            set
            {
                this.apntReasonCodeField = value;
            }
        }

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

        public ApntAxHHTReasonTableContract()
        {
        }
    }
}