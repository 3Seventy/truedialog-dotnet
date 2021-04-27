using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class UserContext : BaseContext, IUserContext
    {
        internal UserContext(IApiCaller api) : base(api)
        {
        }

        public User GetSelf()
        {
            return Api.AsUser().Get<User>($"userinfo", true);
        }

        public List<User> GetList(int accountId, bool throwIfEmpty = false)
        {
            return Api.AsUser().Get<List<User>>($"account/{accountId}/user", throwIfEmpty);
        }

        public List<User> GetList(bool throwIfEmpty = false)
        {
            return GetList(CurrentAccount, throwIfEmpty);
        }

        public User GetUser(int accountId, string username, bool throwIfEmpty = true)
        {
            return Api.AsUser().Get<User>($"account/{accountId}/user/{username}", throwIfEmpty);
        }

        public User GetUser(string username, bool throwIfEmpty = true)
        {
            return GetUser(CurrentAccount, username, throwIfEmpty);
        }

        public User Create(int accountId, User user)
        {
            user.PasswordConfirmation = user.Password;
            return Api.AsUser().Post($"account/{accountId}/user", user);
        }

        public User Create(User user)
        {
            return Create(user.AccountId > 0 ? user.AccountId : CurrentAccount, user);
        }

        public User Update(User user)
        {
            return Api.AsUser().Put($"account/{user.AccountId}/user/{user.UserName}", user);
        }

        public void Delete(int accountId, string username)
        {
            Api.AsUser().Delete($"account/{accountId}/user/{username}");
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
            Api.AsUser().Post<string>($"account/{accountId}/user/{username}/lock", null);
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
            Api.AsUser().Put<string>($"account/{accountId}/user/{username}/lock", null);
        }

        public void Unlock(string username)
        {
            Unlock(CurrentAccount, username);
        }

        public void Unlock(User user)
        {
            Unlock(user.AccountId, user.UserName);
        }

        public void UpdatePassword(int accountId, string username, string currentPassword, string newPassword)
        {
            Api.AsUser().Put<string>($"account/{accountId}/user/{username}/password", new { CurrentPassword = currentPassword, NewPassword = newPassword, ConfirmPassword = newPassword });
        }

        public void UpdatePassword(string username, string currentPassword, string newPassword)
        {
            UpdatePassword(CurrentAccount, username, currentPassword, newPassword);
        }
    }
}
