using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace OnionCamp.Application.DTOs.Facebook
{
    public class FacebookUserAccessTokenValidationDTO
    {
        [JsonPropertyName("data")]
        public FacebookUserAccessTokenValidationDTOData Data { get; set; }
    }
    public class FacebookUserAccessTokenValidationDTOData
    {
        [JsonPropertyName("is_valid")]
        public bool IsValid { get; set; }
        [JsonPropertyName("user_id")]
        public string UserId { get; set; }
    }
}
