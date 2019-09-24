using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Coroutines.Runtime.Unity
{
    public class CoroutineExecuterUnity : ICoroutineExecuter, IDisposable
    {
        public CoroutineExecuterUnityMonoBehaviour MonoBehaviour { get; }
        public bool DontDestroyOnLoad { get; }

        public CoroutineExecuterUnity(string gameObjectName = "CoroutineExecuterUnity", bool dontDestroyOnLoad = false)
        {
            if (gameObjectName == null) throw new ArgumentNullException(nameof(gameObjectName));

            MonoBehaviour = new GameObject(gameObjectName).AddComponent<CoroutineExecuterUnityMonoBehaviour>();
            DontDestroyOnLoad = dontDestroyOnLoad;

            if (DontDestroyOnLoad)
            {
                Object.DontDestroyOnLoad(MonoBehaviour);
            }
        }

        public void Dispose()
        {
            if (MonoBehaviour == null) throw new InvalidOperationException("Can't dispose executer: MonoBehaviour already destroyed.");

            Object.Destroy(MonoBehaviour.gameObject);
        }

        public void Start(IEnumerator routine)
        {
            if (routine == null) throw new ArgumentNullException(nameof(routine));
            if (MonoBehaviour == null) throw new InvalidOperationException("Can't start routine: MonoBehaviour already destroyed.");

            MonoBehaviour.StartCoroutine(routine);
        }

        public void Stop(IEnumerator routine)
        {
            if (routine == null) throw new ArgumentNullException(nameof(routine));
            if (MonoBehaviour == null) throw new InvalidOperationException("Can't stop routine: MonoBehaviour already destroyed.");

            MonoBehaviour.StopCoroutine(routine);
        }
    }
}
