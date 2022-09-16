using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [XmlType(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public class ApntAxHHTSetupTableServiceContract : XppObjectBase
    {
        private string apntVersionNoField;

        private string domainNameField;

        private string hHTDownloadPathField;

        private NoYes hHTDownloadPurchInvoiceLineField;

        private bool hHTDownloadPurchInvoiceLineFieldSpecified;

        private NoYes hHTDownloadPurchReturnLineField;

        private bool hHTDownloadPurchReturnLineFieldSpecified;

        private NoYes hHTDownloadSalesInvoiceLineField;

        private bool hHTDownloadSalesInvoiceLineFieldSpecified;

        private NoYes hHTDownloadSalesReturnLineField;

        private bool hHTDownloadSalesReturnLineFieldSpecified;

        private NoYes hHTDownloadTransferReceiptLineField;

        private bool hHTDownloadTransferReceiptLineFieldSpecified;

        private NoYes hHTDownloadTransferShipmentLineField;

        private bool hHTDownloadTransferShipmentLineFieldSpecified;

        private NoYes hHTPromptOnInvalidBarcodeDataField;

        private bool hHTPromptOnInvalidBarcodeDataFieldSpecified;

        private NoYes hHTPromptOnInvalidBarcodeScField;

        private bool hHTPromptOnInvalidBarcodeScFieldSpecified;

        private NoYes hHTShowPurchInvoiceLineField;

        private bool hHTShowPurchInvoiceLineFieldSpecified;

        private NoYes hHTShowPurchReturnLineField;

        private bool hHTShowPurchReturnLineFieldSpecified;

        private NoYes hHTShowSalesInvoiceLineField;

        private bool hHTShowSalesInvoiceLineFieldSpecified;

        private NoYes hHTShowSalesReturnLineField;

        private bool hHTShowSalesReturnLineFieldSpecified;

        private NoYes hHTShowTransferReceiptLineField;

        private bool hHTShowTransferReceiptLineFieldSpecified;

        private NoYes hHTShowTransferShipmentLineField;

        private bool hHTShowTransferShipmentLineFieldSpecified;

        private string hHTUpdatedPathField;

        private string hHTUploadPathField;

        private NoYes hHTboxNoMandatoryPurchaseField;

        private bool hHTboxNoMandatoryPurchaseFieldSpecified;

        private NoYes hHTboxNoMandatorySalesField;

        private bool hHTboxNoMandatorySalesFieldSpecified;

        private NoYes hHTboxNoMandatoryTransferField;

        private bool hHTboxNoMandatoryTransferFieldSpecified;

        private NoYes hHTcaptureReferenceNoField;

        private bool hHTcaptureReferenceNoFieldSpecified;

        private NoYes hHTcheckItemValidityStockField;

        private bool hHTcheckItemValidityStockFieldSpecified;

        private NoYes hHTcheckitemValidityDataField;

        private bool hHTcheckitemValidityDataFieldSpecified;

        private NoYes hHTlocationwisePricingField;

        private bool hHTlocationwisePricingFieldSpecified;

        private NoYes hHTmanualPurchOrderCreationField;

        private bool hHTmanualPurchOrderCreationFieldSpecified;

        private NoYes hHTmanualPurchReturnCreationField;

        private bool hHTmanualPurchReturnCreationFieldSpecified;

        private NoYes hHTmanualSalesOrderCreationField;

        private bool hHTmanualSalesOrderCreationFieldSpecified;

        private NoYes hHTmanualSalesReturnCreationField;

        private bool hHTmanualSalesReturnCreationFieldSpecified;

        private NoYes hHTmanualTransferRcptCreationField;

        private bool hHTmanualTransferRcptCreationFieldSpecified;

        private NoYes hHTmanualTransferShptCreationField;

        private bool hHTmanualTransferShptCreationFieldSpecified;

        private NoYes hHTpurchaseCrMemoImportField;

        private bool hHTpurchaseCrMemoImportFieldSpecified;

        private NoYes hHTpurchaseInvoiceImportField;

        private bool hHTpurchaseInvoiceImportFieldSpecified;

        private NoYes hHTpurchaseOrderImportField;

        private bool hHTpurchaseOrderImportFieldSpecified;

        private NoYes hHTpurchaseReturnImportField;

        private bool hHTpurchaseReturnImportFieldSpecified;

        private NoYes hHTsalesCrMemoImportField;

        private bool hHTsalesCrMemoImportFieldSpecified;

        private NoYes hHTsalesInvoiceImportField;

        private bool hHTsalesInvoiceImportFieldSpecified;

        private NoYes hHTsalesOrderImportField;

        private bool hHTsalesOrderImportFieldSpecified;

        private NoYes hHTsalesReturnImportField;

        private bool hHTsalesReturnImportFieldSpecified;

        private DateTime modifiedDateTimeField;

        private bool modifiedDateTimeFieldSpecified;

        private string passwordField;

        private string uRLField;

        private string userNameField;

        [XmlElement(IsNullable = true)]
        public string ApntVersionNo
        {
            get
            {
                return this.apntVersionNoField;
            }
            set
            {
                this.apntVersionNoField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string DomainName
        {
            get
            {
                return this.domainNameField;
            }
            set
            {
                this.domainNameField = value;
            }
        }

        public NoYes HHTboxNoMandatoryPurchase
        {
            get
            {
                return this.hHTboxNoMandatoryPurchaseField;
            }
            set
            {
                this.hHTboxNoMandatoryPurchaseField = value;
            }
        }

        [XmlIgnore]
        public bool HHTboxNoMandatoryPurchaseSpecified
        {
            get
            {
                return this.hHTboxNoMandatoryPurchaseFieldSpecified;
            }
            set
            {
                this.hHTboxNoMandatoryPurchaseFieldSpecified = value;
            }
        }

        public NoYes HHTboxNoMandatorySales
        {
            get
            {
                return this.hHTboxNoMandatorySalesField;
            }
            set
            {
                this.hHTboxNoMandatorySalesField = value;
            }
        }

        [XmlIgnore]
        public bool HHTboxNoMandatorySalesSpecified
        {
            get
            {
                return this.hHTboxNoMandatorySalesFieldSpecified;
            }
            set
            {
                this.hHTboxNoMandatorySalesFieldSpecified = value;
            }
        }

        public NoYes HHTboxNoMandatoryTransfer
        {
            get
            {
                return this.hHTboxNoMandatoryTransferField;
            }
            set
            {
                this.hHTboxNoMandatoryTransferField = value;
            }
        }

        [XmlIgnore]
        public bool HHTboxNoMandatoryTransferSpecified
        {
            get
            {
                return this.hHTboxNoMandatoryTransferFieldSpecified;
            }
            set
            {
                this.hHTboxNoMandatoryTransferFieldSpecified = value;
            }
        }

        public NoYes HHTcaptureReferenceNo
        {
            get
            {
                return this.hHTcaptureReferenceNoField;
            }
            set
            {
                this.hHTcaptureReferenceNoField = value;
            }
        }

        [XmlIgnore]
        public bool HHTcaptureReferenceNoSpecified
        {
            get
            {
                return this.hHTcaptureReferenceNoFieldSpecified;
            }
            set
            {
                this.hHTcaptureReferenceNoFieldSpecified = value;
            }
        }

        public NoYes HHTcheckitemValidityData
        {
            get
            {
                return this.hHTcheckitemValidityDataField;
            }
            set
            {
                this.hHTcheckitemValidityDataField = value;
            }
        }

        [XmlIgnore]
        public bool HHTcheckitemValidityDataSpecified
        {
            get
            {
                return this.hHTcheckitemValidityDataFieldSpecified;
            }
            set
            {
                this.hHTcheckitemValidityDataFieldSpecified = value;
            }
        }

        public NoYes HHTcheckItemValidityStock
        {
            get
            {
                return this.hHTcheckItemValidityStockField;
            }
            set
            {
                this.hHTcheckItemValidityStockField = value;
            }
        }

        [XmlIgnore]
        public bool HHTcheckItemValidityStockSpecified
        {
            get
            {
                return this.hHTcheckItemValidityStockFieldSpecified;
            }
            set
            {
                this.hHTcheckItemValidityStockFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTDownloadPath
        {
            get
            {
                return this.hHTDownloadPathField;
            }
            set
            {
                this.hHTDownloadPathField = value;
            }
        }

        public NoYes HHTDownloadPurchInvoiceLine
        {
            get
            {
                return this.hHTDownloadPurchInvoiceLineField;
            }
            set
            {
                this.hHTDownloadPurchInvoiceLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTDownloadPurchInvoiceLineSpecified
        {
            get
            {
                return this.hHTDownloadPurchInvoiceLineFieldSpecified;
            }
            set
            {
                this.hHTDownloadPurchInvoiceLineFieldSpecified = value;
            }
        }

        public NoYes HHTDownloadPurchReturnLine
        {
            get
            {
                return this.hHTDownloadPurchReturnLineField;
            }
            set
            {
                this.hHTDownloadPurchReturnLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTDownloadPurchReturnLineSpecified
        {
            get
            {
                return this.hHTDownloadPurchReturnLineFieldSpecified;
            }
            set
            {
                this.hHTDownloadPurchReturnLineFieldSpecified = value;
            }
        }

        public NoYes HHTDownloadSalesInvoiceLine
        {
            get
            {
                return this.hHTDownloadSalesInvoiceLineField;
            }
            set
            {
                this.hHTDownloadSalesInvoiceLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTDownloadSalesInvoiceLineSpecified
        {
            get
            {
                return this.hHTDownloadSalesInvoiceLineFieldSpecified;
            }
            set
            {
                this.hHTDownloadSalesInvoiceLineFieldSpecified = value;
            }
        }

        public NoYes HHTDownloadSalesReturnLine
        {
            get
            {
                return this.hHTDownloadSalesReturnLineField;
            }
            set
            {
                this.hHTDownloadSalesReturnLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTDownloadSalesReturnLineSpecified
        {
            get
            {
                return this.hHTDownloadSalesReturnLineFieldSpecified;
            }
            set
            {
                this.hHTDownloadSalesReturnLineFieldSpecified = value;
            }
        }

        public NoYes HHTDownloadTransferReceiptLine
        {
            get
            {
                return this.hHTDownloadTransferReceiptLineField;
            }
            set
            {
                this.hHTDownloadTransferReceiptLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTDownloadTransferReceiptLineSpecified
        {
            get
            {
                return this.hHTDownloadTransferReceiptLineFieldSpecified;
            }
            set
            {
                this.hHTDownloadTransferReceiptLineFieldSpecified = value;
            }
        }

        public NoYes HHTDownloadTransferShipmentLine
        {
            get
            {
                return this.hHTDownloadTransferShipmentLineField;
            }
            set
            {
                this.hHTDownloadTransferShipmentLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTDownloadTransferShipmentLineSpecified
        {
            get
            {
                return this.hHTDownloadTransferShipmentLineFieldSpecified;
            }
            set
            {
                this.hHTDownloadTransferShipmentLineFieldSpecified = value;
            }
        }

        public NoYes HHTlocationwisePricing
        {
            get
            {
                return this.hHTlocationwisePricingField;
            }
            set
            {
                this.hHTlocationwisePricingField = value;
            }
        }

        [XmlIgnore]
        public bool HHTlocationwisePricingSpecified
        {
            get
            {
                return this.hHTlocationwisePricingFieldSpecified;
            }
            set
            {
                this.hHTlocationwisePricingFieldSpecified = value;
            }
        }

        public NoYes HHTmanualPurchOrderCreation
        {
            get
            {
                return this.hHTmanualPurchOrderCreationField;
            }
            set
            {
                this.hHTmanualPurchOrderCreationField = value;
            }
        }

        [XmlIgnore]
        public bool HHTmanualPurchOrderCreationSpecified
        {
            get
            {
                return this.hHTmanualPurchOrderCreationFieldSpecified;
            }
            set
            {
                this.hHTmanualPurchOrderCreationFieldSpecified = value;
            }
        }

        public NoYes HHTmanualPurchReturnCreation
        {
            get
            {
                return this.hHTmanualPurchReturnCreationField;
            }
            set
            {
                this.hHTmanualPurchReturnCreationField = value;
            }
        }

        [XmlIgnore]
        public bool HHTmanualPurchReturnCreationSpecified
        {
            get
            {
                return this.hHTmanualPurchReturnCreationFieldSpecified;
            }
            set
            {
                this.hHTmanualPurchReturnCreationFieldSpecified = value;
            }
        }

        public NoYes HHTmanualSalesOrderCreation
        {
            get
            {
                return this.hHTmanualSalesOrderCreationField;
            }
            set
            {
                this.hHTmanualSalesOrderCreationField = value;
            }
        }

        [XmlIgnore]
        public bool HHTmanualSalesOrderCreationSpecified
        {
            get
            {
                return this.hHTmanualSalesOrderCreationFieldSpecified;
            }
            set
            {
                this.hHTmanualSalesOrderCreationFieldSpecified = value;
            }
        }

        public NoYes HHTmanualSalesReturnCreation
        {
            get
            {
                return this.hHTmanualSalesReturnCreationField;
            }
            set
            {
                this.hHTmanualSalesReturnCreationField = value;
            }
        }

        [XmlIgnore]
        public bool HHTmanualSalesReturnCreationSpecified
        {
            get
            {
                return this.hHTmanualSalesReturnCreationFieldSpecified;
            }
            set
            {
                this.hHTmanualSalesReturnCreationFieldSpecified = value;
            }
        }

        public NoYes HHTmanualTransferRcptCreation
        {
            get
            {
                return this.hHTmanualTransferRcptCreationField;
            }
            set
            {
                this.hHTmanualTransferRcptCreationField = value;
            }
        }

        [XmlIgnore]
        public bool HHTmanualTransferRcptCreationSpecified
        {
            get
            {
                return this.hHTmanualTransferRcptCreationFieldSpecified;
            }
            set
            {
                this.hHTmanualTransferRcptCreationFieldSpecified = value;
            }
        }

        public NoYes HHTmanualTransferShptCreation
        {
            get
            {
                return this.hHTmanualTransferShptCreationField;
            }
            set
            {
                this.hHTmanualTransferShptCreationField = value;
            }
        }

        [XmlIgnore]
        public bool HHTmanualTransferShptCreationSpecified
        {
            get
            {
                return this.hHTmanualTransferShptCreationFieldSpecified;
            }
            set
            {
                this.hHTmanualTransferShptCreationFieldSpecified = value;
            }
        }

        public NoYes HHTPromptOnInvalidBarcodeData
        {
            get
            {
                return this.hHTPromptOnInvalidBarcodeDataField;
            }
            set
            {
                this.hHTPromptOnInvalidBarcodeDataField = value;
            }
        }

        [XmlIgnore]
        public bool HHTPromptOnInvalidBarcodeDataSpecified
        {
            get
            {
                return this.hHTPromptOnInvalidBarcodeDataFieldSpecified;
            }
            set
            {
                this.hHTPromptOnInvalidBarcodeDataFieldSpecified = value;
            }
        }

        public NoYes HHTPromptOnInvalidBarcodeSc
        {
            get
            {
                return this.hHTPromptOnInvalidBarcodeScField;
            }
            set
            {
                this.hHTPromptOnInvalidBarcodeScField = value;
            }
        }

        [XmlIgnore]
        public bool HHTPromptOnInvalidBarcodeScSpecified
        {
            get
            {
                return this.hHTPromptOnInvalidBarcodeScFieldSpecified;
            }
            set
            {
                this.hHTPromptOnInvalidBarcodeScFieldSpecified = value;
            }
        }

        public NoYes HHTpurchaseCrMemoImport
        {
            get
            {
                return this.hHTpurchaseCrMemoImportField;
            }
            set
            {
                this.hHTpurchaseCrMemoImportField = value;
            }
        }

        [XmlIgnore]
        public bool HHTpurchaseCrMemoImportSpecified
        {
            get
            {
                return this.hHTpurchaseCrMemoImportFieldSpecified;
            }
            set
            {
                this.hHTpurchaseCrMemoImportFieldSpecified = value;
            }
        }

        public NoYes HHTpurchaseInvoiceImport
        {
            get
            {
                return this.hHTpurchaseInvoiceImportField;
            }
            set
            {
                this.hHTpurchaseInvoiceImportField = value;
            }
        }

        [XmlIgnore]
        public bool HHTpurchaseInvoiceImportSpecified
        {
            get
            {
                return this.hHTpurchaseInvoiceImportFieldSpecified;
            }
            set
            {
                this.hHTpurchaseInvoiceImportFieldSpecified = value;
            }
        }

        public NoYes HHTpurchaseOrderImport
        {
            get
            {
                return this.hHTpurchaseOrderImportField;
            }
            set
            {
                this.hHTpurchaseOrderImportField = value;
            }
        }

        [XmlIgnore]
        public bool HHTpurchaseOrderImportSpecified
        {
            get
            {
                return this.hHTpurchaseOrderImportFieldSpecified;
            }
            set
            {
                this.hHTpurchaseOrderImportFieldSpecified = value;
            }
        }

        public NoYes HHTpurchaseReturnImport
        {
            get
            {
                return this.hHTpurchaseReturnImportField;
            }
            set
            {
                this.hHTpurchaseReturnImportField = value;
            }
        }

        [XmlIgnore]
        public bool HHTpurchaseReturnImportSpecified
        {
            get
            {
                return this.hHTpurchaseReturnImportFieldSpecified;
            }
            set
            {
                this.hHTpurchaseReturnImportFieldSpecified = value;
            }
        }

        public NoYes HHTsalesCrMemoImport
        {
            get
            {
                return this.hHTsalesCrMemoImportField;
            }
            set
            {
                this.hHTsalesCrMemoImportField = value;
            }
        }

        [XmlIgnore]
        public bool HHTsalesCrMemoImportSpecified
        {
            get
            {
                return this.hHTsalesCrMemoImportFieldSpecified;
            }
            set
            {
                this.hHTsalesCrMemoImportFieldSpecified = value;
            }
        }

        public NoYes HHTsalesInvoiceImport
        {
            get
            {
                return this.hHTsalesInvoiceImportField;
            }
            set
            {
                this.hHTsalesInvoiceImportField = value;
            }
        }

        [XmlIgnore]
        public bool HHTsalesInvoiceImportSpecified
        {
            get
            {
                return this.hHTsalesInvoiceImportFieldSpecified;
            }
            set
            {
                this.hHTsalesInvoiceImportFieldSpecified = value;
            }
        }

        public NoYes HHTsalesOrderImport
        {
            get
            {
                return this.hHTsalesOrderImportField;
            }
            set
            {
                this.hHTsalesOrderImportField = value;
            }
        }

        [XmlIgnore]
        public bool HHTsalesOrderImportSpecified
        {
            get
            {
                return this.hHTsalesOrderImportFieldSpecified;
            }
            set
            {
                this.hHTsalesOrderImportFieldSpecified = value;
            }
        }

        public NoYes HHTsalesReturnImport
        {
            get
            {
                return this.hHTsalesReturnImportField;
            }
            set
            {
                this.hHTsalesReturnImportField = value;
            }
        }

        [XmlIgnore]
        public bool HHTsalesReturnImportSpecified
        {
            get
            {
                return this.hHTsalesReturnImportFieldSpecified;
            }
            set
            {
                this.hHTsalesReturnImportFieldSpecified = value;
            }
        }

        public NoYes HHTShowPurchInvoiceLine
        {
            get
            {
                return this.hHTShowPurchInvoiceLineField;
            }
            set
            {
                this.hHTShowPurchInvoiceLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTShowPurchInvoiceLineSpecified
        {
            get
            {
                return this.hHTShowPurchInvoiceLineFieldSpecified;
            }
            set
            {
                this.hHTShowPurchInvoiceLineFieldSpecified = value;
            }
        }

        public NoYes HHTShowPurchReturnLine
        {
            get
            {
                return this.hHTShowPurchReturnLineField;
            }
            set
            {
                this.hHTShowPurchReturnLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTShowPurchReturnLineSpecified
        {
            get
            {
                return this.hHTShowPurchReturnLineFieldSpecified;
            }
            set
            {
                this.hHTShowPurchReturnLineFieldSpecified = value;
            }
        }

        public NoYes HHTShowSalesInvoiceLine
        {
            get
            {
                return this.hHTShowSalesInvoiceLineField;
            }
            set
            {
                this.hHTShowSalesInvoiceLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTShowSalesInvoiceLineSpecified
        {
            get
            {
                return this.hHTShowSalesInvoiceLineFieldSpecified;
            }
            set
            {
                this.hHTShowSalesInvoiceLineFieldSpecified = value;
            }
        }

        public NoYes HHTShowSalesReturnLine
        {
            get
            {
                return this.hHTShowSalesReturnLineField;
            }
            set
            {
                this.hHTShowSalesReturnLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTShowSalesReturnLineSpecified
        {
            get
            {
                return this.hHTShowSalesReturnLineFieldSpecified;
            }
            set
            {
                this.hHTShowSalesReturnLineFieldSpecified = value;
            }
        }

        public NoYes HHTShowTransferReceiptLine
        {
            get
            {
                return this.hHTShowTransferReceiptLineField;
            }
            set
            {
                this.hHTShowTransferReceiptLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTShowTransferReceiptLineSpecified
        {
            get
            {
                return this.hHTShowTransferReceiptLineFieldSpecified;
            }
            set
            {
                this.hHTShowTransferReceiptLineFieldSpecified = value;
            }
        }

        public NoYes HHTShowTransferShipmentLine
        {
            get
            {
                return this.hHTShowTransferShipmentLineField;
            }
            set
            {
                this.hHTShowTransferShipmentLineField = value;
            }
        }

        [XmlIgnore]
        public bool HHTShowTransferShipmentLineSpecified
        {
            get
            {
                return this.hHTShowTransferShipmentLineFieldSpecified;
            }
            set
            {
                this.hHTShowTransferShipmentLineFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTUpdatedPath
        {
            get
            {
                return this.hHTUpdatedPathField;
            }
            set
            {
                this.hHTUpdatedPathField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string HHTUploadPath
        {
            get
            {
                return this.hHTUploadPathField;
            }
            set
            {
                this.hHTUploadPathField = value;
            }
        }

        public DateTime ModifiedDateTime
        {
            get
            {
                return this.modifiedDateTimeField;
            }
            set
            {
                this.modifiedDateTimeField = value;
            }
        }

        [XmlIgnore]
        public bool ModifiedDateTimeSpecified
        {
            get
            {
                return this.modifiedDateTimeFieldSpecified;
            }
            set
            {
                this.modifiedDateTimeFieldSpecified = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string Password
        {
            get
            {
                return this.passwordField;
            }
            set
            {
                this.passwordField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string URL
        {
            get
            {
                return this.uRLField;
            }
            set
            {
                this.uRLField = value;
            }
        }

        [XmlElement(IsNullable = true)]
        public string UserName
        {
            get
            {
                return this.userNameField;
            }
            set
            {
                this.userNameField = value;
            }
        }

        public ApntAxHHTSetupTableServiceContract()
        {
        }
    }
}