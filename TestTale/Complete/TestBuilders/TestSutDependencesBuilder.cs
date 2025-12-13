using TestTale.Complete.Attempts;
using TestTale.Complete.Parameters;

namespace TestTale.Complete.TestBuilders
{
    /// <summary>
    /// The class which register a sut dependencies
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TParameters, TResult}" path="//typeparam"/>
    public class TestSutDependencesBuilder<TSutDependencies, TSut, TParameters, TResult> where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
    {
        private readonly Attempt<TSutDependencies, TSut, TParameters, TResult> _attempt;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="attempt"></param>
        public TestSutDependencesBuilder(Attempt<TSutDependencies, TSut, TParameters, TResult> attempt)
        {
            _attempt = attempt ?? throw new ArgumentNullException(nameof(attempt));
        }

        /// <summary>
        /// The method which binding <see cref="ISutDependencies&lt;T&gt;"/> with the client
        /// </summary>
        /// <param name="sutDependances"></param>
        /// <returns>An instance of <see cref="TestAttemptParameterBuilder&lt;TSutDependencies, TSut, TParameters, TResult&gt;"/></returns>
        public TestAttemptParameterBuilder<TSutDependencies, TSut, TParameters, TResult> Using(TSutDependencies sutDependances)
        {
            _attempt.SutDependencies = sutDependances;
            return new TestAttemptParameterBuilder<TSutDependencies, TSut, TParameters, TResult>(_attempt);
        }
    }
}
