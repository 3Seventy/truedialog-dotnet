using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class AccountAttributeDefinitionContext : BaseContext, IAccountAttributeDefinitionContext
    {
        internal AccountAttributeDefinitionContext(IApiCaller api)
            : base(api)
        {
        }

        public AccountAttributeDefinition GetById(int definitionId, bool throwIfEmpty = false)
        {
            return Api.Get<AccountAttributeDefinition>($"/account/{CurrentAccount}/attributeDef/{definitionId}", throwIfEmpty);
        }

        public List<AccountAttributeDefinition> GetList( bool throwIfEmpty = false)
        {
            return Api.Get<List<AccountAttributeDefinition>>($"/account/{CurrentAccount}/attributeDef", throwIfEmpty);
        }

        public AccountAttributeDefinition Add(AccountAttributeDefinition definition)
        {
            return Api.Post($"/account/{CurrentAccount}/attributeDef", definition);
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
            Api.Delete($"/account/{accountId}/attributeDef/{definitionId}");
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
