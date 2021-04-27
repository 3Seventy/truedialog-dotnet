using System;
using System.Collections.Generic;

using TrueDialog.Model;

namespace TrueDialog.Context
{
    internal class CampaignAnswerContext : BaseContext, ICampaignAnswerContext
    {
        internal CampaignAnswerContext(IApiCaller api) : base(api)
        {
        }

        public List<CampaignAnswer> GetList(int accountId, int campaignId, bool throwIfEmpty = true)
        {
            return Api.Get<List<CampaignAnswer>>($"/account/{accountId}/campaign/{campaignId}/question/answer", throwIfEmpty);
        }

        public List<CampaignAnswer> GetList(int campaignId, bool throwIfEmpty = true)
        {
            return GetList(CurrentAccount, campaignId, throwIfEmpty);
        }

        public CampaignAnswer GetById(int accountId, int campaignId, int answerId, bool throwIfEmpty = true)
        {
            return Api.Get<CampaignAnswer>($"/account/{accountId}/campaign/{campaignId}/question/answer/{answerId}", throwIfEmpty);
        }

        public CampaignAnswer GetById(int campaignId, int answerId, bool throwIfEmpty = true)
        {
            return GetById(CurrentAccount, campaignId, answerId, throwIfEmpty);
        }

        public CampaignAnswer Create(int accountId, int campaignId, CampaignAnswer answer)
        {
            return Api.Post($"/account/{accountId}/campaign/{campaignId}/question/answer", answer);
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
            return Api.Put($"/account/{accountId}/campaign/{campaignId}/question/answer/{answerId}", answer);
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
            Api.Delete($"/account/{accountId}/campaign/{campaignId}/question/answer/{answerId}");
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
