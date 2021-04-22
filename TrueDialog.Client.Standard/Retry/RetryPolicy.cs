using System;
using System.Threading;

namespace TrueDialog.Retry
{
    /// <summary>
    /// Base class for all retry policies.
    /// </summary>
    class RetryPolicy<TDetector> : IRetryPolicy
        where TDetector : IRetryDetectionStrategy, new()
    {
        private readonly RetryStrategy m_retryStrategy;

        public RetryPolicy(RetryStrategy strategy)
        {
            m_retryStrategy = strategy;
        }

        private void InnerExecute(Action<int> action)
        {
            var detect = new TDetector();

            int attempt = 0;

            for (;;)
            {
                ++attempt;

                try
                {
                    action(attempt);
                    break; // The action was successful if we got here, exit the loop.
                }
                catch (Exception ex)
                {
                    if (!detect.IsTransient(ex))
                        throw; // Error is not transient, send it up the stack.

                    if (!m_retryStrategy.ShouldRetry(attempt, ex, out TimeSpan delay))
                        throw; // We've maxed out our retry attempts, send it up.

                    Thread.Sleep(delay);
                }
            }
        }

        /// <summary>
        /// Executes the supplied action
        /// </summary>
        /// <param name="action">The action to execute</param>
        public void Execute(Action<int> action)
        {
            InnerExecute(action);
        }

        /// <summary>
        /// Executes the supplied function
        /// </summary>
        /// <typeparam name="T">The return type of the function</typeparam>
        /// <param name="action">The function to execute.</param>
        public T Execute<T>(Func<int, T> action)
        {
            T rval = default(T); // Default is not actually used.

            InnerExecute(attempt => rval = action(attempt));

            return rval;
        }
    }
}
