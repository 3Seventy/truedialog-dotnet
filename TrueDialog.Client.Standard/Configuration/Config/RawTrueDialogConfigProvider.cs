namespace TrueDialog.Configuration
{
    internal class RawTrueDialogConfigProvider : ITrueDialogConfigProvider
    {
        private readonly string m_username;
        private readonly string m_password;

        public RawTrueDialogConfigProvider(string username, string password)
        {
            m_username = username;
            m_password = password;
        }

        public ITrueDialogConfig GetConfig()
        {
            return new TrueDialogConfig
            {
                Username = m_username,
                Password = m_password
            };
        }
    }
}
