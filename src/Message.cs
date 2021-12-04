using System;
using System.Text.Json.Serialization;

namespace jpda.Adsb.Model
{
    public class Message
    {
        [JsonIgnore] protected string RawMessage { get; set; }
        [JsonIgnore] protected string[] RawMessageSplit { get; set; }
        public string? MessageType { get; set; }
        public string? TransmissionType { get; set; }
        public string? SessionId { get; set; }
        public string? AircraftId { get; set; }
        public string? Hexident { get; set; }
        public string? FlightId { get; set; }
        public DateTime MessageDate { get; set; }
        public DateTime MessageTime { get; set; }
        public DateTime LogDate { get; set; }
        public DateTime LogTime { get; set; }
        public virtual string? Callsign { get; set; }
        public decimal Altitude { get; set; }
        public decimal GroundSpeed { get; set; }
        public string? Track { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public decimal VerticalRate { get; set; }
        public string? Squawk { get; set; }
        public bool SquawkChange { get; set; }
        public bool Emergency { get; set; }
        public bool SPI { get; set; }
        public bool IsOnGround { get; set; }

        protected Message(string data, string messageType)
        {
            MessageType = messageType;
            RawMessage = data;
            RawMessageSplit = data.Split(',');
            TransmissionType = GetValue<string>(1);
            SessionId = GetValue<string>(2);
            AircraftId = GetValue<string>(3);
            Hexident = GetValue<string>(4);
            FlightId = GetValue<string>(5);
            MessageDate = GetValue(6, DateTime.Parse);
            MessageTime = GetValue(7, DateTime.Parse);
            LogDate = GetValue(8, DateTime.Parse);
            LogTime = GetValue(9, DateTime.Parse);
            Callsign = GetValue<string>(10);
            Altitude = GetValue(11, decimal.Parse);
            GroundSpeed = GetValue(12, decimal.Parse);
            Track = GetValue<string>(13);
            Latitude = GetValue(14, decimal.Parse);
            Longitude = GetValue(15, decimal.Parse);
            VerticalRate = GetValue(16, decimal.Parse);
            Squawk = GetValue<string>(17);
            SquawkChange = GetValue(18, x => x == "1");
            Emergency = GetValue(19, x => x == "1");
            SPI = GetValue(20, x => x == "1");
            IsOnGround = GetValue(21, x => x == "1");
        }

        public static Message Parse(string data)
        {
            var pieces = data.Split(',');
            var type = int.Parse(pieces[1]);

            return type switch
            {
                1 => new IdentificationAndCategoryMessage(data),
                2 => new SurfacePositionMessage(data),
                3 => new AirbornePositionMessage(data),
                4 => new AirborneVelocityMessage(data),
                5 => new SurveillanceAltMessage(data),
                6 => new SurveillanceIdMessage(data),
                7 => new AirToAirMessage(data),
                8 => new AllCallReplyMessage(data),
                _ => new Message(data, 0.ToString())
            };
        }

        protected T GetValue<T>(int index, Func<string, T>? convert = null)
        {
            var val = RawMessageSplit[index];
            if (string.IsNullOrEmpty(val)) return default!;
            if (convert == null) return (T) (object) val;
            try
            {
                return convert(val);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

            return default!;
        }
    }
}