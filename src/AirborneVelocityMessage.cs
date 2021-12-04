namespace jpda.Adsb.Model
{
    public class AirborneVelocityMessage : Message
    {
        public AirborneVelocityMessage(string data) : base(data, 4.ToString())
        {
        }
    }
}