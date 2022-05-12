namespace CredoLoan.Core.Extensions
{
    public static class DateTimeExtensions
    {
        public static DateTime ParseBirthDate(this string input)
        {
            try
            {
                return DateTime.Parse(input);
            }
            catch { }
            return DateTime.MinValue;
        }
    }
}
