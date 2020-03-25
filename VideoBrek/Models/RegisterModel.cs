using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace VideoBrek.Models
{
    public class RegisterModel
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public double? Latitude { get; set; }
        public double? Longitude { get; set; }
        public int PrivacyPolicyId { get; set; }
    }
}
