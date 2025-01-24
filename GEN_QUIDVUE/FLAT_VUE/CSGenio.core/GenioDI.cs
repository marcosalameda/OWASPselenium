using CSGenio.core.messaging;
using CSGenio.core.scheduler;
using CSGenio.framework;
using CSGenio.persistence;
using GenioServer.security;
using System;

namespace CSGenio.core.di
{
    /// <summary>
    /// Service locator for GenioServer singleton classes.
    /// Allows for injection of proxys during testing and more reusable program startup.
    /// </summary>
    /// <seealso cref="GenioDIDefault"/>
    public static class GenioDI
    {
        /// <summary>
        /// Constructor for the specific database vendor providers
        /// </summary>
        public static Func<DatabaseType, PersistentSupport> SpFactory { get; set; } = null;

        /// <summary>
        /// Access to the Messaging service
        /// </summary>
        public static MessagingService Messaging { get; set; } = null;

        /// <summary>
        /// Access to the Scheduler service
        /// </summary>
        public static SchedulerService Scheduler { get; set; } = null;

        /// <summary>
        /// Error logger
        /// </summary>
        public static ILogImpl Log { get; set; } = null;

        /// <summary>
        /// EPH association manager for user registration functions
        /// </summary>
        public static IUserBusinessManager EphManager { get; set; } = null;

        /// <summary>
        /// EPH association manager for user registration functions
        /// </summary>
        public static IMetricsOtlp MetricsOtlp { get; set; } = null;

        //-----------
        // TODO:
        // 1 - Configuration needs to be moved from static class to instance and its singleton kept here
        // 2 - OverrideQuery class is being reallocated multiple times and can be registered here
        // 3 - ElasticSearch service has conditional generated classes, needs restructuring to have always some stub class 
        //-----------
    }

}
