namespace TestTale.Common
{
    /// <summary>
    /// 
    /// </summary>
    public interface IAttemptInvokeable
    {
        /// <summary>
        /// 
        /// </summary>
        void InvokeAttempt();
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        Task InvokeAttemptAsync();
    }
}
