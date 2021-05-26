using System;
using System.Collections;
using UnityEngine;

namespace UGF.Coroutines.Runtime.Unity
{
    public abstract class CoroutineExecuterComponentBase : CoroutineExecuterBase
    {
        public override bool IsActive { get { return Component.enabled; } }

        public MonoBehaviour Component
        {
            get
            {
                MonoBehaviour component = OnGetComponent();

                return component ? component : throw new InvalidOperationException("Component no longer exists.");
            }
        }

        public bool IsComponentExists { get { return OnGetComponent() != null; } }

        protected override void OnInitialize()
        {
            base.OnInitialize();

            OnCreate();
        }

        protected override void OnUninitialize()
        {
            base.OnUninitialize();

            OnDestroy();
        }

        protected abstract void OnCreate();
        protected abstract void OnDestroy();
        protected abstract MonoBehaviour OnGetComponent();

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
