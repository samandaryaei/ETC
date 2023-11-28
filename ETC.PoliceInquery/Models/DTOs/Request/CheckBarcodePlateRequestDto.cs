namespace ETC.PoliceInquery.Models.DTOs.Request
{
    public class CheckBarcodePlateRequestDto : BaseRequestDto
    {
        public string PlateNumber { get; set; }
        public string Barcode { get; set; }
        public override string SignData
        {
            get => string.IsNullOrEmpty(SignData) ?
                base.GenSign($"{Barcode}{PlateNumber}") :
                SignData;
        }
    }
}
