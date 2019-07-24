using System.Collections.Generic;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class AccountAttributeDefinitionContext : BaseContext
    {
        internal AccountAttributeDefinitionContext(InternalClient client) : base(client)
        {
        }

        private const string ITEM = "account/{accountId}/attributeDef/{definitionId}";
        private const string LIST = "account/{accountId}/attributeDef";

        public AccountAttributeDefinition GetById(int definitionId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<AccountAttributeDefinition>(ITEM, new { accountId = CurrentAccount, definitionId }, throwIfEmpty);
            return rval;
        }

        public List<AccountAttributeDefinition> GetList(bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<AccountAttributeDefinition>(LIST, new { accountId = CurrentAccount }, throwIfEmpty);
            return rval;
        }

        public AccountAttributeDefinition Add(AccountAttributeDefinition definition)
        {
            var rval = TDClient.Add(LIST, new { accountId = CurrentAccount }, definition);
            return rval;
        }

        public AccountAttributeDefinition Add(string name, DataType dataType, string description = null, bool inheritable = true)
        {
            return Add(new AccountAttributeDefinition
            {
                AccountId = CurrentAccount,
                CategoryId = 0,
                DataType = dataType,
                Description = description,
                Name = name,
                Inheritable = inheritable
            });
        }

        public void Delete(int accountId, int definitionId)
        {
            TDClient.Delete(ITEM, new { accountId, definitionId });
        }

        public void Delete(AccountAttributeDefinition definition)
        {
            Delete(definition.AccountId, definition.Id);
        }

        public void Delete(int definitionId)
        {
            Delete(CurrentAccount, definitionId);
        }
    }
}
