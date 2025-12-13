using TestTale.Complete.Attempts;
using TestTale.Complete.Parameters;
using TestTale.Complete.Situations;

namespace TestTale.Complete.TestBuilders
{
    /// <summary>
    /// The class which register a situation
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TParameters, TResult}" path="//typeparam"/>
    public class TestSituationBuilder<TSutDependencies, TSut, TParameters, TResult> where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
    {
        private readonly Attempt<TSutDependencies, TSut, TParameters, TResult> _attempt;
        private readonly TestVerificationBuilder<TSutDependencies, TSut, TParameters, TResult> _testVerificationBuilder;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="attempt"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TestSituationBuilder(Attempt<TSutDependencies, TSut, TParameters, TResult> attempt)
        {
            _attempt = attempt ?? throw new ArgumentNullException(nameof(attempt));
            _testVerificationBuilder = new TestVerificationBuilder<TSutDependencies, TSut, TParameters, TResult>(_attempt);
        }
        /// <summary>
        /// Register that there are no situation
        /// </summary>
        /// <returns>The current instance of <see cref="TestRunner"/></returns>
        public TestVerificationBuilder<TSutDependencies, TSut, TParameters, TResult> WithNoSituation()
        {
            return _testVerificationBuilder;
        }
        /// <summary>
        /// Register the situation
        /// </summary>
        /// <param name="situation">A class representing a situation</param>
        /// <returns>The current instance of <see cref="TestRunner"/></returns>
        public TestSituationToVerificationBuilder<TSutDependencies, TSut, TParameters, TResult> WithSituation(Situation<TSutDependencies, TSut, TParameters, TResult> situation)
        {
            situation.BindToTheAttempt(_attempt);
            return new TestSituationToVerificationBuilder<TSutDependencies, TSut, TParameters, TResult>(this, _testVerificationBuilder);
        }
    }
}
