namespace TrueDialog.Retry.Strategy
{
    /// <summary>
    /// An exponential retry strategy.
    /// </summary>
    /// <remarks>
    /// Exponential retry strategies will add an ever increasing amount of time.
    /// </remarks>
    /// /// <example>
    /// The times returned might look like the following:
    /// 500ms, 1000ms, 2000ms, 4000ms, and so on.
    /// </example>
    public class ExponentialRetryStrategy : RetryStrategy
    {
        /// <summary />
        public override string Name
        {
            get { return "Exponential Retry"; }
        }

        /// <summary />
        protected override double GetDelay(int attempt)
        {
            int scale = 1 << (attempt - 1);

            return Interval.Milliseconds * scale;
        }
    }
}
