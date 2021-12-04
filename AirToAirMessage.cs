namespace jpda.Adsb.Model
{
    public class AirToAirMessage : Message
    {
        public AirToAirMessage(string data) : base(data, 7.ToString()) { }
    }
}