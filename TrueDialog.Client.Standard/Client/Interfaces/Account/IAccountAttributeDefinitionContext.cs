using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IAccountAttributeDefinitionContext
    {
        AccountAttributeDefinition GetById(int definitionId, bool throwIfEmpty = false);

        List<AccountAttributeDefinition> GetList(bool throwIfEmpty = false);

        AccountAttributeDefinition Add(AccountAttributeDefinition definition);

        AccountAttributeDefinition Add(string name, DataType dataType, string description = null, bool inheritable = true);

        void Delete(int accountId, int definitionId);

        void Delete(AccountAttributeDefinition definition);

        void Delete(int definitionId);
    }
}
