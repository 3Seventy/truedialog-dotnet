using System;

namespace TrueDialog.Configuration.Config
{
    class TrueDialogAuth : IAuthConfig
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public string ApiKey { get; set; }
        public string ApiSecret { get; set; }
        public int AccountId { get; set; }

        public static TrueDialogAuth Empty
        {
            get
            {
                return new TrueDialogAuth();
            }
        }
    }
}
