namespace TrueDialog.Configuration
{
    internal class ClassicTrueDialogConfigProvider : ITrueDialogConfigProvider
    {
        public ITrueDialogConfig GetConfig()
        {
            try
            {
                var config = TrueDialogConfigSection.GetConfig();
                if (config == null)
                    return null;

                return new TrueDialogConfig
                {
                    AccountId = config.Authorization.AccountId,
                    ApiKey = config.Authorization.ApiKey,
                    ApiSecret = config.Authorization.ApiSecret,
                    UserAgent = config.UserAgent,
                    BaseUrl = config.BaseUrl,
                    Username = config.Authorization.UserName,
                    Password = config.Authorization.Password,
                    Timeout = (int)config.Timeout.TotalMilliseconds
                };
            }
            catch
            {
                return null;
            }
        }
    }
}
