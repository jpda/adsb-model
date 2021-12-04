namespace jpda.Adsb.Model
{
    public class IdentificationAndCategoryMessage : Message
    {
        public sealed override string? Callsign { get; set; }

        public IdentificationAndCategoryMessage(string data) : base(data, 1.ToString())
        {
            Callsign = GetValue<string>(10);
        }
    }
}