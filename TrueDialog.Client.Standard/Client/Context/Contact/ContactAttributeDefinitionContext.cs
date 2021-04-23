using System;
using System.Collections.Generic;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ContactAttributeDefinitionContext : BaseContext, IContactAttributeDefinitionContext
    {
        internal ContactAttributeDefinitionContext(IApiCaller api) : base(api)
        {
        }

        public List<ContactAttributeDefinition> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.Get<List<ContactAttributeDefinition>>($"account/{accountId}/contact-attributedef", throwIfEmpty);
        }

        public List<ContactAttributeDefinition> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public ContactAttributeDefinition GetById(int accountId, int definitionId, bool throwIfEmpty = true)
        {
            return Api.Get<ContactAttributeDefinition>($"account/{accountId}/contact-attributedef/{definitionId}", throwIfEmpty);
        }

        public ContactAttributeDefinition GetById(int definitionId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, definitionId, throwIfEmpty);
        }

        public ContactAttributeDefinition Create(int accountId, ContactAttributeDefinition definition)
        {
            definition.CategoryId = 0;
            return Api.Post($"account/{accountId}/contact-attributedef", definition);
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
            return Api.Put($"account/{accountId}/contact-attributedef/{definitionId}", new ContactAttributeDefinition
            {
                CategoryId = 0,
                Description = description
            });
        }

        public ContactAttributeDefinition UpdateDescription(int definitionId, string description)
        {
            return UpdateDescription(CurrentAccount, definitionId, description);
        }

        public void Delete(int accountId, int definitionId)
        {
            Api.Delete($"account/{accountId}/contact-attributedef/{definitionId}");
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
