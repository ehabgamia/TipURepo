using System;
using System.Collections.Generic;

namespace VideoBrek.Models
{
    public class PrivacyPolicyModel
    {
        public int PrivacyPolicyId { get; set; }
        public string PrivacyPolicyText { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpirationDate { get; set; }
        public string CreateDtTm { get; set; }
        public int CreatedBy { get; set; }
        public bool IsActive { get; set; }
        public List<UserProfileModel> UserProfile { get; set; }

    }

    public class TermsAndConditionsModel
    {
        public int Id { get; set; }
        public string TermsText { get; set; }
    }

}