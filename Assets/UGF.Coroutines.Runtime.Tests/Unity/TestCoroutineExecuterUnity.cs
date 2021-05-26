using System.Collections;
using NUnit.Framework;
using UGF.Coroutines.Runtime.Unity;
using UnityEngine;
using UnityEngine.TestTools;

namespace UGF.Coroutines.Runtime.Tests.Unity
{
    public class TestCoroutineExecuterUnity
    {
        private class TestCoroutine : Coroutine
        {
            public bool IsStarted { get; private set; }
            public bool IsEnded { get; private set; }

            protected override IEnumerator Routine()
            {
                IsStarted = true;

                yield return null;

                IsEnded = true;
            }
        }

        private class TestCoroutine2 : Coroutine
        {
            public bool IsStarted { get; private set; }
            public bool IsEnded { get; private set; }

            protected override IEnumerator Routine()
            {
                IsStarted = true;

                yield return new WaitForSeconds(1F);

                IsEnded = true;
            }
        }

        [Test]
        public void Ctor()
        {
            var executer = new CoroutineExecuterGameObject("Executer");

            executer.Initialize();

            Assert.NotNull(executer.Component);
            Assert.True(executer.Component != null);
            Assert.AreEqual("Executer", executer.Component.gameObject.name);

            executer.Uninitialize();
        }

        [UnityTest]
        public IEnumerator Dispose()
        {
            var executer = new CoroutineExecuterGameObject();

            executer.Initialize();

            Assert.True(executer.Component != null);
            Assert.True(executer.IsComponentExists);

            executer.Uninitialize();

            yield return null;

            Assert.False(executer.IsComponentExists);
        }

        [UnityTest]
        public IEnumerator Start()
        {
            var executer = new CoroutineExecuterGameObject();
            var coroutine = new TestCoroutine();

            executer.Initialize();

            Assert.False(coroutine.IsCompleted);
            Assert.False(coroutine.IsStarted);
            Assert.False(coroutine.IsEnded);

            executer.Start(coroutine);

            Assert.False(coroutine.IsCompleted);
            Assert.True(coroutine.IsStarted);
            Assert.False(coroutine.IsEnded);

            yield return coroutine;

            Assert.True(coroutine.IsCompleted);
            Assert.True(coroutine.IsStarted);
            Assert.True(coroutine.IsEnded);

            executer.Uninitialize();
        }

        [UnityTest]
        public IEnumerator Stop()
        {
            var executer = new CoroutineExecuterGameObject();
            var coroutine = new TestCoroutine2();

            executer.Initialize();

            Assert.False(coroutine.IsCompleted);
            Assert.False(coroutine.IsStarted);
            Assert.False(coroutine.IsEnded);

            executer.Start(coroutine);

            Assert.False(coroutine.IsCompleted);
            Assert.True(coroutine.IsStarted);
            Assert.False(coroutine.IsEnded);

            yield return null;

            executer.Stop(coroutine);

            yield return null;

            Assert.False(coroutine.IsCompleted);
            Assert.True(coroutine.IsStarted);
            Assert.False(coroutine.IsEnded);

            executer.Uninitialize();
        }
    }
}
