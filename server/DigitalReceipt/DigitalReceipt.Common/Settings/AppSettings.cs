namespace DigitalReceipt.Common.Settings
{
    public class AppSettings
    {
        public string Key { get; set; }

        public bool EnableSwagger { get; set; }

        public bool EnableCors { get; set; }

        public bool ExposeStackTrace { get; set; }

        public string[] AllowedOrigins { get; set; }

        public string ApplicationName { get; set; }

        public string DefaultUser { get; set; }
    }
}
