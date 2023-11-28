using AutoMapper;
using ETC.PoliceInquery.Models.DTOs.Request;
using ETC.PoliceInquery.Models.DTOs.Request.EntranceRequests;
using ETC.PoliceInquery.Shared;
using System.Security.Cryptography;
using System.Text;

namespace ETC.PoliceInquery.Models
{
    public class MapperConfig : Profile
    {
        public MapperConfig()
        {
            CreateMap<BillDataEntranceRequestDto, BillDataRequestDto>()
                .ForMember(dest => dest.SignData, opt => opt.MapFrom(src => GenSign($"{src.TrackingCode} {src.TrafficUId} {src.EventId} {src.BillNumber}{src.BillPrice}{src.BillDateTime}")));//.ReverseMap();

            CreateMap<CheckBarcodePlateEntranceRequestDto, CheckBarcodePlateRequestDto>()
                .ForMember(dest => dest.SignData, opt => opt.MapFrom(src => GenSign($"{src.Barcode}{src.PlateNumber}")));

            CreateMap<PaymentBillEntranceRequestDto, PaymentBillRequestDto>()
                .ForMember(dest => dest.SignData, opt => opt.MapFrom(src => GenSign($"{src.TrackingCode}{src.BillNumber}{src.PaymentPrice}{src.PaymentDateTime}{(short)Enum.Parse(typeof(PayOffStatus), src.PayoffStatus)}")));

            CreateMap<SendPenaltyEntranceRequestDto, SendPenaltyRequestDto>()
                .ForMember(dest => dest.SignData, opt => opt.MapFrom(src => GenSign($"{src.BillNumber}{src.TrackingCode}{src.ViolationCode}")));

            CreateMap<SendPicEntranceRequestDto, SendPicRequestDto>()
                .ForMember(dest => dest.SignData, opt => opt.MapFrom(src => GenSign($"{src.TrackingCode}{src.TrafficUId}")));

            CreateMap<TrackingClassEntranceRequestDto, TrackingClassRequestDto>()
                .ForMember(dest => dest.SignData, opt => opt.MapFrom(src => GenSign($"{src.TrackingCode}{src.TrafficUId}{src.BillNumber}{src.EventId}")));

            CreateMap<TrafficModelEntranceRequestDto, TrafficModelRequestDto>()
                .ForMember(dest => dest.SignData, opt => opt.MapFrom(src => GenSign($"{src.TrafficUId}{src.PlateNumber}{src.TrafficDate}{src.TrafficTime}{src.CameraCode}{src.FreewayCode}")));
        }
        private string GenSign(string param)
        {
            using (SHA512 sha512 = SHA512.Create())
            {
                byte[] paramBytes = Encoding.UTF8.GetBytes(param);
                byte[] saltedParamBytes = new byte[paramBytes.Length + ApplicationVariables._salt.Length];

                Buffer.BlockCopy(ApplicationVariables._salt, 0, saltedParamBytes, 0, ApplicationVariables._salt.Length);
                Buffer.BlockCopy(paramBytes, 0, saltedParamBytes, ApplicationVariables._salt.Length, paramBytes.Length);

                byte[] hashBytes = sha512.ComputeHash(saltedParamBytes);

                StringBuilder sb = new StringBuilder();
                foreach (byte b in hashBytes)
                {
                    sb.Append(b.ToString("x2")); // Convert each byte to its hexadecimal representation
                }

                return sb.ToString();
            }
        }
    }
}






//نمونه کد ناجی در مستندات
//string GenSign(String param)
//{
//    MessageDigest md = MessageDigest.GetInstance("SHA-512");
//    byte[] salt = { x, x, x, x, x, x, x, x, x, x, x, x, x, x, x, x};
//    md.update(salt);
//    byte[] dg = md.digest(param.getBytes());
//    StringBuilder sb = new StringBuilder();
//    for (int i = 0; i < dg.length; i++)
//    {
//        sb.append(Integer.toString((dg[i] & 0xff) + 0x100, 16).substring(1));
//    }
//    return sb.toString();
//}
