using System;
using System.Collections;
using UGF.Coroutines.Runtime.Unity;
using UnityEngine;

namespace UGF.Coroutines.Runtime
{
    public class CoroutineRunner
    {
        public ICoroutineExecuter Executer { get; }
        public bool IsRunning { get { return m_enumerator != null; } }

        private IEnumerator m_enumerator;

        public CoroutineRunner(ICoroutineExecuter executer)
        {
            Executer = executer ?? throw new ArgumentNullException(nameof(executer));
        }

        public CoroutineRunner(MonoBehaviour component)
        {
            Executer = new CoroutineExecuterUnity(component);
        }

        public void Start(IEnumerator enumerator)
        {
            if (enumerator == null) throw new ArgumentNullException(nameof(enumerator));

            Stop();

            m_enumerator = Routine(enumerator);

            Executer.Start(m_enumerator);
        }

        public void Stop()
        {
            if (m_enumerator != null)
            {
                Executer.Stop(m_enumerator);

                m_enumerator = null;
            }
        }

        private IEnumerator Routine(IEnumerator enumerator)
        {
            yield return enumerator;

            m_enumerator = null;
        }
    }
}
