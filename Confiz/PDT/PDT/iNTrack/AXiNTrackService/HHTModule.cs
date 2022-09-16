namespace iNTrack.AXiNTrackService
{
    using System;
    using System.Xml.Serialization;

    [XmlType(Namespace="http://schemas.datacontract.org/2004/07/Dynamics.Ax.Application")]
    public enum HHTModule
    {
        None,
        PO,
        PI,
        PR,
        PRQ,
        SO,
        SI,
        SR,
        ADJ,
        SC,
        TRO,
        TRI,
        PC,
        IC,
        SET,
        PLC,
        SLC,
        SHRINK,
        TRQ,
        PRS,
        TRS,
        SRR,
        SPC,
        MISC
    }
}

