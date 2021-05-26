using System;
using System.Collections;
using UGF.Initialize.Runtime;

namespace UGF.Coroutines.Runtime
{
    /// <summary>
    /// Represents a coroutine executer.
    /// </summary>
    public interface ICoroutineExecuter : IInitialize
    {
        bool IsActive { get; }

        event CoroutineEnumeratorHandler Started;
        event CoroutineEnumeratorHandler Stopped;
        event Action Cleared;

        void SetActive(bool value);

        /// <summary>
        /// Starts the specified routine.
        /// </summary>
        /// <param name="enumerator">The routine to start.</param>
        void Start(IEnumerator enumerator);

        /// <summary>
        /// Stops the specified routine.
        /// </summary>
        /// <param name="enumerator">The routine to stop.</param>
        void Stop(IEnumerator enumerator);

        /// <summary>
        /// Clears and stop all coroutines.
        /// </summary>
        void Clear();
    }
}
