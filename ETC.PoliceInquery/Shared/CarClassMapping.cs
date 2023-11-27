namespace ETC.PoliceInquery.Shared
{
    public record struct CarClassMapping
    {
        public CarClassMapping(string sepandarCode,string najiCode,string subUsage,string usage)
        {
            SepandarCode = sepandarCode;
            NajiCode = najiCode;
            SubUsage = subUsage;
            Usage = usage;
        }

        public string SepandarCode { get; set; }
        public string NajiCode { get; set; }
        public string SubUsage { get; set; }
        public string Usage { get; set; }
    }
}
