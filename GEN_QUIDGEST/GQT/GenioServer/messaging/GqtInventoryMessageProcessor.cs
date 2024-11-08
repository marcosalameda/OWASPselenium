using CSGenio.business;
using CSGenio.core.messaging;
using System.Collections.Generic;

namespace CSGenio.messaging
{
    public class GqtInventoryMessageProcessor : IMessageProcessor
    {
        /// <inheritdoc/>
        public void Process(IProcessorResponse response, AreaDataset dataset, SubscriberMetadata meta)
        {
            // USE /[MANUAL GQT MESSAGE_PROCESS GQTINVENTORY]/
        }
    }
}