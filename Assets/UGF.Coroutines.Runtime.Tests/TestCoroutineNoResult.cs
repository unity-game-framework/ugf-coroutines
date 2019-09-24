using System.Collections;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace UGF.Coroutines.Runtime.Tests
{
    public class TestCoroutineNoResult
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

            protected override IEnumerator Routine()
            {
                IsStarted = true;

                yield break;
            }
        }

        private class TestCoroutine3 : Coroutine
        {
            public bool Level0 { get; private set; }
            public bool Level1 { get; private set; }
            public bool Level2 { get; private set; }

            protected override IEnumerator Routine()
            {
                Level0 = true;

                yield return Routine1();
            }

            private IEnumerator Routine1()
            {
                Level1 = true;

                yield return Routine2();
            }

            private IEnumerator Routine2()
            {
                Level2 = true;

                yield return null;
            }
        }

        private class CoroutineExecuter : MonoBehaviour
        {
        }

        [UnityTest]
        public IEnumerator IsCompleted()
        {
            var coroutine = new TestCoroutine();

            Assert.False(coroutine.IsCompleted);

            yield return coroutine;

            Assert.True(coroutine.IsCompleted);
        }

        [UnityTest]
        public IEnumerator Completed()
        {
            bool completed = false;
            var coroutine = new TestCoroutine();

            coroutine.Completed += coroutine1 => completed = true;

            Assert.False(completed);

            yield return coroutine;

            Assert.True(completed);
        }

        [UnityTest]
        public IEnumerator Routine()
        {
            var coroutine = new TestCoroutine();

            Assert.False(coroutine.IsStarted);
            Assert.False(coroutine.IsEnded);

            yield return coroutine;

            Assert.True(coroutine.IsStarted);
            Assert.True(coroutine.IsEnded);
        }

        [UnityTest]
        public IEnumerator RoutineBreak()
        {
            var coroutine = new TestCoroutine2();

            Assert.False(coroutine.IsStarted);
            Assert.False(coroutine.IsCompleted);

            yield return coroutine;

            Assert.True(coroutine.IsStarted);
            Assert.True(coroutine.IsCompleted);
        }

        [UnityTest]
        public IEnumerator RoutineBreakWithStart()
        {
            var executer = new GameObject().AddComponent<CoroutineExecuter>();
            var coroutine = new TestCoroutine2();

            Assert.False(coroutine.IsStarted);
            Assert.False(coroutine.IsCompleted);

            executer.StartCoroutine(coroutine);

            Assert.True(coroutine.IsStarted);
            Assert.False(coroutine.IsCompleted);

            yield return null;

            Assert.True(coroutine.IsStarted);
            Assert.True(coroutine.IsCompleted);
        }

        [UnityTest]
        public IEnumerator Started()
        {
            var executer = new GameObject().AddComponent<CoroutineExecuter>();
            var coroutine = new TestCoroutine();

            Assert.False(coroutine.IsCompleted);
            Assert.False(coroutine.IsStarted);
            Assert.False(coroutine.IsEnded);

            executer.StartCoroutine(coroutine);

            Assert.False(coroutine.IsCompleted);
            Assert.True(coroutine.IsStarted);
            Assert.False(coroutine.IsEnded);

            yield return coroutine;

            Assert.True(coroutine.IsCompleted);
            Assert.True(coroutine.IsStarted);
            Assert.True(coroutine.IsEnded);
        }

        [UnityTest]
        public IEnumerator Levels()
        {
            var executer = new GameObject().AddComponent<CoroutineExecuter>();
            var coroutine = new TestCoroutine3();

            Assert.False(coroutine.IsCompleted);
            Assert.False(coroutine.Level0);
            Assert.False(coroutine.Level1);
            Assert.False(coroutine.Level2);

            executer.StartCoroutine(coroutine);

            Assert.False(coroutine.IsCompleted);
            Assert.True(coroutine.Level0);
            Assert.True(coroutine.Level1);
            Assert.True(coroutine.Level2);

            yield return coroutine;

            Assert.True(coroutine.IsCompleted);
        }
    }
}
