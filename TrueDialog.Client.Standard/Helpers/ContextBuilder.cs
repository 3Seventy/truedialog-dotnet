using System;
using System.Collections.Concurrent;
using System.Reflection;
using System.Threading;

using TrueDialog.Context;

namespace TrueDialog
{
    internal sealed class ContextBuilder
    {
        private readonly ConcurrentDictionary<string, BaseContext> m_contextDictionary = new ConcurrentDictionary<string, BaseContext>();
        private readonly SemaphoreSlim m_semaphore = new SemaphoreSlim(1);
        private readonly IApiCaller m_api;

        public ContextBuilder(IApiCaller api)
        {
            m_api = api;
        }

        internal TContext GetContext<TContext>()
            where TContext : BaseContext
        {
            try
            {
                m_semaphore.Wait();
                string key = typeof(TContext).Name;
                if (m_contextDictionary.ContainsKey(key))
                    return m_contextDictionary[key] as TContext;
                else
                {
                    var constructor = typeof(TContext).GetConstructor(BindingFlags.NonPublic | BindingFlags.Instance,
                        null, new Type[] { typeof(IApiCaller) }, null);
                    var context = (TContext)constructor.Invoke(new object[] { m_api });

                    m_contextDictionary[key] = context;
                    return context;
                }
            }
            finally
            {
                m_semaphore.Release();
            }
        }
    }
}
