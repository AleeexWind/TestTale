using TestTale.Complete.Attempts;
using TestTale.Complete.Parameters;

namespace TestTale.Complete.TestBuilders
{
    /// <summary>
    /// The class which creates a client binding to input parameters
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TParameters, TResult}" path="//typeparam"/>
    public class TestAttemptParameterBuilder<TSutDependencies, TSut, TParameters, TResult> where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
    {
        private readonly Attempt<TSutDependencies, TSut, TParameters, TResult> _attempt;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="attempt">A class representing an attempt</param>
        public TestAttemptParameterBuilder(Attempt<TSutDependencies, TSut, TParameters, TResult> attempt)
        {
            _attempt = attempt;
        }
        /// <summary>
        /// The method which specify that there are no input parameters
        /// </summary>
        /// <returns>An instance of <see cref="TestSituationBuilder&lt;TSutDependencies, TSut, TParameters, TResult&gt;"/></returns>
        public TestSituationBuilder<TSutDependencies, TSut, TParameters, TResult> WithNoParameters()
        {
            return new TestSituationBuilder<TSutDependencies, TSut, TParameters, TResult>(_attempt);
        }
        /// <summary>
        /// The method which specify that there are any input parameters
        /// </summary>
        /// <returns>An instance of <see cref="TestSituationBuilder&lt;TSutDependencies, TSut, TParameters, TResult&gt;"/></returns>
        public TestSituationBuilder<TSutDependencies, TSut, TParameters, TResult> WithAnyParameters()
        {
            var parametersObj = Activator.CreateInstance(typeof(TParameters)) ?? throw new ArgumentNullException("parametersObj");
            var parameters = (TParameters)parametersObj;
            _attempt.Parameters = parameters;

            return new TestSituationBuilder<TSutDependencies, TSut, TParameters, TResult>(_attempt);
        }
        /// <summary>
        /// The method which binds the client to input parameters
        /// </summary>
        /// <param name="parameters">Input parameters which is needed to test a piece of functionality</param>
        /// <returns>An instance of <see cref="TestSituationBuilder&lt;TSutDependencies, TSut, TParameters, TResult&gt;"/></returns>
        public TestSituationBuilder<TSutDependencies, TSut, TParameters, TResult> WithParameters(TParameters parameters)
        {
            _attempt.Parameters = parameters;
            return new TestSituationBuilder<TSutDependencies, TSut, TParameters, TResult>(_attempt);
        }

    }
}
