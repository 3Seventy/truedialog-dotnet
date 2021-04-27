namespace TrueDialog.Configuration
{
    public class TrueDialogConfig : ITrueDialogConfig
    {
        public string Username { get; set; }

        public string Password { get; set; }

        public string ApiKey { get; set; }

        public string ApiSecret { get; set; }

        public int? AccountId { get; set; }

        public string BaseUrl { get; set; }

        public string UserAgent { get; set; }

        public int? Timeout { get; set; }
    }
}
