using TestTale.Parameterless.Attempts;

namespace TestTale.Parameterless.Verifications
{
    /// <summary>
    /// The class representing a verification that must be passed for successful testing
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TResult}" path="//typeparam"/>
    public abstract class Verification<TSutDependencies, TSut, TResult> where TSutDependencies : ISutDependencies<TSut>
    {
        private Attempt<TSutDependencies, TSut, TResult>? _attempt;
        /// <summary>
        /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TResult}" path="//typeparam"/>
        /// </summary>
        protected Attempt<TSutDependencies, TSut, TResult> Attempt
        {
            get
            {
                if (_attempt is null)
                {
                    throw new ArgumentNullException(nameof(Attempt), $"{nameof(Attempt)} can not be null");
                }
                return _attempt;
            }
        }
        /// <summary>
        /// The method runs the verification
        /// </summary>
        public abstract void Verify();
        /// <summary>
        /// The method which binds the current verification to the provided attempt
        /// </summary>
        /// <param name="attempt"></param>
        /// <exception cref="ArgumentNullException">An exception raising if the attempt is invalid</exception>
        public void BindToTheAttempt(Attempt<TSutDependencies, TSut, TResult> attempt)
        {
            if (attempt is null || attempt.SutDependencies is null)
            {
                throw new ArgumentNullException(nameof(attempt), $"{nameof(attempt)} is not valid");
            }
            attempt.Verifications.Add(this);
            _attempt = attempt;
        }
    }
}
