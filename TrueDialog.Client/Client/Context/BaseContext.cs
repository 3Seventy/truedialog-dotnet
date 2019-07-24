using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace TrueDialog.Context
{
    public class BaseContext
    {
        private InternalClient m_client;
        private bool m_asUser;

        internal InternalClient TDClient { get { return m_asUser ? m_client.AsUser() : m_client; } }

        internal BaseContext(InternalClient client, bool asUser = false)
        {
            m_client = client;
            m_asUser = asUser;
        }

        protected int CurrentAccount { get { return TDClient.CurrentAccount(); } }

        #region SubContext factory
        protected readonly ConcurrentDictionary<string, BaseContext> m_contextDictionary = new ConcurrentDictionary<string, BaseContext>();
        private readonly object m_mutex = new object();

        protected TContext GetContext<TContext>()
            where TContext : BaseContext
        {
            lock (m_mutex)
            {
                string key = typeof(TContext).Name;
                if (m_contextDictionary.ContainsKey(key))
                    return m_contextDictionary[key] as TContext;
                else
                {
                    var constructor = typeof(TContext).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                        null, new Type[] { typeof(InternalClient) }, null);
                    var context = (TContext)constructor.Invoke(new object[] { TDClient });

                    m_contextDictionary[key] = context;
                    return context;
                }
            }
        }
        #endregion
    }
}
