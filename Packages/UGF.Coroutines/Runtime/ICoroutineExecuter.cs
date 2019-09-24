using System.Collections;

namespace UGF.Coroutines.Runtime
{
    /// <summary>
    /// Represents a coroutine executer.
    /// </summary>
    public interface ICoroutineExecuter
    {
        /// <summary>
        /// Starts the specified routine.
        /// </summary>
        /// <param name="routine">The routine to start.</param>
        void Start(IEnumerator routine);

        /// <summary>
        /// Stops the specified routine.
        /// </summary>
        /// <param name="routine">The routine to stop.</param>
        void Stop(IEnumerator routine);
    }
}
