using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Serialization;

namespace iNTrack.AXiNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [WebServiceBinding(Name = "BasicHttpBinding_AXiNTrack", Namespace = "http://tempuri.org/")]
    [XmlInclude(typeof(XppObjectBase))]
    public class BasicHttpBinding_AXiNTrack : SoapHttpClientProtocol
    {
        private CallContext callContextValueField;

        public CallContext CallContextValue
        {
            get
            {
                return this.callContextValueField;
            }
            set
            {
                this.callContextValueField = value;
            }
        }

        public BasicHttpBinding_AXiNTrack()
        {
            base.Url = "http://entsvr:1111/MicrosoftDynamicsAXAif60/iNTrackAX/xppservice.svc";
        }

        public IAsyncResult BeginconfirmHHTTransactions(string _dataAreaId, string _transactionNo, string _transactionType, string _userId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId };
            return base.BeginInvoke("confirmHHTTransactions", objArray, callback, asyncState);
        }

        public IAsyncResult BegincreateHHTStockCount(ApntAxHHTStockCountServiceContract[] _hhtStockCountList, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _hhtStockCountList };
            return base.BeginInvoke("createHHTStockCount", objArray, callback, asyncState);
        }

        public IAsyncResult BegincreateHHTTransaction(ApntAxHHTTransactionTableServiceContract[] _hhtTransactionList, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _hhtTransactionList };
            return base.BeginInvoke("createHHTTransaction", objArray, callback, asyncState);
        }

        public IAsyncResult BegincreateHHTTransactionHeader(ApntAxHHTTransHeaderServiceContract[] _hhtTransactionHeaderList, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _hhtTransactionHeaderList };
            return base.BeginInvoke("createHHTTransactionHeader", objArray, callback, asyncState);
        }

        public IAsyncResult BegincretaeHHTRegisterTable(ApntAxHHTRegisterTableServiceContract[] _hhtRegisterList, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _hhtRegisterList };
            return base.BeginInvoke("cretaeHHTRegisterTable", objArray, callback, asyncState);
        }

        public IAsyncResult BegindeleteHHTTransaction(string _dataAreaId, string _transactionNo, string _transactionType, string _userId, decimal _lineNo, bool _lineNoSpecified, string _boxNo, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId, _lineNo, _lineNoSpecified, _boxNo };
            return base.BeginInvoke("deleteHHTTransaction", objArray, callback, asyncState);
        }

        public IAsyncResult BegindeleteHHTTransactionHeader(string _dataAreaId, string _transactionNo, string _transactionType, string _userId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId };
            return base.BeginInvoke("deleteHHTTransactionHeader", objArray, callback, asyncState);
        }

        public IAsyncResult BegindeleteHHTTransactions(string _dataAreaId, string _transactionNo, string _transactionType, string _userId, string _boxNo, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId, _boxNo };
            return base.BeginInvoke("deleteHHTTransactions", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetCustTable(string _datAreaId, string _custAccount, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _datAreaId, _custAccount };
            return base.BeginInvoke("getCustTable", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetDataArea(bool ret, bool retSpecified, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { ret, retSpecified };
            return base.BeginInvoke("getDataArea", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTBarcodeByBarcode(string _datAreaId, string _location, string _barcode, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _datAreaId, _location, _barcode };
            return base.BeginInvoke("getHHTBarcodeByBarcode", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTBarcodeByDescription(string _datAreaId, string _location, string _itemId, int _excatMatch, bool _excatMatchSpecified, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _datAreaId, _location, _itemId, _excatMatch, _excatMatchSpecified };
            return base.BeginInvoke("getHHTBarcodeByDescription", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTBarcodeByItemId(string _datAreaId, string _location, string _itemId, int _excatMatch, bool _excatMatchSpecified, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _datAreaId, _location, _itemId, _excatMatch, _excatMatchSpecified };
            return base.BeginInvoke("getHHTBarcodeByItemId", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTBarcodeTable(string _datAreaId, string _location, DateTime _lastModifiedOn, bool _lastModifiedOnSpecified, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _datAreaId, _location, _lastModifiedOn, _lastModifiedOnSpecified };
            return base.BeginInvoke("getHHTBarcodeTable", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTDocSetup(string _dataAreaId, string _inventLocationId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _inventLocationId };
            return base.BeginInvoke("getHHTDocSetup", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTPermission(string _dataAreaId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId };
            return base.BeginInvoke("getHHTPermission", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTPermissionByUserId(string _dataAreaId, string _userId, string _locationId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _userId, _locationId };
            return base.BeginInvoke("getHHTPermissionByUserId", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTPORemainingQty(string _dataAreaId, string _purchId, string _itemBarCode, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _purchId, _itemBarCode };
            return base.BeginInvoke("getHHTPORemainingQty", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTReason(string _dataAreaId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId };
            return base.BeginInvoke("getHHTReason", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTRegisterMacAddress(string _dataAreaId, string _hhtMAcAddress, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _hhtMAcAddress };
            return base.BeginInvoke("getHHTRegisterMacAddress", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTRegisterTable(string _dataAreaId, string _hhtName, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _hhtName };
            return base.BeginInvoke("getHHTRegisterTable", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTSetupTable(string _dataAreaId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId };
            return base.BeginInvoke("getHHTSetupTable", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTStockCountBin(string _dataAreaId, string _locationcode, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _locationcode };
            return base.BeginInvoke("getHHTStockCountBin", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTSuppItem(string _dataAreaId, string _vendaccount, string _itemId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _vendaccount, _itemId };
            return base.BeginInvoke("getHHTSuppItem", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTTransactionHeader(string _dataAreaId, string _transactionType, string _userId, string _inventLocationId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionType, _userId, _inventLocationId };
            return base.BeginInvoke("getHHTTransactionHeader", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTTransactions(string _dataAreaId, string _transactionNo, string _transactionType, string _userId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId };
            return base.BeginInvoke("getHHTTransactions", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTUserLocation(string _dataAreaId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId };
            return base.BeginInvoke("getHHTUserLocation", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTUserRolesTable(string _dataAreaId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId };
            return base.BeginInvoke("getHHTUserRolesTable", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTUserSetup(string _dataAreaId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId };
            return base.BeginInvoke("getHHTUserSetup", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTUserSetUpByUserId(string _dataAreaId, string _userId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _userId };
            return base.BeginInvoke("getHHTUserSetUpByUserId", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTVendorLatestPrice(string _dataAreaId, string vendaccount, string _itemBarCode, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, vendaccount, _itemBarCode };
            return base.BeginInvoke("getHHTVendorLatestPrice", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetHHTVendorWithLatestPrice(string _dataAreaId, string _itemBarCode, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _itemBarCode };
            return base.BeginInvoke("getHHTVendorWithLatestPrice", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetInventLocation(string _dataAreaId, string _inventLocationId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _inventLocationId };
            return base.BeginInvoke("getInventLocation", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetInventTable(string _dataAreaId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId };
            return base.BeginInvoke("getInventTable", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetItemGroupTable(string _dataAreaId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId };
            return base.BeginInvoke("getItemGroupTable", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetModuleMapping(string _dataAreaId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId };
            return base.BeginInvoke("getModuleMapping", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetOnHandLocationWise(string _dataAreaId, string itemId, string variantId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, itemId, variantId };
            return base.BeginInvoke("getOnHandLocationWise", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetOnHandLocationWiseItemSold(string _dataAreaId, string itemId, string variantId, int noOfDays, bool noOfDaysSpecified, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, itemId, variantId, noOfDays, noOfDaysSpecified };
            return base.BeginInvoke("getOnHandLocationWiseItemSold", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetOnHandQty(string _dataAreaId, string itemId, string store, string variantId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, itemId, store, variantId };
            return base.BeginInvoke("getOnHandQty", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetOnHandQtyItemSold(string _dataAreaId, string itemId, string store, string variantId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, itemId, store, variantId };
            return base.BeginInvoke("getOnHandQtyItemSold", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetOnLinePrice(string _dataAreaId, string inventLocationId, string itemBarCode, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, inventLocationId, itemBarCode };
            return base.BeginInvoke("getOnLinePrice", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetPurchInvoiceHeader(string _dataAreaId, string _location, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return base.BeginInvoke("getPurchInvoiceHeader", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetPurchLine(string _dataAreaId, string _purchId, string inventLocationId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _purchId, inventLocationId };
            return base.BeginInvoke("getPurchLine", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetPurchReturnHeader(string _dataAreaId, string _location, int _toBeShipped, bool _toBeShippedSpecified, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _location, _toBeShipped, _toBeShippedSpecified };
            return base.BeginInvoke("getPurchReturnHeader", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetPurchReturnLine(string _dataAreaId, string _purchId, string inventLocationId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _purchId, inventLocationId };
            return base.BeginInvoke("getPurchReturnLine", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetPurchTable(string _dataAreaId, string _location, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return base.BeginInvoke("getPurchTable", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetSalesInvoiceHeader(string _dataAreaId, string _location, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return base.BeginInvoke("getSalesInvoiceHeader", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetSalesLine(string _dataAreaId, string _salesId, string _inventLocationId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _salesId, _inventLocationId };
            return base.BeginInvoke("getSalesLine", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetSalesReturnHeader(string _dataAreaId, string _location, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return base.BeginInvoke("getSalesReturnHeader", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetSalesReturnLine(string _dataAreaId, string _salesId, string _inventLocationId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _salesId, _inventLocationId };
            return base.BeginInvoke("getSalesReturnLine", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetSalesReturnReceiptHeader(string _dataAreaId, string _location, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return base.BeginInvoke("getSalesReturnReceiptHeader", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetSalesTable(string _dataAreaId, string _location, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return base.BeginInvoke("getSalesTable", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetTOTransporter(string _dataAreaId, string _transportId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _transportId };
            return base.BeginInvoke("getTOTransporter", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetTransferHeader(string _dataAreaId, InventTransferStatus _status, bool _statusSpecified, string _inventLocationId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _status, _statusSpecified, _inventLocationId };
            return base.BeginInvoke("getTransferHeader", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetTransferLine(string _dataAreaId, string _inventTransId, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _inventTransId };
            return base.BeginInvoke("getTransferLine", objArray, callback, asyncState);
        }

        public IAsyncResult BegingetVendTable(string _dataAreaId, string _vendAccount, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _vendAccount };
            return base.BeginInvoke("getVendTable", objArray, callback, asyncState);
        }

        public IAsyncResult BeginupdateHHTTransactionHeader(string _dataAreaId, string _transactionNo, string _transactionType, string _userId, string _remarks, DateTime _documentDate, bool _documentDateSpecified, DateTime _expectedDate, bool _expectedDateSpecified, string _trackingId, string _transportId, string _truckNo, string _driverName, string _invoiceNo, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId, _remarks, _documentDate, _documentDateSpecified, _expectedDate, _expectedDateSpecified, _trackingId, _transportId, _truckNo, _driverName, _invoiceNo };
            return base.BeginInvoke("updateHHTTransactionHeader", objArray, callback, asyncState);
        }

        public IAsyncResult BeginupdateRegister(ApntAxHHTRegisterTableServiceContract[] _hhtUpdateList, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _hhtUpdateList };
            return base.BeginInvoke("updateRegister", objArray, callback, asyncState);
        }

        public IAsyncResult BeginupdateStockCountBin(ApntAxHHTStockCountBinServiceContract[] _hhtUpdateStockCountBinList, AsyncCallback callback, object asyncState)
        {
            object[] objArray = new object[] { _hhtUpdateStockCountBinList };
            return base.BeginInvoke("updateStockCountBin", objArray, callback, asyncState);
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/confirmHHTTransactions", RequestElementName = "AXiNTrackConfirmHHTTransactionsRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackConfirmHHTTransactionsResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void confirmHHTTransactions([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _transactionNo, [XmlElement(IsNullable = true)] string _transactionType, [XmlElement(IsNullable = true)] string _userId, out bool response, [XmlIgnore] out bool responseSpecified)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId };
            object[] objArray1 = base.Invoke("confirmHHTTransactions", objArray);
            response = (bool)objArray1[0];
            responseSpecified = (bool)objArray1[1];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/createHHTStockCount", RequestElementName = "AXiNTrackCreateHHTStockCountRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackCreateHHTStockCountResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void createHHTStockCount([XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")][XmlArray(IsNullable = true)] ApntAxHHTStockCountServiceContract[] _hhtStockCountList)
        {
            object[] objArray = new object[] { _hhtStockCountList };
            base.Invoke("createHHTStockCount", objArray);
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/createHHTTransaction", RequestElementName = "AXiNTrackCreateHHTTransactionRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackCreateHHTTransactionResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void createHHTTransaction([XmlArray(IsNullable = true)][XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")] ApntAxHHTTransactionTableServiceContract[] _hhtTransactionList)
        {
            object[] objArray = new object[] { _hhtTransactionList };
            base.Invoke("createHHTTransaction", objArray);
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/createHHTTransactionHeader", RequestElementName = "AXiNTrackCreateHHTTransactionHeaderRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackCreateHHTTransactionHeaderResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void createHHTTransactionHeader([XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")][XmlArray(IsNullable = true)] ApntAxHHTTransHeaderServiceContract[] _hhtTransactionHeaderList)
        {
            object[] objArray = new object[] { _hhtTransactionHeaderList };
            base.Invoke("createHHTTransactionHeader", objArray);
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/cretaeHHTRegisterTable", RequestElementName = "AXiNTrackCretaeHHTRegisterTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackCretaeHHTRegisterTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void cretaeHHTRegisterTable([XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")][XmlArray(IsNullable = true)] ApntAxHHTRegisterTableServiceContract[] _hhtRegisterList)
        {
            object[] objArray = new object[] { _hhtRegisterList };
            base.Invoke("cretaeHHTRegisterTable", objArray);
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/deleteHHTTransaction", RequestElementName = "AXiNTrackDeleteHHTTransactionRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackDeleteHHTTransactionResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void deleteHHTTransaction([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _transactionNo, [XmlElement(IsNullable = true)] string _transactionType, [XmlElement(IsNullable = true)] string _userId, decimal _lineNo, [XmlIgnore] bool _lineNoSpecified, [XmlElement(IsNullable = true)] string _boxNo, out bool response, [XmlIgnore] out bool responseSpecified)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId, _lineNo, _lineNoSpecified, _boxNo };
            object[] objArray1 = base.Invoke("deleteHHTTransaction", objArray);
            response = (bool)objArray1[0];
            responseSpecified = (bool)objArray1[1];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/deleteHHTTransactionHeader", RequestElementName = "AXiNTrackDeleteHHTTransactionHeaderRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackDeleteHHTTransactionHeaderResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void deleteHHTTransactionHeader([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _transactionNo, [XmlElement(IsNullable = true)] string _transactionType, [XmlElement(IsNullable = true)] string _userId, out bool response, [XmlIgnore] out bool responseSpecified)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId };
            object[] objArray1 = base.Invoke("deleteHHTTransactionHeader", objArray);
            response = (bool)objArray1[0];
            responseSpecified = (bool)objArray1[1];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/deleteHHTTransactions", RequestElementName = "AXiNTrackDeleteHHTTransactionsRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackDeleteHHTTransactionsResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void deleteHHTTransactions([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _transactionNo, [XmlElement(IsNullable = true)] string _transactionType, [XmlElement(IsNullable = true)] string _userId, [XmlElement(IsNullable = true)] string _boxNo, out bool response, [XmlIgnore] out bool responseSpecified)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId, _boxNo };
            object[] objArray1 = base.Invoke("deleteHHTTransactions", objArray);
            response = (bool)objArray1[0];
            responseSpecified = (bool)objArray1[1];
        }

        public void EndconfirmHHTTransactions(IAsyncResult asyncResult, out bool response, out bool responseSpecified)
        {
            object[] objArray = base.EndInvoke(asyncResult);
            response = (bool)objArray[0];
            responseSpecified = (bool)objArray[1];
        }

        public void EndcreateHHTStockCount(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndcreateHHTTransaction(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndcreateHHTTransactionHeader(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndcretaeHHTRegisterTable(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EnddeleteHHTTransaction(IAsyncResult asyncResult, out bool response, out bool responseSpecified)
        {
            object[] objArray = base.EndInvoke(asyncResult);
            response = (bool)objArray[0];
            responseSpecified = (bool)objArray[1];
        }

        public void EnddeleteHHTTransactionHeader(IAsyncResult asyncResult, out bool response, out bool responseSpecified)
        {
            object[] objArray = base.EndInvoke(asyncResult);
            response = (bool)objArray[0];
            responseSpecified = (bool)objArray[1];
        }

        public void EnddeleteHHTTransactions(IAsyncResult asyncResult, out bool response, out bool responseSpecified)
        {
            object[] objArray = base.EndInvoke(asyncResult);
            response = (bool)objArray[0];
            responseSpecified = (bool)objArray[1];
        }

        public ApntAxHHTCustomerServiceContract[] EndgetCustTable(IAsyncResult asyncResult)
        {
            return (ApntAxHHTCustomerServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTCompanyDataServiceContract[] EndgetDataArea(IAsyncResult asyncResult)
        {
            return (ApntAxHHTCompanyDataServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTBarcodeTableServiceContract[] EndgetHHTBarcodeByBarcode(IAsyncResult asyncResult)
        {
            return (ApntAxHHTBarcodeTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTBarcodeTableServiceContract[] EndgetHHTBarcodeByDescription(IAsyncResult asyncResult)
        {
            return (ApntAxHHTBarcodeTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTBarcodeTableServiceContract[] EndgetHHTBarcodeByItemId(IAsyncResult asyncResult)
        {
            return (ApntAxHHTBarcodeTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTBarcodeTableServiceContract[] EndgetHHTBarcodeTable(IAsyncResult asyncResult)
        {
            return (ApntAxHHTBarcodeTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTDocSetupServiceContract[] EndgetHHTDocSetup(IAsyncResult asyncResult)
        {
            return (ApntAxHHTDocSetupServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPermissionTableServiceContract[] EndgetHHTPermission(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPermissionTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPermissionTableServiceContract[] EndgetHHTPermissionByUserId(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPermissionTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPORemaingQtyServiceContract[] EndgetHHTPORemainingQty(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPORemaingQtyServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTReasonTableContract[] EndgetHHTReason(IAsyncResult asyncResult)
        {
            return (ApntAxHHTReasonTableContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTRegisterTableServiceContract[] EndgetHHTRegisterMacAddress(IAsyncResult asyncResult)
        {
            return (ApntAxHHTRegisterTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTRegisterTableServiceContract[] EndgetHHTRegisterTable(IAsyncResult asyncResult)
        {
            return (ApntAxHHTRegisterTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTSetupTableServiceContract[] EndgetHHTSetupTable(IAsyncResult asyncResult)
        {
            return (ApntAxHHTSetupTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTStockCountBinServiceContract[] EndgetHHTStockCountBin(IAsyncResult asyncResult)
        {
            return (ApntAxHHTStockCountBinServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTSuppItemsServiceContract[] EndgetHHTSuppItem(IAsyncResult asyncResult)
        {
            return (ApntAxHHTSuppItemsServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTTransHeaderServiceContract[] EndgetHHTTransactionHeader(IAsyncResult asyncResult)
        {
            return (ApntAxHHTTransHeaderServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTTransactionTableServiceContract[] EndgetHHTTransactions(IAsyncResult asyncResult)
        {
            return (ApntAxHHTTransactionTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTUserLocationServiceContract[] EndgetHHTUserLocation(IAsyncResult asyncResult)
        {
            return (ApntAxHHTUserLocationServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTUserRolesTableServiceContract[] EndgetHHTUserRolesTable(IAsyncResult asyncResult)
        {
            return (ApntAxHHTUserRolesTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTUserSetupServiceContract[] EndgetHHTUserSetup(IAsyncResult asyncResult)
        {
            return (ApntAxHHTUserSetupServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTUserSetupServiceContract[] EndgetHHTUserSetUpByUserId(IAsyncResult asyncResult)
        {
            return (ApntAxHHTUserSetupServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPORemaingQtyServiceContract[] EndgetHHTVendorLatestPrice(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPORemaingQtyServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPORemaingQtyServiceContract[] EndgetHHTVendorWithLatestPrice(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPORemaingQtyServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTInventLocationServiceContract[] EndgetInventLocation(IAsyncResult asyncResult)
        {
            return (ApntAxHHTInventLocationServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTInventTableServiceContract[] EndgetInventTable(IAsyncResult asyncResult)
        {
            return (ApntAxHHTInventTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTItemGroupTableServiceContract[] EndgetItemGroupTable(IAsyncResult asyncResult)
        {
            return (ApntAxHHTItemGroupTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTModuleMappingServiceContract[] EndgetModuleMapping(IAsyncResult asyncResult)
        {
            return (ApntAxHHTModuleMappingServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTOnHandQtyServiceContract[] EndgetOnHandLocationWise(IAsyncResult asyncResult)
        {
            return (ApntAxHHTOnHandQtyServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTOnHandQtyServiceContract[] EndgetOnHandLocationWiseItemSold(IAsyncResult asyncResult)
        {
            return (ApntAxHHTOnHandQtyServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTOnHandQtyServiceContract[] EndgetOnHandQty(IAsyncResult asyncResult)
        {
            return (ApntAxHHTOnHandQtyServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTOnHandQtyServiceContract[] EndgetOnHandQtyItemSold(IAsyncResult asyncResult)
        {
            return (ApntAxHHTOnHandQtyServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPricecCheckerServiceContract[] EndgetOnLinePrice(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPricecCheckerServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPurchTableServicesContract[] EndgetPurchInvoiceHeader(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPurchTableServicesContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPurchLineServiceContract[] EndgetPurchLine(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPurchLineServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPurchTableServicesContract[] EndgetPurchReturnHeader(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPurchTableServicesContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPurchLineServiceContract[] EndgetPurchReturnLine(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPurchLineServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTPurchTableServicesContract[] EndgetPurchTable(IAsyncResult asyncResult)
        {
            return (ApntAxHHTPurchTableServicesContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTSalesTableServiceContract[] EndgetSalesInvoiceHeader(IAsyncResult asyncResult)
        {
            return (ApntAxHHTSalesTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTSalesLineServiceContract[] EndgetSalesLine(IAsyncResult asyncResult)
        {
            return (ApntAxHHTSalesLineServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTSalesTableServiceContract[] EndgetSalesReturnHeader(IAsyncResult asyncResult)
        {
            return (ApntAxHHTSalesTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTSalesLineServiceContract[] EndgetSalesReturnLine(IAsyncResult asyncResult)
        {
            return (ApntAxHHTSalesLineServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTSalesTableServiceContract[] EndgetSalesReturnReceiptHeader(IAsyncResult asyncResult)
        {
            return (ApntAxHHTSalesTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTSalesTableServiceContract[] EndgetSalesTable(IAsyncResult asyncResult)
        {
            return (ApntAxHHTSalesTableServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTTOTransporterContract[] EndgetTOTransporter(IAsyncResult asyncResult)
        {
            return (ApntAxHHTTOTransporterContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTTransferServiceContract[] EndgetTransferHeader(IAsyncResult asyncResult)
        {
            return (ApntAxHHTTransferServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTTransferLineServiceContract[] EndgetTransferLine(IAsyncResult asyncResult)
        {
            return (ApntAxHHTTransferLineServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public ApntAxHHTCustVendServiceContract[] EndgetVendTable(IAsyncResult asyncResult)
        {
            return (ApntAxHHTCustVendServiceContract[])base.EndInvoke(asyncResult)[0];
        }

        public void EndupdateHHTTransactionHeader(IAsyncResult asyncResult, out bool response, out bool responseSpecified)
        {
            object[] objArray = base.EndInvoke(asyncResult);
            response = (bool)objArray[0];
            responseSpecified = (bool)objArray[1];
        }

        public void EndupdateRegister(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        public void EndupdateStockCountBin(IAsyncResult asyncResult)
        {
            base.EndInvoke(asyncResult);
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getCustTable", RequestElementName = "AXiNTrackGetCustTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetCustTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTCustomerServiceContract[] getCustTable([XmlElement(IsNullable = true)] string _datAreaId, [XmlElement(IsNullable = true)] string _custAccount)
        {
            object[] objArray = new object[] { _datAreaId, _custAccount };
            return (ApntAxHHTCustomerServiceContract[])base.Invoke("getCustTable", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getDataArea", RequestElementName = "AXiNTrackGetDataAreaRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetDataAreaResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTCompanyDataServiceContract[] getDataArea(bool ret, [XmlIgnore] bool retSpecified)
        {
            object[] objArray = new object[] { ret, retSpecified };
            return (ApntAxHHTCompanyDataServiceContract[])base.Invoke("getDataArea", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTBarcodeByBarcode", RequestElementName = "AXiNTrackGetHHTBarcodeByBarcodeRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTBarcodeByBarcodeResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTBarcodeTableServiceContract[] getHHTBarcodeByBarcode([XmlElement(IsNullable = true)] string _datAreaId, [XmlElement(IsNullable = true)] string _location, [XmlElement(IsNullable = true)] string _barcode)
        {
            object[] objArray = new object[] { _datAreaId, _location, _barcode };
            return (ApntAxHHTBarcodeTableServiceContract[])base.Invoke("getHHTBarcodeByBarcode", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTBarcodeByDescription", RequestElementName = "AXiNTrackGetHHTBarcodeByDescriptionRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTBarcodeByDescriptionResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTBarcodeTableServiceContract[] getHHTBarcodeByDescription([XmlElement(IsNullable = true)] string _datAreaId, [XmlElement(IsNullable = true)] string _location, [XmlElement(IsNullable = true)] string _itemId, int _excatMatch, [XmlIgnore] bool _excatMatchSpecified)
        {
            object[] objArray = new object[] { _datAreaId, _location, _itemId, _excatMatch, _excatMatchSpecified };
            return (ApntAxHHTBarcodeTableServiceContract[])base.Invoke("getHHTBarcodeByDescription", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTBarcodeByItemId", RequestElementName = "AXiNTrackGetHHTBarcodeByItemIdRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTBarcodeByItemIdResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTBarcodeTableServiceContract[] getHHTBarcodeByItemId([XmlElement(IsNullable = true)] string _datAreaId, [XmlElement(IsNullable = true)] string _location, [XmlElement(IsNullable = true)] string _itemId, int _excatMatch, [XmlIgnore] bool _excatMatchSpecified)
        {
            object[] objArray = new object[] { _datAreaId, _location, _itemId, _excatMatch, _excatMatchSpecified };
            return (ApntAxHHTBarcodeTableServiceContract[])base.Invoke("getHHTBarcodeByItemId", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTBarcodeTable", RequestElementName = "AXiNTrackGetHHTBarcodeTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTBarcodeTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTBarcodeTableServiceContract[] getHHTBarcodeTable([XmlElement(IsNullable = true)] string _datAreaId, [XmlElement(IsNullable = true)] string _location, DateTime _lastModifiedOn, [XmlIgnore] bool _lastModifiedOnSpecified)
        {
            object[] objArray = new object[] { _datAreaId, _location, _lastModifiedOn, _lastModifiedOnSpecified };
            return (ApntAxHHTBarcodeTableServiceContract[])base.Invoke("getHHTBarcodeTable", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTDocSetup", RequestElementName = "AXiNTrackGetHHTDocSetupRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTDocSetupResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTDocSetupServiceContract[] getHHTDocSetup([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _inventLocationId)
        {
            object[] objArray = new object[] { _dataAreaId, _inventLocationId };
            return (ApntAxHHTDocSetupServiceContract[])base.Invoke("getHHTDocSetup", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTPermission", RequestElementName = "AXiNTrackGetHHTPermissionRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTPermissionResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPermissionTableServiceContract[] getHHTPermission([XmlElement(IsNullable = true)] string _dataAreaId)
        {
            object[] objArray = new object[] { _dataAreaId };
            return (ApntAxHHTPermissionTableServiceContract[])base.Invoke("getHHTPermission", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTPermissionByUserId", RequestElementName = "AXiNTrackGetHHTPermissionByUserIdRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTPermissionByUserIdResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPermissionTableServiceContract[] getHHTPermissionByUserId([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _userId, [XmlElement(IsNullable = true)] string _locationId)
        {
            object[] objArray = new object[] { _dataAreaId, _userId, _locationId };
            return (ApntAxHHTPermissionTableServiceContract[])base.Invoke("getHHTPermissionByUserId", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTPORemainingQty", RequestElementName = "AXiNTrackGetHHTPORemainingQtyRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTPORemainingQtyResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPORemaingQtyServiceContract[] getHHTPORemainingQty([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _purchId, [XmlElement(IsNullable = true)] string _itemBarCode)
        {
            object[] objArray = new object[] { _dataAreaId, _purchId, _itemBarCode };
            return (ApntAxHHTPORemaingQtyServiceContract[])base.Invoke("getHHTPORemainingQty", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTReason", RequestElementName = "AXiNTrackGetHHTReasonRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTReasonResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTReasonTableContract[] getHHTReason([XmlElement(IsNullable = true)] string _dataAreaId)
        {
            object[] objArray = new object[] { _dataAreaId };
            return (ApntAxHHTReasonTableContract[])base.Invoke("getHHTReason", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTRegisterMacAddress", RequestElementName = "AXiNTrackGetHHTRegisterMacAddressRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTRegisterMacAddressResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTRegisterTableServiceContract[] getHHTRegisterMacAddress([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _hhtMAcAddress)
        {
            object[] objArray = new object[] { _dataAreaId, _hhtMAcAddress };
            return (ApntAxHHTRegisterTableServiceContract[])base.Invoke("getHHTRegisterMacAddress", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTRegisterTable", RequestElementName = "AXiNTrackGetHHTRegisterTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTRegisterTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTRegisterTableServiceContract[] getHHTRegisterTable([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _hhtName)
        {
            object[] objArray = new object[] { _dataAreaId, _hhtName };
            return (ApntAxHHTRegisterTableServiceContract[])base.Invoke("getHHTRegisterTable", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTSetupTable", RequestElementName = "AXiNTrackGetHHTSetupTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTSetupTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTSetupTableServiceContract[] getHHTSetupTable([XmlElement(IsNullable = true)] string _dataAreaId)
        {
            object[] objArray = new object[] { _dataAreaId };
            return (ApntAxHHTSetupTableServiceContract[])base.Invoke("getHHTSetupTable", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTStockCountBin", RequestElementName = "AXiNTrackGetHHTStockCountBinRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTStockCountBinResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTStockCountBinServiceContract[] getHHTStockCountBin([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _locationcode)
        {
            object[] objArray = new object[] { _dataAreaId, _locationcode };
            return (ApntAxHHTStockCountBinServiceContract[])base.Invoke("getHHTStockCountBin", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTSuppItem", RequestElementName = "AXiNTrackGetHHTSuppItemRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTSuppItemResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTSuppItemsServiceContract[] getHHTSuppItem([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _vendaccount, [XmlElement(IsNullable = true)] string _itemId)
        {
            object[] objArray = new object[] { _dataAreaId, _vendaccount, _itemId };
            return (ApntAxHHTSuppItemsServiceContract[])base.Invoke("getHHTSuppItem", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTTransactionHeader", RequestElementName = "AXiNTrackGetHHTTransactionHeaderRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTTransactionHeaderResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTTransHeaderServiceContract[] getHHTTransactionHeader([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _transactionType, [XmlElement(IsNullable = true)] string _userId, [XmlElement(IsNullable = true)] string _inventLocationId)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionType, _userId, _inventLocationId };
            return (ApntAxHHTTransHeaderServiceContract[])base.Invoke("getHHTTransactionHeader", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTTransactions", RequestElementName = "AXiNTrackGetHHTTransactionsRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTTransactionsResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTTransactionTableServiceContract[] getHHTTransactions([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _transactionNo, [XmlElement(IsNullable = true)] string _transactionType, [XmlElement(IsNullable = true)] string _userId)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId };
            return (ApntAxHHTTransactionTableServiceContract[])base.Invoke("getHHTTransactions", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTUserLocation", RequestElementName = "AXiNTrackGetHHTUserLocationRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTUserLocationResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTUserLocationServiceContract[] getHHTUserLocation([XmlElement(IsNullable = true)] string _dataAreaId)
        {
            object[] objArray = new object[] { _dataAreaId };
            return (ApntAxHHTUserLocationServiceContract[])base.Invoke("getHHTUserLocation", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTUserRolesTable", RequestElementName = "AXiNTrackGetHHTUserRolesTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTUserRolesTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTUserRolesTableServiceContract[] getHHTUserRolesTable([XmlElement(IsNullable = true)] string _dataAreaId)
        {
            object[] objArray = new object[] { _dataAreaId };
            return (ApntAxHHTUserRolesTableServiceContract[])base.Invoke("getHHTUserRolesTable", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTUserSetup", RequestElementName = "AXiNTrackGetHHTUserSetupRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTUserSetupResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTUserSetupServiceContract[] getHHTUserSetup([XmlElement(IsNullable = true)] string _dataAreaId)
        {
            object[] objArray = new object[] { _dataAreaId };
            return (ApntAxHHTUserSetupServiceContract[])base.Invoke("getHHTUserSetup", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTUserSetUpByUserId", RequestElementName = "AXiNTrackGetHHTUserSetUpByUserIdRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTUserSetUpByUserIdResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTUserSetupServiceContract[] getHHTUserSetUpByUserId([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _userId)
        {
            object[] objArray = new object[] { _dataAreaId, _userId };
            return (ApntAxHHTUserSetupServiceContract[])base.Invoke("getHHTUserSetUpByUserId", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTVendorLatestPrice", RequestElementName = "AXiNTrackGetHHTVendorLatestPriceRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTVendorLatestPriceResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPORemaingQtyServiceContract[] getHHTVendorLatestPrice([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string vendaccount, [XmlElement(IsNullable = true)] string _itemBarCode)
        {
            object[] objArray = new object[] { _dataAreaId, vendaccount, _itemBarCode };
            return (ApntAxHHTPORemaingQtyServiceContract[])base.Invoke("getHHTVendorLatestPrice", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getHHTVendorWithLatestPrice", RequestElementName = "AXiNTrackGetHHTVendorWithLatestPriceRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetHHTVendorWithLatestPriceResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPORemaingQtyServiceContract[] getHHTVendorWithLatestPrice([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _itemBarCode)
        {
            object[] objArray = new object[] { _dataAreaId, _itemBarCode };
            return (ApntAxHHTPORemaingQtyServiceContract[])base.Invoke("getHHTVendorWithLatestPrice", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getInventLocation", RequestElementName = "AXiNTrackGetInventLocationRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetInventLocationResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTInventLocationServiceContract[] getInventLocation([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _inventLocationId)
        {
            object[] objArray = new object[] { _dataAreaId, _inventLocationId };
            return (ApntAxHHTInventLocationServiceContract[])base.Invoke("getInventLocation", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getInventTable", RequestElementName = "AXiNTrackGetInventTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetInventTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTInventTableServiceContract[] getInventTable([XmlElement(IsNullable = true)] string _dataAreaId)
        {
            object[] objArray = new object[] { _dataAreaId };
            return (ApntAxHHTInventTableServiceContract[])base.Invoke("getInventTable", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getItemGroupTable", RequestElementName = "AXiNTrackGetItemGroupTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetItemGroupTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTItemGroupTableServiceContract[] getItemGroupTable([XmlElement(IsNullable = true)] string _dataAreaId)
        {
            object[] objArray = new object[] { _dataAreaId };
            return (ApntAxHHTItemGroupTableServiceContract[])base.Invoke("getItemGroupTable", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getModuleMapping", RequestElementName = "AXiNTrackGetModuleMappingRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetModuleMappingResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTModuleMappingServiceContract[] getModuleMapping([XmlElement(IsNullable = true)] string _dataAreaId)
        {
            object[] objArray = new object[] { _dataAreaId };
            return (ApntAxHHTModuleMappingServiceContract[])base.Invoke("getModuleMapping", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getOnHandLocationWise", RequestElementName = "AXiNTrackGetOnHandLocationWiseRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetOnHandLocationWiseResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTOnHandQtyServiceContract[] getOnHandLocationWise([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string itemId, [XmlElement(IsNullable = true)] string variantId)
        {
            object[] objArray = new object[] { _dataAreaId, itemId, variantId };
            return (ApntAxHHTOnHandQtyServiceContract[])base.Invoke("getOnHandLocationWise", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getOnHandLocationWiseItemSold", RequestElementName = "AXiNTrackGetOnHandLocationWiseItemSoldRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetOnHandLocationWiseItemSoldResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTOnHandQtyServiceContract[] getOnHandLocationWiseItemSold([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string itemId, [XmlElement(IsNullable = true)] string variantId, int noOfDays, [XmlIgnore] bool noOfDaysSpecified)
        {
            object[] objArray = new object[] { _dataAreaId, itemId, variantId, noOfDays, noOfDaysSpecified };
            return (ApntAxHHTOnHandQtyServiceContract[])base.Invoke("getOnHandLocationWiseItemSold", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getOnHandQty", RequestElementName = "AXiNTrackGetOnHandQtyRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetOnHandQtyResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTOnHandQtyServiceContract[] getOnHandQty([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string itemId, [XmlElement(IsNullable = true)] string store, [XmlElement(IsNullable = true)] string variantId)
        {
            object[] objArray = new object[] { _dataAreaId, itemId, store, variantId };
            return (ApntAxHHTOnHandQtyServiceContract[])base.Invoke("getOnHandQty", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getOnHandQtyItemSold", RequestElementName = "AXiNTrackGetOnHandQtyItemSoldRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetOnHandQtyItemSoldResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTOnHandQtyServiceContract[] getOnHandQtyItemSold([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string itemId, [XmlElement(IsNullable = true)] string store, [XmlElement(IsNullable = true)] string variantId)
        {
            object[] objArray = new object[] { _dataAreaId, itemId, store, variantId };
            return (ApntAxHHTOnHandQtyServiceContract[])base.Invoke("getOnHandQtyItemSold", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getOnLinePrice", RequestElementName = "AXiNTrackGetOnLinePriceRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetOnLinePriceResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPricecCheckerServiceContract[] getOnLinePrice([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string inventLocationId, [XmlElement(IsNullable = true)] string itemBarCode)
        {
            object[] objArray = new object[] { _dataAreaId, inventLocationId, itemBarCode };
            return (ApntAxHHTPricecCheckerServiceContract[])base.Invoke("getOnLinePrice", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getPurchInvoiceHeader", RequestElementName = "AXiNTrackGetPurchInvoiceHeaderRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetPurchInvoiceHeaderResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPurchTableServicesContract[] getPurchInvoiceHeader([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _location)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return (ApntAxHHTPurchTableServicesContract[])base.Invoke("getPurchInvoiceHeader", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getPurchLine", RequestElementName = "AXiNTrackGetPurchLineRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetPurchLineResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPurchLineServiceContract[] getPurchLine([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _purchId, [XmlElement(IsNullable = true)] string inventLocationId)
        {
            object[] objArray = new object[] { _dataAreaId, _purchId, inventLocationId };
            return (ApntAxHHTPurchLineServiceContract[])base.Invoke("getPurchLine", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getPurchReturnHeader", RequestElementName = "AXiNTrackGetPurchReturnHeaderRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetPurchReturnHeaderResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPurchTableServicesContract[] getPurchReturnHeader([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _location, int _toBeShipped, [XmlIgnore] bool _toBeShippedSpecified)
        {
            object[] objArray = new object[] { _dataAreaId, _location, _toBeShipped, _toBeShippedSpecified };
            return (ApntAxHHTPurchTableServicesContract[])base.Invoke("getPurchReturnHeader", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getPurchReturnLine", RequestElementName = "AXiNTrackGetPurchReturnLineRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetPurchReturnLineResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPurchLineServiceContract[] getPurchReturnLine([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _purchId, [XmlElement(IsNullable = true)] string inventLocationId)
        {
            object[] objArray = new object[] { _dataAreaId, _purchId, inventLocationId };
            return (ApntAxHHTPurchLineServiceContract[])base.Invoke("getPurchReturnLine", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getPurchTable", RequestElementName = "AXiNTrackGetPurchTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetPurchTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTPurchTableServicesContract[] getPurchTable([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _location)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return (ApntAxHHTPurchTableServicesContract[])base.Invoke("getPurchTable", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getSalesInvoiceHeader", RequestElementName = "AXiNTrackGetSalesInvoiceHeaderRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetSalesInvoiceHeaderResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTSalesTableServiceContract[] getSalesInvoiceHeader([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _location)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return (ApntAxHHTSalesTableServiceContract[])base.Invoke("getSalesInvoiceHeader", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getSalesLine", RequestElementName = "AXiNTrackGetSalesLineRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetSalesLineResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTSalesLineServiceContract[] getSalesLine([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _salesId, [XmlElement(IsNullable = true)] string _inventLocationId)
        {
            object[] objArray = new object[] { _dataAreaId, _salesId, _inventLocationId };
            return (ApntAxHHTSalesLineServiceContract[])base.Invoke("getSalesLine", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getSalesReturnHeader", RequestElementName = "AXiNTrackGetSalesReturnHeaderRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetSalesReturnHeaderResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTSalesTableServiceContract[] getSalesReturnHeader([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _location)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return (ApntAxHHTSalesTableServiceContract[])base.Invoke("getSalesReturnHeader", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getSalesReturnLine", RequestElementName = "AXiNTrackGetSalesReturnLineRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetSalesReturnLineResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTSalesLineServiceContract[] getSalesReturnLine([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _salesId, [XmlElement(IsNullable = true)] string _inventLocationId)
        {
            object[] objArray = new object[] { _dataAreaId, _salesId, _inventLocationId };
            return (ApntAxHHTSalesLineServiceContract[])base.Invoke("getSalesReturnLine", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getSalesReturnReceiptHeader", RequestElementName = "AXiNTrackGetSalesReturnReceiptHeaderRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetSalesReturnReceiptHeaderResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTSalesTableServiceContract[] getSalesReturnReceiptHeader([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _location)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return (ApntAxHHTSalesTableServiceContract[])base.Invoke("getSalesReturnReceiptHeader", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getSalesTable", RequestElementName = "AXiNTrackGetSalesTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetSalesTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTSalesTableServiceContract[] getSalesTable([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _location)
        {
            object[] objArray = new object[] { _dataAreaId, _location };
            return (ApntAxHHTSalesTableServiceContract[])base.Invoke("getSalesTable", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getTOTransporter", RequestElementName = "AXiNTrackGetTOTransporterRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetTOTransporterResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTTOTransporterContract[] getTOTransporter([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _transportId)
        {
            object[] objArray = new object[] { _dataAreaId, _transportId };
            return (ApntAxHHTTOTransporterContract[])base.Invoke("getTOTransporter", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getTransferHeader", RequestElementName = "AXiNTrackGetTransferHeaderRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetTransferHeaderResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTTransferServiceContract[] getTransferHeader([XmlElement(IsNullable = true)] string _dataAreaId, InventTransferStatus _status, [XmlIgnore] bool _statusSpecified, [XmlElement(IsNullable = true)] string _inventLocationId)
        {
            object[] objArray = new object[] { _dataAreaId, _status, _statusSpecified, _inventLocationId };
            return (ApntAxHHTTransferServiceContract[])base.Invoke("getTransferHeader", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getTransferLine", RequestElementName = "AXiNTrackGetTransferLineRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetTransferLineResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTTransferLineServiceContract[] getTransferLine([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _inventTransId)
        {
            object[] objArray = new object[] { _dataAreaId, _inventTransId };
            return (ApntAxHHTTransferLineServiceContract[])base.Invoke("getTransferLine", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/getVendTable", RequestElementName = "AXiNTrackGetVendTableRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackGetVendTableResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        [return: XmlArray("response", IsNullable = true)]
        [return: XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
        public ApntAxHHTCustVendServiceContract[] getVendTable([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _vendAccount)
        {
            object[] objArray = new object[] { _dataAreaId, _vendAccount };
            return (ApntAxHHTCustVendServiceContract[])base.Invoke("getVendTable", objArray)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/updateHHTTransactionHeader", RequestElementName = "AXiNTrackUpdateHHTTransactionHeaderRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackUpdateHHTTransactionHeaderResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void updateHHTTransactionHeader([XmlElement(IsNullable = true)] string _dataAreaId, [XmlElement(IsNullable = true)] string _transactionNo, [XmlElement(IsNullable = true)] string _transactionType, [XmlElement(IsNullable = true)] string _userId, [XmlElement(IsNullable = true)] string _remarks, DateTime _documentDate, [XmlIgnore] bool _documentDateSpecified, DateTime _expectedDate, [XmlIgnore] bool _expectedDateSpecified, [XmlElement(IsNullable = true)] string _trackingId, [XmlElement(IsNullable = true)] string _transportId, [XmlElement(IsNullable = true)] string _truckNo, [XmlElement(IsNullable = true)] string _driverName, [XmlElement(IsNullable = true)] string _invoiceNo, out bool response, [XmlIgnore] out bool responseSpecified)
        {
            object[] objArray = new object[] { _dataAreaId, _transactionNo, _transactionType, _userId, _remarks, _documentDate, _documentDateSpecified, _expectedDate, _expectedDateSpecified, _trackingId, _transportId, _truckNo, _driverName, _invoiceNo };
            object[] objArray1 = base.Invoke("updateHHTTransactionHeader", objArray);
            response = (bool)objArray1[0];
            responseSpecified = (bool)objArray1[1];
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/updateRegister", RequestElementName = "AXiNTrackUpdateRegisterRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackUpdateRegisterResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void updateRegister([XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")][XmlArray(IsNullable = true)] ApntAxHHTRegisterTableServiceContract[] _hhtUpdateList)
        {
            object[] objArray = new object[] { _hhtUpdateList };
            base.Invoke("updateRegister", objArray);
        }

        [SoapDocumentMethod("http://tempuri.org/AXiNTrack/updateStockCountBin", RequestElementName = "AXiNTrackUpdateStockCountBinRequest", RequestNamespace = "http://tempuri.org", ResponseElementName = "AXiNTrackUpdateStockCountBinResponse", ResponseNamespace = "http://tempuri.org", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        [SoapHeader("CallContextValue")]
        public void updateStockCountBin([XmlArray(IsNullable = true)][XmlArrayItem(Namespace = "http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")] ApntAxHHTStockCountBinServiceContract[] _hhtUpdateStockCountBinList)
        {
            object[] objArray = new object[] { _hhtUpdateStockCountBinList };
            base.Invoke("updateStockCountBin", objArray);
        }
    }
}