using System.Collections;

namespace UGF.Coroutines.Runtime
{
    /// <summary>
    /// Represents a coroutine without any result.
    /// </summary>
    public interface ICoroutine : IEnumerator
    {
        /// <summary>
        /// Gets the value that determines whether coroutine is completed.
        /// </summary>
        bool IsCompleted { get; }

        /// <summary>
        /// Invoked after coroutine becomes completed.
        /// </summary>
        event CoroutineHandler Completed;
    }
}
