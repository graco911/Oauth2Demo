using System;
using System.Collections.Generic;

namespace Oauth2Demo
{
    public class NeurioUser
    {
        public string email { get; set; }
        public string name { get; set; }
        public string password { get; set; }
        public string id { get; set; }
        public string status { get; set; }
        public DateTime createdAt { get; set; }
        public List<Locations> locations { get; set; }
        public List<ReleaseFeatures> releaseFeatures { get; set; }
    }
    public class Locations
    {
        public string name { get; set; }
        public string timezone { get; set; }
        public List<Sensors> sensors { get; set; }
        public float energyRate { get; set; }
        public string billingType { get; set; }
        public float fixedCharge { get; set; }
        public float taxRate { get; set; }
        public float budget { get; set; }
        public DateTime createdAt { get; set; }
        public string id { get; set; }
    }
    public class Sensors
    {
        public string sensorId { get; set; }
        public string email { get; set; }
        public string installCode { get; set; }
        public string sensorType { get; set; }
        public string platformType { get; set; }
        public string locationId { get; set; }
        public List<Channels> channels { get; set; }
        public DateTime startTime { get; set; }
        public string ipAddress { get; set; }
        public string id { get; set; }
    }
    public class Channels
    {
        public string sensorId { get; set; }
        public int channel { get; set; }
        public string channelType { get; set; }
        public string name { get; set; }
        public DateTime start { get; set; }
        public string id { get; set; }
    }

    public class ReleaseFeatures
    {
        public string userId { get; set; }
        public ReleaseFeature releaseFeature { get; set; }
        public DateTime createdAt { get; set; }
        public string id { get; set; }

    }

    public class ReleaseFeature
    {
        public string name { get; set; }
        public string description { get; set; }
        public DateTime createdAt { get; set; }
        public string id { get; set; }
    }
}