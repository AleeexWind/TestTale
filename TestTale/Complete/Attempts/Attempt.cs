using TestTale.Common;
using TestTale.Complete.Parameters;
using TestTale.Complete.Situations;
using TestTale.Complete.Verifications;

namespace TestTale.Complete.Attempts
{
    /// <summary>
    /// The class representing a client attempt to use some functionality.
    /// The attempt itself means some method of the system under test (Sut)/>
    /// </summary>
    /// <typeparam name="TSutDependencies">System under test dependencies type</typeparam>
    /// <typeparam name="TSut">System under test type</typeparam>
    /// <typeparam name="TParameters">Parameters of the system under test type</typeparam>
    /// <typeparam name="TResult">Result of the system under test type</typeparam>
    public abstract class Attempt<TSutDependencies, TSut, TParameters, TResult> : IAttemptInvokeable where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
    {
        private TParameters? _parameters;
        /// <summary>
        /// Input parameters which is needed to test a piece of functionality
        /// </summary>
        public TParameters Parameters
        {
            get
            {
                if (_parameters is null) throw new ArgumentNullException(nameof(_parameters), "Parameters can not be null");
                return _parameters;
            }
            set
            {
                if (value is null) throw new ArgumentNullException(nameof(value), "Parameters can not be null");
                _parameters = value;
            }
        }
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
            SutDependencies = sutDependances;
        }
        /// <summary>
        /// The output result obtained after attempt performed
        /// </summary>
        public TResult? Result { get; private set; }
        /// <summary>
        /// Collection of registered situations
        /// </summary>
        public List<Situation<TSutDependencies, TSut, TParameters, TResult>> Situations { get; } = [];
        /// <summary>
        /// Collection of registered verifications
        /// </summary>
        public List<Verification<TSutDependencies, TSut, TParameters, TResult>> Verifications { get; } = [];

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
        protected TSut Sut
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
