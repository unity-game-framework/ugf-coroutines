using System.Collections;
using System.Threading.Tasks;
using NUnit.Framework;
using UGF.Coroutines.Runtime.Tasks;
using UnityEngine.TestTools;

namespace UGF.Coroutines.Runtime.Tests.Tasks
{
    public class TestTaskCoroutine
    {
        private class Target
        {
            public bool Completed { get; set; }
        }

        [UnityTest]
        public IEnumerator TaskNoResult()
        {
            var target = new Target();

            yield return TaskMethod(target).CreateCoroutine();

            Assert.True(target.Completed);
        }

        [UnityTest]
        public IEnumerator TaskWithResult()
        {
            TaskCoroutine<Target> coroutine = TaskMethod2().CreateCoroutine();

            yield return coroutine;

            Target result = coroutine.Result;

            Assert.NotNull(result);
            Assert.True(result.Completed);
        }

        private static async Task TaskMethod(Target target)
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Yield();
            }

            target.Completed = true;
        }

        private static async Task<Target> TaskMethod2()
        {
            for (int i = 0; i < 10; i++)
            {
                await Task.Yield();
            }

            return new Target { Completed = true };
        }
    }
}
