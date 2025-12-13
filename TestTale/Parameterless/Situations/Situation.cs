using TestTale.Parameterless.Attempts;

namespace TestTale.Parameterless.Situations
{
    /// <summary>
    /// The class representing some situation which accures during the test.
    /// For example when an external source or a mocked class return some specific data
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TResult}" path="//typeparam"/>
    public abstract class Situation<TSutDependencies, TSut, TResult> where TSutDependencies : ISutDependencies<TSut>
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
        /// Encapsulate an action of the situation. Includes instructions about what happens during the test execution.
        /// </summary>
        public abstract Action Action { get; }
        /// <summary>
        /// The method which binds the current situation to the provided attempt
        /// </summary>
        /// <param name="attempt"></param>
        /// <exception cref="ArgumentNullException">An exception raising if the attempt is invalid</exception>
        public void BindToTheAttempt(Attempt<TSutDependencies, TSut, TResult> attempt)
        {
            if (attempt is null || attempt.SutDependencies is null)
            {
                throw new ArgumentNullException(nameof(attempt), $"{nameof(attempt)} is not valid");
            }
            attempt.Situations.Add(this);
            _attempt = attempt;
        }
    }
}
