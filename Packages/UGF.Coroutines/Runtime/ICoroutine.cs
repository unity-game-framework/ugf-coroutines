using System.Collections;

namespace UGF.Coroutines.Runtime
{
    public interface ICoroutine : IEnumerator
    {
        bool IsCompleted { get; }

        event CoroutineHandler Completed;
    }
}
