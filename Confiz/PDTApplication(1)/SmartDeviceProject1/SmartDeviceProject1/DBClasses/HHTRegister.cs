using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace SmartDeviceProject1.DBClasses
{
 public class HHTREGISTER
{
    public string HHTNAME { get; set; }

    public string MACADDRESS { get; set; }

    public DateTime MODIFIEDDATETIME { get; set; }

    public string MODIFIEDBY { get; set; }

    public DateTime CREATEDDATETIME { get; set; }

    public string CREATEDBY { get; set; }

    public string DATAAREAID { get; set; }

    public long ROWVERSION { get; set; }

}

}
