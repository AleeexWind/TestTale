using TestTale.Common;
using TestTale.Complete.Attempts;
using TestTale.Complete.Parameters;
using TestTale.Complete.Verifications;

namespace TestTale.Complete.TestBuilders
{
    /// <summary>
    /// Transition class which register a verification with access to run a test
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TParameters, TResult}" path="//typeparam"/>
    public class TestVerificationToRunnerBuilder<TSutDependencies, TSut, TParameters, TResult> where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
    {
        private readonly TestVerificationBuilder<TSutDependencies, TSut, TParameters, TResult> _testVerificationBuilder;
        private readonly TestRunner _testRunner;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="testVerificationBuilder"></param>
        /// <param name="testRunner"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TestVerificationToRunnerBuilder(
            TestVerificationBuilder<TSutDependencies, TSut, TParameters, TResult> testVerificationBuilder,
            TestRunner testRunner)
        {
            _testVerificationBuilder = testVerificationBuilder ?? throw new ArgumentNullException(nameof(testVerificationBuilder));
            _testRunner = testRunner ?? throw new ArgumentNullException(nameof(testRunner));
        }
        /// <summary>
        /// Register the verification
        /// </summary>
        /// <param name="verification">A class representing a verification</param>
        /// <returns>An instance of <see cref="TestVerificationToRunnerBuilder&lt;TSutDependencies, TSut, TParameters, TResult&gt;"/></returns>
        public TestVerificationToRunnerBuilder<TSutDependencies, TSut, TParameters, TResult> Then(Verification<TSutDependencies, TSut, TParameters, TResult> verification)
        {
            return _testVerificationBuilder.Then(verification);
        }
        /// <summary>
        /// The method which runs a test asynchronously
        /// </summary>
        /// <returns>A task of the method</returns>
        public async Task RunAsync()
        {
            await _testRunner.RunAsync();
        }
        /// <summary>
        /// The method which runs a test
        /// </summary>
        public void Run()
        {
            _testRunner.Run();
        }
    }
}
