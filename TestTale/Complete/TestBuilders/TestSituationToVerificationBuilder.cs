using TestTale.Complete.Parameters;
using TestTale.Complete.Situations;
using TestTale.Complete.Verifications;

namespace TestTale.Complete.TestBuilders
{
    /// <summary>
    /// Transition class which register a situation with access to verivication registration
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TParameters, TResult}" path="//typeparam"/>
    public class TestSituationToVerificationBuilder<TSutDependencies, TSut, TParameters, TResult> where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
    {
        private readonly TestSituationBuilder<TSutDependencies, TSut, TParameters, TResult> _testSituationBuilder;
        private readonly TestVerificationBuilder<TSutDependencies, TSut, TParameters, TResult> _testVerificationBuilder;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="testSituationBuilder"></param>
        /// <param name="testVerificationBuilder"></param>
        public TestSituationToVerificationBuilder(
            TestSituationBuilder<TSutDependencies, TSut, TParameters, TResult> testSituationBuilder,
            TestVerificationBuilder<TSutDependencies, TSut, TParameters, TResult> testVerificationBuilder)
        {
            _testSituationBuilder = testSituationBuilder ?? throw new ArgumentNullException(nameof(testSituationBuilder));
            _testVerificationBuilder = testVerificationBuilder ?? throw new ArgumentNullException(nameof(testVerificationBuilder));
        }
        /// <summary>
        /// Register the situation
        /// </summary>
        /// <param name="situation">A class representing a situation</param>
        /// <returns>The current instance of <see cref="TestRunner"/></returns>
        public TestSituationToVerificationBuilder<TSutDependencies, TSut, TParameters, TResult> WithSituation(Situation<TSutDependencies, TSut, TParameters, TResult> situation)
        {
            return _testSituationBuilder.WithSituation(situation);
        }
        /// <summary>
        /// Register the verification
        /// </summary>
        /// <param name="verification">A class representing a verification</param>
        /// <returns>The current instance of <see cref="TestRunner"/></returns>
        public TestVerificationToRunnerBuilder<TSutDependencies, TSut, TParameters, TResult> Then(Verification<TSutDependencies, TSut, TParameters, TResult> verification)
        {
            return _testVerificationBuilder.Then(verification);
        }
    }
}
