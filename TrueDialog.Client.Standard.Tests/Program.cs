using System;

namespace TrueDialog
{
    class Program
    {
        static void Main(string[] args)
        {
            var info1 = Client.Singleton.Account.GetCurrentAccount();
        }
    }
}
