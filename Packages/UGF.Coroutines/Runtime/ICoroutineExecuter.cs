using System.Collections;

namespace UGF.Coroutines.Runtime
{
    public interface ICoroutineExecuter
    {
        void Start(IEnumerator routine);
        void Stop(IEnumerator routine);
    }
}
