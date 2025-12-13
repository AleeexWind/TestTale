namespace TestTale.Common
{
    /// <summary>
    /// The class which runs a test.
    /// </summary>
    public class TestRunner
    {
        private readonly IAttemptInvokeable _attempt;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="attempt">A class representing an attempt</param>
        /// <exception cref="ArgumentNullException">An exception raising if the attempt is invalid</exception>
        public TestRunner(IAttemptInvokeable attempt)
        {
            _attempt = attempt ?? throw new ArgumentNullException(nameof(attempt));
        }
        /// <summary>
        /// The method which runs a test asynchronously
        /// </summary>
        /// <returns>A task of the method</returns>
        public async Task RunAsync()
        {
            await _attempt.InvokeAttemptAsync();
        }
        /// <summary>
        /// The method which runs a test
        /// </summary>
        public void Run()
        {
            _attempt.InvokeAttempt();
        }
    }
}
