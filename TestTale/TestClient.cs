using TestTale.Complete.Attempts;
using TestTale.Complete.Parameters;
using TestTale.Complete.TestBuilders;
using TestTale.Parameterless.Attempts;
using TestTale.Parameterless.TestBuilders;

namespace TestTale.TestClients
{
    /// <summary>
    /// An actor from the point of view of which the functionality is being tested
    /// </summary>
    public class TestClient
    {
        /// <summary>
        /// The method which binds the client to an attempt
        /// </summary>
        /// <param name="attempt">A class representing an attempt</param>
        /// <returns>The current instance of <see cref="TestSituationBuilder&lt;TSutDependencies, TSut, TResult&gt;"/></returns>
        public static TestSutDependencesBuilder<TSutDependencies, TSut, TResult> Attempts<TSutDependencies, TSut, TResult>(Attempt<TSutDependencies, TSut, TResult> attempt) where TSutDependencies : ISutDependencies<TSut>
        {
            return new TestSutDependencesBuilder<TSutDependencies, TSut, TResult>(attempt);
        }
        /// <summary>
        /// The method which binds the client to an attempt
        /// </summary>
        /// <param name="attemptFunc">A function representing an attempt</param>
        /// <returns>The current instance of <see cref="TestSituationBuilder&lt;TSutDependencies, TSut, TResult&gt;"/></returns>
        public static TestSutDependencesBuilder<TSutDependencies, TSut, TResult> Attempts<TSutDependencies, TSut, TResult>(Func<TResult> attemptFunc) where TSutDependencies : ISutDependencies<TSut>
        {
            var attempt = new AttemptAsFunc<TSutDependencies, TSut, TResult>(attemptFunc);
            return new TestSutDependencesBuilder<TSutDependencies, TSut, TResult>(attempt);
        }
        /// <summary>
        /// The method which binds the client to an attempt
        /// </summary>
        /// <param name="methodName">A method name which representing the method under test. The method should be nested in the TSut</param>
        /// <returns>The current instance of <see cref="TestSituationBuilder&lt;TSutDependencies, TSut, TResult&gt;"/></returns>
        /// <exception cref="MissingMethodException"></exception>
        public static TestSutDependencesBuilder<TSutDependencies, TSut, TResult> Attempts<TSutDependencies, TSut, TResult>(string methodName) where TSutDependencies : ISutDependencies<TSut>
        {
            var sutType = typeof(TSut);
            var mut = sutType.GetMethod(methodName);
            if (mut == null)
            {
                throw new MissingMethodException($"Method {methodName} not found in Sut");
            }

            var attempt = new AttemptAsMethodName<TSutDependencies, TSut, TResult>(mut);
            return new TestSutDependencesBuilder<TSutDependencies, TSut, TResult>(attempt);
        }
        /// <summary>
        /// The method which binds the client to an attempt
        /// </summary>
        /// <param name="attempt">A class representing an attempt</param>
        /// <returns>The current instance of <see cref="TestSituationBuilder&lt;TSutDependencies, TSut, TParameters, TResult&gt;"/></returns>
        public static TestSutDependencesBuilder<TSutDependencies, TSut, TParameters, TResult> Attempts<TSutDependencies, TSut, TParameters, TResult>(Attempt<TSutDependencies, TSut, TParameters, TResult> attempt) where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
        {
            return new TestSutDependencesBuilder<TSutDependencies, TSut, TParameters, TResult>(attempt);
        }
        /// <summary>
        /// The method which binds the client to an attempt
        /// </summary>
        /// <param name="attemptFunc">A function representing an attempt</param>
        /// <returns>The current instance of <see cref="TestSituationBuilder&lt;TSutDependencies, TSut, TParameters, TResult&gt;"/></returns>
        public static TestSutDependencesBuilder<TSutDependencies, TSut, TParameters, TResult> Attempts<TSutDependencies, TSut, TParameters, TResult>(Func<TParameters, TResult> attemptFunc) where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
        {
            var attempt = new AttemptAsFunc<TSutDependencies, TSut, TParameters, TResult>(attemptFunc);
            return new TestSutDependencesBuilder<TSutDependencies, TSut, TParameters, TResult>(attempt);
        }
        /// <summary>
        /// The method which binds the client to an attempt
        /// </summary>
        /// <param name="methodName">A method name which representing the method under test. The method should be nested in the TSut</param>
        /// <returns>The current instance of <see cref="TestSituationBuilder&lt;TSutDependencies, TSut, TParameters, TResult&gt;"/></returns>
        /// <exception cref="MissingMethodException"></exception>
        public static TestSutDependencesBuilder<TSutDependencies, TSut, TParameters, TResult> Attempts<TSutDependencies, TSut, TParameters, TResult>(string methodName) where TSutDependencies : ISutDependencies<TSut> where TParameters : IAttemptParameters
        {
            var sutType = typeof(TSut);
            var mut = sutType.GetMethod(methodName);
            if (mut == null)
            {
                throw new MissingMethodException($"Method {methodName} not found in Sut");
            }

            var attempt = new AttemptAsMethodName<TSutDependencies, TSut, TParameters, TResult>(mut);
            return new TestSutDependencesBuilder<TSutDependencies, TSut, TParameters, TResult>(attempt);
        }
    }
}
