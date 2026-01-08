using TestTale.Common;
using TestTale.Parameterless.Attempts;
using TestTale.Parameterless.Verifications;

namespace TestTale.Parameterless.TestBuilders
{
    /// <summary>
    /// The class which register a verification
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TResult}" path="//typeparam"/>
    public class TestVerificationBuilder<TSutDependencies, TSut, TResult> where TSutDependencies : ISutDependencies<TSut>
    {
        private readonly Attempt<TSutDependencies, TSut, TResult> _attempt;
        private readonly TestRunner _testRunner;

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="attempt"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TestVerificationBuilder(Attempt<TSutDependencies, TSut, TResult> attempt)
        {
            _attempt = attempt ?? throw new ArgumentNullException(nameof(attempt));
            _testRunner = new TestRunner(_attempt);
        }
        /// <summary>
        /// The method which binds an attempt to a verification
        /// </summary>
        /// <param name="verification">A class representing a verification</param>
        /// <returns>The current instance of <see cref="TestVerificationToRunnerBuilder&lt;TSutDependencies, TSut, TResult&gt;"/></returns>
        public TestVerificationToRunnerBuilder<TSutDependencies, TSut, TResult> Then(Verification<TSutDependencies, TSut, TResult> verification)
        {
            verification.BindToTheAttempt(_attempt);
            return new TestVerificationToRunnerBuilder<TSutDependencies, TSut, TResult>(this, _testRunner);
        }
    }
}
