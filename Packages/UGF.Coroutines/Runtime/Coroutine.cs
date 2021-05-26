using System.Collections;

namespace UGF.Coroutines.Runtime
{
    /// <summary>
    /// Represents an abstract implementation of the coroutine without any result.
    /// </summary>
    public abstract class Coroutine : ICoroutine
    {
        public bool IsCompleted { get; private set; }

        public event CoroutineHandler Completed;

        private IEnumerator m_enumerator;

        object IEnumerator.Current { get { return m_enumerator ??= Enumerator(); } }

        /// <summary>
        /// Routine implementation.
        /// </summary>
        /// <remarks>
        /// Use this method to implement custom routine.
        /// </remarks>
        protected abstract IEnumerator Routine();

        bool IEnumerator.MoveNext()
        {
            return !IsCompleted;
        }

        void IEnumerator.Reset()
        {
        }

        private IEnumerator Enumerator()
        {
            yield return Routine();

            IsCompleted = true;

            Completed?.Invoke(this);
        }
    }
}
