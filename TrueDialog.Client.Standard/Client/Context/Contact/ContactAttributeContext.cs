using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class ContactAttributeContext : BaseContext, IContactAttributeContext
    {
        internal ContactAttributeContext(IApiCaller api) : base(api)
        {
        }

        public ContactAttribute GetByName(int accountId, int contactId, string name, bool throwIfEmpty = false)
        {
            var value = Api.Get<string>($"account/{accountId}/contact/{contactId}/attribute/{name}", throwIfEmpty);

            return new ContactAttribute
            {
                Name = name,
                AccountId = accountId,
                Value = value
            };
        }

        public ContactAttribute GetByName(int contactId, string name, bool throwIfEmpty = false)
        {
            return GetByName(CurrentAccount, contactId, name, throwIfEmpty);
        }

        public List<ContactAttribute> GetList(int accountId, int contactId, bool throwIfEmpty = false)
        {
            return Api.Get<List<ContactAttribute>>($"account/{accountId}/contact/{contactId}/attribute");
        }

        public List<ContactAttribute> GetList(int contactId, bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, contactId, throwIfEmpty);
        }

        public ContactAttribute CreateOrUpdate(int accountId, int contactId, string name, string value)
        {
            return Api.Post<ContactAttribute>($"account/{accountId}/contact/{contactId}/attribute/{name}", value);
        }

        public ContactAttribute CreateOrUpdate(int contactId, string name, string value)
        {
            return CreateOrUpdate(CurrentAccount, contactId, name, value);
        }

        public ContactAttribute CreateOrUpdate(int contactId, ContactAttribute attribute)
        {
            string name = attribute.Id > 0 ? attribute.Id.ToString() : attribute.Name;
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Attribute name is missing.");

            return CreateOrUpdate(CurrentAccount, contactId, name, attribute.Value);
        }

        public ContactAttribute CreateOrUpdate(ContactAttribute attribute)
        {
            if (attribute.ContactId == 0)
                throw new ArgumentException("Contact ID is missing");

            return CreateOrUpdate(attribute.ContactId, attribute);
        }

        public void Delete(int accountId, int contactId, string name)
        {
            Api.Delete($"account/{accountId}/contact/{contactId}/attribute/{name}");
        }

        public void Delete(int contactId, string name)
        {
            Delete(CurrentAccount, contactId, name);
        }

        public void Delete(ContactAttribute attribute)
        {
            if (attribute.ContactId == 0)
                throw new ArgumentException("Contact ID is missing.");

            string name = attribute.Id > 0 ? attribute.Id.ToString() : attribute.Name;
            if (string.IsNullOrEmpty(name))
                throw new ArgumentException("Attribute name is missing.");

            Delete(attribute.ContactId, name);
        }
    }
}
