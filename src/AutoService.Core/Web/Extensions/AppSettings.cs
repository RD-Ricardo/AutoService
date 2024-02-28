namespace AutoService.Core.Web.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpireHours { get; set; }
        public string Issurer { get; set; }
        public string ValidAt { get; set; }
    }
}
