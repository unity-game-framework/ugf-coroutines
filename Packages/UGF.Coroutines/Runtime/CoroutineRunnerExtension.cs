using System;
using System.Collections;
using System.Threading.Tasks;

namespace UGF.Coroutines.Runtime
{
    public static class CoroutineRunnerExtension
    {
        public static async Task RunAsync(this CoroutineRunner runner, IEnumerator routine)
        {
            if (runner == null) throw new ArgumentNullException(nameof(runner));
            if (routine == null) throw new ArgumentNullException(nameof(routine));

            runner.Start(routine);

            while (runner.IsRunning)
            {
                await Task.Yield();
            }
        }
    }
}
