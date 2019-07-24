using System;
using System.Collections.Generic;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class ContactAttributeDefinitionContext : BaseContext
    {
        internal ContactAttributeDefinitionContext(InternalClient client) : base(client)
        {
        }

        private const string ITEM = "account/{accountId}/contact-attributedef/{definitionId}";
        private const string LIST = "account/{accountId}/contact-attributedef";

        public List<ContactAttributeDefinition> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<ContactAttributeDefinition>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<ContactAttributeDefinition> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public ContactAttributeDefinition GetById(int accountId, int definitionId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<ContactAttributeDefinition>(ITEM, new { accountId, definitionId }, throwIfEmpty);
            return rval;
        }

        public ContactAttributeDefinition GetById(int definitionId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, definitionId, throwIfEmpty);
        }

        public ContactAttributeDefinition Create(int accountId, ContactAttributeDefinition definition)
        {
            definition.CategoryId = 0;
            var rval = TDClient.Add(LIST, new { accountId }, definition);
            return rval;
        }

        public ContactAttributeDefinition Create(ContactAttributeDefinition definition)
        {
            return Create(CurrentAccount, definition);
        }

        public ContactAttributeDefinition Create(int accountId, string name, DataType dataType, string description = null)
        {
            return Create(accountId, new ContactAttributeDefinition
            {
                Name = name,
                DataType = dataType,
                CategoryId = 0,
                Description = description
            });
        }

        public ContactAttributeDefinition UpdateDescription(int accountId, int definitionId, string description)
        {
            var rval = TDClient.Update(ITEM, new { accountId, definitionId }, new ContactAttributeDefinition
            {
                CategoryId = 0,
                Description = description
            });

            return rval;
        }

        public ContactAttributeDefinition UpdateDescription(int definitionId, string description)
        {
            return UpdateDescription(CurrentAccount, definitionId, description);
        }

        public void Delete(int accountId, int definitionId)
        {
            TDClient.Delete(ITEM, new { accountId, definitionId });
        }

        public void Delete(int definitionId)
        {
            Delete(CurrentAccount, definitionId);
        }

        public void Delete(ContactAttributeDefinition definition)
        {
            if (definition.Id == 0)
                throw new ArgumentException("Definition ID is missing.");

            int accountId = definition.AccountId > 0 ? definition.AccountId : CurrentAccount;
            Delete(accountId, definition.Id);
        }
    }
}
