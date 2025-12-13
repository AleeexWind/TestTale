using TestTale.Common;
using TestTale.Parameterless.Verifications;

namespace TestTale.Parameterless.TestBuilders
{
    /// <summary>
    /// Transition class which register a verification with access to run a test
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TResult}" path="//typeparam"/>
    public class TestVerificationToRunnerBuilder<TSutDependencies, TSut, TResult> where TSutDependencies : ISutDependencies<TSut>
    {
        private readonly TestVerificationBuilder<TSutDependencies, TSut, TResult> _testVerificationBuilder;
        private readonly TestRunner _testRunner;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="testRunner"></param>
        /// <param name="testVerificationBuilder"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TestVerificationToRunnerBuilder(
            TestVerificationBuilder<TSutDependencies, TSut, TResult> testVerificationBuilder,
            TestRunner testRunner)
        {
            _testVerificationBuilder = testVerificationBuilder ?? throw new ArgumentNullException(nameof(testVerificationBuilder));
            _testRunner = testRunner ?? throw new ArgumentNullException(nameof(testRunner));
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
