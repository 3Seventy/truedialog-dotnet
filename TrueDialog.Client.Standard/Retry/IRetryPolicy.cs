using System;

namespace TrueDialog.Retry
{
    /// <summary>
    /// Interface for a class that will execute the supplied action with a retry logic.
    /// </summary>
    public interface IRetryPolicy
    {
        /// <summary />
        /// <param name="action">The action to execute</param>
        void Execute(Action<int> action);

        /// <summary />
        /// <typeparam name="T">The function return type</typeparam>
        /// <param name="action">The function to execute.</param>
        T Execute<T>(Func<int, T> action);
    }
}
