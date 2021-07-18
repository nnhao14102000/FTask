using System;
using System.Collections.Generic;

namespace FTask.Api.HealthChecks
{
    /// <summary>
    /// Health check response
    /// </summary>
    public class HealthcheckResponse
    {
        /// <summary>
        /// Status
        /// </summary>
        /// <value></value>
        public string Status { get; set; }

        /// <summary>
        /// Checks
        /// </summary>
        /// <value></value>
        public IEnumerable<HealthCheck> Checks {get;set;}

        /// <summary>
        /// Duration of all checks
        /// </summary>
        /// <value></value>
        public TimeSpan Duration {get;set;}
    }
}