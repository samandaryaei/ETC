namespace ETC.PoliceInquery.DTOs.Request
{
    public class CheckBarcodePlateRequestDto
    {
        public string PlateNumber { get; set; }
        public string Barcode { get; set; }
        public string SignData { get; set; }
    }
}
