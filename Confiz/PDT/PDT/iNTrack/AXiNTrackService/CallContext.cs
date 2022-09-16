using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlRoot(Namespace = "http://schemas.microsoft.com/dynamics/2010/01/datacontracts", IsNullable = true)]
    [XmlType(Namespace = "http://schemas.microsoft.com/dynamics/2010/01/datacontracts")]
    public class CallContext : SoapHeader
    {
        private string companyField;

        private string languageField;

        private string logonAsUserField;

        private string messageIdField;

        private string partitionKeyField;

        private ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] propertyBagField;

        [XmlElement(IsNullable = true)]
        public string Company
        {
            get
            {
                return this.companyField;
            }
            set
            {
                this.companyField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string Language
        {
            get
            {
                return this.languageField;
            }
            set
            {
                this.languageField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string LogonAsUser
        {
            get
            {
                return this.logonAsUserField;
            }
            set
            {
                this.logonAsUserField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string MessageId
        {
            get
            {
                return this.messageIdField;
            }
            set
            {
                this.messageIdField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string PartitionKey
        {
            get
            {
                return this.partitionKeyField;
            }
            set
            {
                this.partitionKeyField = value;
            }
        }

        [XmlArray(IsNullable = true)]
        [XmlArrayItem("KeyValueOfstringstring", Namespace = "http://schemas.microsoft.com/2003/10/Serialization/Arrays", IsNullable = false)]
        public ArrayOfKeyValueOfstringstringKeyValueOfstringstring[] PropertyBag
        {
            get
            {
                return this.propertyBagField;
            }
            set
            {
                this.propertyBagField = value;
            }
        }

        public CallContext()
        {
        }
    }
}