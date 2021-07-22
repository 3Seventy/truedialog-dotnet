using System;
using System.Collections.Generic;
using System.Linq;

using TrueDialog.Helpers;
using TrueDialog.Model;

namespace TrueDialog.Builders
{
    public class SMSBuilder : ISMSBuilder
    {
        private readonly ISet<string> m_from = new HashSet<string>();
        private readonly ISet<string> m_to = new HashSet<string>();

        private string m_message;
        private int? m_campaignId;
        private bool m_ignoreInvalidTargets;
        private bool m_forceOptIn;

        private readonly IMessageContext m_context;

        public SMSBuilder(IMessageContext context)
        {
            m_context = context;
        }

        public ISMSBuilder IgnoreInvalidTargets(bool ignore = true)
        {
            m_ignoreInvalidTargets = ignore;
            return this;
        }

        public ISMSBuilder ForceOptIn(bool forceOptIn = true)
        {
            m_forceOptIn = forceOptIn;
            return this;
        }

        public ISMSBuilder Text(string messageText)
        {
            m_message = messageText;
            return this;
        }

        public ISMSBuilder From(string from)
        {
            m_from.Add(from);
            return this;
        }

        public ISMSBuilder To(string to)
        {
            m_to.Add(Utils.ReadPhoneNumber(to));
            return this;
        }

        public ISMSBuilder To(IEnumerable<string> to)
        {
            m_to.AddRange(to.Select(Utils.ReadPhoneNumber));
            return this;
        }

        public ISMSBuilder Campaign(int campaignId)
        {
            m_campaignId = campaignId;
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
                CampaignId = m_campaignId ?? 0,
                Channels = m_from.ToList(),
                Targets = m_to.ToList(),
                Message = m_message,
                Execute = true,
                IgnoreInvalidTargets = m_ignoreInvalidTargets,
                ForceOptIn = m_forceOptIn
            };
        }

        private void Validate()
        {
            if (!m_from.Any())
                throw new ArgumentException("From address can't be empty.");

            if (!m_to.Any())
                throw new ArgumentException("To address can't be empty.");

            if (string.IsNullOrEmpty(m_message) && !m_campaignId.HasValue)
                throw new ArgumentException("Message text can't be empty.");
        }
    }
}
