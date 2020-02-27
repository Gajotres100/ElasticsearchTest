using Nest;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistance.Elasticsearch.Maping
{
    [ElasticsearchType(IdProperty = nameof(TracklogId))]
    public class TracklogDocument
    {
        [Number(NumberType.Integer, Name = nameof(TracklogId), Index = true)]
        public int TracklogId { get; set; }
        [Number(NumberType.Integer, Name = nameof(UserId), Index = true)]
        public int UserId { get; set; }
        [Number(NumberType.Integer, Name = nameof(EventId), Index = true)]
        public int EventId { get; set; }
        public GeoLocation Location { get; set; }
        [Number(NumberType.Integer, Name = nameof(Speed), Index = true)]
        public int? Speed { get; set; }
        public int? Heading { get; set; }
        [Number(NumberType.Integer, Name = nameof(Satno), Index = true)]
        public int? Satno { get; set; }
        public int? Live { get; set; }
        [Number(NumberType.Integer, Name = nameof(IgnitionStatus), Index = true)]
        public int? IgnitionStatus { get; set; }
        public double? BatteryVoltage { get; set; }
        public double? MainSupplyVoltage { get; set; }
        public int? Altitude { get; set; }
        [Keyword(Name = nameof(Address), Index = true)]
        public string Address { get; set; }
        [Number(NumberType.Integer, Name = nameof(DeviceId), Index = true)]
        public int DeviceId { get; set; }
        [Number(NumberType.Integer, Name = nameof(DeviceUserId), Index = true)]
        public int? DeviceUserId { get; set; }
        [Number(NumberType.Integer, Name = nameof(VirtOdo), Index = true)]
        public decimal? VirtOdo { get; set; }
        [Keyword(Name = nameof(DeviceUserFirstName), Index = true)]
        public string DeviceUserFirstName { get; set; }
        [Keyword(Name = nameof(DeviceUserLastName), Index = true)]
        public string DeviceUserLastName { get; set; }
        [Keyword(Name = nameof(DeviceAlias), Index = true)]
        public string DeviceAlias { get; set; }
        [Keyword(Name = nameof(VehicleRegistration), Index = true)]
        public string VehicleRegistration { get; set; }
        public string VehicleOtherInfo { get; set; }
        public int? EngineRpm { get; set; }
        [Number(Name = nameof(FuelLevel1), Index = true)]
        public double? FuelLevel1 { get; set; }
        [Number(Name = nameof(FuelLevel2), Index = true)]
        public double? FuelLevel2 { get; set; }
        [Number(Name = nameof(Temperature1), Index = true)]
        public double? Temperature1 { get; set; }
        [Number(Name = nameof(Temperature2), Index = true)]
        public double? Temperature2 { get; set; }
        public double Temperature3 { get; set; }
        public double Temperature4 { get; set; }
        [Keyword(Name = nameof(Ibutton), Index = true)]
        public string Ibutton { get; set; }
        [Keyword(Name = nameof(Rfid), Index = true)]
        public string Rfid { get; set; }
        [Date(Name = nameof(Timestamp), Index = true)]
        public DateTime Timestamp { get; set; }
    }
}
