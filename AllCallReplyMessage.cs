namespace jpda.Adsb.Model
{
    public class AllCallReplyMessage : Message
    {
        public AllCallReplyMessage(string data) : base(data, 8.ToString())
        {
        }
    }
}