using System;
using System.Collections.Generic;
using System.Text;

namespace DiscoLedCracker.Class
{
    public class LicenseData
    {
        public int Version { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime LastRunDate { get; set; }

        public TimeSpan RemainingRunTime { get; set; }

        public int[] Data { get; set; }

        public List<LicenseDevice> LicenseDevices { get; set; }

        public bool IsEmpty { get; set; }

        public static LicenseData Empty
        {
            get
            {
                return new LicenseData();
            }
        }

        public LicenseData()
        {
            this.LicenseDevices = new List<LicenseDevice>();
            this.IsEmpty = true;
        }
    }
}
