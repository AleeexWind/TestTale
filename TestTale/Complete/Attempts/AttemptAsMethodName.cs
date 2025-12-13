using System.Reflection;
using TestTale.Common;
using TestTale.Complete.Parameters;

namespace TestTale.Complete.Attempts
{
    /// <summary>
    /// <inheritdoc cref="Attempt{TSut, TParameters, TParameters, TResult}" path="//typeparam"/>
    /// This attempt is presented as a method name
    /// </summary>
    public class AttemptAsMethodName<TSutDependencies, TSut, TParameters, TResult> : Attempt<TSutDependencies, TSut, TParameters, TResult>, IAttemptInvokeable where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
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
                    Func<TParameters, TResult> attemptFunc = (Func<TParameters, TResult>)Delegate.CreateDelegate(
                        typeof(Func<TParameters, TResult>),
                        Sut,
                        _methodInfo);
                    return attemptFunc(Parameters);
                };
            }
        }
    }
}
