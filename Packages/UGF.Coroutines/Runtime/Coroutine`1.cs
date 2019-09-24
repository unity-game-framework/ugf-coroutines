using System;
using System.Collections;
using System.Collections.Generic;

namespace UGF.Coroutines.Runtime
{
    /// <summary>
    /// Represents an abstract implementation of the coroutine with a result of the specified type.
    /// </summary>
    public abstract class Coroutine<TResult> : ICoroutine<TResult>
    {
        public bool IsCompleted { get { return !m_moveNext; } }

        public TResult Result
        {
            get
            {
                if (!HasResult)
                {
                    throw new InvalidOperationException($"Coroutine result not specified: '{GetType()}'.");
                }

                return m_result;
            }
            protected set { m_result = value; }
        }

        public bool HasResult { get { return typeof(TResult).IsValueType || !EqualityComparer<TResult>.Default.Equals(m_result, default); } }

        public event CoroutineHandler<TResult> Completed;

        event CoroutineHandler ICoroutine.Completed { add { m_completed += value; } remove { m_completed -= value; } }
        object IEnumerator.Current { get { return m_enumerator ?? (m_enumerator = Enumerator()); } }

        private TResult m_result;
        private CoroutineHandler m_completed;
        private IEnumerator m_enumerator;
        private bool m_moveNext = true;

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

            m_completed?.Invoke(this);
        }
    }
}
