using System.Threading.Tasks;

namespace UGF.Coroutines.Runtime.Tasks
{
    public static class TaskCoroutineExtensions
    {
        public static TaskCoroutine CreateCoroutine(this Task task)
        {
            return new TaskCoroutine(task);
        }

        public static TaskCoroutine<T> CreateCoroutine<T>(this Task<T> task)
        {
            return new TaskCoroutine<T>(task);
        }
    }
}
