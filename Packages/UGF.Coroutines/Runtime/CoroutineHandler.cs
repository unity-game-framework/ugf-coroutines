namespace UGF.Coroutines.Runtime
{
    /// <summary>
    /// Delegate used to handle coroutine without any result.
    /// </summary>
    /// <param name="coroutine">The coroutine.</param>
    public delegate void CoroutineHandler(ICoroutine coroutine);
}
