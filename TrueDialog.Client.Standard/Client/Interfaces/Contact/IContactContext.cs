using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IContactContext
    {

        #region SubContexts
        IContactAttributeContext Attribute { get; }

        IContactAttributeDefinitionContext AttributeDefinition { get; }

        IContactSubscriptionContext Subscription { get; }
        #endregion

        Contact GetById(int accountId, int contactId, bool throwIfEmpty = true);

        Contact GetById(int contactId, bool throwIfEmpty = true);

        List<Contact> GetList(int accountId, bool throwIfEmpty = false);

        List<Contact> GetList(bool throwIfEmpty = false);

        List<Contact> Search(int accountId, string needle);

        List<Contact> Search(string needle);

        Contact Create(int accountId, Contact contact);

        Contact Create(Contact contact);

        Contact Create(int accountId, string phoneNumber, string email = null, List<ContactAttribute> attributes = null, List<ContactSubscription> subscriptions = null);

        Contact Create(string phoneNumber, string email = null, List<ContactAttribute> attributes = null, List<ContactSubscription> subscriptions = null);

        Contact Update(int accountId, int contactId, Contact contact);

        Contact Update(int contactId, Contact contact);

        Contact Update(Contact contact);

        void Delete(int accountId, int contactId);

        void Delete(int contactId);

        void Delete(Contact contact);
    }
}
