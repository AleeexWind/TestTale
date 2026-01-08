using TestTale.Common;
using TestTale.Complete.Attempts;
using TestTale.Complete.Parameters;
using TestTale.Complete.Verifications;

namespace TestTale.Complete.TestBuilders
{
    /// <summary>
    /// The class which register a verification
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TParameters, TResult}" path="//typeparam"/>
    public class TestVerificationBuilder<TSutDependencies, TSut, TParameters, TResult> where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
    {
        private readonly Attempt<TSutDependencies, TSut, TParameters, TResult> _attempt;
        private readonly TestRunner _testRunner;
        /// <summary>
        /// 
        /// </summary>
        /// <param name="attempt"></param>
        /// <exception cref="ArgumentNullException"></exception>
        public TestVerificationBuilder(Attempt<TSutDependencies, TSut, TParameters, TResult> attempt)
        {
            _attempt = attempt ?? throw new ArgumentNullException(nameof(attempt));
            _testRunner = new TestRunner(_attempt);
        }
        /// <summary>
        /// The method which binds an attempt to a verification
        /// </summary>
        /// <param name="verification">A class representing a verification</param>
        /// <returns>An instance of <see cref="TestVerificationToRunnerBuilder&lt;TSutDependencies, TSut, TParameters, TResult&gt;"/></returns>
        public TestVerificationToRunnerBuilder<TSutDependencies, TSut, TParameters, TResult> Then(Verification<TSutDependencies, TSut, TParameters, TResult> verification)
        {
            verification.BindToTheAttempt(_attempt);
            return new TestVerificationToRunnerBuilder<TSutDependencies, TSut, TParameters, TResult>(this, _testRunner);
        }
    }
}
