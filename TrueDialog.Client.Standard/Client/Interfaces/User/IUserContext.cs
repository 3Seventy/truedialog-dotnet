using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog
{
    public interface IUserContext
    {
        User GetSelf();

        List<User> GetList(int accountId, bool throwIfEmpty = false);

        List<User> GetList(bool throwIfEmpty = false);

        User GetUser(int accountId, string username, bool throwIfEmpty = true);

        User GetUser(string username, bool throwIfEmpty = true);

        User Create(int accountId, User user);

        User Create(User user);

        User Update(User user);

        void Delete(int accountId, string username);

        void Delete(string username);

        void Delete(User user);

        void Lock(int accountId, string username);

        void Lock(string username);

        void Lock(User user);

        void Unlock(int accountId, string username);

        void Unlock(string username);

        void Unlock(User user);

        void UpdatePassword(int accountId, string username, string currentPassword, string newPassword);

        void UpdatePassword(string username, string currentPassword, string newPassword);
    }
}
