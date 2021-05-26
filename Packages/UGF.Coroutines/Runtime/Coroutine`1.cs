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
        public bool IsCompleted { get; private set; }
        public TResult Result { get { return HasResult ? m_result : throw new InvalidOperationException("Value not specified."); } }
        public bool HasResult { get { return m_resultType.IsValueType || !EqualityComparer<TResult>.Default.Equals(m_result, default); } }

        public event CoroutineHandler<TResult> Completed;

        event CoroutineHandler ICoroutine.Completed { add { m_completed += value; } remove { m_completed -= value; } }
        object IEnumerator.Current { get { return m_enumerator ??= Enumerator(); } }

        private readonly Type m_resultType = typeof(TResult);
        private TResult m_result;
        private CoroutineHandler m_completed;
        private IEnumerator m_enumerator;

        /// <summary>
        /// Routine implementation.
        /// </summary>
        /// <remarks>
        /// Use this method to implement custom routine.
        /// </remarks>
        protected abstract IEnumerator Routine();

        protected void SetResult(TResult result)
        {
            if (m_resultType.IsClass && EqualityComparer<TResult>.Default.Equals(result, default)) throw new ArgumentNullException(nameof(result));

            m_result = result;
        }

        protected void ClearResult()
        {
            m_result = default;
        }

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

            m_completed?.Invoke(this);
        }
    }
}
