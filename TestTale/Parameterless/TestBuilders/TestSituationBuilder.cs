using TestTale.Parameterless.Attempts;
using TestTale.Parameterless.Situations;

namespace TestTale.Parameterless.TestBuilders
{
    /// <summary>
    /// The class which register a situation
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TResult}" path="//typeparam"/>
    public class TestSituationBuilder<TSutDependencies, TSut, TResult> where TSutDependencies : ISutDependencies<TSut>
    {
        private readonly Attempt<TSutDependencies, TSut, TResult> _attempt;
        private readonly TestVerificationBuilder<TSutDependencies, TSut, TResult> _testVerificationBuilder;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="attempt"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TestSituationBuilder(Attempt<TSutDependencies, TSut, TResult> attempt)
        {
            _attempt = attempt ?? throw new ArgumentNullException(nameof(attempt));
            _testVerificationBuilder = new TestVerificationBuilder<TSutDependencies, TSut, TResult>(_attempt);
        }
        /// <summary>
        /// Register that there are no situation
        /// </summary>
        /// <returns>The current instance of <see cref="TestVerificationBuilder&lt;TSutDependencies, TSut, TResult&gt;"/></returns>
        public TestVerificationBuilder<TSutDependencies, TSut, TResult> WithNoSituation()
        {
            return _testVerificationBuilder;
        }
        /// <summary>
        /// Register the situation
        /// </summary>
        /// <param name="situation">A class representing a situation</param>
        /// <returns>The current instance of <see cref="TestSituationToVerificationBuilder&lt;TSutDependencies, TSut, TResult&gt;"/></returns>
        public TestSituationToVerificationBuilder<TSutDependencies, TSut, TResult> WithSituation(Situation<TSutDependencies, TSut, TResult> situation)
        {
            situation.BindToTheAttempt(_attempt);
            return new TestSituationToVerificationBuilder<TSutDependencies, TSut, TResult>(this, _testVerificationBuilder);
        }
    }
}
