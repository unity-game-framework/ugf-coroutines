using System;
using System.Collections;
using NUnit.Framework;
using UnityEngine.TestTools;

namespace UGF.Coroutines.Runtime.Tests
{
    public class TestCoroutineWithResult
    {
        private class Target
        {
        }

        private class TestCoroutine : Coroutine<Target>
        {
            public bool IsStarted { get; private set; }
            public bool IsEnded { get; private set; }

            protected override IEnumerator Routine()
            {
                IsStarted = true;

                yield return null;

                IsEnded = true;

                Result = new Target();
            }
        }

        private class TestCoroutine2 : Coroutine<int>
        {
            protected override IEnumerator Routine()
            {
                yield return null;
            }
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
            ICoroutine coroutine = new TestCoroutine();

            coroutine.Completed += coroutine1 => completed = true;

            Assert.False(completed);

            yield return coroutine;

            Assert.True(completed);
        }

        [UnityTest]
        public IEnumerator CompletedWithResult()
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
        public IEnumerator Result()
        {
            var coroutine = new TestCoroutine();

            Assert.Throws<InvalidOperationException>(() =>
            {
                // ReSharper disable once UnusedVariable
                Target result = coroutine.Result;
            });

            yield return coroutine;

            Assert.DoesNotThrow(() =>
            {
                // ReSharper disable once UnusedVariable
                Target result = coroutine.Result;
            });
        }

        [UnityTest]
        public IEnumerator HasResult()
        {
            var coroutine = new TestCoroutine();

            Assert.False(coroutine.HasResult);

            yield return coroutine;

            Assert.True(coroutine.HasResult);
        }

        [UnityTest]
        public IEnumerator HasResultValueType()
        {
            var coroutine = new TestCoroutine2();

            Assert.True(coroutine.HasResult);

            yield return coroutine;

            Assert.True(coroutine.HasResult);
        }
    }
}
