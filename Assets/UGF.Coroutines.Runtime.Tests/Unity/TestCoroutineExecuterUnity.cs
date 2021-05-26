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
            var executer = new CoroutineExecuterUnity("Executer");

            Assert.NotNull(executer.Component);
            Assert.True(executer.Component != null);
            Assert.AreEqual("Executer", executer.Component.gameObject.name);
        }

        [UnityTest]
        public IEnumerator Dispose()
        {
            var executer = new CoroutineExecuterUnity();

            Assert.True(executer.Component != null);
            Assert.True(executer.IsComponentExists);

            executer.DestroyComponent();

            yield return null;

            Assert.False(executer.IsComponentExists);
        }

        [UnityTest]
        public IEnumerator Start()
        {
            var executer = new CoroutineExecuterUnity();
            var coroutine = new TestCoroutine();

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
        }

        [UnityTest]
        public IEnumerator Stop()
        {
            var executer = new CoroutineExecuterUnity();
            var coroutine = new TestCoroutine2();

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
        }
    }
}
