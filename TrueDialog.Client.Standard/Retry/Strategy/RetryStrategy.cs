using System;

namespace TrueDialog.Retry
{
    /// <summary>
    /// Wrapper around if we should retry a request.
    /// </summary>
    public abstract class RetryStrategy
    {
        /// <summary>
        /// Gets the name of the retry strategy.
        /// </summary>
        public abstract string Name { get; }

        /// <summary>
        /// Gets or sets the maximum number of tries we should go for.
        /// </summary>
        public byte MaxTries { get; set; }

        /// <summary>
        /// Gets or sets the initial amount of time for a retry.
        /// </summary>
        public TimeSpan Interval { get; set; }

        /// <summary>
        /// Gets or sets the minimum amount of time we should delay by.
        /// </summary>
        public TimeSpan MinInterval { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of time we should delay by.
        /// </summary>
        public TimeSpan MaxInterval { get; set; }

        /// <summary>
        /// Gets the delay we should wait for if we attempt to retry.
        /// </summary>
        /// <param name="attempt"></param>
        protected abstract double GetDelay(int attempt);

        /// <summary>
        /// Checks to see if the call should be retried.
        /// </summary>
        /// <param name="attempt">The attempt # that was tried.</param>
        /// <param name="lastException">The exception (if any) that we got.</param>
        /// <param name="delay">The delay we should wait for before trying again.</param>
        /// <returns>True if we should retry, false if not.</returns>
        public bool ShouldRetry(int attempt, Exception lastException, out TimeSpan delay)
        {
            double delayUSec = GetDelay(attempt);

            delayUSec = Math.Min(delayUSec, MaxInterval.TotalMilliseconds);
            delayUSec = Math.Max(delayUSec, MinInterval.TotalMilliseconds);

            delay = TimeSpan.FromMilliseconds(delayUSec);

            return (attempt < MaxTries);
        }
    }
}
