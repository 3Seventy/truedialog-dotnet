namespace TrueDialog.Retry.Strategy
{
    /// <summary>
    /// In incrementing retry strategy.
    /// </summary>
    /// <remarks>
    /// An incrementing retry strategy will add a fixed amount of time to each attempt.
    /// </remarks>
    /// <example>
    /// The times returned might look like the following:
    /// 500ms, 1000ms, 1500ms, 2000ms, and so on.
    /// </example>
    public class IncrementalRetryStrategy : RetryStrategy
    {
        /// <summary />
        public override string Name
        {
            get { return "Incremental Retry"; }
        }

        /// <summary />
        protected override double GetDelay(int attempt)
        {
            return Interval.TotalMilliseconds * attempt;
        }
    }
}
