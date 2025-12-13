namespace TestTale
{
    /// <summary>
    /// A system under test with dependencies. In other words it is a piece of functionality with its depandencies which needed to test
    /// </summary>
    /// <typeparam name="T">A type of the system under test</typeparam>
    public interface ISutDependencies<T>
    {
        /// <summary>
        /// A system under test. Means a piece of functionality which needed to test
        /// </summary>
        T SUT { get; }
    }
}
