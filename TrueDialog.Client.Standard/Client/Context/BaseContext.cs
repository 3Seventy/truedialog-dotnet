using System;
using System.Collections.Concurrent;
using System.Reflection;

namespace TrueDialog.Context
{
    internal class BaseContext
    {
        protected readonly ITrueDialogClient Client;
        protected readonly IApiCaller Api;

        public BaseContext(ITrueDialogClient client, IApiCaller api)
        {
            Client = client;
            Api = api;
        }

        protected int CurrentAccount { get { return Client.AccountId; } }

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
                    var context = (TContext)constructor.Invoke(new object[] { Client, Api });

                    m_contextDictionary[key] = context;
                    return context;
                }
            }
        }
        #endregion
    }
}
