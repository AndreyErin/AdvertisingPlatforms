namespace AdvertisingPlatforms.Domain.Models
{
    /// <summary>
    /// Exception information.
    /// </summary>
    public class ExceptionInfo
    {
        /// <summary>
        /// Title exception.
        /// </summary>
        public string Title { get; }
        /// <summary>
        /// EndPoint exception.
        /// </summary>
        public string? EndPoint { get; }
        /// <summary>
        /// Type exception.
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// StackTrace exception.
        /// </summary>
        public string? StackTrace { get; set; }

        /// <summary>
        /// Inner exception.
        /// </summary>
        public ExceptionInfo? InnerExceptionInfo { get; set; }


        /// <summary>
        /// Create information about exception.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <param name="endPoint"></param>
        /// <param name="stackTrace"></param>
        public ExceptionInfo(string type, string title, string? endPoint = null,  string? stackTrace = null)
        {
            Title = title;
            EndPoint = endPoint;
            Type = type;
            StackTrace = stackTrace;
            InnerExceptionInfo = null;
        }
    }
}
