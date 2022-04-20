using Flottio.Annotations;
using System;

namespace Flottio.FuelCardMonitoring.Monitoring
{
    /**
	 * The JMX monitoring bean for monitoring
	 */
    [DomainService]
    public class FuelCardJMXBean
    {

        private readonly static FuelCardJMXBean INSTANCE = new FuelCardJMXBean();

        public String onRequest()
        {
            return null;
        }
    }
}