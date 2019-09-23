using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Coroutines.Runtime.Unity
{
    public class CoroutineExecuterUnity : ICoroutineExecuter, IDisposable
    {
        public CoroutineExecuterUnityMonoBehaviour MonoBehaviour { get; }

        public CoroutineExecuterUnity(bool dontDestroyOnLoad = false, string gameObjectName = "CoroutineExecuterUnity")
        {
            if (gameObjectName == null) throw new ArgumentNullException(nameof(gameObjectName));

            MonoBehaviour = new GameObject(gameObjectName).AddComponent<CoroutineExecuterUnityMonoBehaviour>();

            if (dontDestroyOnLoad)
            {
                Object.DontDestroyOnLoad(MonoBehaviour);
            }
        }

        public void Dispose()
        {
            Object.Destroy(MonoBehaviour.gameObject);
        }

        public void Start(IEnumerator routine)
        {
            if (routine == null) throw new ArgumentNullException(nameof(routine));

            MonoBehaviour.StartCoroutine(routine);
        }

        public void Stop(IEnumerator routine)
        {
            if (routine == null) throw new ArgumentNullException(nameof(routine));

            MonoBehaviour.StopCoroutine(routine);
        }
    }
}
