using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Coroutines.Runtime.Unity
{
    public class CoroutineExecuterGameObject : CoroutineExecuterComponentBase
    {
        public string Name { get; }

        private MonoBehaviour m_component;

        public CoroutineExecuterGameObject(string name = "CoroutineExecuterUnity")
        {
            if (string.IsNullOrEmpty(name)) throw new ArgumentException("Value cannot be null or empty.", nameof(name));

            Name = name;
        }

        protected override void OnCreate()
        {
            m_component = new GameObject(Name).AddComponent<CoroutineExecuterBehaviour>();
        }

        protected override void OnDestroy()
        {
            Object.Destroy(m_component.gameObject);
        }

        protected override MonoBehaviour OnGetComponent()
        {
            return m_component;
        }
    }
}
