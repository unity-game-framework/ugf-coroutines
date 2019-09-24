using System.Collections;

namespace UGF.Coroutines.Runtime
{
    /// <summary>
    /// Represents an abstract implementation of the coroutine without any result.
    /// </summary>
    public abstract class Coroutine : ICoroutine
    {
        public bool IsCompleted { get { return !m_moveNext; } }

        public event CoroutineHandler Completed;

        private IEnumerator m_enumerator;
        private bool m_moveNext = true;

        object IEnumerator.Current { get { return m_enumerator ?? (m_enumerator = Enumerator()); } }

        /// <summary>
        /// Routine implementation.
        /// </summary>
        /// <remarks>
        /// Use this method to implement custom routine.
        /// </remarks>
        protected abstract IEnumerator Routine();

        bool IEnumerator.MoveNext()
        {
            return m_moveNext;
        }

        void IEnumerator.Reset()
        {
        }

        private IEnumerator Enumerator()
        {
            yield return Routine();

            m_moveNext = false;

            Completed?.Invoke(this);
        }
    }
}
