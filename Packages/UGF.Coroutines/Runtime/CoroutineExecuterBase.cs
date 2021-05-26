using System;
using System.Collections;
using UGF.Initialize.Runtime;

namespace UGF.Coroutines.Runtime
{
    public abstract class CoroutineExecuterBase : InitializeBase, ICoroutineExecuter
    {
        public virtual bool IsActive { get; protected set; }

        public event CoroutineEnumeratorHandler Started;
        public event CoroutineEnumeratorHandler Stopped;
        public event Action Cleared;

        public void SetActive(bool value)
        {
            OnSetActive(value);
        }

        public void Start(IEnumerator enumerator)
        {
            if (enumerator == null) throw new ArgumentNullException(nameof(enumerator));

            OnStart(enumerator);

            Started?.Invoke(enumerator);
        }

        public void Stop(IEnumerator enumerator)
        {
            if (enumerator == null) throw new ArgumentNullException(nameof(enumerator));

            OnStop(enumerator);

            Stopped?.Invoke(enumerator);
        }

        public void Clear()
        {
            OnClear();

            Cleared?.Invoke();
        }

        protected virtual void OnSetActive(bool value)
        {
            IsActive = value;
        }

        protected abstract void OnStart(IEnumerator enumerator);
        protected abstract void OnStop(IEnumerator enumerator);
        protected abstract void OnClear();
    }
}
