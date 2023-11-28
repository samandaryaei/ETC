namespace ETC.PoliceInquery.Models.DTOs.Request
{
    public class CheckBarcodePlateRequestDto : BaseRequestDto
    {
        public string PlateNumber { get; set; }
        public string Barcode { get; set; }
    }
}
