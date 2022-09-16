using System;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Web.Services;
using System.Web.Services.Description;
using System.Web.Services.Protocols;
using System.Xml.Xsl;

namespace iNTrack.iNTrackService
{
    [DebuggerStepThrough]
    [DesignerCategory("code")]
    [WebServiceBinding(Name = "ServiceSoap", Namespace = "http://tempuri.org/")]
    public class Service : SoapHttpClientProtocol
    {
        public Service()
        {
            base.Url = "http://localhost/iNTrackAX/Service.asmx";
        }

        public IAsyncResult BeginCheckConnectivity(AsyncCallback callback, object asyncState)
        {
            IAsyncResult asyncResult = base.BeginInvoke("CheckConnectivity", new object[0], callback, asyncState);
            return asyncResult;
        }

        public IAsyncResult BeginDownloadFile(string FileName, AsyncCallback callback, object asyncState)
        {
            object[] fileName = new object[] { FileName };
            return base.BeginInvoke("DownloadFile", fileName, callback, asyncState);
        }

        public IAsyncResult BeginGetData(string[] Param, AsyncCallback callback, object asyncState)
        {
            object[] param = new object[] { Param };
            return base.BeginInvoke("GetData", param, callback, asyncState);
        }

        public IAsyncResult BeginGetFileList(string Path, AsyncCallback callback, object asyncState)
        {
            object[] path = new object[] { Path };
            return base.BeginInvoke("GetFileList", path, callback, asyncState);
        }

        public IAsyncResult BeginGetServerTime(AsyncCallback callback, object asyncState)
        {
            IAsyncResult asyncResult = base.BeginInvoke("GetServerTime", new object[0], callback, asyncState);
            return asyncResult;
        }

        public IAsyncResult BeginSetData(string[] Param, DataSet dataset, AsyncCallback callback, object asyncState)
        {
            object[] param = new object[] { Param, dataset };
            return base.BeginInvoke("SetData", param, callback, asyncState);
        }

        [SoapDocumentMethod("http://tempuri.org/CheckConnectivity", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public bool CheckConnectivity()
        {
            object[] objArray = base.Invoke("CheckConnectivity", new object[0]);
            return (bool)objArray[0];
        }

        [SoapDocumentMethod("http://tempuri.org/DownloadFile", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
       // [return: XmlElement(DataType = "base64Binary")]
        public byte[] DownloadFile(string FileName)
        {
            object[] fileName = new object[] { FileName };
            return (byte[])base.Invoke("DownloadFile", fileName)[0];
        }

        public bool EndCheckConnectivity(IAsyncResult asyncResult)
        {
            return (bool)base.EndInvoke(asyncResult)[0];
        }

        public byte[] EndDownloadFile(IAsyncResult asyncResult)
        {
            return (byte[])base.EndInvoke(asyncResult)[0];
        }

        public DataSet EndGetData(IAsyncResult asyncResult)
        {
            return (DataSet)base.EndInvoke(asyncResult)[0];
        }

        public string[] EndGetFileList(IAsyncResult asyncResult)
        {
            return (string[])base.EndInvoke(asyncResult)[0];
        }

        public string EndGetServerTime(IAsyncResult asyncResult)
        {
            return (string)base.EndInvoke(asyncResult)[0];
        }

        public int EndSetData(IAsyncResult asyncResult)
        {
            return (int)base.EndInvoke(asyncResult)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/GetData", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public DataSet GetData(string[] Param)
        {
            object[] param = new object[] { Param };
            return (DataSet)base.Invoke("GetData", param)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/GetFileList", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public string[] GetFileList(string Path)
        {
            object[] path = new object[] { Path };
            return (string[])base.Invoke("GetFileList", path)[0];
        }

        [SoapDocumentMethod("http://tempuri.org/GetServerTime", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public string GetServerTime()
        {
            object[] objArray = base.Invoke("GetServerTime", new object[0]);
            return (string)objArray[0];
        }

        [SoapDocumentMethod("http://tempuri.org/SetData", RequestNamespace = "http://tempuri.org/", ResponseNamespace = "http://tempuri.org/", Use = SoapBindingUse.Literal, ParameterStyle = SoapParameterStyle.Wrapped)]
        public int SetData(string[] Param, DataSet dataset)
        {
            object[] param = new object[] { Param, dataset };
            return (int)base.Invoke("SetData", param)[0];
        }
    }
}