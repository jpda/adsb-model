using System;

namespace jpda.Adsb.Model
{
    public sealed class SurfacePositionMessage : Message
    {
        public SurfacePositionMessage(string data) : base(data, 2.ToString())
        {
            var decParse = new Func<string, decimal>(decimal.Parse);
            Altitude = GetValue(11, decParse);
            GroundSpeed = GetValue(12, decParse);
            Track = GetValue<string>(13);
            Latitude = GetValue(14, decParse);
            Longitude = GetValue(15, decParse);
            IsOnGround = GetValue(21, bool.Parse);
        }
    }
}