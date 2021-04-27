using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IAccountAttributeContext
    {
        AccountAttribute GetById(int accountId, int attributeId, bool throwIfEmpty = false);

        AccountAttribute GetById(int attributeId, bool throwIfEmpty = false);

        AccountAttribute GetByName(int accountId, string attributeName, bool throwIfEmpty = false);

        AccountAttribute GetByName(string attributeName, bool throwIfEmpty = false);

        List<AccountAttribute> GetList(bool throwIfEmpty = false);

        List<AccountAttribute> GetList(int accountId, bool throwIfEmpty = false);

        AccountAttribute Create(int accountId, AccountAttribute attribute);

        AccountAttribute Create(AccountAttribute attribute);

        AccountAttribute Update(AccountAttribute attribute);

        void Delete(int accountId, int attributeId);

        void Delete(int accountId, string attributeName);

        void Delete(AccountAttribute attribute);

        void Delete(int attributeId);

        void Delete(string attributeName);
    }
}
