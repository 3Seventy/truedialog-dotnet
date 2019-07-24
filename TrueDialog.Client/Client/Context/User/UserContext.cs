using RestSharp;
using System.Collections.Generic;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class UserContext : BaseContext
    {
        internal UserContext(InternalClient client) : base(client, true)
        {
        }

        private const string LIST = "/account/{accountId}/user";
        private const string ITEM = "/account/{accountId}/user/{username}";
        private const string LOCK = "/account/{accountId}/user/{username}/lock";
        private const string RESET = "/account/{accountId}/user/{username}/password";

        public List<User> GetList(int accountId, bool throwIfEmpty = false)
        {
            var rval = TDClient.GetList<User>(LIST, new { accountId }, throwIfEmpty);
            return rval;
        }

        public List<User> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public User GetUser(int accountId, string username, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<User>(ITEM, new { accountId, username }, throwIfEmpty);
            return rval;
        }

        public User GetUser(string username, bool throwIfEmpty = true)
        {
            return GetUser(CurrentAccount, username, throwIfEmpty);
        }

        public User Create(int accountId, User user)
        {
            user.PasswordConfirmation = user.Password;
            var rval = TDClient.Add(LIST, new { accountId }, user);
            return rval;
        }

        public User Create(User user)
        {
            return Create(user.AccountId > 0 ? user.AccountId : CurrentAccount, user);
        }

        public User Update(User user)
        {
            var rval = TDClient.Update(ITEM, new { accountId = user.AccountId, username = user.UserName }, user);
            return rval;
        }

        public void Delete(int accountId, string username)
        {
            TDClient.Delete(ITEM, new { accountId, username });
        }

        public void Delete(string username)
        {
            Delete(CurrentAccount, username);
        }

        public void Delete(User user)
        {
            Delete(user.AccountId, user.UserName);
        }

        public void Lock(int accountId, string username)
        {
            var request = TDClient.BuildRequest(Method.POST, LOCK, new { accountId, username }, null);
            TDClient.InnerExecute(request);
        }

        public void Lock(string username)
        {
            Lock(CurrentAccount, username);
        }

        public void Lock(User user)
        {
            Lock(user.AccountId, user.UserName);
        }

        public void Unlock(int accountId, string username)
        {
            var request = TDClient.BuildRequest(Method.PUT, LOCK, new { accountId, username }, null);
            TDClient.InnerExecute(request);
        }

        public void Unlock(string username)
        {
            Unlock(CurrentAccount, username);
        }

        public void Unlock(User user)
        {
            Unlock(user.AccountId, user.UserName);
        }

        public void UpdatePassword(int accountId, string username, string newPassword)
        {
            var request = TDClient.BuildRequest(Method.PUT, RESET, new { accountId, username }, new { NewPassword = newPassword, ConfirmPassword = newPassword });
            TDClient.InnerExecute(request);
        }

        public void UpdatePassword(string username, string newPassword)
        {
            UpdatePassword(CurrentAccount, username, newPassword);
        }
    }
}
