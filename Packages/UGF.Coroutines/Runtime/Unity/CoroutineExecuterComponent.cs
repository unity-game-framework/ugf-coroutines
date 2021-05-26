using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace UGF.Coroutines.Runtime.Unity
{
    public class CoroutineExecuterComponent : CoroutineExecuterComponentBase
    {
        public bool DestroyOnUninitialize { get; }

        private readonly MonoBehaviour m_component;

        public CoroutineExecuterComponent(MonoBehaviour component, bool destroyOnUninitialize = false)
        {
            m_component = component ? component : throw new ArgumentNullException(nameof(component));

            DestroyOnUninitialize = destroyOnUninitialize;
        }

        protected override void OnCreate()
        {
        }

        protected override void OnDestroy()
        {
            if (DestroyOnUninitialize)
            {
                Object.Destroy(m_component);
            }
        }

        protected override MonoBehaviour OnGetComponent()
        {
            return m_component;
        }
    }
}
