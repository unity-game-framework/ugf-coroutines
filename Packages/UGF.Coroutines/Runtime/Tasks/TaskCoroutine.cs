using System;
using System.Collections;
using System.Threading.Tasks;

namespace UGF.Coroutines.Runtime.Tasks
{
    public class TaskCoroutine : Coroutine
    {
        public Task Task { get; }

        public TaskCoroutine(Task task)
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
        }
    }
}
