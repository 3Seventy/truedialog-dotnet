namespace TrueDialog.Retry.Strategy
{
    /// <summary>
    /// A fixed retry strategy.
    /// </summary>
    /// <remarks>
    /// The fixed retry strategy will retry at a fixed interval.
    /// </remarks>
    public class FixedRetryStrategy : RetryStrategy
    {
        /// <summary />
        public override string Name
        {
            get { return "Fixed Retry"; }
        }

        /// <summary />
        protected override double GetDelay(int attempt)
        {
            return Interval.TotalMilliseconds;
        }
    }
}
