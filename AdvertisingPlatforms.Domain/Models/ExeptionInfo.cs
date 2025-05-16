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
        public string EndPoint { get; }
        /// <summary>
        /// Type exception.
        /// </summary>
        public string Type { get; }
        /// <summary>
        /// Details exception.
        /// </summary>
        public List<string?>? Details { get; }

        /// <summary>
        /// Create information about exception.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="title"></param>
        /// <param name="endPoint"></param>
        /// <param name="details"></param>
        public ExceptionInfo(string type, string title, string endPoint,  List<string?>? details = null)
        {
            Title = title;
            EndPoint = endPoint;
            Type = type;
            Details = details;
        }
    }
}
