using TestTale.Common;
using TestTale.Complete.Parameters;

namespace TestTale.Complete.Attempts
{
    /// <summary>
    /// <inheritdoc cref="Attempt{TSut, TParameters, TParameters, TResult}" path="//typeparam"/>
    /// This attempt is presented as a function
    /// </summary>
    public class AttemptAsFunc<TSutDependencies, TSut, TParameters, TResult> : Attempt<TSutDependencies, TSut, TParameters, TResult>, IAttemptInvokeable where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
    {
        private readonly Func<TParameters, TResult> _attemptFunc;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="attemptFunc">The function which is an attempt</param>
        public AttemptAsFunc(Func<TParameters, TResult> attemptFunc)
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
                    return _attemptFunc(Parameters);
                };
            }
        }
    }
}
