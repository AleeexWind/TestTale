using System.Reflection;

namespace TestTale.Parameterless.Attempts
{
    /// <summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TResult}" path="//typeparam"/>
    /// This attempt is presented as a method name
    /// </summary>
    public class AttemptAsMethodName<TSutDependencies, TSut, TResult> : Attempt<TSutDependencies, TSut, TResult> where TSutDependencies : ISutDependencies<TSut>
    {
        private readonly MethodInfo _methodInfo;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public AttemptAsMethodName(MethodInfo methodInfo)
        {
            _methodInfo = methodInfo;
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
                    Func<TResult> attemptFunc = (Func<TResult>)Delegate.CreateDelegate(
                        typeof(Func<TResult>),
                        Sut,
                        _methodInfo);
                    return attemptFunc();
                };
            }
        }
    }
}
