using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrueDialog.Model;

namespace TrueDialog.Context
{
    public class CampaignAnswerContext : BaseContext
    {
        internal CampaignAnswerContext(InternalClient client) : base(client)
        {
        }

        private const string LIST = "/account/{accountId}/campaign/{campaignId}/question/answer";
        private const string ITEM = "/account/{accountId}/campaign/{campaignId}/question/answer/{answerId}";

        public List<CampaignAnswer> GetList(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetList<CampaignAnswer>(LIST, new { accountId, campaignId }, throwIfEmpty);
            return rval;
        }

        public List<CampaignAnswer> GetList(int campaignId, bool throwIfEmpty = true)
        {
            return GetList(CurrentAccount, campaignId, throwIfEmpty);
        }

        public CampaignAnswer GetById(int accountId, int campaignId, int answerId, bool throwIfEmpty = true)
        {
            var rval = TDClient.GetItem<CampaignAnswer>(ITEM, new { accountId, campaignId, answerId }, throwIfEmpty);
            return rval;
        }

        public CampaignAnswer GetById(int campaignId, int answerId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, campaignId, answerId, throwIfEmpty);
        }

        public CampaignAnswer Create(int accountId, int campaignId, CampaignAnswer answer)
        {
            var rval = TDClient.Add(LIST, new { accountId, campaignId }, answer);
            return rval;
        }

        public CampaignAnswer Create(int campaignId, CampaignAnswer answer)
        {
            int accountId = answer.AccountId > 0 ? answer.AccountId : CurrentAccount;
            return Create(accountId, campaignId, answer);
        }

        public CampaignAnswer Create(CampaignAnswer answer)
        {
            if (answer.CampaignId == 0)
                throw new ArgumentException("Campaign ID is missing.");

            int accountId = answer.AccountId > 0 ? answer.AccountId : CurrentAccount;
            return Create(accountId, answer.CampaignId, answer);
        }

        public CampaignAnswer Update(int accountId, int campaignId, int answerId, CampaignAnswer answer)
        {
            var rval = TDClient.Update(ITEM, new { accountId, campaignId, answerId }, answer);
            return rval;
        }

        public CampaignAnswer Update(int campaignId, int answerId, CampaignAnswer answer)
        {
            int accountId = answer.AccountId > 0 ? answer.AccountId : CurrentAccount;
            return Update(accountId, campaignId, answerId, answer);
        }

        public CampaignAnswer Update(CampaignAnswer answer)
        {
            if (answer.CampaignId == 0)
                throw new ArgumentException("Campaign ID is missing.");

            if (answer.Id == 0)
                throw new ArgumentException("Answer ID is missing.");

            int accountId = answer.AccountId > 0 ? answer.AccountId : CurrentAccount;
            return Update(accountId, answer.CampaignId, answer.Id, answer);
        }

        public void Delete(int accountId, int campaignId, int answerId)
        {
            TDClient.Delete(ITEM, new { accountId, campaignId, answerId });
        }

        public void Delete(int campaignId, int answerId)
        {
            Delete(CurrentAccount, campaignId, answerId);
        }

        public void Delete(CampaignAnswer answer)
        {
            if (answer.CampaignId == 0)
                throw new ArgumentException("Campaign ID is missing.");

            if (answer.Id == 0)
                throw new ArgumentException("Answer ID is missing.");

            int accountId = answer.AccountId > 0 ? answer.AccountId : CurrentAccount;
            Delete(accountId, answer.CampaignId, answer.Id);
        }
    }
}
