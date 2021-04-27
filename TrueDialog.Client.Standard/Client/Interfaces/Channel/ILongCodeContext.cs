using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface ILongCodeContext
    {
        List<string> GetRawList(int accountId, bool throwIfEmpty = false);

        List<string> GetRawList(bool throwIfEmpty = false);

        List<LongCode> GetList(int accountId, bool includeChildren = false, bool throwIfEmpty = false);

        List<LongCode> GetList(bool includeChildren = false, bool throwIfEmpty = false);

        LongCode AddForwarding(int accountId, string longCode, string forwardingNumber);

        LongCode AddForwarding(string longCode, string forwardingNumber);

        LongCode AddForwarding(LongCode longCode, string forwardingNumber);

        LongCode UpdateForwarding(int accountId, string longCode, string forwardingNumber);

        LongCode UpdateForwarding(string longCode, string forwardingNumber);

        LongCode UpdateForwarding(LongCode longCode, string forwardingNumber);

        void RemoveForwarding(int accountId, string longCode);

        void RemoveForwarding(string longCode);

        void RemoveForwarding(LongCode longCode);

        LongCode VerifyForwarding(int accountId, string longCode, string verificationCode);

        LongCode VerifyForwarding(string longCode, string verificationCode);

        LongCode VerifyForwarding(LongCode longCode, string verificationCode);
    }
}
