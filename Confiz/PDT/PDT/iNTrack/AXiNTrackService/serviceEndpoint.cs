namespace iNTrack.AXiNTrackService
{
    using System;
    using System.ComponentModel;
    using System.Diagnostics;
    using System.Web.Services;
    using System.Web.Services.Protocols;
    using System.Xml.Serialization;

    [DesignerCategory("code"), XmlInclude(typeof(XppObjectBase)), WebServiceBinding(Name="serviceEndpoint", Namespace="http://tempuri.org/"), DebuggerStepThrough]
    public class serviceEndpoint : SoapHttpClientProtocol
    {
        public serviceEndpoint()
        {
            base.Url = "http://entsvr:1111/MicrosoftDynamicsAXAif60/iNTrackAX/xppservice.svc";
        }
    }
}

