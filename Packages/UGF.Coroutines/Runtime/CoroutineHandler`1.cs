namespace UGF.Coroutines.Runtime
{
    public delegate void CoroutineHandler<in TResult>(ICoroutine<TResult> coroutine);
}
