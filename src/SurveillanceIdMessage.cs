namespace jpda.Adsb.Model
{
    public class SurveillanceIdMessage : Message
    {
        public SurveillanceIdMessage(string data) : base(data, 6.ToString())
        {
        }
    }
}