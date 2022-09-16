namespace iNTrack
{
    using OpenNETCF.WindowsCE;
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.CompilerServices;

    public static class OpenNETCFLib
    {
        public static List<TimeZoneInfo> GetTimeZoneInfo()
        {
            List<TimeZoneInfo> list2;
            try
            {
                List<TimeZoneInfo> list = new List<TimeZoneInfo>();
                TimeZoneCollection zones = new TimeZoneCollection();
                zones.Initialize();
                IEnumerator enumerator = zones.GetEnumerator();
                try
                {
                    while (true)
                    {
                        if (!enumerator.MoveNext())
                        {
                            break;
                        }
                        TimeZoneInformation current = (TimeZoneInformation) enumerator.Current;
                        try
                        {
                            TimeZoneInfo item = new TimeZoneInfo {
                                DisplayName = current.DisplayName.Replace("\0", string.Empty),
                                StandardName = current.StandardName,
                                Bias = current.Bias
                            };
                            list.Add(item);
                        }
                        catch (Exception)
                        {
                        }
                    }
                }
                finally
                {
                    IDisposable objA = enumerator as IDisposable;
                    if (!ReferenceEquals(objA, null))
                    {
                        objA.Dispose();
                    }
                }
                list2 = list;
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
            return list2;
        }

        public static void SetTimeZoneInformation(string StandardName)
        {
            Func<TimeZoneInfo, bool> func = null;
            try
            {
                TimeZoneInformation tzi = new TimeZoneInformation {
                    StandardName = StandardName
                };
                if (func == null)
                {
                    func = element => element.StandardName == StandardName;
                }
                tzi.Bias = Enumerable.Where<TimeZoneInfo>(GetTimeZoneInfo(), func).First<TimeZoneInfo>().Bias;
                DateTimeHelper.SetTimeZoneInformation(tzi);
            }
            catch (Exception exception1)
            {
                throw exception1;
            }
        }

        public class TimeZoneInfo
        {
            public string DisplayName { get; set; }

            public string StandardName { get; set; }

            public int Bias { get; set; }
        }
    }
}

