using System;

namespace Oauth2Demo
{
    public class SensorData
    {
        public float consumptionPower { get; set; }
        public long consumptionEnergy { get; set; }
        public float generationPower { get; set; }
        public long generationEnergy { get; set; }
        public long netPower { get; set; }
        public long netEnergy { get; set; }
        public DateTime timestamp { get; set; }

    }
}