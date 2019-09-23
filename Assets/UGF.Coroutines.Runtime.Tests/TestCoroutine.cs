using System.Collections;
using NUnit.Framework;

namespace UGF.Coroutines.Runtime.Tests
{
    public class TestCoroutine
    {
        private class Target
        {
        }

        private class CoroutineTarget : Coroutine<Target>
        {
            protected override IEnumerator Routine()
            {
                Result = new Target();

                yield break;
            }
        }

        private class CoroutineInt : Coroutine<int>
        {
            protected override IEnumerator Routine()
            {
                Result = 10;

                yield break;
            }
        }

        [Test]
        public void Cast()
        {
            var coroutine0 = new CoroutineTarget();
            var coroutine1 = new CoroutineInt();
            var cast0 = coroutine0 as ICoroutine<object>;
            var cast1 = coroutine1 as ICoroutine<object>;

            Assert.NotNull(cast0);
            Assert.Null(cast1);
        }
    }
}
