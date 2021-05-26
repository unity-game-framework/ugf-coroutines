using System;
using System.Collections;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Coroutines.Runtime.Unity
{
    public class CoroutineExecuterUnity : CoroutineExecuterBase
    {
        public override bool IsActive { get { return Component.enabled; } }
        public MonoBehaviour Component { get { return m_component ? m_component : throw new InvalidOperationException("Component no longer exists."); } }
        public bool IsComponentExists { get { return m_component != null; } }

        private readonly MonoBehaviour m_component;

        public CoroutineExecuterUnity(MonoBehaviour component)
        {
            m_component = component ? component : throw new ArgumentNullException(nameof(component));
        }

        public CoroutineExecuterUnity(string gameObjectName = "CoroutineExecuterUnity")
        {
            m_component = new GameObject(gameObjectName).AddComponent<CoroutineExecuterUnityComponent>();
        }

        public void DestroyComponent()
        {
            Object.Destroy(Component);
        }

        protected override void OnSetActive(bool value)
        {
            Component.enabled = value;
        }

        protected override void OnStart(IEnumerator enumerator)
        {
            Component.StartCoroutine(enumerator);
        }

        protected override void OnStop(IEnumerator enumerator)
        {
            Component.StopCoroutine(enumerator);
        }

        protected override void OnClear()
        {
            Component.StopAllCoroutines();
        }
    }
}
