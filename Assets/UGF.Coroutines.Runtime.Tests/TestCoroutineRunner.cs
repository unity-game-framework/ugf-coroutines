using System.Collections;
using NUnit.Framework;
using UGF.Coroutines.Runtime.Unity;
using UnityEngine.TestTools;

namespace UGF.Coroutines.Runtime.Tests
{
    public class TestCoroutineRunner
    {
        [UnityTest]
        public IEnumerator IsRunning()
        {
            var executer = new CoroutineExecuterGameObject();
            var runner = new CoroutineRunner(executer);

            executer.Initialize();

            runner.Start(WaitForUpdateRoutine(3));

            yield return null;

            Assert.True(runner.IsRunning);

            yield return null;
            yield return null;

            Assert.False(runner.IsRunning);

            executer.Uninitialize();
        }

        [UnityTest]
        public IEnumerator Start()
        {
            var executer = new CoroutineExecuterGameObject();
            var runner = new CoroutineRunner(executer);

            executer.Initialize();

            runner.Start(WaitForUpdateRoutine(2));

            yield return null;

            Assert.True(runner.IsRunning);

            runner.Start(WaitForUpdateRoutine(3));

            yield return null;
            yield return null;

            Assert.True(runner.IsRunning);

            yield return null;

            Assert.False(runner.IsRunning);

            executer.Uninitialize();
        }

        [UnityTest]
        public IEnumerator Stop()
        {
            var executer = new CoroutineExecuterGameObject();
            var runner = new CoroutineRunner(executer);

            executer.Initialize();

            runner.Start(WaitForUpdateRoutine(10));

            yield return null;
            yield return null;
            yield return null;
            yield return null;

            Assert.True(runner.IsRunning);

            runner.Stop();

            Assert.False(runner.IsRunning);

            yield return null;

            Assert.False(runner.IsRunning);

            executer.Uninitialize();
        }

        private IEnumerator WaitForUpdateRoutine(int count)
        {
            for (int i = 0; i < count; i++)
            {
                yield return null;
            }
        }
    }
}
