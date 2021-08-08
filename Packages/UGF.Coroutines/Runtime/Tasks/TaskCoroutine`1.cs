using System;
using System.Collections;
using System.Threading.Tasks;

namespace UGF.Coroutines.Runtime.Tasks
{
    public class TaskCoroutine<TResult> : Coroutine<TResult>
    {
        public Task<TResult> Task { get; }

        public TaskCoroutine(Task<TResult> task)
        {
            Task = task ?? throw new ArgumentNullException(nameof(task));
        }

        protected override IEnumerator Routine()
        {
            while (!Task.IsCompleted)
            {
                yield return null;
            }

            if (Task.IsFaulted)
            {
                throw Task.Exception ?? throw new Exception("Task has faulted.");
            }

            if (Task.Result != null)
            {
                SetResult(Task.Result);
            }
        }
    }
}
