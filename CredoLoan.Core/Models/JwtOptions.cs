namespace CredoLoan.Core.Models
{
    public class JwtOptions
    {
        public string Issuer { get; set; }

        public string Audience { get; set; }

        public string IssuerSigningKey { get; set; }
    }
}
