using Microsoft.Extensions.Configuration;

namespace TrueDialog.Configuration
{
    internal class TrueDialogConfigProvider : ITrueDialogConfigProvider
    {
        private const string Section = "TrueDialog";
        private readonly IConfiguration m_config;

        public TrueDialogConfigProvider(IConfiguration config)
        {
            m_config = config;
        }

        public ITrueDialogConfig GetConfig()
        {
            return m_config.GetSection(Section).Get<TrueDialogConfig>();
        }
    }
}
