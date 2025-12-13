using TestTale.Common;
using TestTale.Parameterless.Situations;
using TestTale.Parameterless.Verifications;

namespace TestTale.Parameterless.Attempts
{
    /// <summary>
    /// The class representing a client attempt to use some functionality.
    /// The attempt itself means some method of the system under test (Sut)/>
    /// </summary>
    /// <typeparam name="TSutDependencies">System under test dependencies type</typeparam>
    /// <typeparam name="TSut">System under test type</typeparam>
    /// <typeparam name="TResult">Result of the system under test type</typeparam>
    public abstract class Attempt<TSutDependencies, TSut, TResult> : IAttemptInvokeable where TSutDependencies : ISutDependencies<TSut>
    {
        /// <summary>
        /// The function representing an attempt
        /// </summary>
        public abstract Func<TResult> AttemptFunc { get; }

        /// <summary>
        /// The method which binds the SutDependances to the current attempt
        /// </summary>
        /// <param name="sutDependances"></param>
        public void Bind(TSutDependencies sutDependances)
        {
            if (sutDependances is null) throw new ArgumentNullException(nameof(sutDependances), "SutDependances should not be null");
            if (sutDependances.SUT is null) throw new ArgumentNullException(nameof(sutDependances.SUT), "SutDependances should contain Sut");
            SutDependencies =  sutDependances;
        }
        /// <summary>
        /// The output result obtained after attempt performed
        /// </summary>
        public TResult? Result { get; private set; }
        /// <summary>
        /// Collection of registered situations
        /// </summary>
        public List<Situation<TSutDependencies, TSut, TResult>> Situations { get; } = [];
        /// <summary>
        /// Collection of registered verifications
        /// </summary>
        public List<Verification<TSutDependencies, TSut, TResult>> Verifications { get; } = [];

        /// <summary>
        /// The method invoking the curremt attempt
        /// </summary>
        public void InvokeAttempt()
        {
            if (AttemptFunc is null) throw new ArgumentNullException(nameof(AttemptFunc), "AttemptFunc should not be null");
            InvokeSituations();
            Result = AttemptFunc.Invoke();
            InvokeVerifications();
        }
        /// <summary>
        /// The method invoking the curremt attempt asynchronously
        /// </summary>
        /// <returns>A task of the method</returns>
        public async Task InvokeAttemptAsync()
        {
            if (AttemptFunc is null) throw new ArgumentNullException(nameof(AttemptFunc), "AttemptFunc should not be null");
            InvokeSituations();
            Result = await Task.Run(AttemptFunc);
            InvokeVerifications();
        }
        /// <summary>
        /// System under test
        /// </summary>
        public TSut Sut
        {
            get
            {
                if (SutDependencies is null)
                {
                    throw new InvalidOperationException("SutDependencies can not be null");
                }
                return SutDependencies.SUT;
            }
        }

        private TSutDependencies? _sutDependencies;
        /// <summary>
        /// <inheritdoc cref="ISutDependencies&lt;T&gt;" path="/summary"/>
        /// </summary>
        public TSutDependencies SutDependencies
        {
            get
            {
                if (_sutDependencies is null)
                {
                    throw new InvalidOperationException("SutDependencies can not be null");
                }
                return _sutDependencies;
            }
            set
            {
                _sutDependencies = value;
            }
        }

        private void InvokeSituations()
        {
            foreach (var situation in Situations)
            {
                situation.Action.Invoke();
            }
        }
        private void InvokeVerifications()
        {
            foreach (var verification in Verifications)
            {
                verification.Verify();
            }
        }
    }
}
