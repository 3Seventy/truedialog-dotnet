using System;
using System.Collections.Generic;
using System.Linq;

using TrueDialog.Context;
using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Builders
{
    public class SMSBuilder : ISMSBuilder
    {
        internal string _message;
        internal int? _campaignId;
        internal List<string> _from = new List<string>();
        internal List<string> _to = new List<string>();

        private readonly MessageContext m_context;

        public SMSBuilder(MessageContext context)
        {
            m_context = context;
        }

        public ISMSBuilder Text(string messageText)
        {
            _message = messageText;
            return this;
        }

        public ISMSBuilder From(string from)
        {
            _from.Add(from);
            return this;
        }

        public ISMSBuilder To(string to)
        {
            _to.Add(Utils.ReadPhoneNumber(to));
            return this;
        }

        public ISMSBuilder Campaign(int campaignId)
        {
            _campaignId = campaignId;
            return this;
        }

        public ActionPushCampaign Send()
        {
            Validate();
            return m_context.Submit(BuildAction());
        }

        internal ActionPushCampaign BuildAction()
        {
            return new ActionPushCampaign
            {
                CampaignId = _campaignId ?? 0,
                Channels = _from,
                Targets = _to,
                Message = _message,
                Execute = true
            };
        }

        private void Validate()
        {
            if (!_from.Any())
                throw new ArgumentException("From address can't be empty.");

            if (!_to.Any())
                throw new ArgumentException("To address can't be empty.");

            if (string.IsNullOrEmpty(_message) && !_campaignId.HasValue)
                throw new ArgumentException("Message text can't be empty.");
        }
    }
}
