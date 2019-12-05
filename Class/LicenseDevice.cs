using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DiscoLedCracker.Class
{
    public class LicenseDevice
    {
        public bool HasIndividualDate { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public TimeSpan RemainingRunTime { get; set; }

        public string ConnectorName { get; set; }

        public string DeviceName { get; set; }

        public string LockDeviceName { get; set; }

        public bool Locked { get; set; }
    }
}
