namespace UGF.Coroutines.Runtime
{
    /// <summary>
    /// Represents a coroutine with result of the specified type.
    /// </summary>
    public interface ICoroutine<out TResult> : ICoroutine
    {
        /// <summary>
        /// Gets the result of the coroutine.
        /// </summary>
        /// <remarks>
        /// In default implementation this property throws exception, if there is no any result.
        /// Use 'HasResult' property before access this property.
        /// </remarks>
        TResult Result { get; }

        /// <summary>
        /// Gets the value that determines whether this coroutine has result.
        /// </summary>
        /// <remarks>
        /// In default implementation when the type of the result is 'ValueType' this property always true.
        /// </remarks>
        bool HasResult { get; }

        /// <summary>
        /// Invoked after coroutine becomes completed.
        /// </summary>
        new event CoroutineHandler<TResult> Completed;
    }
}
