namespace FTask.Api.HealthChecks
{
    /// <summary>
    /// Health check model
    /// </summary>
    public class HealthCheck
    {
        /// <summary>
        /// Status
        /// </summary>
        /// <value></value>
        public string Status { get; set; }

        /// <summary>
        /// Name component
        /// </summary>
        /// <value></value>
        public string Component { get; set; }

        /// <summary>
        /// Description
        /// </summary>
        /// <value></value>
        public string Description { get; set; }
    }
}