namespace jpda.Adsb.Model
{
    public class SurveillanceAltMessage : Message
    {
        public SurveillanceAltMessage(string data) : base(data, 5.ToString())
        {
        }
    }
}