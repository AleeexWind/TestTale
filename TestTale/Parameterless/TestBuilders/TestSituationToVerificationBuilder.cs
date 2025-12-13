using TestTale.Parameterless.Situations;
using TestTale.Parameterless.Verifications;

namespace TestTale.Parameterless.TestBuilders
{
    /// <summary>
    /// Transition class which register a situation with access to verivication registration
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TResult}" path="//typeparam"/>
    public class TestSituationToVerificationBuilder<TSutDependencies, TSut, TResult> where TSutDependencies : ISutDependencies<TSut>
    {
        private readonly TestSituationBuilder<TSutDependencies, TSut, TResult> _testSituationBuilder;
        private readonly TestVerificationBuilder<TSutDependencies, TSut, TResult> _testVerificationBuilder;
        /// <summary>
        /// Transition class which register a situation with access to verification registration
        /// </summary>
        /// <param name="testSituationBuilder"></param>
        /// <param name="testVerificationBuilder"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TestSituationToVerificationBuilder(
            TestSituationBuilder<TSutDependencies, TSut, TResult> testSituationBuilder,
            TestVerificationBuilder<TSutDependencies, TSut, TResult> testVerificationBuilder)
        {
            _testSituationBuilder = testSituationBuilder ?? throw new ArgumentNullException(nameof(testSituationBuilder));
            _testVerificationBuilder = testVerificationBuilder ?? throw new ArgumentNullException(nameof(testVerificationBuilder));
        }
        /// <summary>
        /// Register the situation
        /// </summary>
        /// <param name="situation">A class representing a situation</param>
        /// <returns>The current instance of <see cref="TestRunner"/></returns>
        public TestSituationToVerificationBuilder<TSutDependencies, TSut, TResult> WithSituation(Situation<TSutDependencies, TSut, TResult> situation)
        {
            return _testSituationBuilder.WithSituation(situation);
        }
        /// <summary>
        /// Register the verification
        /// </summary>
        /// <param name="verification">A class representing a verification</param>
        /// <returns>The current instance of <see cref="TestRunner"/></returns>
        public TestVerificationToRunnerBuilder<TSutDependencies, TSut, TResult> Then(Verification<TSutDependencies, TSut, TResult> verification)
        {
            return _testVerificationBuilder.Then(verification);
        }
    }
}
