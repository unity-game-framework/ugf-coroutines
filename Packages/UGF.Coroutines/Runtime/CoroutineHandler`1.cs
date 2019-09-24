namespace UGF.Coroutines.Runtime
{
    /// <summary>
    /// Delegate used to handle coroutine with result.
    /// </summary>
    /// <param name="coroutine">The coroutine.</param>
    public delegate void CoroutineHandler<in TResult>(ICoroutine<TResult> coroutine);
}
