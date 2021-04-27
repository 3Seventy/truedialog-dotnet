using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IContactAttributeDefinitionContext
    {
        List<ContactAttributeDefinition> GetList(int accountId, bool throwIfEmpty = false);

        List<ContactAttributeDefinition> GetList(bool throwIfEmpty = false);

        ContactAttributeDefinition GetById(int accountId, int definitionId, bool throwIfEmpty = true);

        ContactAttributeDefinition GetById(int definitionId, bool throwIfEmpty = true);

        ContactAttributeDefinition Create(int accountId, ContactAttributeDefinition definition);

        ContactAttributeDefinition Create(ContactAttributeDefinition definition);

        ContactAttributeDefinition Create(int accountId, string name, DataType dataType, string description = null);

        ContactAttributeDefinition UpdateDescription(int accountId, int definitionId, string description);

        ContactAttributeDefinition UpdateDescription(int definitionId, string description);

        void Delete(int accountId, int definitionId);

        void Delete(int definitionId);

        void Delete(ContactAttributeDefinition definition);
    }
}
