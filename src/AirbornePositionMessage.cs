namespace jpda.Adsb.Model
{
    public class AirbornePositionMessage : Message
   {
        public AirbornePositionMessage(string data) : base(data, 3.ToString()) { }
    }
}