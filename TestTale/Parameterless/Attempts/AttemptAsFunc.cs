namespace TestTale.Parameterless.Attempts
{
    /// <summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TResult}" path="//typeparam"/>
    /// This attempt is presented as a function
    /// </summary>
    public class AttemptAsFunc<TSutDependencies, TSut, TResult> : Attempt<TSutDependencies, TSut, TResult> where TSutDependencies : ISutDependencies<TSut>
    {
        private readonly Func<TResult> _attemptFunc;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="attemptFunc">The function which is an attempt</param>
        public AttemptAsFunc(Func<TResult> attemptFunc)
        {
            _attemptFunc = attemptFunc;
        }
        /// <summary>
        /// The function which is an attempt
        /// </summary>
        public override Func<TResult> AttemptFunc
        {
            get
            {
                return () =>
                {
                    return _attemptFunc();
                };
            }
        }
    }
}
