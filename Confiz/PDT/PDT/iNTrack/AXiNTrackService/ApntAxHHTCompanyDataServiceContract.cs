using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTCompanyDataServiceContract : XppObjectBase
    {
        private string currencyCodeField;

        private string dirPartyNameField;

        private string selectableDataAreaField;

        [XmlElement(IsNullable = true)]
        public string CurrencyCode
        {
            get
            {
                return this.currencyCodeField;
            }
            set
            {
                this.currencyCodeField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string DirPartyName
        {
            get
            {
                return this.dirPartyNameField;
            }
            set
            {
                this.dirPartyNameField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string SelectableDataArea
        {
            get
            {
                return this.selectableDataAreaField;
            }
            set
            {
                this.selectableDataAreaField = value;
            }
        }

        public ApntAxHHTCompanyDataServiceContract()
        {
        }
    }
}