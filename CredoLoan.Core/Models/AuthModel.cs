﻿using System.Text.Json.Serialization;

namespace CredoLoan.Core.Models
{
    public class AuthModel
    {
        public string Name { get; set; }
        public string SurName { get; set; }
        public string UserName { get; set; }
        public string PersonalNumber { get; set; }
        public string AccessToken { get; set; }
        public DateTime ExpiresIn { get; set; }
    }
}
