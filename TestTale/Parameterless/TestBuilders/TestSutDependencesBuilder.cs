using TestTale.Parameterless.Attempts;

namespace TestTale.Parameterless.TestBuilders
{
    /// <summary>
    /// The class which register a sut dependencies
    /// </summary>
    /// <inheritdoc cref="Attempt{TSutDependencies, TSut, TResult}" path="//typeparam"/>
    public class TestSutDependencesBuilder<TSutDependencies, TSut, TResult> where TSutDependencies : ISutDependencies<TSut>
    {
        private readonly Attempt<TSutDependencies, TSut, TResult> _attempt;
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        /// <param name="attempt"></param>
        public TestSutDependencesBuilder(Attempt<TSutDependencies, TSut, TResult> attempt)
        {
            _attempt = attempt ?? throw new ArgumentNullException(nameof(attempt));
        }

        /// <summary>
        /// The method which binding <see cref="ISutDependencies&lt;T&gt;"/> with the client
        /// </summary>
        /// <param name="sutDependances"></param>
        /// <returns>An instance of <see cref="TestSituationBuilder&lt;TSutDependencies, TSut, TResult&gt;"/></returns>
        public TestSituationBuilder<TSutDependencies, TSut, TResult> Using(TSutDependencies sutDependances)
        {
            _attempt.SutDependencies = sutDependances;
            return new TestSituationBuilder<TSutDependencies, TSut, TResult>(_attempt);
        }
    }
}
