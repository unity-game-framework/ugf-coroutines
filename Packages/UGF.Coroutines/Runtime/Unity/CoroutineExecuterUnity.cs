using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Coroutines.Runtime.Unity
{
    /// <summary>
    /// Represents coroutine executer implementation using Unity coroutine executer.
    /// </summary>
    /// <remarks>
    /// Use the dispose method to destroy created gameObject with component when the executer no needed anymore.
    /// </remarks>
    public class CoroutineExecuterUnity : ICoroutineExecuter, IDisposable
    {
        /// <summary>
        /// Gets the component used to execute coroutines.
        /// </summary>
        public CoroutineExecuterUnityMonoBehaviour MonoBehaviour { get; }

        /// <summary>
        /// Gets the value that determines whether to don't destroy on load created gameObject.
        /// </summary>
        public bool DontDestroyOnLoad { get; }

        /// <summary>
        /// Gets the value that determines whether created gameObject still present and can be used.
        /// </summary>
        public bool IsAlive { get { return MonoBehaviour != null; } }

        /// <summary>
        /// Creates executer with the specified gameObject name.
        /// </summary>
        /// <param name="gameObjectName"></param>
        /// <param name="dontDestroyOnLoad">The value that determines whether to don't destroy on load created gameObject.</param>
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

        /// <summary>
        /// Destroy created gameObject.
        /// </summary>
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
