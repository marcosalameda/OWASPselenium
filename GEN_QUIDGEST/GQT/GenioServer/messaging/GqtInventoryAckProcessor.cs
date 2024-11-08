using CSGenio.business;
using CSGenio.core.messaging;
using System.Collections.Generic;

namespace CSGenio.messaging
{
    public class GqtInventoryAckProcessor : IAckProcessor
    {
        /// <inheritdoc/>
        public void Process(AckMessage ack)
        {
            // USE /[MANUAL GQT MESSAGE_ACK GQTINVENTORY]/
        }
    }
}