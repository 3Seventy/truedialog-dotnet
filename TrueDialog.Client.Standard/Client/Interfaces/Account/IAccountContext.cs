using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IAccountContext
    {
        IAccountAttributeContext Attribute { get; }

        IAccountAttributeDefinitionContext AttributeDefinition { get; }

        Account GetById(int accountId, bool throwIfEmpty = false);

        Account GetCurrentAccount();

        /// <summary>
        /// Get list of all available accounts
        /// </summary>
        /// <returns>List of accounts</returns>
        List<Account> GetList(bool throwIfEmpty = false);

        Account Create(Account account);

        Account Update(Account account);

        void Delete(int accountId);

        void Delete(Account account);
    }
}
