using System;
using Insight.Domain.Enums;

namespace Insight.Domain.Model
{
    public class Vehicle
    {
        public string Id { get; set; }
        public string RegistrationNr { get; set; }
        public DateTime RegistrationDate { get; set; }
        public string Name { get; set; }
        public VehicleType Type { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
    }
}
