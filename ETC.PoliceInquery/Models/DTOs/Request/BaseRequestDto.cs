using ETC.PoliceInquery.Shared;
using System.Security.Cryptography;
using System.Text;
using System.Text.Json.Serialization;

namespace ETC.PoliceInquery.Models.DTOs.Request
{
    public class BaseRequestDto
    {
        public virtual string SignData { get; set; }
    }
}





