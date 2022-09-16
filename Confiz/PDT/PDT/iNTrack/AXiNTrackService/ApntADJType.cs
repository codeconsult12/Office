namespace iNTrack.AXiNTrackService
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public enum ApntADJType
    {
        WASTE,
        SHRINK,
        MISC
    }
}

